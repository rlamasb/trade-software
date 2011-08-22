using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace stockTrade.forms
{
    public partial class baseTradeOrder : common.forms.baseForm
    {
        protected data.baseDS.investorTransHistoryDataTable myTransHistoryTbl = new data.baseDS.investorTransHistoryDataTable();
        public baseTradeOrder()
        {
            try
            {
                InitializeComponent();
                transTypeCb.LoadData();
                portfolioCb.LoadData();
                statusCb.LoadData();
                feePercEd.Value = Settings.sysStockTransFeePercent;
                this.myDataSource = new BindingSource();
                this.myDataSource.DataSource = this.myTransHistoryTbl;
                dataNavigator.Visible = false;

                //Color
                stockCodeEd.BackColor = common.settings.sysColorNormalBG; stockCodeEd.ForeColor = common.settings.sysColorNormalFG;
                transTypeCb.BackColor = common.settings.sysColorNormalBG; transTypeCb.ForeColor = common.settings.sysColorNormalFG;
                codeEd.BackColor = common.settings.sysColorNormalBG; codeEd.ForeColor = common.settings.sysColorNormalFG;
                portfolioCb.BackColor = common.settings.sysColorNormalBG; portfolioCb.ForeColor = common.settings.sysColorNormalFG;
                onTimeEd.BackColor = common.settings.sysColorNormalBG; onTimeEd.ForeColor = common.settings.sysColorNormalFG;

                qtyEd.BackColor = common.settings.sysColorNormalBG; qtyEd.ForeColor = common.settings.sysColorNormalFG;
                priceEd.BackColor = common.settings.sysColorNormalBG; priceEd.ForeColor = common.settings.sysColorNormalFG;
                subTotalEd.BackColor = common.settings.sysColorHiLightBG1; subTotalEd.ForeColor = common.settings.sysColorHiLightFG1;
                feePercEd.BackColor = common.settings.sysColorNormalBG; feePercEd.ForeColor = common.settings.sysColorNormalFG;
                feeAmtEd.BackColor = common.settings.sysColorNormalBG; feeAmtEd.ForeColor = common.settings.sysColorNormalFG;
                totalAmtEd.BackColor = common.settings.sysColorHiLightBG2; totalAmtEd.ForeColor = common.settings.sysColorHiLightFG2;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        public enum editModes { New, NewFromAlert, ViewOnly };
        public editModes _myMode = editModes.ViewOnly;
        public editModes myMode
        {
            get { return this._myMode; }
            set
            {
                this._myMode = value;
                switch (value)
                {
                    case editModes.New:
                        saveBtn.Enabled = true;
                        newBtn.Enabled = true;

                        qtyEd.ReadOnly = false;
                        stockCodeEd.ReadOnly = false;
                        portfolioCb.Enabled = true;
                        transTypeCb.Enabled = true;
                        break;
                    case editModes.NewFromAlert:
                        saveBtn.Enabled = true;
                        newBtn.Enabled = false;

                        qtyEd.ReadOnly = false;
                        stockCodeEd.ReadOnly = true;
                        portfolioCb.Enabled = false;
                        transTypeCb.Enabled = false;
                        break;

                    case editModes.ViewOnly:
                    default:
                        saveBtn.Enabled = false;
                        newBtn.Enabled = false;

                        qtyEd.ReadOnly = true;
                        stockCodeEd.ReadOnly = true;
                        portfolioCb.Enabled = false;
                        transTypeCb.Enabled = false;
                        break;
                }
            }
        }

        private BindingSource _myDataSource = null;
        public BindingSource myDataSource
        {
            get { return _myDataSource; }
            set
            {
                _myDataSource = value;
                if (value != null)
                {
                    _myDataSource.CurrentChanged += new System.EventHandler(this.DataSourceCurrentChanged);
                    DataSourceCurrentChanged(this, null);
                }
            }
        }
       
        private void DataBinding(BindingSource dataSource)
        {
            data.baseDS.investorTransHistoryDataTable tbl = new data.baseDS.investorTransHistoryDataTable();

            this.stockCodeEd.DataBindings.Clear();
            this.stockCodeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", dataSource, tbl.stockCodeColumn.ColumnName, true));

            this.transTypeCb.DataBindings.Clear();
            this.transTypeCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", dataSource, tbl.tranTypeColumn.ColumnName, true));

            this.codeEd.DataBindings.Clear();
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", dataSource, tbl.idColumn.ColumnName, true));

            this.portfolioCb.DataBindings.Clear();
            this.portfolioCb.DataBindings.Add(new System.Windows.Forms.Binding("myValue", dataSource, tbl.portfolioColumn.ColumnName, true));

            this.onTimeEd.DataBindings.Clear();
            this.onTimeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", dataSource, tbl.onTimeColumn.ColumnName, true));

            this.qtyEd.DataBindings.Clear();
            this.qtyEd.DataBindings.Add(new System.Windows.Forms.Binding("Value", dataSource, tbl.qtyColumn.ColumnName, true));

            this.subTotalEd.DataBindings.Clear();
            this.subTotalEd.DataBindings.Add(new System.Windows.Forms.Binding("Value", dataSource, tbl.amtColumn.ColumnName, true));

            this.feeAmtEd.DataBindings.Clear();
            this.feeAmtEd.DataBindings.Add(new System.Windows.Forms.Binding("Value", dataSource, tbl.feeAmtColumn.ColumnName, true));
        }
        /// <summary>
        /// Calculate total,subtotal,fee when qty was changed
        /// </summary>
        private void CalculateAmt()
        {
            subTotalEd.Value = qtyEd.Value * priceEd.Value;
            feeAmtEd.Value = Math.Round(feePercEd.Value * subTotalEd.Value / 1000, Settings.sysPrecisionLocal);
            totalAmtEd.Value = subTotalEd.Value + feeAmtEd.Value;
        }

        /// <summary>
        /// Price and fee percentage are not stored in the database so the function calculated the values form others
        /// </summary>
        private void CalculatePriceAndFeePercentage()
        {
            priceEd.Value = (int)((qtyEd.Value == 0 ? 0 : subTotalEd.Value / qtyEd.Value));
            feePercEd.Value = (subTotalEd.Value == 0 ? 0 : (feeAmtEd.Value / subTotalEd.Value) * 100);
            totalAmtEd.Value = subTotalEd.Value + feeAmtEd.Value;
        }
       
        protected virtual data.baseDS.investorTransHistoryRow AddNew()
        {
            this.myTransHistoryTbl.Clear();
            data.baseDS.investorTransHistoryRow transRow = this.myTransHistoryTbl.NewinvestorTransHistoryRow();
            dataLibs.InitData(transRow);
            feeAmtEd .Value = Settings.sysStockTransFeePercent;
            //Date
            DateTime onTime = sysLibs.GetServerDateTime();
            onTimeEd.myDateTime  = onTime;
            transRow.onTime = onTime;
            this.myTransHistoryTbl.AddinvestorTransHistoryRow(transRow);
            SetFocus();
            return transRow;
        }
        protected virtual bool Save()
        {
            if (statusCb.myValue == myTypes.commonStatus.Close)
            {
                common.system.ShowErrorMessage("Không thể lưu lại giao dịch đã đóng."); 
                return false;
            }
            data.baseDS.investorTransHistoryRow saveTransRow = 
                            dataLibs.MakeStockTransaction(transTypeCb.myValue,
                                                          stockCodeEd.Text,portfolioCb.myValue, (int)qtyEd.Value,
                                                          feePercEd.Value);
            if (saveTransRow==null) return false;
            statusCb.myValue = myTypes.commonStatus.Close;
            onTimeEd.myDateTime = saveTransRow.onTime;
            codeEd.Text = saveTransRow.id.ToString();
            subTotalEd.Value = saveTransRow.amt;
            feeAmtEd.Value = saveTransRow.feeAmt;
            CalculatePriceAndFeePercentage();
            return true;
        }
        protected virtual void CancelEdit() { this.Close(); }
        protected virtual void Find(){ }
        protected virtual void Print() { }
        protected virtual bool DataValid() 
        {
            ClearNotifyError();
            bool retVal = true;
            if (qtyEd.Value <= 0)
            {
                NotifyError(qtyLbl);
                retVal = false;
            }
            if (stockCodeEd.Text.Trim() == "")
            {
                NotifyError(stockCodeLbl);
                retVal = false;
            }
            if (transTypeCb.myValue == analysis.tradeActions.None)
            {
                NotifyError(transTypeLbl);
                retVal = false;
            }
            if (portfolioCb.myValue == "")
            {
                NotifyError(portfolioLbl);
                retVal = false;
            }
            if (this.myMode == editModes.New || this.myMode == editModes.NewFromAlert)
            {
                CalculateAmt();
            }
            return retVal;
        }
        public virtual void SetFocus()
        {
            //this.Focus();
            qtyEd.Focus();
        }

        public bool ShowForm(BindingSource dataSource, int orderId)
        {
            this.myMode = editModes.ViewOnly;
            this.myDataSource = dataSource;
            this.dataNavigator.BindingSource = dataSource;
            for (int idx = 0; idx < dataSource.Count; idx++)
            {
                if (((data.baseDS.investorTransHistoryRow)((DataRowView)dataSource[idx]).Row).id != orderId) continue;
                dataSource.Position = idx;
                break;
            }
            SetFocus();
            ShowDialog();
            return true;
        }
        private void DataSourceCurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.myMode != editModes.ViewOnly) return;

                if (this.myDataSource==null || this.myDataSource.Current==null) return;
                data.baseDS.investorTransHistoryRow row = (data.baseDS.investorTransHistoryRow)((DataRowView)this.myDataSource.Current).Row;
                this.stockCodeEd.Text = row.stockCode;
                this.transTypeCb.myValue =  (analysis.tradeActions)row.tranType;
                this.codeEd.Text = row.id.ToString();
                this.portfolioCb.myValue = row.portfolio;
                this.onTimeEd.myDateTime = row.onTime;
                this.qtyEd.Value = row.qty;
                this.subTotalEd.Value = row.amt;
                this.feeAmtEd.Value = row.feeAmt;
                CalculatePriceAndFeePercentage();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            try
            {
                AddNew();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (!DataValid()) return;
                Save();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CancelEdit();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }

        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Find();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }

        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Print();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }

        }
        private void qtyEd_Validated(object sender, EventArgs e)
        {
            try
            {
                if (this.myMode == editModes.New || this.myMode == editModes.NewFromAlert) CalculateAmt();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}