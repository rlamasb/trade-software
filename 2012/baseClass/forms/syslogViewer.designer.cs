namespace baseClass.forms
{
    partial class syslogViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(syslogViewer));
            this.dateRange = new common.controls.dateRange0();
            this.okBtn = new common.controls.baseButton();
            this.exitBtn = new common.controls.baseButton();
            this.syslogGrid = new System.Windows.Forms.DataGridView();
            this.syslogSource = new System.Windows.Forms.BindingSource(this.components);
            this.myBaseDS = new databases.baseDS();
            this.myTempDS = new databases.tmpDS();
            this.sourceChk = new common.controls.baseCheckBox();
            this.descChk = new common.controls.baseCheckBox();
            this.descEd = new common.controls.baseTextBox();
            this.optionPnl = new System.Windows.Forms.Panel();
            this.accountEd = new baseClass.controls.txtInvestor();
            this.logTypeCb = new baseClass.controls.cbSyslogTypes();
            this.messageChk = new common.controls.baseCheckBox();
            this.messageEd = new common.controls.baseTextBox();
            this.sourceEd = new common.controls.baseTextBox();
            this.accountChk = new common.controls.baseCheckBox();
            this.logTypeChk = new common.controls.baseCheckBox();
            this.infoPnl = new System.Windows.Forms.Panel();
            this.typeCb = new baseClass.controls.cbSyslogTypes();
            this.investorLbl = new common.controls.baseLabel();
            this.investorCb = new baseClass.controls.cbInvestor();
            this.dateTimeEd = new common.controls.baseDateTime();
            this.onDateLbl = new common.controls.baseLabel();
            this.typeLbl = new common.controls.baseLabel();
            this.infoEd = new common.controls.baseTextBox();
            this.infoLbl = new common.controls.baseLabel();
            this.baseTextBox1 = new common.controls.baseTextBox();
            this.sourceLbl = new common.controls.baseLabel();
            this.descLbl = new common.controls.baseLabel();
            this.desc1Ed = new common.controls.baseTextBox();
            this.codeLbl = new common.controls.baseLabel();
            this.codeEd = new common.controls.baseTextBox();
            this.onDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.syslogGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.syslogSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTempDS)).BeginInit();
            this.optionPnl.SuspendLayout();
            this.infoPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(884, 2);
            this.TitleLbl.Size = new System.Drawing.Size(10, 27);
            this.TitleLbl.Text = "NHẬT KÝ HỆ THỐNG";
            this.TitleLbl.Visible = false;
            // 
            // dateRange
            // 
            this.dateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRange.Location = new System.Drawing.Point(23, 5);
            this.dateRange.Margin = new System.Windows.Forms.Padding(4);
            this.dateRange.Name = "dateRange";
            this.dateRange.Size = new System.Drawing.Size(394, 50);
            this.dateRange.TabIndex = 1;
            // 
            // okBtn
            // 
            this.okBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Image = global::baseClass.Properties.Resources.report;
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.okBtn.isDownState = false;
            this.okBtn.Location = new System.Drawing.Point(428, 27);
            this.okBtn.Name = "okBtn";
            this.okBtn.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.okBtn.Size = new System.Drawing.Size(76, 44);
            this.okBtn.TabIndex = 30;
            this.okBtn.Text = "&Xem";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Image = global::baseClass.Properties.Resources.close;
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.exitBtn.isDownState = false;
            this.exitBtn.Location = new System.Drawing.Point(428, 81);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.exitBtn.Size = new System.Drawing.Size(76, 44);
            this.exitBtn.TabIndex = 31;
            this.exitBtn.Text = "Th&oát";
            this.exitBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // syslogGrid
            // 
            this.syslogGrid.AllowUserToAddRows = false;
            this.syslogGrid.AllowUserToDeleteRows = false;
            this.syslogGrid.AutoGenerateColumns = false;
            this.syslogGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.syslogGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.onDateColumn,
            this.descriptionColumn});
            this.syslogGrid.DataSource = this.syslogSource;
            this.syslogGrid.Location = new System.Drawing.Point(4, 161);
            this.syslogGrid.Name = "syslogGrid";
            this.syslogGrid.ReadOnly = true;
            this.syslogGrid.RowHeadersWidth = 40;
            this.syslogGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.syslogGrid.Size = new System.Drawing.Size(519, 354);
            this.syslogGrid.TabIndex = 1;
            this.syslogGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.syslogGrid_RowEnter);
            this.syslogGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.syslogGrid_DataError);
            // 
            // syslogSource
            // 
            this.syslogSource.DataMember = "sysLog";
            this.syslogSource.DataSource = this.myBaseDS;
            // 
            // myBaseDS
            // 
            this.myBaseDS.DataSetName = "baseDS";
            this.myBaseDS.EnforceConstraints = false;
            this.myBaseDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // myTempDS
            // 
            this.myTempDS.DataSetName = "tempDS";
            this.myTempDS.EnforceConstraints = false;
            this.myTempDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sourceChk
            // 
            this.sourceChk.AutoSize = true;
            this.sourceChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceChk.Location = new System.Drawing.Point(22, 105);
            this.sourceChk.Name = "sourceChk";
            this.sourceChk.Size = new System.Drawing.Size(67, 20);
            this.sourceChk.TabIndex = 12;
            this.sourceChk.Text = "Nguồn";
            this.sourceChk.UseVisualStyleBackColor = true;
            this.sourceChk.CheckedChanged += new System.EventHandler(this.sourceChk_CheckedChanged);
            // 
            // descChk
            // 
            this.descChk.AutoSize = true;
            this.descChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descChk.Location = new System.Drawing.Point(130, 105);
            this.descChk.Name = "descChk";
            this.descChk.Size = new System.Drawing.Size(64, 20);
            this.descChk.TabIndex = 14;
            this.descChk.Text = "Mô tả";
            this.descChk.UseVisualStyleBackColor = true;
            this.descChk.CheckedChanged += new System.EventHandler(this.descChk_CheckedChanged);
            // 
            // descEd
            // 
            this.descEd.Enabled = false;
            this.descEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descEd.isRequired = true;
            this.descEd.isToUpperCase = false;
            this.descEd.Location = new System.Drawing.Point(130, 127);
            this.descEd.Name = "descEd";
            this.descEd.Size = new System.Drawing.Size(144, 24);
            this.descEd.TabIndex = 15;
            // 
            // optionPnl
            // 
            this.optionPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.optionPnl.Controls.Add(this.accountEd);
            this.optionPnl.Controls.Add(this.logTypeCb);
            this.optionPnl.Controls.Add(this.messageChk);
            this.optionPnl.Controls.Add(this.messageEd);
            this.optionPnl.Controls.Add(this.sourceEd);
            this.optionPnl.Controls.Add(this.accountChk);
            this.optionPnl.Controls.Add(this.logTypeChk);
            this.optionPnl.Controls.Add(this.dateRange);
            this.optionPnl.Controls.Add(this.descChk);
            this.optionPnl.Controls.Add(this.okBtn);
            this.optionPnl.Controls.Add(this.descEd);
            this.optionPnl.Controls.Add(this.exitBtn);
            this.optionPnl.Controls.Add(this.sourceChk);
            this.optionPnl.Location = new System.Drawing.Point(0, 1);
            this.optionPnl.Name = "optionPnl";
            this.optionPnl.Size = new System.Drawing.Size(524, 160);
            this.optionPnl.TabIndex = 1;
            // 
            // accountEd
            // 
            this.accountEd.Enabled = false;
            this.accountEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountEd.isRequired = true;
            this.accountEd.isToUpperCase = true;
            this.accountEd.Location = new System.Drawing.Point(226, 77);
            this.accountEd.MaxLength = 20;
            this.accountEd.Name = "accountEd";
            this.accountEd.Size = new System.Drawing.Size(188, 24);
            this.accountEd.TabIndex = 5;
            // 
            // logTypeCb
            // 
            this.logTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logTypeCb.Enabled = false;
            this.logTypeCb.FormattingEnabled = true;
            this.logTypeCb.Location = new System.Drawing.Point(22, 77);
            this.logTypeCb.myValue = commonTypes.AppTypes.SyslogTypes.Others;
            this.logTypeCb.Name = "logTypeCb";
            this.logTypeCb.SelectedValue = ((byte)(255));
            this.logTypeCb.Size = new System.Drawing.Size(206, 24);
            this.logTypeCb.TabIndex = 3;
            // 
            // messageChk
            // 
            this.messageChk.AutoSize = true;
            this.messageChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageChk.Location = new System.Drawing.Point(274, 105);
            this.messageChk.Name = "messageChk";
            this.messageChk.Size = new System.Drawing.Size(105, 20);
            this.messageChk.TabIndex = 16;
            this.messageChk.Text = "Thông tin lỗi";
            this.messageChk.UseVisualStyleBackColor = true;
            this.messageChk.CheckedChanged += new System.EventHandler(this.messageChk_CheckedChanged);
            // 
            // messageEd
            // 
            this.messageEd.Enabled = false;
            this.messageEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageEd.isRequired = true;
            this.messageEd.isToUpperCase = false;
            this.messageEd.Location = new System.Drawing.Point(274, 127);
            this.messageEd.Name = "messageEd";
            this.messageEd.Size = new System.Drawing.Size(142, 24);
            this.messageEd.TabIndex = 17;
            // 
            // sourceEd
            // 
            this.sourceEd.Enabled = false;
            this.sourceEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceEd.isRequired = true;
            this.sourceEd.isToUpperCase = false;
            this.sourceEd.Location = new System.Drawing.Point(21, 127);
            this.sourceEd.Name = "sourceEd";
            this.sourceEd.Size = new System.Drawing.Size(109, 24);
            this.sourceEd.TabIndex = 13;
            // 
            // accountChk
            // 
            this.accountChk.AutoSize = true;
            this.accountChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountChk.Location = new System.Drawing.Point(224, 57);
            this.accountChk.Name = "accountChk";
            this.accountChk.Size = new System.Drawing.Size(88, 20);
            this.accountChk.TabIndex = 4;
            this.accountChk.Text = "Tài khỏan";
            this.accountChk.UseVisualStyleBackColor = true;
            this.accountChk.CheckedChanged += new System.EventHandler(this.accountChk_CheckedChanged);
            // 
            // logTypeChk
            // 
            this.logTypeChk.AutoSize = true;
            this.logTypeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTypeChk.Location = new System.Drawing.Point(24, 56);
            this.logTypeChk.Name = "logTypeChk";
            this.logTypeChk.Size = new System.Drawing.Size(53, 20);
            this.logTypeChk.TabIndex = 2;
            this.logTypeChk.Text = "Loại";
            this.logTypeChk.UseVisualStyleBackColor = true;
            this.logTypeChk.CheckedChanged += new System.EventHandler(this.logTypeChk_CheckedChanged);
            // 
            // infoPnl
            // 
            this.infoPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.infoPnl.Controls.Add(this.typeCb);
            this.infoPnl.Controls.Add(this.investorLbl);
            this.infoPnl.Controls.Add(this.investorCb);
            this.infoPnl.Controls.Add(this.dateTimeEd);
            this.infoPnl.Controls.Add(this.onDateLbl);
            this.infoPnl.Controls.Add(this.typeLbl);
            this.infoPnl.Controls.Add(this.infoEd);
            this.infoPnl.Controls.Add(this.infoLbl);
            this.infoPnl.Controls.Add(this.baseTextBox1);
            this.infoPnl.Controls.Add(this.sourceLbl);
            this.infoPnl.Controls.Add(this.descLbl);
            this.infoPnl.Controls.Add(this.desc1Ed);
            this.infoPnl.Controls.Add(this.codeLbl);
            this.infoPnl.Controls.Add(this.codeEd);
            this.infoPnl.Location = new System.Drawing.Point(525, 1);
            this.infoPnl.Name = "infoPnl";
            this.infoPnl.Size = new System.Drawing.Size(416, 515);
            this.infoPnl.TabIndex = 10;
            // 
            // typeCb
            // 
            this.typeCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.syslogSource, "type", true));
            this.typeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.typeCb.Enabled = false;
            this.typeCb.FormattingEnabled = true;
            this.typeCb.Location = new System.Drawing.Point(21, 70);
            this.typeCb.myValue = commonTypes.AppTypes.SyslogTypes.Others;
            this.typeCb.Name = "typeCb";
            this.typeCb.SelectedValue = ((byte)(255));
            this.typeCb.Size = new System.Drawing.Size(206, 26);
            this.typeCb.TabIndex = 2;
            // 
            // investorLbl
            // 
            this.investorLbl.AutoSize = true;
            this.investorLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.investorLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.investorLbl.Location = new System.Drawing.Point(20, 157);
            this.investorLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.investorLbl.Name = "investorLbl";
            this.investorLbl.Size = new System.Drawing.Size(79, 16);
            this.investorLbl.TabIndex = 265;
            this.investorLbl.Text = "Nhà đầu tư";
            // 
            // investorCb
            // 
            this.investorCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.syslogSource, "investorCode", true));
            this.investorCb.DisplayMember = "code";
            this.investorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.investorCb.Enabled = false;
            this.investorCb.FormattingEnabled = true;
            this.investorCb.Location = new System.Drawing.Point(20, 176);
            this.investorCb.myValue = "";
            this.investorCb.Name = "investorCb";
            this.investorCb.Size = new System.Drawing.Size(374, 24);
            this.investorCb.TabIndex = 4;
            this.investorCb.ValueMember = "code";
            // 
            // dateTimeEd
            // 
            this.dateTimeEd.DataBindings.Add(new System.Windows.Forms.Binding("myValue", this.syslogSource, "onDate", true));
            this.dateTimeEd.Enabled = false;
            this.dateTimeEd.Location = new System.Drawing.Point(20, 124);
            this.dateTimeEd.myValue = new System.DateTime(((long)(0)));
            this.dateTimeEd.Name = "dateTimeEd";
            this.dateTimeEd.Size = new System.Drawing.Size(146, 25);
            this.dateTimeEd.TabIndex = 3;
            // 
            // onDateLbl
            // 
            this.onDateLbl.AutoSize = true;
            this.onDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.onDateLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.onDateLbl.Location = new System.Drawing.Point(20, 104);
            this.onDateLbl.Name = "onDateLbl";
            this.onDateLbl.Size = new System.Drawing.Size(67, 16);
            this.onDateLbl.TabIndex = 262;
            this.onDateLbl.Text = "Ngày/Giờ";
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.typeLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.typeLbl.Location = new System.Drawing.Point(20, 52);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(34, 16);
            this.typeLbl.TabIndex = 257;
            this.typeLbl.Text = "Loại";
            // 
            // infoEd
            // 
            this.infoEd.BackColor = System.Drawing.SystemColors.Window;
            this.infoEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.syslogSource, "message", true));
            this.infoEd.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.infoEd.isRequired = true;
            this.infoEd.isToUpperCase = false;
            this.infoEd.Location = new System.Drawing.Point(20, 333);
            this.infoEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.infoEd.Multiline = true;
            this.infoEd.Name = "infoEd";
            this.infoEd.ReadOnly = true;
            this.infoEd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infoEd.Size = new System.Drawing.Size(374, 170);
            this.infoEd.TabIndex = 7;
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.infoLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoLbl.Location = new System.Drawing.Point(20, 313);
            this.infoLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(86, 16);
            this.infoLbl.TabIndex = 261;
            this.infoLbl.Text = "Thông tin lỗi";
            // 
            // baseTextBox1
            // 
            this.baseTextBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.baseTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.syslogSource, "description", true));
            this.baseTextBox1.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.baseTextBox1.ForeColor = System.Drawing.Color.Black;
            this.baseTextBox1.isRequired = true;
            this.baseTextBox1.isToUpperCase = false;
            this.baseTextBox1.Location = new System.Drawing.Point(20, 283);
            this.baseTextBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.baseTextBox1.Name = "baseTextBox1";
            this.baseTextBox1.ReadOnly = true;
            this.baseTextBox1.Size = new System.Drawing.Size(374, 26);
            this.baseTextBox1.TabIndex = 6;
            // 
            // sourceLbl
            // 
            this.sourceLbl.AutoSize = true;
            this.sourceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.sourceLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.sourceLbl.Location = new System.Drawing.Point(20, 210);
            this.sourceLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sourceLbl.Name = "sourceLbl";
            this.sourceLbl.Size = new System.Drawing.Size(48, 16);
            this.sourceLbl.TabIndex = 259;
            this.sourceLbl.Text = "Nguồn";
            // 
            // descLbl
            // 
            this.descLbl.AutoSize = true;
            this.descLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.descLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.descLbl.Location = new System.Drawing.Point(20, 264);
            this.descLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.descLbl.Name = "descLbl";
            this.descLbl.Size = new System.Drawing.Size(45, 16);
            this.descLbl.TabIndex = 260;
            this.descLbl.Text = "Mô tả";
            // 
            // desc1Ed
            // 
            this.desc1Ed.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.desc1Ed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.syslogSource, "source", true));
            this.desc1Ed.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.desc1Ed.ForeColor = System.Drawing.Color.Black;
            this.desc1Ed.isRequired = true;
            this.desc1Ed.isToUpperCase = false;
            this.desc1Ed.Location = new System.Drawing.Point(20, 229);
            this.desc1Ed.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.desc1Ed.Name = "desc1Ed";
            this.desc1Ed.ReadOnly = true;
            this.desc1Ed.Size = new System.Drawing.Size(374, 26);
            this.desc1Ed.TabIndex = 5;
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.codeLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.codeLbl.Location = new System.Drawing.Point(20, 6);
            this.codeLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(46, 16);
            this.codeLbl.TabIndex = 258;
            this.codeLbl.Text = "Mã số";
            // 
            // codeEd
            // 
            this.codeEd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.syslogSource, "id", true));
            this.codeEd.ForeColor = System.Drawing.Color.Black;
            this.codeEd.isRequired = true;
            this.codeEd.isToUpperCase = false;
            this.codeEd.Location = new System.Drawing.Point(20, 26);
            this.codeEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.codeEd.Name = "codeEd";
            this.codeEd.ReadOnly = true;
            this.codeEd.Size = new System.Drawing.Size(101, 23);
            this.codeEd.TabIndex = 1;
            // 
            // onDateColumn
            // 
            this.onDateColumn.DataPropertyName = "onDate";
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.onDateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.onDateColumn.HeaderText = "Ngày/Giờ";
            this.onDateColumn.Name = "onDateColumn";
            this.onDateColumn.ReadOnly = true;
            this.onDateColumn.Width = 140;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.DataPropertyName = "description";
            this.descriptionColumn.HeaderText = "Mô tả";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.ReadOnly = true;
            this.descriptionColumn.Width = 320;
            // 
            // syslogViewer
            // 
            this.ClientSize = new System.Drawing.Size(938, 541);
            this.Controls.Add(this.infoPnl);
            this.Controls.Add(this.optionPnl);
            this.Controls.Add(this.syslogGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "syslogViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Nhat ky he thong";
            this.ResizeEnd += new System.EventHandler(this.syslogViewer_ResizeEnd);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.syslogGrid, 0);
            this.Controls.SetChildIndex(this.optionPnl, 0);
            this.Controls.SetChildIndex(this.infoPnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.syslogGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.syslogSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTempDS)).EndInit();
            this.optionPnl.ResumeLayout(false);
            this.optionPnl.PerformLayout();
            this.infoPnl.ResumeLayout(false);
            this.infoPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private databases.baseDS myBaseDS;
        private System.Windows.Forms.DataGridView syslogGrid;
        private System.Windows.Forms.BindingSource syslogSource;
        protected baseClass.controls.cbSyslogTypes logTypeCb;
        protected databases.tmpDS myTempDS;
        protected common.controls.baseLabel onDateLbl;
        protected common.controls.baseLabel typeLbl;
        protected common.controls.baseTextBox baseTextBox1;
        protected common.controls.baseLabel sourceLbl;
        protected common.controls.baseLabel descLbl;
        protected common.controls.baseTextBox desc1Ed;
        protected common.controls.baseLabel codeLbl;
        protected common.controls.baseTextBox codeEd;
        protected common.controls.baseLabel investorLbl;
        protected common.controls.baseDateTime dateTimeEd;
        protected common.controls.baseTextBox infoEd;
        protected common.controls.baseLabel infoLbl;
        protected baseClass.controls.cbInvestor investorCb;
        protected common.controls.baseButton exitBtn;
        protected common.controls.baseButton okBtn;
        protected common.controls.dateRange0 dateRange;
        protected common.controls.baseCheckBox sourceChk;
        protected common.controls.baseCheckBox descChk;
        protected common.controls.baseTextBox descEd;
        protected System.Windows.Forms.Panel optionPnl;
        protected common.controls.baseCheckBox logTypeChk;
        protected common.controls.baseCheckBox accountChk;
        protected common.controls.baseTextBox sourceEd;
        protected common.controls.baseCheckBox messageChk;
        protected common.controls.baseTextBox messageEd;
        protected System.Windows.Forms.Panel infoPnl;
        protected baseClass.controls.cbSyslogTypes typeCb;
        protected baseClass.controls.txtInvestor accountEd;
        private System.Windows.Forms.DataGridViewTextBoxColumn onDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
    }
}

