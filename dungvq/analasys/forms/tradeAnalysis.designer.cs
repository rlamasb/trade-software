namespace tools.forms
{
    partial class tradeAnalysis
    {
        //common.libs.appAvailable myAvail = new common.libs.appAvailable();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tradeAnalysis));
            this.activeIndicatorLV = new common.controls.ListViewAdv();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainContainer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainContainer.Location = new System.Drawing.Point(0, 26);
            this.mainContainer.Margin = new System.Windows.Forms.Padding(1);
            this.mainContainer.Size = new System.Drawing.Size(681, 474);
            this.mainContainer.Visible = false;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(717, 47);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.TitleLbl.Size = new System.Drawing.Size(27, 24);
            // 
            // activeIndicatorLV
            // 
            this.activeIndicatorLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.activeIndicatorLV.BackColor = System.Drawing.SystemColors.Control;
            this.activeIndicatorLV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeIndicatorLV.Location = new System.Drawing.Point(0, 0);
            this.activeIndicatorLV.Margin = new System.Windows.Forms.Padding(2);
            this.activeIndicatorLV.Name = "activeIndicatorLV";
            this.activeIndicatorLV.Size = new System.Drawing.Size(682, 24);
            this.activeIndicatorLV.TabIndex = 247;
            this.activeIndicatorLV.UseCompatibleStateImageBehavior = false;
            this.activeIndicatorLV.View = System.Windows.Forms.View.SmallIcon;
            this.activeIndicatorLV.Click += new System.EventHandler(this.activeIndicatorLV_Click);
            // 
            // tradeAnalysis
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(681, 500);
            this.Controls.Add(this.activeIndicatorLV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "tradeAnalysis";
            this.Controls.SetChildIndex(this.activeIndicatorLV, 0);
            this.Controls.SetChildIndex(this.mainContainer, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private common.controls.ListViewAdv activeIndicatorLV;
    }
}