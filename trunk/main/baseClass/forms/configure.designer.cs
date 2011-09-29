namespace baseClass.forms
{
    partial class configure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configure));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sysAutoKeySource = new System.Windows.Forms.BindingSource(this.components);
            this.myBaseDS = new data.baseDS();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.configureTab = new System.Windows.Forms.TabControl();
            this.connectionPg = new System.Windows.Forms.TabPage();
            this.dbConnInfoObj = new common.controls.dbConnection();
            this.databasePic = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.noteEd = new System.Windows.Forms.TextBox();
            this.checkConnBtn = new System.Windows.Forms.Button();
            this.optionPage = new System.Windows.Forms.TabPage();
            this.imgFileGb = new System.Windows.Forms.GroupBox();
            this.logoImgFileLbl2 = new System.Windows.Forms.Label();
            this.logoImgFileEd2 = new common.controls.baseTextBox();
            this.iconImgFileLbl = new System.Windows.Forms.Label();
            this.iconImgFileEd = new common.controls.baseTextBox();
            this.bgImgFileLbl = new System.Windows.Forms.Label();
            this.bgImgFileEd = new common.controls.baseTextBox();
            this.logoImgFileLbl1 = new System.Windows.Forms.Label();
            this.logoImgFileEd1 = new common.controls.baseTextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sysAutoKeyTA = new data.baseDSTableAdapters.sysAutoKeyTA();
            ((System.ComponentModel.ISupportInitialize)(this.sysAutoKeySource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).BeginInit();
            this.configureTab.SuspendLayout();
            this.connectionPg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databasePic)).BeginInit();
            this.optionPage.SuspendLayout();
            this.imgFileGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(477, 1);
            this.TitleLbl.Size = new System.Drawing.Size(344, 27);
            this.TitleLbl.Text = "THIẾT LẬP HỆ THỐNG";
            this.TitleLbl.Visible = false;
            // 
            // sysAutoKeySource
            // 
            this.sysAutoKeySource.DataMember = "sysAutoKey";
            this.sysAutoKeySource.DataSource = this.myBaseDS;
            // 
            // myBaseDS
            // 
            this.myBaseDS.DataSetName = "baseDS";
            this.myBaseDS.EnforceConstraints = false;
            this.myBaseDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // openFileDialog
            // 
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Chọn tệp";
            // 
            // configureTab
            // 
            this.configureTab.Controls.Add(this.connectionPg);
            this.configureTab.Controls.Add(this.optionPage);
            this.configureTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configureTab.Location = new System.Drawing.Point(-2, 1);
            this.configureTab.Name = "configureTab";
            this.configureTab.SelectedIndex = 0;
            this.configureTab.Size = new System.Drawing.Size(459, 401);
            this.configureTab.TabIndex = 208;
            // 
            // connectionPg
            // 
            this.connectionPg.Controls.Add(this.dbConnInfoObj);
            this.connectionPg.Controls.Add(this.databasePic);
            this.connectionPg.Controls.Add(this.label11);
            this.connectionPg.Controls.Add(this.noteEd);
            this.connectionPg.Controls.Add(this.checkConnBtn);
            this.connectionPg.Location = new System.Drawing.Point(4, 25);
            this.connectionPg.Name = "connectionPg";
            this.connectionPg.Padding = new System.Windows.Forms.Padding(3);
            this.connectionPg.Size = new System.Drawing.Size(451, 372);
            this.connectionPg.TabIndex = 6;
            this.connectionPg.Text = "Database";
            this.connectionPg.UseVisualStyleBackColor = true;
            // 
            // dbConnInfoObj
            // 
            this.dbConnInfoObj.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbConnInfoObj.Location = new System.Drawing.Point(20, 27);
            this.dbConnInfoObj.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dbConnInfoObj.Name = "dbConnInfoObj";
            this.dbConnInfoObj.Size = new System.Drawing.Size(304, 130);
            this.dbConnInfoObj.TabIndex = 1;
            // 
            // databasePic
            // 
            this.databasePic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.databasePic.Image = ((System.Drawing.Image)(resources.GetObject("databasePic.Image")));
            this.databasePic.Location = new System.Drawing.Point(339, 28);
            this.databasePic.Name = "databasePic";
            this.databasePic.Size = new System.Drawing.Size(91, 106);
            this.databasePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.databasePic.TabIndex = 243;
            this.databasePic.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(23, 162);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 16);
            this.label11.TabIndex = 240;
            this.label11.Text = "Infomation";
            // 
            // noteEd
            // 
            this.noteEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteEd.Location = new System.Drawing.Point(115, 158);
            this.noteEd.Margin = new System.Windows.Forms.Padding(4);
            this.noteEd.Multiline = true;
            this.noteEd.Name = "noteEd";
            this.noteEd.ReadOnly = true;
            this.noteEd.Size = new System.Drawing.Size(315, 111);
            this.noteEd.TabIndex = 2;
            this.noteEd.TabStop = false;
            // 
            // checkConnBtn
            // 
            this.checkConnBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkConnBtn.Image = global::baseClass.Properties.Resources.connection;
            this.checkConnBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkConnBtn.Location = new System.Drawing.Point(117, 272);
            this.checkConnBtn.Margin = new System.Windows.Forms.Padding(0);
            this.checkConnBtn.Name = "checkConnBtn";
            this.checkConnBtn.Size = new System.Drawing.Size(160, 30);
            this.checkConnBtn.TabIndex = 233;
            this.checkConnBtn.Text = "Check connection";
            this.checkConnBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkConnBtn.UseVisualStyleBackColor = true;
            this.checkConnBtn.Click += new System.EventHandler(this.checkConnBtn_Click);
            // 
            // optionPage
            // 
            this.optionPage.Controls.Add(this.imgFileGb);
            this.optionPage.Location = new System.Drawing.Point(4, 25);
            this.optionPage.Name = "optionPage";
            this.optionPage.Padding = new System.Windows.Forms.Padding(3);
            this.optionPage.Size = new System.Drawing.Size(451, 416);
            this.optionPage.TabIndex = 4;
            this.optionPage.Text = "Options";
            this.optionPage.UseVisualStyleBackColor = true;
            // 
            // imgFileGb
            // 
            this.imgFileGb.Controls.Add(this.logoImgFileLbl2);
            this.imgFileGb.Controls.Add(this.logoImgFileEd2);
            this.imgFileGb.Controls.Add(this.iconImgFileLbl);
            this.imgFileGb.Controls.Add(this.iconImgFileEd);
            this.imgFileGb.Controls.Add(this.bgImgFileLbl);
            this.imgFileGb.Controls.Add(this.bgImgFileEd);
            this.imgFileGb.Controls.Add(this.logoImgFileLbl1);
            this.imgFileGb.Controls.Add(this.logoImgFileEd1);
            this.imgFileGb.Location = new System.Drawing.Point(7, 16);
            this.imgFileGb.Name = "imgFileGb";
            this.imgFileGb.Size = new System.Drawing.Size(439, 292);
            this.imgFileGb.TabIndex = 1;
            this.imgFileGb.TabStop = false;
            this.imgFileGb.Text = " Tệp hình ";
            // 
            // logoImgFileLbl2
            // 
            this.logoImgFileLbl2.AutoSize = true;
            this.logoImgFileLbl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoImgFileLbl2.Location = new System.Drawing.Point(19, 123);
            this.logoImgFileLbl2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logoImgFileLbl2.Name = "logoImgFileLbl2";
            this.logoImgFileLbl2.Size = new System.Drawing.Size(46, 16);
            this.logoImgFileLbl2.TabIndex = 36;
            this.logoImgFileLbl2.Text = "Logo 2";
            // 
            // logoImgFileEd2
            // 
            this.logoImgFileEd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoImgFileEd2.Location = new System.Drawing.Point(91, 121);
            this.logoImgFileEd2.Margin = new System.Windows.Forms.Padding(4);
            this.logoImgFileEd2.Name = "logoImgFileEd2";
            this.logoImgFileEd2.Size = new System.Drawing.Size(326, 22);
            this.logoImgFileEd2.TabIndex = 4;
            this.myToolTip.SetToolTip(this.logoImgFileEd2, "Nhấp kép chuột để chọn ");
            this.logoImgFileEd2.DoubleClick += new System.EventHandler(this.logoImgFileEd2_DoubleClick);
            // 
            // iconImgFileLbl
            // 
            this.iconImgFileLbl.AutoSize = true;
            this.iconImgFileLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconImgFileLbl.Location = new System.Drawing.Point(19, 61);
            this.iconImgFileLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.iconImgFileLbl.Name = "iconImgFileLbl";
            this.iconImgFileLbl.Size = new System.Drawing.Size(69, 16);
            this.iconImgFileLbl.TabIndex = 34;
            this.iconImgFileLbl.Text = "Biểu tượng";
            // 
            // iconImgFileEd
            // 
            this.iconImgFileEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconImgFileEd.Location = new System.Drawing.Point(91, 59);
            this.iconImgFileEd.Margin = new System.Windows.Forms.Padding(4);
            this.iconImgFileEd.Name = "iconImgFileEd";
            this.iconImgFileEd.Size = new System.Drawing.Size(326, 22);
            this.iconImgFileEd.TabIndex = 2;
            this.myToolTip.SetToolTip(this.iconImgFileEd, "Nhấp kép chuột để chọn ");
            this.iconImgFileEd.DoubleClick += new System.EventHandler(this.iconImgFileEd_DoubleClick);
            // 
            // bgImgFileLbl
            // 
            this.bgImgFileLbl.AutoSize = true;
            this.bgImgFileLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bgImgFileLbl.Location = new System.Drawing.Point(19, 31);
            this.bgImgFileLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bgImgFileLbl.Name = "bgImgFileLbl";
            this.bgImgFileLbl.Size = new System.Drawing.Size(58, 16);
            this.bgImgFileLbl.TabIndex = 33;
            this.bgImgFileLbl.Text = "Hình nền";
            // 
            // bgImgFileEd
            // 
            this.bgImgFileEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bgImgFileEd.Location = new System.Drawing.Point(91, 29);
            this.bgImgFileEd.Margin = new System.Windows.Forms.Padding(4);
            this.bgImgFileEd.Name = "bgImgFileEd";
            this.bgImgFileEd.Size = new System.Drawing.Size(326, 22);
            this.bgImgFileEd.TabIndex = 1;
            this.myToolTip.SetToolTip(this.bgImgFileEd, "Nhấp kép chuột để chọn ");
            this.bgImgFileEd.DoubleClick += new System.EventHandler(this.bgImgFileEd_DoubleClick);
            // 
            // logoImgFileLbl1
            // 
            this.logoImgFileLbl1.AutoSize = true;
            this.logoImgFileLbl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoImgFileLbl1.Location = new System.Drawing.Point(19, 91);
            this.logoImgFileLbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logoImgFileLbl1.Name = "logoImgFileLbl1";
            this.logoImgFileLbl1.Size = new System.Drawing.Size(46, 16);
            this.logoImgFileLbl1.TabIndex = 32;
            this.logoImgFileLbl1.Text = "Logo 1";
            // 
            // logoImgFileEd1
            // 
            this.logoImgFileEd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoImgFileEd1.Location = new System.Drawing.Point(91, 89);
            this.logoImgFileEd1.Margin = new System.Windows.Forms.Padding(4);
            this.logoImgFileEd1.Name = "logoImgFileEd1";
            this.logoImgFileEd1.Size = new System.Drawing.Size(326, 22);
            this.logoImgFileEd1.TabIndex = 3;
            this.myToolTip.SetToolTip(this.logoImgFileEd1, "Nhấp kép chuột để chọn ");
            this.logoImgFileEd1.DoubleClick += new System.EventHandler(this.logoImgFileEd_DoubleClick);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.Location = new System.Drawing.Point(274, 346);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(76, 30);
            this.saveBtn.TabIndex = 206;
            this.saveBtn.Text = "&Lưu";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitBtn.Location = new System.Drawing.Point(350, 346);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(76, 30);
            this.exitBtn.TabIndex = 207;
            this.exitBtn.Text = "Đó&ng";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "key";
            this.dataGridViewTextBoxColumn1.HeaderText = "Loại";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "value";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "Giá trị";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 240;
            // 
            // sysAutoKeyTA
            // 
            this.sysAutoKeyTA.ClearBeforeFill = true;
            // 
            // configure
            // 
            this.ClientSize = new System.Drawing.Size(457, 401);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.configureTab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "configure";
            this.Text = "Thiet lap he thong";
            this.Load += new System.EventHandler(this.configure_Load);
            this.Controls.SetChildIndex(this.configureTab, 0);
            this.Controls.SetChildIndex(this.exitBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.saveBtn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sysAutoKeySource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).EndInit();
            this.configureTab.ResumeLayout(false);
            this.connectionPg.ResumeLayout(false);
            this.connectionPg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databasePic)).EndInit();
            this.optionPage.ResumeLayout(false);
            this.imgFileGb.ResumeLayout(false);
            this.imgFileGb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource sysAutoKeySource;
        private data.baseDS myBaseDS;
        protected System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabControl configureTab;
        private System.Windows.Forms.TabPage connectionPg;
        protected common.controls.dbConnection dbConnInfoObj;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        protected System.Windows.Forms.GroupBox imgFileGb;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TextBox noteEd;
        protected System.Windows.Forms.Button checkConnBtn;
        protected System.Windows.Forms.PictureBox databasePic;
        protected System.Windows.Forms.Button saveBtn;
        protected System.Windows.Forms.Button exitBtn;
        protected System.Windows.Forms.TabPage optionPage;
        protected System.Windows.Forms.Label logoImgFileLbl2;
        protected common.controls.baseTextBox logoImgFileEd2;
        protected System.Windows.Forms.Label iconImgFileLbl;
        protected common.controls.baseTextBox iconImgFileEd;
        protected System.Windows.Forms.Label bgImgFileLbl;
        protected common.controls.baseTextBox bgImgFileEd;
        protected System.Windows.Forms.Label logoImgFileLbl1;
        protected common.controls.baseTextBox logoImgFileEd1;
        private data.baseDSTableAdapters.sysAutoKeyTA sysAutoKeyTA;
    }
}