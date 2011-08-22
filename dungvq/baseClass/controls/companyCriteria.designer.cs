namespace baseClass.controls
{
    partial class companyCriteria
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
            this.commCodeEd = new common.control.baseTextBox();
            this.address1Ed = new common.control.baseTextBox();
            this.nameEd = new common.control.baseTextBox();
            this.tickerCodeEd = new common.control.baseTextBox();
            this.stockExchangeChk = new baseClass.controls.baseCheckBox();
            this.stockExchangeCb = new baseClass.controls.cbStockExchange();
            this.tickerCodeChk = new baseClass.controls.baseCheckBox();
            this.nameChk = new baseClass.controls.baseCheckBox();
            this.address1Chk = new baseClass.controls.baseCheckBox();
            this.commCodeChk = new baseClass.controls.baseCheckBox();
            this.SuspendLayout();
            // 
            // commCodeEd
            // 
            this.commCodeEd.BackColor = System.Drawing.Color.White;
            this.commCodeEd.Enabled = false;
            this.commCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commCodeEd.ForeColor = System.Drawing.Color.Black;
            this.commCodeEd.Location = new System.Drawing.Point(0, 25);
            this.commCodeEd.Name = "commCodeEd";
            this.commCodeEd.Size = new System.Drawing.Size(131, 24);
            this.commCodeEd.TabIndex = 2;
            // 
            // address1Ed
            // 
            this.address1Ed.Enabled = false;
            this.address1Ed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Ed.Location = new System.Drawing.Point(196, 78);
            this.address1Ed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.address1Ed.Name = "address1Ed";
            this.address1Ed.Size = new System.Drawing.Size(194, 22);
            this.address1Ed.TabIndex = 10;
            // 
            // nameEd
            // 
            this.nameEd.Enabled = false;
            this.nameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameEd.Location = new System.Drawing.Point(-1, 78);
            this.nameEd.Name = "nameEd";
            this.nameEd.Size = new System.Drawing.Size(197, 22);
            this.nameEd.TabIndex = 8;
            // 
            // tickerCodeEd
            // 
            this.tickerCodeEd.BackColor = System.Drawing.Color.White;
            this.tickerCodeEd.Enabled = false;
            this.tickerCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickerCodeEd.ForeColor = System.Drawing.Color.Black;
            this.tickerCodeEd.Location = new System.Drawing.Point(261, 25);
            this.tickerCodeEd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tickerCodeEd.Name = "tickerCodeEd";
            this.tickerCodeEd.Size = new System.Drawing.Size(131, 24);
            this.tickerCodeEd.TabIndex = 6;
            // 
            // stockExchangeChk
            // 
            this.stockExchangeChk.AutoSize = true;
            this.stockExchangeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockExchangeChk.Location = new System.Drawing.Point(130, 2);
            this.stockExchangeChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stockExchangeChk.Name = "stockExchangeChk";
            this.stockExchangeChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stockExchangeChk.Size = new System.Drawing.Size(112, 20);
            this.stockExchangeChk.TabIndex = 3;
            this.stockExchangeChk.Text = "Sàn giao dịch";
            this.stockExchangeChk.UseVisualStyleBackColor = true;
            this.stockExchangeChk.CheckedChanged += new System.EventHandler(this.stockExchangeChk_CheckedChanged);
            // 
            // stockExchangeCb
            // 
            this.stockExchangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockExchangeCb.Enabled = false;
            this.stockExchangeCb.FormattingEnabled = true;
            this.stockExchangeCb.Location = new System.Drawing.Point(131, 25);
            this.stockExchangeCb.Margin = new System.Windows.Forms.Padding(2);
            this.stockExchangeCb.myValue = "";
            this.stockExchangeCb.Name = "stockExchangeCb";
            this.stockExchangeCb.Size = new System.Drawing.Size(131, 24);
            this.stockExchangeCb.TabIndex = 4;
            // 
            // tickerCodeChk
            // 
            this.tickerCodeChk.AutoSize = true;
            this.tickerCodeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickerCodeChk.Location = new System.Drawing.Point(259, 2);
            this.tickerCodeChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tickerCodeChk.Name = "tickerCodeChk";
            this.tickerCodeChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tickerCodeChk.Size = new System.Drawing.Size(77, 20);
            this.tickerCodeChk.TabIndex = 5;
            this.tickerCodeChk.Text = "Mã hiệu";
            this.tickerCodeChk.UseVisualStyleBackColor = true;
            this.tickerCodeChk.CheckedChanged += new System.EventHandler(this.tickerCodeChk_CheckedChanged);
            // 
            // nameChk
            // 
            this.nameChk.AutoSize = true;
            this.nameChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameChk.Location = new System.Drawing.Point(0, 55);
            this.nameChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nameChk.Name = "nameChk";
            this.nameChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nameChk.Size = new System.Drawing.Size(54, 20);
            this.nameChk.TabIndex = 7;
            this.nameChk.Text = "Tên ";
            this.nameChk.UseVisualStyleBackColor = true;
            this.nameChk.CheckedChanged += new System.EventHandler(this.nameChk_CheckedChanged);
            // 
            // address1Chk
            // 
            this.address1Chk.AutoSize = true;
            this.address1Chk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Chk.Location = new System.Drawing.Point(195, 55);
            this.address1Chk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.address1Chk.Name = "address1Chk";
            this.address1Chk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.address1Chk.Size = new System.Drawing.Size(70, 20);
            this.address1Chk.TabIndex = 9;
            this.address1Chk.Text = "Địa chỉ";
            this.address1Chk.UseVisualStyleBackColor = true;
            this.address1Chk.CheckedChanged += new System.EventHandler(this.address1Chk_CheckedChanged);
            // 
            // commCodeChk
            // 
            this.commCodeChk.AutoSize = true;
            this.commCodeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commCodeChk.Location = new System.Drawing.Point(0, 2);
            this.commCodeChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.commCodeChk.Name = "commCodeChk";
            this.commCodeChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.commCodeChk.Size = new System.Drawing.Size(99, 20);
            this.commCodeChk.TabIndex = 1;
            this.commCodeChk.Text = "Mã công ty";
            this.commCodeChk.UseVisualStyleBackColor = true;
            this.commCodeChk.CheckedChanged += new System.EventHandler(this.commCodeChk_CheckedChanged);
            // 
            // companyCriteria
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.stockExchangeChk);
            this.Controls.Add(this.stockExchangeCb);
            this.Controls.Add(this.tickerCodeChk);
            this.Controls.Add(this.tickerCodeEd);
            this.Controls.Add(this.nameChk);
            this.Controls.Add(this.address1Chk);
            this.Controls.Add(this.address1Ed);
            this.Controls.Add(this.nameEd);
            this.Controls.Add(this.commCodeChk);
            this.Controls.Add(this.commCodeEd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "companyCriteria";
            this.Size = new System.Drawing.Size(390, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox commonNameEd;
        protected baseClass.controls.baseCheckBox commCodeChk;
        protected baseClass.controls.baseCheckBox address1Chk;
        protected common.control.baseTextBox commCodeEd;
        protected common.control.baseTextBox nameEd;
        protected common.control.baseTextBox address1Ed;
        protected baseClass.controls.baseCheckBox nameChk;
        protected baseCheckBox tickerCodeChk;
        protected common.control.baseTextBox tickerCodeEd;
        protected cbStockExchange stockExchangeCb;
        protected baseCheckBox stockExchangeChk;
    }
}
