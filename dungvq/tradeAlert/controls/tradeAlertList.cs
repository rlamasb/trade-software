using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using application;

namespace tradeAlert.controls
{
    public partial class tradeAlertList : common.control.baseUserControl
    {
        public delegate void onCellClick(gridColumnName colName,data.baseDS.tradeAlertRow row);
        public event onCellClick myOnCellClick = null;
        public enum gridColumnName { OnTime, Subject, StockCode,Strategy,Status,View,Cancel };
        public tradeAlertList()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }

        private BindingSource _myDataSource = null;
        public BindingSource myDataSource
        {
            get { return _myDataSource;}
            set 
            {
                if (value == null) value = new BindingSource();
                _myDataSource = value;
                tradeAlertGrid.DataSource = value;
                SetDataGrid();
            }
        }
        
        private System.Windows.Forms.DataGridViewTextBoxColumn onTimeColumn = new DataGridViewTextBoxColumn();
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeColumn = new DataGridViewTextBoxColumn();
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectColumn = new DataGridViewTextBoxColumn();
        private System.Windows.Forms.DataGridViewTextBoxColumn strategyColumn = new DataGridViewTextBoxColumn();
        private System.Windows.Forms.DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
        private common.control.gridViewImageColumn cancelColumn = new common.control.gridViewImageColumn();
        private common.control.gridViewImageColumn viewColumn = new common.control.gridViewImageColumn();

        protected void SetDataGrid()
        {
            data.baseDS.tradeAlertDataTable tbl = new data.baseDS.tradeAlertDataTable();
            // 
            // onTimeColumn
            // 
            this.onTimeColumn.Name = gridColumnName.OnTime.ToString();
            this.onTimeColumn.DataPropertyName = tbl.onTimeColumn.ColumnName;
            this.onTimeColumn.HeaderText = "Thời gian";
            this.onTimeColumn.ReadOnly = true;
            this.onTimeColumn.Width = 130;

            // 
            // stockCodeColumn
            // 
            this.stockCodeColumn.Name = gridColumnName.StockCode.ToString();
            this.stockCodeColumn.DataPropertyName = tbl.stockCodeColumn.ColumnName;
            this.stockCodeColumn.HeaderText = "Mã CK";
            this.stockCodeColumn.ReadOnly = true;
            this.stockCodeColumn.Width = 80;
            // 
            // subjectColumn
            // 
            this.subjectColumn.Name = gridColumnName.Subject.ToString();
            this.subjectColumn.DataPropertyName = tbl.subjectColumn.ColumnName;
            this.subjectColumn.HeaderText = "Giao dịch";
            this.subjectColumn.ReadOnly = true;
            this.subjectColumn.Width = 100;
            
            // 
            // strategyColumn
            // 
            this.strategyColumn.Name = gridColumnName.Strategy.ToString();
            this.strategyColumn.DataPropertyName = tbl.strategyColumn.ColumnName;
            this.strategyColumn.HeaderText = "Chiến lược";
            this.strategyColumn.ReadOnly = true;
            this.strategyColumn.Width = 100;
            this.strategyColumn.Visible = false;
            // 
            // statusColumn
            // 
            this.statusColumn.Name = gridColumnName.Status.ToString();
            this.statusColumn.DataPropertyName = tbl.statusColumn.ColumnName;
            this.statusColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.statusColumn.HeaderText = "";
            this.statusColumn.ReadOnly = true;
            this.statusColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.statusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.statusColumn.Width = 50;
            // 
            // cancelColumn
            // 
            this.cancelColumn.Name = gridColumnName.Cancel.ToString();
            this.cancelColumn.HeaderText = "";
            this.cancelColumn.myValue = "";
            this.cancelColumn.ReadOnly = true;
            this.cancelColumn.Width = 25;
            this.cancelColumn.myImageType = common.control.imageType.Cancel;
            
            // 
            // viewColumn
            // 
            this.viewColumn.Name = gridColumnName.View.ToString();
            this.viewColumn.HeaderText = "";
            this.viewColumn.myValue = "";
            this.viewColumn.ReadOnly = true;
            this.viewColumn.Width = 25;
            this.viewColumn.myImageType = common.control.imageType.Edit;

            // 
            // dataGrid
            // 
            this.tradeAlertGrid.AutoGenerateColumns = false;
            this.tradeAlertGrid.DisableReadOnlyColumn = false;
            this.tradeAlertGrid.Columns.Clear();
            this.tradeAlertGrid.Columns.AddRange(new DataGridViewColumn[]
                {this.onTimeColumn,this.stockCodeColumn,this.subjectColumn,
                 this.strategyColumn,this.statusColumn,this.viewColumn,this.cancelColumn});
            //this.tradeAlertGrid.ReOrderColumn(new string[] 
            //        {gridColumnName.OnTime.ToString(),gridColumnName.StockCode.ToString(), 
            //         gridColumnName.Subject.ToString(),gridColumnName.Strategy.ToString(),
            //         gridColumnName.Status.ToString(), 
            //         gridColumnName.View.ToString(),gridColumnName.Cancel.ToString()
            //        });
            common.system.AutoFitGridColumn(tradeAlertGrid, subjectColumn.Name);
        }

        private void tradeAlertList_Resize(object sender, EventArgs e)
        {
            try
            {
                tradeAlertGrid.Size = this.Size;
                common.system.AutoFitGridColumn(tradeAlertGrid, subjectColumn.Name);
            }
            catch (Exception er)
            {
                this.ErrorHandler(sender,er);
            }
        }
        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.myDataSource == null || this.myDataSource.Current == null || e == null || myOnCellClick == null) return;
                foreach (gridColumnName item in Enum.GetValues(typeof(gridColumnName)))
                {
                    if (item.ToString() != tradeAlertGrid.Columns[e.ColumnIndex].Name) continue;
                    myOnCellClick(item, (data.baseDS.tradeAlertRow)((DataRowView)this.myDataSource.Current).Row);
                    break;
                }
            }
            catch (Exception er)
            {
                this.ErrorHandler(sender, er);
            }
        }
    }
}