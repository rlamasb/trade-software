using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace baseClass.controls
{
    public partial class companyCriteria : common.control.baseUserControl
    {
        private data.baseDS.companyDataTable companyTbl = new data.baseDS.companyDataTable();
        private data.baseDS.stockCodeDataTable stockCodeTbl = new data.baseDS.stockCodeDataTable();
        public companyCriteria()
        {
            try
            {
                InitializeComponent();
                commCodeEd.isToUpperCase=true;
                tickerCodeEd.isToUpperCase = true;
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }

        public void LoadData()
        {
            stockExchangeCb.LoadData();
        }

        public string GetCriteria()
        {
            return GetCriteria(companyTbl.TableName, stockCodeTbl.TableName, false);
        }
        public string GetCriteria(string companyAlias, string stockCodeAlias, bool withUnicode)
        {
            string filter = "";
            if (this.commCodeChk.Checked && this.commCodeEd.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") + (companyAlias == "" ? "" : companyAlias + ".") + companyTbl.codeColumn.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" +  common.Consts.SQL_CMD_ALL_MARKER + this.commCodeEd.Text.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";

            if (this.nameChk.Checked && this.nameEd.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") + (companyAlias == "" ? "" : companyAlias + ".") + companyTbl.nameColumn.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" + common.Consts.SQL_CMD_ALL_MARKER + this.nameEd.Text.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";

            if (this.address1Chk.Checked && this.address1Ed.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") + (companyAlias == "" ? "" : companyAlias + ".") + companyTbl.address1Column.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" + common.Consts.SQL_CMD_ALL_MARKER + this.address1Ed.Text.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";

            if (this.stockExchangeChk.Checked && this.stockExchangeCb.myValue != "")
                filter += (filter == "" ? "" : " AND ") + (stockCodeAlias == "" ? "" : stockCodeAlias + ".") + stockCodeTbl.stockExchangeColumn.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" + common.Consts.SQL_CMD_ALL_MARKER + this.stockExchangeCb.myValue.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";

            if (this.tickerCodeChk.Checked && this.tickerCodeEd.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") + (stockCodeAlias == "" ? "" : stockCodeAlias + ".") + stockCodeTbl.tickerCodeColumn.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" + common.Consts.SQL_CMD_ALL_MARKER + this.tickerCodeEd.Text.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";
            return filter;
        }

        public string GetSQL()
        {
            string cond = GetCriteria("a", "b", true);
            string sqlCmd = "SELECT a.* FROM company a ";
            if (tickerCodeEd.Enabled  && tickerCodeEd.Text.Trim()!="")
                sqlCmd += " INNER JOIN stockCode b  ON a.code=b.comCode";
            if (cond.Trim() != "") sqlCmd += " WHERE " + cond;
            return sqlCmd;
        }

        private void address1Chk_CheckedChanged(object sender, EventArgs e)
        {
            address1Ed.Enabled = address1Chk.Checked;
        }

        private void commCodeChk_CheckedChanged(object sender, EventArgs e)
        {
            commCodeEd.Enabled = commCodeChk.Checked;
        }

        private void nameChk_CheckedChanged(object sender, EventArgs e)
        {
            nameEd.Enabled = nameChk.Checked;
        }

        private void stockExchangeChk_CheckedChanged(object sender, EventArgs e)
        {
            stockExchangeCb.Enabled = stockExchangeChk.Checked;
        }

        private void tickerCodeChk_CheckedChanged(object sender, EventArgs e)
        {
            tickerCodeEd.Enabled = tickerCodeChk.Checked;
        }
    }
}