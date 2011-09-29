using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace baseClass.forms
{
    public partial class chartDataOptions : baseDialogForm  
    {
        public chartDataOptions()
        {
            try
            {
                InitializeComponent();
                timeRangeCb.myValue = application.AppTypes.TimeRanges.Y5; 
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        public void InitData()
        {
            this.timeRangeCb.LoadData();
        }
        public static chartDataOptions GetForm(string formName)
        {
            string cacheKey = typeof(chartDataOptions).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            chartDataOptions form = (chartDataOptions)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new chartDataOptions();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }

        public bool GetDate()
        {
            ClearNotifyError();
            bool retVal = true;
            if (!timeRangeCb.GetDate())
            {
                NotifyError(timeRangeCb);
                return false;
            }
            return retVal;
        }
        public virtual application.AppTypes.TimeRanges myTimeRange
        {
            get
            {
                return timeRangeCb.myValue;
            }
            set
            {
                timeRangeCb.myValue = value;
            }
        }

        protected override bool BeforeAcceptProcess()
        {
            bool retVal = GetDate();
            myFormStatus.acceptClose = true;
            return retVal;
        }
    }    
}