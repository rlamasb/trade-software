using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using application;

namespace application
{
    public partial class baseVoucherEntry : baseVoucher
    {
        private bool fDoubledEntryBooking = true;  //Doubled-entry-booking status
        private bool fIgnoreDataNeed = false;  
                
        public baseVoucherEntry()
        {
            InitializeComponent();
        }

        public virtual void SetMainAccount(string accountNo, char debitCredit)
        {
            SetMainAccount(accountNo, debitCredit, false);
        }

        public virtual void SetMainAccount(string accountNo, char debitCredit, bool decrStat)
        {
            this.debitCreditCb.SelectedIndex =(debitCredit=='N' ? 0:1);
            this.debitCreditCb.Text = this.debitCreditCb.Items[this.debitCreditCb.SelectedIndex].ToString();
            this.accountEd.Text = accountNo;
            this.debitCreditCb.Enabled = decrStat;
        }
        
        protected override void LockEntryData(bool lockState)
        {
            base.LockEntryData(lockState);  
            this.accountEd.Enabled = !lockState;
        }

        protected override void ShowSubTotal()
        {
            double total = 0, tmp;
            for (int count = 0; count < detailGrid.Rows.Count; count++)
            {
                if (detailGrid.Rows[count].Cells["dAccountNo"].Value != null)
                {
                    tmp = 0; double.TryParse(this.detailGrid.Rows[count].Cells["amount"].Value.ToString(), out tmp);
                    total += tmp;
                }
            }
            this.subTotalEd.Text = total.ToString(Consts.constLocalAmtMask);
            //this.subTotalEd.Text = total.ToString();
        }

        protected override void SetDetailGrid()
        {
            DataGridViewComboBoxColumn dAccountNo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn dAccountName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            DataGridViewTextBoxColumn accountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn fAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn exRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn dCustCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn invoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn invoiceTaxPerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn catCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn voucherId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn dc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn deb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewCellStyle amountCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewCellStyle fAmountCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewCellStyle percentCellStyle = new System.Windows.Forms.DataGridViewCellStyle();

            amountCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            amountCellStyle.Format = "N0"; amountCellStyle.NullValue = null;

            fAmountCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            fAmountCellStyle.Format = "N2";  fAmountCellStyle.NullValue = null;
            
            percentCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            percentCellStyle.Format = "N1";  percentCellStyle.NullValue = null;

            // 
            // detailGrid
            // 
            this.detailGrid.DataSource = this.voucherDetailsSource;

            this.detailGrid.AutoGenerateColumns = false;
            this.detailGrid.ColumnHeadersHeight = 30;
            this.detailGrid.Columns.Clear();
            this.detailGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                    dAccountNo,dAccountName,amount,exRate,fAmount,dCustCode,invoiceNo,invoiceTaxPerc,
                    catCode1,accountNo,voucherId,deb,dc});
            this.detailGrid.Margin = new System.Windows.Forms.Padding(0);
            this.detailGrid.RowHeadersWidth = 28;
            this.detailGrid.RowTemplate.Height = 28;
            this.detailGrid.ScrollBars = ScrollBars.Vertical;
            this.detailGrid.Location = new System.Drawing.Point(0, 308);

            // 
            // dAccountNo
            // 
            dAccountNo.DataPropertyName = "dAccountNo";
            dAccountNo.DataSource = this.accountSource;
            dAccountNo.DisplayMember = "accountNo";
            dAccountNo.ValueMember = "accountNo";
            dAccountNo.HeaderText = "Đối.ứng";
            dAccountNo.Name = "dAccountNo";
            dAccountNo.Width = 90;
            dAccountNo.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            // 
            // dAccountName
            // 
            dAccountName.DataPropertyName = "dAccountNo";
            dAccountName.DataSource = this.accountSource;
            dAccountName.DisplayMember = "desc1";
            dAccountName.HeaderText = "         Tên tài khoản";
            dAccountName.Name = "dAccountName";
            dAccountName.ReadOnly = true;
            dAccountName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            dAccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            dAccountName.ValueMember = "accountNo";
            //dAccountName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dAccountName.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox; 
            dAccountName.Width = 215;
            // 
            // amount
            // 
            amount.DataPropertyName = "amount";
            amount.DefaultCellStyle = amountCellStyle;
            amount.HeaderText = "       Số tiền";
            amount.Name = "amount";
            amount.Width = 110;

