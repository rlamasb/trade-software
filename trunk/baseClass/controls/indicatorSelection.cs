using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace baseClass.controls
{
    public partial class indicatorSelection : common.control.baseUserControl
    {
        public StringCollection myIndicatorCode
        {
            get { return indicatorClb.myCheckedValues; }
            set { indicatorClb.myCheckedValues =value; }
        }

        public void CheckAll(bool state)
        {
            indicatorClb.CheckAll(state);
        }
        public indicatorSelection()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }

        public void LoadData()
        {
            indicatorClb.LoadData();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void indicatorSelection_Resize(object sender, EventArgs e)
        {
            indicatorClb.Size = new Size(this.Width, this.Height - closeBtn.Height+5);
            closeBtn.Location = new Point(this.Width - closeBtn.Width, this.Height - closeBtn.Height);
        }
    }
}