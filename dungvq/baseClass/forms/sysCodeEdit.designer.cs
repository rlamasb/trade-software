namespace baseClass.forms
{
    partial class sysCodeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sysCodeEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.categoryCb = new baseClass.controls.cbSysCodeCat();
            this.syscodeGrid = new common.control.baseDataGridView();
            this.gridSyscode = new common.control.DataGridViewTextBoxColumnExt();
            this.gridDescription1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDescription2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isSystem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sysCodeSource = new System.Windows.Forms.BindingSource(this.components);
            this.systemChk = new baseClass.controls.baseCheckBox();
            this.typeLbl = new baseClass.controls.baseLabel();
            this.isVisibleChk = new baseClass.controls.baseCheckBox();
            this.notesEd = new common.control.baseTextBox();
            this.notesLbl = new baseClass.controls.baseLabel();
            this.editPnl = new System.Windows.Forms.Panel();
            this.weightEd = new common.control.baseTextBox();
            this.weightLbl = new baseClass.controls.baseLabel();
            this.editIsVisibleChk = new baseClass.controls.baseCheckBox();
            this.editNoteEd = new System.Windows.Forms.TextBox();
            this.label6 = new baseClass.controls.baseLabel();
            this.inGroupEd = new common.control.baseTextBox();
            this.inGroupLbl = new baseClass.controls.baseLabel();
            this.desc2Ed = new common.control.baseTextBox();
            this.desc2Lbl = new baseClass.controls.baseLabel();
            this.editIsSystemChk = new baseClass.controls.baseCheckBox();
            this.codeEd = new common.control.baseTextBox();
            this.codeLbl = new baseClass.controls.baseLabel();
            this.desc1Ed = new common.control.baseTextBox();
            this.desc1Lbl = new baseClass.controls.baseLabel();
            this.maxLenEd = new common.control.baseTextBox();
            this.categoryEd = new common.control.baseTextBox();
            this.tag1Ed = new common.control.baseTextBox();
            this.tag1Lbl = new baseClass.controls.baseLabel();
            this.tag2Ed = new common.control.baseTextBox();
            this.tag2Lbl = new baseClass.controls.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.syscodeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysCodeSource)).BeginInit();
            this.editPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBox
            // 
            resources.ApplyResources(this.toolBox, "toolBox");
            // 
            // exitBtn
            // 
            resources.ApplyResources(this.exitBtn, "exitBtn");
            // 
            // saveBtn
            // 
            resources.ApplyResources(this.saveBtn, "saveBtn");
            // 
            // deleteBtn
            // 
            resources.ApplyResources(this.deleteBtn, "deleteBtn");
            // 
            // editBtn
            // 
            resources.ApplyResources(this.editBtn, "editBtn");
            // 
            // addNewBtn
            // 
            resources.ApplyResources(this.addNewBtn, "addNewBtn");
            // 
            // toExcelBtn
            // 
            resources.ApplyResources(this.toExcelBtn, "toExcelBtn");
            // 
            // findBtn
            // 
            resources.ApplyResources(this.findBtn, "findBtn");
            // 
            // reloadBtn
            // 
            resources.ApplyResources(this.reloadBtn, "reloadBtn");
            // 
            // printBtn
            // 
            resources.ApplyResources(this.printBtn, "printBtn");
            // 
            // unLockBtn
            // 
            resources.ApplyResources(this.unLockBtn, "unLockBtn");
            // 
            // lockBtn
            // 
            resources.ApplyResources(this.lockBtn, "lockBtn");
            // 
            // TitleLbl
            // 
            resources.ApplyResources(this.TitleLbl, "TitleLbl");
            // 
            // categoryCb
            // 
            this.categoryCb.DisplayMember = "category";
            this.categoryCb.DropDownHeight = 500;
            this.categoryCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.categoryCb, "categoryCb");
            this.categoryCb.FormattingEnabled = true;
            this.categoryCb.myValue = "";
            this.categoryCb.Name = "categoryCb";
            this.categoryCb.ValueMember = "category";
            this.categoryCb.SelectedIndexChanged += new System.EventHandler(this.sysCodeCatSource_CurrentChanged);
            // 
            // syscodeGrid
            // 
            this.syscodeGrid.AllowUserToAddRows = false;
            this.syscodeGrid.AllowUserToDeleteRows = false;
            this.syscodeGrid.AutoGenerateColumns = false;
            resources.ApplyResources(this.syscodeGrid, "syscodeGrid");
            this.syscodeGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridSyscode,
            this.gridDescription1,
            this.gridDescription2,
            this.inGroup,
            this.weight,
            this.isSystem,
            this.isVisible});
            this.syscodeGrid.DataSource = this.sysCodeSource;
            this.syscodeGrid.Name = "syscodeGrid";
            this.syscodeGrid.ReadOnly = true;
            this.syscodeGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syscodeGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.syscodeGrid_DataError);
            // 
            // gridSyscode
            // 
            this.gridSyscode.DataPropertyName = "code";
            dataGridViewCellStyle2.NullValue = null;
            this.gridSyscode.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.gridSyscode, "gridSyscode");
            this.gridSyscode.Name = "gridSyscode";
            this.gridSyscode.ReadOnly = true;
            this.gridSyscode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSyscode.Uppercase = false;
            // 
            // gridDescription1
            // 
            this.gridDescription1.DataPropertyName = "description1";
            resources.ApplyResources(this.gridDescription1, "gridDescription1");
            this.gridDescription1.Name = "gridDescription1";
            this.gridDescription1.ReadOnly = true;
            // 
            // gridDescription2
            // 
            this.gridDescription2.DataPropertyName = "description2";
            resources.ApplyResources(this.gridDescription2, "gridDescription2");
            this.gridDescription2.Name = "gridDescription2";
            this.gridDescription2.ReadOnly = true;
            // 
            // inGroup
            // 
            this.inGroup.DataPropertyName = "inGroup";
            resources.ApplyResources(this.inGroup, "inGroup");
            this.inGroup.Name = "inGroup";
            this.inGroup.ReadOnly = true;
            // 
            // weight
            // 
            this.weight.DataPropertyName = "weight";
            resources.ApplyResources(this.weight, "weight");
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            // 
            // isSystem
            // 
            this.isSystem.DataPropertyName = "isSystem";
            resources.ApplyResources(this.isSystem, "isSystem");
            this.isSystem.Name = "isSystem";
            this.isSystem.ReadOnly = true;
            // 
            // isVisible
            // 
            this.isVisible.DataPropertyName = "isVisible";
            resources.ApplyResources(this.isVisible, "isVisible");
            this.isVisible.Name = "isVisible";
            this.isVisible.ReadOnly = true;
            // 
            // sysCodeSource
            // 
            this.sysCodeSource.DataMember = "sysCode";
            this.sysCodeSource.DataSource = this.myDataSet;
            // 
            // systemChk
            // 
            resources.ApplyResources(this.systemChk, "systemChk");
            this.systemChk.ForeColor = System.Drawing.SystemColors.InfoText;
            this.systemChk.Name = "systemChk";
            // 
            // typeLbl
            // 
            resources.ApplyResources(this.typeLbl, "typeLbl");
            this.typeLbl.Name = "typeLbl";
            // 
            // isVisibleChk
            // 
            resources.ApplyResources(this.isVisibleChk, "isVisibleChk");
            this.isVisibleChk.ForeColor = System.Drawing.SystemColors.InfoText;
            this.isVisibleChk.Name = "isVisibleChk";
            // 
            // notesEd
            // 
            this.notesEd.BackColor = System.Drawing.SystemColors.Info;
            resources.ApplyResources(this.notesEd, "notesEd");
            this.notesEd.Name = "notesEd";
            this.notesEd.ReadOnly = true;
            // 
            // notesLbl
            // 
            resources.ApplyResources(this.notesLbl, "notesLbl");
            this.notesLbl.Name = "notesLbl";
            // 
            // editPnl
            // 
            this.editPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.editPnl.Controls.Add(this.tag2Ed);
            this.editPnl.Controls.Add(this.tag2Lbl);
            this.editPnl.Controls.Add(this.tag1Ed);
            this.editPnl.Controls.Add(this.tag1Lbl);
            this.editPnl.Controls.Add(this.weightEd);
            this.editPnl.Controls.Add(this.weightLbl);
            this.editPnl.Controls.Add(this.editIsVisibleChk);
            this.editPnl.Controls.Add(this.editNoteEd);
            this.editPnl.Controls.Add(this.label6);
            this.editPnl.Controls.Add(this.inGroupEd);
            this.editPnl.Controls.Add(this.inGroupLbl);
            this.editPnl.Controls.Add(this.desc2Ed);
            this.editPnl.Controls.Add(this.desc2Lbl);
            this.editPnl.Controls.Add(this.editIsSystemChk);
            this.editPnl.Controls.Add(this.codeEd);
            this.editPnl.Controls.Add(this.codeLbl);
            this.editPnl.Controls.Add(this.desc1Ed);
            this.editPnl.Controls.Add(this.desc1Lbl);
            resources.ApplyResources(this.editPnl, "editPnl");
            this.editPnl.Name = "editPnl";
            // 
            // weightEd
            // 
            this.weightEd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.weightEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeSource, "weight", true));
            resources.ApplyResources(this.weightEd, "weightEd");
            this.weightEd.ForeColor = System.Drawing.Color.Black;
            this.weightEd.Name = "weightEd";
            // 
            // weightLbl
            // 
            resources.ApplyResources(this.weightLbl, "weightLbl");
            this.weightLbl.Name = "weightLbl";
            // 
            // editIsVisibleChk
            // 
            resources.ApplyResources(this.editIsVisibleChk, "editIsVisibleChk");
            this.editIsVisibleChk.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.sysCodeSource, "isVisible", true));
            this.editIsVisibleChk.Name = "editIsVisibleChk";
            this.editIsVisibleChk.TabStop = false;
            this.editIsVisibleChk.UseVisualStyleBackColor = true;
            // 
            // editNoteEd
            // 
            this.editNoteEd.BackColor = System.Drawing.SystemColors.Window;
            this.editNoteEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeSource, "notes", true));
            resources.ApplyResources(this.editNoteEd, "editNoteEd");
            this.editNoteEd.Name = "editNoteEd";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // inGroupEd
            // 
            this.inGroupEd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.inGroupEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeSource, "inGroup", true));
            resources.ApplyResources(this.inGroupEd, "inGroupEd");
            this.inGroupEd.ForeColor = System.Drawing.Color.Black;
            this.inGroupEd.Name = "inGroupEd";
            // 
            // inGroupLbl
            // 
            resources.ApplyResources(this.inGroupLbl, "inGroupLbl");
            this.inGroupLbl.Name = "inGroupLbl";
            // 
            // desc2Ed
            // 
            this.desc2Ed.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.desc2Ed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeSource, "description2", true));
            resources.ApplyResources(this.desc2Ed, "desc2Ed");
            this.desc2Ed.ForeColor = System.Drawing.Color.Black;
            this.desc2Ed.Name = "desc2Ed";
            // 
            // desc2Lbl
            // 
            resources.ApplyResources(this.desc2Lbl, "desc2Lbl");
            this.desc2Lbl.Name = "desc2Lbl";
            // 
            // editIsSystemChk
            // 
            resources.ApplyResources(this.editIsSystemChk, "editIsSystemChk");
            this.editIsSystemChk.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.sysCodeSource, "isSystem", true));
            this.editIsSystemChk.Name = "editIsSystemChk";
            this.editIsSystemChk.TabStop = false;
            // 
            // codeEd
            // 
            this.codeEd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeSource, "code", true));
            resources.ApplyResources(this.codeEd, "codeEd");
            this.codeEd.ForeColor = System.Drawing.Color.Black;
            this.codeEd.Name = "codeEd";
            // 
            // codeLbl
            // 
            resources.ApplyResources(this.codeLbl, "codeLbl");
            this.codeLbl.Name = "codeLbl";
            // 
            // desc1Ed
            // 
            this.desc1Ed.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.desc1Ed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeSource, "description1", true));
            resources.ApplyResources(this.desc1Ed, "desc1Ed");
            this.desc1Ed.ForeColor = System.Drawing.Color.Black;
            this.desc1Ed.Name = "desc1Ed";
            // 
            // desc1Lbl
            // 
            resources.ApplyResources(this.desc1Lbl, "desc1Lbl");
            this.desc1Lbl.Name = "desc1Lbl";
            // 
            // maxLenEd
            // 
            this.maxLenEd.BackColor = System.Drawing.SystemColors.Info;
            resources.ApplyResources(this.maxLenEd, "maxLenEd");
            this.maxLenEd.ForeColor = System.Drawing.Color.Black;
            this.maxLenEd.Name = "maxLenEd";
            this.maxLenEd.TabStop = false;
            // 
            // categoryEd
            // 
            this.categoryEd.BackColor = System.Drawing.SystemColors.Info;
            this.categoryEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeSource, "category", true));
            resources.ApplyResources(this.categoryEd, "categoryEd");
            this.categoryEd.ForeColor = System.Drawing.Color.Black;
            this.categoryEd.Name = "categoryEd";
            this.categoryEd.TabStop = false;
            // 
            // tag1Ed
            // 
            this.tag1Ed.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tag1Ed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeSource, "tag1", true));
            resources.ApplyResources(this.tag1Ed, "tag1Ed");
            this.tag1Ed.ForeColor = System.Drawing.Color.Black;
            this.tag1Ed.Name = "tag1Ed";
            // 
            // tag1Lbl
            // 
            resources.ApplyResources(this.tag1Lbl, "tag1Lbl");
            this.tag1Lbl.Name = "tag1Lbl";
            // 
            // tag2Ed
            // 
            this.tag2Ed.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tag2Ed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sysCodeSource, "tag2", true));
            resources.ApplyResources(this.tag2Ed, "tag2Ed");
            this.tag2Ed.ForeColor = System.Drawing.Color.Black;
            this.tag2Ed.Name = "tag2Ed";
            // 
            // tag2Lbl
            // 
            resources.ApplyResources(this.tag2Lbl, "tag2Lbl");
            this.tag2Lbl.Name = "tag2Lbl";
            // 
            // sysCodeEdit
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.categoryEd);
            this.Controls.Add(this.maxLenEd);
            this.Controls.Add(this.editPnl);
            this.Controls.Add(this.notesLbl);
            this.Controls.Add(this.notesEd);
            this.Controls.Add(this.isVisibleChk);
            this.Controls.Add(this.typeLbl);
            this.Controls.Add(this.systemChk);
            this.Controls.Add(this.syscodeGrid);
            this.Controls.Add(this.categoryCb);
            this.Name = "sysCodeEdit";
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.categoryCb, 0);
            this.Controls.SetChildIndex(this.syscodeGrid, 0);
            this.Controls.SetChildIndex(this.systemChk, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.typeLbl, 0);
            this.Controls.SetChildIndex(this.isVisibleChk, 0);
            this.Controls.SetChildIndex(this.notesEd, 0);
            this.Controls.SetChildIndex(this.notesLbl, 0);
            this.Controls.SetChildIndex(this.editPnl, 0);
            this.Controls.SetChildIndex(this.maxLenEd, 0);
            this.Controls.SetChildIndex(this.categoryEd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.syscodeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysCodeSource)).EndInit();
            this.editPnl.ResumeLayout(false);
            this.editPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource sysCodeSource;
        protected baseClass.controls.baseCheckBox isVisibleChk;
        protected baseClass.controls.cbSysCodeCat categoryCb;
        protected baseClass.controls.baseCheckBox systemChk;
        protected baseClass.controls.baseLabel typeLbl;
        protected common.control.baseDataGridView syscodeGrid;
        protected common.control.baseTextBox notesEd;
        protected baseClass.controls.baseLabel notesLbl;
        private System.Windows.Forms.Panel editPnl;
        protected baseClass.controls.baseCheckBox editIsVisibleChk;
        private System.Windows.Forms.TextBox editNoteEd;
        private baseClass.controls.baseLabel label6;
        protected common.control.baseTextBox inGroupEd;
        protected baseClass.controls.baseLabel inGroupLbl;
        protected common.control.baseTextBox desc2Ed;
        protected baseClass.controls.baseLabel desc2Lbl;
        protected baseClass.controls.baseCheckBox editIsSystemChk;
        protected common.control.baseTextBox codeEd;
        protected baseClass.controls.baseLabel codeLbl;
        protected common.control.baseTextBox desc1Ed;
        protected baseClass.controls.baseLabel desc1Lbl;
        protected common.control.baseTextBox weightEd;
        protected baseClass.controls.baseLabel weightLbl;
        protected common.control.baseTextBox maxLenEd;
        protected common.control.baseTextBox categoryEd;
        private common.control.DataGridViewTextBoxColumnExt gridSyscode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDescription1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDescription2;
        private System.Windows.Forms.DataGridViewTextBoxColumn inGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSystem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isVisible;
        protected common.control.baseTextBox tag2Ed;
        protected baseClass.controls.baseLabel tag2Lbl;
        protected common.control.baseTextBox tag1Ed;
        protected baseClass.controls.baseLabel tag1Lbl;
    }
}