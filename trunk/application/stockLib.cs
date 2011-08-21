using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;
using TicTacTec.TA.Library;

namespace application
{
    public class stockLibs
    {
        #region TALib Wrapper
        public static void ShiftRight(double[] list, int startIdx)
        {
            Array.Copy(list, 0, list, startIdx, list.Length - startIdx);
            for (int idx = 0; idx < startIdx; idx++) list[idx] = 0;
        }

        public static double Max(double[] list)
        {
            return common.math.Max(list,0);
        }
        public static double Max(int[] list)
        {
            return common.math.Max(list , 0);
        }
        public static double Min(double[] list)
        {
            return common.math.Min(list, 0);
        }
        public static double Min(int[] list)
        {
            return common.math.Min(list, 0);
        }

        public static bool MakeStockRSI(int startIdx, int endIdx, double[] list, int rsiPeriod, int fastK_Period, int fastD_Period,
                                        out int begin, out int length,double[] outFastK, double[] outFastD)

        {
            begin = 0; length = 0;
            TicTacTec.TA.Library.Core.RetCode retCode = TicTacTec.TA.Library.Core.RetCode.UnknownErr;
            retCode = TicTacTec.TA.Library.Core.StochRsi(startIdx, endIdx, list, rsiPeriod, fastK_Period, fastD_Period, Core.MAType.Ema,
                                               out begin, out length, outFastK, outFastD);
            if (retCode != TicTacTec.TA.Library.Core.RetCode.Success) return false;
            return true;
        }


        public static bool MakeBBANDS(int startIdx, int endIdx, double[] list, int period,int kUp,int kDn,
                                      out int begin, out int length, double[] outUpperList, double[] outMiddleList, double[] outLowerList)
        {
            begin = 0; length = 0;
            TicTacTec.TA.Library.Core.RetCode retCode = TicTacTec.TA.Library.Core.RetCode.UnknownErr;
            retCode = TicTacTec.TA.Library.Core.Bbands(startIdx, endIdx,list, period,kUp,kDn, Core.MAType.Sma,
                                                       out begin, out length, outUpperList, outMiddleList, outLowerList); 
            if (retCode != TicTacTec.TA.Library.Core.RetCode.Success) return false;
            return true;
        }
        public static bool MakeMovingAverage(myTypes.indicatorType type, int startIdx, int endIdx, double[] list, int avgPeriod,
                                             out int begin, out int length,double[] output)
        {
            begin = 0; length = 0;
            TicTacTec.TA.Library.Core.RetCode retCode = TicTacTec.TA.Library.Core.RetCode.UnknownErr;
            switch (type)
            {
                case myTypes.indicatorType.SMA:
                    retCode = TicTacTec.TA.Library.Core.Sma(startIdx, endIdx, list, avgPeriod, out begin, out length, output); break;
                case myTypes.indicatorType.EMA:
                    retCode = TicTacTec.TA.Library.Core.Ema(startIdx, endIdx, list, avgPeriod, out begin, out length, output); break;
                case myTypes.indicatorType.WMA:
                    retCode = TicTacTec.TA.Library.Core.Wma(startIdx, endIdx, list, avgPeriod, out begin, out length, output); break;
                case myTypes.indicatorType.RSI:
                    retCode = TicTacTec.TA.Library.Core.Rsi(startIdx, endIdx, list, avgPeriod, out begin, out length, output); break;
            }
            if (retCode != TicTacTec.TA.Library.Core.RetCode.Success) return false;
            return true;
        }

        public static bool MakeMACD(int startIdx, int endIdx, double[] list, int fast, int slow, int signal, 
                                    out int begin, out int length, double[] output, double[] sigOutput, double[] histOutput)
        {
            begin = 0; length = 0;
            TicTacTec.TA.Library.Core.RetCode retCode = TicTacTec.TA.Library.Core.Macd(startIdx, endIdx, list, fast, slow, signal,
                                                                                       out begin, out length, output, sigOutput, histOutput);
            if (retCode != TicTacTec.TA.Library.Core.RetCode.Success) return false;
            return true;
        }
        public static bool MakeStochasticFast(int startIdx, int endIdx, double[] hiList, double[] loList, double[] closeList,
                                              int fastK_Period, int fastD_Period,
                                              out int begin, out int length,double[] outFastK, double[] outFastD)
        {
            begin = 0; length = 0;
            Core.RetCode retCode = Core.StochF(startIdx, endIdx, hiList, loList, closeList, fastK_Period, fastD_Period, Core.MAType.Sma,
                                               out begin, out length, outFastK, outFastD);
            if (retCode != TicTacTec.TA.Library.Core.RetCode.Success) return false;
            return true;
        }
        public static bool MakeStochasticSlow(int startIdx, int endIdx, double[] hiList, double[] loList, double[] closeList,
                                              int fastK_Period, int slowK_Period, int slowD_Period, 
                                              out int begin, out int length,double[] outSlowK, double[] outSlowD)
        {
            begin = 0; length = 0;
            Core.RetCode retCode = Core.Stoch(startIdx, endIdx, hiList, loList, closeList, fastK_Period, slowK_Period,
                                              Core.MAType.Sma, slowD_Period, Core.MAType.Sma,
                                              out begin, out length, outSlowK, outSlowD);
            if (retCode != TicTacTec.TA.Library.Core.RetCode.Success) return false;
            return true;
        }

        public static bool MakeDI(myTypes.indicatorType type, int startIdx, int endIdx, double[] hiList, double[] loList, double[] closeList,
                                              int period, out int begin, out int length, double[] output)
        {
            begin = 0; length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;
            switch (type)
            {
                case myTypes.indicatorType.DI: retCode = Core.Dx(startIdx, endIdx, hiList, loList, closeList, period, out begin, out length, output); break;
                case myTypes.indicatorType.DIMinus: retCode = Core.MinusDI(startIdx, endIdx, hiList, loList, closeList, period, out begin, out length, output); break;
                case myTypes.indicatorType.DIPlus: retCode = Core.PlusDI(startIdx, endIdx, hiList, loList, closeList, period, out begin, out length, output); break;
            }
            if (retCode != TicTacTec.TA.Library.Core.RetCode.Success) return false;
            return true;
        }

        public static bool MakeDM(myTypes.indicatorType type, int startIdx, int endIdx, double[] hiList, double[] loList,int period, out int begin, out int length, double[] output)
        {
            begin = 0; length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;
            switch (type)
            {
                case myTypes.indicatorType.DMMinus: retCode = Core.MinusDM(startIdx, endIdx, hiList, loList, period, out begin, out length, output); break;
                case myTypes.indicatorType.DMPlus: retCode = Core.PlusDM(startIdx, endIdx, hiList, loList, period, out begin, out length, output); break;
            }
            if (retCode != TicTacTec.TA.Library.Core.RetCode.Success) return false;
            return true;
        }


