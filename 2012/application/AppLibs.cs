using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Data;
using System.Windows.Forms; 
using System.Data.SqlClient;
using System.Drawing;
using System.Transactions;
using commonClass;

namespace application
{
    public class AppLibs
    {
        //Number of units to read ahead
        private const int constNumberOfReadAheadUnit = 0;
        public static data.tmpDS.codeListDataTable GetTimeScales()
        {
            data.tmpDS.codeListDataTable tbl = new data.tmpDS.codeListDataTable();
            data.tmpDS.codeListRow row;
            for (int idx = 0; idx < AppTypes.myTimeScales.Length; idx++)
            {
                row = tbl.NewcodeListRow();
                row.code = AppTypes.myTimeScales[idx].Code;
                row.description = AppTypes.myTimeScales[idx].Description;
                tbl.AddcodeListRow(row);
            }
            return tbl;
        }
        public static data.tmpDS.codeListDataTable GetCommonStatus()
        {
            data.tmpDS.codeListDataTable tbl = new data.tmpDS.codeListDataTable();
            data.tmpDS.codeListRow row;
            foreach (AppTypes.CommonStatus item in Enum.GetValues(typeof(AppTypes.CommonStatus)))
            {
                row = tbl.NewcodeListRow();
                row.code = ((byte)item).ToString();
                row.byteValue = (byte)item;
                row.description = AppTypes.Type2Text(item);
                tbl.AddcodeListRow(row);
            }
            return tbl;
        }
        public static data.tmpDS.codeListDataTable GetTradeActions()
        {
            data.tmpDS.codeListDataTable tbl = new data.tmpDS.codeListDataTable();
            data.tmpDS.codeListRow row;
            foreach (AppTypes.TradeActions item in Enum.GetValues(typeof(AppTypes.TradeActions)))
            {
                row = tbl.NewcodeListRow();
                row.code = ((byte)item).ToString();
                row.byteValue = (byte)item;
                row.description = AppTypes.Type2Text(item);
                tbl.AddcodeListRow(row);
            }
            return tbl;
        }

        public static DateTime GetWorkDayDate(DateTime frDate, int days) { return frDate.AddDays(days); }

