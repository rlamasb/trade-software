using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class investorLogin : common.forms.baseForm
    {
        private data.baseDS.investorDataTable investorTbl = new data.baseDS.investorDataTable();
        public bool isLoginOk = false;
        public investorLogin()
        {
            InitializeComponent();
            this.myStatusStrip.Visible = false;
        }

        private void userLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.loginEd.Text = application.sysLibs.sysLoginAccount;
            }
            catch( Exception er)
            {
                common.system.ShowErrorMessage(er.Message.ToString()); 
            }
         }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                isLoginOk = false;
                if (DoLogin())
                {
                    isLoginOk = true;
                    this.Close();
                }
            }
            catch (Exception er)
            {
                common.system.ShowErrorMessage(er.Message.ToString());
            }
        }

        public  bool DoLogin()
        {
            string account = this.loginEd.Text.Trim();
            string password = this.passwordEd.Text.Trim();
            if (account == "")
            {
                common.system.ShowErrorMessage("Chưa nhập tài khoản đăng nhập.");
                return false;
            }
            investorTbl.Clear();
            application.dataLibs.LoadInvestorByAccount(investorTbl, account);
            if (investorTbl.Count==0)
            {
                common.system.ShowErrorMessage("Đăng nhập không hợp lệ.Xin vui lòng kiểm tra lại [Account] và [Password]");
                return false;
            }
            if (investorTbl[0].password.Trim() != password.Trim())
            {
                common.system.ShowErrorMessage("Đăng nhập không hợp lệ.Xin vui lòng kiểm tra lại [Account] và [Password]");
                return false;
            }
            if (!application.sysLibs.isSupperAdminLogin(investorTbl[0].account) && 
                 investorTbl[0].expireDate < application.sysLibs.GetServerDateTime())
            {
                common.system.ShowErrorMessage("Tài khỏan đã hết hạn sử dụng.");
                return false;
            }
            application.sysLibs.sysLoginCode = investorTbl[0].code.Trim();
            application.sysLibs.sysLoginAccount = investorTbl[0].account.Trim();
            
            ////Estimate options
            //application.Analysis.myEstimateOptions.totalCashAmt = investorTbl[0].cashAmt;
            //application.Analysis.myEstimateOptions.maxBuyAmtPerc = investorTbl[0].maxBuyAmtPerc;
            //application.Analysis.myEstimateOptions.qtyAccumulatePerc = investorTbl[0].stockAccumulatePerc;
            //application.Analysis.myEstimateOptions.qtyReducePerc = investorTbl[0].stockReducePerc;
            return true;
        }

        private void userLogin_Activated(object sender, EventArgs e)
        {
            if (this.loginEd.Text.Trim() != "") this.passwordEd.Focus();
        }
    }
}