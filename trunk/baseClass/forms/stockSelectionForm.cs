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
                if (!this.myFormStatus.isCloseClick)  return codeSelection.myCheckedValues;
                return null;
            }
            set
            {
                codeSelection.myCheckedValues = value;
            }
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