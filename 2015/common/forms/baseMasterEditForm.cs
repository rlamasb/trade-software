using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Transactions;

namespace common.forms
{
    public partial class baseMasterEditForm : common.forms.baseForm
    {
        public BindingSource myMasterSource = null;
        public static bool fOnProccessing = false;

        public baseMasterEditForm()
        {
            InitializeComponent();
        }

        //Keycode trapping
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Hot keys
            if ((msg.Msg == common.Consts.WM_KEYDOWN) || (msg.Msg == common.Consts.WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case common.Consts.constHotKeySave:
                        if (this.saveBtn.Enabled) saveBtn_Click(null, null);
                        break;
                    case common.Consts.constHotKeyAddNew:
                        if (this.addNewBtn.Enabled) addNewBtn_Click(null, null);
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Abtrstract functions
        protected virtual bool FindData(){return true;}

        protected virtual bool IsEditKeyValid(string key, string keyFld)
        {
            if (myMasterSource == null) return false;
            int row = myMasterSource.Find(keyFld, key);
            if (row < 0) return true;
            if (row != myMasterSource.Position)
            {
                if (MessageBox.Show("Đã có mã số [" + key + "] trong hệ thống, xem lại dữ liệu ? ", common.settings.sysApplicationName,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    myMasterSource.CancelEdit();
                    myMasterSource.Position = row;
                    return true;
                }
                return false;
            }
            return true;
        }
        protected virtual bool ExportToExcel() 
        {
            try
            {
                this.saveFileDialog.CheckPathExists = true;
                this.saveFileDialog.DefaultExt = "xls";
                this.saveFileDialog.Filter = "Dang Excel(*.XLS)|*.XLS|Tat ca(*.*)|*.*";
                this.saveFileDialog.AddExtension = true;
                this.saveFileDialog.RestoreDirectory = true;
                this.saveFileDialog.Title = "Thu muc luu tap tin ?";
                if (this.saveFileDialog.ShowDialog() != DialogResult.OK) return false;
                DataTable tbl = ((DataSet)myMasterSource.DataSource).Tables[myMasterSource.DataMember];
                if (tbl == null) return false;
                common.Export.ExportToExcel(tbl, this.saveFileDialog.FileName);
                common.sysLibs.ShowMessage("Đã xuất dữ liệu ra tập tin : " + this.saveFileDialog.FileName);
            }
            catch (Exception er) 
            {
                this.ErrorHander(er); 
            }
            return false;
        }

        protected virtual void SetFirstFocus() { return; }
        protected virtual void LockEdit(bool lockState)
        {
            this.saveBtn.Enabled = !lockState;
            this.addNewBtn.Enabled = !lockState;
            this.deleteBtn.Enabled = !lockState;
            editBtn.Text = (!lockState ? "&Xem" : "&Sửa");
        }
        protected virtual bool DataValid(bool showMsg) {return true;}
        // Check if the data can be changed (in working period, ownwer...)
        protected virtual bool DataChangable() { return true; }
        protected virtual bool LoadData() {return false;}
        protected virtual bool DataChanged() { return false; }
        protected virtual bool UpdateMasterTable() { return false; }
        protected virtual void CancelAllChanges() { return; }
        protected virtual bool AddNew(string code)
        {
            fOnProccessing = true;
            try
            {
                if (!((myMasterSource.Current != null) && ((DataRowView)myMasterSource.Current).IsNew))
                {
                    myMasterSource.AddNew();
                }
                LockEdit(false);
                this.ShowMessage("");
                return true;
            }
            catch (Exception er)
            {
                this.ErrorHander(er);
                common.sysLibs.ShowErrorMessage("Hệ thống gặp lỗi");
            }
            finally
            {
                fOnProccessing = false;
            }
            return false; 
        }
        protected virtual bool SaveData() { return SaveCurrent(); }
        protected virtual bool SaveCurrent() 
        {
            try
            {
                myMasterSource.EndEdit();
                if (!UpdateMasterTable()) return false;
                this.ShowMessage("Dữ liệu đã được lưu");
                return true;
            }
            catch (Exception er)
            {
                CancelAllChanges();
                this.ErrorHander(er);
                common.sysLibs.ShowErrorMessage("Không lưu được dữ liệu");
            }
            return false;
        }
        protected virtual bool RemoveCurrent()
        {
            try
            {
                fOnProccessing = true;
                if (myMasterSource == null)
                {
                    this.ShowMessage("Chưa thiết lập [myMasterSource]"); return false;
                }

                if (myMasterSource.Count <= 0)
                {
                    deleteBtn.Enabled = false;
                    return false;
                }
                if (MessageBox.Show("Xóa bỏ dữ liệu này ?", common.settings.sysApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return false;

                DataRowView drMaster = (DataRowView)myMasterSource.Current;
                //Existing data need some check before deleting
                if (!drMaster.IsNew && !DataChangable()) return false;
                myMasterSource.RemoveCurrent();
                if (UpdateMasterTable())
                {
                    common.sysLibs.ShowErrorMessage("Đã xoá dữ liệu.");
                    return true;
                }
                common.sysLibs.ShowErrorMessage("Xoá dữ liệu gặp lỗi.");
            }
            catch (Exception er)
            {
                CancelAllChanges();
                this.ErrorHander(er);
            }
            finally { fOnProccessing = false; }
            return false;
        }
        protected virtual bool AskToSaveChanged()
        {
            try
            {
                if (fOnProccessing) return true;
                if ((myMasterSource.Current != null) && ((DataRowView)myMasterSource.Current).IsNew && !DataValid(false))
                {
                    // This may trigger RowValidating event which will call AskToSave.
                    // AskToSave normally will cancel new editing record , 
                    // so it need to be informed to do it silently. 
                    CancelAllChanges();
                    return false;
                }
                if (DataChanged())
                {
                    DialogResult dl1 = MessageBox.Show("Lưu lại dữ liệu thay đổi ?", common.settings.sysApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dl1 == DialogResult.Yes) SaveCurrent();
                    else CancelAllChanges();
                }
                return true;
            }
            catch { }
            return false;
        }
        protected virtual void OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.messageLbl.Text = e.Exception.Message.ToString();
            return;
        }
        #endregion Abtrstract functions

        #region event handler
        private void exitBtn_Click(object sender, EventArgs e)
        {
            AskToSaveChanged(); Close();
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (!RemoveCurrent()) return;
            if (myMasterSource.Count==0)
            {
                if (MessageBox.Show("Đã xóa dữ liệu cuối, thêm dữ liệu để tiếp tục ?", common.settings.sysApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    this.Close();
                    return;
                }
                AddNew("");
            }
            SetFirstFocus();
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!DataValid(true)) return;
            if (SaveData()) 
                SetFirstFocus();
            else 
            {
                CancelAllChanges();
            }
        }
        private void editBtn_Click(object sender, EventArgs e)
        {
            LockEdit(saveBtn.Enabled);
        }
        private void addNewBtn_Click(object sender, EventArgs e)
        {
            AddNew("");  SetFirstFocus();
        }
        private void toExcelBtn_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        private void baseMasterEditForm_Load(object sender, EventArgs e)
        {
            LockEdit(true);
        }
        private void findBtn_Click(object sender, EventArgs e)
        {
            FindData();
        }
        #endregion event handler
    }
}