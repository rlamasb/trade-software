namespace baseClass.controls
{
    partial class chartTiming
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
            this.frDateEd = new common.control.baseDate();
            this.toDateEd = new common.control.baseDate();
            this.okBtn = new baseClass.controls.baseButton();
            this.timeScaleCb = new baseClass.controls.cbTimeScale();
            this.timeRangeCb = new baseClass.controls.cbTimeRange();
            this.SuspendLayout();
            // 
            // frDateEd
            // 
            this.frDateEd.BeepOnError = true;
            this.frDateEd.Enabled = false;
            this.frDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.frDateEd.Location = new System.Drawing.Point(104, 0);
            this.frDateEd.Mask = "00/00/0000";
            this.frDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.frDateEd.Name = "frDateEd";
            this.frDateEd.Size = new System.Drawing.Size(83, 24);
            this.frDateEd.TabIndex = 1;
            // 
            // toDateEd
            // 
            this.toDateEd.BeepOnError = true;
            this.toDateEd.Enabled = false;
            this.toDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.toDateEd.Location = new System.Drawing.Point(187, 0);
            this.toDateEd.Mask = "00/00/0000";
            this.toDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.toDateEd.Name = "toDateEd";
            this.toDateEd.Size = new System.Drawing.Size(83, 24);
            this.toDateEd.TabIndex = 2;
            // 
            // okBtn
            // 
            this.okBtn.Enabled = false;
            this.okBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Image = global::baseClass.Properties.Resources.run;
            this.okBtn.Location = new System.Drawing.Point(363, -1);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(25, 23);
            this.okBtn.TabIndex = 10;
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // timeScaleCb
            // 
            this.timeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeScaleCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeScaleCb.FormattingEnabled = true;
            this.timeScaleCb.Location = new System.Drawing.Point(271, 0);
            this.timeScaleCb.Name = "timeScaleCb";
            this.timeScaleCb.SelectedValue = ((byte)(0));
            this.timeScaleCb.Size = new System.Drawing.Size(95, 24);
            this.timeScaleCb.TabIndex = 3;
            this.timeScaleCb.SelectedIndexChanged += new System.EventHandler(this.timing_Changed);
            // 
            // timeRangeCb
            // 
            this.timeRangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeRangeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeRangeCb.FormattingEnabled = true;
            this.timeRangeCb.Location = new System.Drawing.Point(2, 0);
            this.timeRangeCb.myValue = application.myTypes.timeRanges.None;
            this.timeRangeCb.Name = "timeRangeCb";
            this.timeRangeCb.SelectedValue = ((byte)(0));
            this.timeRangeCb.Size = new System.Drawing.Size(103, 23);
            this.timeRangeCb.TabIndex = 11;
            this.timeRangeCb.SelectedIndexChanged += new System.EventHandler(this.timing_Changed);
            // 
            // chartTiming
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.timeRangeCb);
            this.Controls.Add(this.timeScaleCb);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.toDateEd);
            this.Controls.Add(this.frDateEd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "chartTiming";
            this.Size = new System.Drawing.Size(392, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox commonNameEd;
        private common.control.baseDate frDateEd;
        private common.control.baseDate toDateEd;
        private baseButton okBtn;
        protected cbTimeScale timeScaleCb;
        protected cbTimeRange timeRangeCb;
    }
}
