using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using application;

namespace tradeAlert
{
    public class libs
    {
        private const int constDataReadAheadInHour = 10 * 24;
        #region strategy estimation
        public delegate void onProcessStart(int stockCodeCount);
        public delegate bool onProcessItem(string stockcode);
        public delegate void onProcessEnd();

        private class tradeAlert
        {
            public analysis.tradePoint tradePoint = null;
            public string stockCode="",strategy="";
            public DateTime onDateTime = common.Consts.constNullDate;
            public tradeAlert(string _stockCode, string _strategy,DateTime _onDateTime,analysis.tradePoint _tradePoint)
            {
                this.stockCode = _stockCode;
                this.strategy = _strategy;
                this.onDateTime = _onDateTime;
                this.tradePoint = _tradePoint;
            }
        }

        private static DateTime GetTradeAlertLastTime()
        {
            StringCollection aFields = new StringCollection();
            aFields.Add(configuration.configKeys.sysTradeAlertLastRun.ToString());
            configuration.GetConfig(ref aFields);
            DateTime lastTime = DateTime.Now;
            if (!DateTime.TryParse(aFields[0], out lastTime)) return common.Consts.constNullDate;
            return lastTime;
        }
        private static void SaveTradeAlertLastTime(DateTime onTime)
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Add(configuration.configKeys.sysTradeAlertLastRun.ToString());
            aValues.Add(onTime.ToString());
            configuration.SaveConfig(aFields, aValues);
        }

        private static void CreateTradeAlert(tradeAlert[] alertList)
        {
            StringCollection strategyList;
            data.baseDS.tradeAlertDataTable tradeAlertTbl = new data.baseDS.tradeAlertDataTable();
            data.baseDS.stockCodeExtDataTable stockCodeTbl = new data.baseDS.stockCodeExtDataTable();
            data.baseDS.portpolioDataTable portpolioTbl = new data.baseDS.portpolioDataTable();
            dataLibs.LoadData(portpolioTbl);
            for (int idx1 = 0; idx1 < portpolioTbl.Count; idx1++)
            {
                stockCodeTbl.Clear();
                dataLibs.LoadData(stockCodeTbl, portpolioTbl[idx1]);
                strategyList = common.system.MultivalueString2List(portpolioTbl[idx1].interestedStrategy);
                for (int idx2 = 0; idx2 < strategyList.Count; idx2++) strategyList[idx2] = strategyList[idx2].Trim();

                for (int idx2 = 0; idx2 < alertList.Length; idx2++)
                {
                    if (strategyList.Count>0 && !strategyList.Contains(alertList[idx2].strategy)) continue;
                    if (stockCodeTbl.FindBycode(alertList[idx2].stockCode)==null) continue;
                    CreateTradeAlert(tradeAlertTbl, portpolioTbl[idx1], alertList[idx2].stockCode, alertList[idx2].strategy,
                                    alertList[idx2].tradePoint,alertList[idx2].onDateTime); 
                }
            }
            dataLibs.UpdateData(tradeAlertTbl);
        }

        private static void CreateTradeAlert(data.baseDS.tradeAlertDataTable tradeAlertTbl,data.baseDS.portpolioRow portpolioRow,
                                             string stockCode, string strategy, analysis.tradePoint info, DateTime onTime)
        {
            data.baseDS.tradeAlertRow row = tradeAlertTbl.NewtradeAlertRow();
            dataLibs.InitData(row);
            row.onTime = onTime;
            row.portpolio = portpolioRow.code;
            row.stockCode = stockCode; ;
            row.strategy = strategy; ;
            row.status = (byte)myTypes.commonStatus.New; 
            row.tradeAction = (byte)info.tradeAction;
            row.subject = info.tradeAction.ToString();
            row.msg = "";
            tradeAlertTbl.AddtradeAlertRow(row);
        }

        public static void CreateTradeAlert()
        {
            CreateTradeAlert(null, null, null);
        }
        public static void CreateTradeAlert(onProcessStart onStartFunc, onProcessItem onProcessItemFunc, onProcessEnd onEndFunc)
        {
            //Get date range : [last run datetime, current datetime]
            DateTime frDate = GetTradeAlertLastTime();

            DateTime toDate = sysLibs.GetServerDateTime();
            if (frDate == common.Consts.constNullDate)
            {
                frDate = toDate.AddDays(-1);
            }
            //For testing only
            //frDate = DateTime.Parse("01/06/2011");

            //Move date ahead to ensure that there are sufficient data need in analysis process
            DateTime readFrDate = frDate.AddHours(-constDataReadAheadInHour);

            //Run all strategy analysis for all stocks.
            data.baseDS.stockCodeExtDataTable stockCodeExtTbl = new data.baseDS.stockCodeExtDataTable();
            dataLibs.LoadData(stockCodeExtTbl,(byte)myTypes.commonStatus.Enable);
            data.baseDS.strategyDataTable strategyTbl = new data.baseDS.strategyDataTable();
            dataLibs.LoadData(strategyTbl,true);

            analysis.workData analysisData = new analysis.workData();

            tradeAlert[] tradeAlertList = new tradeAlert[0];
            analysis.tradePoint tradePoint;

            if (onStartFunc != null) onStartFunc(stockCodeExtTbl.Count);
 
            for (int idx1 = 0; idx1 < stockCodeExtTbl.Count; idx1++)
            {
                if (onProcessItemFunc != null)
                    if (!onProcessItemFunc(stockCodeExtTbl[idx1].code)) break;
                analysisData.Init(readFrDate, toDate, stockCodeExtTbl[idx1]);
                for (int idx2 = 0; idx2 < strategyTbl.Count; idx2++)
                {
                    analysis.analysisResult advices = strategy.libs.Strategy(analysisData,strategyTbl[idx2].code);
                    if (advices == null) continue;
                    //Ignore invalid advices
                    for (int idx3 = 0; idx3 < advices.Count; idx3++)
                    {
                        tradePoint = (analysis.tradePoint)advices[idx3];
                        if (analysisData.priceDate[tradePoint.postition] < frDate)  continue;

                        Array.Resize(ref tradeAlertList, tradeAlertList.Length + 1);
                        tradeAlertList[tradeAlertList.Length - 1] =
                            new tradeAlert(stockCodeExtTbl[idx1].code.Trim(), strategyTbl[idx2].code.Trim(),
                                            analysisData.priceDate[tradePoint.postition], tradePoint);
                    }
                }
            }
            stockCodeExtTbl.Dispose();
            strategyTbl.Dispose();

            //Create alerts
            CreateTradeAlert(tradeAlertList);

            //Save last lun date
            SaveTradeAlertLastTime(toDate);
            if (onEndFunc != null) onEndFunc();
        }
        #endregion
    }
}
