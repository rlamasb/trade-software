namespace common.forms
{
    partial class baseMasterEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseMasterEditForm));
            this.toolBox = new System.Windows.Forms.GroupBox();
            this.findBtn = new System.Windows.Forms.Button();
            this.toExcelBtn = new System.Windows.Forms.Button();
            this.addNewBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.TitleLbl.Location = new System.Drawing.Point(0, 3);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TitleLbl.Size = new System.Drawing.Size(543, 24);
            this.TitleLbl.TabIndex = 142;
            this.TitleLbl.Text = "TIÊU ĐỀ";
            // 
            // toolBox
            // 
            this.toolBox.Controls.Add(this.findBtn);
            this.toolBox.Controls.Add(this.toExcelBtn);
            this.toolBox.Controls.Add(this.addNewBtn);
            this.toolBox.Controls.Add(this.exitBtn);
            this.toolBox.Controls.Add(this.saveBtn);
            this.toolBox.Controls.Add(this.deleteBtn);
            this.toolBox.Controls.Add(this.editBtn);
            this.toolBox.Location = new System.Drawing.Point(0, 438);
            this.toolBox.Margin = new System.Windows.Forms.Padding(4);
            this.toolBox.Name = "toolBox";
            this.toolBox.Padding = new System.Windows.Forms.Padding(4);
            this.toolBox.Size = new System.Drawing.Size(566, 56);
            this.toolBox.TabIndex = 143;
            this.toolBox.TabStop = false;
            // 
            // findBtn
            // 
            this.findBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findBtn.Image = global::common.Properties.Resources.find;
            this.findBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.findBtn.Location = new System.Drawing.Point(267, 14);
            this.findBtn.Margin = new System.Windows.Forms.Padding(4);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(61, 33);
            this.findBtn.TabIndex = 44;
            this.findBtn.Text = "&Tìm";
            this.findBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.findBtn, "Lưu dữ liệu - [F2]");
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Visible = false;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toExcelBtn.Image = global::common.Properties.Resources.excel;
            this.toExcelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toExcelBtn.Location = new System.Drawing.Point(328, 14);
            this.toExcelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.toExcelBtn.Name = "toExcelBtn";
            this.toExcelBtn.Size = new System.Drawing.Size(67, 33);
            this.toExcelBtn.TabIndex = 45;
            this.toExcelBtn.Text = "Excel";
            this.toExcelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.toExcelBtn, "Xuất ra Excel");
            this.toExcelBtn.UseVisualStyleBackColor = true;
            this.toExcelBtn.Visible = false;
            this.toExcelBtn.Click += new System.EventHandler(this.toExcelBtn_Click);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewBtn.ForeColor = System.Drawing.SystemColors.InfoText;
            this.addNewBtn.Image = global::common.Properties.Resources.addNew;
            this.addNewBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addNewBtn.Location = new System.Drawing.Point(84, 14);
            this.addNewBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addNewBtn.Name = "addNewBtn";
            this.addNewBtn.Size = new System.Drawing.Size(61, 33);
            this.addNewBtn.TabIndex = 41;
            this.addNewBtn.Text = "&Mới";
            this.addNewBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.addNewBtn, "Thêm dữ liệu  mới - [F3]");
            this.addNewBtn.UseVisualStyleBackColor = true;
            this.addNewBtn.Click += new System.EventHandler(this.addNewBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Image = global::common.Properties.Resources.close;
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitBtn.Location = new System.Drawing.Point(395, 14);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(67, 33);
            this.exitBtn.TabIndex = 46;
            this.exitBtn.Text = "Th&oát";
            this.exitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.exitBtn, "Kết thúc (Alt -F4)");
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = global::common.Properties.Resources.save;
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.Location = new System.Drawing.Point(23, 14);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(61, 33);
            this.saveBtn.TabIndex = 40;
            this.saveBtn.Text = "&Lưu";
            this.saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.saveBtn, "Lưu dữ liệu - [F2]");
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Image = global::common.Properties.Resources.delete;
            this.deleteBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteBtn.Location = new System.Drawing.Point(145, 14);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(61, 33);
            this.deleteBtn.TabIndex = 42;
            this.deleteBtn.Text = "&Xóa";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.deleteBtn, "Xóa dữ liệu");
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Image = global::common.Properties.Resources.edit;
            this.editBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editBtn.Location = new System.Drawing.Point(206, 14);
            this.editBtn.Margin = new System.Windows.Forms.Padding(4);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(61, 33);
            this.editBtn.TabIndex = 43;
            this.editBtn.Text = "&Sửa";
            this.editBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.editBtn, "Thay đổi  dữ liệu");
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // baseMasterEditForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(567, 521);
            this.Controls.Add(this.toolBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "baseMasterEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tieu de";
            this.Load += new System.EventHandler(this.baseMasterEditForm_Load);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.toolBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ComboBox comboBox1;
        protected System.Windows.Forms.GroupBox toolBox;
        protected System.Windows.Forms.Button exitBtn;
        protected System.Windows.Forms.Button saveBtn;
        protected System.Windows.Forms.Button deleteBtn;
        protected System.Windows.Forms.Button editBtn;
        protected System.Windows.Forms.Button addNewBtn;
        //protected data.masterDataSet myMasterDataSet;
        protected System.Windows.Forms.Button toExcelBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected System.Windows.Forms.Button findBtn;
    }
}

