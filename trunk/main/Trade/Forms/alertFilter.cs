using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Trade.Forms
{
    public partial class alertFilter : baseClass.forms.baseDialogForm  
    {
        public alertFilter()
        {
            try
            {
                InitializeComponent();
                statusCb.LoadData();
                portfolioCb.LoadData();
                strategyCb.LoadData();
                timeScaleCb.LoadData();
        
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        
        public void SetDateRange(bool enable,bool check)
        {
            dateRangeChk.Enabled  = enable;
            dateRangeChk.Checked = check;
            dateRangeChk_CheckedChanged(null,null);
            if (!enable) dateRange.Enabled = false;
        }
        public DateTime myFromDate
        {
            get { return dateRange.frDate;}
            set { dateRange.frDate = value;}
        }
        public DateTime myToDate
        {
            get { return dateRange.toDate; }
            set { dateRange.toDate = value; }
        }

        public void SetPortfolio(bool enable, bool check)
        {
            portfolioChk.Enabled = enable;
            portfolioChk.Checked = check;
            portfolioChk_CheckedChanged(null, null);
            if (!enable) portfolioCb.Enabled = false;
        }
        public string myPortfolio
        {
            get { return portfolioCb.myValue; }
            set { portfolioCb.myValue = value; }
        }

        public void SetStockCode(bool enable, bool check)
        {
            stockChk.Enabled = enable;
            stockChk.Checked = check;
            stockChk_CheckedChanged(null, null);
            if (!enable) stockCodeEd.Enabled = false;
        }
        public string myStockCode
        {
            get { return stockCodeEd.Text; }
            set { stockCodeEd.Text = value; }
        }

        public void SetStatus(bool enable, bool check)
        {
            statusChk.Enabled = enable;
            statusChk.Checked = check;
            statusChk_CheckedChanged(null, null);
            if (!enable) statusCb.Enabled = false;
        }
        public application.AppTypes.CommonStatus myStatus
        {
            get { return statusCb.myValue; }
            set { statusCb.myValue = value; }
        }

        protected override bool BeforeAcceptProcess()
        {
            bool retVal = true;
            ClearNotifyError();
            if (dateRange.Enabled && !dateRange.GetDateRange()) retVal = false;
            return retVal;
        }
        public string GetSQL()
        {
            data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
            data.baseDS.tradeAlertDataTable tradeAlertTbl = new data.baseDS.tradeAlertDataTable();
            string condCmd = "";
            condCmd += (condCmd == "" ? "" : " AND ") +
                "(" + tradeAlertTbl.portfolioColumn.ColumnName +
                    " IN (" +
                    " SELECT " + portfolioTbl.codeColumn.ColumnName +
                    " FROM " + portfolioTbl.TableName +
                    " WHERE " + portfolioTbl.investorCodeColumn.ColumnName + "=N'" + application.sysLibs.sysLoginCode + "'))";

            if (dateRangeChk.Checked)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.onTimeColumn.ColumnName + 
                    " BETWEEN '" + common.system.ConvertToSQLDateString(dateRange.frDate,false) + "' AND '"+
                                   common.system.ConvertToSQLDateString(dateRange.toDate.AddDays(1).AddSeconds(-1),false) + "')";
            if (statusChk.Checked)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.statusColumn.ColumnName + " & " + ((byte)statusCb.myValue).ToString() + ">0)";

            if (portfolioChk.Checked)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.portfolioColumn.ColumnName + "=N'" + portfolioCb.myValue + "')";

            if (strategyChk.Checked)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.strategyColumn.ColumnName + "=N'" + strategyCb.myValue + "')";

            //??
            //if (timeScaleChk.Checked)
            //    condCmd += (condCmd == "" ? "" : " AND ") +
            //        "(" + tradeAlertTbl.timeScaleColumn.ColumnName + "=" + (byte)timeScaleCb.myValue + ")";

            if (stockChk.Checked)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.stockCodeColumn.ColumnName + "=N'" + stockCodeEd.Text.Trim() + "')";

            string sqlCmd = "SELECT * FROM " + tradeAlertTbl.TableName +
                            (condCmd == "" ? "" : " WHERE " + condCmd) +
                            " ORDER BY " + tradeAlertTbl.onTimeColumn.ColumnName + " DESC";
            return sqlCmd;
        }

        #region event handler
        private void dateRangeChk_CheckedChanged(object sender, EventArgs e)
        {
            dateRange.Enabled = dateRangeChk.Checked;
        }
        private void statusChk_CheckedChanged(object sender, EventArgs e)
        {
            statusCb.Enabled = statusChk.Checked;
        }
        private void portfolioChk_CheckedChanged(object sender, EventArgs e)
        {
            portfolioCb.Enabled = portfolioChk.Checked;
        }
        private void strategyChk_CheckedChanged(object sender, EventArgs e)
        {
            strategyCb.Enabled = strategyChk.Checked;
        }
        private void stockChk_CheckedChanged(object sender, EventArgs e)
        {
            stockCodeEd.Enabled = stockChk.Checked;
        }
        private void timeScaleChk_CheckedChanged(object sender, EventArgs e)
        {
            timeScaleCb.Enabled = timeScaleChk.Checked;
        }
        #endregion
    }    
}