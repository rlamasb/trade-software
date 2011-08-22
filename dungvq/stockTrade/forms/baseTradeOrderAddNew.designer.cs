namespace stockTrade.forms
{
    partial class baseTradeOrderAddNew
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.myTransHistoryTbl)).BeginInit();
            this.toolPnl.SuspendLayout();
            this.editGB1.SuspendLayout();
            this.editGB2.SuspendLayout();
            this.SuspendLayout();
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(610, 12);
            this.myToolTip.SetToolTip(this.printBtn, "In");
            this.printBtn.Visible = false;
            // 
            // toolPnl
            // 
            this.toolPnl.Location = new System.Drawing.Point(-30, 0);
            this.toolPnl.Size = new System.Drawing.Size(819, 48);
            this.toolPnl.Controls.SetChildIndex(this.saveBtn, 0);
            this.toolPnl.Controls.SetChildIndex(this.newBtn, 0);
            this.toolPnl.Controls.SetChildIndex(this.findBtn, 0);
            this.toolPnl.Controls.SetChildIndex(this.cancelBtn, 0);
            this.toolPnl.Controls.SetChildIndex(this.printBtn, 0);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(594, 104);
            this.myToolTip.SetToolTip(this.findBtn, "Tìm kiếm");
            this.findBtn.Visible = false;
            // 
            // newBtn
            // 
            this.newBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newBtn.Location = new System.Drawing.Point(31, 2);
            this.newBtn.Size = new System.Drawing.Size(117, 40);
            this.newBtn.Text = "Thêm mới ";
            this.myToolTip.SetToolTip(this.newBtn, "Giao dịch mới ");
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = true;
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveBtn.Location = new System.Drawing.Point(148, 1);
            this.saveBtn.Size = new System.Drawing.Size(117, 40);
            this.saveBtn.Text = "Thực hiện";
            this.myToolTip.SetToolTip(this.saveBtn, "Lưu");
            // 
            // cancelBtn
            // 
            this.cancelBtn.Enabled = true;
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancelBtn.Location = new System.Drawing.Point(265, 1);
            this.cancelBtn.Size = new System.Drawing.Size(117, 40);
            this.cancelBtn.Text = "Không ";
            this.myToolTip.SetToolTip(this.cancelBtn, "Hủy giao dịch mới ");
            // 
            // editGB1
            // 
            this.editGB1.Location = new System.Drawing.Point(0, 217);
            this.editGB1.TabIndex = 2;
            // 
            // editGB2
            // 
            this.editGB2.Location = new System.Drawing.Point(0, 45);
            this.editGB2.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "tickerCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // baseTradeOrderAddNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 384);
            this.Name = "baseTradeOrderAddNew";
            this.Text = "New trade order";
            ((System.ComponentModel.ISupportInitialize)(this.myTransHistoryTbl)).EndInit();
            this.toolPnl.ResumeLayout(false);
            this.editGB1.ResumeLayout(false);
            this.editGB1.PerformLayout();
            this.editGB2.ResumeLayout(false);
            this.editGB2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

    }
}