namespace baseClass.forms
{
    partial class subSectorSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(subSectorSelectionForm));
            this.codeSelection = new baseClass.controls.subSectorSelect();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(403, 380);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(327, 380);
            // 
            // codeSelection
            // 
            this.codeSelection.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeSelection.Location = new System.Drawing.Point(0, 0);
            this.codeSelection.Margin = new System.Windows.Forms.Padding(2);
            this.codeSelection.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("codeSelection.myCheckedValues")));
            this.codeSelection.myItemString = "";
            this.codeSelection.Name = "codeSelection";
            this.codeSelection.ShowCheckedOnly = false;
            this.codeSelection.Size = new System.Drawing.Size(469, 390);
            this.codeSelection.TabIndex = 145;
            // 
            // subSectorSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 433);
            this.Controls.Add(this.codeSelection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "subSectorSelectionForm";
            this.Text = "Chon ma nganh/ Subsector selection";
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.codeSelection, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.subSectorSelect codeSelection;
    }
}