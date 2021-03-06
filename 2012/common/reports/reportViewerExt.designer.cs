namespace common.reports
{
    partial class reportViewerExtForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reportViewerExtForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.printBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printSetupBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.findBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.firstBtn = new System.Windows.Forms.ToolStripButton();
            this.prevBtn = new System.Windows.Forms.ToolStripButton();
            this.nextBtn = new System.Windows.Forms.ToolStripButton();
            this.lastBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomLevelEd = new System.Windows.Forms.ToolStripComboBox();
            this.zoomBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toPageEd = new System.Windows.Forms.ToolStripTextBox();
            this.gotoBtn = new System.Windows.Forms.ToolStripButton();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.DisplayStatusBar = true;
            resources.ApplyResources(this.reportViewer, "reportViewer");
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printBtn,
            this.toolStripSeparator1,
            this.printSetupBtn,
            this.toolStripSeparator2,
            this.exportBtn,
            this.toolStripSeparator3,
            this.findBtn,
            this.toolStripSeparator4,
            this.firstBtn,
            this.prevBtn,
            this.nextBtn,
            this.lastBtn,
            this.toolStripSeparator5,
            this.zoomLevelEd,
            this.zoomBtn,
            this.toolStripSeparator6,
            this.toPageEd,
            this.gotoBtn});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // printBtn
            // 
            this.printBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printBtn.Image = global::common.Properties.Resources.print;
            resources.ApplyResources(this.printBtn, "printBtn");
            this.printBtn.Name = "printBtn";
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // printSetupBtn
            // 
            this.printSetupBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printSetupBtn.Image = global::common.Properties.Resources.printsetup;
            resources.ApplyResources(this.printSetupBtn, "printSetupBtn");
            this.printSetupBtn.Name = "printSetupBtn";
            this.printSetupBtn.Click += new System.EventHandler(this.printSetupBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // exportBtn
            // 
            this.exportBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportBtn.Image = global::common.Properties.Resources.excel;
            resources.ApplyResources(this.exportBtn, "exportBtn");
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // findBtn
            // 
            this.findBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.findBtn, "findBtn");
            this.findBtn.Image = global::common.Properties.Resources.find;
            this.findBtn.Name = "findBtn";
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // firstBtn
            // 
            this.firstBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.firstBtn.Image = global::common.Properties.Resources.first;
            resources.ApplyResources(this.firstBtn, "firstBtn");
            this.firstBtn.Name = "firstBtn";
            this.firstBtn.Click += new System.EventHandler(this.firstBtn_Click);
            // 
            // prevBtn
            // 
            this.prevBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prevBtn.Image = global::common.Properties.Resources.previous;
            resources.ApplyResources(this.prevBtn, "prevBtn");
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextBtn.Image = global::common.Properties.Resources.next;
            resources.ApplyResources(this.nextBtn, "nextBtn");
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // lastBtn
            // 
            this.lastBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lastBtn.Image = global::common.Properties.Resources.last;
            resources.ApplyResources(this.lastBtn, "lastBtn");
            this.lastBtn.Name = "lastBtn";
            this.lastBtn.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // zoomLevelEd
            // 
            this.zoomLevelEd.Items.AddRange(new object[] {
            resources.GetString("zoomLevelEd.Items"),
            resources.GetString("zoomLevelEd.Items1"),
            resources.GetString("zoomLevelEd.Items2"),
            resources.GetString("zoomLevelEd.Items3"),
            resources.GetString("zoomLevelEd.Items4"),
            resources.GetString("zoomLevelEd.Items5"),
            resources.GetString("zoomLevelEd.Items6"),
            resources.GetString("zoomLevelEd.Items7"),
            resources.GetString("zoomLevelEd.Items8"),
            resources.GetString("zoomLevelEd.Items9"),
            resources.GetString("zoomLevelEd.Items10"),
            resources.GetString("zoomLevelEd.Items11"),
            resources.GetString("zoomLevelEd.Items12"),
            resources.GetString("zoomLevelEd.Items13")});
            this.zoomLevelEd.Name = "zoomLevelEd";
            resources.ApplyResources(this.zoomLevelEd, "zoomLevelEd");
            this.zoomLevelEd.SelectedIndexChanged += new System.EventHandler(this.zoomLevelEd_SelectedIndexChanged);
            this.zoomLevelEd.Validated += new System.EventHandler(this.zoomLevelEd_Validated);
            // 
            // zoomBtn
            // 
            this.zoomBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.zoomBtn, "zoomBtn");
            this.zoomBtn.Name = "zoomBtn";
            this.zoomBtn.Click += new System.EventHandler(this.zoomBtn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // toPageEd
            // 
            this.toPageEd.Name = "toPageEd";
            resources.ApplyResources(this.toPageEd, "toPageEd");
            this.toPageEd.Validated += new System.EventHandler(this.toPageEd_Validated);
            // 
            // gotoBtn
            // 
            this.gotoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.gotoBtn, "gotoBtn");
            this.gotoBtn.Name = "gotoBtn";
            this.gotoBtn.Click += new System.EventHandler(this.gotoBtn_Click);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // reportViewerExtForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Name = "reportViewerExtForm";
            this.Controls.SetChildIndex(this.reportViewer, 0);
            this.Controls.SetChildIndex(this.toolStrip, 0);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton printBtn;
        private System.Windows.Forms.ToolStripButton nextBtn;
        private System.Windows.Forms.ToolStripButton prevBtn;
        private System.Windows.Forms.ToolStripButton firstBtn;
        private System.Windows.Forms.ToolStripButton lastBtn;
        private System.Windows.Forms.ToolStripButton exportBtn;
        private System.Windows.Forms.ToolStripComboBox zoomLevelEd;
        private System.Windows.Forms.ToolStripTextBox toPageEd;
        private System.Windows.Forms.ToolStripButton findBtn;
        private System.Windows.Forms.ToolStripButton zoomBtn;
        private System.Windows.Forms.ToolStripButton gotoBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton printSetupBtn;
        private System.Windows.Forms.PrintDialog printDialog;
    }
}