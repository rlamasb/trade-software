using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using application;

namespace Trade
{
    public class Libs
    {
        #region strategy estimation
        public delegate void onProcessStart(int stockCodeCount);
        public delegate bool onProcessItem(string stockcode);
        public delegate void onProcessEnd();

        private class TradeAlert
        {
            public Strategy.TradePointInfo TradePoint = null;
            public AppTypes.TimeScale TimeScale =  AppTypes.MainDataTimeScale;
            public string StockCode="", Strategy="";
            public DateTime OnDateTime = common.Consts.constNullDate;
            public double Price=0,Volume=0;
            public TradeAlert(string stockCode, string strategy, AppTypes.TimeScale timeScale, DateTime onDateTime, 
                               double price,double volume,Strategy.TradePointInfo tradePoint)
            {
                this.StockCode = stockCode;
                this.TimeScale = timeScale;
                this.Strategy = strategy;
                this.OnDateTime = onDateTime;
                this.Price = price;
                this.Volume = volume;
                this.TradePoint = tradePoint;
            }
        }

        private static void SaveLastRunTime(DateTime onTime)
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Add(configuration.configKeys.sysTradeAlertLastRun.ToString());
            aValues.Add(onTime.ToString());
            configuration.SaveConfig(aFields, aValues);
        }


        
        //withAplicableCheckInAlert = true : Sell alerts only create when user owned stock that is applible to sell
        private static bool withAplicableCheckInAlert = false;

        /// <summary>
        /// Create alerts for all stock in portfolio
        /// </summary>
        /// <param name="alertList"> all alert resulted from analysis </param>
        /// <param name="frDate">Alert will only create alert in range [frDate,toDate].
        /// It also ensure that in the same day,there in ONLY one new alert of the same type</param>
        /// <param name="toDate"></param>
        private static void CreateTradeAlert(TradeAlert[] alertList,DateTime frDate,DateTime toDate)
        {
            decimal availabeQty;
            string msg;
            StringCollection timeScaleList;

            data.baseDS.tradeAlertRow tradeAlertRow;
            data.baseDS.tradeAlertDataTable tradeAlertTbl = new data.baseDS.tradeAlertDataTable();
            data.baseDS.stockCodeDataTable stockCodeTbl = new data.baseDS.stockCodeDataTable();
            data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
            data.baseDS.portfolioDetailDataTable portfolioDetailTbl = new data.baseDS.portfolioDetailDataTable();
            DataView portfolioDetailView = new DataView(portfolioDetailTbl);
            portfolioDetailView.Sort = portfolioDetailTbl.codeColumn.ColumnName;
            DataRowView[] strategyRowFound;

            dataLibs.LoadData(portfolioTbl);
            for (int idx1 = 0; idx1 < portfolioTbl.Count; idx1++)
            {
                // Only alert on stock codes that were selected by user. 
                stockCodeTbl.Clear();
                dataLibs.LoadData(stockCodeTbl, portfolioTbl[idx1]);

                portfolioDetailTbl.Clear();
                //??dataLibs.LoadData(portfolioDetailTbl, portfolioTbl[idx1].code, AppTypes.PortfolioDetailDataType.Strategy);

                for (int idx2 = 0; idx2 < alertList.Length; idx2++)
                {
                    // Check if alert's strategy in user's wish list ??
                    strategyRowFound = portfolioDetailView.FindRows(alertList[idx2].Strategy.Trim());
                    if (strategyRowFound.Length == 0) continue;

                    // Check if time alert's time scale in user's wish list ??
                    timeScaleList = common.MultiValueString.String2List(((data.baseDS.portfolioDetailRow)strategyRowFound[0].Row).data.Trim());
                    if (!timeScaleList.Contains(alertList[idx2].TimeScale.Code)) continue;
                    if (stockCodeTbl.FindBycode(alertList[idx2].StockCode.Trim()) == null) continue;

                    //Do not crete alert if there is a NEW one.
                    tradeAlertRow = dataLibs.GetLastAlert(frDate, toDate, portfolioTbl[idx1].code, alertList[idx2].StockCode,
                                                          alertList[idx2].Strategy,
                                                          alertList[idx2].TimeScale.Code,
                                                          (byte)application.AppTypes.CommonStatus.New);
                    if (tradeAlertRow != null) continue;

                    //Availabe stock
                    if (withAplicableCheckInAlert)
                    {
                        availabeQty = application.dataLibs.GetAvailableStock(alertList[idx2].StockCode, portfolioTbl[idx1].code,
                                                               application.Settings.sysStockSell2BuyInterval, alertList[idx2].OnDateTime);
                    }
                    else availabeQty = int.MaxValue;

                    //Aplicable to sell
                    if ((alertList[idx2].TradePoint.TradeAction == AppTypes.TradeActions.Sell ||
                          alertList[idx2].TradePoint.TradeAction == AppTypes.TradeActions.ClearAll) && (availabeQty <= 0)) continue;
                    msg = " - Giá : " + alertList[idx2].Price.ToString() + common.Consts.constCRLF +
                          " - K/L giao dịch : " + alertList[idx2].Volume.ToString() + common.Consts.constCRLF +
                          " - Xu hướng : (" + alertList[idx2].TradePoint.BusinessInfo.ShortTermTrend  + "," +
                                              alertList[idx2].TradePoint.BusinessInfo.MediumTermTrend + "," +
                                              alertList[idx2].TradePoint.BusinessInfo.LongTermTrend + ")" + common.Consts.constCRLF +
                          " - K/L sở hữu hợp lệ : " + availabeQty.ToString() + common.Consts.constCRLF;

                    CreateTradeAlert(tradeAlertTbl, portfolioTbl[idx1], alertList[idx2].StockCode, alertList[idx2].Strategy,
                                    alertList[idx2].TimeScale, alertList[idx2].TradePoint, toDate, msg);
                }
            }
            dataLibs.UpdateData(tradeAlertTbl);
        }

