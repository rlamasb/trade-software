using System;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO; 
using System.Xml;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace baseClass.forms
{
    public partial class configure : baseForm
    {
        public configure()
        {
            try
            {
                InitializeComponent();
                dbConnInfoObj.LockEdit(true);
                configureTab.SendToBack();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
            }
        }

        private void ReadConfiguration()
        {
            application.configuration.Load_User_Config(false);
            //General settings

            this.logoImgFileEd1.Text = common.fileFuncs.MakeRelativePath(application.sysLibs.sysImgFilePathCompanyLogo1);
            this.logoImgFileEd2.Text = common.fileFuncs.MakeRelativePath(application.sysLibs.sysImgFilePathCompanyLogo2);

            this.iconImgFileEd.Text = common.fileFuncs.MakeRelativePath(application.sysLibs.sysImgFilePathIcon);
            this.bgImgFileEd.Text = common.fileFuncs.MakeRelativePath(application.sysLibs.sysImgFilePathBackGround);

            //Connection
            common.configuration.dbConnectionInfo dbConInfo = new common.configuration.dbConnectionInfo();
            dbConInfo.serverName = application.sysLibs.sysConnectionServerName;
            dbConInfo.database  = application.sysLibs.sysConnectionDbName;
            dbConInfo.account = application.sysLibs.sysConnectionAccount;
            dbConInfo.password = application.sysLibs.sysConnectionPassword;
            dbConInfo.timeoutInSecs = application.sysLibs.sysConnectionTimeout;
            dbConInfo.useTransaction  = application.sysLibs.sysUseTransactionInUpdate;
            dbConnInfoObj.SetConnectionInfo(dbConInfo);
        }

        private void SaveConfiguration()
        {
            // User settings
            application.sysLibs.sysImgFilePathIcon =  this.iconImgFileEd.Text.Trim();
            application.sysLibs.sysImgFilePathBackGround = this.bgImgFileEd.Text.Trim();
            application.sysLibs.sysImgFilePathCompanyLogo1 = this.logoImgFileEd1.Text.Trim();
            application.sysLibs.sysImgFilePathCompanyLogo2 = this.logoImgFileEd2.Text.Trim();
           
            //Save configuration
            application.configuration.Save_User_Config(false);
        }

        private string SelectImgFile(string extFilter)
        {
            openFileDialog.Filter = extFilter;
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveConfiguration();
                
                sysAutoKeyTA.Update(myBaseDS.sysAutoKey);
                myBaseDS.sysAutoKey.AcceptChanges();
                this.ShowMessage("");
                common.system.ShowMessage("Đã lưu dữ liệu");
                this.Close();
            }
            catch(Exception er)
            {
                this.ShowMessage(er.Message.ToString());
                common.system.ShowMessage("Lưu dữ liệu gặp lỗi");
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        
        private void refreshAutoKeyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                myBaseDS.sysAutoKey.Clear();
                application.dataLibs.LoadData(myBaseDS.sysAutoKey);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void iconImgFileEd_DoubleClick(object sender, EventArgs e)
        {
            ((common.controls.baseTextBox)sender).Text = SelectImgFile("Icon(*.ico)|*.ico;| Tat ca(*.*)|*.*");
        }

        private void bgImgFileEd_DoubleClick(object sender, EventArgs e)
        {
            ((common.controls.baseTextBox)sender).Text = SelectImgFile("JPEG (*.JPG,*.JPEG)|*.JPG;*.JPEG|GIF(*.GIF)|*.GIF|Tat ca(*.*)|*.*");
        }

        private void logoImgFileEd_DoubleClick(object sender, EventArgs e)
        {
            bgImgFileEd_DoubleClick(sender, e);
        }

        private void logoImgFileEd2_DoubleClick(object sender, EventArgs e)
        {
            bgImgFileEd_DoubleClick(sender, e);
        }

        private void configure_Load(object sender, EventArgs e)
        {
            try
            {
                ReadConfiguration();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
            }            
        }

        private void checkConnBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //Flashing
                databasePic.BorderStyle = BorderStyle.None;
                System.Threading.Thread.Sleep(100);
                databasePic.BorderStyle = BorderStyle.Fixed3D;
                string tmp = common.database.BuidConnectionString(dbConnInfoObj.GetConnectionInfo());
                string errorMsg = "";
                this.noteEd.Text = "";
                if (common.database.CheckDbConnection(tmp, out errorMsg))
                    this.ShowMessage("Kết nối thành công đến CSDL");
                else
                {
                    this.noteEd.Text = errorMsg;
                    this.ShowMessage("Không thể kết nối đến CSDL");
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}