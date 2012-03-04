using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AdvancedDataGridView;
using application;
using commonTypes;
using commonClass;

namespace Trade.Forms
{
    public partial class  tradeAlertList : common.forms.baseForm
    {
        public tradeAlertList()
        {
            try
            {
                InitializeComponent();
                common.dialogs.SetFileDialogEXCEL(saveFileDialog);

                stockCodeSource.DataSource = DataAccess.Libs.myStockCodeTbl;
                tradeActionSource.DataSource = application.AppLibs.GetTradeActions();
                timeScaleSource.DataSource = application.AppLibs.GetTimeScales();
                CommonStatusSource.DataSource = application.AppLibs.GetCommonStatus();

                SetDataGrid();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("tradeAlert");
            onDateColumn.HeaderText = Languages.Libs.GetString("onDate");
            codeColumn.HeaderText = Languages.Libs.GetString("code");
            strategyColumn.HeaderText = Languages.Libs.GetString("strategy");
            timeScaleColumn.HeaderText = Languages.Libs.GetString("timeScale");
            actionColumn.HeaderText = Languages.Libs.GetString("tradeAction");
            detailGrid.Refresh();

            sumOnDateColumn.HeaderText = Languages.Libs.GetString("onDate");
            sumCodeColumn.HeaderText = Languages.Libs.GetString("code");
            sumNameColumn.HeaderText = Languages.Libs.GetString("description");
            sumMessageColumn.HeaderText = Languages.Libs.GetString("alertSummary");

            sumNameColumn.DisplayMember = (commonClass.SysLibs.IsUseVietnamese() ? myTmpDS.stockCode.nameColumn.ColumnName : 
                                              myTmpDS.stockCode.nameEnColumn.ColumnName); 

            alertSummarySource.DataSource = MakeAlertSummary(tradeAlertSource.DataSource as databases.baseDS.tradeAlertDataTable);
            summaryGrid.Refresh();
        }

        public enum gridColumnName { OnTime, TradeAction, StockCode, Strategy, TimeScale, Status, View, Cancel };
        public virtual void  Init()
        {
            databases.tmpDS.codeListDataTable strategyTbl = new databases.tmpDS.codeListDataTable();
            application.Strategy.Libs.LoadStrategy(strategyTbl, AppTypes.StrategyTypes.Strategy);
            strategySource.DataSource = strategyTbl;

            DateTime lastAlertDate = DataAccess.Libs.GetLastAlertTime(commonClass.SysLibs.sysLoginCode);
            DateTime onDate = DataAccess.Libs.GetServerDateTime();
            if (lastAlertDate == common.Consts.constNullDate) lastAlertDate = onDate;
            lastAlertDate = lastAlertDate.Date;

            SetFilterDateRange(lastAlertDate, onDate);
            SetFilterDateRangeStat(true, true);
            SetFilterStatus(AppTypes.CommonStatus.New);
            
        }

        public delegate void onCellClick(gridColumnName colName, databases.baseDS.tradeAlertRow row);
        public event onCellClick myOnCellClick = null;

        public ContextMenuStrip myContextMenuStrip
        {
            get 
            { 
                return detailGrid.ContextMenuStrip; 
            }
            set 
            { 
                this.detailGrid.ContextMenuStrip = value;
                this.summaryGrid.ContextMenuStrip = value; 
            }
        }        

        private string _myPortfolioCode = "";
        public string myPortfolioCode
        {
            get {return _myPortfolioCode; }
            set 
            {
                _myPortfolioCode = value; 
                myAlertFilterForm.myPortfolio = value; 
            }
        }
        private string _myStockCode = "";
        public string myStockCode
        {
            get {return _myStockCode; }
            set 
            {
                _myStockCode = value; 
                myAlertFilterForm.myStockCode = value; 
            }
        }
        public databases.baseDS.tradeAlertRow CurrentRow
        {
            get
            {
                if (tradeAlertSource.Current == null) return null;
                return (databases.baseDS.tradeAlertRow)((DataRowView)tradeAlertSource.Current).Row;
            }
        }

        public databases.baseDS.tradeAlertRow CurrentSummaryRow
        {
            get
            {
                if (alertSummarySource.Current == null) return null;
                return (databases.baseDS.tradeAlertRow)((DataRowView)alertSummarySource.Current).Row;
            }
        }

        public void Export()
        {
            if (summaryGrid.DataSource == null)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("noData"));
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel(myDataSet.tradeAlert, saveFileDialog.FileName);
        }
        public void FormResize()
        {
            common.system.AutoFitGridColumn(detailGrid, strategyColumn.Name);
            common.system.AutoFitGridColumn(summaryGrid, sumNameColumn.Name);
        }
        public void SetColumnVisible(string[] colName, bool visible)
        {
            summaryGrid.SetColumnVisible(colName, visible);
            FormResize();
        }
        public void SetColumnVisible(string colName, bool visible)
        {
            summaryGrid.SetColumnVisible(colName, visible);
            FormResize();
        }
        public void SetFilterDateRangeDefault()
        {
            myAlertFilterForm.myFromDate = DataAccess.Libs.GetServerDateTime();
            myAlertFilterForm.myToDate = myAlertFilterForm.myFromDate;
        }
        public void SetFilterDateRange(DateTime frDate,DateTime toDate)
        {
            myAlertFilterForm.myFromDate = frDate;
            myAlertFilterForm.myToDate = toDate;
        }
        public void SetFilterDateRangeStat(bool enable,bool check)
        {
            myAlertFilterForm.SetDateRange(enable,check);
        }
        public void SetFilterPortfolioStat(bool enable, bool check)
        {
            myAlertFilterForm.SetPortfolio(enable, check);
        }
        public void SetFilterStockStat(bool enable, bool check)
        {
            myAlertFilterForm.SetStockCode(enable, check);
        }
        public void SetFilterStatusStat(bool enable, bool check)
        {
            myAlertFilterForm.SetStatus(enable, check);
        }
        public void SetFilterStatus(AppTypes.CommonStatus status)
        {
            myAlertFilterForm.myStatus =  status;
        }
        public virtual void LoadData()
        {
            tradeAlertSource.DataSource = DataAccess.Libs.GetTradeAlert_BySQL(myAlertFilterForm.GetSQL());
            alertSummarySource.DataSource = MakeAlertSummary(tradeAlertSource.DataSource as databases.baseDS.tradeAlertDataTable);
            SetDataGrid();
            ShowReccount(alertSummarySource.Count);
        }

