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
            this.sysLogTypeCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sysCodeTypeSource = new System.Windows.Forms.BindingSource(this.components);
            this.myTempDS = new databases.tmpDS();
            this.onDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syslogSource = new System.Windows.Forms.BindingSource(this.components);
            this.myBaseDS = new databases.baseDS();
            this.investorSource = new System.Windows.Forms.BindingSource(this.components);
            this.sourceChk = new common.controls.baseCheckBox();
            this.descChk = new common.controls.baseCheckBox();
            this.descEd = new common.controls.baseTextBox();
            this.optionPnl = new System.Windows.Forms.Panel();
            this.logTypeCb = new baseClass.controls.cbSyslogTypes();
            this.messageChk = new common.controls.baseCheckBox();
            this.messageEd = new common.controls.baseTextBox();
            this.sourceEd = new common.controls.baseTextBox();
            this.investorEd = new baseClass.controls.txtInvestor();
            this.investorChk = new common.controls.baseCheckBox();
            this.logTypeChk = new common.controls.baseCheckBox();
            this.infoPnl = new System.Windows.Forms.Panel();
            this.typeCb = new common.controls.baseComboBox();
            this.investorLbl = new common.controls.baseLabel();
            this.investorCb = new baseClass.controls.cbInvestor();
            this.dateTimeEd = new common.controls.baseDateTime();
            this.onDateLbl = new common.controls.baseLabel();
            this.typeLbl = new common.controls.baseLabel();
            this.editNoteEd = new common.controls.baseTextBox();
            this.messageLbl = new common.controls.baseLabel();
            this.baseTextBox1 = new common.controls.baseTextBox();
            this.sourceLbl = new common.controls.baseLabel();
            this.descLbl = new common.controls.baseLabel();
            this.desc1Ed = new common.controls.baseTextBox();
            this.codeLbl = new common.controls.baseLabel();
            this.codeEd = new common.controls.baseTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.syslogGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysCodeTypeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTempDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.syslogSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).BeginInit();
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
            this.dateRange.Location = new System.Drawing.Point(27, 3);
            this.dateRange.Margin = new System.Windows.Forms.Padding(4);
            this.dateRange.Name = "dateRange";
            this.dateRange.Size = new System.Drawing.Size(392, 48);
            this.dateRange.TabIndex = 1;
            // 
            // okBtn
            // 
            this.okBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Image = global::baseClass.Properties.Resources.report;
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okBtn.isDownState = false;
            this.okBtn.Location = new System.Drawing.Point(447, 107);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(89, 31);
            this.okBtn.TabIndex = 30;
            this.okBtn.Text = "&Xem";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Image = global::baseClass.Properties.Resources.close;
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitBtn.isDownState = false;
            this.exitBtn.Location = new System.Drawing.Point(536, 107);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(89, 31);
            this.exitBtn.TabIndex = 31;
            this.exitBtn.Text = "Th&oát";
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
            this.sysLogTypeCol,
            this.onDateDataGridViewTextBoxColumn,
            this.descriptionColumn});
            this.syslogGrid.DataSource = this.syslogSource;
            this.syslogGrid.Location = new System.Drawing.Point(1, 149);
            this.syslogGrid.Name = "syslogGrid";
            this.syslogGrid.ReadOnly = true;
            this.syslogGrid.RowHeadersWidth = 40;
            this.syslogGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.syslogGrid.Size = new System.Drawing.Size(652, 376);
            this.syslogGrid.TabIndex = 1;
            this.syslogGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.syslogGrid_RowEnter);
            this.syslogGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.syslogGrid_DataError);
            // 
            // sysLogTypeCol
            // 
            this.sysLogTypeCol.DataPropertyName = "type";
            this.sysLogTypeCol.DataSource = this.sysCodeTypeSource;
            this.sysLogTypeCol.DisplayMember = "description";
            this.sysLogTypeCol.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.sysLogTypeCol.HeaderText = "Lọai";
            this.sysLogTypeCol.Name = "sysLogTypeCol";
            this.sysLogTypeCol.ReadOnly = true;
            this.sysLogTypeCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sysLogTypeCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sysLogTypeCol.Width = 90;
            // 
            // sysCodeTypeSource
            // 
            this.sysCodeTypeSource.DataMember = "codeList";
            this.sysCodeTypeSource.DataSource = this.myTempDS;
            // 
            // myTempDS
            // 
            this.myTempDS.DataSetName = "tempDS";
            this.myTempDS.EnforceConstraints = false;
            this.myTempDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // onDateDataGridViewTextBoxColumn
            // 
            this.onDateDataGridViewTextBoxColumn.DataPropertyName = "onDate";
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.onDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.onDateDataGridViewTextBoxColumn.HeaderText = "Ngày/Giờ";
            this.onDateDataGridViewTextBoxColumn.Name = "onDateDataGridViewTextBoxColumn";
            this.onDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.onDateDataGridViewTextBoxColumn.Width = 150;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.DataPropertyName = "description";
            this.descriptionColumn.HeaderText = "Mô tả";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.ReadOnly = true;
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
            // investorSource
            // 
            this.investorSource.DataMember = "investor";
            this.investorSource.DataSource = this.myTempDS;
            // 
            // sourceChk
            // 
            this.sourceChk.AutoSize = true;
            this.sourceChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceChk.Location = new System.Drawing.Point(137, 57);
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
            this.descChk.Location = new System.Drawing.Point(245, 55);
            this.descChk.Name = "descChk";
            this.descChk.Size = new System.Drawing.Size(50, 20);
            this.descChk.TabIndex = 14;
            this.descChk.Text = "Tên";
            this.descChk.UseVisualStyleBackColor = true;
            this.descChk.CheckedChanged += new System.EventHandler(this.descChk_CheckedChanged);
            // 
            // descEd
            // 
            this.descEd.Enabled = false;
            this.descEd.isRequired = true;
            this.descEd.isToUpperCase = false;
            this.descEd.Location = new System.Drawing.Point(245, 79);
            this.descEd.Name = "descEd";
            this.descEd.Size = new System.Drawing.Size(176, 23);
            this.descEd.TabIndex = 15;
            // 
            // optionPnl
            // 
            this.optionPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.optionPnl.Controls.Add(this.logTypeCb);
            this.optionPnl.Controls.Add(this.messageChk);
            this.optionPnl.Controls.Add(this.messageEd);
            this.optionPnl.Controls.Add(this.sourceEd);
            this.optionPnl.Controls.Add(this.investorEd);
            this.optionPnl.Controls.Add(this.investorChk);
            this.optionPnl.Controls.Add(this.logTypeChk);
            this.optionPnl.Controls.Add(this.dateRange);
            this.optionPnl.Controls.Add(this.descChk);
            this.optionPnl.Controls.Add(this.okBtn);
            this.optionPnl.Controls.Add(this.descEd);
            this.optionPnl.Controls.Add(this.exitBtn);
            this.optionPnl.Controls.Add(this.sourceChk);
            this.optionPnl.Location = new System.Drawing.Point(0, 1);
            this.optionPnl.Name = "optionPnl";
            this.optionPnl.Size = new System.Drawing.Size(653, 146);
            this.optionPnl.TabIndex = 1;
            // 
            // logTypeCb
            // 
            this.logTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logTypeCb.Enabled = false;
            this.logTypeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTypeCb.FormattingEnabled = true;
            this.logTypeCb.Location = new System.Drawing.Point(420, 25);
            this.logTypeCb.myValue = commonTypes.AppTypes.SyslogTypes.Others;
            this.logTypeCb.Name = "logTypeCb";
            this.logTypeCb.SelectedValue = commonTypes.AppTypes.SyslogTypes.Others;
            this.logTypeCb.Size = new System.Drawing.Size(206, 26);
            this.logTypeCb.TabIndex = 3;
            // 
            // messageChk
            // 
            this.messageChk.AutoSize = true;
            this.messageChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageChk.Location = new System.Drawing.Point(421, 56);
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
            this.messageEd.isRequired = true;
            this.messageEd.isToUpperCase = false;
            this.messageEd.Location = new System.Drawing.Point(421, 79);
            this.messageEd.Name = "messageEd";
            this.messageEd.Size = new System.Drawing.Size(202, 23);
            this.messageEd.TabIndex = 17;
            // 
            // sourceEd
            // 
            this.sourceEd.Enabled = false;
            this.sourceEd.isRequired = true;
            this.sourceEd.isToUpperCase = false;
            this.sourceEd.Location = new System.Drawing.Point(136, 79);
            this.sourceEd.Name = "sourceEd";
            this.sourceEd.Size = new System.Drawing.Size(109, 23);
            this.sourceEd.TabIndex = 13;
            // 
            // investorEd
            // 
            this.investorEd.Enabled = false;
            this.investorEd.isRequired = true;
            this.investorEd.isToUpperCase = true;
            this.investorEd.Location = new System.Drawing.Point(28, 79);
            this.investorEd.MaxLength = 15;
            this.investorEd.Name = "investorEd";
            this.investorEd.Size = new System.Drawing.Size(108, 23);
            this.investorEd.TabIndex = 11;
            // 
            // investorChk
            // 
            this.investorChk.AutoSize = true;
            this.investorChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.investorChk.Location = new System.Drawing.Point(27, 55);
            this.investorChk.Name = "investorChk";
            this.investorChk.Size = new System.Drawing.Size(88, 20);
            this.investorChk.TabIndex = 10;
            this.investorChk.Text = "Tài khỏan";
            this.investorChk.UseVisualStyleBackColor = true;
            this.investorChk.CheckedChanged += new System.EventHandler(this.workerChk_CheckedChanged);
            // 
            // logTypeChk
            // 
            this.logTypeChk.AutoSize = true;
            this.logTypeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTypeChk.Location = new System.Drawing.Point(423, 4);
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
            this.infoPnl.Controls.Add(this.editNoteEd);
            this.infoPnl.Controls.Add(this.messageLbl);
            this.infoPnl.Controls.Add(this.baseTextBox1);
            this.infoPnl.Controls.Add(this.sourceLbl);
            this.infoPnl.Controls.Add(this.descLbl);
            this.infoPnl.Controls.Add(this.desc1Ed);
            this.infoPnl.Controls.Add(this.codeLbl);
            this.infoPnl.Controls.Add(this.codeEd);
            this.infoPnl.Location = new System.Drawing.Point(654, 1);
            this.infoPnl.Name = "infoPnl";
            this.infoPnl.Size = new System.Drawing.Size(416, 524);
            this.infoPnl.TabIndex = 10;
            // 
            // typeCb
            // 
            this.typeCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.syslogSource, "type", true));
            this.typeCb.DataSource = this.sysCodeTypeSource;
            this.typeCb.DisplayMember = "description";
            this.typeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCb.FormattingEnabled = true;
            this.typeCb.Location = new System.Drawing.Point(23, 74);
            this.typeCb.myValue = "";
            this.typeCb.Name = "typeCb";
            this.typeCb.Size = new System.Drawing.Size(201, 24);
            this.typeCb.TabIndex = 2;
            this.typeCb.ValueMember = "codeByte";
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
            this.investorCb.DataSource = this.investorSource;
            this.investorCb.DisplayMember = "displayName";
            this.investorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.typeLbl.Location = new System.Drawing.Point(20, 55);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(34, 16);
            this.typeLbl.TabIndex = 257;
            this.typeLbl.Text = "Loại";
            // 
            // editNoteEd
            // 
            this.editNoteEd.BackColor = System.Drawing.SystemColors.Window;
            this.editNoteEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.syslogSource, "message", true));
            this.editNoteEd.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.editNoteEd.isRequired = true;
            this.editNoteEd.isToUpperCase = false;
            this.editNoteEd.Location = new System.Drawing.Point(20, 333);
            this.editNoteEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.editNoteEd.Multiline = true;
            this.editNoteEd.Name = "editNoteEd";
            this.editNoteEd.ReadOnly = true;
            this.editNoteEd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.editNoteEd.Size = new System.Drawing.Size(374, 181);
            this.editNoteEd.TabIndex = 7;
            // 
            // messageLbl
            // 
            this.messageLbl.AutoSize = true;
            this.messageLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.messageLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.messageLbl.Location = new System.Drawing.Point(20, 313);
            this.messageLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(86, 16);
            this.messageLbl.TabIndex = 261;
            this.messageLbl.Text = "Thông tin lỗi";
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
            // syslogViewer
            // 
            this.ClientSize = new System.Drawing.Size(1070, 548);
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
            ((System.ComponentModel.ISupportInitialize)(this.sysCodeTypeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTempDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.syslogSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).EndInit();
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
        private System.Windows.Forms.BindingSource investorSource;
        protected baseClass.controls.cbSyslogTypes logTypeCb;
        protected System.Windows.Forms.BindingSource sysCodeTypeSource;
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
        protected common.controls.baseTextBox editNoteEd;
        protected common.controls.baseLabel messageLbl;
        protected baseClass.controls.cbInvestor investorCb;
        protected common.controls.baseButton exitBtn;
        protected common.controls.baseButton okBtn;
        protected common.controls.dateRange0 dateRange;
        protected common.controls.baseCheckBox sourceChk;
        protected common.controls.baseCheckBox descChk;
        protected common.controls.baseTextBox descEd;
        protected System.Windows.Forms.Panel optionPnl;
        protected common.controls.baseCheckBox logTypeChk;
        protected common.controls.baseCheckBox investorChk;
        protected baseClass.controls.txtInvestor investorEd;
        protected common.controls.baseTextBox sourceEd;
        protected common.controls.baseCheckBox messageChk;
        protected common.controls.baseTextBox messageEd;
        protected System.Windows.Forms.Panel infoPnl;
        protected common.controls.baseComboBox typeCb;
        private System.Windows.Forms.DataGridViewComboBoxColumn sysLogTypeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn onDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
    }
}

