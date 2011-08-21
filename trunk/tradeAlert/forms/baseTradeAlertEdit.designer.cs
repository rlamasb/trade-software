namespace tradeAlert.forms
{
    partial class baseTradeAlertEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseTradeAlertEdit));
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderBtn = new baseClass.controls.baseButton();
            this.cancelBtn = new baseClass.controls.baseButton();
            this.dataNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.basePanel1 = new common.control.basePanel();
            this.recoverBtn = new baseClass.controls.baseButton();
            this.closeBtnq = new baseClass.controls.baseButton();
            this.tradeAlertEdit = new tradeAlert.controls.tradeAlertEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dataNavigator)).BeginInit();
            this.dataNavigator.SuspendLayout();
            this.basePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(623, 96);
            this.closeBtn.Visible = false;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(612, 132);
            this.okBtn.Visible = false;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1018, 76);
            this.TitleLbl.Size = new System.Drawing.Size(62, 46);
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
            this.dataGridViewTextBoxColumn2.DataPropertyName = "stockExchange";
            this.dataGridViewTextBoxColumn2.HeaderText = "Sàn ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "noOpenShares";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "SL niêm yết";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // orderBtn
            // 
            this.orderBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderBtn.Image = global::tradeAlert.Properties.Resources.edit;
            this.orderBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.orderBtn.Location = new System.Drawing.Point(2, 1);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Size = new System.Drawing.Size(108, 40);
            this.orderBtn.TabIndex = 10;
            this.orderBtn.Text = "Giao dịch";
            this.orderBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.orderBtn.UseVisualStyleBackColor = true;
            this.orderBtn.Click += new System.EventHandler(this.orderBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Image = global::tradeAlert.Properties.Resources.cancel;
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancelBtn.Location = new System.Drawing.Point(110, 1);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(108, 40);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Bỏ qua";
            this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // dataNavigator
            // 
            this.dataNavigator.AddNewItem = null;
            this.dataNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dataNavigator.CountItemFormat = "/ {0}";
            this.dataNavigator.DeleteItem = null;
            this.dataNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.dataNavigator.Location = new System.Drawing.Point(0, 385);
            this.dataNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dataNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dataNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dataNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dataNavigator.Name = "dataNavigator";
            this.dataNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dataNavigator.Size = new System.Drawing.Size(436, 25);
            this.dataNavigator.TabIndex = 146;
            this.dataNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(30, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(20, 22);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // basePanel1
            // 
            this.basePanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.basePanel1.Controls.Add(this.recoverBtn);
            this.basePanel1.Controls.Add(this.closeBtnq);
            this.basePanel1.Controls.Add(this.cancelBtn);
            this.basePanel1.Controls.Add(this.orderBtn);
            this.basePanel1.haveCloseButton = false;
            this.basePanel1.Location = new System.Drawing.Point(-1, 0);
            this.basePanel1.Name = "basePanel1";
            this.basePanel1.Size = new System.Drawing.Size(491, 48);
            this.basePanel1.TabIndex = 148;
            // 
            // recoverBtn
            // 
            this.recoverBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoverBtn.Image = global::tradeAlert.Properties.Resources.undo;
            this.recoverBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.recoverBtn.Location = new System.Drawing.Point(218, 1);
            this.recoverBtn.Name = "recoverBtn";
            this.recoverBtn.Size = new System.Drawing.Size(108, 40);
            this.recoverBtn.TabIndex = 13;
            this.recoverBtn.Text = "Phục hồi";
            this.recoverBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.recoverBtn.UseVisualStyleBackColor = true;
            this.recoverBtn.Click += new System.EventHandler(this.recoverBtn_Click);
            // 
            // closeBtnq
            // 
            this.closeBtnq.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtnq.Image = global::tradeAlert.Properties.Resources.close;
            this.closeBtnq.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeBtnq.Location = new System.Drawing.Point(326, 1);
            this.closeBtnq.Name = "closeBtnq";
            this.closeBtnq.Size = new System.Drawing.Size(108, 40);
            this.closeBtnq.TabIndex = 12;
            this.closeBtnq.Text = "Đóng";
            this.closeBtnq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeBtnq.UseVisualStyleBackColor = true;
            this.closeBtnq.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // tradeAlertEdit
            // 
            this.tradeAlertEdit.Location = new System.Drawing.Point(20, 51);
            this.tradeAlertEdit.Name = "tradeAlertEdit";
            this.tradeAlertEdit.Size = new System.Drawing.Size(395, 325);
            this.tradeAlertEdit.TabIndex = 145;
            // 
            // baseTradeAlertEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 433);
            this.Controls.Add(this.basePanel1);
            this.Controls.Add(this.dataNavigator);
            this.Controls.Add(this.tradeAlertEdit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = true;
            this.Name = "baseTradeAlertEdit";
            this.Text = "Trade alerts";
            this.Controls.SetChildIndex(this.tradeAlertEdit, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.dataNavigator, 0);
            this.Controls.SetChildIndex(this.basePanel1, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataNavigator)).EndInit();
            this.dataNavigator.ResumeLayout(false);
            this.dataNavigator.PerformLayout();
            this.basePanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private tradeAlert.controls.tradeAlertEdit tradeAlertEdit;
        protected baseClass.controls.baseButton orderBtn;
        protected baseClass.controls.baseButton cancelBtn;
        private System.Windows.Forms.BindingNavigator dataNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private common.control.basePanel basePanel1;
        protected baseClass.controls.baseButton closeBtnq;
        protected baseClass.controls.baseButton recoverBtn;

    }
}