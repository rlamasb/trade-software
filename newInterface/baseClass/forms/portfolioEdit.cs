﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using commonTypes;
using commonClass;

namespace baseClass.forms
{
    public partial class portfolioEdit : baseMasterEdit
    {
        public AppTypes.PortfolioTypes myPortfolioType = AppTypes.PortfolioTypes.Portfolio;
        public portfolioEdit()
        {
            try
            {
                InitializeComponent();
                this.LoadDataOnLoad = false;
                myMasterSource = portfolioSource;

                codeEd.MaxLength = myDataSet.portfolio.codeColumn.MaxLength;
                nameEd.MaxLength = myDataSet.portfolio.nameColumn.MaxLength;
                descriptionEd.MaxLength = myDataSet.portfolio.descriptionColumn.MaxLength;
                
                codeEd.BackColor = common.Settings.sysColorDisableBG; codeEd.ForeColor = common.Settings.sysColorDisableFG;
                capitalUnitLbl.Text = Settings.sysMainCurrencyText;

                usedAmtEd.BackColor = common.Settings.sysColorHiLightBG1;
                usedAmtEd.ForeColor = common.Settings.sysColorHiLightFG1;

                cashAmtEd.BackColor = common.Settings.sysColorHiLightBG2;
                cashAmtEd.ForeColor = common.Settings.sysColorHiLightFG2; 

                common.system.AutoFitGridColumn(stockGrid, stockNameColumn.Name);
                LockEdit(true);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("portfolio");

            codeColumn.HeaderText = Languages.Libs.GetString("code");
            nameColumn.HeaderText = Languages.Libs.GetString("name");

            xpPane_generalInfo.Caption = Languages.Libs.GetString("generalInfo");
            codeLbl.Text = Languages.Libs.GetString("code");
            nameLbl.Text = Languages.Libs.GetString("name");
            descriptionLbl.Text = Languages.Libs.GetString("description");

            xpPanel_Investment.Caption = Languages.Libs.GetString("investment");
            capitalAmtLbl.Text = Languages.Libs.GetString("capitalAmt");
            usedAmtLbl.Text = Languages.Libs.GetString("usedAmt");
            cashAmtLbl.Text = Languages.Libs.GetString("cashAmt");
            maxBuyAmtPercLbl.Text = Languages.Libs.GetString("maxBuyAmtPercent");
            maxAccumulatePercLbl.Text = Languages.Libs.GetString("maxAccumulatePercent");
            maxReducePercLbl.Text = Languages.Libs.GetString("maxReducePercent");

            xpPane_ownedStock.Caption = Languages.Libs.GetString("ownedList");
            stockCodeColumn.HeaderText = Languages.Libs.GetString("code");
            stockNameColumn.HeaderText = Languages.Libs.GetString("name");
            qtyColumn.HeaderText = Languages.Libs.GetString("qty");
        }

        private void CalculateCashAmt()
        {
            if (this.portfolioSource.Current == null) return;
            databases.baseDS.portfolioRow row = (databases.baseDS.portfolioRow)((DataRowView)this.portfolioSource.Current).Row;
            if (row.IsNull(myDataSet.portfolio.startCapAmtColumn.ColumnName)) cashAmtEd.Value = 0;
            else cashAmtEd.Value = row.startCapAmt - row.usedCapAmt;
        }

        private string _myInvestorCode = "";
        public string myInvestorCode
        {
            get { return _myInvestorCode; }
            set 
            {
                _myInvestorCode = value;
                LoadData();
            }
        }
        public static portfolioEdit GetForm()
        {
            string cacheKey = typeof(portfolioEdit).FullName;
            portfolioEdit form = (portfolioEdit)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new portfolioEdit();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }
        protected void UpdateEditStatus()
        {
            ShowReccount((this.portfolioSource.Position + 1).ToString() + "/" + this.portfolioSource.Count.ToString());
        }
        protected void LoadDetailData()
        {
            if (this.portfolioSource.Current == null) return;
            databases.baseDS.portfolioRow row = (databases.baseDS.portfolioRow)((DataRowView)this.portfolioSource.Current).Row;
            //Investor stock
            if (row.IsNull(myDataSet.portfolio.codeColumn.ColumnName))
                 investorStockSource.DataSource = null;
            else investorStockSource.DataSource = DataAccess.Libs.GetOwnedStock_ByPortfolio(row.code);

        }

        #region override funcs
        protected override void SetFirstFocus()
        {
            this.nameEd.Focus();
        }
        protected override void LoadData()
        {
            portfolioSource.DataSource = DataAccess.Libs.GetPortfolio_ByInvestorAndType(this.myInvestorCode, this.myPortfolioType);
            CalculateCashAmt();
        }
        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            this.nameEd.Enabled = !lockState;
            this.descriptionEd.Enabled = !lockState;

            this.capitalAmtEd.Enabled = !lockState;
            this.usedAmtEd.Enabled = !lockState;
            this.cashAmtEd.Enabled = !lockState;

            this.maxBuyAmtPercEd.Enabled = !lockState;
            this.stockAccumulatePercEd.Enabled = !lockState;
            this.stockReducePercEd.Enabled = !lockState;
        }
        protected override bool DataValid(bool showMsg)
        {
            ClearNotifyError();
            bool retVal = base.DataValid(showMsg);
            if (nameEd.Text.Trim() == "")
            {
                NotifyError(nameLbl);
                retVal = false;
            }
            if (descriptionEd.Text.Trim() == "")
            {
                NotifyError(descriptionLbl);
                retVal = false;
            }
            if (!retVal) this.ShowMessage(Languages.Libs.GetString("invalidData"));
            return retVal;
        }
        public override void AddNew(string code)
        {
            //databases.baseDS.portfolioRow lastRow = (databases.baseDS.portfolioRow)((DataRowView)myMasterSource.Current).Row;
            databases.baseDS.portfolioRow row = (databases.baseDS.portfolioRow)((DataRowView)myMasterSource.AddNew()).Row;
            if (row == null) return;
            databases.AppLibs.InitData(row);
            row.type = (byte)this.myPortfolioType;
            row.investorCode = this.myInvestorCode;
            row.code = Consts.constMarkerNEW; 

            int position = myMasterSource.Position;
            myMasterSource.Position = -1;
            myMasterSource.Position = position;
            SetFirstFocus();
        }
        protected override void RemoveCurrent()
        {
            this.ShowMessage("");
            databases.baseDS.portfolioRow row = (databases.baseDS.portfolioRow)((DataRowView)myMasterSource.Current).Row;
            if (row.HasVersion(DataRowVersion.Original))
                DataAccess.Libs.DeleteData(row);
            base.RemoveCurrent();
        }
        protected override void UpdateData(DataRow row)
        {
            if (row == null) return;
            DataAccess.Libs.UpdateData((databases.baseDS.portfolioRow)row);
            LoadData();
        }

        protected override bool DataChanged()
        {
            return false;
        }

        #endregion override funcs

        #region event handler
        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowError(e.Exception);
        }
        private void portfolioSource_CurrentChanged(object sender, EventArgs e)
        {
            bool saveOnProccessing = this.fOnProccessing;
            try
            {
                if (this.fOnProccessing) return;
                CalculateCashAmt();
                UpdateEditStatus();
                LoadDetailData();
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        private void basePortfolioEdit_Resize(object sender, EventArgs e)
        {
            try
            {
                xpPanelGroup_Info.Height = this.ClientRectangle.Height - this.xpPanelGroup_Info.Location.Y - SystemInformation.CaptionHeight+3;
                xpPane_ownedStock.Height = xpPanelGroup_Info.Height - xpPane_ownedStock.Location.Y;
                if (xpPane_ownedStock.Height < 150) xpPane_ownedStock.Height = 150;
                common.system.AutoFitGridColumn(portfolioGrid, nameColumn.Name);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        private void capitalAmtEd_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                CalculateCashAmt();
            }
            catch (Exception er)
            {
                ShowError(er);
            }

        }
        #endregion event handler
    }
}