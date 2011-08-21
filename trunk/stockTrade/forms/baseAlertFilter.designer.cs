namespace stockTrade.forms
{
    partial class baseAlertFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseAlertFilter));
            this.stockChk = new common.control.baseCheckBox();
            this.stockCodeEd = new baseClass.controls.txtStockCode();
            this.strategyChk = new common.control.baseCheckBox();
            this.strategyCb = new baseClass.controls.cbStrategy();
            this.portfolioChk = new common.control.baseCheckBox();
            this.portfolioCb = new baseClass.controls.cbPorpolio();
            this.statusChk = new common.control.baseCheckBox();
            this.dateRangeChk = new common.control.baseCheckBox();
            this.statusCb = new baseClass.controls.cbTradeAlertStatus();
            this.dateRange = new common.control.dateRange2();
            this.dummyLabel = new common.control.baseLabel();
            this.timeScaleCb = new baseClass.controls.cbTimeScale();
            this.timeScaleChk = new common.control.baseCheckBox();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeBtn.Location = new System.Drawing.Point(485, 64);
            this.closeBtn.Size = new System.Drawing.Size(90, 39);
            this.closeBtn.TabIndex = 102;
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // okBtn
            // 
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.okBtn.Location = new System.Drawing.Point(485, 24);
            this.okBtn.Size = new System.Drawing.Size(90, 40);
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(635, 163);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TitleLbl.Size = new System.Drawing.Size(89, 20);
            this.TitleLbl.TabIndex = 149;
            this.TitleLbl.Visible = false;
            // 
            // stockChk
            // 
            this.stockChk.AutoSize = true;
            this.stockChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockChk.Location = new System.Drawing.Point(376, 3);
            this.stockChk.Name = "stockChk";
            this.stockChk.Size = new System.Drawing.Size(66, 20);
            this.stockChk.TabIndex = 5;
            this.stockChk.Text = "Mã CP";
            this.stockChk.UseVisualStyleBackColor = true;
            this.stockChk.CheckedChanged += new System.EventHandler(this.stockChk_CheckedChanged);
            // 
            // stockCodeEd
            // 
            this.stockCodeEd.BackColor = System.Drawing.Color.White;
            this.stockCodeEd.Enabled = false;
            this.stockCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeEd.ForeColor = System.Drawing.Color.Black;
            this.stockCodeEd.Location = new System.Drawing.Point(373, 25);
            this.stockCodeEd.Name = "stockCodeEd";
            this.stockCodeEd.Size = new System.Drawing.Size(94, 24);
            this.stockCodeEd.TabIndex = 6;
            // 
            // strategyChk
            // 
            this.strategyChk.AutoSize = true;
            this.strategyChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyChk.Location = new System.Drawing.Point(37, 52);
            this.strategyChk.Name = "strategyChk";
            this.strategyChk.Size = new System.Drawing.Size(93, 20);
            this.strategyChk.TabIndex = 12;
            this.strategyChk.Text = "Chiến lược";
            this.strategyChk.UseVisualStyleBackColor = true;
            this.strategyChk.CheckedChanged += new System.EventHandler(this.strategyChk_CheckedChanged);
            // 
            // strategyCb
            // 
            this.strategyCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.strategyCb.Enabled = false;
            this.strategyCb.FormattingEnabled = true;
            this.strategyCb.Location = new System.Drawing.Point(38, 74);
            this.strategyCb.myValue = "";
            this.strategyCb.Name = "strategyCb";
            this.strategyCb.Size = new System.Drawing.Size(240, 26);
            this.strategyCb.TabIndex = 13;
            // 
            // portfolioChk
            // 
            this.portfolioChk.AutoSize = true;
            this.portfolioChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioChk.Location = new System.Drawing.Point(203, 3);
            this.portfolioChk.Name = "portfolioChk";
            this.portfolioChk.Size = new System.Drawing.Size(82, 20);
            this.portfolioChk.TabIndex = 3;
            this.portfolioChk.Text = "Portfolio";
            this.portfolioChk.UseVisualStyleBackColor = true;
            this.portfolioChk.CheckedChanged += new System.EventHandler(this.portfolioChk_CheckedChanged);
            // 
            // portfolioCb
            // 
            this.portfolioCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portfolioCb.Enabled = false;
            this.portfolioCb.FormattingEnabled = true;
            this.portfolioCb.Location = new System.Drawing.Point(200, 25);
            this.portfolioCb.myValue = "";
            this.portfolioCb.Name = "portfolioCb";
            this.portfolioCb.Size = new System.Drawing.Size(175, 26);
            this.portfolioCb.TabIndex = 4;
            // 
            // statusChk
            // 
            this.statusChk.AutoSize = true;
            this.statusChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusChk.Location = new System.Drawing.Point(374, 52);
            this.statusChk.Name = "statusChk";
            this.statusChk.Size = new System.Drawing.Size(93, 20);
            this.statusChk.TabIndex = 10;
            this.statusChk.Text = "Trạng thái";
            this.statusChk.UseVisualStyleBackColor = true;
            this.statusChk.CheckedChanged += new System.EventHandler(this.statusChk_CheckedChanged);
            // 
            // dateRangeChk
            // 
            this.dateRangeChk.AutoSize = true;
            this.dateRangeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRangeChk.Location = new System.Drawing.Point(39, 3);
            this.dateRangeChk.Name = "dateRangeChk";
            this.dateRangeChk.Size = new System.Drawing.Size(84, 20);
            this.dateRangeChk.TabIndex = 1;
            this.dateRangeChk.Text = "Thời gian";
            this.dateRangeChk.UseVisualStyleBackColor = true;
            this.dateRangeChk.CheckedChanged += new System.EventHandler(this.dateRangeChk_CheckedChanged);
            // 
            // statusCb
            // 
            this.statusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCb.Enabled = false;
            this.statusCb.FormattingEnabled = true;
            this.statusCb.Location = new System.Drawing.Point(373, 74);
            this.statusCb.myValue = application.myTypes.commonStatus.None;
            this.statusCb.Name = "statusCb";
            this.statusCb.SelectedValue = ((byte)(0));
            this.statusCb.Size = new System.Drawing.Size(94, 26);
            this.statusCb.TabIndex = 11;
            // 
            // dateRange
            // 
            this.dateRange.Enabled = false;
            this.dateRange.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRange.frDate = new System.DateTime(((long)(0)));
            this.dateRange.Location = new System.Drawing.Point(37, 4);
            this.dateRange.Margin = new System.Windows.Forms.Padding(4);
            this.dateRange.Name = "dateRange";
            this.dateRange.Size = new System.Drawing.Size(162, 46);
            this.dateRange.TabIndex = 2;
            this.dateRange.toDate = new System.DateTime(((long)(0)));
            // 
            // dummyLabel
            // 
            this.dummyLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dummyLabel.Location = new System.Drawing.Point(38, 0);
            this.dummyLabel.Name = "dummyLabel";
            this.dummyLabel.Size = new System.Drawing.Size(149, 23);
            this.dummyLabel.TabIndex = 161;
            // 
            // timeScaleCb
            // 
            this.timeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeScaleCb.Enabled = false;
            this.timeScaleCb.FormattingEnabled = true;
            this.timeScaleCb.Location = new System.Drawing.Point(276, 74);
            this.timeScaleCb.myValue = application.myTypes.timeScales.RealTime;
            this.timeScaleCb.Name = "timeScaleCb";
            this.timeScaleCb.SelectedValue = ((byte)(0));
            this.timeScaleCb.Size = new System.Drawing.Size(99, 26);
            this.timeScaleCb.TabIndex = 15;
            // 
            // timeScaleChk
            // 
            this.timeScaleChk.AutoSize = true;
            this.timeScaleChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeScaleChk.Location = new System.Drawing.Point(279, 51);
            this.timeScaleChk.Name = "timeScaleChk";
            this.timeScaleChk.Size = new System.Drawing.Size(53, 20);
            this.timeScaleChk.TabIndex = 14;
            this.timeScaleChk.Text = "Lọai";
            this.timeScaleChk.UseVisualStyleBackColor = true;
            this.timeScaleChk.CheckedChanged += new System.EventHandler(this.timeScaleChk_CheckedChanged);
            // 
            // baseAlertFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 141);
            this.Controls.Add(this.timeScaleChk);
            this.Controls.Add(this.timeScaleCb);
            this.Controls.Add(this.stockChk);
            this.Controls.Add(this.stockCodeEd);
            this.Controls.Add(this.strategyChk);
            this.Controls.Add(this.strategyCb);
            this.Controls.Add(this.portfolioChk);
            this.Controls.Add(this.portfolioCb);
            this.Controls.Add(this.statusChk);
            this.Controls.Add(this.dateRangeChk);
            this.Controls.Add(this.statusCb);
            this.Controls.Add(this.dummyLabel);
            this.Controls.Add(this.dateRange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "baseAlertFilter";
            this.Text = "Loc du lieu";
            this.Controls.SetChildIndex(this.dateRange, 0);
            this.Controls.SetChildIndex(this.dummyLabel, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.statusCb, 0);
            this.Controls.SetChildIndex(this.dateRangeChk, 0);
            this.Controls.SetChildIndex(this.statusChk, 0);
            this.Controls.SetChildIndex(this.portfolioCb, 0);
            this.Controls.SetChildIndex(this.portfolioChk, 0);
            this.Controls.SetChildIndex(this.strategyCb, 0);
            this.Controls.SetChildIndex(this.strategyChk, 0);
            this.Controls.SetChildIndex(this.stockCodeEd, 0);
            this.Controls.SetChildIndex(this.stockChk, 0);
            this.Controls.SetChildIndex(this.timeScaleCb, 0);
            this.Controls.SetChildIndex(this.timeScaleChk, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseCheckBox stockChk;
        protected baseClass.controls.txtStockCode stockCodeEd;
        protected common.control.baseCheckBox strategyChk;
        protected baseClass.controls.cbStrategy strategyCb;
        protected common.control.baseCheckBox portfolioChk;
        protected baseClass.controls.cbPorpolio portfolioCb;
        protected common.control.baseCheckBox statusChk;
        protected common.control.baseCheckBox dateRangeChk;
        protected baseClass.controls.cbTradeAlertStatus statusCb;
        protected common.control.baseLabel dummyLabel;
        protected common.control.dateRange2 dateRange;
        private baseClass.controls.cbTimeScale timeScaleCb;
        protected common.control.baseCheckBox timeScaleChk;


    }
}