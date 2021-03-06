namespace Trade.Forms
{
    partial class portfolioWatch
    {

        //common.libs.appAvailable myAvail = new common.libs.appAvailable();
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(portfolioWatch));
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectColumn = new AdvancedDataGridView.TreeGridColumn();
            this.actionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeColunm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portfolioWatchSource = new System.Windows.Forms.BindingSource(this.components);
            this.myTmpDS = new databases.tmpDS();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.portfolioListCb = new baseClass.controls.cbWatchList();
            this.myDataSet = new databases.baseDS();
            this.dataGV = new common.controls.baseDataGridView();
            this.refreshBtn = new baseClass.controls.baseButton();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boughtPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boughtAmtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profitVariantAmtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profitVariantPercColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceVariantColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioWatchSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1647, 105);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.TitleLbl.Size = new System.Drawing.Size(93, 64);
            this.TitleLbl.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "tickerCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "stockExchange";
            this.dataGridViewTextBoxColumn2.HeaderText = "Sàn ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "noOpenShares";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "SL niêm yết";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // subjectColumn
            // 
            this.subjectColumn.DefaultNodeImage = null;
            this.subjectColumn.FillWeight = 8F;
            this.subjectColumn.HeaderText = "Description";
            this.subjectColumn.Name = "subjectColumn";
            this.subjectColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.subjectColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // actionColumn
            // 
            this.actionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.actionColumn.FillWeight = 1F;
            this.actionColumn.HeaderText = "";
            this.actionColumn.Name = "actionColumn";
            this.actionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.actionColumn.Width = 50;
            // 
            // timeColunm
            // 
            this.timeColunm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.timeColunm.FillWeight = 1F;
            this.timeColunm.HeaderText = "Thời gian";
            this.timeColunm.Name = "timeColunm";
            this.timeColunm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.timeColunm.Width = 170;
            // 
            // idColumn
            // 
            this.idColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idColumn.FillWeight = 1F;
            this.idColumn.HeaderText = "id";
            this.idColumn.Name = "idColumn";
            this.idColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idColumn.Width = 50;
            // 
            // portfolioWatchSource
            // 
            this.portfolioWatchSource.AllowNew = false;
            this.portfolioWatchSource.DataMember = "porfolioWatch";
            this.portfolioWatchSource.DataSource = this.myTmpDS;
            // 
            // myTmpDS
            // 
            this.myTmpDS.DataSetName = "tmpDS";
            this.myTmpDS.EnforceConstraints = false;
            this.myTmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.xls";
            this.saveFileDialog.Filter = "(*.xls)|*.xls|All files (*.*)|*.*";
            // 
            // portfolioListCb
            // 
            this.portfolioListCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portfolioListCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioListCb.FormattingEnabled = true;
            this.portfolioListCb.Location = new System.Drawing.Point(0, 1);
            this.portfolioListCb.Margin = new System.Windows.Forms.Padding(4);
            this.portfolioListCb.myValue = "";
            this.portfolioListCb.Name = "portfolioListCb";
            this.portfolioListCb.Size = new System.Drawing.Size(356, 24);
            this.portfolioListCb.TabIndex = 1;
            this.portfolioListCb.SelectionChangeCommitted += new System.EventHandler(this.watchListCb_SelectionChangeCommitted);
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGV
            // 
            this.dataGV.AllowUserToAddRows = false;
            this.dataGV.AllowUserToDeleteRows = false;
            this.dataGV.AutoGenerateColumns = false;
            this.dataGV.ColumnHeadersHeight = 25;
            this.dataGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeColumn,
            this.marketColumn,
            this.nameColumn,
            this.qtyColumn,
            this.boughtPriceColumn,
            this.priceColumn,
            this.boughtAmtColumn,
            this.amtColumn,
            this.profitVariantAmtColumn,
            this.profitVariantPercColumn,
            this.priceVariantColumn});
            this.dataGV.DataSource = this.portfolioWatchSource;
            this.dataGV.Location = new System.Drawing.Point(0, 29);
            this.dataGV.Name = "dataGV";
            this.dataGV.ReadOnly = true;
            this.dataGV.RowTemplate.Height = 24;
            this.dataGV.Size = new System.Drawing.Size(1155, 140);
            this.dataGV.TabIndex = 10;
            this.dataGV.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGV_Scroll);
            this.dataGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGV_DataBindingComplete);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Image = global::Trade.Properties.Resources.refresh;
            this.refreshBtn.isDownState = false;
            this.refreshBtn.Location = new System.Drawing.Point(355, 1);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(4);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(24, 23);
            this.refreshBtn.TabIndex = 2;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "code";
            this.codeColumn.HeaderText = "Code";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            this.codeColumn.Width = 60;
            // 
            // marketColumn
            // 
            this.marketColumn.DataPropertyName = "stockExchange";
            this.marketColumn.HeaderText = "Market";
            this.marketColumn.Name = "marketColumn";
            this.marketColumn.ReadOnly = true;
            this.marketColumn.Width = 70;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "name";
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // qtyColumn
            // 
            this.qtyColumn.DataPropertyName = "qty";
            this.qtyColumn.HeaderText = "Qty";
            this.qtyColumn.Name = "qtyColumn";
            this.qtyColumn.ReadOnly = true;
            // 
            // boughtPriceColumn
            // 
            this.boughtPriceColumn.DataPropertyName = "boughtPrice";
            this.boughtPriceColumn.HeaderText = "Bought Price";
            this.boughtPriceColumn.Name = "boughtPriceColumn";
            this.boughtPriceColumn.ReadOnly = true;
            // 
            // priceColumn
            // 
            this.priceColumn.DataPropertyName = "price";
            this.priceColumn.HeaderText = "Current price";
            this.priceColumn.Name = "priceColumn";
            this.priceColumn.ReadOnly = true;
            // 
            // boughtAmtColumn
            // 
            this.boughtAmtColumn.DataPropertyName = "boughtAmt";
            this.boughtAmtColumn.HeaderText = "Bought Amt";
            this.boughtAmtColumn.Name = "boughtAmtColumn";
            this.boughtAmtColumn.ReadOnly = true;
            // 
            // amtColumn
            // 
            this.amtColumn.DataPropertyName = "amt";
            this.amtColumn.HeaderText = "Current Amt";
            this.amtColumn.Name = "amtColumn";
            this.amtColumn.ReadOnly = true;
            this.amtColumn.Width = 110;
            // 
            // profitVariantAmtColumn
            // 
            this.profitVariantAmtColumn.DataPropertyName = "profitVariantAmt";
            this.profitVariantAmtColumn.HeaderText = "Profit ";
            this.profitVariantAmtColumn.Name = "profitVariantAmtColumn";
            this.profitVariantAmtColumn.ReadOnly = true;
            this.profitVariantAmtColumn.Width = 110;
            // 
            // profitVariantPercColumn
            // 
            this.profitVariantPercColumn.DataPropertyName = "profitVariantPerc";
            this.profitVariantPercColumn.HeaderText = "%";
            this.profitVariantPercColumn.Name = "profitVariantPercColumn";
            this.profitVariantPercColumn.ReadOnly = true;
            this.profitVariantPercColumn.Width = 40;
            // 
            // priceVariantColumn
            // 
            this.priceVariantColumn.DataPropertyName = "priceVariant";
            this.priceVariantColumn.HeaderText = "+/-";
            this.priceVariantColumn.Name = "priceVariantColumn";
            this.priceVariantColumn.ReadOnly = true;
            this.priceVariantColumn.Width = 60;
            // 
            // portfolioWatch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1155, 321);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.portfolioListCb);
            this.Controls.Add(this.dataGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.MinimizeBox = false;
            this.Name = "portfolioWatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Portfolio Watch";
            this.Resize += new System.EventHandler(this.basePortfolioView_Resize);
            this.Controls.SetChildIndex(this.dataGV, 0);
            this.Controls.SetChildIndex(this.portfolioListCb, 0);
            this.Controls.SetChildIndex(this.refreshBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.portfolioWatchSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected databases.baseDS myDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private AdvancedDataGridView.TreeGridColumn subjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeColunm;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        protected databases.tmpDS myTmpDS;
        protected System.Windows.Forms.BindingSource portfolioWatchSource;
        protected baseClass.controls.cbWatchList portfolioListCb;
        protected baseClass.controls.baseButton refreshBtn;
        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected common.controls.baseDataGridView dataGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marketColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn boughtPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn boughtAmtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profitVariantAmtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profitVariantPercColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceVariantColumn;
    }
}