namespace Tools.Forms
{
    partial class options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(options));
            this.investmentPg = new System.Windows.Forms.TabPage();
            this.investmentGb = new System.Windows.Forms.GroupBox();
            this.percentLb2 = new baseClass.controls.baseLabel();
            this.maxBuyQtyPercEd = new common.controls.numberTextBox();
            this.maxBuyQtyPercLbl = new baseClass.controls.baseLabel();
            this.baseLabel4 = new baseClass.controls.baseLabel();
            this.maxBuyAmtPercLbl = new baseClass.controls.baseLabel();
            this.baseLabel1 = new baseClass.controls.baseLabel();
            this.totalCapitalLbl = new baseClass.controls.baseLabel();
            this.totalAmountLbl = new baseClass.controls.baseLabel();
            this.qtyReducePercLbl = new baseClass.controls.baseLabel();
            this.qtyAccumulatePercEd = new common.controls.numberTextBox();
            this.totalCapitalEd = new common.controls.numberTextBox();
            this.qtyAccumulatePercLbl = new baseClass.controls.baseLabel();
            this.qtyReducePercEd = new common.controls.numberTextBox();
            this.maxBuyAmtPercEd = new common.controls.numberTextBox();
            this.systemPg = new System.Windows.Forms.TabPage();
            this.systemGb = new System.Windows.Forms.GroupBox();
            this.volumeWeightEd = new common.controls.numberTextBox();
            this.transFeePercLbl = new baseClass.controls.baseLabel();
            this.volumeWeightLbl = new baseClass.controls.baseLabel();
            this.buy2SellIntervalLbl = new baseClass.controls.baseLabel();
            this.keepSellAdviceChk = new common.controls.baseCheckBox();
            this.priceWeightLbl = new baseClass.controls.baseLabel();
            this.percentLb1 = new baseClass.controls.baseLabel();
            this.dayLbl = new baseClass.controls.baseLabel();
            this.buy2SellIntervalEd = new System.Windows.Forms.NumericUpDown();
            this.priceWeightEd = new common.controls.numberTextBox();
            this.transFeePercEd = new common.controls.numberTextBox();
            this.optionTab = new System.Windows.Forms.TabControl();
            this.investmentPg.SuspendLayout();
            this.investmentGb.SuspendLayout();
            this.systemPg.SuspendLayout();
            this.systemGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buy2SellIntervalEd)).BeginInit();
            this.optionTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(221, 252);
            this.closeBtn.Size = new System.Drawing.Size(92, 26);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(129, 251);
            this.okBtn.Size = new System.Drawing.Size(92, 27);
            this.okBtn.Text = "Ok";
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(740, 156);
            // 
            // investmentPg
            // 
            this.investmentPg.Controls.Add(this.investmentGb);
            this.investmentPg.Location = new System.Drawing.Point(4, 25);
            this.investmentPg.Name = "investmentPg";
            this.investmentPg.Padding = new System.Windows.Forms.Padding(3);
            this.investmentPg.Size = new System.Drawing.Size(341, 277);
            this.investmentPg.TabIndex = 0;
            this.investmentPg.Text = "Investment";
            this.investmentPg.UseVisualStyleBackColor = true;
            // 
            // investmentGb
            // 
            this.investmentGb.Controls.Add(this.percentLb2);
            this.investmentGb.Controls.Add(this.maxBuyQtyPercEd);
            this.investmentGb.Controls.Add(this.maxBuyQtyPercLbl);
            this.investmentGb.Controls.Add(this.baseLabel4);
            this.investmentGb.Controls.Add(this.maxBuyAmtPercLbl);
            this.investmentGb.Controls.Add(this.baseLabel1);
            this.investmentGb.Controls.Add(this.totalCapitalLbl);
            this.investmentGb.Controls.Add(this.totalAmountLbl);
            this.investmentGb.Controls.Add(this.qtyReducePercLbl);
            this.investmentGb.Controls.Add(this.qtyAccumulatePercEd);
            this.investmentGb.Controls.Add(this.totalCapitalEd);
            this.investmentGb.Controls.Add(this.qtyAccumulatePercLbl);
            this.investmentGb.Controls.Add(this.qtyReducePercEd);
            this.investmentGb.Controls.Add(this.maxBuyAmtPercEd);
            this.investmentGb.Location = new System.Drawing.Point(8, 2);
            this.investmentGb.Name = "investmentGb";
            this.investmentGb.Size = new System.Drawing.Size(332, 219);
            this.investmentGb.TabIndex = 152;
            this.investmentGb.TabStop = false;
            // 
            // percentLb2
            // 
            this.percentLb2.AutoSize = true;
            this.percentLb2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentLb2.Location = new System.Drawing.Point(213, 160);
            this.percentLb2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.percentLb2.Name = "percentLb2";
            this.percentLb2.Size = new System.Drawing.Size(22, 16);
            this.percentLb2.TabIndex = 318;
            this.percentLb2.Text = "%";
            // 
            // maxBuyQtyPercEd
            // 
            this.maxBuyQtyPercEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxBuyQtyPercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.maxBuyQtyPercEd.Location = new System.Drawing.Point(158, 155);
            this.maxBuyQtyPercEd.myFormat = "###.##";
            this.maxBuyQtyPercEd.Name = "maxBuyQtyPercEd";
            this.maxBuyQtyPercEd.Size = new System.Drawing.Size(52, 26);
            this.maxBuyQtyPercEd.TabIndex = 316;
            this.maxBuyQtyPercEd.Text = "11";
            this.maxBuyQtyPercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maxBuyQtyPercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.maxBuyQtyPercEd.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // maxBuyQtyPercLbl
            // 
            this.maxBuyQtyPercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxBuyQtyPercLbl.Location = new System.Drawing.Point(12, 157);
            this.maxBuyQtyPercLbl.Name = "maxBuyQtyPercLbl";
            this.maxBuyQtyPercLbl.Size = new System.Drawing.Size(144, 16);
            this.maxBuyQtyPercLbl.TabIndex = 317;
            this.maxBuyQtyPercLbl.Text = "Max Buy Qty";
            this.maxBuyQtyPercLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // baseLabel4
            // 
            this.baseLabel4.AutoSize = true;
            this.baseLabel4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel4.Location = new System.Drawing.Point(212, 111);
            this.baseLabel4.Name = "baseLabel4";
            this.baseLabel4.Size = new System.Drawing.Size(22, 16);
            this.baseLabel4.TabIndex = 12;
            this.baseLabel4.Text = "%";
            // 
            // maxBuyAmtPercLbl
            // 
            this.maxBuyAmtPercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxBuyAmtPercLbl.Location = new System.Drawing.Point(9, 84);
            this.maxBuyAmtPercLbl.Name = "maxBuyAmtPercLbl";
            this.maxBuyAmtPercLbl.Size = new System.Drawing.Size(147, 16);
            this.maxBuyAmtPercLbl.TabIndex = 4;
            this.maxBuyAmtPercLbl.Text = "Max buy amount";
            this.maxBuyAmtPercLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel1.Location = new System.Drawing.Point(212, 136);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(22, 16);
            this.baseLabel1.TabIndex = 11;
            this.baseLabel1.Text = "%";
            // 
            // totalCapitalLbl
            // 
            this.totalCapitalLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCapitalLbl.Location = new System.Drawing.Point(9, 58);
            this.totalCapitalLbl.Name = "totalCapitalLbl";
            this.totalCapitalLbl.Size = new System.Drawing.Size(147, 16);
            this.totalCapitalLbl.TabIndex = 0;
            this.totalCapitalLbl.Text = "Total amount";
            this.totalCapitalLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalAmountLbl
            // 
            this.totalAmountLbl.AutoSize = true;
            this.totalAmountLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAmountLbl.Location = new System.Drawing.Point(211, 84);
            this.totalAmountLbl.Name = "totalAmountLbl";
            this.totalAmountLbl.Size = new System.Drawing.Size(110, 16);
            this.totalAmountLbl.TabIndex = 10;
            this.totalAmountLbl.Text = "% total amount";
            // 
            // qtyReducePercLbl
            // 
            this.qtyReducePercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyReducePercLbl.Location = new System.Drawing.Point(9, 110);
            this.qtyReducePercLbl.Name = "qtyReducePercLbl";
            this.qtyReducePercLbl.Size = new System.Drawing.Size(147, 16);
            this.qtyReducePercLbl.TabIndex = 2;
            this.qtyReducePercLbl.Text = "Reduce quantity";
            this.qtyReducePercLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // qtyAccumulatePercEd
            // 
            this.qtyAccumulatePercEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyAccumulatePercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.qtyAccumulatePercEd.Location = new System.Drawing.Point(158, 132);
            this.qtyAccumulatePercEd.myFormat = "###.##";
            this.qtyAccumulatePercEd.Name = "qtyAccumulatePercEd";
            this.qtyAccumulatePercEd.Size = new System.Drawing.Size(52, 26);
            this.qtyAccumulatePercEd.TabIndex = 4;
            this.qtyAccumulatePercEd.Text = "10";
            this.qtyAccumulatePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.qtyAccumulatePercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.qtyAccumulatePercEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // totalCapitalEd
            // 
            this.totalCapitalEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCapitalEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.totalCapitalEd.Location = new System.Drawing.Point(158, 53);
            this.totalCapitalEd.myFormat = "###,###,###,###,###";
            this.totalCapitalEd.Name = "totalCapitalEd";
            this.totalCapitalEd.Size = new System.Drawing.Size(143, 26);
            this.totalCapitalEd.TabIndex = 1;
            this.totalCapitalEd.Text = "10,000,000";
            this.totalCapitalEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.totalCapitalEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.totalCapitalEd.Value = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            // 
            // qtyAccumulatePercLbl
            // 
            this.qtyAccumulatePercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyAccumulatePercLbl.Location = new System.Drawing.Point(9, 136);
            this.qtyAccumulatePercLbl.Name = "qtyAccumulatePercLbl";
            this.qtyAccumulatePercLbl.Size = new System.Drawing.Size(147, 16);
            this.qtyAccumulatePercLbl.TabIndex = 8;
            this.qtyAccumulatePercLbl.Text = "Accumulate quantity";
            this.qtyAccumulatePercLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // qtyReducePercEd
            // 
            this.qtyReducePercEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyReducePercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.qtyReducePercEd.Location = new System.Drawing.Point(158, 106);
            this.qtyReducePercEd.myFormat = "###.##";
            this.qtyReducePercEd.Name = "qtyReducePercEd";
            this.qtyReducePercEd.Size = new System.Drawing.Size(52, 26);
            this.qtyReducePercEd.TabIndex = 3;
            this.qtyReducePercEd.Text = "10";
            this.qtyReducePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.qtyReducePercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.qtyReducePercEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // maxBuyAmtPercEd
            // 
            this.maxBuyAmtPercEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxBuyAmtPercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.maxBuyAmtPercEd.Location = new System.Drawing.Point(158, 80);
            this.maxBuyAmtPercEd.myFormat = "###.##";
            this.maxBuyAmtPercEd.Name = "maxBuyAmtPercEd";
            this.maxBuyAmtPercEd.Size = new System.Drawing.Size(52, 26);
            this.maxBuyAmtPercEd.TabIndex = 2;
            this.maxBuyAmtPercEd.Text = "10";
            this.maxBuyAmtPercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maxBuyAmtPercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.maxBuyAmtPercEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // systemPg
            // 
            this.systemPg.Controls.Add(this.systemGb);
            this.systemPg.Location = new System.Drawing.Point(4, 25);
            this.systemPg.Name = "systemPg";
            this.systemPg.Padding = new System.Windows.Forms.Padding(3);
            this.systemPg.Size = new System.Drawing.Size(341, 277);
            this.systemPg.TabIndex = 1;
            this.systemPg.Text = "System";
            this.systemPg.UseVisualStyleBackColor = true;
            // 
            // systemGb
            // 
            this.systemGb.Controls.Add(this.volumeWeightEd);
            this.systemGb.Controls.Add(this.transFeePercLbl);
            this.systemGb.Controls.Add(this.volumeWeightLbl);
            this.systemGb.Controls.Add(this.buy2SellIntervalLbl);
            this.systemGb.Controls.Add(this.keepSellAdviceChk);
            this.systemGb.Controls.Add(this.priceWeightLbl);
            this.systemGb.Controls.Add(this.percentLb1);
            this.systemGb.Controls.Add(this.dayLbl);
            this.systemGb.Controls.Add(this.buy2SellIntervalEd);
            this.systemGb.Controls.Add(this.priceWeightEd);
            this.systemGb.Controls.Add(this.transFeePercEd);
            this.systemGb.Location = new System.Drawing.Point(8, 2);
            this.systemGb.Name = "systemGb";
            this.systemGb.Size = new System.Drawing.Size(332, 220);
            this.systemGb.TabIndex = 151;
            this.systemGb.TabStop = false;
            // 
            // volumeWeightEd
            // 
            this.volumeWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeWeightEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.volumeWeightEd.Location = new System.Drawing.Point(159, 145);
            this.volumeWeightEd.myFormat = "###,###,###,###,###";
            this.volumeWeightEd.Name = "volumeWeightEd";
            this.volumeWeightEd.Size = new System.Drawing.Size(72, 24);
            this.volumeWeightEd.TabIndex = 10;
            this.volumeWeightEd.TabStop = false;
            this.volumeWeightEd.Text = "10";
            this.volumeWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.volumeWeightEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.volumeWeightEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // transFeePercLbl
            // 
            this.transFeePercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transFeePercLbl.Location = new System.Drawing.Point(13, 53);
            this.transFeePercLbl.Name = "transFeePercLbl";
            this.transFeePercLbl.Size = new System.Drawing.Size(144, 16);
            this.transFeePercLbl.TabIndex = 305;
            this.transFeePercLbl.Text = "Transaction fee";
            this.transFeePercLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // volumeWeightLbl
            // 
            this.volumeWeightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeWeightLbl.Location = new System.Drawing.Point(13, 148);
            this.volumeWeightLbl.Name = "volumeWeightLbl";
            this.volumeWeightLbl.Size = new System.Drawing.Size(144, 16);
            this.volumeWeightLbl.TabIndex = 314;
            this.volumeWeightLbl.Text = "Quantity ratio";
            this.volumeWeightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buy2SellIntervalLbl
            // 
            this.buy2SellIntervalLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buy2SellIntervalLbl.Location = new System.Drawing.Point(13, 76);
            this.buy2SellIntervalLbl.Name = "buy2SellIntervalLbl";
            this.buy2SellIntervalLbl.Size = new System.Drawing.Size(144, 16);
            this.buy2SellIntervalLbl.TabIndex = 306;
            this.buy2SellIntervalLbl.Text = "Only sell after";
            this.buy2SellIntervalLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // keepSellAdviceChk
            // 
            this.keepSellAdviceChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keepSellAdviceChk.Location = new System.Drawing.Point(8, 99);
            this.keepSellAdviceChk.Name = "keepSellAdviceChk";
            this.keepSellAdviceChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.keepSellAdviceChk.Size = new System.Drawing.Size(165, 18);
            this.keepSellAdviceChk.TabIndex = 8;
            this.keepSellAdviceChk.Text = "Keep Buy advice";
            this.keepSellAdviceChk.UseVisualStyleBackColor = true;
            // 
            // priceWeightLbl
            // 
            this.priceWeightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceWeightLbl.Location = new System.Drawing.Point(13, 124);
            this.priceWeightLbl.Name = "priceWeightLbl";
            this.priceWeightLbl.Size = new System.Drawing.Size(144, 16);
            this.priceWeightLbl.TabIndex = 307;
            this.priceWeightLbl.Text = "Price ratio";
            this.priceWeightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // percentLb1
            // 
            this.percentLb1.AutoSize = true;
            this.percentLb1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentLb1.Location = new System.Drawing.Point(241, 52);
            this.percentLb1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.percentLb1.Name = "percentLb1";
            this.percentLb1.Size = new System.Drawing.Size(22, 16);
            this.percentLb1.TabIndex = 311;
            this.percentLb1.Text = "%";
            // 
            // dayLbl
            // 
            this.dayLbl.AutoSize = true;
            this.dayLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayLbl.Location = new System.Drawing.Point(237, 80);
            this.dayLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dayLbl.Name = "dayLbl";
            this.dayLbl.Size = new System.Drawing.Size(39, 16);
            this.dayLbl.TabIndex = 308;
            this.dayLbl.Text = "days";
            // 
            // buy2SellIntervalEd
            // 
            this.buy2SellIntervalEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buy2SellIntervalEd.Location = new System.Drawing.Point(159, 73);
            this.buy2SellIntervalEd.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.buy2SellIntervalEd.Name = "buy2SellIntervalEd";
            this.buy2SellIntervalEd.Size = new System.Drawing.Size(72, 26);
            this.buy2SellIntervalEd.TabIndex = 2;
            this.buy2SellIntervalEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.buy2SellIntervalEd.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // priceWeightEd
            // 
            this.priceWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceWeightEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.priceWeightEd.Location = new System.Drawing.Point(159, 120);
            this.priceWeightEd.myFormat = "###,###,###,###,###";
            this.priceWeightEd.Name = "priceWeightEd";
            this.priceWeightEd.Size = new System.Drawing.Size(72, 24);
            this.priceWeightEd.TabIndex = 9;
            this.priceWeightEd.TabStop = false;
            this.priceWeightEd.Text = "1,000";
            this.priceWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.priceWeightEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.priceWeightEd.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // transFeePercEd
            // 
            this.transFeePercEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transFeePercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.transFeePercEd.Location = new System.Drawing.Point(159, 49);
            this.transFeePercEd.myFormat = "###,###.##";
            this.transFeePercEd.Name = "transFeePercEd";
            this.transFeePercEd.Size = new System.Drawing.Size(72, 24);
            this.transFeePercEd.TabIndex = 1;
            this.transFeePercEd.TabStop = false;
            this.transFeePercEd.Text = ".2";
            this.transFeePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.transFeePercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.transFeePercEd.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // optionTab
            // 
            this.optionTab.Controls.Add(this.systemPg);
            this.optionTab.Controls.Add(this.investmentPg);
            this.optionTab.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionTab.Location = new System.Drawing.Point(-6, 0);
            this.optionTab.Name = "optionTab";
            this.optionTab.SelectedIndex = 0;
            this.optionTab.Size = new System.Drawing.Size(349, 306);
            this.optionTab.TabIndex = 150;
            // 
            // options
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(343, 305);
            this.Controls.Add(this.optionTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "options";
            this.Text = "Options";
            this.Controls.SetChildIndex(this.optionTab, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.investmentPg.ResumeLayout(false);
            this.investmentGb.ResumeLayout(false);
            this.investmentGb.PerformLayout();
            this.systemPg.ResumeLayout(false);
            this.systemGb.ResumeLayout(false);
            this.systemGb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buy2SellIntervalEd)).EndInit();
            this.optionTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage investmentPg;
        private baseClass.controls.baseLabel baseLabel4;
        private baseClass.controls.baseLabel baseLabel1;
        private baseClass.controls.baseLabel totalAmountLbl;
        private common.controls.numberTextBox qtyAccumulatePercEd;
        private baseClass.controls.baseLabel qtyAccumulatePercLbl;
        private common.controls.numberTextBox maxBuyAmtPercEd;
        private baseClass.controls.baseLabel maxBuyAmtPercLbl;
        private common.controls.numberTextBox qtyReducePercEd;
        private common.controls.numberTextBox totalCapitalEd;
        private baseClass.controls.baseLabel qtyReducePercLbl;
        private baseClass.controls.baseLabel totalCapitalLbl;
        private System.Windows.Forms.TabPage systemPg;
        protected common.controls.numberTextBox volumeWeightEd;
        protected baseClass.controls.baseLabel volumeWeightLbl;
        private common.controls.baseCheckBox keepSellAdviceChk;
        protected baseClass.controls.baseLabel percentLb1;
        private System.Windows.Forms.NumericUpDown buy2SellIntervalEd;
        protected common.controls.numberTextBox transFeePercEd;
        protected common.controls.numberTextBox priceWeightEd;
        protected baseClass.controls.baseLabel dayLbl;
        protected baseClass.controls.baseLabel priceWeightLbl;
        protected baseClass.controls.baseLabel buy2SellIntervalLbl;
        protected baseClass.controls.baseLabel transFeePercLbl;
        private System.Windows.Forms.TabControl optionTab;
        private System.Windows.Forms.GroupBox systemGb;
        protected System.Windows.Forms.GroupBox investmentGb;
        protected baseClass.controls.baseLabel percentLb2;
        private common.controls.numberTextBox maxBuyQtyPercEd;
        private baseClass.controls.baseLabel maxBuyQtyPercLbl;


    }
}