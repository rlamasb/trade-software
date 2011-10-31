using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace application
{
    public class test
    {
        public static bool LoadTestConfig()
        {
            data.system.dbConnectionString = "Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";

            sysLibs.sysProductOwner = Consts.constProductOwner;
            sysLibs.sysProductCode = Consts.constProductCode;

            configuration.withEncryption = true;
            configuration.Load_User_Envir();
            sysLibs.SetAppEnvironment();

            sysLibs.sysLoginCode = "A00000004";
            return true;
        }
    }
    public class errorHandler
    {
        private static string _lastErrorMsg = "";
        public static string lastErrorMessage
        {
            get
            {
                string tmp = _lastErrorMsg; _lastErrorMsg = ""; return tmp;
            }
            set { _lastErrorMsg = value; }
        }
    }
    public class sysLibs
    {
        public static DateTime GetWorkDayDate(DateTime frDate, int days) { return frDate.AddDays(days); }

        public static common.myAutoKeyInfo GetAutoKey(string key, bool usePending)
        {
            DateTime curTimeStamp = common.Consts.constNullDate;
            data.baseDS.sysAutoKeyPendingDataTable sysAutoKeyPendingTbl = new data.baseDS.sysAutoKeyPendingDataTable();
            //First try to re-used unused keys if required
            if (usePending)
            {
                curTimeStamp = GetServerDateTime();
                DateTime minTimeStamp = curTimeStamp.AddSeconds(-Settings.sysTimeOut_AutoKey);
                sysAutoKeyPendingTbl.Clear();
                dataLibs.LoadData(sysAutoKeyPendingTbl,key);
                if (sysAutoKeyPendingTbl.Count > 0)
                {
                    for (int idx = 0; idx < sysAutoKeyPendingTbl.Count; idx++)
                    {
                        //Still valid : ignore it
                        if (sysAutoKeyPendingTbl[idx].timeStamp > minTimeStamp) continue;

                        //The the first invalid key will be used. Updating the timestamp to make it valid again.
                        sysAutoKeyPendingTbl[idx].timeStamp = curTimeStamp;
                        dataLibs.UpdateData(sysAutoKeyPendingTbl[idx]);
                        return new common.myAutoKeyInfo(key, sysAutoKeyPendingTbl[idx].value, sysAutoKeyPendingTbl[idx].value.Trim());
                    }
                }
            }
            //Then, create a new key and pending key if required
            data.baseDS.sysAutoKeyRow sysAutoKeyRow = dataLibs.NewAutoKeyValue(key);
            if (usePending) dataLibs.CreateAutoPendingKey(sysAutoKeyRow.key, sysAutoKeyRow.value.ToString(), curTimeStamp);
            string valueStr = sysAutoKeyRow.value.ToString().Trim();
            return new common.myAutoKeyInfo(key, valueStr, valueStr);
        }
        public static void DeleteKeyPending(common.myAutoKeyInfo autoKeyInfo)
        {
            //Remove the used key in pending list
            dataLibs.DeleteAutoKeyPending(autoKeyInfo.key, autoKeyInfo.value);
        }

        public static string GetAutoDataKey(string tblName)
        {
            return GetAutoDataKey(tblName, Settings.sysDataKeyPrefix, Settings.sysDataKeySize, false);
        }
        public static string GetAutoDataKey(string tblName, string prefix, int maxLen, bool usePending)
        {
            common.myAutoKeyInfo keyInfo = sysLibs.GetAutoKey(tblName, usePending);
            if (keyInfo == null) return null;
            return prefix + keyInfo.value.PadLeft(maxLen - prefix.Length, '0');
        }

        public static bool InWorkPeriod(string dateTimeStr)
        {
            DateTime dt;
            if (!common.dateTimeLibs.StringToDateTime(dateTimeStr, out dt)) return false;
            return InWorkPeriod(dt);
        }
        public static bool InWorkPeriod(DateTime dt)
        {
            if ((dt.CompareTo(sysLibs.sysWorkPeriodStart) >= 0) && (dt.CompareTo(sysLibs.sysWorkPeriodEnd) <= 0)) return true;
            return false;
        }

        public static void ExitApplication()
        {
            if (common.settings.sysDebugMode)
            {
                common.system.ShowMessage(language.GetString("exitApplication"));
                return;
            }
            common.system.ExitApplication();
        }

        public static DateTime GetServerDateTime()
        {
            try
            {
                SqlConnection conn = new SqlConnection(data.system.dbConnectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT GETDATE()", conn);
                DateTime retDT = DateTime.Parse(command.ExecuteScalar().ToString());
                command.Dispose();
                conn.Close(); conn.Dispose();
                return retDT;
            }
            catch (Exception er)
            {
                errorHandler.lastErrorMessage = er.Message;
            }
            return DateTime.Now;
        }

        public static decimal GetAmountFromExRate(decimal fAmount, decimal exRate)
        {
            return Math.Round(exRate * fAmount, Settings.sysPrecisionLocal);
        }
        public static decimal GetFAmountFromExRate(decimal amount, decimal exRate)
        {
            if (exRate == 0) return 0;
            return Math.Round(amount / exRate, Settings.sysPrecisionForeign);
        }
        public static decimal GetExrateFromAmt(decimal amount, decimal fAmount)
        {
            if (fAmount == 0) return 0;
            return Math.Round(amount / fAmount, Settings.sysPrecisionLocal);
        }

        //========================================================================================
        // Split invoiceCode into 2 parts invoiceNo and seri
        //   - invoiceCode in the format [invoiceNo]/[seri] for example  000100/GD/2009N
        //   - seri = in the format [AA]/[yyyyA] or [AA]/[yyA]  for example GD/2009N, GD/09N
        //=======================================================================================
        public static bool SpitInvoiceCode(string invoiceCode, out string seri, out string invoiceNo)
        {
            SpitInvoiceCode(invoiceCode, new char[] { '/' }, "20", out seri, out invoiceNo);
            return true;
        }
        public static bool SpitInvoiceCode(string invoiceCode, char[] sepaChars, string yearPadding, out string seri, out string invoiceNo)
        {
            seri = ""; invoiceNo = "";
            string[] invoicePart = invoiceCode.Split(sepaChars, StringSplitOptions.RemoveEmptyEntries);
            if (invoicePart.Length == 0) return false;

            invoiceNo = invoicePart[0];
            if (invoicePart.Length == 3)
            {
                //try to get [yyyy] or [yy] part in the seri
                char[] seriChars = invoicePart[2].ToCharArray();
                string yearStr = "", otherStr = "";
                for (int idx = 0; idx < seriChars.Length; idx++)
                {
                    if (Char.IsDigit(seriChars[idx])) yearStr += seriChars[idx].ToString();
                    else otherStr += seriChars[idx].ToString();
                }
                if (yearStr.Length == 2) yearStr = yearPadding + yearStr;
                seri = invoicePart[1] + sepaChars[0] + yearStr + otherStr;
                return true;
            }
            else
            {
                for (int idx = 1; idx < invoicePart.Length; idx++)
                    seri += (seri != "" ? sepaChars[0].ToString() : "") + invoicePart[idx];
            }
            return true;
        }

        public static DateTime GetLastClosingDate(DateTime onDate)
        {
            //if (GetClosingDate(onDate)==onDate) return onDate;

            DateTime closingDate = onDate;
            common.dateTimeLibs.MakeDate(1, onDate.Month, onDate.Year, out closingDate);
            return closingDate.AddDays(-1);
        }
        public static DateTime GetClosingDate(DateTime onDate)
        {
            DateTime closingDate = onDate;
            common.dateTimeLibs.MakeDate(1, onDate.Month, onDate.Year, out closingDate);
            return closingDate.AddMonths(1).AddDays(-1);
        }

        public static CultureInfo myCultureInfo = new CultureInfo(Settings.sysCultureCode);

        public static void SetAppEnvironment()
        {
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
            Application.CurrentCulture = myCultureInfo;
        }

        public static bool isSupperAdminLogin(string loginName)
        {
            return loginName.Trim().ToLower() == Settings.sysSuperAdminName;
        }
        public static bool isSupperAdminLogin()
        {
            return isSupperAdminLogin(sysLoginCode);
        }
        public static bool isAdminLogin(string loginType)
        {
            return (loginType.Trim() == Consts.constWorkerTypeAdmin);
        }
        public static bool isAdminLogin()
        {
            return isAdminLogin(sysLoginType);
        }
        public static void ClearLogin()
        {
            sysLoginCode = "";
            sysLoginAccount = "";
            sysLoginType = "";
            sysLoginLocationName = "";
        }

        public static string DateTimeToString(DateTime dt)
        {
            return dt.ToShortDateString();
        }
        public static bool StringToDateTime(string dateTimeTxt, out DateTime dt)
        {
            CultureInfo MyCultureInfo = new CultureInfo(Settings.sysCultureCode);
            return DateTime.TryParse(dateTimeTxt, MyCultureInfo, DateTimeStyles.NoCurrentDateDefault, out dt);
        }

        public enum searchOptions : int { Exact, StartWith, EndWith, Contain }; // Export format enumeration		
        public static string MakeSearchExpression(string searchBy, string searchTerm, searchOptions option)
        {
            return MakeSearchExpression(searchBy, searchTerm, option, false);
        }
        public static string MakeSearchExpression(string searchBy, string searchTerm, searchOptions option, bool withUnicode)
        {
            string unicodeMark = (withUnicode ? "N" : "");
            switch (option)
            {
                case searchOptions.Exact: return searchBy + "=" + unicodeMark + "'" + searchTerm + "'";
                case searchOptions.EndWith: return searchBy + " LIKE " + unicodeMark + "'" + common.Consts.SQL_CMD_ALL_MARKER + searchTerm + "'";
                case searchOptions.StartWith: return searchBy + " LIKE " + unicodeMark + "'" + searchTerm + common.Consts.SQL_CMD_ALL_MARKER + "'";
                case searchOptions.Contain: return searchBy + " LIKE " + unicodeMark + "'" + common.Consts.SQL_CMD_ALL_MARKER + searchTerm + common.Consts.SQL_CMD_ALL_MARKER + "'";
            }
            return "";
        }

        #region system environment
        public static bool sysUseLocalConfigFile
        {
            get
            {
                StringCollection aFields = new StringCollection();
                aFields.Clear();
                aFields.Add(configuration.configKeys.useLocalConfigFile.ToString());
                if (!common.configuration.GetConfig(configuration.constXMLElement_Root, configuration.constXMLElement_Sub_System, aFields)) return false;
                return aFields[0].Trim() == Boolean.TrueString;
            }
            set
            {
                StringCollection aFields = new StringCollection();
                StringCollection aValues = new StringCollection();
                aFields.Clear(); aValues.Clear();
                aFields.Add(configuration.configKeys.useLocalConfigFile.ToString()); aValues.Add((value ? Boolean.TrueString : Boolean.FalseString));
                common.configuration.SaveConfig(configuration.constXMLElement_Root, configuration.constXMLElement_Sub_System, aFields, aValues);
            }
        }
        public static bool sysUseTransactionInUpdate = false;

        public static short sysConnectionTimeout = 30; //In seconds
        public static decimal sysInventoryWarningQty = 0;

        //Upload
        private static common.uploadMethod _sysUploadMethod = common.uploadMethod.None;
        public static common.uploadMethod sysUploadMethod
        {
            get
            {
                return _sysUploadMethod;
            }
            set
            {
                _sysUploadMethod = value;
                switch (_sysUploadMethod)
                {
                    case common.uploadMethod.HTTP: common.fileFuncs.HttpSetup(sysUploadAddress,sysUploadScriptFile,sysUploadUser,sysUploadPassword); break;
                    case common.uploadMethod.SharedFolder: common.fileFuncs.LocalSetup(sysLibs.sysUploadAddress); break; 
                }
            }
        }
        public static string sysUploadAddress = "";
        public static string sysUploadUser = "", sysUploadPassword = "", sysUploadScriptFile = "";
        

        public static DateTime sysDataStartDate = common.Consts.constNullDate;
        public static DateTime sysWorkPeriodStart = common.Consts.constNullDate;
        public static DateTime sysWorkPeriodEnd = common.Consts.constNullDate;

        public static int sysLoginUserId = common.Consts.constNullInt;
        public static int sysLoginLocationId = common.Consts.constNullInt;

        //public static StringCollection sysLoginInterestedBizSectors = null;
        //public static StringCollection sysLoginInterestedStockCode = null;
        //public static StringCollection sysLoginInterestedStrategy = null;

        


        public static string sysLoginCode = "";
        public static string sysLoginAccount = "";
        public static string sysLoginType = "";
        public static string sysLoginLocationName = "";
        public static string sysCompanyName = "";
        public static string sysCompanyAddr1 = "";
        public static string sysCompanyAddr2 = "";
        public static string sysCompanyAddr3 = "";
        public static string sysCompanyTaxCode = "";
        public static string sysCompanyBankCode = "";
        public static string sysCompanyBankName = "";
        public static string sysCompanyBankAccount = "";
        public static string sysCompanyPhone = "";
        public static string sysCompanyFax = "";
        public static string sysCompanyEmail = "";
        public static string sysCompanyURL = "";
        public static string sysCompanyDirector = "";
        public static string sysCompanyChiefAccountant = "";
        public static string sysCompanyHeadOfManagementBoard = "";
        public static string sysCompanyCashier = "";
        public static string sysWarehouseManager = "";

        public static string sysReportSignerTitle_Director = "Giám đốc";
        public static string sysReportSignerTitle_ChiefAcct = "Kế tóan trưởng";
        public static string sysReportSignerTitle_Cashier = "Thủ quỹ";
        public static string sysReportSignerTitle_WhManager = "Thủ kho";
        public static string sysReportSignerTitle_Creator = "Lập Biểu";


        public static string sysImgFilePathIcon = "";
        public static string sysImgFilePathBackGround = "";
        public static string sysImgFilePathCompanyLogo1 = "";
        public static string sysImgFilePathCompanyLogo2 = "";
        public static string sysConnectionServerName = "";
        public static string sysConnectionDbName = "";
        public static string sysConnectionAccount = "";
        public static string sysConnectionPassword = "";
        public static string sysProductCode = "";
        public static string sysProductOwner = "";
        public static string sysProductVersion = "";

        #endregion system environment
    }
    public class commonLibs
    {
        public static string GetUnitTempTableName()
        {
            return "#" + common.system.UniqueString();
        }
        public static bool PasswordIsValid(string password, out string errMsg)
        {
            errMsg = "";
            if (password.TrimEnd().Length < Settings.sysPasswordMinLen)
            {
                errMsg = "Mật khẩu phải có ít nhất " + Settings.sysPasswordMinLen.ToString() + " ký tự.";
                return false;
            }
            return true;
        }
        public static int Permission2Number(string permission)
        {
            if (permission.Trim() == "") return common.Consts.constPermissionNONE;
            int perm = 0;
            if (permission.Contains(Consts.constUserPermissionADD.ToString())) perm += common.Consts.constPermissionADD;
            if (permission.Contains(Consts.constUserPermissionEDIT.ToString())) perm += common.Consts.constPermissionEDIT;
            if (permission.Contains(Consts.constUserPermissionDEL.ToString())) perm += common.Consts.constPermissionDEL;
            return perm;
        }
        public static string Number2Permission(int number)
        {
            if (number == 0) return "";
            string permission = "";
            if ((number & common.Consts.constPermissionADD) > 0) permission += Consts.constUserPermissionADD.ToString();
            if ((number & common.Consts.constPermissionDEL) > 0) permission += Consts.constUserPermissionDEL.ToString();
            if ((number & common.Consts.constPermissionEDIT) > 0) permission += Consts.constUserPermissionEDIT.ToString();
            return permission;
        }
        public static int GetFormPermission(string formCode)
        {
            string permission;
            permission = Consts.constUserPermissionADD.ToString() +
                             Consts.constUserPermissionDEL.ToString() +
                             Consts.constUserPermissionEDIT.ToString();
            return Permission2Number(permission);

            if (sysLibs.isSupperAdminLogin())
            {
                permission = Consts.constUserPermissionADD.ToString() +
                             Consts.constUserPermissionDEL.ToString() +
                             Consts.constUserPermissionEDIT.ToString();
                return Permission2Number(permission);
            }
            //permission = dataLibs.GetWorkerAllPermission(Consts.constSysPermissionMenu,
            //                                            sysLibs.sysLoginUserId, formCode);
            //return Permission2Number(permission);
        }
    }
    public class reportLibs
    {
        public static string SayDate(DateTime dt)
        {
            return "Ngày " + dt.Day.ToString() + " tháng " + dt.Month.ToString() + " năm " + dt.Year.ToString();
        }
    }
    public class configuration
    {
        public static bool ReadUserSettings(string subNode, string childNode, StringCollection aFields)
        {
            return common.configuration.GetConfiguration(Settings.sysUserConfigFile, subNode, childNode, aFields, false);
        }
        public static bool SetUserSettings(string subNode, string childNode, StringCollection aFields, StringCollection aValues)
        {
            return common.configuration.SaveConfiguration(Settings.sysUserConfigFile, subNode, childNode, aFields, aValues, false);
        }

        public enum configKeys
        {
            //System
            sysDebugMode,
            sysCultureCode, sysPasswdMinLen, sysUseStrongPassword,
            sysDataKeyPrefix, sysDataKeySize, sysAutoEditKeySize, sysTimeOutAutoKey,
            sysProductCostMethod, sysProductCostDistMethod,
            sysMaskLocalAmount, sysMaskForeignAmt, sysMaskQty, sysMaskPrice, sysMaskPercent,
            sysPrecisionLocal, sysPrecisionForeign, sysPrecisionQty,sysPrecisionPrice, sysPrecisionPercentage,
            sysMainCurrency,

            sysSmtpServer, sysSmtpPort, sysSmtpAuthAccount , sysSmtpAuthPassword, sysSmptSSL,
            
            sysProdVersion, sysReleaseDate,
            sysDataStartDate, sysWorkPeriodStart, sysWorkPeriodEnd,
            sysItemTagInputType,
            sysTradeAlertLastRun,

            //Upload
            sysUploadMethod, sysUploadAddress, sysUploadScriptFile, sysUploadUser, sysUploadPassword,
            
            //To local file
            useLocalConfigFile,
            LoginName,loginLocationId,

            //Depend on user [sysUseLocalConfigFile]
            companyName, companyAddr1, companyAddr2, companyAddr3, companyTaxcode,
            telephone, fax, email, URL,
            director, headOfManagementBoard, chiefAccountant, warehouseManager, cashier,
            reportSignerTitle_Director, reportSignerTitle_ChiefAcct, reportSignerTitle_Cachier,
            reportSignerTitle_whManager, reportSignerTitle_Creator,

            bankCode, bankAccount, bankName,
            useTransactionInUpdate,
            whWarningQty,
            imgFilePathBackground, imgFilePathIcon,
            imgFilePathComanyLogo1, imgFilePathComanyLogo2,
            //Stock
            stockTransFeePercent, stockSell2BuyInterval, stockPriceWeight, stockVolumeWeight,
            stockMaxBuyQtyPerc, stockReduceQtyPerc, stockAccumulateQtyPerc,
            stockMaxBuyAmtPerc, stockTotalCapAmt
        }

        //private const string constRootXMLElementStr = "Configuration";
        public const string constXMLElement_Root = "Application";
        public const string constXMLElement_Sub_System = "System";
        public const string constXMLElement_Sub_Database = "Database";
        public static bool withEncryption
        {
            get { return common.configuration.withEncryption;}
            set { common.configuration.withEncryption = value;}
        }
        public static string BuidConnectionString(string serverAddr, string dbName, string account, string password)
        {
            string configStr = "";
            configStr = "Data Source=" + serverAddr.Trim() +
                        ";Initial Catalog=" + dbName.Trim() +
                        ";Persist Security Info=True;User ID=" + account.Trim();
            if (password.Trim() != "") configStr += ";password=" + password;
            return configStr;
        }


        //============================================================================================
        // Database connection information to ensure that all database access can be done
        //============================================================================================
        //============================================================================================
        // Database connection information to ensure that all database access can be done
        //============================================================================================
        public static void Load_Db_Config()
        {
            common.configuration.dbConnectionInfo dbConInfo = common.configuration.GetDbConectionInfo();
            sysLibs.sysConnectionServerName = dbConInfo.serverName;
            sysLibs.sysConnectionDbName = dbConInfo.database;
            sysLibs.sysConnectionAccount = dbConInfo.account;
            sysLibs.sysConnectionPassword = dbConInfo.password;
            sysLibs.sysConnectionTimeout = dbConInfo.timeoutInSecs;
            sysLibs.sysUseTransactionInUpdate = dbConInfo.useTransaction;
            data.system.ClearConnectionString();
        }
        public static void Save_Db_Config()
        {
            //Database connection
            common.configuration.dbConnectionInfo dbConInfo = new common.configuration.dbConnectionInfo();
            dbConInfo.serverName = sysLibs.sysConnectionServerName;
            dbConInfo.database = sysLibs.sysConnectionDbName;
            dbConInfo.account = sysLibs.sysConnectionAccount;
            dbConInfo.password = sysLibs.sysConnectionPassword;
            dbConInfo.timeoutInSecs = sysLibs.sysConnectionTimeout;
            dbConInfo.useTransaction = sysLibs.sysUseTransactionInUpdate;
            common.configuration.SaveDbConectionInfo(dbConInfo);
            data.system.ClearConnectionString();
        }

        public static void Load_User_Config(bool useLocalFile)
        {
            StringCollection aFields = new StringCollection();
            //=================================
            //   System : store in database
            //=================================

            // Version and release date
            aFields.Clear();
            aFields.Add(configKeys.sysProdVersion.ToString());
            aFields.Add(configKeys.sysReleaseDate.ToString()); //For future used
            configuration.GetConfig(ref aFields);

            sysLibs.sysProductVersion = aFields[0].ToString();
            //sysLibs.sysreleaseDate = aFields[1].ToString();

            //Date range
            DateTime dt;
            aFields.Clear();
            aFields.Add(configKeys.sysDataStartDate.ToString());
            aFields.Add(configKeys.sysWorkPeriodStart.ToString());
            aFields.Add(configKeys.sysWorkPeriodEnd.ToString());
            configuration.GetConfig(ref aFields);

            dt = DateTime.MaxValue; DateTime.TryParse(aFields[0].ToString(), out dt);
            sysLibs.sysDataStartDate = dt;

            dt = DateTime.MaxValue; DateTime.TryParse(aFields[1].ToString(), out dt);
            sysLibs.sysWorkPeriodStart = dt;

            dt = DateTime.MinValue; DateTime.TryParse(aFields[2].ToString(), out dt);
            sysLibs.sysWorkPeriodEnd = dt;

            //Warehouse
            aFields.Clear();
            aFields.Add(configKeys.whWarningQty.ToString());
            configuration.GetConfig(ref aFields);
            decimal qty = 0; decimal.TryParse(aFields[0].ToString(), out qty);
            sysLibs.sysInventoryWarningQty = qty;

            //=======================================
            //   Other : store in database or XML
            //=======================================
            //Company
            aFields.Clear();
            aFields.Add(configKeys.companyName.ToString());
            aFields.Add(configKeys.companyAddr1.ToString());
            aFields.Add(configKeys.companyAddr2.ToString());
            aFields.Add(configKeys.companyAddr3.ToString());
            aFields.Add(configKeys.telephone.ToString());
            aFields.Add(configKeys.fax.ToString());
            aFields.Add(configKeys.email.ToString());
            aFields.Add(configKeys.URL.ToString());
            aFields.Add(configKeys.companyTaxcode.ToString());

            aFields.Add(configKeys.bankName.ToString());
            aFields.Add(configKeys.bankAccount.ToString());
            aFields.Add(configKeys.bankCode.ToString());

            aFields.Add(configKeys.director.ToString());
            aFields.Add(configKeys.chiefAccountant.ToString());
            aFields.Add(configKeys.headOfManagementBoard.ToString());
            aFields.Add(configKeys.warehouseManager.ToString());
            aFields.Add(configKeys.cashier.ToString());

            aFields.Add(configKeys.reportSignerTitle_Director.ToString());
            aFields.Add(configKeys.reportSignerTitle_ChiefAcct.ToString());
            aFields.Add(configKeys.reportSignerTitle_Cachier.ToString());
            aFields.Add(configKeys.reportSignerTitle_whManager.ToString());
            aFields.Add(configKeys.reportSignerTitle_Creator.ToString());
            if (useLocalFile) common.configuration.GetConfig(constXMLElement_Root, constXMLElement_Sub_System,aFields);
            else configuration.GetConfig(ref aFields);

            //sysLibs.sysCompanyName = aFields[0].ToString();
            sysLibs.sysCompanyAddr1 = aFields[1].ToString();
            sysLibs.sysCompanyAddr2 = aFields[2].ToString();
            sysLibs.sysCompanyAddr3 = aFields[3].ToString();

            sysLibs.sysCompanyPhone = aFields[4].ToString();
            sysLibs.sysCompanyFax = aFields[5].ToString();
            sysLibs.sysCompanyEmail = aFields[6].ToString();
            sysLibs.sysCompanyURL = aFields[7].ToString();
            sysLibs.sysCompanyTaxCode = aFields[8].ToString();

            sysLibs.sysCompanyBankName = aFields[9].ToString();
            sysLibs.sysCompanyBankAccount = aFields[10].ToString();
            sysLibs.sysCompanyBankCode = aFields[11].ToString();

            sysLibs.sysCompanyDirector = aFields[12].ToString();
            sysLibs.sysCompanyChiefAccountant = aFields[13].ToString();
            sysLibs.sysCompanyHeadOfManagementBoard = aFields[14].ToString();
            sysLibs.sysWarehouseManager = aFields[15].ToString();
            sysLibs.sysCompanyCashier = aFields[16].ToString();

            //Image and Icon
            aFields.Clear();
            aFields.Add(configKeys.imgFilePathBackground.ToString());
            aFields.Add(configKeys.imgFilePathIcon.ToString());
            aFields.Add(configKeys.imgFilePathComanyLogo1.ToString());
            aFields.Add(configKeys.imgFilePathComanyLogo2.ToString());
            if (useLocalFile) common.configuration.GetConfig(constXMLElement_Root, constXMLElement_Sub_System,aFields);
            else configuration.GetConfig(ref aFields);

            sysLibs.sysImgFilePathBackGround = common.fileFuncs.GetFullPath(aFields[0].ToString());
            sysLibs.sysImgFilePathIcon = common.fileFuncs.GetFullPath(aFields[1].ToString());
            sysLibs.sysImgFilePathCompanyLogo1 = common.fileFuncs.GetFullPath(aFields[2].ToString());
            sysLibs.sysImgFilePathCompanyLogo2 = common.fileFuncs.GetFullPath(aFields[3].ToString());
        }
        public static void Save_User_Config(bool useLocalFile)
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();

            //========================
            //  Store in database
            //========================
            aFields.Clear(); aValues.Clear();

            //Date 
            aFields.Add(configKeys.sysWorkPeriodStart.ToString()); aValues.Add(sysLibs.sysWorkPeriodStart.ToShortDateString());
            aFields.Add(configKeys.sysWorkPeriodEnd.ToString()); aValues.Add(sysLibs.sysWorkPeriodEnd.ToShortDateString());

            //Inventory options
            aFields.Add(configKeys.whWarningQty.ToString()); aValues.Add(sysLibs.sysInventoryWarningQty.ToString());

            configuration.SaveConfig(aFields, aValues);

            //========================
            //  Store in XML
            //========================
            aFields.Clear(); aValues.Clear();
            //Company
            aFields.Add(configKeys.companyName.ToString()); aValues.Add(sysLibs.sysCompanyName);
            aFields.Add(configKeys.companyAddr1.ToString()); aValues.Add(sysLibs.sysCompanyAddr1);
            aFields.Add(configKeys.companyAddr2.ToString()); aValues.Add(sysLibs.sysCompanyAddr2);
            aFields.Add(configKeys.companyAddr3.ToString()); aValues.Add(sysLibs.sysCompanyAddr3);
            aFields.Add(configKeys.telephone.ToString()); aValues.Add(sysLibs.sysCompanyPhone);
            aFields.Add(configKeys.fax.ToString()); aValues.Add(sysLibs.sysCompanyFax);
            aFields.Add(configKeys.email.ToString()); aValues.Add(sysLibs.sysCompanyEmail);
            aFields.Add(configKeys.URL.ToString()); aValues.Add(sysLibs.sysCompanyURL);
            aFields.Add(configKeys.companyTaxcode.ToString()); aValues.Add(sysLibs.sysCompanyTaxCode);

            aFields.Add(configKeys.bankName.ToString()); aValues.Add(sysLibs.sysCompanyBankName);
            aFields.Add(configKeys.bankAccount.ToString()); aValues.Add(sysLibs.sysCompanyBankAccount);
            aFields.Add(configKeys.bankCode.ToString()); aValues.Add(sysLibs.sysCompanyBankCode);

            aFields.Add(configKeys.director.ToString()); aValues.Add(sysLibs.sysCompanyDirector);
            aFields.Add(configKeys.chiefAccountant.ToString()); aValues.Add(sysLibs.sysCompanyChiefAccountant);
            aFields.Add(configKeys.headOfManagementBoard.ToString()); aValues.Add(sysLibs.sysCompanyHeadOfManagementBoard);
            aFields.Add(configKeys.warehouseManager.ToString()); aValues.Add(sysLibs.sysWarehouseManager);
            aFields.Add(configKeys.cashier.ToString()); aValues.Add(sysLibs.sysCompanyCashier);

            //Image and icon
            aFields.Add(configKeys.imgFilePathIcon.ToString()); aValues.Add(common.fileFuncs.MakeRelativePath(sysLibs.sysImgFilePathIcon));
            aFields.Add(configKeys.imgFilePathBackground.ToString()); aValues.Add(common.fileFuncs.MakeRelativePath(sysLibs.sysImgFilePathBackGround));
            aFields.Add(configKeys.imgFilePathComanyLogo1.ToString()); aValues.Add(common.fileFuncs.MakeRelativePath(sysLibs.sysImgFilePathCompanyLogo1));
            aFields.Add(configKeys.imgFilePathComanyLogo2.ToString()); aValues.Add(common.fileFuncs.MakeRelativePath(sysLibs.sysImgFilePathCompanyLogo2));

            if (useLocalFile) common.configuration.SaveConfig(constXMLElement_Root, constXMLElement_Sub_System, aFields, aValues);
            else configuration.SaveConfig(aFields, aValues);
        }

        public static void Load_User_Envir()
        {
            string XMLFileName = common.settings.sysConfigFile;
            StringCollection aFields = new StringCollection();
            aFields.Add(configKeys.LoginName.ToString()); 
            aFields.Add(configKeys.loginLocationId.ToString());
            common.configuration.GetConfig("ENVIRONMENT", "Login",  aFields);

            sysLibs.sysLoginAccount = aFields[0].ToString();
            int id = 0;
            int.TryParse(aFields[1].ToString(), out id);
            sysLibs.sysLoginLocationId = id;
        }
        public static void Save_User_Envir()
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();

            aFields.Clear(); aValues.Clear();
            aFields.Add(configKeys.LoginName.ToString());
            aValues.Add(sysLibs.sysLoginAccount);

            aFields.Add(configKeys.loginLocationId.ToString());
            aValues.Add(sysLibs.sysLoginLocationId.ToString());

            common.configuration.SaveConfig("ENVIRONMENT", "Login", aFields, aValues);
        }

        public static void Load_Sys_Settings()
        {
            Load_Sys_Settings_SYSTEM();
            Load_Sys_Settings_STOCK();
            Load_Sys_Settings_CHART();
        }
        public static void Save_Sys_Settings()
        {
            Save_Sys_Settings_SYSTEM();
            Save_Sys_Settings_STOCK();
            Save_Sys_Settings_CHART();
        }

        public static void Load_Sys_Settings_SYSTEM()
        {
            int num;
            DateTime dt;
            //Systen tab 
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add(configKeys.sysCultureCode.ToString());
            aFields.Add(configKeys.sysPasswdMinLen.ToString());
            aFields.Add(configKeys.sysUseStrongPassword.ToString());
            aFields.Add(configKeys.sysDebugMode.ToString());

            aFields.Add(configKeys.sysDataKeyPrefix.ToString());
            aFields.Add(configKeys.sysDataKeySize.ToString());
            aFields.Add(configKeys.sysAutoEditKeySize.ToString());
            aFields.Add(configKeys.sysTimeOutAutoKey.ToString());
            configuration.GetConfig(ref aFields);
            if (aFields[0].Trim() != "") Settings.sysCultureCode = aFields[0];
            


            if (int.TryParse(aFields[1], out num)) Settings.sysPasswordMinLen = (byte)num;
            if (aFields[2].Trim() != "") Settings.sysUseStrongPassword = (aFields[2] == Boolean.TrueString);
            if (aFields[3].Trim() != "") Settings.sysDebugMode = (aFields[3] == Boolean.TrueString);
            if (aFields[4].Trim() != "") Settings.sysDataKeyPrefix = aFields[4].Trim();
            
            if (int.TryParse(aFields[5], out num)) Settings.sysDataKeySize = num;
            if (int.TryParse(aFields[6], out num)) Settings.sysAutoEditKeySize  = num;
            if (int.TryParse(aFields[7], out num)) Settings.sysTimeOut_AutoKey = num;
            
            //Format
            aFields.Clear();
            aFields.Add(configKeys.sysMaskLocalAmount.ToString());   
            aFields.Add(configKeys.sysMaskForeignAmt.ToString());
            aFields.Add(configKeys.sysMaskQty.ToString());
            aFields.Add(configKeys.sysMaskPrice.ToString());      
            aFields.Add(configKeys.sysMaskPercent.ToString());

            aFields.Add(configKeys.sysPrecisionLocal.ToString()); 
            aFields.Add(configKeys.sysPrecisionForeign.ToString());
            aFields.Add(configKeys.sysPrecisionQty.ToString()); 
            aFields.Add(configKeys.sysPrecisionPrice.ToString());
            aFields.Add(configKeys.sysPrecisionPercentage.ToString());
            
            configuration.GetConfig(ref aFields);
            if (aFields[0].Trim() != "") Settings.sysMaskLocalAmt = aFields[0];
            if (aFields[1].Trim() != "") Settings.sysMaskForeignAmt = aFields[1];
            if (aFields[2].Trim() != "") Settings.sysMaskQty = aFields[2];
            if (aFields[3].Trim() != "") Settings.sysMaskPrice = aFields[3];
            if (aFields[4].Trim() != "") Settings.sysMaskPercent = aFields[4];
            
            if (int.TryParse(aFields[5], out num)) Settings.sysPrecisionLocal = num;
            if (int.TryParse(aFields[6], out num)) Settings.sysPrecisionForeign = num;
            if (int.TryParse(aFields[7], out num)) Settings.sysPrecisionQty = num;
            if (int.TryParse(aFields[8], out num)) Settings.sysPrecisionPrice = num;
            if (int.TryParse(aFields[9], out num)) Settings.sysPrecisionPercentage = num;

            //Email
            aFields.Clear();
            aFields.Add(configKeys.sysSmtpServer.ToString());
            aFields.Add(configKeys.sysSmtpPort.ToString());
            aFields.Add(configKeys.sysSmtpAuthAccount.ToString());
            aFields.Add(configKeys.sysSmtpAuthPassword.ToString());
            aFields.Add(configKeys.sysSmptSSL.ToString());

            configuration.GetConfig(ref aFields);
            if (aFields[0].Trim() != "")  common.sendMail.mySettings.smtpAddress = aFields[0];
            if (aFields[1].Trim() != ""  & int.TryParse(aFields[1], out num)) common.sendMail.mySettings.smtpPort = num;
            common.sendMail.mySettings.authAccount = aFields[2].Trim();
            common.sendMail.mySettings.authPassword = aFields[3].Trim();
            common.sendMail.mySettings.smtpSSL = (aFields[4].Trim() == Boolean.TrueString);


            //Report
            aFields.Clear();
            aFields.Add(configKeys.reportSignerTitle_Director.ToString());
            aFields.Add(configKeys.reportSignerTitle_ChiefAcct.ToString()); 
            aFields.Add(configKeys.reportSignerTitle_Cachier.ToString()); 
            aFields.Add(configKeys.reportSignerTitle_whManager.ToString()); 
            aFields.Add(configKeys.reportSignerTitle_Creator.ToString());
            configuration.GetConfig(ref aFields);
            if (aFields[0].Trim() != "") sysLibs.sysReportSignerTitle_Director = aFields[0];
            if (aFields[1].Trim() != "") sysLibs.sysReportSignerTitle_ChiefAcct= aFields[1];
            if (aFields[2].Trim() != "") sysLibs.sysReportSignerTitle_Cashier = aFields[2];
            if (aFields[3].Trim() != "") sysLibs.sysReportSignerTitle_WhManager = aFields[3];
            if (aFields[4].Trim() != "") sysLibs.sysReportSignerTitle_Creator = aFields[4];

            //Others
            aFields.Clear();
            aFields.Add(configKeys.sysDataStartDate.ToString());
            aFields.Add(configKeys.sysMainCurrency.ToString());
            
            configuration.GetConfig(ref aFields);
            if (DateTime.TryParse(aFields[0], out dt)) sysLibs.sysDataStartDate = dt;
            if (aFields[1].Trim() != "") Settings.sysMainCurrency = aFields[1];

            //Upload
            aFields.Clear();
            aFields.Add(configKeys.sysUploadMethod.ToString());
            aFields.Add(configKeys.sysUploadAddress.ToString());
            aFields.Add(configKeys.sysUploadScriptFile.ToString());
            aFields.Add(configKeys.sysUploadUser.ToString());
            aFields.Add(configKeys.sysUploadPassword.ToString());
            configuration.GetConfig(ref aFields);
            
            byte code = 0; byte.TryParse(aFields[0], out code);
            sysLibs.sysUploadMethod = (common.uploadMethod)code;

            sysLibs.sysUploadAddress = aFields[1];
            sysLibs.sysUploadScriptFile = aFields[2];
            sysLibs.sysUploadUser = aFields[3];
            sysLibs.sysUploadPassword = aFields[4];
            sysLibs.sysUploadMethod = sysLibs.sysUploadMethod; // Force setup
        }
        public static void Save_Sys_Settings_SYSTEM()
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Clear(); aValues.Clear();
            aFields.Add(configKeys.sysCultureCode.ToString());
            aFields.Add(configKeys.sysPasswdMinLen.ToString());
            aFields.Add(configKeys.sysUseStrongPassword.ToString());
            aFields.Add(configKeys.sysDebugMode.ToString());
            aValues.Add(Settings.sysCultureCode);
            aValues.Add(Settings.sysPasswordMinLen.ToString());
            aValues.Add(Settings.sysUseStrongPassword.ToString());
            aValues.Add((Settings.sysDebugMode?Boolean.TrueString:Boolean.FalseString));

            aFields.Add(configKeys.sysDataKeyPrefix.ToString());
            aFields.Add(configKeys.sysDataKeySize.ToString());
            aFields.Add(configKeys.sysAutoEditKeySize.ToString());
            aFields.Add(configKeys.sysTimeOutAutoKey.ToString());
            aValues.Add(Settings.sysDataKeyPrefix);
            aValues.Add(Settings.sysDataKeySize.ToString());
            aValues.Add(Settings.sysAutoEditKeySize.ToString());
            aValues.Add(Settings.sysTimeOut_AutoKey.ToString());
            configuration.SaveConfig(aFields, aValues);

            //Format
            aFields.Add(configKeys.sysMaskLocalAmount.ToString()); 
            aFields.Add(configKeys.sysMaskForeignAmt.ToString());
            aFields.Add(configKeys.sysMaskQty.ToString()); 
            aFields.Add(configKeys.sysMaskPercent.ToString());

            aValues.Add(Settings.sysMaskLocalAmt);
            aValues.Add(Settings.sysMaskForeignAmt);
            aValues.Add(Settings.sysMaskQty);
            aValues.Add(Settings.sysMaskPercent);

            aFields.Add(configKeys.sysPrecisionLocal.ToString()); 
            aFields.Add(configKeys.sysPrecisionForeign.ToString());
            aFields.Add(configKeys.sysPrecisionQty.ToString()); 
            aFields.Add(configKeys.sysPrecisionPercentage.ToString());

            aValues.Add(Settings.sysPrecisionLocal.ToString());
            aValues.Add(Settings.sysPrecisionForeign.ToString());
            aValues.Add(Settings.sysPrecisionQty.ToString());
            aValues.Add(Settings.sysPrecisionPercentage.ToString());
            configuration.SaveConfig(aFields, aValues);

            //Mail
            aFields.Clear(); aValues.Clear();
            aFields.Add(configKeys.sysSmtpServer.ToString());
            aFields.Add(configKeys.sysSmtpPort.ToString());
            aFields.Add(configKeys.sysSmtpAuthAccount.ToString());
            aFields.Add(configKeys.sysSmtpAuthPassword.ToString());
            aFields.Add(configKeys.sysSmptSSL.ToString());

            aValues.Add(common.sendMail.mySettings.smtpAddress);
            aValues.Add(common.sendMail.mySettings.smtpPort.ToString());
            aValues.Add(common.sendMail.mySettings.authAccount);
            aValues.Add(common.sendMail.mySettings.authPassword);
            aValues.Add(common.sendMail.mySettings.smtpSSL?Boolean.TrueString:Boolean.FalseString);
            configuration.SaveConfig(aFields, aValues);


            //Others
            aFields.Clear(); aValues.Clear();
            aFields.Add(configKeys.sysMainCurrency.ToString());
            aFields.Add(configKeys.sysDataStartDate.ToString());
            //aFields.Add(configKeys.sysItemTagInputType.ToString());

            aValues.Add(Settings.sysMainCurrency);
            aValues.Add(sysLibs.sysDataStartDate.ToShortDateString());
            configuration.SaveConfig(aFields, aValues);

            //Upload
            aFields.Clear(); 
            aFields.Add(configKeys.sysUploadMethod.ToString());
            aFields.Add(configKeys.sysUploadAddress.ToString());
            aFields.Add(configKeys.sysUploadScriptFile.ToString());
            aFields.Add(configKeys.sysUploadUser.ToString());
            aFields.Add(configKeys.sysUploadPassword.ToString());

            aValues.Clear();
            aValues.Add(((byte)sysLibs.sysUploadMethod).ToString());
            aValues.Add(sysLibs.sysUploadAddress);
            aValues.Add(sysLibs.sysUploadScriptFile);
            aValues.Add(sysLibs.sysUploadUser);
            aValues.Add(sysLibs.sysUploadPassword);
            configuration.SaveConfig(aFields, aValues);


            //Report
            aFields.Clear(); aValues.Clear();
            aFields.Add(configKeys.reportSignerTitle_Director.ToString()); aValues.Add(sysLibs.sysReportSignerTitle_Director);
            aFields.Add(configKeys.reportSignerTitle_ChiefAcct.ToString()); aValues.Add(sysLibs.sysReportSignerTitle_ChiefAcct);
            aFields.Add(configKeys.reportSignerTitle_Cachier.ToString()); aValues.Add(sysLibs.sysReportSignerTitle_Cashier);
            aFields.Add(configKeys.reportSignerTitle_whManager.ToString()); aValues.Add(sysLibs.sysReportSignerTitle_WhManager);
            aFields.Add(configKeys.reportSignerTitle_Creator.ToString()); aValues.Add(sysLibs.sysReportSignerTitle_Creator);
            configuration.SaveConfig(aFields, aValues);
        }

        public static void Load_Sys_Settings_STOCK()
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add(configKeys.stockTransFeePercent.ToString());
            aFields.Add(configKeys.stockSell2BuyInterval.ToString());
            
            aFields.Add(configKeys.stockPriceWeight.ToString());
            aFields.Add(configKeys.stockVolumeWeight.ToString());

            aFields.Add(configKeys.stockMaxBuyQtyPerc.ToString());
            aFields.Add(configKeys.stockReduceQtyPerc.ToString());
            aFields.Add(configKeys.stockAccumulateQtyPerc.ToString());
            
            aFields.Add(configKeys.stockTotalCapAmt.ToString());
            aFields.Add(configKeys.stockMaxBuyAmtPerc.ToString());

            configuration.GetConfig(ref aFields);
            decimal d = 0; int n = 0;
            if (aFields[0].Trim() != "")
            {
                decimal.TryParse(aFields[0], out d); Settings.sysStockTransFeePercent = d;
            }
            if (aFields[1].Trim() != "")
            {
                int.TryParse(aFields[1], out n); Settings.sysStockSell2BuyInterval = (short)n;
            }
            if (aFields[2].Trim() != "")
            {
                decimal.TryParse(aFields[2], out d); Settings.sysStockPriceWeight = d;
            }
            if (aFields[3].Trim() != "")
            {
                decimal.TryParse(aFields[3], out d); Settings.sysStockVolumeWeight = d;
            }

            if (aFields[4].Trim() != "")
            {
                decimal.TryParse(aFields[4], out d); Settings.sysStockMaxBuyQtyPerc = d;
            }
            if (aFields[5].Trim() != "")
            {
                decimal.TryParse(aFields[5], out d); Settings.sysStockReduceQtyPerc = d;
            }
            if (aFields[6].Trim() != "")
            {
                decimal.TryParse(aFields[6], out d); Settings.sysStockAccumulateQtyPerc = d;
            }
            if (aFields[7].Trim() != "")
            {
                decimal.TryParse(aFields[7], out d); Settings.sysStockTotalCapAmt = d;
            }
            if (aFields[8].Trim() != "")
            {
                decimal.TryParse(aFields[8], out d); Settings.sysStockMaxBuyAmtPerc = d;
            }
        }
        public static void Save_Sys_Settings_STOCK()
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Clear();
            aFields.Add(configKeys.stockTransFeePercent.ToString());
            aFields.Add(configKeys.stockSell2BuyInterval.ToString());
            
            aFields.Add(configKeys.stockPriceWeight.ToString());
            aFields.Add(configKeys.stockVolumeWeight.ToString());

            aFields.Add(configKeys.stockMaxBuyQtyPerc.ToString());
            aFields.Add(configKeys.stockReduceQtyPerc.ToString());
            aFields.Add(configKeys.stockAccumulateQtyPerc.ToString());
            aFields.Add(configKeys.stockTotalCapAmt.ToString());
            aFields.Add(configKeys.stockMaxBuyAmtPerc.ToString());


            aValues.Clear();
            aValues.Add(Settings.sysStockTransFeePercent.ToString());
            aValues.Add(Settings.sysStockSell2BuyInterval.ToString());
            
            aValues.Add(Settings.sysStockPriceWeight.ToString());
            aValues.Add(Settings.sysStockVolumeWeight.ToString());

            aValues.Add(Settings.sysStockMaxBuyQtyPerc.ToString());
            aValues.Add(Settings.sysStockReduceQtyPerc.ToString());
            aValues.Add(Settings.sysStockAccumulateQtyPerc.ToString());
            aValues.Add(Settings.sysStockTotalCapAmt.ToString());
            aValues.Add(Settings.sysStockMaxBuyAmtPerc.ToString());
            configuration.SaveConfig(aFields, aValues);
        }

        public static void Load_Sys_Settings_CHART()
        {
            decimal d = 0; 
            //Color page
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysChartBgColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartFgColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartGridColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartVolumesColor }));

            aFields.Add(common.system.GetName(new { Settings.sysChartLineCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBearCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBullCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBarDnColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBarUpColor }));

            configuration.GetConfig(ref aFields);
            if (aFields[0].Trim() != "") Settings.sysChartBgColor = ColorTranslator.FromHtml(aFields[0]);
            if (aFields[1].Trim() != "") Settings.sysChartFgColor = ColorTranslator.FromHtml(aFields[1]);
            if (aFields[2].Trim() != "") Settings.sysChartGridColor = ColorTranslator.FromHtml(aFields[2]);
            if (aFields[3].Trim() != "") Settings.sysChartVolumesColor = ColorTranslator.FromHtml(aFields[3]);

            if (aFields[4].Trim() != "") Settings.sysChartLineCandleColor = ColorTranslator.FromHtml(aFields[4]);
            if (aFields[5].Trim() != "") Settings.sysChartBearCandleColor = ColorTranslator.FromHtml(aFields[5]);
            if (aFields[6].Trim() != "") Settings.sysChartBullCandleColor = ColorTranslator.FromHtml(aFields[6]);
            if (aFields[7].Trim() != "") Settings.sysChartBarDnColor = ColorTranslator.FromHtml(aFields[7]);
            if (aFields[8].Trim() != "") Settings.sysChartBarUpColor = ColorTranslator.FromHtml(aFields[8]);

            //Chart page
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysChartShowDescription }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowVolume }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowGrid }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowLegend }));

            aFields.Add(common.system.GetName(new { Settings.sysChartAutoScaleMetric }));
            aFields.Add(common.system.GetName(new { Settings.sysChartXScaleMetric }));
            aFields.Add(common.system.GetName(new { Settings.sysChartYScaleMetric }));

            aFields.Add(common.system.GetName(new { Settings.sysChartAutoPanMetric}));
            aFields.Add(common.system.GetName(new { Settings.sysChartXPanMetric }));
            aFields.Add(common.system.GetName(new { Settings.sysChartYPanMetric }));

            configuration.GetConfig(ref aFields);
            Settings.sysChartShowDescription = (aFields[0].Trim() == Boolean.TrueString);
            Settings.sysChartShowVolume = (aFields[1].Trim() == Boolean.TrueString);
            Settings.sysChartShowGrid = (aFields[2].Trim() == Boolean.TrueString);
            Settings.sysChartShowLegend = (aFields[3].Trim() == Boolean.TrueString);

            Settings.sysChartAutoScaleMetric = (aFields[4].Trim() == Boolean.TrueString);
            if (aFields[5].Trim() != "")
            {
                decimal.TryParse(aFields[5], out d); Settings.sysChartXScaleMetric = d;
            }
            if (aFields[6].Trim() != "")
            {
                decimal.TryParse(aFields[6], out d); Settings.sysChartYScaleMetric = d;
            }

            Settings.sysChartAutoPanMetric = (aFields[7].Trim() == Boolean.TrueString);
            if (aFields[8].Trim() != "")
            {
                decimal.TryParse(aFields[8], out d); Settings.sysChartXPanMetric = d;
            }
            if (aFields[9].Trim() != "")
            {
                decimal.TryParse(aFields[9], out d); Settings.sysChartYPanMetric = d;
            }
        }
        public static void Save_Sys_Settings_CHART()
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Clear();   
            aFields.Add(common.system.GetName(new { Settings.sysChartBgColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartFgColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartGridColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartVolumesColor }));

            aFields.Add(common.system.GetName(new { Settings.sysChartLineCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBearCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBullCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBarDnColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBarUpColor }));
            
            aValues.Clear();
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBgColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartFgColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartGridColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartVolumesColor));

            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartLineCandleColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBearCandleColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBullCandleColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBarDnColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBarUpColor));
            configuration.SaveConfig(aFields, aValues);

            //Chart page
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysChartShowDescription }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowVolume }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowGrid }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowLegend }));

            aFields.Add(common.system.GetName(new { Settings.sysChartAutoScaleMetric }));
            aFields.Add(common.system.GetName(new { Settings.sysChartXScaleMetric }));
            aFields.Add(common.system.GetName(new { Settings.sysChartYScaleMetric }));

            aFields.Add(common.system.GetName(new { Settings.sysChartAutoPanMetric }));
            aFields.Add(common.system.GetName(new { Settings.sysChartXPanMetric }));
            aFields.Add(common.system.GetName(new { Settings.sysChartYPanMetric }));

            aValues.Clear();
            aValues.Add(Settings.sysChartShowDescription.ToString());
            aValues.Add(Settings.sysChartShowVolume.ToString());
            aValues.Add(Settings.sysChartShowGrid.ToString());
            aValues.Add(Settings.sysChartShowLegend.ToString());

            aValues.Add(Settings.sysChartAutoScaleMetric.ToString());
            aValues.Add(Settings.sysChartXScaleMetric.ToString());
            aValues.Add(Settings.sysChartYScaleMetric.ToString());

            aValues.Add(Settings.sysChartAutoPanMetric.ToString());
            aValues.Add(Settings.sysChartXPanMetric.ToString());
            aValues.Add(Settings.sysChartYPanMetric.ToString());

            configuration.SaveConfig(aFields, aValues);
        }

        public static void GetConfig(ref StringCollection aFields)
        {
            for (int idx = 0; idx < aFields.Count; idx++)
            {
                aFields[idx] = dataLibs.GetConfig(aFields[idx].ToString());
                if (withEncryption && aFields[idx].ToString().Trim() != "")
                {
                    aFields[idx] = common.cryption.Decrypt(aFields[idx].ToString());
                }
            }
        }
        public static void SaveConfig(StringCollection aFields, StringCollection aValues)
        {
            string value;
            for (int idx = 0; idx < aFields.Count; idx++)
            {
                value = aValues[idx].ToString();
                if (withEncryption && (value.Trim() != ""))
                {
                    value = common.cryption.Encrypt(value);
                }
                dataLibs.SaveConfig(aFields[idx].ToString(), value);
            }
        }
    }
}
