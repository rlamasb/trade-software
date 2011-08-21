namespace baseClass.forms
{
    partial class sysCodeCatEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sysCodeCatEdit));
            this.listGrid = new common.control.baseDataGridView();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sysCodeCatSource = new System.Windows.Forms.BindingSource(this.components);
            this.noteEd = new System.Windows.Forms.TextBox();
            this.label6 = new baseClass.controls.baseLabel();
            this.label7 = new baseClass.controls.baseLabel();
            this.codeEd = new common.control.baseTextBox();
            this.descriptionEd = new common.control.baseTextBox();
            this.label4 = new baseClass.controls.baseLabel();
            this.isVisibleChk = new baseClass.controls.baseCheckBox();
            this.isSystemChk = new baseClass.controls.baseCheckBox();
            this.tagLbl1 = new baseClass.controls.baseLabel();
            this.tagEd1 = new common.control.baseTextBox();
            this.tagLbl2 = new baseClass.controls.baseLabel();
            this.tagEd2 = new common.control.baseTextBox();
            this.maxLenLbl = new baseClass.controls.baseLabel();
            this.maxLenEd = new common.control.baseTextBox();
            this.weightLbl = new baseClass.controls.baseLabel();
            this.weightEd = new common.control.baseTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysCodeCatSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(-8, -10);
            this.toolBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toolBox.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toolBox.Size = new System.Drawing.Size(450, 57);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(354, 11);
            this.exitBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(98, 11);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.saveBtn.Size = new System.Drawing.Size(64, 39);
            this.myToolTip.SetToolTip(this.saveBtn, "Lưu dữ liệu - [F2]");
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(162, 11);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.deleteBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(226, 11);
            this.editBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.editBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(34, 11);
            this.addNewBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.addNewBtn.Size = new System.Drawing.Size(64, 39);
            this.myToolTip.SetToolTip(this.addNewBtn, "Thêm dữ liệu mới - [F3]");
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(560, 19);
            this.toExcelBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toExcelBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(462, 14);
            this.findBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(290, 11);
            this.reloadBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.reloadBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(466, 13);
            this.printBtn.Size = new System.Drawing.Size(64, 39);
            this.printBtn.Visible = false;
            // 
            // unLockBtn
            // 
            this.unLockBtn.Location = new System.Drawing.Point(742, 278);
            this.unLockBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.unLockBtn.Size = new System.Drawing.Size(34, 26);
            // 
            // lockBtn
            // 
            this.lockBtn.Location = new System.Drawing.Point(723, 260);
            this.lockBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lockBtn.Size = new System.Drawing.Size(34, 26);
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(635, 163);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TitleLbl.Size = new System.Drawing.Size(307, 24);
            this.TitleLbl.TabIndex = 149;
            this.TitleLbl.Text = "THÔNG TIN NHÓM PHÂN LOẠI";
            // 
            // listGrid
            // 
            this.listGrid.AllowUserToAddRows = false;
            this.listGrid.AllowUserToDeleteRows = false;
            this.listGrid.AllowUserToOrderColumns = true;
            this.listGrid.AutoGenerateColumns = false;
            this.listGrid.ColumnHeadersHeight = 25;
            this.listGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryDataGridViewTextBoxColumn,
            this.description,
            this.weight});
            this.listGrid.DataSource = this.sysCodeCatSource;
            this.listGrid.Location = new System.Drawing.Point(435, -1);
            this.listGrid.Name = "listGrid";
            this.listGrid.ReadOnly = true;
            this.listGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listGrid.Size = new System.Drawing.Size(431, 379);
            this.listGrid.TabIndex = 153;
            this.listGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.listGrid_DataError);
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Mã số";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryDataGridViewTextBoxColumn.Width = 130;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Diễn giải";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 240;
            // 
            // weight
            // 
            this.weight.DataPropertyName = "weight";
            this.weight.HeaderText = "Trọng số";
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            this.weight.Visible = false;
            this.weight.Width = 70;
            // 
            // sysCodeCatSource
            // 
            this.sysCodeCatSource.DataMember = "sysCodeCat";
            this.sysCodeCatSource.DataSource = this.myDataSet;
            // 
            // noteEd
            // 
            this.noteEd.BackColor = System.Drawing.SystemColors.Window;
            this.noteEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeCatSource, "notes", true));
            this.noteEd.Location = new System.Drawing.Point(24, 288);
            this.noteEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.noteEd.Multiline = true;
            this.noteEd.Name = "noteEd";
            this.noteEd.Size = new System.Drawing.Size(389, 48);
            this.noteEd.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 268);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 167;
            this.label6.Text = "Ghi chú";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 165;
            this.label7.Text = "Mã số *";
            // 
            // codeEd
            // 
            this.codeEd.BackColor = System.Drawing.SystemColors.Window;
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeCatSource, "category", true));
            this.codeEd.Location = new System.Drawing.Point(24, 88);
            this.codeEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(235, 22);
            this.codeEd.TabIndex = 1;
            this.codeEd.Validating += new System.ComponentModel.CancelEventHandler(this.codeEd_Validating);
            // 
            // descriptionEd
            // 
            this.descriptionEd.BackColor = System.Drawing.SystemColors.Window;
            this.descriptionEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeCatSource, "Description", true));
            this.descriptionEd.Location = new System.Drawing.Point(24, 138);
            this.descriptionEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.descriptionEd.Name = "descriptionEd";
            this.descriptionEd.Size = new System.Drawing.Size(388, 22);
            this.descriptionEd.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 164;
            this.label4.Text = "Diễn giải *";
            // 
            // isVisibleChk
            // 
            this.isVisibleChk.AutoSize = true;
            this.isVisibleChk.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.sysCodeCatSource, "isVisible", true));
            this.isVisibleChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isVisibleChk.Location = new System.Drawing.Point(24, 347);
            this.isVisibleChk.Name = "isVisibleChk";
            this.isVisibleChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isVisibleChk.Size = new System.Drawing.Size(76, 20);
            this.isVisibleChk.TabIndex = 22;
            this.isVisibleChk.Text = "Hiển thị";
            this.isVisibleChk.UseVisualStyleBackColor = true;
            // 
            // isSystemChk
            // 
            this.isSystemChk.AutoSize = true;
            this.isSystemChk.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.sysCodeCatSource, "isSystem", true));
            this.isSystemChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isSystemChk.Location = new System.Drawing.Point(127, 347);
            this.isSystemChk.Name = "isSystemChk";
            this.isSystemChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isSystemChk.Size = new System.Drawing.Size(86, 20);
            this.isSystemChk.TabIndex = 23;
            this.isSystemChk.Text = "Hệ thống";
            this.isSystemChk.UseVisualStyleBackColor = true;
            // 
            // tagLbl1
            // 
            this.tagLbl1.AutoSize = true;
            this.tagLbl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagLbl1.Location = new System.Drawing.Point(24, 168);
            this.tagLbl1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tagLbl1.Name = "tagLbl1";
            this.tagLbl1.Size = new System.Drawing.Size(78, 16);
            this.tagLbl1.TabIndex = 169;
            this.tagLbl1.Text = "Thông số 1";
            // 
            // tagEd1
            // 
            this.tagEd1.BackColor = System.Drawing.SystemColors.Window;
            this.tagEd1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeCatSource, "tag1", true));
            this.tagEd1.Location = new System.Drawing.Point(24, 188);
            this.tagEd1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tagEd1.Name = "tagEd1";
            this.tagEd1.Size = new System.Drawing.Size(97, 22);
            this.tagEd1.TabIndex = 20;
            // 
            // tagLbl2
            // 
            this.tagLbl2.AutoSize = true;
            this.tagLbl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagLbl2.Location = new System.Drawing.Point(121, 168);
            this.tagLbl2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tagLbl2.Name = "tagLbl2";
            this.tagLbl2.Size = new System.Drawing.Size(78, 16);
            this.tagLbl2.TabIndex = 171;
            this.tagLbl2.Text = "Thông số 1";
            // 
            // tagEd2
            // 
            this.tagEd2.BackColor = System.Drawing.SystemColors.Window;
            this.tagEd2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeCatSource, "tag2", true));
            this.tagEd2.Location = new System.Drawing.Point(120, 188);
            this.tagEd2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tagEd2.Name = "tagEd2";
            this.tagEd2.Size = new System.Drawing.Size(97, 22);
            this.tagEd2.TabIndex = 21;
            // 
            // maxLenLbl
            // 
            this.maxLenLbl.AutoSize = true;
            this.maxLenLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxLenLbl.Location = new System.Drawing.Point(256, 68);
            this.maxLenLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.maxLenLbl.Name = "maxLenLbl";
            this.maxLenLbl.Size = new System.Drawing.Size(49, 16);
            this.maxLenLbl.TabIndex = 173;
            this.maxLenLbl.Text = "Độ dài";
            // 
            // maxLenEd
            // 
            this.maxLenEd.BackColor = System.Drawing.SystemColors.Window;
            this.maxLenEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeCatSource, "maxCodeLen", true));
            this.maxLenEd.Location = new System.Drawing.Point(256, 88);
            this.maxLenEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.maxLenEd.Name = "maxLenEd";
            this.maxLenEd.Size = new System.Drawing.Size(97, 22);
            this.maxLenEd.TabIndex = 2;
            // 
            // weightLbl
            // 
            this.weightLbl.AutoSize = true;
            this.weightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightLbl.Location = new System.Drawing.Point(24, 218);
            this.weightLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.weightLbl.Name = "weightLbl";
            this.weightLbl.Size = new System.Drawing.Size(64, 16);
            this.weightLbl.TabIndex = 175;
            this.weightLbl.Text = "Trọng số";
            // 
            // weightEd
            // 
            this.weightEd.BackColor = System.Drawing.SystemColors.Window;
            this.weightEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeCatSource, "weight", true));
            this.weightEd.Location = new System.Drawing.Point(24, 238);
            this.weightEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.weightEd.Name = "weightEd";
            this.weightEd.Size = new System.Drawing.Size(96, 22);
            this.weightEd.TabIndex = 22;
            // 
            // sysCodeCatEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 407);
            this.Controls.Add(this.weightLbl);
            this.Controls.Add(this.weightEd);
            this.Controls.Add(this.maxLenLbl);
            this.Controls.Add(this.maxLenEd);
            this.Controls.Add(this.tagLbl2);
            this.Controls.Add(this.tagEd2);
            this.Controls.Add(this.tagLbl1);
            this.Controls.Add(this.tagEd1);
            this.Controls.Add(this.isSystemChk);
            this.Controls.Add(this.isVisibleChk);
            this.Controls.Add(this.noteEd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.codeEd);
            this.Controls.Add(this.descriptionEd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "sysCodeCatEdit";
            this.Text = "Nhom phan loai";
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.listGrid, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.descriptionEd, 0);
            this.Controls.SetChildIndex(this.codeEd, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.noteEd, 0);
            this.Controls.SetChildIndex(this.isVisibleChk, 0);
            this.Controls.SetChildIndex(this.isSystemChk, 0);
            this.Controls.SetChildIndex(this.tagEd1, 0);
            this.Controls.SetChildIndex(this.tagLbl1, 0);
            this.Controls.SetChildIndex(this.tagEd2, 0);
            this.Controls.SetChildIndex(this.tagLbl2, 0);
            this.Controls.SetChildIndex(this.maxLenEd, 0);
            this.Controls.SetChildIndex(this.maxLenLbl, 0);
            this.Controls.SetChildIndex(this.weightEd, 0);
            this.Controls.SetChildIndex(this.weightLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysCodeCatSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private common.control.baseDataGridView listGrid;
        private System.Windows.Forms.TextBox noteEd;
        private baseClass.controls.baseLabel label6;
        private baseClass.controls.baseLabel label7;
        private common.control.baseTextBox codeEd;
        private common.control.baseTextBox descriptionEd;
        private baseClass.controls.baseLabel label4;
        private System.Windows.Forms.BindingSource sysCodeCatSource;
        private baseClass.controls.baseCheckBox isVisibleChk;
        private baseClass.controls.baseCheckBox isSystemChk;
        private baseClass.controls.baseLabel tagLbl1;
        private common.control.baseTextBox tagEd1;
        private baseClass.controls.baseLabel tagLbl2;
        private common.control.baseTextBox tagEd2;
        private baseClass.controls.baseLabel maxLenLbl;
        private common.control.baseTextBox maxLenEd;
        private baseClass.controls.baseLabel weightLbl;
        private common.control.baseTextBox weightEd;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
    }
}