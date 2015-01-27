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
using commonTypes;

namespace databases
{
    public static class SysLibs
    {
        private static string _dbConnectionString = null;
        public static string dbConnectionString
        {
            get
            {
                if (Properties.Settings.Default.environment == "localT440")
                    _dbConnectionString = "Data Source=(local);Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=P@ssword123";
                if (Properties.Settings.Default.environment == "localHP")
                    _dbConnectionString = "Data Source=HAIQUAN\\MSSQLSERVER2008;Database=stock;User ID=sa;Password=123";
                if (Properties.Settings.Default.environment == "SITT440")
                    _dbConnectionString = "Data Source=HAIQUAN\\MSSQLSERVER2008;Database=stock;User ID=sa;Password=123";
                if (Properties.Settings.Default.environment == "Prod")
                    _dbConnectionString = "Data Source=(local);Database=stock;User ID=sa;Password=123456";

                if (commonTypes.Settings.sysDebugMode)
                    //return "Data Source=localhost\\SQL08;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=123";
                    return "Data Source=(local);Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=P@ssword123";
                
                
                
                return _dbConnectionString;
                //if (_dbConnectionString == null)
                //{
                //    common.dbConnectionInfo dbInfo = common.configuration.GetDbConectionInfo(0, true); //The first connection string
                //    _dbConnectionString = common.database.BuidConnectionString(dbInfo);
                //}
                //return _dbConnectionString;
            }
            set
            {
                _dbConnectionString = value;
            }
        }

        private static string _importConnectionString = null;
        public static string importConnectionString
        {
            get
            {
                if (commonTypes.Settings.sysDebugMode)
                //return "Data Source=localhost\\SQL08;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";
                    return "Data Source=(local);Initial Catalog=stock-import;Persist Security Info=True;User ID=sa;Password=P@ssword123";
                _importConnectionString = "Data Source=(local);Initial Catalog=stock-import;Persist Security Info=True;User ID=sa;Password=P@ssword123";
                return _importConnectionString;
                //if (_importConnectionString == null)
                //{
                //    common.dbConnectionInfo dbInfo = common.configuration.GetDbConectionInfo(1, false); //The second connection string
                //    //Use the first connection string if the second one doesnot exist
                //    if (dbInfo!=null) _importConnectionString = common.database.BuidConnectionString(dbInfo);
                //    else _importConnectionString = dbConnectionString;
                //}
                //return _importConnectionString;
            }
            set
            {
                _importConnectionString = value;
            }
        }

        //private static string _stockConnectionString = null;
        //public static string stockConnectionString
        //{
        //    get
        //    {
        //        //if (common.Settings.sysDebugMode)
        //        //  return "Data Source=localhost\\SQL08;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=123";
        //        //_dbConnectionString = "Data Source=HAIQUAN\\MSSQLSERVER2008;Database=stock;User ID=sa;Password=123";
        //        _stockConnectionString = "Data Source=MOSS-SVR6;Database=stock;User ID=sa;Password=P@ssword123";
        //        return _stockConnectionString;
        //        if (_stockConnectionString == null)
        //        {
        //            common.dbConnectionInfo dbInfo = common.configuration.GetDbConectionInfo(0, true); //The first connection string
        //            _stockConnectionString = common.database.BuidConnectionString(dbInfo);
        //        }
        //        return _stockConnectionString;
        //    }
        //    set
        //    {
        //        _stockConnectionString = value;
        //    }
        //}

        public static bool CheckAllDbConnection()
        {
            return  common.database.CheckDbConnection(dbConnectionString) &&
                    common.database.CheckDbConnection(importConnectionString);
        }
        public static void ClearConnectionString()
        {
            _dbConnectionString = null;
            _importConnectionString = null;
        }
    }
}
