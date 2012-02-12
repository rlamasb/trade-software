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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configure));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.configureTab = new System.Windows.Forms.TabControl();
            this.connectionPg = new System.Windows.Forms.TabPage();
            this.toolBarPnl = new common.controls.basePanel();
            this.saveBtn = new common.controls.baseButton();
            this.checkConnBtn = new common.controls.baseButton();
            this.exitBtn = new common.controls.baseButton();
            this.errorPnl = new common.controls.basePanel();
            this.errorMsgEd = new common.controls.baseTextBox();
            this.wsConnection = new common.controls.wsConnection();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.configureTab.SuspendLayout();
            this.connectionPg.SuspendLayout();
            this.toolBarPnl.SuspendLayout();
            this.errorPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(477, 1);
            this.TitleLbl.Size = new System.Drawing.Size(344, 27);
            this.TitleLbl.Text = "THIẾT LẬP HỆ THỐNG";
            this.TitleLbl.Visible = false;
            // 
            // configureTab
            // 
            this.configureTab.Controls.Add(this.connectionPg);
            this.configureTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configureTab.Location = new System.Drawing.Point(0, 1);
            this.configureTab.Name = "configureTab";
            this.configureTab.SelectedIndex = 0;
            this.configureTab.Size = new System.Drawing.Size(470, 514);
            this.configureTab.TabIndex = 208;
            // 
            // connectionPg
            // 
            this.connectionPg.Controls.Add(this.errorPnl);
            this.connectionPg.Controls.Add(this.toolBarPnl);
            this.connectionPg.Controls.Add(this.wsConnection);
            this.connectionPg.Location = new System.Drawing.Point(4, 25);
            this.connectionPg.Name = "connectionPg";
            this.connectionPg.Padding = new System.Windows.Forms.Padding(3);
            this.connectionPg.Size = new System.Drawing.Size(462, 485);
            this.connectionPg.TabIndex = 6;
            this.connectionPg.Text = "Connection";
            this.connectionPg.UseVisualStyleBackColor = true;
            // 
            // toolBarPnl
            // 
            this.toolBarPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolBarPnl.Controls.Add(this.saveBtn);
            this.toolBarPnl.Controls.Add(this.checkConnBtn);
            this.toolBarPnl.Controls.Add(this.exitBtn);
            this.toolBarPnl.haveCloseButton = false;
            this.toolBarPnl.isExpanded = true;
            this.toolBarPnl.Location = new System.Drawing.Point(1, 237);
            this.toolBarPnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.toolBarPnl.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.toolBarPnl.myWeight = 0;
            this.toolBarPnl.Name = "toolBarPnl";
            this.toolBarPnl.Size = new System.Drawing.Size(461, 40);
            this.toolBarPnl.TabIndex = 2;
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.isDownState = false;
            this.saveBtn.Location = new System.Drawing.Point(253, 3);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(97, 33);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "&Lưu";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // checkConnBtn
            // 
            this.checkConnBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkConnBtn.Image = global::baseClass.Properties.Resources.connection;
            this.checkConnBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkConnBtn.isDownState = false;
            this.checkConnBtn.Location = new System.Drawing.Point(156, 3);
            this.checkConnBtn.Margin = new System.Windows.Forms.Padding(0);
            this.checkConnBtn.Name = "checkConnBtn";
            this.checkConnBtn.Size = new System.Drawing.Size(97, 33);
            this.checkConnBtn.TabIndex = 10;
            this.checkConnBtn.Text = "Test";
            this.checkConnBtn.UseVisualStyleBackColor = true;
            this.checkConnBtn.Click += new System.EventHandler(this.checkConnBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitBtn.isDownState = false;
            this.exitBtn.Location = new System.Drawing.Point(350, 3);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(97, 33);
            this.exitBtn.TabIndex = 12;
            this.exitBtn.Text = "Đó&ng";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // errorPnl
            // 
            this.errorPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.errorPnl.Controls.Add(this.errorMsgEd);
            this.errorPnl.haveCloseButton = false;
            this.errorPnl.isExpanded = true;
            this.errorPnl.Location = new System.Drawing.Point(0, 278);
            this.errorPnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.errorPnl.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.errorPnl.myWeight = 0;
            this.errorPnl.Name = "errorPnl";
            this.errorPnl.Size = new System.Drawing.Size(462, 100);
            this.errorPnl.TabIndex = 236;
            this.errorPnl.Visible = false;
            this.errorPnl.myOnClosing += new common.controls.basePanel.OnClosing(this.errorPnl_myOnClosing);
            // 
            // errorMsgEd
            // 
            this.errorMsgEd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorMsgEd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorMsgEd.isRequired = true;
            this.errorMsgEd.isToUpperCase = false;
            this.errorMsgEd.Location = new System.Drawing.Point(0, 0);
            this.errorMsgEd.Multiline = true;
            this.errorMsgEd.Name = "errorMsgEd";
            this.errorMsgEd.ReadOnly = true;
            this.errorMsgEd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorMsgEd.Size = new System.Drawing.Size(458, 96);
            this.errorMsgEd.TabIndex = 11;
            // 
            // wsConnection
            // 
            this.wsConnection.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wsConnection.Location = new System.Drawing.Point(8, 4);
            this.wsConnection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wsConnection.myInfo = null;
            this.wsConnection.Name = "wsConnection";
            this.wsConnection.Size = new System.Drawing.Size(446, 231);
            this.wsConnection.TabIndex = 1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "Giá trị";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 240;
            // 
            // configure
            // 
            this.ClientSize = new System.Drawing.Size(467, 510);
            this.Controls.Add(this.configureTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "configure";
            this.Text = "Thiet lap he thong";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.configure_Load);
            this.Controls.SetChildIndex(this.configureTab, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.configureTab.ResumeLayout(false);
            this.connectionPg.ResumeLayout(false);
            this.toolBarPnl.ResumeLayout(false);
            this.errorPnl.ResumeLayout(false);
            this.errorPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl configureTab;
        private System.Windows.Forms.TabPage connectionPg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        protected common.controls.baseButton checkConnBtn;
        protected common.controls.baseButton saveBtn;
        protected common.controls.baseButton exitBtn;
        protected common.controls.wsConnection wsConnection;
        private common.controls.basePanel toolBarPnl;
        protected common.controls.basePanel errorPnl;
        protected common.controls.baseTextBox errorMsgEd;
    }
}