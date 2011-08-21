namespace tradeAlert.controls
{
    partial class tradeAlertCriteria
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
            this.components = new System.ComponentModel.Container();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tradeActionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portpolioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strategyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tradeAlertSource = new System.Windows.Forms.BindingSource(this.components);
            this.portpolioChk = new common.control.baseCheckBox();
            this.portpolioCb = new baseClass.controls.cbPorpolio();
            this.tradeAlertStatusChk = new common.control.baseCheckBox();
            this.frDateChk = new common.control.baseCheckBox();
            this.frDateEd = new common.control.baseDate();
            this.tradeAlertStatusCb = new baseClass.controls.cbTradeAlertStatus();
            this.strategyChk = new common.control.baseCheckBox();
            this.strategyCb = new baseClass.controls.cbStrategy();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).BeginInit();
            this.SuspendLayout();
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // onTimeDataGridViewTextBoxColumn
            // 
            this.onTimeDataGridViewTextBoxColumn.DataPropertyName = "onTime";
            this.onTimeDataGridViewTextBoxColumn.HeaderText = "onTime";
            this.onTimeDataGridViewTextBoxColumn.Name = "onTimeDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // tradeActionDataGridViewTextBoxColumn
            // 
            this.tradeActionDataGridViewTextBoxColumn.DataPropertyName = "tradeAction";
            this.tradeActionDataGridViewTextBoxColumn.HeaderText = "tradeAction";
            this.tradeActionDataGridViewTextBoxColumn.Name = "tradeActionDataGridViewTextBoxColumn";
            // 
            // portpolioDataGridViewTextBoxColumn
            // 
            this.portpolioDataGridViewTextBoxColumn.DataPropertyName = "portpolio";
            this.portpolioDataGridViewTextBoxColumn.HeaderText = "portpolio";
            this.portpolioDataGridViewTextBoxColumn.Name = "portpolioDataGridViewTextBoxColumn";
            // 
            // stockCodeDataGridViewTextBoxColumn
            // 
            this.stockCodeDataGridViewTextBoxColumn.DataPropertyName = "stockCode";
            this.stockCodeDataGridViewTextBoxColumn.HeaderText = "stockCode";
            this.stockCodeDataGridViewTextBoxColumn.Name = "stockCodeDataGridViewTextBoxColumn";
            // 
            // strategyDataGridViewTextBoxColumn
            // 
            this.strategyDataGridViewTextBoxColumn.DataPropertyName = "strategy";
            this.strategyDataGridViewTextBoxColumn.HeaderText = "strategy";
            this.strategyDataGridViewTextBoxColumn.Name = "strategyDataGridViewTextBoxColumn";
            // 
            // subjectDataGridViewTextBoxColumn
            // 
            this.subjectDataGridViewTextBoxColumn.DataPropertyName = "subject";
            this.subjectDataGridViewTextBoxColumn.HeaderText = "subject";
            this.subjectDataGridViewTextBoxColumn.Name = "subjectDataGridViewTextBoxColumn";
            // 
            // msgDataGridViewTextBoxColumn
            // 
            this.msgDataGridViewTextBoxColumn.DataPropertyName = "msg";
            this.msgDataGridViewTextBoxColumn.HeaderText = "msg";
            this.msgDataGridViewTextBoxColumn.Name = "msgDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // portpolioChk
            // 
            this.portpolioChk.AutoSize = true;
            this.portpolioChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portpolioChk.Location = new System.Drawing.Point(96, 4);
            this.portpolioChk.Name = "portpolioChk";
            this.portpolioChk.Size = new System.Drawing.Size(85, 20);
            this.portpolioChk.TabIndex = 9;
            this.portpolioChk.Text = "Portpolio";
            this.portpolioChk.UseVisualStyleBackColor = true;
            this.portpolioChk.CheckedChanged += new System.EventHandler(this.portpolioChk_CheckedChanged);
            // 
            // portpolioCb
            // 
            this.portpolioCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portpolioCb.Enabled = false;
            this.portpolioCb.FormattingEnabled = true;
            this.portpolioCb.Location = new System.Drawing.Point(94, 25);
            this.portpolioCb.myValue = "";
            this.portpolioCb.Name = "portpolioCb";
            this.portpolioCb.Size = new System.Drawing.Size(130, 24);
            this.portpolioCb.TabIndex = 10;
            // 
            // tradeAlertStatusChk
            // 
            this.tradeAlertStatusChk.AutoSize = true;
            this.tradeAlertStatusChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tradeAlertStatusChk.Location = new System.Drawing.Point(1, 4);
            this.tradeAlertStatusChk.Name = "tradeAlertStatusChk";
            this.tradeAlertStatusChk.Size = new System.Drawing.Size(93, 20);
            this.tradeAlertStatusChk.TabIndex = 7;
            this.tradeAlertStatusChk.Text = "Trạng thái";
            this.tradeAlertStatusChk.UseVisualStyleBackColor = true;
            this.tradeAlertStatusChk.CheckedChanged += new System.EventHandler(this.tradeAlertStatusChk_CheckedChanged);
            // 
            // frDateChk
            // 
            this.frDateChk.AutoSize = true;
            this.frDateChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frDateChk.Location = new System.Drawing.Point(396, 4);
            this.frDateChk.Name = "frDateChk";
            this.frDateChk.Size = new System.Drawing.Size(87, 20);
            this.frDateChk.TabIndex = 13;
            this.frDateChk.Text = "Sau ngày";
            this.frDateChk.UseVisualStyleBackColor = true;
            this.frDateChk.CheckedChanged += new System.EventHandler(this.frDateChk_CheckedChanged);
            // 
            // frDateEd
            // 
            this.frDateEd.BeepOnError = true;
            this.frDateEd.Enabled = false;
            this.frDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.frDateEd.Location = new System.Drawing.Point(394, 25);
            this.frDateEd.Mask = "00/00/0000";
            this.frDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.frDateEd.Name = "frDateEd";
            this.frDateEd.Size = new System.Drawing.Size(95, 26);
            this.frDateEd.TabIndex = 14;
            // 
            // tradeAlertStatusCb
            // 
            this.tradeAlertStatusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tradeAlertStatusCb.Enabled = false;
            this.tradeAlertStatusCb.FormattingEnabled = true;
            this.tradeAlertStatusCb.Location = new System.Drawing.Point(0, 25);
            this.tradeAlertStatusCb.myValue = application.myTypes.commonStatus.None;
            this.tradeAlertStatusCb.Name = "tradeAlertStatusCb";
            this.tradeAlertStatusCb.SelectedValue = ((byte)(0));
            this.tradeAlertStatusCb.Size = new System.Drawing.Size(96, 24);
            this.tradeAlertStatusCb.TabIndex = 8;
            // 
            // strategyChk
            // 
            this.strategyChk.AutoSize = true;
            this.strategyChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyChk.Location = new System.Drawing.Point(224, 4);
            this.strategyChk.Name = "strategyChk";
            this.strategyChk.Size = new System.Drawing.Size(93, 20);
            this.strategyChk.TabIndex = 11;
            this.strategyChk.Text = "Chiến lược";
            this.strategyChk.UseVisualStyleBackColor = true;
            this.strategyChk.CheckedChanged += new System.EventHandler(this.strategyChk_CheckedChanged);
            // 
            // strategyCb
            // 
            this.strategyCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.strategyCb.Enabled = false;
            this.strategyCb.FormattingEnabled = true;
            this.strategyCb.Location = new System.Drawing.Point(223, 25);
            this.strategyCb.myValue = "";
            this.strategyCb.Name = "strategyCb";
            this.strategyCb.Size = new System.Drawing.Size(172, 24);
            this.strategyCb.TabIndex = 12;
            // 
            // tradeAlertCriteria
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.strategyChk);
            this.Controls.Add(this.strategyCb);
            this.Controls.Add(this.portpolioChk);
            this.Controls.Add(this.portpolioCb);
            this.Controls.Add(this.tradeAlertStatusChk);
            this.Controls.Add(this.frDateChk);
            this.Controls.Add(this.frDateEd);
            this.Controls.Add(this.tradeAlertStatusCb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "tradeAlertCriteria";
            this.Size = new System.Drawing.Size(493, 48);
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox commonNameEd;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn onTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tradeActionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn portpolioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn strategyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn msgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource tradeAlertSource;
        protected common.control.baseCheckBox portpolioChk;
        protected baseClass.controls.cbPorpolio portpolioCb;
        protected common.control.baseCheckBox tradeAlertStatusChk;
        protected common.control.baseCheckBox frDateChk;
        protected common.control.baseDate frDateEd;
        protected baseClass.controls.cbTradeAlertStatus tradeAlertStatusCb;
        protected common.control.baseCheckBox strategyChk;
        protected baseClass.controls.cbStrategy strategyCb;
    }
}