        private class SummaryItem
        {
            public SummaryItem(string stockCode, DateTime onDate)
            { 
                StockCode = stockCode;
                OnDate = onDate;
            }
            public string StockCode = "";
            public DateTime OnDate = common.Consts.constNullDate;
            public int Qty = 0;
        }
        public databases.baseDS.tradeAlertDataTable MakeAlertSummary(databases.baseDS.tradeAlertDataTable tbl)
        {
            SummaryItem buyCount,sellCount;
            databases.baseDS.tradeAlertRow sumRow;
            databases.baseDS.tradeAlertDataTable sumTbl = new databases.baseDS.tradeAlertDataTable();
            sumTbl.DefaultView.Sort = sumTbl.onTimeColumn.ColumnName +"," + sumTbl.stockCodeColumn.ColumnName;
            DataRowView[] foundRows;
            common.DictionaryList buyCountList = new common.DictionaryList();
            common.DictionaryList sellCountList = new common.DictionaryList();

            object obj;
            //Sum
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                foundRows = sumTbl.DefaultView.FindRows(new object[]{tbl[idx].onTime.Date, tbl[idx].stockCode});
                if (foundRows.Length != 0) 
                    sumRow = (databases.baseDS.tradeAlertRow)foundRows[0].Row;
                else
                {
                    sumRow = sumTbl.NewtradeAlertRow();
                    databases.AppLibs.InitData(sumRow);
                    sumRow.onTime = tbl[idx].onTime.Date;
                    sumRow.stockCode = tbl[idx].stockCode;
                    sumTbl.AddtradeAlertRow(sumRow);
                }
                AppTypes.TradeActions action = (AppTypes.TradeActions)tbl[idx].tradeAction; 
                switch(action)
                {
                    case AppTypes.TradeActions.Buy :
                    case AppTypes.TradeActions.Accumulate :
                         obj =  buyCountList.Find(sumRow.onTime.ToString() + sumRow.stockCode);
                         if (obj == null)
                             buyCount = new SummaryItem(sumRow.stockCode, sumRow.onTime);
                         else buyCount = (SummaryItem)obj;
                         buyCount.Qty++;
                         buyCountList.Add(sumRow.onTime.ToString() + sumRow.stockCode, buyCount);
                         break;
                    case AppTypes.TradeActions.Sell :
                    case AppTypes.TradeActions.ClearAll :
                         obj = sellCountList.Find(sumRow.onTime.ToString() + sumRow.stockCode);
                         if (obj == null)
                             sellCount = new SummaryItem(sumRow.stockCode, sumRow.onTime);
                         else sellCount = (SummaryItem)obj;
                         sellCount.Qty++;
                         sellCountList.Add(sumRow.onTime.Date.ToString() + sumRow.stockCode, sellCount);
                         break;
                }
            }
            //Make summary message
            for (int idx = 0; idx < sumTbl.Count; idx++)
            {
                sumTbl[idx].msg ="";
                obj = buyCountList.Find(sumTbl[idx].onTime.ToString() + sumTbl[idx].stockCode);
                if (obj != null)
                    sumTbl[idx].msg += (sumTbl[idx].msg.Trim() != "" ? " , " : "") + (obj as SummaryItem).Qty.ToString() +" "+ Languages.Libs.GetString("buyAlert");

                obj = sellCountList.Find(sumTbl[idx].onTime.ToString() + sumTbl[idx].stockCode);
                if (obj != null)
                    sumTbl[idx].msg += (sumTbl[idx].msg.Trim() !="" ? " , " : "") +(obj as SummaryItem).Qty.ToString()+ " "+ Languages.Libs.GetString("sellAlert") ; 
            }
            return sumTbl;
        }

