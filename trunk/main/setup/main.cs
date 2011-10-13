using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace setup
{
    public partial class main : baseClass.forms.baseApplication
    {
        private bool fullMode = false;
        public main()
        {
            try
            {
                InitializeComponent();
                this.mainMenuStrip = myMenu;
                this.loginRequired = false;
                this.permissionRequired = false;

                sysCodeCatMenuItem.Enabled = fullMode;
                sysCodeMenuItem.Enabled = fullMode;
                sysCodeCatMenuItem.Enabled = fullMode;
                sysOptionsMenuItem.Enabled = fullMode;
            }
            catch (Exception er)
            {
                common.system.ShowErrorMessage(er.Message);
            }
        }

        protected override bool LoadAppConfig()
        {
            //Product code and owner
            application.sysLibs.sysProductCode = "FMSETUP";
            application.sysLibs.sysProductOwner = application.Consts.constProductOwner;
            //Allow call to sensitive funtions in common.dll 
            common.Consts.constValidCallString = common.Consts.constValidCallMarker;

            //Consider as super admin login
            application.sysLibs.sysLoginAccount = application.Settings.sysSuperAdminName;
            //Turn off debug mode to ensure that users cannot bypass some system check
            application.Settings.sysDebugMode = false;

            common.settings.sysConfigFile = this.myConfigFileName;
            //Encryption key should be set before the below commands
            application.configuration.withEncryption = true;
            common.configuration.withEncryption = true;

            application.configuration.Load_Db_Config();
            //Image
            if (common.fileFuncs.FileExist(application.sysLibs.sysImgFilePathBackGround))
                this.BackgroundImage = common.images.LoadImage(application.sysLibs.sysImgFilePathBackGround);
            else this.BackgroundImage = null;
            if (common.fileFuncs.FileExist(application.sysLibs.sysImgFilePathIcon))
                this.Icon = common.images.LoadIcon(application.sysLibs.sysImgFilePathIcon);
            else this.Icon = null;
            return true;
        }
        protected override bool CheckLicense()
        {
            application.sysLibs.sysCompanyName = "";
            common.license.myLicenseItem lic;
            string licFile = LicenseFileName();

            if (common.fileFuncs.FileExist(licFile))
            {
                lic = common.license.GetLicence(licFile);
                if ((lic != null) && (lic.productCode == application.sysLibs.sysProductCode) && common.license.isSerialOk(lic))
                {
                    // Set the company name from licence file
                    application.sysLibs.sysCompanyName = lic.companyName;
                    this.fullMode = true;
                }
            }
            return true;
        }
     
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form myForm = this.FindForm("workerEdit");
            //if (myForm == null || myForm.IsDisposed)
            //{
            //    myForm = new baseClass.workerList();
            //    myForm.Name = "workerEdit";
            //}
            //this.ShowForm(myForm);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kết thúc sử dụng chương trình", application.Consts.constApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("aboutBox");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new AboutBox();
                myForm.Name = "aboutBox";
            }
            this.ShowForm(myForm,false);
        }

        private void locationMenuItem_Click(object sender, EventArgs e)
        {
            //Form myForm = this.FindForm("locationEdit");
            //if (myForm == null || myForm.IsDisposed)
            //{
            //    myForm = new baseClass.locationList();
            //    myForm.Name = "locationEdit";
            //}
            //this.ShowForm(myForm);
        }

        private void dbConfigMenuItem_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("configureDb");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new common.forms.configureDb();
                ((common.forms.configureDb)myForm).SetTitle("TỆP CẤU HÌNH", "Tep cau hinh");
                myForm.Name = "configureDb";
            }
            this.ShowForm(myForm,true);
            //this.myConfigFileName==
        }

        private void sysCodeCatMenuItem_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("sysCodeCatEdit");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new baseClass.forms.sysCodeCatEdit();
                myForm.Name = "sysCodeCatEdit";
            }
            this.ShowForm(myForm);
        }

        private void sysCodeMenuItem_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("sysCodeEdit");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new baseClass.forms.sysCodeEdit();
                myForm.Name = "sysCodeEdit";
            }
            this.ShowForm(myForm);
        }

        private void sysOptionsMenuItem_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("sysOptionsMenuItem");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new forms.sysOptionsMenuItem();
                myForm.Name = "sysOptionsMenuItem";
            }
            this.ShowForm(myForm);
        }

        private void selectConfFileMenuItem_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("configFile");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new setup.forms.configFile();
                ((setup.forms.configFile)myForm).SetTitle("CHỌN TỆP CẤU HÌNH", "Chon tep cau hinh");
                myForm.Name = "configFile";
            }
            this.ShowForm(myForm, true);
        }
    }
}