        public static myTypes.indicatorType GetIndicatorType(string indicatorCode)
        {
            foreach (myTypes.indicatorType item in Enum.GetValues(typeof(myTypes.indicatorType)))
            {
                if (indicatorCode.StartsWith(item.ToString())) return item;
            }
            return myTypes.indicatorType.None;
        }

        #endregion

        #region indicator data
        public enum stockDataField : byte { OnDate, High, Low, Open, Close, Volume };
        public static double[] MakeDataList(data.baseDS.priceDataDataTable dataTbl, int startIdx, stockDataField dataField)
        {
            double[] list = new double[dataTbl.Count - startIdx];
            switch (dataField)
            {
                case stockDataField.High:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++) list[j] = (double)dataTbl[i].closePrice; break;
                case stockDataField.Low:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++) list[j] = (double)dataTbl[i].lowPrice; break;
                case stockDataField.Open:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++) list[j] = (double)dataTbl[i].openPrice; break;
                case stockDataField.Close:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++) list[j] = (double)dataTbl[i].closePrice; break;
                case stockDataField.Volume:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++) list[j] = (double)dataTbl[i].volume; break;
                case stockDataField.OnDate:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++) list[j] = new XDate(dataTbl[i].onDate); break;
                default:
                    common.system.ThrowException("Invalid dataField in MakeDataList()"); break;
            }
            return list;
        }

        //Load stock price into table toTbl
        // - noBarAhead  : the number of units(minute,day,hour,week...) to read beyond the start time[frDate].
        // - out startIdx : specify the row where the data in [frDate,toDate] range starts
        public static void LoadStockPrice(string stockCode, DateTime frDate, DateTime toDate, myTypes.timeScales timeScale, int noUnitAhead,
                                          data.baseDS.priceDataDataTable toTbl, out int startIdx)
        {
            startIdx = toTbl.Count;
            toTbl.Clear();
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
                    switch (timeScale)
                    {
                        case myTypes.timeScales.Hourly:
                            checkFrDate = checkToDate.AddHours(-(int)(noUnitAhead * rangeScale));
                            break;
                        case myTypes.timeScales.Daily:
                            checkFrDate = checkToDate.AddDays(-(int)(noUnitAhead * rangeScale));
                            break;
                        case myTypes.timeScales.Weekly:
                            checkFrDate = checkToDate.AddDays(-(int)(7*noUnitAhead * rangeScale));
                            break;
                        case myTypes.timeScales.Monthly:
                            checkFrDate = checkToDate.AddMonths(-(int)(noUnitAhead * rangeScale));
                            break;
                        case myTypes.timeScales.Yearly:
                            checkFrDate = checkToDate.AddYears(-(int)(noUnitAhead * rangeScale));
                            break;
                        case myTypes.timeScales.RealTime:
                            checkFrDate = checkToDate.AddMinutes(-(int)(application.Settings.sysAutoRefreshInSeconds * noUnitAhead * rangeScale)/60);
                            //checkFrDate = checkToDate.AddDays(-(int)rangeScale);
                            break;
                        default: common.system.ThrowException("Invalid parametter in calling to LoadStockPrice()");
                            break;
                    }
                    gotRowCount = dataLibs.GetTotalPriceRow(timeScale, checkFrDate,checkToDate, stockCode);
                    //No more data ??
                    if (checkFrDate < application.Settings.sysStartDataDate) break;
                    //Sufficient data ??
                    totalGotRowCount += gotRowCount;
                    if (totalGotRowCount >= noUnitAhead) break;

                    checkToDate = checkFrDate.AddSeconds(-1);
                    if (gotRowCount == 0) rangeScale = noUnitAhead;
                    else
                    {
                        if ( (decimal)(noUnitAhead - totalGotRowCount) / gotRowCount > 0)
                            rangeScale = rangeScale * (decimal)(noUnitAhead - totalGotRowCount) / gotRowCount;
                        if(rangeScale<1) rangeScale=1;
                    }
                }
                dataLibs.LoadData(toTbl, timeScale, checkFrDate, frDate.AddSeconds(-1), stockCode);
                startIdx = toTbl.Count - startIdx;
            }
            dataLibs.LoadData(toTbl,timeScale,frDate, toDate, stockCode);
        }

        public static bool DeleteIndicatorSMA(string indicatorCode, byte[] avgPeriod, DateTime frDate, DateTime toDate)
        {
            for (int count = 0; count < avgPeriod.Length; count++)
            {
                if (avgPeriod[count] == 0) continue;
                string dataCode = indicatorCode.Trim() + avgPeriod[count].ToString();
                dataLibs.DeleteIndicatorData(frDate, toDate, dataCode);
            }
            return true;
        }
        
        //Convert data in a price datatble to point list
        //public static DataPointCollection MakeDataPoints(data.baseDS.indicatorDataDataTable dataTbl, string fldName)
        //{
        //    DataPointCollection points = new DataPointCollection(); 
        //    decimal d;
        //    for (int idx = 0; idx < dataTbl.Count; idx++)
        //    {
        //        d = (decimal)dataTbl[idx][fldName];
        //        if (d == 0) continue;
        //        points.AddXY(dataTbl[idx].onDate, (decimal)dataTbl[idx][fldName]);
        //    }
        //    return points;
        //}
        #endregion indicator data
    }
    public class analysis
    {
        #region analysis core
        public class estimateOptions
        {
            public decimal totalCapAmt = Settings.sysStockTotalCapAmt;
            public decimal maxBuyAmtPerc = Settings.sysStockMaxBuyAmtPerc;
            public decimal qtyReducePerc = Settings.sysStockReduceQtyPerc;
            public decimal qtyAccumulatePerc = Settings.sysStockAccumulateQtyPerc;
            public decimal transFeecPerc = Settings.sysStockTransFeePercent;
            public decimal priceWeight = Settings.sysStockPriceWeight;
            public decimal maxBuyQtyPerc = Settings.sysStockMaxBuyQtyPerc;
            public short buy2SellInterval = Settings.sysStockSell2BuyInterval;
        }

        public class workData
        {
            public workData(){}
            public workData(myTypes.timeScales timeScale,DateTime frDate, DateTime toDate, data.baseDS.stockCodeExtRow stockCodeRow) 
            {
                Init(timeScale, frDate, toDate, stockCodeRow);
            }

            public data.baseDS.stockCodeExtRow stockCodeRow = null;
            public DateTime startDate = common.Consts.constNullDate;
            public DateTime endDate = common.Consts.constNullDate;
            // noDayToReadAhead  : price data will be read in 2 ranges  [startDate-noDayToReadAhead,frDate] and  [startDate,endDate]
            private int noUnitToReadAhead = 100;

            // Because data will beread ahead some lengh,
            // the [priceStartIdx] is used to mark where the data in range [frDate,toDate] start
            public int priceStartIdx = 0;

            private data.baseDS.priceDataDataTable priceDataTbl = new data.baseDS.priceDataDataTable();
            // _buffClosePrice : closePrice + read adead items
            private double[] _buffClosePrice = null, _closePrice = null;
            private double[] _buffHiPrice = null, _hiPrice = null;
            private double[] _buffLoPrice = null, _loPrice = null;
            private double[] _openPrice = null;
            private double[] _totalVolume = null;
            private DateTime[] _priceDate = null;

            private double[] buffClosePrice
            {
                get
                {
                    if (_buffClosePrice == null)
                        _buffClosePrice = stockLibs.MakeDataList(this.priceDataTbl, 0, stockLibs.stockDataField.Close);
                    return _buffClosePrice;
                }
            }
            private double[] buffHiPrice
            {
                get
                {
                    if (_buffHiPrice == null)
                        _buffHiPrice = stockLibs.MakeDataList(this.priceDataTbl, 0, stockLibs.stockDataField.High);
                    return _buffHiPrice;
                }
            }
            private double[] buffLoPrice
            {
                get
                {
                    if (_buffLoPrice == null)
                        _buffLoPrice = stockLibs.MakeDataList(this.priceDataTbl, 0, stockLibs.stockDataField.Low);
                    return _buffLoPrice;
                }
            }

            public double[] closePrice
            {
                get
                {
                    if (_closePrice == null)
                        //_closePrice = stockLibs.MakeDataList(this.priceDataTbl, this.priceStartIdx, stockLibs.stockDataField.Close);
                        _closePrice = stockLibs.MakeDataList(this.priceDataTbl,0, stockLibs.stockDataField.Close);
                    return _closePrice;
                }
            }
            public double[] hiPrice
            {
                get
                {
                    if (_hiPrice == null)
                        //_hiPrice = stockLibs.MakeDataList(this.priceDataTbl, this.priceStartIdx, stockLibs.stockDataField.High);
                        _hiPrice = stockLibs.MakeDataList(this.priceDataTbl, 0, stockLibs.stockDataField.High);
                    return _hiPrice;
                }
            }
            public double[] loPrice
            {
                get
                {
                    if (_loPrice == null)
                        //_loPrice = stockLibs.MakeDataList(this.priceDataTbl, this.priceStartIdx, stockLibs.stockDataField.Low);
                        _loPrice = stockLibs.MakeDataList(this.priceDataTbl, 0, stockLibs.stockDataField.Low);
                    return _loPrice;
                }
            }
            public double[] openPrice
            {
                get
                {
                    if (_openPrice == null)
                        //_openPrice = stockLibs.MakeDataList(this.priceDataTbl, this.priceStartIdx, stockLibs.stockDataField.Open);
                        _openPrice = stockLibs.MakeDataList(this.priceDataTbl, 0, stockLibs.stockDataField.Open);
                    return _openPrice;
                }
            }
            public double[] totalVolume
            {
                get
                {
                    if (_totalVolume == null)
                        //_totalVolume = stockLibs.MakeDataList(this.priceDataTbl, this.priceStartIdx, stockLibs.stockDataField.Volume);
                        _totalVolume = stockLibs.MakeDataList(this.priceDataTbl, 0, stockLibs.stockDataField.Volume);
                    return _totalVolume;
                }
            }
            public DateTime[] priceDate
            {
                get
                {
                    if (_priceDate == null)
                    {
                        //for (int i = this.priceStartIdx, j = 0; i < this.priceDataTbl.Count; i++, j++)
                        for (int i = 0, j = 0; i < this.priceDataTbl.Count; i++, j++)
                        {
                            Array.Resize(ref _priceDate, j+1);
                            _priceDate[j] = this.priceDataTbl[i].onDate;
                        }
                    }
                    return _priceDate;
                }
            }
            public double[] StockData(myTypes.timeScales timeScale,string stockCode, stockLibs.stockDataField dataField)
            {
                data.baseDS.priceDataDataTable dataTbl = new data.baseDS.priceDataDataTable();
                application.dataLibs.LoadData(dataTbl,timeScale,startDate, endDate, stockCode);

                double[] outList = new double[this.priceDataTbl.Count];
                data.baseDS.priceDataRow row;

                string dataFldName = "";
                switch (dataField)
                {
                    case stockLibs.stockDataField.High:
                         dataFldName = this.priceDataTbl.highPriceColumn.ColumnName; break;
                    case stockLibs.stockDataField.Low:
                         dataFldName = this.priceDataTbl.lowPriceColumn.ColumnName; break;
                    case stockLibs.stockDataField.Open:
                         dataFldName = this.priceDataTbl.openPriceColumn.ColumnName; break;
                    case stockLibs.stockDataField.Close:
                         dataFldName = this.priceDataTbl.closePriceColumn.ColumnName; break;
                    case stockLibs.stockDataField.Volume:
                         dataFldName = this.priceDataTbl.volumeColumn.ColumnName; break;
                    default: return outList;
                }
                for (int idx = 0; idx < this.priceDataTbl.Count; idx++)
                {
                    row = dataTbl.FindBystockCodeonDate(stockCode, this.priceDataTbl[idx].onDate);
                    if (row != null) 
                         outList[idx] = double.Parse(row[dataFldName].ToString());
                    else outList[idx] = 0;
                }
                return outList;
            }

            public void Init(myTypes.timeScales timeScale, DateTime frDate, DateTime toDate, data.baseDS.stockCodeExtRow stockRow)
            {
                this.startDate = frDate; this.endDate = toDate;
                this.stockCodeRow = stockRow;
                this.priceDataTbl.Clear();
                this.priceStartIdx = 0;
                stockLibs.LoadStockPrice(stockRow.code, this.startDate, this.endDate,timeScale, this.noUnitToReadAhead, 
                                         this.priceDataTbl, out this.priceStartIdx);
                _buffClosePrice = null; _closePrice = null;
                _buffHiPrice = null; _hiPrice = null;
                _buffLoPrice = null; _loPrice = null;
                _openPrice = null;
                _priceDate = null;
                _totalVolume = null;
            }

            private double[] MovingAverage(myTypes.indicatorType type, int period)
            {
                int startIdx = this.buffClosePrice.Length - this.closePrice.Length - period + 1;
                if (startIdx < 0) startIdx=0;
                double[] tmpOutPut = new double[this.closePrice.Length + period];
                int begin = 0, len = 0;
                if (!stockLibs.MakeMovingAverage(type, startIdx, this.buffClosePrice.Length - 1, this.buffClosePrice, period, out begin, out len, tmpOutPut))
                    return new double[0];
                double[] outPut = new double[this.closePrice.Length];
                if (len >= this.closePrice.Length)
                    Array.Copy(tmpOutPut, len - this.closePrice.Length, outPut, 0, outPut.Length);
                else
                    Array.Copy(tmpOutPut,0,outPut,outPut.Length-len, len);
                return outPut;
            }
            private double[] MakeDI(myTypes.indicatorType type, int period)
            {
                int startIdx = this.buffClosePrice.Length - this.closePrice.Length - period + 1;
                if (startIdx < 0) startIdx = 0;

                double[] tmpOutput = new double[this.closePrice.Length + period];
                int begin = 0, len = 0;
                if (!stockLibs.MakeDI(type, startIdx, this.buffClosePrice.Length - 1, this.buffHiPrice, 
                                      this.buffLoPrice, this.buffClosePrice, period, out begin, out len, tmpOutput))
                {
                    return new double[0];
                }
                double[] output = new double[this.closePrice.Length];
                if (len >= this.closePrice.Length)
                {
                    Array.Copy(tmpOutput, len - this.closePrice.Length, output, 0, output.Length);
                }
                else
                {
                    Array.Copy(tmpOutput, 0, output, output.Length - len, len);
                }
                return output;
            }
            private double[] MakeDM(myTypes.indicatorType type, int period)
            {
                int startIdx = this.buffHiPrice.Length - this.buffHiPrice.Length - period + 1;
                if (startIdx < 0) startIdx = 0;

                double[] tmpOutput = new double[this.buffHiPrice.Length + period];
                int begin = 0, len = 0;
                if (!stockLibs.MakeDM(type, startIdx, this.buffClosePrice.Length - 1, this.buffHiPrice, this.buffLoPrice, period, out begin, out len, tmpOutput))
                {
                    return new double[0];
                }
                double[] output = new double[this.buffHiPrice.Length];
                if (len >= this.buffHiPrice.Length)
                {
                    Array.Copy(tmpOutput, len - this.buffHiPrice.Length, output, 0, output.Length);
                }
                else
                {
                    Array.Copy(tmpOutput, 0, output, output.Length - len, len);
                }
                return output;
            }

            public double[] SMA(int period)
            {
                return MovingAverage(myTypes.indicatorType.SMA, period);
            }
            public double[] EMA(int period)
            {
                return MovingAverage(myTypes.indicatorType.EMA, period);
            }
            public double[] WMA(int period)
            {
                return MovingAverage(myTypes.indicatorType.WMA, period);
            }
            public double[] RSI(int period)
            {
                return MovingAverage(myTypes.indicatorType.RSI, period);
            }
            public double[] DX(int period)
            {
                return MakeDI(myTypes.indicatorType.DI, period);
            }
            public double[] MinusDI(int period)
            {
                return MakeDI(myTypes.indicatorType.DIMinus, period);
            }
            public double[] PlusDI(int period)
            {
                return MakeDI(myTypes.indicatorType.DIPlus, period);
            }
            public double[] MinusDM(int period)
            {
                return MakeDM(myTypes.indicatorType.DMMinus, period);
            }
            public double[] PlusDM(int period)
            {
                return MakeDM(myTypes.indicatorType.DMPlus, period);
            }

            public void MACD(int fastPeriod, int slowPeriod, int signalPeriod, ref double[] output, ref double[] sigOutput, ref double[] histOutput)
            {
                int maxPeriod = Math.Max(fastPeriod, slowPeriod);
                int startIdx = this.buffClosePrice.Length - this.closePrice.Length - maxPeriod + 1;
                if (startIdx < 0) startIdx = 0;

                double[] tmpOutput = new double[this.closePrice.Length + maxPeriod];
                double[] tmpSigOutput = new double[this.closePrice.Length + maxPeriod];
                double[] tmpHistOutput = new double[this.closePrice.Length + maxPeriod];
                int begin = 0, len = 0;
                if (!stockLibs.MakeMACD(startIdx, this.buffClosePrice.Length - 1, this.buffClosePrice, fastPeriod, slowPeriod, signalPeriod, out begin, out len, tmpOutput, tmpSigOutput, tmpHistOutput))
                {
                    output = new double[0];
                    sigOutput = new double[0];
                    histOutput = new double[0];
                    return;
                }
                output = new double[this.closePrice.Length];
                sigOutput = new double[this.closePrice.Length];
                histOutput = new double[this.closePrice.Length];
                if (len >= this.closePrice.Length)
                {
                    Array.Copy(tmpOutput, len - this.closePrice.Length, output, 0, output.Length);
                    Array.Copy(tmpSigOutput, len - this.closePrice.Length, sigOutput, 0, sigOutput.Length);
                    Array.Copy(tmpHistOutput, len - this.closePrice.Length, histOutput, 0, sigOutput.Length);
                }
                else
                {
                    Array.Copy(tmpOutput, 0, output, output.Length - len, len);
                    Array.Copy(tmpSigOutput, 0, sigOutput, sigOutput.Length - len, len);
                    Array.Copy(tmpHistOutput, 0, histOutput, histOutput.Length - len, len);
                }
                return;
            }
            public void BBands(int period, int kUp, int kDown, ref double[] outUpperList, ref double[] outMiddleList, ref double[] outLowerList)
            {
                int maxPeriod = period;
                int startIdx = this.buffClosePrice.Length - this.closePrice.Length - maxPeriod + 1;
                if (startIdx < 0) startIdx = 0;

                double[] tmpUpperList = new double[this.closePrice.Length + maxPeriod];
                double[] tmpMiddleList = new double[this.closePrice.Length + maxPeriod];
                double[] tmpLowerList = new double[this.closePrice.Length + maxPeriod];
                int begin = 0, len = 0;
                if (!stockLibs.MakeBBANDS(startIdx, this.buffClosePrice.Length - 1, this.buffClosePrice, period,kUp,kDown,
                                          out begin, out len, outUpperList, outMiddleList, outLowerList))
                {
                    outUpperList = new double[0];
                    outMiddleList = new double[0];
                    outLowerList = new double[0];
                    return;
                }
                outUpperList = new double[this.closePrice.Length];
                outMiddleList = new double[this.closePrice.Length];
                outLowerList = new double[this.closePrice.Length];
                if (len >= this.closePrice.Length)
                {
                    Array.Copy(tmpUpperList, len - this.closePrice.Length, outUpperList, 0, outUpperList.Length);
                    Array.Copy(tmpMiddleList, len - this.closePrice.Length, outMiddleList, 0, outMiddleList.Length);
                    Array.Copy(tmpLowerList, len - this.closePrice.Length, outLowerList, 0, outLowerList.Length);
                }
                else
                {
                    Array.Copy(tmpUpperList, 0, outUpperList, outUpperList.Length - len, len);
                    Array.Copy(tmpMiddleList, 0, outMiddleList, outMiddleList.Length - len, len);
                    Array.Copy(tmpLowerList, 0, outLowerList, outLowerList.Length - len, len);
                }
                return;
            }

            public void StochasticFast(int fastK_Period, int fastD_Period,
                                       ref double[] outSlowK, ref double[] outSlowD)
            {
                int maxPeriod = Math.Max(fastK_Period, fastD_Period);
                int startIdx = this.buffClosePrice.Length - this.closePrice.Length - maxPeriod + 1;
                if (startIdx < 0) startIdx = 0;

                double[] tmpOutSlowK = new double[this.closePrice.Length + maxPeriod];
                double[] tmpOutSlowD = new double[this.closePrice.Length + maxPeriod];
                int begin = 0, len = 0;
                if (!stockLibs.MakeStochasticFast(startIdx, this.buffClosePrice.Length - 1, 
                                                  this.buffHiPrice,this.buffLoPrice,this.buffClosePrice, fastK_Period, fastD_Period, 
                                                  out begin, out len, tmpOutSlowK, tmpOutSlowD))
                {
                    outSlowK = new double[0];
                    outSlowD = new double[0];
                    return;
                }
                outSlowK = new double[this.closePrice.Length];
                outSlowD = new double[this.closePrice.Length];
                if (len >= this.closePrice.Length)
                {
                    Array.Copy(tmpOutSlowK, len - outSlowK.Length, outSlowK, 0, outSlowK.Length);
                    Array.Copy(tmpOutSlowD, len - outSlowD.Length, outSlowD, 0, outSlowD.Length);
                }
                else
                {
                    Array.Copy(tmpOutSlowK, 0, outSlowK, outSlowK.Length - len, len);
                    Array.Copy(tmpOutSlowD, 0, outSlowD, outSlowD.Length - len, len);
                }
                return;
            }

            public void StochasticSlow(int fastK_Period, int slowK_Period, int slowD_Period,
                                       ref double[] outSlowK, ref double[] outSlowD)
            {
                int maxPeriod = Math.Max(slowK_Period, slowD_Period);
                int startIdx = this.buffClosePrice.Length - this.closePrice.Length - maxPeriod + 1;
                if (startIdx < 0) startIdx = 0;

                double[] tmpOutSlowK = new double[this.closePrice.Length + maxPeriod];
                double[] tmpOutSlowD = new double[this.closePrice.Length + maxPeriod];
                int begin = 0, len = 0;
                if (!stockLibs.MakeStochasticSlow(startIdx, this.buffClosePrice.Length - 1,
                                                  this.buffHiPrice, this.buffLoPrice, this.buffClosePrice,
                                                  fastK_Period, slowK_Period, slowD_Period,
                                                  out begin, out len, tmpOutSlowK, tmpOutSlowD))
                {
                    outSlowK = new double[0];
                    outSlowD = new double[0];
                    return;
                }
                outSlowK = new double[this.closePrice.Length];
                outSlowD = new double[this.closePrice.Length];
                if (len >= this.closePrice.Length)
                {
                    Array.Copy(tmpOutSlowK, len - outSlowK.Length, outSlowK, 0, outSlowK.Length);
                    Array.Copy(tmpOutSlowD, len - outSlowD.Length, outSlowD, 0, outSlowD.Length);
                }
                else
                {
                    Array.Copy(tmpOutSlowK, 0, outSlowK, outSlowK.Length - len, len);
                    Array.Copy(tmpOutSlowD, 0, outSlowD, outSlowD.Length - len, len);
                }
                return;
            }
            public void StockRSI(int rsiPeriod, int fastK_Period, int fastD_Period, ref double[] outSlowK, ref double[] outSlowD)
            {
                int maxPeriod = Math.Max(fastK_Period, fastD_Period);
                maxPeriod = Math.Max(rsiPeriod, maxPeriod);
                int startIdx = this.buffClosePrice.Length - this.closePrice.Length - maxPeriod + 1;
                if (startIdx < 0) startIdx = 0;

                double[] tmpOutSlowK = new double[this.closePrice.Length + maxPeriod];
                double[] tmpOutSlowD = new double[this.closePrice.Length + maxPeriod];
                int begin = 0, len = 0;
                if (!stockLibs.MakeStockRSI(startIdx, this.buffClosePrice.Length - 1,
                                            this.buffClosePrice, rsiPeriod, fastK_Period, fastD_Period,
                                            out begin, out len, tmpOutSlowK, tmpOutSlowD))
                {
                    outSlowK = new double[0];
                    outSlowD = new double[0];
                    return;
                }
                outSlowK = new double[this.closePrice.Length];
                outSlowD = new double[this.closePrice.Length];
                if (len >= this.closePrice.Length)
                {
                    Array.Copy(tmpOutSlowK, len - outSlowK.Length, outSlowK, 0, outSlowK.Length);
                    Array.Copy(tmpOutSlowD, len - outSlowD.Length, outSlowD, 0, outSlowD.Length);
                }
                else
                {
                    Array.Copy(tmpOutSlowK, 0, outSlowK, outSlowK.Length - len, len);
                    Array.Copy(tmpOutSlowD, 0, outSlowD, outSlowD.Length - len, len);
                }
                return;
            }

        }
        public enum tradeActions : byte { None = 0, Buy = 1, Sell = 2, Accumulate = 3, ClearAll = 4, Select = 5};

        //Convert all TradeActions to table of (code,description)
        public static DataTable CreateTradeActionsTable()
        {
            DataTable tbl = new DataTable();
            // Define columns
            DataColumn col1 = new DataColumn("code", typeof(byte)); tbl.Columns.Add(col1);
            DataColumn col2 = new DataColumn("description"); tbl.Columns.Add(col2);
            foreach (analysis.tradeActions item in Enum.GetValues(typeof(analysis.tradeActions)))
            {
                DataRow row = tbl.Rows.Add((byte)item);
                row[1] = item.ToString();
            }
            return tbl;
        }

        public enum marketTrend : byte { Unspecified=0, Sidebar = 1, Upward = 2, Downward = 3 };
        public class tradePointInfo
        {
            public marketTrend marketTrend = marketTrend.Unspecified;
            public double price = 0;
            public int volume = 0;
            public double weight = 0;
            public void Set(tradePointInfo info)
            {
                this.marketTrend = info.marketTrend;
                this.price = info.price;
                this.volume = info.volume;
                this.weight = info.weight;
            }
        }
        public class tradePoint
        {
            // Data position where the trade point occured.
            // The index is used to get data (closePrice,openPrice...) of a trade point.
            public int dataIdx = 0;
            // Position where the point appears in the chart.  
            public int pointIdx = 0;
            public DateTime onDateTime = common.Consts.constNullDate;
            public tradePointInfo tradeInfo = new tradePointInfo();
            public tradeActions tradeAction = tradeActions.None;

            public tradePoint(tradeActions action, int idx, tradePointInfo info)
            {
                this.tradeAction = action;
                if(info!=null)  this.tradeInfo.Set(info);
                this.dataIdx = idx;
            }
            public tradePoint(tradeActions action, int idx)
            {
                this.tradeAction = action;
                this.dataIdx = idx;
            }
        }
        public class analysisResult : ArrayList
        {
            public analysisResult() { }
            public void Add(tradeActions action, int idx,tradePointInfo info)
            {
                this.Add(new tradePoint(action, idx,info));
            }
            public void Add(tradeActions action, int idx)
            {
                this.Add(new tradePoint(action, idx, null));
            }
            public tradePoint GetItem(int idx)
            {
                return (tradePoint)this[idx];
            }
        }
        #endregion

        #region usefull functions
        public enum cutStat : byte { None = 0, Match = 1, Up = 2, Down = 3 };
        public class cutPoint
        {
            public cutStat stat = cutStat.None;
            public int possition = -1;
        }
        public static cutStat Cut(double[] list1, double[] list2,int position)
        {
            if (position > list1.Length || position > list2.Length) return cutStat.None;
            if (list2[position] == 0) return cutStat.None;
            if (position == 0)
                return (list1[0] == list2[0] ? cutStat.Match : cutStat.None);
            if ((list2[position] == list1[position - 1]) || (list2[position] == list1[position])) return cutStat.Match;
            if ((list2[position-1] < list1[position]) && (list2[position] > list1[position])) return cutStat.Up;
            if ((list2[position - 1] > list1[position]) && (list2[position] < list1[position])) return cutStat.Down;
            return cutStat.None; 
        }

        public static void EstimateAdvice(workData analysisData, analysisResult advices,estimateOptions options, 
                                          data.tmpDS.tradeEstimateDataTable toTbl)
        {
            decimal initCapAmt = options.totalCapAmt * options.maxBuyAmtPerc / 100;
            decimal priceWeight= options.priceWeight;
            decimal feePerc = options.transFeecPerc/100;
            short buy2SellInterval = options.buy2SellInterval;

            data.tmpDS.tradeEstimateRow row;
            int adviceDataIdx, lastBuyId = -1;
            decimal stockQty = 0,qty;
            decimal maxBuyQty = (decimal)(analysisData.stockCodeRow.noOpenShares * options.maxBuyQtyPerc / 100); 
            decimal stockAmt = 0, stockPrice = 0, amt, feeAmt, totalFeeAmt = 0;
            decimal cashAmt = initCapAmt;
            toTbl.Clear();

            DateTime tmpDate, transDate = common.Consts.constNullDate; ;
            data.baseDS.priceDataRow priceDataRow; 
            bool keepInApplicableSell = true;
            for (int idx = 0; idx < advices.Count; idx++)
            {
                adviceDataIdx = advices.GetItem(idx).dataIdx;
                qty = 0; amt = 0;
                row = toTbl.NewtradeEstimateRow();
                row.ignored = false;
                analysis.tradeActions action = advices.GetItem(idx).tradeAction;

                stockPrice = (decimal)analysisData.closePrice[adviceDataIdx];
                transDate = analysisData.priceDate[adviceDataIdx];
                switch (action)
                {
                    case analysis.tradeActions.Buy:
                        //Assume that we can only buy if we have money 
                        qty = (stockPrice == 0 ? 0 : Math.Floor(cashAmt / ( (stockPrice * priceWeight) * (1 + feePerc))));
                        if (qty > maxBuyQty) qty = maxBuyQty;
                        if (qty != 0)
                        {
                            amt = qty * stockPrice * priceWeight;
                            stockAmt += amt;
                            stockQty += qty;
                            feeAmt = Math.Round(amt * feePerc, 0);
                            cashAmt -= amt + feeAmt;
                            totalFeeAmt += feeAmt;
                            lastBuyId = adviceDataIdx;
                        }
                        else row.ignored = true;
                        break;
                    case analysis.tradeActions.Sell:
                        //Can sell if own some stock
                        if (stockQty <= 0) 
                        {
                            row.ignored = true;
                            break;
                        }
                        // Not applicable to sell
                        if (lastBuyId < 0)
                        {
                            row.ignored = true;
                            break;
                        }
                        if (common.dateTimeLibs.DateDiffInDays(analysisData.priceDate[lastBuyId].Date, 
                                                               analysisData.priceDate[adviceDataIdx].Date) < buy2SellInterval)
                        {
                            // Keep inapplicable Sells ??
                            if (keepInApplicableSell)
                            {
                                DateTime minAllowSellDate = analysisData.priceDate[lastBuyId].Date.AddDays(buy2SellInterval);
                                for (int idx2 = idx + 1; idx2 < advices.Count; idx2++)
                                {
                                    //There is any advice from from [this date , this date +buy2SellInterval], ignore the inapplicable sell 
                                    if (analysisData.priceDate[advices.GetItem(idx2).dataIdx].Date <= minAllowSellDate)
                                    {
                                        row.ignored = true;
                                        break;
                                    }
                                    //No advice, keep this inapplicable sell. 
                                    if (analysisData.priceDate[advices.GetItem(idx2).dataIdx].Date > minAllowSellDate)
                                    {
                                        // minAllowSellDate may be a holiday so we need to find a sell date in range [minAllowSellDate, analysisData.priceDate[advices.GetItem(idx2).dataIdx].Date]
                                        // We assume that there are no data on hodidays and use the price,date as transaction price/date
                                        tmpDate = analysisData.priceDate[advices.GetItem(idx2).dataIdx].Date;
                                        priceDataRow = dataLibs.GetNextPrice(minAllowSellDate, myTypes.timeScales.Daily, analysisData.stockCodeRow.code);
                                        //priceDataRow == null : there must be some error.
                                        if (priceDataRow == null) row.ignored = true;
                                        else
                                        {
                                            stockPrice = priceDataRow.closePrice;
                                            transDate = priceDataRow.onDate;
                                        }
                                        break;
                                    }
                                }
                            }
                            else row.ignored = true;
                        }
                        //Ok, sell it
                        qty = stockQty;
                        amt = qty * stockPrice * priceWeight;
                        stockQty = 0; stockAmt = 0;
                        feeAmt = Math.Round(amt * feePerc, 0);
                        cashAmt += amt - feeAmt;
                        totalFeeAmt += feeAmt;
                        break;
                }
                row.tradeAction = action.ToString();
                row.onDate = transDate;
                row.price = stockPrice;
                row.qty = qty;
                row.amt = amt;
                row.feeAmt = totalFeeAmt;
                row.stockQty = stockQty;
                row.stockAmt = stockAmt;
                row.cashAmt = cashAmt;
                row.totalAmt = row.cashAmt + row.stockAmt;
                row.revenue = row.totalAmt - initCapAmt;
                toTbl.AddtradeEstimateRow(row);
            }
        }

        public static void ExportData(string toFileName, workData data, params object[] paras)
        {
            if (paras.Length == 0) return;
            // Define the new datatable
            DataTable tbl = new DataTable();
            DataColumn col0 = new DataColumn("onDate", typeof(DateTime)); tbl.Columns.Add(col0);
            DataColumn col1 = new DataColumn("open", typeof(Decimal)); tbl.Columns.Add(col1);
            DataColumn col2 = new DataColumn("close", typeof(Decimal)); tbl.Columns.Add(col2);
            DataColumn col3 = new DataColumn("hi", typeof(Decimal)); tbl.Columns.Add(col3);
            DataColumn col4 = new DataColumn("low", typeof(Decimal)); tbl.Columns.Add(col4);
            DataColumn col5 = new DataColumn("volume", typeof(Decimal)); tbl.Columns.Add(col5);
            for (int colId = 0; colId < paras.Length; colId++)
            {
                DataColumn col = new DataColumn("val" + colId.ToString().Trim(), typeof(Decimal));
                tbl.Columns.Add(col);
            }
            double[] val = new double[paras.Length];
            int rowCount = ((double[])paras[0]).Length;
            DataRow row;
            for (int rowId = 0; rowId < rowCount; rowId++)
            {
                row = tbl.Rows.Add();
                row[0] = data.priceDate[rowId];
                row[1] = data.openPrice[rowId];
                row[2] = data.closePrice[rowId];
                row[3] = data.hiPrice[rowId];
                row[4] = data.loPrice[rowId];
                row[5] = data.totalVolume[rowId];
                for (int colId = 0; colId < paras.Length; colId++)
                {
                    row[colId + 6] = ((double[])paras[colId])[rowId];
                }
            }
            common.Export.ExportToExcel(tbl, toFileName);
        }
        #endregion

        #region strategy estimation
        //Estimate for one stock ; ??Will be done

        //Structure represent the estimation criteria for the "strategy accuracry" on specific stock.
        public class oneStockStrategyStats
        {
            public string strategyCode = "";
            public decimal startAmt = 0, closingAmt = 0;
            public int totalTrans = 0, noWinTrans = 0, noLossTrans = 0;
            public decimal winPerc = 0, lossPerc = 0;
            public decimal maxAmtInWin = 0, maxAmtInLoss = 0, avgAmtInWin = 0, avgAmtInLoss = 0;
            public decimal totalWinAmt = 0, totalLossAmt = 0;
            public decimal avgNoDayHoldStockInWin = 0;   //average of the number of days to hlod stock in win transaction;
            public decimal maxNoTransWinInRow = 0, maxNoTransLossInRow = 0;
        }

        //Estimate for all stock
        private class strategyStats
        {
            public int winStockCount = 0, lossStockCount = 0;
            public double winStockPerc = 0, lossStockPerc = 0;
            public double maxWinAmt = 0, maxLossAmt = 0;
            public double avgWinAmt = 0, avgLossAmt = 0;
            public double totalWinAmt = 0, totalLossAmt = 0;
        }

        //Structure represent the estimation criteria for the "strategy accuracry" on all stocks.
        private static strategyStats EstimateStrategy(decimal[] list)
        {
            strategyStats estData = new strategyStats();
            for (int rowId = 0; rowId < list.Length; rowId++)
            {
                if (list[rowId] > 0)
                {
                    estData.winStockCount++;
                    if ((double)list[rowId] > estData.maxWinAmt) estData.maxWinAmt = (double)list[rowId];
                    estData.totalWinAmt += (double)list[rowId];
                }
                if (list[rowId] < 0)
                {
                    estData.lossStockCount++;
                    if ((double)list[rowId] < estData.maxLossAmt) estData.maxLossAmt = (double)list[rowId];
                    estData.totalLossAmt += (double)list[rowId];
                }
            }
            if (list.Length > 0)
            {
                estData.winStockPerc = 100 * estData.winStockCount / (double)list.Length;
                estData.lossStockPerc = 100 * estData.lossStockCount / (double)list.Length;
            }
            if (estData.winStockCount > 0)
            {
                estData.avgWinAmt = estData.totalWinAmt / (double)estData.winStockCount;
            }
            if (estData.lossStockCount > 0)
            {
                estData.avgLossAmt = estData.totalLossAmt / (double)estData.lossStockCount;
            }
            return estData;
        }
        public static DataTable GetStrategyStats(DataTable tbl)
        {
            ArrayList estDataList = new ArrayList();
            decimal[] dataList = new decimal[tbl.Rows.Count];
            for (int colId = 1; colId < tbl.Columns.Count; colId++)
            {
                //Convert to list
                for (int rowId = 0; rowId < tbl.Rows.Count; rowId++) dataList[rowId] = (decimal)tbl.Rows[rowId][colId];
                estDataList.Add(EstimateStrategy(dataList));
            }
            //Create table to store data
            DataTable retTbl = tbl.Clone();
            strategyStats estData;
            retTbl.Rows.Add("01.Tỉ lệ CP lời");         //winStockPerc; 
            retTbl.Rows.Add("02.Tỉ lệ CP lỗ");          //lossStockPerc
            retTbl.Rows.Add("03.ST lời lớn nhất");      //maxWinAmt 
            retTbl.Rows.Add("04.ST lỗ lớn nhất");       //maxLossAmt
            retTbl.Rows.Add("05.ST lời trung bình");    //avgWinAmt 
            retTbl.Rows.Add("06.ST lỗ trung bình");     //avgLossAmt
            //retTbl.Rows.Add("07.Số lượng CP lời");      //winStockCount 
            //retTbl.Rows.Add("08.Số lượng CP lỗ");       //lossStockCount
            //retTbl.Rows.Add("09.Tổng lời");             //totalWinAmt 
            //retTbl.Rows.Add("10.Tồng lỗ");              //totalLossAmt
            for (int colId = 0; colId < estDataList.Count; colId++)
            {
                estData = (strategyStats)estDataList[colId];

                retTbl.Rows[0][colId + 1] = estData.winStockPerc;
                retTbl.Rows[1][colId + 1] = estData.lossStockPerc;

                retTbl.Rows[2][colId + 1] = estData.maxWinAmt;
                retTbl.Rows[3][colId + 1] = estData.maxLossAmt;

                retTbl.Rows[4][colId + 1] = estData.avgWinAmt;
                retTbl.Rows[5][colId + 1] = estData.avgLossAmt;

                //retTbl.Rows[6][colId + 1] = estData.winStockCount;
                //retTbl.Rows[7][colId + 1] = estData.lossStockCount;
                //retTbl.Rows[8][colId + 1] = estData.totalWinAmt;
                //retTbl.Rows[9][colId + 1] = estData.totalLossAmt;
            }
            return retTbl;
        }
        #endregion
    }
    public class chart
    {
        public static PointPairList MakePointPairList(double[] dataX, double[] dataY)
        {
            PointPairList list = new PointPairList();
            for (int idx = 0; idx < Math.Min(dataX.Length, dataY.Length); idx++)
            {
                list.Add(dataX[idx], dataY[idx]);
            }
            return list;
        }
        public static PointPairList MakePointPairList(data.baseDS.priceDataDataTable data, stockLibs.stockDataField  valueType)
        {
            PointPairList list = new PointPairList();
            switch (valueType)
            {
                case stockLibs.stockDataField.Close:  
                     for (int idx = 0; idx < data.Count; idx++)  list.Add( new XDate(data[idx].onDate), (double)data[idx].closePrice); 
                     break;
                case stockLibs.stockDataField.Open:
                     for (int idx = 0; idx < data.Count; idx++) list.Add(new XDate(data[idx].onDate), (double)data[idx].openPrice);
                     break;
                case stockLibs.stockDataField.Low:
                     for (int idx = 0; idx < data.Count; idx++) list.Add(new XDate(data[idx].onDate), (double)data[idx].lowPrice);
                     break;
                case stockLibs.stockDataField.High:
                     for (int idx = 0; idx < data.Count; idx++) list.Add(new XDate(data[idx].onDate), (double)data[idx].highPrice);
                     break;
                case stockLibs.stockDataField.Volume:
                     for (int idx = 0; idx < data.Count; idx++) list.Add(new XDate(data[idx].onDate), (double)data[idx].volume);
                     break;
                default:
                     common.system.ThrowException("Invalid valueType in MakePointPairList()");
                     break;
            }
            return list;
        }

        public static JapaneseCandleStickItem PlotChartCandleStick(GraphPane myPane, data.baseDS.priceDataDataTable data, string title,
                                                                   Color color, Color stickColor, Color fallingColor)
        {
            StockPointList spl = new StockPointList();
            for (int idx = 0; idx < data.Count; idx++)
            {
                StockPt pt = new StockPt(new XDate(data[idx].onDate), (double)data[idx].highPrice,
                                         (double)data[idx].lowPrice, (double)data[idx].openPrice,
                                         (double)data[idx].closePrice, (double)data[idx].volume);
                spl.Add(pt);
            }

            JapaneseCandleStickItem myCurve = myPane.AddJapaneseCandleStick(title, spl);
            myCurve.Stick.IsAutoSize = true;
            myCurve.Stick.Color = stickColor;
            myCurve.Stick.FallingColor = fallingColor;
            myCurve.Color = color;

            // Use DateAsOrdinal to skip weekend gaps
            //myPane.XAxis.Type = AxisType.DateAsOrdinal;
            //myPane.XAxis.Scale.Min = new XDate(2006, 1, 1);

            // pretty it up a little
            //myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
            //myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0f);
            return myCurve;
        }

    }
    public class screening
    {
        public static bool GetStockList(data.baseDS.stockCodeExtDataTable stockCodeTbl, myTypes.screeningCriteria[] criteriaList)
        {
            data.baseDS.priceDataDataTable priceTbl = new data.baseDS.priceDataDataTable();
            DateTime curDate = application.sysLibs.GetServerDateTime();
            string sqlCmdStock = "", sqlCmdPrice = "";
            for(int idx=0; idx<criteriaList.Length;idx++)
            {
                switch (criteriaList[idx].code)
                {
                    //From stock
                    case myTypes.screeningCritType.MarketCap:

                        sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                                        "(" + stockCodeTbl.capitalColumn.ColumnName + ">=" + criteriaList[idx].min.ToString() + ")";
                        if (criteriaList[idx].max > criteriaList[idx].min)
                        {
                            sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                    "(" + stockCodeTbl.capitalColumn.ColumnName + "<=" + criteriaList[idx].max.ToString() + ")";
                        }
                        break;

                    case myTypes.screeningCritType.TotalVolume:
                         sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                 "(" + stockCodeTbl.noOpenSharesColumn.ColumnName + ">=" + criteriaList[idx].min.ToString() + ")";
                         if (criteriaList[idx].max > criteriaList[idx].min)
                         {
                             sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                     "(" + stockCodeTbl.noOpenSharesColumn.ColumnName + "<=" + criteriaList[idx].max.ToString() + ")";
                         }
                         break;

                    case myTypes.screeningCritType.ForeignOwnVolume:
                         sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                 "(" + stockCodeTbl.noForeignOwnSharesColumn.ColumnName + ">=" + criteriaList[idx].min.ToString() + ")";
                         if (criteriaList[idx].max > criteriaList[idx].min)
                         {
                             sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                     "(" + stockCodeTbl.noForeignOwnSharesColumn.ColumnName + "<=" + criteriaList[idx].max.ToString() + ")";
                         }
                         break;

                    case myTypes.screeningCritType.TargetPrice:
                         sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                 "(" + stockCodeTbl.targetPriceColumn.ColumnName + ">=" + criteriaList[idx].min.ToString() + ")";
                         if (criteriaList[idx].max > criteriaList[idx].min)
                         {
                             sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                     "(" + stockCodeTbl.targetPriceColumn.ColumnName + "<=" + criteriaList[idx].max.ToString() + ")";
                         }
                         break;
                    //From price
                    case myTypes.screeningCritType.LastMonthTransVolume:
                         sqlCmdPrice += (sqlCmdPrice == "" ? "" : " AND ") +
                                 "(" + priceTbl.volumeColumn.ColumnName + ">=" + criteriaList[idx].min.ToString() + ")";

                         if (criteriaList[idx].max > criteriaList[idx].min)
                         {
                             
                             sqlCmdPrice += (sqlCmdPrice == "" ? "" : " AND ") +
                                        "(" + priceTbl.volumeColumn.ColumnName + "<=" + criteriaList[idx].max.ToString() + ")";
                         }
                         sqlCmdPrice += (sqlCmdPrice == "" ? "" : " AND ") +
                                    "(" +  priceTbl.onDateColumn.ColumnName +
                                          " BETWEEN '" + common.system.ConvertToSQLDateString(curDate.AddMonths(-1)) + "' AND " +
                                          " '" + common.system.ConvertToSQLDateString(curDate) +
                                    "')";
                         break;
                }
            }
            string sqlCmd = "";
            if (sqlCmdStock != "" && sqlCmdPrice != "")
            {
                sqlCmd =  " SELECT *" +
                          " FROM " + stockCodeTbl.TableName +
                          " WHERE " + sqlCmdStock +
                          " AND " + stockCodeTbl.codeColumn.ColumnName + " IN " +
                          "(" +
                          " SELECT " + priceTbl.stockCodeColumn.ColumnName +
                          " FROM " + priceTbl.TableName +
                          " WHERE " + sqlCmdPrice +
                          ")";
            }
            if (sqlCmd == "" && sqlCmdStock != "")
            {
                sqlCmd =  " SELECT * " +
                          " FROM " + stockCodeTbl.TableName +
                          " WHERE " + sqlCmdStock;
            }
            if (sqlCmd == "" && sqlCmdPrice != "")
            {
                sqlCmd = " SELECT *" +
                          " FROM " + stockCodeTbl.TableName +
                          " WHERE " + stockCodeTbl.codeColumn.ColumnName + " IN " +
                          "(" +
                          " SELECT " + priceTbl.stockCodeColumn.ColumnName +
                          " FROM " + priceTbl.TableName +
                          " WHERE " + sqlCmdPrice +
                          ")";
            }
            if (sqlCmd == "") return false;

            dataLibs.LoadFromSQL(stockCodeTbl, sqlCmd);
            return true;
        }
    }

}
