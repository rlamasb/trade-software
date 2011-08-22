﻿namespace baseClass.forms
{
    partial class companyList
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(companyList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid = new common.control.baseDataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.findPnl = new System.Windows.Forms.Panel();
            this.filterBtn = new baseClass.controls.baseButton();
            this.closeFindBtn = new baseClass.controls.baseButton();
            this.findCriteria = new baseClass.controls.companyCriteria();
            ((System.ComponentModel.ISupportInitialize)(this.companySource)).BeginInit();
            this.xpPanel_GeneralInfo.SuspendLayout();
            this.xpPanel_StockInfo.SuspendLayout();
            this.xpPanel_OtherInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).BeginInit();
            this.xpPanelGroup_Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.findPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpPanel_GeneralInfo
            // 
            this.xpPanel_GeneralInfo.ImageItems.ImageSet = null;
            this.xpPanel_GeneralInfo.Size = new System.Drawing.Size(483, 375);
            // 
            // xpPanel_StockInfo
            // 
            this.xpPanel_StockInfo.ImageItems.ImageSet = null;
            this.xpPanel_StockInfo.Location = new System.Drawing.Point(0, 375);
            this.xpPanel_StockInfo.Size = new System.Drawing.Size(483, 279);
            // 
            // xpPanel_OtherInfo
            // 
            this.xpPanel_OtherInfo.ImageItems.ImageSet = null;
            this.xpPanel_OtherInfo.Location = new System.Drawing.Point(0, 654);
            this.xpPanel_OtherInfo.Size = new System.Drawing.Size(483, 33);
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(-2, -2);
            this.toolBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toolBox.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toolBox.Size = new System.Drawing.Size(554, 48);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(428, 3);
            this.exitBtn.Size = new System.Drawing.Size(71, 38);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(73, 3);
            this.saveBtn.Size = new System.Drawing.Size(71, 38);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(144, 3);
            this.deleteBtn.Size = new System.Drawing.Size(71, 38);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(286, 3);
            this.editBtn.Size = new System.Drawing.Size(71, 38);
            this.editBtn.Text = "&Khóa";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(2, 3);
            this.addNewBtn.Size = new System.Drawing.Size(71, 38);
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(786, 7);
            this.toExcelBtn.Size = new System.Drawing.Size(58, 38);
            this.toExcelBtn.Visible = false;
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(215, 3);
            this.findBtn.Size = new System.Drawing.Size(71, 38);
            this.findBtn.Visible = true;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Enabled = true;
            this.reloadBtn.Location = new System.Drawing.Point(357, 3);
            this.reloadBtn.Size = new System.Drawing.Size(71, 38);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(844, 7);
            this.printBtn.Size = new System.Drawing.Size(58, 38);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1285, 150);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            // 
            // dataGrid
            // 
            this.dataGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.NavajoWhite;
            this.dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGrid.DataSource = this.companySource;
            this.dataGrid.DisableReadOnlyColumn = true;
            this.dataGrid.Location = new System.Drawing.Point(501, -2);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(461, 681);
            this.dataGrid.TabIndex = 231;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Mã số";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Tên";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 300;
            // 
            // findPnl
            // 
            this.findPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.findPnl.Controls.Add(this.filterBtn);
            this.findPnl.Controls.Add(this.closeFindBtn);
            this.findPnl.Controls.Add(this.findCriteria);
            this.findPnl.Location = new System.Drawing.Point(500, 479);
            this.findPnl.Name = "findPnl";
            this.findPnl.Size = new System.Drawing.Size(464, 154);
            this.findPnl.TabIndex = 239;
            this.findPnl.Visible = false;
            // 
            // filterBtn
            // 
            this.filterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtn.Image = global::baseClass.Properties.Resources.filter;
            this.filterBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.filterBtn.Location = new System.Drawing.Point(264, 108);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(80, 38);
            this.filterBtn.TabIndex = 10;
            this.filterBtn.Text = "Lọc";
            this.filterBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // closeFindBtn
            // 
            this.closeFindBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeFindBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeFindBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeFindBtn.Location = new System.Drawing.Point(344, 108);
            this.closeFindBtn.Name = "closeFindBtn";
            this.closeFindBtn.Size = new System.Drawing.Size(80, 38);
            this.closeFindBtn.TabIndex = 11;
            this.closeFindBtn.Text = "Đóng";
            this.closeFindBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeFindBtn.UseVisualStyleBackColor = true;
            this.closeFindBtn.Click += new System.EventHandler(this.closeFindBtn_Click);
            // 
            // findCriteria
            // 
            this.findCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findCriteria.Location = new System.Drawing.Point(34, 5);
            this.findCriteria.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.findCriteria.Name = "findCriteria";
            this.findCriteria.Size = new System.Drawing.Size(391, 100);
            this.findCriteria.TabIndex = 1;
            // 
            // companyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(962, 703);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.findPnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "companyList";
            this.Controls.SetChildIndex(this.xpPanelGroup_Info, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.findPnl, 0);
            this.Controls.SetChildIndex(this.dataGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.companySource)).EndInit();
            this.xpPanel_GeneralInfo.ResumeLayout(false);
            this.xpPanel_StockInfo.ResumeLayout(false);
            this.xpPanel_OtherInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).EndInit();
            this.xpPanelGroup_Info.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.findPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseButton closeFindBtn;
        protected baseClass.controls.baseButton filterBtn;
        protected controls.companyCriteria findCriteria;
        protected System.Windows.Forms.Panel findPnl;
        protected common.control.baseDataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}