        private static void CreateTradeAlert(data.baseDS.tradeAlertDataTable tradeAlertTbl,data.baseDS.portfolioRow portfolioRow,
                                             string stockCode, string strategy, AppTypes.TimeScale timeScale, Strategy.TradePointInfo info, DateTime onTime, string msg)
        {
            data.baseDS.tradeAlertRow row = tradeAlertTbl.NewtradeAlertRow();
            dataLibs.InitData(row);
            row.onTime = onTime;
            row.portfolio = portfolioRow.code;
            row.stockCode = stockCode;
            row.timeScale = timeScale.Code; 
            row.strategy = strategy; 
            row.status = (byte)AppTypes.CommonStatus.New; 
            row.tradeAction = (byte)info.TradeAction;
            row.subject = info.TradeAction.ToString();
            row.msg = msg;
            tradeAlertTbl.AddtradeAlertRow(row);
        }

        public static void CreateTradeAlert()
        {
            CreateTradeAlert(null, null, null);
        }
        public static void CreateTradeAlert(onProcessStart onStartFunc, onProcessItem onProcessItemFunc, onProcessEnd onEndFunc)
        {
            CultureInfo cultureInfo = new CultureInfo(Settings.sysCultureCode);
            DateTime frDate = common.Consts.constNullDate;
            DateTime toDate = sysLibs.GetServerDateTime();
            
            //Run all strategy analysis for all stocks.
            data.baseDS.stockCodeDataTable stockCodeTbl = new data.baseDS.stockCodeDataTable();
            dataLibs.LoadData(stockCodeTbl, AppTypes.CommonStatus.Enable);

            Data data = new Data();

            TradeAlert[] tradeAlertList = new TradeAlert[0];
            StringCollection strategyList = new StringCollection();
            for (int idx = 0; idx < Strategy.Data.MetaList.Values.Length; idx++)
            {
                Strategy.Meta meta = (Strategy.Meta)Strategy.Data.MetaList.Values[idx];
                if (meta.Type != AppTypes.StrategyTypes.Strategy) continue;
                strategyList.Add(Strategy.Data.MetaList.Keys[idx]);
            }

            if (onStartFunc != null) onStartFunc(stockCodeTbl.Count);

            for (int stockCodeIdx = 0; stockCodeIdx < stockCodeTbl.Count; stockCodeIdx++)
            {
                if (onProcessItemFunc != null)
                    if (!onProcessItemFunc(stockCodeTbl[stockCodeIdx].code)) break;

                foreach (AppTypes.TimeScale timeScale in AppTypes.myTimeScales)
                {
                    //Move date ahead to ensure that there are sufficient data need in analysis process
                    switch (timeScale.Type)
                    {
                        case AppTypes.TimeScaleTypes.RealTime:
                            frDate = toDate.AddHours(-1);
                            break;
                        case AppTypes.TimeScaleTypes.Hour:
                            frDate = toDate.Date;
                            break;
                        case AppTypes.TimeScaleTypes.Day:
                            frDate = toDate.Date;
                            break;
                        case AppTypes.TimeScaleTypes.Week:
                            frDate = common.dateTimeLibs.StartOfWeek(toDate, cultureInfo).AddSeconds(-1);
                            break;
                        case AppTypes.TimeScaleTypes.Month:
                            frDate = common.dateTimeLibs.MakeDate(1, toDate.Month, toDate.Year).AddSeconds(-1);
                            break;
                        case AppTypes.TimeScaleTypes.Year:
                            frDate = common.dateTimeLibs.MakeDate(1, 1, toDate.Year).AddSeconds(-1);
                            break;
                        default:
                            common.system.ThrowException("Invalid parametter in calling to LoadStockPrice()");
                            break;
                    }

                    data.Reload(stockCodeTbl[stockCodeIdx].code,timeScale,frDate, toDate);

                    for (int strategyIdx = 0; strategyIdx < strategyList.Count; strategyIdx++)
                    {
                        Strategy.Libs.ClearCache();
                        Strategy.TradePoints advices = Strategy.Libs.Analysis(data, strategyList[strategyIdx].Trim());
                        if (advices == null) continue;
                        for (int idx3 = 0; idx3 < advices.Count; idx3++)
                        {
                            Strategy.TradePointInfo tradeInfo = (Strategy.TradePointInfo)advices[idx3];
                            Array.Resize(ref tradeAlertList, tradeAlertList.Length + 1);
                            tradeAlertList[tradeAlertList.Length - 1]=
                                new TradeAlert(stockCodeTbl[stockCodeIdx].code.Trim(), strategyList[strategyIdx].Trim(),
                                               timeScale, DateTime.FromOADate(data.DateTime[tradeInfo.DataIdx]),
                                               data.Close[tradeInfo.DataIdx],
                                               data.Volume[tradeInfo.DataIdx],
                                               tradeInfo);

                        }
                    }
                }
            }
            stockCodeTbl.Dispose();

            //Create alerts in the day
            CreateTradeAlert(tradeAlertList,toDate.Date,toDate);

            //Save last lun date
            SaveLastRunTime(toDate);
            if (onEndFunc != null) onEndFunc();
        }
        #endregion
    }
}
