﻿namespace baseClass.controls
{
    partial class stockCodeSelect
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stockCodeSelect));
            this.selectCodeEd = new common.control.baseTextBox();
            this.optionPnl = new System.Windows.Forms.Panel();
            this.selectCodeBtn = new baseClass.controls.baseButton();
            this.showOnlyCheckedChk = new baseClass.controls.baseCheckBox();
            this.selectAllChk = new baseClass.controls.baseCheckBox();
            this.stockCodeClb = new baseClass.controls.clbStockCode();
            this.bizSectorTypeSelection = new baseClass.controls.bizSectorTypeSelection();
            this.optionPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectCodeEd
            // 
            this.selectCodeEd.BackColor = System.Drawing.Color.White;
            this.selectCodeEd.ForeColor = System.Drawing.Color.Black;
            this.selectCodeEd.Location = new System.Drawing.Point(224, 1);
            this.selectCodeEd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectCodeEd.Name = "selectCodeEd";
            this.selectCodeEd.Size = new System.Drawing.Size(133, 23);
            this.selectCodeEd.TabIndex = 3;
            this.selectCodeEd.Validated += new System.EventHandler(this.selectCodeEd_Validated);
            // 
            // optionPnl
            // 
            this.optionPnl.Controls.Add(this.selectCodeBtn);
            this.optionPnl.Controls.Add(this.showOnlyCheckedChk);
            this.optionPnl.Controls.Add(this.selectCodeEd);
            this.optionPnl.Controls.Add(this.selectAllChk);
            this.optionPnl.Location = new System.Drawing.Point(0, 211);
            this.optionPnl.Name = "optionPnl";
            this.optionPnl.Size = new System.Drawing.Size(539, 27);
            this.optionPnl.TabIndex = 8;
            this.optionPnl.Resize += new System.EventHandler(this.optionPnl_Resize);
            // 
            // selectCodeBtn
            // 
            this.selectCodeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCodeBtn.Image = global::baseClass.Properties.Resources.adddata;
            this.selectCodeBtn.Location = new System.Drawing.Point(359, 2);
            this.selectCodeBtn.Name = "selectCodeBtn";
            this.selectCodeBtn.Size = new System.Drawing.Size(24, 23);
            this.selectCodeBtn.TabIndex = 4;
            this.selectCodeBtn.UseVisualStyleBackColor = true;
            this.selectCodeBtn.Click += new System.EventHandler(this.selectCodeBtn_Click);
            // 
            // showOnlyCheckedChk
            // 
            this.showOnlyCheckedChk.AutoSize = true;
            this.showOnlyCheckedChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showOnlyCheckedChk.Location = new System.Drawing.Point(3, 3);
            this.showOnlyCheckedChk.Name = "showOnlyCheckedChk";
            this.showOnlyCheckedChk.Size = new System.Drawing.Size(108, 20);
            this.showOnlyCheckedChk.TabIndex = 1;
            this.showOnlyCheckedChk.Text = "Các mã chọn";
            this.showOnlyCheckedChk.UseVisualStyleBackColor = true;
            this.showOnlyCheckedChk.CheckedChanged += new System.EventHandler(this.showOnlyCheckedChk_CheckedChanged);
            // 
            // selectAllChk
            // 
            this.selectAllChk.AutoSize = true;
            this.selectAllChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllChk.Location = new System.Drawing.Point(120, 3);
            this.selectAllChk.Name = "selectAllChk";
            this.selectAllChk.Size = new System.Drawing.Size(102, 20);
            this.selectAllChk.TabIndex = 2;
            this.selectAllChk.Text = "Chọn tất cả";
            this.selectAllChk.UseVisualStyleBackColor = true;
            this.selectAllChk.CheckedChanged += new System.EventHandler(this.selectAllChk_CheckedChanged);
            // 
            // stockCodeClb
            // 
            this.stockCodeClb.CheckOnClick = true;
            this.stockCodeClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeClb.FormattingEnabled = true;
            this.stockCodeClb.Location = new System.Drawing.Point(-1, 27);
            this.stockCodeClb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("stockCodeClb.myCheckedItems")));
            this.stockCodeClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeClb.myCheckedValues")));
            this.stockCodeClb.myDataTbl = null;
            this.stockCodeClb.myItemString = "";
            this.stockCodeClb.myItemValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeClb.myItemValues")));
            this.stockCodeClb.Name = "stockCodeClb";
            this.stockCodeClb.ShowCheckedOnly = false;
            this.stockCodeClb.Size = new System.Drawing.Size(540, 184);
            this.stockCodeClb.TabIndex = 2;
            // 
            // bizSectorTypeSelection
            // 
            this.bizSectorTypeSelection.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bizSectorTypeSelection.Location = new System.Drawing.Point(0, 0);
            this.bizSectorTypeSelection.Margin = new System.Windows.Forms.Padding(2);
            this.bizSectorTypeSelection.myBizSectorCode = "";
            this.bizSectorTypeSelection.myBizSectorType = application.myTypes.bizSectorType.None;
            this.bizSectorTypeSelection.Name = "bizSectorTypeSelection";
            this.bizSectorTypeSelection.Size = new System.Drawing.Size(539, 24);
            this.bizSectorTypeSelection.TabIndex = 1;
            this.bizSectorTypeSelection.mySectorSelectionChange += new baseClass.controls.bizSectorTypeSelection.SectorSelectionChange(this.bizSectorTypeSelection_mySectorSelectionChange);
            // 
            // stockCodeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.optionPnl);
            this.Controls.Add(this.stockCodeClb);
            this.Controls.Add(this.bizSectorTypeSelection);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "stockCodeSelect";
            this.Size = new System.Drawing.Size(539, 242);
            this.Resize += new System.EventHandler(this.form_Resize);
            this.optionPnl.ResumeLayout(false);
            this.optionPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected bizSectorTypeSelection bizSectorTypeSelection;
        protected clbStockCode stockCodeClb;
        protected baseCheckBox selectAllChk;
        private baseCheckBox showOnlyCheckedChk;
        protected common.control.baseTextBox selectCodeEd;
        protected System.Windows.Forms.Panel optionPnl;
        protected baseButton selectCodeBtn;
    }
}