            // 
            // Exchange rate
            // 
            exRate.DataPropertyName = "exRate";
            exRate.DefaultCellStyle = amountCellStyle;
            exRate.HeaderText = "Tỉ giá";
            exRate.Name = "exRate";
            exRate.Width = 50;
            exRate.Visible = false;

            // 
            // Foreign amount
            // 
            fAmount.DataPropertyName = "fAmount";
            fAmount.DefaultCellStyle = fAmountCellStyle;
            fAmount.HeaderText = " Nguyên tệ";
            fAmount.Name = "fAmount";
            fAmount.Width = 100;
            fAmount.Visible = false;

            // 
            // custCode
            // 
            dCustCode.DataPropertyName = "dcustCode";
            dCustCode.HeaderText = "Mã.đơn.vị";
            dCustCode.Name = "dCustCode";
            dCustCode.Width = 75;

            // 
            // Invoice
            // 
            invoiceNo.DataPropertyName = "invoiceNo";
            invoiceNo.HeaderText = "Hoá.đơn";
            invoiceNo.Name = "gridInvoiceNo";
            invoiceNo.Width = 80;

            // 
            // Invoice's tax
            // 
            invoiceTaxPerc.DefaultCellStyle = percentCellStyle;
            invoiceTaxPerc.HeaderText = "%";
            invoiceTaxPerc.DataPropertyName = "invoiceTaxPerc";
            invoiceTaxPerc.Name = "gridTax";
            invoiceTaxPerc.Width = 35;

            // 
            // AccountNo
            // 
            accountNo.DataPropertyName = "accountNo";
            accountNo.HeaderText = "";
            accountNo.Name = "accountNo";
            accountNo.Width = 70;
            accountNo.Visible = false;

            // 
            // gridVoucherId
            // 
            voucherId.DataPropertyName = "voucherId";
            voucherId.Name = "voucherId";
            voucherId.HeaderText = "a";
            voucherId.Width = 90;
            voucherId.Visible = false;

            // 
            // gridCatCode1
            // 
            catCode1.DataPropertyName = "catCode1";
            catCode1.HeaderText = "Phân loại";
            catCode1.Name = "gridCatCode1";
            catCode1.Width = 90;
            catCode1.Visible = false;

            // 
            // dc
            // 
            dc.DataPropertyName = "dc";
            dc.Name = "dc";
            dc.HeaderText = "a";
            dc.Width = 50;
            dc.Visible = false;

