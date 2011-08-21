using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace tradeAlert.forms
{
    public partial class baseTradeAlertEdit : common.forms.baseDialogForm 
    {
        public baseTradeAlertEdit()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public void ShowForm(BindingSource dataSource,int rowId)
        {
            tradeAlertEdit.myDataSource = dataSource;
            dataNavigator.BindingSource = dataSource;
            for (int idx = 0; idx < dataSource.Count; idx++)
            {
                if (((data.baseDS.tradeAlertRow)((DataRowView)dataSource[idx]).Row).id != rowId) continue;
                dataSource.Position = idx;
                break;
            }
            ShowDialog();
        }

        private data.baseDS.tradeAlertRow myCurrentRow 
        {
            get
            {
                if (tradeAlertEdit.myDataSource==null || tradeAlertEdit.myDataSource.Current == null) return null;
                return (data.baseDS.tradeAlertRow)((DataRowView)tradeAlertEdit.myDataSource.Current).Row;
            }
        }

        #region event handler
        private void orderBtn_Click(object sender, EventArgs e)
        {
            this.ShowMessage("");
            if (this.myCurrentRow == null)
            {
                common.system.ShowMessage("Dữ liệu không hợp lệ !");
                return;
            }
            //Show order here....
            data.baseDS.tradeAlertRow row = this.myCurrentRow;
            application.dataLibs.CloseTradeAlert(row);
            application.dataLibs.UpdateData(row);
            this.ShowMessage("Đã lưu dữ liệu.");
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (this.myCurrentRow==null) 
                {
                    common.system.ShowMessage("Dữ liệu không hợp lệ !");
                    return;
                }
                if (common.system.ShowDialogYesNo("Hủy thông báo này ?") == DialogResult.No) return;
                data.baseDS.tradeAlertRow row = this.myCurrentRow;
                application.dataLibs.CancelTradeAlert(row);
                application.dataLibs.UpdateData(row);
                this.ShowMessage("Đã xóa dữ liệu.");
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void recoverBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (this.myCurrentRow == null)
                {
                    common.system.ShowMessage("Dữ liệu không hợp lệ !");
                    return;
                }
                data.baseDS.tradeAlertRow row = this.myCurrentRow;
                application.dataLibs.RenewTradeAlert(row);
                application.dataLibs.UpdateData(row);
                this.ShowMessage("Đã phục hồi dữ liệu.");
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}