        public static data.baseDS.stockExchangeRow GetStockExchange(string stockCode)
        {
            data.baseDS.stockCodeRow stockRow = SysLibs.FindAndCache_StockCode(stockCode);
            if (stockRow == null) return null;
            data.baseDS.stockExchangeRow stockExchangeRow = SysLibs.FindAndCache_StockExchange(stockRow.stockExchange);
            return stockExchangeRow;
        }
        /// <summary>
        ///  Create records to keep stock transaction (buy,sell...) 
        ///  - transactions
        ///  - investorStock
        /// </summary>
        /// <param name="onDate"></param>
        /// <param name="type"></param>
        /// <param name="stockCode"></param>
        /// <param name="portfolio"></param>
        /// <param name="qty"></param>
        /// <param name="amt"></param>
        public static data.baseDS.transactionsDataTable MakeTransaction(AppTypes.TradeActions type, string stockCode, string portfolioCode, int qty, decimal feePerc,out string errorText)
        {
            errorText="";
            data.baseDS.stockExchangeRow marketRow = GetStockExchange(stockCode);
            if (marketRow == null) return null;

            errorText="";
            DateTime onTime = DateTime.Now;
            //Price
            data.baseDS.priceDataRow priceRow = DbAccess.GetLastPriceData(stockCode);
            if (priceRow == null)
            {
                errorText = Languages.Libs.GetString("cannotDoTransaction");
                return null;
            }
            decimal amt = qty * priceRow.closePrice * marketRow.priceRatio;
            decimal feeAmt = (decimal)Math.Round(feePerc * amt / 100, Settings.sysPrecisionLocal);

            data.baseDS.portfolioRow portfolioRow = DbAccess.GetPortfolio(portfolioCode);
            if (portfolioRow == null)
            {
                errorText = String.Format(Languages.Libs.GetString("dataNotFound"), "[portfolio]");
                return null;
            }
            switch (type)
            {
                case AppTypes.TradeActions.Buy:
                case AppTypes.TradeActions.Accumulate:
                    portfolioRow.usedCapAmt += amt;
                    portfolioRow.usedCapAmt += feeAmt;
                    break;
                default: //Sell
                    portfolioRow.usedCapAmt -= amt;
                    portfolioRow.usedCapAmt += feeAmt;
                    break;
            }
            if (portfolioRow.startCapAmt - portfolioRow.usedCapAmt < 0)
            {
                portfolioRow.CancelEdit();
                errorText = String.Format(Languages.Libs.GetString("outOfMoney"), portfolioRow.startCapAmt - portfolioRow.usedCapAmt - amt - feeAmt);
                return null;
            }

            //Create records to store data 
            data.baseDS.transactionsDataTable transTbl = new data.baseDS.transactionsDataTable();
            data.baseDS.investorStockDataTable investorStockTbl = new data.baseDS.investorStockDataTable();
            data.baseDS.transactionsRow transRow;
            data.baseDS.investorStockRow stockRow;

            transRow = transTbl.NewtransactionsRow();
            commonClass.AppLibs.InitData(transRow);
            transRow.onTime = onTime;
            transRow.tranType = (byte)type;
            transRow.stockCode = stockCode;
            transRow.portfolio = portfolioCode;
            transRow.qty = qty;
            transRow.amt = amt;
            transRow.feeAmt = feeAmt;
            transRow.status = (byte)AppTypes.CommonStatus.Close;
            transTbl.AddtransactionsRow(transRow);

            //Update stock
            DateTime onDate = onTime.Date;
            switch (type)
            {
                case AppTypes.TradeActions.Buy:
                case AppTypes.TradeActions.Accumulate:
                    investorStockTbl.Clear();
                    DbAccess.LoadData(investorStockTbl, stockCode, portfolioCode, onDate);
                    if (investorStockTbl.Count == 0)
                    {
                        stockRow = investorStockTbl.NewinvestorStockRow();
                        commonClass.AppLibs.InitData(stockRow);
                        stockRow.buyDate = onDate;
                        stockRow.stockCode = stockCode;
                        stockRow.portfolio = portfolioCode;
                        investorStockTbl.AddinvestorStockRow(stockRow);
                    }
                    stockRow = investorStockTbl[0];
                    stockRow.qty += qty; stockRow.buyAmt += amt;
                    break;
                default: //Sell
                    DateTime applicableDate = onDate.AddDays(-marketRow.minBuySellDay);
                    investorStockTbl.Clear();
                    DbAccess.LoadData(investorStockTbl, stockCode, portfolioCode);
                    decimal remainQty = qty;
                    for (int idx = 0; idx < investorStockTbl.Count; idx++)
                    {
                        if (investorStockTbl[idx].buyDate > applicableDate) continue;
                        if (investorStockTbl[idx].qty >= remainQty)
                        {
                            investorStockTbl[idx].buyAmt = (investorStockTbl[idx].qty - remainQty) * (investorStockTbl[idx].qty == 0 ? 0 : investorStockTbl[idx].buyAmt / investorStockTbl[idx].qty);
                            investorStockTbl[idx].qty = (investorStockTbl[idx].qty - remainQty);
                            remainQty = 0;
                        }
                        else
                        {
                            remainQty -= investorStockTbl[idx].qty;
                            investorStockTbl[idx].buyAmt = 0;
                            investorStockTbl[idx].qty = 0;
                        }
                        if (remainQty == 0) break;
                    }
                    if (remainQty > 0)
                    {
                        errorText =  String.Format(Languages.Libs.GetString("outOfQty"), qty - remainQty);
                        return null;
                    }
                    break;
            }
            //Delete empty stock
            for (int idx = 0; idx < investorStockTbl.Count; idx++)
            {
                if (investorStockTbl[idx].qty != 0) continue;
                investorStockTbl[idx].Delete();
            }

            //Update data with transaction support
            TransactionScopeOption tranOption;
            tranOption = (commonClass.SysLibs.sysUseTransactionInUpdate ? TransactionScopeOption.Required : TransactionScopeOption.Suppress);
            using (TransactionScope scope = new TransactionScope(tranOption))
            {
                DbAccess.UpdateData(portfolioRow);
                DbAccess.UpdateData(investorStockTbl);
                DbAccess.UpdateData(transTbl);
                scope.Complete();
            }
            return transTbl;
        }

