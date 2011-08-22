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
    public partial class baseTradeOrderNewFromAlert : baseTradeOrder
    {
        public baseTradeOrderNewFromAlert()
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
        private bool fDataSaved = false;

        public bool ShowForm(data.baseDS.tradeAlertRow alertRow)
        {
            myMode = editModes.NewFromAlert;
            this.feePercEd.Value = application.Settings.sysStockTransFeePercent;

            qtyEd.Value = 0; subTotalEd.Value = 0; feeAmtEd.Value = 0; totalAmtEd.Value = 0;
            portfolioCb.myValue  = alertRow.portfolio;
            stockCodeEd.Text = alertRow.stockCode.Trim();
            transTypeCb.myValue = (analysis.tradeActions)alertRow.tradeAction;
            statusCb.myValue = myTypes.commonStatus.New;

            //Price
            data.baseDS.priceDataRow priceRow = application.dataLibs.GetLastPrice(alertRow.stockCode);
            if (priceRow != null) priceEd.Value = priceRow.closePrice * application.Settings.sysStockPriceWeight;
            SetFocus();

            this.fDataSaved = false;
            ShowDialog();
            return this.fDataSaved;
        }
        
        protected override bool Save()
        {
            this.ShowMessage("");
            if (common.system.ShowDialogYesNo("Thực hiện giao dịch này ?") == DialogResult.No) return false;
            if (!base.Save()) return false;
            common.system.ShowMessage("Dữ liệu đã được cập nhật");
            this.Close();
            this.fDataSaved = true;
            return true;
        }
        protected override void CancelEdit() 
        {
            this.fDataSaved = false;
            this.Close();
        }
    }
}