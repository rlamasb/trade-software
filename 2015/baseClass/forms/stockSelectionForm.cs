using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;


namespace baseClass.forms
{
    public partial class stockSelectionForm : common.forms.baseListSelection   
    {
        public override StringCollection mySelectedCodes
        {
            get
            {
                if (!this.myFormStatus.isCloseClick)  return codeSelection.myValues;
                return null;
            }
            set
            {
                codeSelection.myValues = value;
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            codeSelection.SetLanguage();
        }

        public stockSelectionForm()
        {
            try
            {
                InitializeComponent();
                codeSelection.LoadData(); 
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}