        /// <summary>
        /// Load stock price data withd some point ahead of the specified date range
        /// </summary>
        /// <param name="stockCode"></param>
        /// <param name="frDate">Start date </param>
        /// <param name="toDate">End date</param>
        /// <param name="timeScale">Time scale</param>
        /// <param name="noUnitAhead">the number of units(minute,day,hour,week...) to read beyond the start time[frDate].</param>
        /// <param name="toTbl">Table keeps loaded data</param>
        /// <param name="startIdx">specify the row where the data in [frDate,toDate] range starts</param>
        public static void LoadAnalysisData(AnalysisData dataObj)
        {
            //commonClass.SysLibs.WriteSystemLog("LoadAnalysisData", dataObj.DataStockCode, dataObj.DataMaxCount.ToString());

            int startIdx = dataObj.priceDataTbl.Count;
            if (dataObj.DataTimeRange == commonClass.AppTypes.TimeRanges.None)
            {
                dataObj.priceDataTbl.Clear();
                DbAccess.LoadData(dataObj.priceDataTbl, dataObj.DataTimeScale.Code, dataObj.DataStockCode, dataObj.DataMaxCount + constNumberOfReadAheadUnit);
                dataObj.FirstDataStartAt = 0;
                return;
            }
            int noUnitAhead = constNumberOfReadAheadUnit;

            DateTime toDate = common.Consts.constNullDate;
            DateTime frDate = common.Consts.constNullDate;
            if (!commonClass.AppTypes.GetDate(dataObj.DataTimeRange, out frDate, out toDate)) return;

            data.baseDS.priceDataStatDataTable priceStatTbl = DbAccess.GetPriceDataStat(dataObj.DataTimeScale, dataObj.DataStockCode);
            if (priceStatTbl.Count == 0) return;
            DateTime dataMaxDateTime = priceStatTbl[0].maxDate;
            DateTime dataMinDateTime = priceStatTbl[0].minDate;
            int dataTotalCount = priceStatTbl[0].totalCount;

            if (toDate > dataMaxDateTime) toDate = dataMaxDateTime;
            if (frDate < dataMinDateTime) frDate = dataMinDateTime;
            dataObj.priceDataTbl.Clear();
            if (noUnitAhead != 0)
            {
                // Find start date that return sufficient rows as required by [noBarAhead]
                DateTime checkFrDate = common.Consts.constNullDate;
                DateTime checkToDate = frDate.AddSeconds(-1);
                int totalGotRowCount = 0, gotRowCount;
                decimal rangeScale = 1;
                //int loopPass = 0;
                while (true)
                {
                    //loopPass++;
                    switch (dataObj.DataTimeScale.Type)
                    {
                        case commonClass.AppTypes.TimeScaleTypes.Minnute:
                            checkFrDate = checkToDate.AddMinutes(-(int)(noUnitAhead * rangeScale));
                            break;
                        case commonClass.AppTypes.TimeScaleTypes.Hour:
                            checkFrDate = checkToDate.AddHours(-(int)(noUnitAhead * rangeScale));
                            break;
                        case commonClass.AppTypes.TimeScaleTypes.Day:
                            checkFrDate = checkToDate.AddDays(-(int)(noUnitAhead * rangeScale));
                            break;
                        case commonClass.AppTypes.TimeScaleTypes.Week:
                            checkFrDate = checkToDate.AddDays(-(int)(7 * noUnitAhead * rangeScale));
                            break;
                        case commonClass.AppTypes.TimeScaleTypes.Month:
                            checkFrDate = checkToDate.AddMonths(-(int)(noUnitAhead * rangeScale));
                            break;
                        case commonClass.AppTypes.TimeScaleTypes.Year:
                            checkFrDate = checkToDate.AddYears(-(int)(noUnitAhead * rangeScale));
                            break;
                        case commonClass.AppTypes.TimeScaleTypes.RealTime:
                            //checkFrDate = checkToDate.AddMinutes(-(int)(commonClass.Settings.sysAutoRefreshInSeconds * noUnitAhead * rangeScale) / 60);
                            checkFrDate = checkToDate.AddMinutes(-(int)(noUnitAhead * rangeScale));
                            break;
                        default: common.system.ThrowException("Invalid parametter in calling to LoadStockPrice()");
                            break;
                    }
                    gotRowCount = DbAccess.GetTotalPriceRow(dataObj.DataTimeScale, checkFrDate, checkToDate, dataObj.DataStockCode);
                    //No more data ??
                    if (checkFrDate < dataMinDateTime) break;
                    //Sufficient data ??
                    totalGotRowCount += gotRowCount;
                    if (totalGotRowCount >= noUnitAhead) break;

                    //No data load means the check range not big enough, increse rangeScale by 5 to make it larger scale
                    if (gotRowCount == 0) rangeScale += 5;
                    else
                    {
                        //Estimate the best range scale 
                        // Increase total left sligtly by 3% with the hope that it can take all need.
                        // 5 and 3% had been tested indifferent cases and see that they are the best value.
                        decimal tmpRangeScale = rangeScale * (decimal)(noUnitAhead - totalGotRowCount + noUnitAhead * 0.03) / gotRowCount;
                        rangeScale = (tmpRangeScale > 0 ? tmpRangeScale : rangeScale + 5);
                    }
                    checkToDate = checkFrDate.AddSeconds(-1);
                }
                DbAccess.LoadData(dataObj.priceDataTbl, dataObj.DataTimeScale.Code, checkFrDate, frDate.AddSeconds(-1), dataObj.DataStockCode);
                startIdx = dataObj.priceDataTbl.Count - startIdx;
            }
            DbAccess.LoadData(dataObj.priceDataTbl, dataObj.DataTimeScale.Code, frDate, toDate, dataObj.DataStockCode);
            dataObj.FirstDataStartAt = startIdx;
        }

