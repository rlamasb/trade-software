namespace baseClass.forms
{
    partial class basePortfolioEdit
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(basePortfolioEdit));
            this.xpPane_generalInfo = new UIComponents.XPPanel(201);
            this.portfolioTypeLbl = new baseClass.controls.baseLabel();
            this.cbPortfolioType = new baseClass.controls.cbPortfolioType();
            this.portfolioSource = new System.Windows.Forms.BindingSource(this.components);
            this.descriptionEd = new common.control.baseTextBox();
            this.codeLbl = new baseClass.controls.baseLabel();
            this.nameLbl = new baseClass.controls.baseLabel();
            this.codeEd = new common.control.baseTextBox();
            this.nameEd = new common.control.baseTextBox();
            this.descriptionLbl = new baseClass.controls.baseLabel();
            this.stockPercLbl = new baseClass.controls.baseLabel();
            this.stockAccumulatePercEd = new common.control.numberTextBox();
            this.maxBuyAmtPercEd = new common.control.numberTextBox();
            this.usedAmtLbl = new baseClass.controls.baseLabel();
            this.maxBuyAmtPercLbl = new baseClass.controls.baseLabel();
            this.usedAmtEd = new common.control.numberTextBox();
            this.capitalAmtLbl = new baseClass.controls.baseLabel();
            this.stockAccumulatePercLbl = new baseClass.controls.baseLabel();
            this.capitalAmtEd = new common.control.numberTextBox();
            this.stockReducePercEd = new common.control.numberTextBox();
            this.cashAmtLbl = new baseClass.controls.baseLabel();
            this.stockReducePercLbl = new baseClass.controls.baseLabel();
            this.capitalUnitLbl = new baseClass.controls.baseLabel();
            this.cashAmtEd = new common.control.numberTextBox();
            this.interestedStockClb = new baseClass.controls.stockCodeList();
            this.interestedStrategy = new baseClass.controls.porfolioStrategy();
            this.interestedBizSectorClb = new baseClass.controls.subSectorList();
            this.interestedStockLbl = new baseClass.controls.baseLabel();
            this.interestedBizSectorLbl = new baseClass.controls.baseLabel();
            this.transOrderCriteria = new baseClass.controls.transHistoryCriteria();
            this.transHistGrid = new common.control.baseDataGridView();
            this.onTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.histTranTypeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tradeActionSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transHistorySource = new System.Windows.Forms.BindingSource(this.components);
            this.transHistBtn = new common.control.baseButton();
            this.stockGrid = new common.control.baseDataGridView();
            this.stockCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockNameColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.stockCodeSource = new System.Windows.Forms.BindingSource(this.components);
            this.qtyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.investorStockSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dataNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.dataNavigatorCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.xpPanelGroup_Info = new UIComponents.XPPanelGroup();
            this.xpPanel_transHistory = new UIComponents.XPPanel(278);
            this.xpPane_ownedStock = new UIComponents.XPPanel(237);
            this.xpPanel_options = new UIComponents.XPPanel(538);
            this.xpPanel_xxInvestment = new UIComponents.XPPanel(155);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            this.xpPane_generalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transHistGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeActionSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transHistorySource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorStockSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataNavigator)).BeginInit();
            this.dataNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).BeginInit();
            this.xpPanelGroup_Info.SuspendLayout();
            this.xpPanel_transHistory.SuspendLayout();
            this.xpPane_ownedStock.SuspendLayout();
            this.xpPanel_options.SuspendLayout();
            this.xpPanel_xxInvestment.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(-16, -7);
            this.toolBox.Size = new System.Drawing.Size(604, 53);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(501, 7);
            this.exitBtn.Size = new System.Drawing.Size(97, 39);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(113, 7);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.saveBtn.Size = new System.Drawing.Size(97, 39);
            this.saveBtn.TabIndex = 4;
            this.myToolTip.SetToolTip(this.saveBtn, "Lưu dữ liệu - [F2]");
            // 
            // deleteBtn
            // 
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Location = new System.Drawing.Point(210, 7);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.deleteBtn.Size = new System.Drawing.Size(97, 39);
            this.deleteBtn.TabIndex = 5;
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(307, 7);
            this.editBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.editBtn.Size = new System.Drawing.Size(97, 39);
            this.editBtn.TabIndex = 6;
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(16, 7);
            this.addNewBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.addNewBtn.Size = new System.Drawing.Size(97, 39);
            this.addNewBtn.TabIndex = 3;
            this.myToolTip.SetToolTip(this.addNewBtn, "Thêm dữ liệu mới - [F3]");
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(975, 3);
            this.toExcelBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toExcelBtn.Visible = false;
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(947, 4);
            this.findBtn.Visible = false;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(404, 7);
            this.reloadBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.reloadBtn.Size = new System.Drawing.Size(97, 39);
            this.reloadBtn.TabIndex = 7;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(1065, 4);
            this.printBtn.Visible = false;
            // 
            // unLockBtn
            // 
            this.unLockBtn.Location = new System.Drawing.Point(1227, 281);
            this.unLockBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.unLockBtn.Size = new System.Drawing.Size(34, 26);
            // 
            // lockBtn
            // 
            this.lockBtn.Location = new System.Drawing.Point(1208, 263);
            this.lockBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lockBtn.Size = new System.Drawing.Size(34, 26);
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(1120, 166);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TitleLbl.Size = new System.Drawing.Size(90, 24);
            this.TitleLbl.TabIndex = 149;
            // 
            // xpPane_generalInfo
            // 
            this.xpPane_generalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPane_generalInfo.AnimationRate = 0;
            this.xpPane_generalInfo.BackColor = System.Drawing.Color.Transparent;
            this.xpPane_generalInfo.Caption = "Thông tin chung";
            this.xpPane_generalInfo.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPane_generalInfo.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPane_generalInfo.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPane_generalInfo.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPane_generalInfo.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPane_generalInfo.Controls.Add(this.portfolioTypeLbl);
            this.xpPane_generalInfo.Controls.Add(this.cbPortfolioType);
            this.xpPane_generalInfo.Controls.Add(this.descriptionEd);
            this.xpPane_generalInfo.Controls.Add(this.codeLbl);
            this.xpPane_generalInfo.Controls.Add(this.nameLbl);
            this.xpPane_generalInfo.Controls.Add(this.codeEd);
            this.xpPane_generalInfo.Controls.Add(this.nameEd);
            this.xpPane_generalInfo.Controls.Add(this.descriptionLbl);
            this.xpPane_generalInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPane_generalInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPane_generalInfo.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPane_generalInfo.ImageItems.ImageSet = null;
            this.xpPane_generalInfo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.xpPane_generalInfo.Location = new System.Drawing.Point(0, 0);
            this.xpPane_generalInfo.Name = "xpPane_generalInfo";
            this.xpPane_generalInfo.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPane_generalInfo.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPane_generalInfo.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPane_generalInfo.Size = new System.Drawing.Size(568, 201);
            this.xpPane_generalInfo.TabIndex = 1;
            this.xpPane_generalInfo.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPane_generalInfo.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPane_generalInfo.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPane_generalInfo.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // portfolioTypeLbl
            // 
            this.portfolioTypeLbl.AutoSize = true;
            this.portfolioTypeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioTypeLbl.Location = new System.Drawing.Point(141, 37);
            this.portfolioTypeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portfolioTypeLbl.Name = "portfolioTypeLbl";
            this.portfolioTypeLbl.Size = new System.Drawing.Size(34, 16);
            this.portfolioTypeLbl.TabIndex = 366;
            this.portfolioTypeLbl.Text = "Loại";
            // 
            // cbPortfolioType
            // 
            this.cbPortfolioType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.portfolioSource, "type", true));
            this.cbPortfolioType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPortfolioType.FormattingEnabled = true;
            this.cbPortfolioType.Location = new System.Drawing.Point(138, 56);
            this.cbPortfolioType.myValue = application.myTypes.portfolioType.WatchList;
            this.cbPortfolioType.Name = "cbPortfolioType";
            this.cbPortfolioType.SelectedValue = ((byte)(1));
            this.cbPortfolioType.Size = new System.Drawing.Size(214, 24);
            this.cbPortfolioType.TabIndex = 2;
            this.cbPortfolioType.SelectionChangeCommitted += new System.EventHandler(this.cbPortfolioType_SelectionChangeCommitted);
            // 
            // portfolioSource
            // 
            this.portfolioSource.DataMember = "portfolio";
            this.portfolioSource.DataSource = this.myDataSet;
            this.portfolioSource.CurrentChanged += new System.EventHandler(this.portfolioSource_CurrentChanged);
            // 
            // descriptionEd
            // 
            this.descriptionEd.BackColor = System.Drawing.SystemColors.Window;
            this.descriptionEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "description", true));
            this.descriptionEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionEd.Location = new System.Drawing.Point(29, 154);
            this.descriptionEd.Multiline = true;
            this.descriptionEd.Name = "descriptionEd";
            this.descriptionEd.Size = new System.Drawing.Size(518, 41);
            this.descriptionEd.TabIndex = 3;
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(26, 37);
            this.codeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(46, 16);
            this.codeLbl.TabIndex = 364;
            this.codeLbl.Text = "Mã số";
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(28, 86);
            this.nameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(31, 16);
            this.nameLbl.TabIndex = 353;
            this.nameLbl.Text = "Tên";
            // 
            // codeEd
            // 
            this.codeEd.BackColor = System.Drawing.SystemColors.Window;
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "code", true));
            this.codeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEd.Location = new System.Drawing.Point(29, 56);
            this.codeEd.Name = "codeEd";
            this.codeEd.ReadOnly = true;
            this.codeEd.Size = new System.Drawing.Size(108, 24);
            this.codeEd.TabIndex = 1;
            this.codeEd.TabStop = false;
            // 
            // nameEd
            // 
            this.nameEd.BackColor = System.Drawing.SystemColors.Window;
            this.nameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "name", true));
            this.nameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameEd.Location = new System.Drawing.Point(29, 105);
            this.nameEd.Name = "nameEd";
            this.nameEd.Size = new System.Drawing.Size(518, 24);
            this.nameEd.TabIndex = 1;
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.Location = new System.Drawing.Point(29, 135);
            this.descriptionLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(45, 16);
            this.descriptionLbl.TabIndex = 351;
            this.descriptionLbl.Text = "Mô tả";
            // 
            // stockPercLbl
            // 
            this.stockPercLbl.AutoSize = true;
            this.stockPercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockPercLbl.Location = new System.Drawing.Point(349, 121);
            this.stockPercLbl.Name = "stockPercLbl";
            this.stockPercLbl.Size = new System.Drawing.Size(22, 16);
            this.stockPercLbl.TabIndex = 363;
            this.stockPercLbl.Text = "%";
            // 
            // stockAccumulatePercEd
            // 
            this.stockAccumulatePercEd.BackColor = System.Drawing.SystemColors.Window;
            this.stockAccumulatePercEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "stockAccumulatePerc", true));
            this.stockAccumulatePercEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockAccumulatePercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.stockAccumulatePercEd.Location = new System.Drawing.Point(132, 117);
            this.stockAccumulatePercEd.myFormat = "###";
            this.stockAccumulatePercEd.Name = "stockAccumulatePercEd";
            this.stockAccumulatePercEd.Size = new System.Drawing.Size(106, 24);
            this.stockAccumulatePercEd.TabIndex = 11;
            this.stockAccumulatePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stockAccumulatePercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.stockAccumulatePercEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // maxBuyAmtPercEd
            // 
            this.maxBuyAmtPercEd.BackColor = System.Drawing.SystemColors.Window;
            this.maxBuyAmtPercEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "maxBuyAmtPerc", true));
            this.maxBuyAmtPercEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxBuyAmtPercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.maxBuyAmtPercEd.Location = new System.Drawing.Point(26, 117);
            this.maxBuyAmtPercEd.myFormat = "###";
            this.maxBuyAmtPercEd.Name = "maxBuyAmtPercEd";
            this.maxBuyAmtPercEd.ReadOnly = true;
            this.maxBuyAmtPercEd.Size = new System.Drawing.Size(106, 24);
            this.maxBuyAmtPercEd.TabIndex = 10;
            this.maxBuyAmtPercEd.TabStop = false;
            this.maxBuyAmtPercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maxBuyAmtPercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.maxBuyAmtPercEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // usedAmtLbl
            // 
            this.usedAmtLbl.AutoSize = true;
            this.usedAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usedAmtLbl.Location = new System.Drawing.Point(189, 46);
            this.usedAmtLbl.Name = "usedAmtLbl";
            this.usedAmtLbl.Size = new System.Drawing.Size(82, 16);
            this.usedAmtLbl.TabIndex = 349;
            this.usedAmtLbl.Text = "Đã sử dụng";
            // 
            // maxBuyAmtPercLbl
            // 
            this.maxBuyAmtPercLbl.AutoSize = true;
            this.maxBuyAmtPercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxBuyAmtPercLbl.Location = new System.Drawing.Point(26, 96);
            this.maxBuyAmtPercLbl.Name = "maxBuyAmtPercLbl";
            this.maxBuyAmtPercLbl.Size = new System.Drawing.Size(103, 16);
            this.maxBuyAmtPercLbl.TabIndex = 362;
            this.maxBuyAmtPercLbl.Text = "G/T mua tối đa";
            // 
            // usedAmtEd
            // 
            this.usedAmtEd.BackColor = System.Drawing.SystemColors.Window;
            this.usedAmtEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "usedCapAmt", true));
            this.usedAmtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usedAmtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.usedAmtEd.Location = new System.Drawing.Point(189, 66);
            this.usedAmtEd.myFormat = "###,###,###,###,###";
            this.usedAmtEd.Name = "usedAmtEd";
            this.usedAmtEd.ReadOnly = true;
            this.usedAmtEd.Size = new System.Drawing.Size(163, 24);
            this.usedAmtEd.TabIndex = 2;
            this.usedAmtEd.TabStop = false;
            this.usedAmtEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.usedAmtEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.usedAmtEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // capitalAmtLbl
            // 
            this.capitalAmtLbl.AutoSize = true;
            this.capitalAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitalAmtLbl.Location = new System.Drawing.Point(26, 47);
            this.capitalAmtLbl.Name = "capitalAmtLbl";
            this.capitalAmtLbl.Size = new System.Drawing.Size(62, 16);
            this.capitalAmtLbl.TabIndex = 342;
            this.capitalAmtLbl.Text = "Tiền vốn";
            // 
            // stockAccumulatePercLbl
            // 
            this.stockAccumulatePercLbl.AutoSize = true;
            this.stockAccumulatePercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockAccumulatePercLbl.Location = new System.Drawing.Point(131, 95);
            this.stockAccumulatePercLbl.Name = "stockAccumulatePercLbl";
            this.stockAccumulatePercLbl.Size = new System.Drawing.Size(82, 16);
            this.stockAccumulatePercLbl.TabIndex = 360;
            this.stockAccumulatePercLbl.Text = "K/L tích lũy";
            // 
            // capitalAmtEd
            // 
            this.capitalAmtEd.BackColor = System.Drawing.SystemColors.Window;
            this.capitalAmtEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "startCapAmt", true));
            this.capitalAmtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitalAmtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.capitalAmtEd.Location = new System.Drawing.Point(26, 66);
            this.capitalAmtEd.myFormat = "###,###,###,###,###";
            this.capitalAmtEd.Name = "capitalAmtEd";
            this.capitalAmtEd.Size = new System.Drawing.Size(163, 24);
            this.capitalAmtEd.TabIndex = 1;
            this.capitalAmtEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.capitalAmtEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.capitalAmtEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.capitalAmtEd.Validating += new System.ComponentModel.CancelEventHandler(this.capitalAmtEd_Validating);
            // 
            // stockReducePercEd
            // 
            this.stockReducePercEd.BackColor = System.Drawing.SystemColors.Window;
            this.stockReducePercEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "stockReducePerc", true));
            this.stockReducePercEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockReducePercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.stockReducePercEd.Location = new System.Drawing.Point(238, 117);
            this.stockReducePercEd.myFormat = "###";
            this.stockReducePercEd.Name = "stockReducePercEd";
            this.stockReducePercEd.ReadOnly = true;
            this.stockReducePercEd.Size = new System.Drawing.Size(106, 24);
            this.stockReducePercEd.TabIndex = 12;
            this.stockReducePercEd.TabStop = false;
            this.stockReducePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stockReducePercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.stockReducePercEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // cashAmtLbl
            // 
            this.cashAmtLbl.AutoSize = true;
            this.cashAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashAmtLbl.Location = new System.Drawing.Point(348, 46);
            this.cashAmtLbl.Name = "cashAmtLbl";
            this.cashAmtLbl.Size = new System.Drawing.Size(63, 16);
            this.cashAmtLbl.TabIndex = 356;
            this.cashAmtLbl.Text = "Tiền mặt";
            // 
            // stockReducePercLbl
            // 
            this.stockReducePercLbl.AutoSize = true;
            this.stockReducePercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockReducePercLbl.Location = new System.Drawing.Point(240, 96);
            this.stockReducePercLbl.Name = "stockReducePercLbl";
            this.stockReducePercLbl.Size = new System.Drawing.Size(65, 16);
            this.stockReducePercLbl.TabIndex = 361;
            this.stockReducePercLbl.Text = "K/L giảm";
            // 
            // capitalUnitLbl
            // 
            this.capitalUnitLbl.AutoSize = true;
            this.capitalUnitLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitalUnitLbl.Location = new System.Drawing.Point(511, 68);
            this.capitalUnitLbl.Name = "capitalUnitLbl";
            this.capitalUnitLbl.Size = new System.Drawing.Size(36, 16);
            this.capitalUnitLbl.TabIndex = 343;
            this.capitalUnitLbl.Text = "????";
            // 
            // cashAmtEd
            // 
            this.cashAmtEd.BackColor = System.Drawing.SystemColors.Window;
            this.cashAmtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashAmtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.cashAmtEd.Location = new System.Drawing.Point(352, 66);
            this.cashAmtEd.myFormat = "###,###,###,###,###";
            this.cashAmtEd.Name = "cashAmtEd";
            this.cashAmtEd.ReadOnly = true;
            this.cashAmtEd.Size = new System.Drawing.Size(163, 24);
            this.cashAmtEd.TabIndex = 3;
            this.cashAmtEd.TabStop = false;
            this.cashAmtEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cashAmtEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.cashAmtEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // interestedStockClb
            // 
            this.interestedStockClb.DataBindings.Add(new System.Windows.Forms.Binding("myItemString", this.portfolioSource, "interestedStock", true));
            this.interestedStockClb.Enabled = false;
            this.interestedStockClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestedStockClb.Location = new System.Drawing.Point(29, 147);
            this.interestedStockClb.Margin = new System.Windows.Forms.Padding(2);
            this.interestedStockClb.myItemString = "";
            this.interestedStockClb.Name = "interestedStockClb";
            this.interestedStockClb.Size = new System.Drawing.Size(532, 68);
            this.interestedStockClb.TabIndex = 20;
            // 
            // interestedStrategy
            // 
            this.interestedStrategy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.interestedStrategy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestedStrategy.Location = new System.Drawing.Point(29, 217);
            this.interestedStrategy.Margin = new System.Windows.Forms.Padding(4);
            this.interestedStrategy.Name = "interestedStrategy";
            this.interestedStrategy.Size = new System.Drawing.Size(535, 319);
            this.interestedStrategy.TabIndex = 21;
            // 
            // interestedBizSectorClb
            // 
            this.interestedBizSectorClb.DataBindings.Add(new System.Windows.Forms.Binding("myItemString", this.portfolioSource, "interestedSector", true));
            this.interestedBizSectorClb.Enabled = false;
            this.interestedBizSectorClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestedBizSectorClb.Location = new System.Drawing.Point(29, 55);
            this.interestedBizSectorClb.Margin = new System.Windows.Forms.Padding(2);
            this.interestedBizSectorClb.myItemString = "";
            this.interestedBizSectorClb.Name = "interestedBizSectorClb";
            this.interestedBizSectorClb.Size = new System.Drawing.Size(535, 68);
            this.interestedBizSectorClb.TabIndex = 11;
            // 
            // interestedStockLbl
            // 
            this.interestedStockLbl.AutoSize = true;
            this.interestedStockLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestedStockLbl.Location = new System.Drawing.Point(29, 128);
            this.interestedStockLbl.Name = "interestedStockLbl";
            this.interestedStockLbl.Size = new System.Drawing.Size(128, 16);
            this.interestedStockLbl.TabIndex = 344;
            this.interestedStockLbl.Text = "Cổ phiếu quan tâm";
            // 
            // interestedBizSectorLbl
            // 
            this.interestedBizSectorLbl.AutoSize = true;
            this.interestedBizSectorLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestedBizSectorLbl.Location = new System.Drawing.Point(29, 37);
            this.interestedBizSectorLbl.Name = "interestedBizSectorLbl";
            this.interestedBizSectorLbl.Size = new System.Drawing.Size(132, 16);
            this.interestedBizSectorLbl.TabIndex = 345;
            this.interestedBizSectorLbl.Text = "Lãnh vực quan tâm";
            // 
            // transOrderCriteria
            // 
            this.transOrderCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transOrderCriteria.Location = new System.Drawing.Point(0, 35);
            this.transOrderCriteria.myPortfolio = "";
            this.transOrderCriteria.Name = "transOrderCriteria";
            this.transOrderCriteria.PortfolioChecked = false;
            this.transOrderCriteria.PortfolioEnabled = true;
            this.transOrderCriteria.Size = new System.Drawing.Size(483, 46);
            this.transOrderCriteria.TabIndex = 1;
            // 
            // transHistGrid
            // 
            this.transHistGrid.AllowUserToAddRows = false;
            this.transHistGrid.AllowUserToDeleteRows = false;
            this.transHistGrid.AutoGenerateColumns = false;
            this.transHistGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transHistGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.onTimeDataGridViewTextBoxColumn,
            this.histTranTypeColumn,
            this.stockCodeDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.amtDataGridViewTextBoxColumn});
            this.transHistGrid.DataSource = this.transHistorySource;
            this.transHistGrid.Location = new System.Drawing.Point(-1, 86);
            this.transHistGrid.Name = "transHistGrid";
            this.transHistGrid.ReadOnly = true;
            this.transHistGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transHistGrid.Size = new System.Drawing.Size(588, 190);
            this.transHistGrid.TabIndex = 20;
            // 
            // onTimeDataGridViewTextBoxColumn
            // 
            this.onTimeDataGridViewTextBoxColumn.DataPropertyName = "onTime";
            this.onTimeDataGridViewTextBoxColumn.HeaderText = "Ngày/Giờ";
            this.onTimeDataGridViewTextBoxColumn.Name = "onTimeDataGridViewTextBoxColumn";
            this.onTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.onTimeDataGridViewTextBoxColumn.Width = 160;
            // 
            // histTranTypeColumn
            // 
            this.histTranTypeColumn.DataPropertyName = "tranType";
            this.histTranTypeColumn.DataSource = this.tradeActionSource;
            this.histTranTypeColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.histTranTypeColumn.HeaderText = "";
            this.histTranTypeColumn.Name = "histTranTypeColumn";
            this.histTranTypeColumn.ReadOnly = true;
            this.histTranTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.histTranTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.histTranTypeColumn.Width = 70;
            // 
            // stockCodeDataGridViewTextBoxColumn
            // 
            this.stockCodeDataGridViewTextBoxColumn.DataPropertyName = "stockCode";
            this.stockCodeDataGridViewTextBoxColumn.HeaderText = "Mã";
            this.stockCodeDataGridViewTextBoxColumn.Name = "stockCodeDataGridViewTextBoxColumn";
            this.stockCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockCodeDataGridViewTextBoxColumn.Width = 75;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "qty";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "KL";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amtDataGridViewTextBoxColumn
            // 
            this.amtDataGridViewTextBoxColumn.DataPropertyName = "amt";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.amtDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.amtDataGridViewTextBoxColumn.HeaderText = "Giá trị";
            this.amtDataGridViewTextBoxColumn.Name = "amtDataGridViewTextBoxColumn";
            this.amtDataGridViewTextBoxColumn.ReadOnly = true;
            this.amtDataGridViewTextBoxColumn.Width = 120;
            // 
            // transHistorySource
            // 
            this.transHistorySource.DataMember = "investorTransHistory";
            this.transHistorySource.DataSource = this.myDataSet;
            // 
            // transHistBtn
            // 
            this.transHistBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transHistBtn.Image = global::baseClass.Properties.Resources.refresh;
            this.transHistBtn.isDownState = false;
            this.transHistBtn.Location = new System.Drawing.Point(484, 58);
            this.transHistBtn.Name = "transHistBtn";
            this.transHistBtn.Size = new System.Drawing.Size(25, 23);
            this.transHistBtn.TabIndex = 10;
            this.transHistBtn.UseVisualStyleBackColor = true;
            this.transHistBtn.Click += new System.EventHandler(this.transHistBtn_Click);
            // 
            // stockGrid
            // 
            this.stockGrid.AllowUserToAddRows = false;
            this.stockGrid.AllowUserToDeleteRows = false;
            this.stockGrid.AutoGenerateColumns = false;
            this.stockGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stockCodeColumn,
            this.stockNameColumn,
            this.qtyColumn});
            this.stockGrid.DataSource = this.investorStockSource;
            this.stockGrid.Location = new System.Drawing.Point(2, 34);
            this.stockGrid.Name = "stockGrid";
            this.stockGrid.ReadOnly = true;
            this.stockGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockGrid.Size = new System.Drawing.Size(586, 201);
            this.stockGrid.TabIndex = 40;
            this.stockGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // stockCodeColumn
            // 
            this.stockCodeColumn.DataPropertyName = "stockCode";
            this.stockCodeColumn.HeaderText = "Mã";
            this.stockCodeColumn.Name = "stockCodeColumn";
            this.stockCodeColumn.ReadOnly = true;
            this.stockCodeColumn.Width = 80;
            // 
            // stockNameColumn
            // 
            this.stockNameColumn.DataPropertyName = "stockCode";
            this.stockNameColumn.DataSource = this.stockCodeSource;
            this.stockNameColumn.DisplayMember = "name";
            this.stockNameColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.stockNameColumn.HeaderText = "Tên";
            this.stockNameColumn.Name = "stockNameColumn";
            this.stockNameColumn.ReadOnly = true;
            this.stockNameColumn.ValueMember = "code";
            this.stockNameColumn.Width = 215;
            // 
            // stockCodeSource
            // 
            this.stockCodeSource.DataMember = "stockCode";
            this.stockCodeSource.DataSource = this.myDataSet;
            // 
            // qtyColumn
            // 
            this.qtyColumn.DataPropertyName = "qty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.qtyColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.qtyColumn.HeaderText = "Khối lượng";
            this.qtyColumn.Name = "qtyColumn";
            this.qtyColumn.ReadOnly = true;
            // 
            // investorStockSource
            // 
            this.investorStockSource.DataMember = "investorStock";
            this.investorStockSource.DataSource = this.myDataSet;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Enabled = false;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(30, 22);
            this.bindingNavigatorCountItem.Text = "/ 0";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Enabled = false;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Enabled = false;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Enabled = false;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Enabled = false;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Enabled = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(160, 15);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // dataNavigator
            // 
            this.dataNavigator.AddNewItem = null;
            this.dataNavigator.BackColor = System.Drawing.SystemColors.Control;
            this.dataNavigator.BindingSource = this.portfolioSource;
            this.dataNavigator.CountItem = this.dataNavigatorCount;
            this.dataNavigator.CountItemFormat = "{0}";
            this.dataNavigator.DeleteItem = null;
            this.dataNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.dataNavigatorCount,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5});
            this.dataNavigator.Location = new System.Drawing.Point(0, 681);
            this.dataNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.dataNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.dataNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.dataNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.dataNavigator.Name = "dataNavigator";
            this.dataNavigator.PositionItem = this.bindingNavigatorPositionItem1;
            this.dataNavigator.Size = new System.Drawing.Size(584, 25);
            this.dataNavigator.TabIndex = 358;
            this.dataNavigator.Text = "bindingNavigator1";
            // 
            // dataNavigatorCount
            // 
            this.dataNavigatorCount.Name = "dataNavigatorCount";
            this.dataNavigatorCount.Size = new System.Drawing.Size(23, 22);
            this.dataNavigatorCount.Text = "{0}";
            this.dataNavigatorCount.ToolTipText = "Total number of items";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(170, 22);
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem1.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem1.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem1.Text = "Move last";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // xpPanelGroup_Info
            // 
            this.xpPanelGroup_Info.AutoScroll = true;
            this.xpPanelGroup_Info.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelGroup_Info.BorderMargin = new System.Drawing.Size(0, 0);
            this.xpPanelGroup_Info.Controls.Add(this.xpPanel_transHistory);
            this.xpPanelGroup_Info.Controls.Add(this.xpPane_ownedStock);
            this.xpPanelGroup_Info.Controls.Add(this.xpPanel_options);
            this.xpPanelGroup_Info.Controls.Add(this.xpPanel_xxInvestment);
            this.xpPanelGroup_Info.Controls.Add(this.xpPane_generalInfo);
            this.xpPanelGroup_Info.Location = new System.Drawing.Point(0, 48);
            this.xpPanelGroup_Info.Name = "xpPanelGroup_Info";
            this.xpPanelGroup_Info.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpPanelGroup_Info.PanelGradient")));
            this.xpPanelGroup_Info.PanelSpacing = 2;
            this.xpPanelGroup_Info.Size = new System.Drawing.Size(585, 634);
            this.xpPanelGroup_Info.TabIndex = 359;
            // 
            // xpPanel_transHistory
            // 
            this.xpPanel_transHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_transHistory.AnimationRate = 0;
            this.xpPanel_transHistory.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_transHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.xpPanel_transHistory.Caption = "Lịch sử giao dịch";
            this.xpPanel_transHistory.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_transHistory.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_transHistory.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_transHistory.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_transHistory.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_transHistory.Controls.Add(this.transOrderCriteria);
            this.xpPanel_transHistory.Controls.Add(this.transHistGrid);
            this.xpPanel_transHistory.Controls.Add(this.transHistBtn);
            this.xpPanel_transHistory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_transHistory.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_transHistory.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_transHistory.ImageItems.ImageSet = null;
            this.xpPanel_transHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.xpPanel_transHistory.Location = new System.Drawing.Point(0, 935);
            this.xpPanel_transHistory.Name = "xpPanel_transHistory";
            this.xpPanel_transHistory.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_transHistory.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_transHistory.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_transHistory.PanelState = UIComponents.XPPanelState.Collapsed;
            this.xpPanel_transHistory.Size = new System.Drawing.Size(568, 33);
            this.xpPanel_transHistory.TabIndex = 5;
            this.xpPanel_transHistory.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_transHistory.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_transHistory.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_transHistory.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // xpPane_ownedStock
            // 
            this.xpPane_ownedStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPane_ownedStock.AnimationRate = 0;
            this.xpPane_ownedStock.BackColor = System.Drawing.Color.Transparent;
            this.xpPane_ownedStock.Caption = "Cổ phiếu sở hữu";
            this.xpPane_ownedStock.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPane_ownedStock.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPane_ownedStock.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPane_ownedStock.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPane_ownedStock.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPane_ownedStock.Controls.Add(this.stockGrid);
            this.xpPane_ownedStock.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPane_ownedStock.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPane_ownedStock.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPane_ownedStock.ImageItems.ImageSet = null;
            this.xpPane_ownedStock.ImeMode = System.Windows.Forms.ImeMode.On;
            this.xpPane_ownedStock.Location = new System.Drawing.Point(0, 900);
            this.xpPane_ownedStock.Name = "xpPane_ownedStock";
            this.xpPane_ownedStock.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPane_ownedStock.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPane_ownedStock.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPane_ownedStock.PanelState = UIComponents.XPPanelState.Collapsed;
            this.xpPane_ownedStock.Size = new System.Drawing.Size(568, 33);
            this.xpPane_ownedStock.TabIndex = 4;
            this.xpPane_ownedStock.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPane_ownedStock.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPane_ownedStock.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPane_ownedStock.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // xpPanel_options
            // 
            this.xpPanel_options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_options.AnimationRate = 0;
            this.xpPanel_options.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_options.Caption = "Thông số";
            this.xpPanel_options.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_options.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_options.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_options.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_options.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_options.Controls.Add(this.interestedStockClb);
            this.xpPanel_options.Controls.Add(this.interestedStrategy);
            this.xpPanel_options.Controls.Add(this.interestedBizSectorLbl);
            this.xpPanel_options.Controls.Add(this.interestedBizSectorClb);
            this.xpPanel_options.Controls.Add(this.interestedStockLbl);
            this.xpPanel_options.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_options.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_options.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_options.ImageItems.ImageSet = null;
            this.xpPanel_options.ImeMode = System.Windows.Forms.ImeMode.On;
            this.xpPanel_options.Location = new System.Drawing.Point(0, 360);
            this.xpPanel_options.Name = "xpPanel_options";
            this.xpPanel_options.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_options.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_options.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_options.Size = new System.Drawing.Size(568, 538);
            this.xpPanel_options.TabIndex = 3;
            this.xpPanel_options.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_options.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_options.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_options.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // xpPanel_xxInvestment
            // 
            this.xpPanel_xxInvestment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_xxInvestment.AnimationRate = 0;
            this.xpPanel_xxInvestment.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_xxInvestment.Caption = "Đầu tư";
            this.xpPanel_xxInvestment.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_xxInvestment.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_xxInvestment.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_xxInvestment.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_xxInvestment.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_xxInvestment.Controls.Add(this.capitalUnitLbl);
            this.xpPanel_xxInvestment.Controls.Add(this.stockPercLbl);
            this.xpPanel_xxInvestment.Controls.Add(this.capitalAmtLbl);
            this.xpPanel_xxInvestment.Controls.Add(this.stockAccumulatePercEd);
            this.xpPanel_xxInvestment.Controls.Add(this.cashAmtEd);
            this.xpPanel_xxInvestment.Controls.Add(this.maxBuyAmtPercEd);
            this.xpPanel_xxInvestment.Controls.Add(this.stockReducePercLbl);
            this.xpPanel_xxInvestment.Controls.Add(this.usedAmtLbl);
            this.xpPanel_xxInvestment.Controls.Add(this.cashAmtLbl);
            this.xpPanel_xxInvestment.Controls.Add(this.maxBuyAmtPercLbl);
            this.xpPanel_xxInvestment.Controls.Add(this.stockReducePercEd);
            this.xpPanel_xxInvestment.Controls.Add(this.usedAmtEd);
            this.xpPanel_xxInvestment.Controls.Add(this.capitalAmtEd);
            this.xpPanel_xxInvestment.Controls.Add(this.stockAccumulatePercLbl);
            this.xpPanel_xxInvestment.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_xxInvestment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_xxInvestment.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_xxInvestment.ImageItems.ImageSet = null;
            this.xpPanel_xxInvestment.Location = new System.Drawing.Point(0, 203);
            this.xpPanel_xxInvestment.Name = "xpPanel_xxInvestment";
            this.xpPanel_xxInvestment.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_xxInvestment.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_xxInvestment.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_xxInvestment.Size = new System.Drawing.Size(568, 155);
            this.xpPanel_xxInvestment.TabIndex = 2;
            this.xpPanel_xxInvestment.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_xxInvestment.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_xxInvestment.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_xxInvestment.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // basePortfolioEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 729);
            this.Controls.Add(this.xpPanelGroup_Info);
            this.Controls.Add(this.dataNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "basePortfolioEdit";
            this.Text = "Portfolio";
            this.Controls.SetChildIndex(this.dataNavigator, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.xpPanelGroup_Info, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            this.xpPane_generalInfo.ResumeLayout(false);
            this.xpPane_generalInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transHistGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeActionSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transHistorySource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorStockSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataNavigator)).EndInit();
            this.dataNavigator.ResumeLayout(false);
            this.dataNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).EndInit();
            this.xpPanelGroup_Info.ResumeLayout(false);
            this.xpPanel_transHistory.ResumeLayout(false);
            this.xpPane_ownedStock.ResumeLayout(false);
            this.xpPanel_options.ResumeLayout(false);
            this.xpPanel_options.PerformLayout();
            this.xpPanel_xxInvestment.ResumeLayout(false);
            this.xpPanel_xxInvestment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseLabel usedAmtLbl;
        protected common.control.numberTextBox usedAmtEd;
        protected common.control.baseDataGridView stockGrid;
        protected baseClass.controls.subSectorList interestedBizSectorClb;
        protected baseClass.controls.baseLabel interestedBizSectorLbl;
        protected baseClass.controls.baseLabel interestedStockLbl;
        protected baseClass.controls.baseLabel capitalUnitLbl;
        protected baseClass.controls.stockCodeList interestedStockClb;
        protected baseClass.controls.baseLabel capitalAmtLbl;
        protected common.control.numberTextBox capitalAmtEd;
        protected System.Windows.Forms.BindingSource investorStockSource;
        protected System.Windows.Forms.BindingSource stockCodeSource;
        protected System.Windows.Forms.BindingSource portfolioSource;
        protected baseClass.controls.baseLabel descriptionLbl;
        protected common.control.baseTextBox descriptionEd;
        protected common.control.baseTextBox codeEd;
        protected baseClass.controls.baseLabel nameLbl;
        protected common.control.baseTextBox nameEd;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected baseClass.controls.baseLabel cashAmtLbl;
        protected common.control.numberTextBox cashAmtEd;
        protected baseClass.controls.porfolioStrategy interestedStrategy;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn stockNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyColumn;
        protected common.control.baseDataGridView transHistGrid;
        protected System.Windows.Forms.BindingSource transHistorySource;
        protected common.control.baseButton transHistBtn;
        protected System.Windows.Forms.BindingNavigator dataNavigator;
        protected System.Windows.Forms.ToolStripLabel dataNavigatorCount;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        protected System.Windows.Forms.BindingSource tradeActionSource;
        protected baseClass.controls.transHistoryCriteria transOrderCriteria;
        protected baseClass.controls.baseLabel codeLbl;
        protected common.control.numberTextBox maxBuyAmtPercEd;
        protected baseClass.controls.baseLabel maxBuyAmtPercLbl;
        protected common.control.numberTextBox stockAccumulatePercEd;
        protected baseClass.controls.baseLabel stockAccumulatePercLbl;
        protected common.control.numberTextBox stockReducePercEd;
        protected baseClass.controls.baseLabel stockReducePercLbl;
        protected baseClass.controls.baseLabel stockPercLbl;
        protected UIComponents.XPPanel xpPane_generalInfo;
        protected UIComponents.XPPanelGroup xpPanelGroup_Info;
        protected UIComponents.XPPanel xpPanel_xxInvestment;
        protected UIComponents.XPPanel xpPanel_options;
        protected UIComponents.XPPanel xpPanel_transHistory;
        protected UIComponents.XPPanel xpPane_ownedStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn onTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn histTranTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amtDataGridViewTextBoxColumn;
        protected baseClass.controls.baseLabel portfolioTypeLbl;
        protected baseClass.controls.cbPortfolioType cbPortfolioType;
    }
}