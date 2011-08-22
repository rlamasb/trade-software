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
    public partial class baseTradeOrderAddNew : baseTradeOrder
    {
        public baseTradeOrderAddNew()
        {
            try
            {
                InitializeComponent();
                dataNavigator.Visible = false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public void ShowForm()
        {
            AddNew();
            Show();
            this.BringToFront();
        }
        public override void SetFocus()
        {
            stockCodeEd.Focus();
        }
        protected override data.baseDS.investorTransHistoryRow AddNew()
        {
            myMode = editModes.New;
            stockCodeEd.Text = "";
            feePercEd.Value = application.Settings.sysStockTransFeePercent;
            qtyEd.Value = 0; subTotalEd.Value = 0; feeAmtEd.Value = 0; totalAmtEd.Value = 0;
            priceEd.Value = 0;
            statusCb.myValue = myTypes.commonStatus.New;
            SetFocus();
            return null;
        }
        protected override bool Save()
        {
            this.ShowMessage("");
            if (common.system.ShowDialogYesNo("Thực hiện giao dịch này ?") == DialogResult.No) return false;
            if (!base.Save()) return false;
            common.system.ShowMessage("Dữ liệu đã được cập nhật");
            return true;
        }
        protected override void CancelEdit() 
        {
            this.Close();
        }
    }
}