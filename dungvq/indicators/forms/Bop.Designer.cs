﻿namespace Indicators.forms
{
    partial class Bop
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
            this.label1 = new System.Windows.Forms.Label();
            this.inNewPaneChk = new baseClass.controls.baseCheckBox();
            this.weightEd1 = new System.Windows.Forms.NumericUpDown();
            this.colorEd1 = new common.control.ColorComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.weightEd1)).BeginInit();
            this.SuspendLayout();
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(113, 72);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(199, 72);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(27, 72);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 160;
            this.label1.Text = "Balance of Power";
            // 
            // inNewPaneChk
            // 
            this.inNewPaneChk.AutoSize = true;
            this.inNewPaneChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inNewPaneChk.Location = new System.Drawing.Point(53, 45);
            this.inNewPaneChk.Name = "inNewPaneChk";
            this.inNewPaneChk.Size = new System.Drawing.Size(189, 20);
            this.inNewPaneChk.TabIndex = 159;
            this.inNewPaneChk.Text = "Hiển thị trong cửa sổ mới";
            this.inNewPaneChk.UseVisualStyleBackColor = true;
            // 
            // weightEd1
            // 
            this.weightEd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightEd1.Location = new System.Drawing.Point(282, 12);
            this.weightEd1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.weightEd1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.weightEd1.Name = "weightEd1";
            this.weightEd1.Size = new System.Drawing.Size(38, 26);
            this.weightEd1.TabIndex = 158;
            this.weightEd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.weightEd1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // colorEd1
            // 
            this.colorEd1.Color = System.Drawing.Color.Black;
            this.colorEd1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorEd1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorEd1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorEd1.Location = new System.Drawing.Point(135, 12);
            this.colorEd1.Name = "colorEd1";
            this.colorEd1.Size = new System.Drawing.Size(150, 27);
            this.colorEd1.TabIndex = 157;
            // 
            // Bop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 132);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inNewPaneChk);
            this.Controls.Add(this.weightEd1);
            this.Controls.Add(this.colorEd1);
            this.Name = "Bop";
            this.Text = "Bop";
            this.Controls.SetChildIndex(this.removeBtn, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.colorEd1, 0);
            this.Controls.SetChildIndex(this.weightEd1, 0);
            this.Controls.SetChildIndex(this.inNewPaneChk, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.weightEd1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        protected baseClass.controls.baseCheckBox inNewPaneChk;
        private System.Windows.Forms.NumericUpDown weightEd1;
        protected common.control.ColorComboBox colorEd1;
    }
}