        private Forms.tradeAlertEdit _myTradeAlertEditForm = null;
        private Forms.tradeAlertEdit myTradeAlertEditForm
        {
            get
            {
                if (_myTradeAlertEditForm == null || _myTradeAlertEditForm.IsDisposed)
                    _myTradeAlertEditForm = GetTradeAlertEditForm();
                return _myTradeAlertEditForm;
            }
        }
        protected virtual Forms.tradeAlertEdit GetTradeAlertEditForm()
        {
            return new Forms.tradeAlertEdit();
        }

        private Forms.alertFilter _myAlertFilterForm = null;
        private Forms.alertFilter myAlertFilterForm
        {
            get
            {
                if (_myAlertFilterForm == null || _myAlertFilterForm.IsDisposed)
                {
                    _myAlertFilterForm = GetAlertFilterForm();
                    _myAlertFilterForm.myOnProcess += new common.forms.baseDialogForm.onProcess(DoAlertFilter);
                }
                return _myAlertFilterForm;
            }
        }
        protected virtual Forms.alertFilter GetAlertFilterForm()
        {
            return new Forms.alertFilter();
        }

        private Forms.transactionFromAlert _myNewTradeOrderForm = null;
        private Forms.transactionFromAlert myNewTradeOrderForm
        {
            get
            {
                if (_myNewTradeOrderForm == null || _myNewTradeOrderForm.IsDisposed)
                    _myNewTradeOrderForm = GetNewTradeOrderForm();
                return _myNewTradeOrderForm;
            }
        }