            // 
            // deb
            // 
            deb.DataPropertyName = "deb";
            deb.Name = "deb";
            deb.HeaderText = "a";
            deb.Width = 50;
            deb.Visible = false;
        }

        protected override bool SaveDetailData(int voucherId) 
        {
            if (!base.SaveDetailData(voucherId)) return false;    
            try
            {
                DataRowView drVoucher = (DataRowView)voucherSource.Current;
                //Update the VoucherID and AccountNo
                DataRowView drDetail;
                for (int i = 0; i < voucherDetailsSource.Count; i++)
                {
                    voucherDetailsSource.Position = i;
                    drDetail = (DataRowView)voucherDetailsSource.Current;
                    drDetail["accountNo"] = this.accountEd.Text.ToString();
                    drDetail["VoucherId"] = drVoucher["VoucherId"];
                    
                    //Empty custCode means no customer so it must set to be null
                    if (drDetail["dCustCode"].ToString().Trim() == "") drDetail["dCustCode"] = null;
                    if (drDetail["custCode"].ToString().Trim() == "") drDetail["custCode"] = null;
                    
                    drDetail["dc"] = (this.debitCreditCb.SelectedIndex==0?"N":"C");
                    drDetail["deb"]= fDoubledEntryBooking;
                    if (SameInvoiceMode)  drDetail["invoiceNo"] = drVoucher["refInvoiceNo"];
                    if (drDetail["invoiceNo"].ToString().Trim() == "")  drDetail["invoiceNo"] = null;
                }
                voucherDetailsSource.EndEdit();
                voucherDetailsTableAdapter.Update(myApplicationDataSet.VoucherDetails);
                myApplicationDataSet.VoucherDetails.AcceptChanges();

                this.ShowMessage("Đã lưu số liệu");
                return true;
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
                common.sysLibs.ShowErrorMessage("Không lưu được dữ liệu");
            }
            return false;
        }

        protected override void SameInvoiceModeChanged(bool mode)
        {
            if (this.detailGrid.Columns["gridInvoiceNo"] == null) return;
            this.detailGrid.Columns["gridInvoiceNo"].ReadOnly = mode;
            Color cl = (mode ? invoiceNoEd.BackColor : voucherNoEd.BackColor);
            this.detailGrid.Columns["gridInvoiceNo"].DefaultCellStyle.BackColor = cl;
        }

        protected override void CancelAllChanges()
        {
            try
            {
                base.CancelAllChanges();
                voucherDetailsSource.CancelEdit();
                myApplicationDataSet.VoucherDetails.RejectChanges();
                this.ShowMessage("");
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString(), "Lỗi");
                common.sysLibs.ShowErrorMessage("Không thể phục hồi(Undo) dữ liệu");
            }
        }

        //Load detail data for current voucher
        protected override void LoadDetailData(int VoucherId) 
        {
            this.voucherDetailsTableAdapter.FillByVoucherId(this.myApplicationDataSet.VoucherDetails,VoucherId);
            DataRowView drDetails = (DataRowView)voucherDetailsSource.Current;
            if (drDetails != null)
            {
                this.accountEd.Text = drDetails["AccountNo"].ToString();
                this.debitCreditCb.SelectedIndex = (drDetails["dc"].ToString().Contains("N") ? 0 : 1);
            }
            ShowSubTotal();

            this.ShowMessage("");
            base.LoadDetailData(VoucherId); 
        }

        //Copy data
        protected override void CopyData(int VoucherId,bool appendMode)
        {
            data.applicationDataSet.VoucherDetailsDataTable tmpTbl = new data.applicationDataSet.VoucherDetailsDataTable();
            this.voucherDetailsTableAdapter.FillByVoucherId(tmpTbl, VoucherId);
            if (!appendMode)  this.myApplicationDataSet.VoucherDetails.Clear();
            data.applicationDataSet.VoucherDetailsRow dr;   
            for (int idx=0; idx < tmpTbl.Rows.Count;idx++)
            {
                dr = myApplicationDataSet.VoucherDetails.NewVoucherDetailsRow();
                dr.ItemArray = tmpTbl[idx].ItemArray;
                myApplicationDataSet.VoucherDetails.AddVoucherDetailsRow(dr); 
            }
            ShowSubTotal();
            this.ShowMessage("");
            base.CopyData(VoucherId, appendMode);
        }

        protected override void CopyLines()
        {
            if (this.detailGrid.SelectedRows.Count <= 0) return;
            data.applicationDataSet.VoucherDetailsRow dr;
            for (int idx = detailGrid.SelectedRows.Count - 1; idx >= 0; idx--)
            {
                dr = myApplicationDataSet.VoucherDetails.NewVoucherDetailsRow();
                dr.ItemArray = ((DataRowView)detailGrid.Rows[detailGrid.SelectedRows[idx].Index].DataBoundItem).Row.ItemArray;
                myApplicationDataSet.VoucherDetails.AddVoucherDetailsRow(dr);
            }
            ShowSubTotal();
            base.CopyLines();
        }   
        protected override void DetailValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (e == null) return;
            if (fIgnoreDataNeed) return;
            fIgnoreDataNeed = true;

            string SaveCustCode = "",SaveDAccountNo = "",SaveInvoiceNo = "";
            double SaveInvoicePerc = 0;
            try
            {
                if (detailGrid.CurrentRow != null)
                {
                    SaveCustCode = detailGrid.CurrentRow.Cells["dCustCode"].Value.ToString();
                    SaveDAccountNo = detailGrid.CurrentRow.Cells["dAccountNo"].Value.ToString();
                    SaveInvoiceNo = detailGrid.CurrentRow.Cells["gridInvoiceNo"].Value.ToString();
                    double.TryParse(detailGrid.CurrentRow.Cells["gridTax"].Value.ToString(), out SaveInvoicePerc);
                }
                if (this.SameCustCodeMode) SaveCustCode = this.custCodeEd.Text.ToString();

                int VoucherId = 0; int.TryParse(this.voucherIdEd.Text.ToString(), out VoucherId);
                e.Row.Cells["VoucherId"].Value = VoucherId;
                e.Row.Cells["dAccountNo"].Value = SaveDAccountNo;
                e.Row.Cells["dCustCode"].Value = SaveCustCode;
                e.Row.Cells["gridInvoiceNo"].Value = SaveInvoiceNo;
                e.Row.Cells["gridTax"].Value = SaveInvoicePerc;

                e.Row.Cells["amount"].Value = 0;

                e.Row.Cells["dc"].Value = "N";
                e.Row.Cells["deb"].Value = fDoubledEntryBooking;
                e.Row.Cells["accountNo"].Value = this.accountEd.Text.ToString();

                this.ShowMessage("");
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
            }
            finally
            {
                fIgnoreDataNeed = false;
            }
            return;
        }

        protected override bool VoucherDataValid()
        {
            if (!base.VoucherDataValid()) return false;
        
            if (accountEd.Text.Trim() == "")
            {
                accountEd.Focus(); common.sysLibs.ShowErrorMessage("Chưa nhập [Tàikhoản]>");
                return false;
            }
            return true;
        }

        protected override void DetailCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {   
            string invoiceNo;
            if (detailGrid.CurrentCell == null) return;
            try
            {
                this.ShowMessage("");
                //dAccountNo
                if (detailGrid.Columns[e.ColumnIndex].Name.Trim() == "dAccountNo")
                {
                    application.globalObj.myAccountFind.Find(detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), true);
                    if (application.globalObj.myAccountFind.selectedDataRow != null)
                    {
                        detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = application.globalObj.myAccountFind.selectedDataRow["accountNo"].ToString();
                        voucherDetailsSource.ResetCurrentItem();  
                    }
                }
                //Ammount
                if (detailGrid.Columns[e.ColumnIndex].Name.Trim() == "amount") ShowSubTotal();

                //Allow tax percent to be null
                if (detailGrid.Columns[e.ColumnIndex].Name.Trim() == "gridTax")
                {
                    if (detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() == "")
                        detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                    else
                    {
                        double d = 0;
                        double.TryParse(detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out d);
                        detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = d;
                    }
                }

                //Customer 
                if (detailGrid.Columns[e.ColumnIndex].Name.Trim() == "dCustCode")
                {
                    if (detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() == "")
                    {
                        detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null; return;
                    }
                    if (detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        application.globalObj.myCustomerFind.SetQuerryCustCode(detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        application.globalObj.myCustomerFind.Find(detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), true);
                        if (application.globalObj.myCustomerFind.selectedDataRow != null)
                        {
                            detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = application.globalObj.myCustomerFind.selectedDataRow["customerCode"].ToString();
                        }
                        else detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                        voucherDetailsSource.ResetCurrentItem();  
                    }
                }
                //Invoice
                if (detailGrid.Columns[e.ColumnIndex].Name.Trim() == "gridInvoiceNo")
                {
                    if (detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() == "")
                    {
                        detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                        return;
                    }
                    if (detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        invoiceNo = detailGrid.Rows[e.RowIndex].Cells["gridInvoiceNo"].Value.ToString();
                        if (this.FindAddInvoice(ref invoiceNo))
                        {
                            detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = invoiceNo;
                        }
                        else
                        {
                            detailGrid.Rows[e.RowIndex].Cells["gridInvoiceNo"].Value = null;
                        }
                        voucherDetailsSource.ResetCurrentItem();
                    }
                }
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
            }
        }


        protected override void DetailCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string invoiceNo;
            if (detailGrid.CurrentCell == null) return;
            try
            {
                this.ShowMessage("");
                //Invoice
                if (detailGrid.Columns[e.ColumnIndex].Name.Trim() == "gridInvoiceNo")
                {
                    if (detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() == "")
                        return;
                    invoiceNo = detailGrid.Rows[e.RowIndex].Cells["gridInvoiceNo"].Value.ToString();
                    if (this.FindShowInvoice(ref invoiceNo))
                    {
                        detailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = invoiceNo;
                    }
                    else
                    {
                        detailGrid.Rows[e.RowIndex].Cells["gridInvoiceNo"].Value = null;
                    }
                    voucherDetailsSource.ResetCurrentItem();
                }
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
            }
        }

        private void accountEd_Validating(object sender, CancelEventArgs e)
        {
            if (application.globalObj.myAccountFind.Find(this.accountEd.Text.ToString()))
            {
                DataRowView drFind = application.globalObj.myAccountFind.selectedDataRow;
                this.accountEd.Text = drFind["accountNo"].ToString();
            }
        }

        private void voucherEntry_Load(object sender, EventArgs e)
        {
            this.accountTableAdapter.Fill(this.myMasterDataSet.Account);
        }
    }
}