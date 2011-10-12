using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class sysCodeEdit :  baseMasterEdit
    {
        public sysCodeEdit()
        {
            try
            {
                InitializeComponent();
                codeEd.isToUpperCase = true;
                inGroupEd.isToUpperCase = true;
                inGroupEd.MaxLength = myDataSet.sysCode.inGroupColumn.MaxLength; 
                myMasterSource = sysCodeSource;
                LockEditData(true);
                categoryCb.LoadData();
                syscodeGrid.DisableReadOnlyColumn = false;
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = language.GetString("classificationSystem");

            categoryLbl.Text = language.GetString("category");
            noteLbl.Text = language.GetString("note");
            visibleChk.Text = language.GetString("visible");
            systemChk.Text = language.GetString("system");


            codeLbl.Text = language.GetString("code");
            inGroupLbl.Text = language.GetString("name");
            desc1Lbl.Text = language.GetString("description") + " 1";
            desc2Lbl.Text = language.GetString("description") + " 2";
            weightLbl.Text = language.GetString("weight");
            tag1Lbl.Text = language.GetString("tag") + " 1";
            tag2Lbl.Text = language.GetString("tag") + " 2";
            editNoteLbl.Text = language.GetString("note");
            
            
            codeColumn.HeaderText = language.GetString("code");
            inGroupColumn.HeaderText = language.GetString("group");
            description1Column.HeaderText = language.GetString("description")+ " 1";
            description1Column.HeaderText = language.GetString("description") + " 2";
            weightColumn.HeaderText = language.GetString("weight");

            categoryCb.SetLanguage();
        }


        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            codeEd.Enabled = !this.isLockEdit;
            inGroupEd.Enabled = !this.isLockEdit;
            desc1Ed.Enabled = !this.isLockEdit;
            desc2Ed.Enabled = !this.isLockEdit;
            weightEd.Enabled = !this.isLockEdit;
            notesEd.Enabled = !this.isLockEdit;
            tag1Ed.Enabled = !this.isLockEdit;
            tag2Ed.Enabled = !this.isLockEdit;
            editIsVisibleChk.Enabled = !this.isLockEdit;
            editPnl.Enabled = !this.isLockEdit;
        }
        protected override void SetFirstFocus() { codeEd.Focus(); }
        protected override bool DataValid(bool showMsg)
        {
            ClearNotifyError();
            if (codeEd.Text.Trim() == "")
            {
                NotifyError(codeLbl);
                this.codeEd.Focus(); return false;
            }
            if (desc1Ed.Text.Trim() == "")
            {
                NotifyError(desc1Lbl);
                this.desc1Ed.Focus(); return false;
            }
            data.baseDS.sysCodeCatRow row = categoryCb.GetRow(categoryCb.myValue);
            if (row != null & !row.IsmaxCodeLenNull() && row.maxCodeLen > 0 && codeEd.Text.Length > row.maxCodeLen)
            {
                if (showMsg) common.system.ShowErrorMessage(String.Format(language.GetString("dataTooLong"),row.maxCodeLen));
            }
            return true;
        }

        protected override void UpdateData(DataRow row)
        {
            if (row == null)
            {
                application.dataLibs.UpdateData(myDataSet.sysCode);
                return;
            }
            application.dataLibs.UpdateData((data.baseDS.sysCodeRow)row);
        }
        public override void AddNew(string code)
        {
            this.AddNewRow();
            data.baseDS.sysCodeRow row = (data.baseDS.sysCodeRow)((DataRowView)sysCodeSource.Current).Row;
            if (row == null) return;
            application.dataLibs.InitData(row);
            row.code = code;
            row.category = this.categoryCb.SelectedValue.ToString();
        }
        protected override string GetKeyValue(DataRow dr)
        {
            return ((data.baseDS.sysCodeRow)dr).code;
        }
        protected override void LoadData()
        {
            this.ShowMessage("");
            LoadSyscode();
        }
        protected override bool BeforeDelete()
        {
            if (!base.BeforeDelete()) return false;
            if (IsSystemDataRow(syscodeGrid.CurrentRow.Index))
            {
                common.system.ShowErrorMessage(language.GetString("cannotDelete"));
                return false;
            }
            return true;
        }

        private bool IsSystemDataRow(int rowIdx)
        {
            return syscodeGrid.Rows[rowIdx].Cells["isSystem"].Value.ToString() == Boolean.TrueString;
        }

        private void LoadSyscode()
        {
        
            this.myDataSet.sysCode.Clear();
            codeEd.MaxLength = myDataSet.sysCode.codeColumn.MaxLength;
            if (this.categoryCb.SelectedValue != null)
            {
                string catCode = this.categoryCb.SelectedValue.ToString();
                application.dataLibs.LoadData(this.myDataSet.sysCode, catCode);
                data.baseDS.sysCodeCatRow row = myDataSet.sysCodeCat.FindBycategory(catCode);
                if (row != null && !row.IsmaxCodeLenNull())
                {
                    codeEd.MaxLength = row.maxCodeLen;
                }
            }
            this.ShowReccount();
        }

        private void CategoryChanged()
        {
            this.ShowMessage("");
            myDataSet.RejectChanges();
            data.baseDS.sysCodeCatRow row = categoryCb.GetRow(categoryCb.myValue);
            if (row != null)
            {
                systemChk.Checked = row.isSystem;
                visibleChk.Checked = row.isVisible;
                maxLenEd.Text = (row.IsmaxCodeLenNull() ?"":row.maxCodeLen.ToString());
                notesEd.Text = (row.IsnotesNull() ? "" : row.notes.ToString());
            }
            LoadSyscode();
            
            if (this.systemChk.Checked) LockEdit(true);
            editBtn.Enabled = !this.systemChk.Checked;
        }

        private void syscodeGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowError(e.Exception);
        }

        private void sysCodeCatSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                CategoryChanged();
            }
            catch(Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}