        public override void Refresh()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    LoadData();
                });
            }
            else
            {
                LoadData();
                base.Refresh();
            }
        }

        protected virtual Forms.transactionFromAlert GetNewTradeOrderForm()
        {
            return new Forms.transactionFromAlert();
        }
        
        private void DoAlertFilter(object sender,common.baseDialogEvent e)
        {
            try
            {
                common.system.ShowCurrorWait();
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                common.system.ShowCurrorDefault();
            }
        }
        private void EditTradeAlert(int rowId)
        {
            myTradeAlertEditForm.ShowForm(tradeAlertSource, rowId);
        }
        private void EditTradeAlert()
        {
            if (tradeAlertSource.Current == null) return;
            databases.baseDS.tradeAlertRow row = (databases.baseDS.tradeAlertRow)((DataRowView)tradeAlertSource.Current).Row;
            EditTradeAlert(row.id);
        }
        private bool DeleteTradeAlert(int rowId)
        {
            if (common.system.ShowDialogYesNo(Languages.Libs.GetString("askDeleteAlert")) == DialogResult.No) return false;
            DataAccess.Libs.DeleteTradeAlert(rowId);
            return true;
        }
        private void DeleteTradeAlerts()
        {
            if (summaryGrid.SelectedRows.Count == 0)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("pleaseSelectRows"));
                return;
            }
            if (common.system.ShowDialogYesNo(Languages.Libs.GetString("askDeleteAlert")) == DialogResult.No) return;
            int count = 0;
            databases.baseDS.tradeAlertRow row;
            for (int idx = 0; idx < summaryGrid.SelectedRows.Count; idx++)
            {
                row = (databases.baseDS.tradeAlertRow)((DataRowView)summaryGrid.SelectedRows[idx].DataBoundItem).Row;
                if (row == null) continue;
                DataAccess.Libs.DeleteTradeAlert(row.id);
                count++;
                summaryGrid.Rows.RemoveAt(summaryGrid.SelectedRows[idx].Index); 
            }
            common.system.ShowMessage(String.Format(Languages.Libs.GetString("alertDeleted"),count));
        }
        private void IgnnoreAlerts()
        {
            databases.baseDS.tradeAlertRow alertRow;
            for (int idx = 0; idx < summaryGrid.SelectedRows.Count; idx++)
            {
                alertRow = (databases.baseDS.tradeAlertRow)((DataRowView)summaryGrid.SelectedRows[idx].DataBoundItem).Row;
                if (alertRow == null) continue;
                alertRow.status = (byte)AppTypes.CommonStatus.Ignore;
                DataAccess.Libs.UpdateData(alertRow);
            }
        }
        private void RecoverAlerts()
        {
            databases.baseDS.tradeAlertRow alertRow;
            for (int idx = 0; idx < summaryGrid.SelectedRows.Count; idx++)
            {
                alertRow = (databases.baseDS.tradeAlertRow)((DataRowView)summaryGrid.SelectedRows[idx].DataBoundItem).Row;
                if (alertRow == null) continue;
                alertRow.status = (byte)AppTypes.CommonStatus.New;
                DataAccess.Libs.UpdateData(alertRow);
            }
        }
        public void PlaceOrder()
        {
            if (this.CurrentRow == null) return;
            this.myNewTradeOrderForm.ShowNew(this.CurrentRow);
        }
        protected void SetDataGrid()
        {
            this.onDateColumn.Name = gridColumnName.OnTime.ToString();
            this.codeColumn.Name = gridColumnName.StockCode.ToString();
            this.actionColumn.Name = gridColumnName.TradeAction.ToString();
            this.strategyColumn.Name = gridColumnName.Strategy.ToString();
            this.statusColumn.Name = gridColumnName.Status.ToString();
            this.viewColumn.Name = gridColumnName.View.ToString();
            
            this.viewColumn.myImageType = common.controls.imageType.Edit;
            this.toDetailBtn.myImageType = common.controls.imageType.Detail;
            this.toSummaryBtn.myImageType = common.controls.imageType.Detail;
        }

        #region event handler
        private void tradeAlertList_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.fOnProccessing) return;
                this.fOnProccessing = true;
                FormResize();
                this.fOnProccessing = false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
                this.fOnProccessing = false;
            }
        }
        private void detailGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0 && detailGrid.Columns[e.ColumnIndex] == toSummaryBtn)
                    mainTab.SelectedTab = summaryPg;

                databases.baseDS.tradeAlertRow alertRow; 
                if (this.tradeAlertSource.Current == null || e == null) return;

                if (detailGrid.Columns[e.ColumnIndex].Name == gridColumnName.View.ToString())
                {
                    alertRow = (databases.baseDS.tradeAlertRow)((DataRowView)tradeAlertSource.Current).Row;
                    EditTradeAlert(alertRow.id);
                    return;
                }
                if (detailGrid.Columns[e.ColumnIndex].Name == gridColumnName.Cancel.ToString())
                {
                    alertRow = (databases.baseDS.tradeAlertRow)((DataRowView)tradeAlertSource.Current).Row;
                    if(!DeleteTradeAlert(alertRow.id)) return;
                    summaryGrid.Rows.RemoveAt(e.RowIndex); 
                    return;
                }

                if (this.tradeAlertSource.Current == null || e == null || myOnCellClick == null) return;
                foreach (gridColumnName item in Enum.GetValues(typeof(gridColumnName)))
                {
                    if (item.ToString() != summaryGrid.Columns[e.ColumnIndex].Name) continue;
                    myOnCellClick(item, (databases.baseDS.tradeAlertRow)((DataRowView)this.tradeAlertSource.Current).Row);
                    break;
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void summaryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex>=0 && summaryGrid.Columns[e.ColumnIndex] == toDetailBtn)
                    mainTab.SelectedTab = detailPg;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                myAlertFilterForm.ShowForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void mainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (mainTab.SelectedTab == summaryPg)
                    common.system.AutoFitGridColumn(summaryGrid, sumNameColumn.Name);
                else
                {
                    string stockcode = "";
                    if (alertSummarySource.Current != null)
                    {
                        stockcode = ((databases.baseDS.tradeAlertRow)(alertSummarySource.Current as DataRowView).Row).stockCode;
                    }
                    tradeAlertSource.Filter = myDataSet.tradeAlert.stockCodeColumn.ColumnName + "='" + stockcode + "'"; 
                    common.system.AutoFitGridColumn(detailGrid, strategyColumn.Name);
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion event handler
    }
}