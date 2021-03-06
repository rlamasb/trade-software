namespace stockTrade.forms
{
    partial class baseTradeAlertList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseTradeAlertList));
            this.myDataSet = new data.baseDS();
            this.tradeAlertSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolBarPnl = new common.control.basePanel();
            this.viewBtn = new common.control.baseButton();
            this.recoverBtn = new common.control.baseButton();
            this.refreshBtn = new common.control.baseButton();
            this.ignoreBtn = new common.control.baseButton();
            this.deleteBtn = new common.control.baseButton();
            this.showFilterBtn = new common.control.baseButton();
            this.commonStatusSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeScaleSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGrid = new common.control.baseDataGridView();
            this.onTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strategyColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.strategySource = new System.Windows.Forms.BindingSource(this.components);
            this.timeScaleColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.subjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.viewColumn = new common.control.gridViewImageColumn();
            this.cancelColumn = new common.control.gridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).BeginInit();
            this.toolBarPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonStatusSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeScaleSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strategySource)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1018, 76);
            this.TitleLbl.Size = new System.Drawing.Size(62, 46);
            this.TitleLbl.Visible = false;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tradeAlertSource
            // 
            this.tradeAlertSource.DataMember = "tradeAlert";
            this.tradeAlertSource.DataSource = this.myDataSet;
            // 
            // toolBarPnl
            // 
            this.toolBarPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolBarPnl.Controls.Add(this.viewBtn);
            this.toolBarPnl.Controls.Add(this.recoverBtn);
            this.toolBarPnl.Controls.Add(this.refreshBtn);
            this.toolBarPnl.Controls.Add(this.ignoreBtn);
            this.toolBarPnl.Controls.Add(this.deleteBtn);
            this.toolBarPnl.Controls.Add(this.showFilterBtn);
            this.toolBarPnl.haveCloseButton = false;
            this.toolBarPnl.haveShowHideButton = true;
            this.toolBarPnl.isExpanded = false;
            this.toolBarPnl.isVisible = false;
            this.toolBarPnl.Location = new System.Drawing.Point(2123, 609);
            this.toolBarPnl.mySizingOptions = common.control.basePanel.SizingOptions.None;
            this.toolBarPnl.myWeight = 0;
            this.toolBarPnl.Name = "toolBarPnl";
            this.toolBarPnl.Size = new System.Drawing.Size(17, 24);
            this.toolBarPnl.TabIndex = 151;
            this.toolBarPnl.myOnShowStateChanged += new common.control.basePanel.OnShowStateChanged(this.toolBarPnl_myOnShowStateChanged);
            // 
            // viewBtn
            // 
            this.viewBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBtn.Image = global::stockTrade.Properties.Resources.detail;
            this.viewBtn.isDownState = false;
            this.viewBtn.Location = new System.Drawing.Point(7, 1);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(23, 20);
            this.viewBtn.TabIndex = 5;
            this.viewBtn.UseVisualStyleBackColor = true;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // recoverBtn
            // 
            this.recoverBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoverBtn.Image = global::stockTrade.Properties.Resources.undo;
            this.recoverBtn.isDownState = false;
            this.recoverBtn.Location = new System.Drawing.Point(76, 1);
            this.recoverBtn.Name = "recoverBtn";
            this.recoverBtn.Size = new System.Drawing.Size(23, 20);
            this.recoverBtn.TabIndex = 20;
            this.recoverBtn.UseVisualStyleBackColor = true;
            this.recoverBtn.Click += new System.EventHandler(this.recoverBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Image = global::stockTrade.Properties.Resources.refresh;
            this.refreshBtn.isDownState = false;
            this.refreshBtn.Location = new System.Drawing.Point(99, 1);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(23, 20);
            this.refreshBtn.TabIndex = 35;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // ignoreBtn
            // 
            this.ignoreBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ignoreBtn.Image = global::stockTrade.Properties.Resources.pause;
            this.ignoreBtn.isDownState = false;
            this.ignoreBtn.Location = new System.Drawing.Point(53, 1);
            this.ignoreBtn.Name = "ignoreBtn";
            this.ignoreBtn.Size = new System.Drawing.Size(23, 20);
            this.ignoreBtn.TabIndex = 15;
            this.ignoreBtn.UseVisualStyleBackColor = true;
            this.ignoreBtn.Click += new System.EventHandler(this.ignoreBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Image = global::stockTrade.Properties.Resources.cancel;
            this.deleteBtn.isDownState = false;
            this.deleteBtn.Location = new System.Drawing.Point(30, 1);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(23, 20);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // showFilterBtn
            // 
            this.showFilterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showFilterBtn.Image = global::stockTrade.Properties.Resources.filter;
            this.showFilterBtn.isDownState = false;
            this.showFilterBtn.Location = new System.Drawing.Point(122, 1);
            this.showFilterBtn.Name = "showFilterBtn";
            this.showFilterBtn.Size = new System.Drawing.Size(23, 20);
            this.showFilterBtn.TabIndex = 40;
            this.showFilterBtn.UseVisualStyleBackColor = true;
            this.showFilterBtn.Click += new System.EventHandler(this.showFilterBtn_Click);
            // 
            // commonStatusSource
            // 
            this.commonStatusSource.DataSource = this.myDataSet;
            this.commonStatusSource.Position = 0;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.onTimeColumn,
            this.stockCodeColumn,
            this.strategyColumn,
            this.timeScaleColumn,
            this.subjectColumn,
            this.statusColumn,
            this.viewColumn,
            this.cancelColumn});
            this.dataGrid.DataSource = this.tradeAlertSource;
            this.dataGrid.DisableReadOnlyColumn = true;
            this.dataGrid.Location = new System.Drawing.Point(0, 26);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.Size = new System.Drawing.Size(703, 223);
            this.dataGrid.TabIndex = 153;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            this.dataGrid.Resize += new System.EventHandler(this.tradeAlertList_Resize);
            // 
            // onTimeColumn
            // 
            this.onTimeColumn.DataPropertyName = "onTime";
            this.onTimeColumn.HeaderText = "Thời gian";
            this.onTimeColumn.Name = "onTimeColumn";
            this.onTimeColumn.ReadOnly = true;
            this.onTimeColumn.Width = 140;
            // 
            // stockCodeColumn
            // 
            this.stockCodeColumn.DataPropertyName = "stockCode";
            this.stockCodeColumn.HeaderText = "Mã";
            this.stockCodeColumn.Name = "stockCodeColumn";
            this.stockCodeColumn.ReadOnly = true;
            this.stockCodeColumn.Width = 60;
            // 
            // strategyColumn
            // 
            this.strategyColumn.DataPropertyName = "strategy";
            this.strategyColumn.DataSource = this.strategySource;
            this.strategyColumn.DisplayMember = "description";
            this.strategyColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.strategyColumn.HeaderText = "Chiến lược";
            this.strategyColumn.Name = "strategyColumn";
            this.strategyColumn.ReadOnly = true;
            this.strategyColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.strategyColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.strategyColumn.ValueMember = "code";
            this.strategyColumn.Width = 120;
            // 
            // strategySource
            // 
            this.strategySource.DataMember = "strategy";
            this.strategySource.DataSource = this.myDataSet;
            // 
            // timeScaleColumn
            // 
            this.timeScaleColumn.DataPropertyName = "timeScale";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.timeScaleColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.timeScaleColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.timeScaleColumn.HeaderText = "Loại";
            this.timeScaleColumn.Name = "timeScaleColumn";
            this.timeScaleColumn.ReadOnly = true;
            this.timeScaleColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.timeScaleColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.timeScaleColumn.Width = 70;
            // 
            // subjectColumn
            // 
            this.subjectColumn.DataPropertyName = "subject";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.subjectColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.subjectColumn.HeaderText = "Q/Định";
            this.subjectColumn.Name = "subjectColumn";
            this.subjectColumn.ReadOnly = true;
            this.subjectColumn.Width = 55;
            // 
            // statusColumn
            // 
            this.statusColumn.DataPropertyName = "status";
            this.statusColumn.DataSource = this.commonStatusSource;
            this.statusColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.statusColumn.HeaderText = "";
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.ReadOnly = true;
            this.statusColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.statusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.statusColumn.Width = 50;
            // 
            // viewColumn
            // 
            this.viewColumn.HeaderText = "";
            this.viewColumn.myValue = "";
            this.viewColumn.Name = "viewColumn";
            this.viewColumn.ReadOnly = true;
            this.viewColumn.Width = 25;
            // 
            // cancelColumn
            // 
            this.cancelColumn.HeaderText = "";
            this.cancelColumn.myValue = "";
            this.cancelColumn.Name = "cancelColumn";
            this.cancelColumn.ReadOnly = true;
            this.cancelColumn.Width = 25;
            // 
            // baseTradeAlertList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 273);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.toolBarPnl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "baseTradeAlertList";
            this.Text = "Trade alerts";
            this.Resize += new System.EventHandler(this.tradeAlertList_Resize);
            this.Controls.SetChildIndex(this.toolBarPnl, 0);
            this.Controls.SetChildIndex(this.dataGrid, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).EndInit();
            this.toolBarPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commonStatusSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeScaleSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strategySource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected data.baseDS myDataSet;
        protected System.Windows.Forms.BindingSource tradeAlertSource;
        protected common.control.basePanel toolBarPnl;
        protected common.control.baseButton viewBtn;
        protected common.control.baseButton recoverBtn;
        protected common.control.baseButton refreshBtn;
        protected common.control.baseButton ignoreBtn;
        protected common.control.baseButton deleteBtn;
        protected common.control.baseButton showFilterBtn;
        protected System.Windows.Forms.BindingSource commonStatusSource;
        protected System.Windows.Forms.BindingSource timeScaleSource;
        protected common.control.baseDataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn onTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn strategyColumn;
        protected System.Windows.Forms.BindingSource strategySource;
        private System.Windows.Forms.DataGridViewComboBoxColumn timeScaleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn statusColumn;
        private common.control.gridViewImageColumn viewColumn;
        private common.control.gridViewImageColumn cancelColumn;

    }
}