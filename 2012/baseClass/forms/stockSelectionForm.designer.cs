namespace baseClass.forms
{
    partial class stockSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stockSelectionForm));
            this.codeSelection = new baseClass.controls.stockCodeSelect();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(347, 414);
            this.closeBtn.Text = "Close";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(265, 414);
            this.okBtn.Text = "Accept";
            // 
            // codeSelection
            // 
            this.codeSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.codeSelection.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeSelection.Location = new System.Drawing.Point(0, 0);
            this.codeSelection.Margin = new System.Windows.Forms.Padding(1);
            this.codeSelection.myItemString = "";
            this.codeSelection.myValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("codeSelection.myValues")));
            this.codeSelection.Name = "codeSelection";
            this.codeSelection.ShowCheckedOnly = false;
            this.codeSelection.Size = new System.Drawing.Size(456, 418);
            this.codeSelection.TabIndex = 145;
            // 
            // stockSelectionForm
            // 
            this.ClientSize = new System.Drawing.Size(456, 466);
            this.Controls.Add(this.codeSelection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "stockSelectionForm";
            this.Text = "Select stock  ";
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.codeSelection, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.stockCodeSelect codeSelection;
    }
}