        public static void _LoadAnalysisData(AnalysisData dataObj)
        {
            int startIdx = dataObj.priceDataTbl.Count;
            dataObj.priceDataTbl.Clear();
            DbAccess.LoadData(dataObj.priceDataTbl, dataObj.DataTimeScale.Code, dataObj.DataStockCode, dataObj.DataMaxCount + constNumberOfReadAheadUnit);
            dataObj.FirstDataStartAt = 0;
        }

        //Updated data from the last read/update point
        public static int UpdateAnalysisData(AnalysisData dataObj)
        {
            int lastDataIdx = dataObj.priceDataTbl.Count - 1;
            DateTime lastDateTime;
            if (lastDataIdx < 0) lastDateTime = commonClass.Settings.sysStartDataDate;
            else lastDateTime = dataObj.priceDataTbl[lastDataIdx].onDate;

            data.baseDS.priceDataDataTable tbl = new data.baseDS.priceDataDataTable();
            DbAccess.LoadData(tbl, dataObj.DataTimeScale.Code, lastDateTime, dataObj.DataStockCode);
            if (tbl.Count > 0)
            {
                //Delete the last data because the updated data will include this one.
                if (lastDataIdx >= 0)
                {
                    dataObj.priceDataTbl[lastDataIdx].ItemArray = tbl[0].ItemArray;
                    commonClass.AppLibs.DataConcat(tbl, 1, dataObj.priceDataTbl);
                }
                else commonClass.AppLibs.DataConcat(tbl, 0, dataObj.priceDataTbl);
            }
            return dataObj.priceDataTbl.Count - 1 - lastDataIdx;
        }


        //Syslog
        public static void WriteSyslog(AppTypes.SyslogMedia media, AppTypes.DataAccessMode accessMode, AppTypes.SyslogTypes logType, 
                                       string investorCode, string desc, string source, string msg)
        {
            switch (media)
            {
                case AppTypes.SyslogMedia.File :
                    commonClass.SysLibs.WriteSystemLog(logType.ToString(), investorCode,common.stringLibs.MakeString(new string[] { desc, source, msg }, common.Consts.constTab));
                    break;
                case AppTypes.SyslogMedia.Database:
                    switch (accessMode)
                    {
                        case AppTypes.DataAccessMode.Local:
                            DbAccess.WriteSyslog(logType, commonClass.SysLibs.sysLoginCode, desc, source, msg);
                            break;
                        case AppTypes.DataAccessMode.WebService:
                            DataAccess.Libs.WriteSyslog(logType, commonClass.SysLibs.sysLoginCode, desc, source, msg);
                            break;
                    }
                    break;
            }
        }
        public static void WriteSyslog(AppTypes.SyslogMedia media,AppTypes.DataAccessMode accessMode,Exception er)
        {
            switch (media)
            {
                case AppTypes.SyslogMedia.File:
                    commonClass.SysLibs.WriteSystemLog(AppTypes.SyslogTypes.Exception.ToString(), commonClass.SysLibs.sysLoginCode, 
                                                       common.system.MakeLogString(er, common.Consts.constTab));
                    break;
                case AppTypes.SyslogMedia.Database:
                    switch (accessMode)
                    {
                        case AppTypes.DataAccessMode.Local:
                            DbAccess.WriteSyslog(er,commonClass.SysLibs.sysLoginCode);
                            break;
                        case AppTypes.DataAccessMode.WebService:
                            DataAccess.Libs.WriteSyslog(er, commonClass.SysLibs.sysLoginCode);
                            break;
                    }
                    break;
            }            
        }
    }
}
