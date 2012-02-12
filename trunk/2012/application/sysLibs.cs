using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Data;
using System.Windows.Forms; 
using System.Data.SqlClient;
using System.Drawing;
using System.Transactions;
using commonClass;

namespace application
{
    public class test
    {
        public static bool LoadTestConfig()
        {
            data.SysLibs.dbConnectionString = "Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";

            common.Settings.sysProductOwner = commonClass.Consts.constProductOwner;
            common.Settings.sysProductCode = commonClass.Consts.constProductCode;
            common.Consts.constValidCallString = common.Consts.constValidCallMarker;

            commonClass.Configuration.withEncryption = true;
            Configuration.Load_User_Envir();

            commonClass.SysLibs.sysLoginCode = "A00000004";
            return true;
        }
    }
    public class ErrorHandler
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
    public class CommonLibs
    {
        public static string GetUnitTempTableName()
        {
            return "#" + common.system.UniqueString();
        }
        public static bool PasswordIsValid(string password, out string errMsg)
        {
            errMsg = "";
            if (password.TrimEnd().Length < commonClass.Settings.sysGlobal.PasswordMinLen)
            {
                errMsg = "Mật khẩu phải có ít nhất " + commonClass.Settings.sysGlobal.PasswordMinLen.ToString() + Languages.Libs.GetString("characters");
                return false;
            }
            return true;
        }
        public static int Permission2Number(string permission)
        {
            if (permission.Trim() == "") return common.Consts.constPermissionNONE;
            int perm = 0;
            if (permission.Contains(commonClass.Consts.constUserPermissionADD.ToString())) perm += common.Consts.constPermissionADD;
            if (permission.Contains(commonClass.Consts.constUserPermissionEDIT.ToString())) perm += common.Consts.constPermissionEDIT;
            if (permission.Contains(commonClass.Consts.constUserPermissionDEL.ToString())) perm += common.Consts.constPermissionDEL;
            return perm;
        }
        public static string Number2Permission(int number)
        {
            if (number == 0) return "";
            string permission = "";
            if ((number & common.Consts.constPermissionADD) > 0) permission += commonClass.Consts.constUserPermissionADD.ToString();
            if ((number & common.Consts.constPermissionDEL) > 0) permission += commonClass.Consts.constUserPermissionDEL.ToString();
            if ((number & common.Consts.constPermissionEDIT) > 0) permission += commonClass.Consts.constUserPermissionEDIT.ToString();
            return permission;
        }
        public static int GetFormPermission(string formCode)
        {
            string permission;
            permission = commonClass.Consts.constUserPermissionADD.ToString() +
                             commonClass.Consts.constUserPermissionDEL.ToString() +
                             commonClass.Consts.constUserPermissionEDIT.ToString();
            return Permission2Number(permission);

            if (commonClass.SysLibs.isSupperAdminLogin())
            {
                permission = commonClass.Consts.constUserPermissionADD.ToString() +
                             commonClass.Consts.constUserPermissionDEL.ToString() +
                             commonClass.Consts.constUserPermissionEDIT.ToString();
                return Permission2Number(permission);
            }
            //permission = dataLibs.GetWorkerAllPermission(commonClass.Consts.constSysPermissionMenu,
            //                                            sysLibs.sysLoginUserId, formCode);
            //return Permission2Number(permission);
        }
    }

