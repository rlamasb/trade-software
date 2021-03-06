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
    public partial class dayOfWeek : common.controls.baseUserControl
    {
        public dayOfWeek()
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
        public StringCollection myValues
        {
            get
            {
                
                StringCollection list = new StringCollection();
                if (mondayChk.Checked) list.Add(DayOfWeek.Monday.ToString());
                if (tuesdayChk.Checked) list.Add(DayOfWeek.Tuesday.ToString());
                if (wednesdayChk.Checked) list.Add(DayOfWeek.Wednesday.ToString());
                if (thursdayChk.Checked) list.Add(DayOfWeek.Thursday.ToString());
                if (fridayChk.Checked) list.Add(DayOfWeek.Friday.ToString());
                if (saturdayChk.Checked) list.Add(DayOfWeek.Saturday.ToString());
                if (sundayChk.Checked) list.Add(DayOfWeek.Sunday.ToString());
                return list;
            }
            set
            {
                mondayChk.Checked = false;      tuesdayChk.Checked = false;
                wednesdayChk.Checked = false;   thursdayChk.Checked = false;
                fridayChk.Checked = false;      saturdayChk.Checked = false;
                sundayChk.Checked = false;
                for (int idx = 0; idx < value.Count; idx++)
                {
                    if (value[idx] == DayOfWeek.Monday.ToString())  mondayChk.Checked = true;
                    if (value[idx] == DayOfWeek.Tuesday.ToString()) tuesdayChk.Checked = true;
                    if (value[idx] == DayOfWeek.Wednesday.ToString()) wednesdayChk.Checked = true;
                    if (value[idx] == DayOfWeek.Thursday.ToString()) thursdayChk.Checked = true;
                    if (value[idx] == DayOfWeek.Friday.ToString()) fridayChk.Checked = true;
                    if (value[idx] == DayOfWeek.Saturday.ToString()) saturdayChk.Checked = true;
                    if (value[idx] == DayOfWeek.Sunday.ToString()) sundayChk.Checked = true;
                }
            }
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            //mondayChk.Text = common.language.myCulture.Libs.GetString("firstName");
        }
    }
}