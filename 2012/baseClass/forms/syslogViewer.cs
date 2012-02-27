using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using application;
using databases;
using commonTypes;
using common;

namespace baseClass.forms
{
    public partial class syslogViewer : baseForm 
    {
        private bool _fullMode = false;
        private bool fullMode
        {
            get { return _fullMode; }
            set
            {
                _fullMode = value;
                this.Height = syslogGrid.Location.Y + 7 + 2 * SystemInformation.CaptionHeight + (_fullMode ? syslogGrid.Height : 0);
                this.Width = optionPnl.Location.X + optionPnl.Width + (_fullMode ? infoPnl.Width : 0) + 5;

                infoPnl.Visible = _fullMode;
                syslogGrid.Visible = _fullMode;
                Application.DoEvents();
            }
        }
        public syslogViewer()
        {
            try
            {
                InitializeComponent();
                fullMode = false;

                myBaseDS.investor.Clear();
                logTypeCb.LoadData();
                logTypeCb.SelectFirstIfNull();
                investorSource.DataSource = DataAccess.Libs.myInvestorShortTbl; 
                //??application.sysLibs.LoadEnumList(myTempDS.codeList);

                typeCb.BackColor = codeEd.BackColor;
                investorCb.BackColor = codeEd.BackColor;

                common.system.AutoFitGridColumn(syslogGrid, descriptionColumn.Name);
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }
        private void LoadData()
        {
            string filter = myBaseDS.sysLog.onDateColumn.ColumnName + " BETWEEN '" +
                                            common.system.ConvertToSQLDateString(dateRange.frDate) + "' AND '" +
                                            common.system.ConvertToSQLDateString(dateRange.toDate) + "'";
            if (investorChk.Checked && investorEd.Text.Trim() != "")
            {
                string investorCode = investorEd.GetInvestorCode();
                if (investorCode!=null)
                    filter += (filter == "" ? "" : " AND ") + common.system.MakeSearchExpression(myBaseDS.sysLog.investorCodeColumn.ColumnName,investorCode.Trim(), system.searchOptions.Exact,true);
            }
            if (sourceChk.Checked && sourceEd.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") +
                    common.system.MakeSearchExpression(myBaseDS.sysLog.sourceColumn.ColumnName, sourceEd.Text.Trim(), system.searchOptions.Contain,true);
            if (descChk.Checked && descEd.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") +
                    common.system.MakeSearchExpression(myBaseDS.sysLog.descriptionColumn.ColumnName, descEd.Text.Trim(), system.searchOptions.Contain, true);

            if (messageChk.Checked && messageEd.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") +
                    common.system.MakeSearchExpression(myBaseDS.sysLog.messageColumn.ColumnName, messageEd.Text.Trim(), system.searchOptions.Contain, true);

            if (logTypeChk.Checked)
            {
                filter += (filter == "" ? "" : " AND ") +
                    myBaseDS.sysLog.typeColumn.ColumnName + " = " + ((byte)logTypeCb.myValue).ToString();
            }
            string sqlCmd = "SELECT * FROM " + myBaseDS.sysLog.TableName + (filter == "" ? "" : " WHERE " + filter);
            syslogSource.DataSource = DataAccess.Libs.GetSyslog_BySQL(sqlCmd);
            this.ShowReccount(syslogSource.Count);
        }
       
        private void okBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                ClearNotifyError();
                if(!dateRange.GetDateRange()) 
                {
                    NotifyError(dateRange);
                    return; 
                }
                fullMode = false;
                LoadData();
                fullMode = true;
                this.ShowReccount(syslogSource.Count);
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void syslogGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void descChk_CheckedChanged(object sender, EventArgs e)
        {
            descEd.Enabled = descChk.Checked;
        }

        private void logTypeChk_CheckedChanged(object sender, EventArgs e)
        {
            logTypeCb.Enabled = logTypeChk.Checked;
        }

        private void messageChk_CheckedChanged(object sender, EventArgs e)
        {
            messageEd.Enabled = messageChk.Checked;
        }

        private void workerChk_CheckedChanged(object sender, EventArgs e)
        {
            investorEd.Enabled = investorChk.Checked;
        }

        private void syslogViewer_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                //fullMode = fullMode;
                common.system.AutoFitGridColumn(syslogGrid, descriptionColumn.Name);
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }

        private void sourceChk_CheckedChanged(object sender, EventArgs e)
        {
            sourceEd.Enabled = sourceChk.Checked;
        }

        private void syslogGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex < 0) return;
            //    databases.baseDS.sysLogRow row = (databases.baseDS.sysLogRow)((DataRowView)syslogGrid.Rows[e.RowIndex].DataBoundItem).Row;
            //    if (row == null) return;
            //    this.ShowMessage((row.IsmessageNull() ? "" : row.message));
            //}
            //catch (Exception er)
            //{
            //    this.ShowError(er);
            //}
        }
    }
}