    public class SysLibs
    {
        public static common.myAutoKeyInfo GetAutoKey(string key, bool usePending)
        {
            DateTime curTimeStamp = common.Consts.constNullDate;
            data.baseDS.sysAutoKeyPendingDataTable sysAutoKeyPendingTbl = new data.baseDS.sysAutoKeyPendingDataTable();
            //First try to re-used unused keys if required
            if (usePending)
            {
                curTimeStamp = DateTime.Now;
                DateTime minTimeStamp = curTimeStamp.AddSeconds(-Settings.sysGlobal.TimeOut_AutoKey);
                sysAutoKeyPendingTbl.Clear();
                DbAccess.LoadData(sysAutoKeyPendingTbl, key);
                if (sysAutoKeyPendingTbl.Count > 0)
                {
                    for (int idx = 0; idx < sysAutoKeyPendingTbl.Count; idx++)
                    {
                        //Still valid : ignore it
                        if (sysAutoKeyPendingTbl[idx].timeStamp > minTimeStamp) continue;

                        //The the first invalid key will be used. Updating the timestamp to make it valid again.
                        sysAutoKeyPendingTbl[idx].timeStamp = curTimeStamp;
                        DbAccess.UpdateData(sysAutoKeyPendingTbl[idx]);
                        return new common.myAutoKeyInfo(key, sysAutoKeyPendingTbl[idx].value, sysAutoKeyPendingTbl[idx].value.Trim());
                    }
                }
            }
            //Then, create a new key and pending key if required
            data.baseDS.sysAutoKeyRow sysAutoKeyRow = DbAccess.NewAutoKeyValue(key);
            if (usePending) DbAccess.CreateAutoPendingKey(sysAutoKeyRow.key, sysAutoKeyRow.value.ToString(), curTimeStamp);
            string valueStr = sysAutoKeyRow.value.ToString().Trim();
            return new common.myAutoKeyInfo(key, valueStr, valueStr);
        }
        public static void DeleteKeyPending(common.myAutoKeyInfo autoKeyInfo)
        {
            //Remove the used key in pending list
            DbAccess.DeleteAutoKeyPending(autoKeyInfo.key, autoKeyInfo.value);
        }

        public static string GetAutoDataKey(string tblName, bool usePending)
        {
            return GetAutoDataKey(tblName, Settings.sysGlobal.DataKeyPrefix, Settings.sysGlobal.DataKeySize, usePending);
        }
        public static string GetAutoDataKey(string tblName, string prefix, int maxLen, bool usePending)
        {
            common.myAutoKeyInfo keyInfo = GetAutoKey(tblName, usePending);
            if (keyInfo == null) return null;
            return prefix + keyInfo.value.PadLeft(maxLen - prefix.Length, '0');
        }

        #region FindAndCache
        private static data.baseDS myCachedDS = new data.baseDS();
        private static data.tmpDS myCachedTmpDS = new data.tmpDS();
        public static void ClearCache()
        {
            myCachedDS.Clear();
            myCachedTmpDS.Clear();
        }

        public static data.baseDS.stockExchangeDataTable myStockExchangeTbl
        {
            get
            {
                if (myCachedDS.stockExchange.Count==0)
                {
                    application.DbAccess.LoadData(myCachedDS.stockExchange);
                }
                return myCachedDS.stockExchange;
            }
        }

        public static data.baseDS.stockExchangeRow FindAndCache_StockExchange(string code)
        {
            data.baseDS.stockExchangeRow row = myCachedDS.stockExchange.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.stockExchangeTA dataTA = new data.baseDSTableAdapters.stockExchangeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(myCachedDS.stockExchange);
            row = myCachedDS.stockExchange.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.stockCodeRow FindAndCache_StockCode(string code)
        {
            data.baseDS.stockCodeRow row = myCachedDS.stockCode.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.stockCodeTA dataTA = new data.baseDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(myCachedDS.stockCode, code);
            row = myCachedDS.stockCode.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static data.baseDS.portfolioRow FindAndCache(data.baseDS.portfolioDataTable tbl, string code)
        {
            data.baseDS.portfolioRow row = tbl.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.portfolioTA dataTA = new data.baseDSTableAdapters.portfolioTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static data.baseDS.bizSubSectorRow FindAndCache(data.baseDS.bizSubSectorDataTable tbl, string code)
        {
            data.baseDS.bizSubSectorRow row = tbl.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.bizSubSectorTA dataTA = new data.baseDSTableAdapters.bizSubSectorTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.bizSubSectorRow FindAndCache_BizSubSector(string code)
        {
            return FindAndCache(myCachedDS.bizSubSector, code);
        }

        public static data.tmpDS.stockCodeRow FindAndCache_StockCodeShort(string code)
        {
            data.tmpDS.stockCodeRow row = myCachedTmpDS.stockCode.FindBycode(code);
            if (row != null) return row;
            data.tmpDSTableAdapters.stockCodeTA dataTA = new data.tmpDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(myCachedTmpDS.stockCode, code);
            row = myCachedTmpDS.stockCode.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static data.tmpDS.stockCodeRow FindAndCache(data.tmpDS.stockCodeDataTable tbl, string code)
        {
            data.tmpDS.stockCodeRow row = tbl.FindBycode(code);
            if (row != null) return row;
            data.tmpDSTableAdapters.stockCodeTA dataTA = new data.tmpDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        #endregion
    }
}
