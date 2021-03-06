namespace common.controls
{
    partial class dateOrderRange
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
            this.dateRangeCb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toDateEd = new System.Windows.Forms.MaskedTextBox();
            this.frDateEd = new System.Windows.Forms.MaskedTextBox();
            this.toDateLbl = new System.Windows.Forms.Label();
            this.frDateLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateRangeCb
            // 
            this.dateRangeCb.DisplayMember = "sysCode";
            this.dateRangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dateRangeCb.FormattingEnabled = true;
            this.dateRangeCb.Items.AddRange(new object[] {
            "Tháng trước",
            "Tuần trước",
            "Ngày truớc",
            "Hôm nay",
            "Tuần này",
            "Tháng này",
            "Ngày",
            "Tùy chọn"});
            this.dateRangeCb.Location = new System.Drawing.Point(0, 22);
            this.dateRangeCb.Margin = new System.Windows.Forms.Padding(4);
            this.dateRangeCb.MaxDropDownItems = 20;
            this.dateRangeCb.Name = "dateRangeCb";
            this.dateRangeCb.Size = new System.Drawing.Size(113, 24);
            this.dateRangeCb.TabIndex = 87;
            this.dateRangeCb.SelectedIndexChanged += new System.EventHandler(this.dateRangeCb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-3, 1);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 92;
            this.label5.Text = "Thời gian";
            // 
            // toDateEd
            // 
            this.toDateEd.Enabled = false;
            this.toDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.toDateEd.Location = new System.Drawing.Point(212, 22);
            this.toDateEd.Mask = "00/00/0000";
            this.toDateEd.Name = "toDateEd";
            this.toDateEd.Size = new System.Drawing.Size(100, 24);
            this.toDateEd.TabIndex = 89;
            this.toDateEd.ValidatingType = typeof(System.DateTime);
            this.toDateEd.Enter += new System.EventHandler(this.toDateEd_Enter);
            // 
            // frDateEd
            // 
            this.frDateEd.Enabled = false;
            this.frDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.frDateEd.Location = new System.Drawing.Point(113, 22);
            this.frDateEd.Mask = "00/00/0000";
            this.frDateEd.Name = "frDateEd";
            this.frDateEd.Size = new System.Drawing.Size(100, 24);
            this.frDateEd.TabIndex = 88;
            this.frDateEd.ValidatingType = typeof(System.DateTime);
            this.frDateEd.Enter += new System.EventHandler(this.frDateEd_Enter);
            // 
            // toDateLbl
            // 
            this.toDateLbl.AutoSize = true;
            this.toDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDateLbl.Location = new System.Drawing.Point(213, 1);
            this.toDateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.toDateLbl.Name = "toDateLbl";
            this.toDateLbl.Size = new System.Drawing.Size(70, 18);
            this.toDateLbl.TabIndex = 91;
            this.toDateLbl.Text = "Đến ngày";
            // 
            // frDateLbl
            // 
            this.frDateLbl.AutoSize = true;
            this.frDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frDateLbl.Location = new System.Drawing.Point(113, 1);
            this.frDateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.frDateLbl.Name = "frDateLbl";
            this.frDateLbl.Size = new System.Drawing.Size(60, 18);
            this.frDateLbl.TabIndex = 90;
            this.frDateLbl.Text = "Từ ngày";
            // 
            // dateOrderRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateRangeCb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.toDateEd);
            this.Controls.Add(this.frDateEd);
            this.Controls.Add(this.toDateLbl);
            this.Controls.Add(this.frDateLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "dateOrderRange";
            this.Size = new System.Drawing.Size(314, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ComboBox dateRangeCb;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.MaskedTextBox toDateEd;
        protected System.Windows.Forms.MaskedTextBox frDateEd;
        protected System.Windows.Forms.Label toDateLbl;
        protected System.Windows.Forms.Label frDateLbl;


    }
}
