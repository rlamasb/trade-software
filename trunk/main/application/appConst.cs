using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Drawing;

namespace application
{
    public class Consts
    {
        // tmpDataset.analysisData only have 10 indicator values[0-9]
        //public const int constMaxIndicatorValueFld = 10;
        public const string constProductOwner = "Dung Vu";
        public const string constProductCode = "STOCKTRADING";

        public const char constUserPermissionADD = 'a';
        public const char constUserPermissionDEL = 'd';
        public const char constUserPermissionEDIT = 'e';

        public const string constNotAvailable = "N/A";
        //Statement type
        public const string constSysPortfolioCode = "SPORTFOLIO";

        //Worker type
        public const string constWorkerTypeAdmin = "ADM";

        //=================================================================================
        //Sys configuration 
        //=================================================================================
        //Microsoft system : http://support.microsoft.com/kb/320584
        public const int WM_KEYDOWN = 0x100;
        public const int WM_SYSKEYDOWN = 0x104;

        //Application titles
        public const string constApplicationName = "System";
        public const string constSysPermissionMenu = "MEN";
    }
    public class Settings
    {
        public static string sysUserConfigFile
        {
            get
            {
                return common.fileFuncs.GetFullPath("user.xml");
            }
        }

        public static AppTypes.TimeRanges sysScreeningTimeRange = AppTypes.TimeRanges.Y1;
        public static AppTypes.TimeScale sysScreeningTimeScale = AppTypes.TimeScaleFromCode("D1");

        public static AppTypes.TimeRanges sysDefaultTimeRange = AppTypes.TimeRanges.Y5;
        public static string sysDefaultTimeScaleCode = "D1";

        public static string sysString_All_Description ="<All>";
        public static string sysString_All_Code = "**";

        public static DateTime sysStartDataDate = DateTime.Parse("2006/01/01");
        public static int sysAutoRefreshInSeconds = 5 * 60;

        // Multi-value field is stored in the format: <prefix><value><postfix><separator>
        public static string sysListSeparatorPrefix = "/";
        public static string sysListSeparatorPostfix = "/";
        public static string sysListSeparator = " ";

        public static bool sysDebugMode
        {
            get { return common.settings.sysDebugMode;}
            set
            {
                common.settings.sysDebugMode = value;
            }
        }
        public static bool sysUseStrongPassword = false;

        // Auto-generated edit key has the form  <number><postfix>
        // myAutoEditKeySize specifies the lenght of <number> part 
        public static int sysAutoEditKeySize = 4;
        
        // Auto-generated data has the form  <prefix><numeric string>
        // sysDataKeySize specifies the lenght of <number string> part 
        public static int sysDataKeySize = 9;
        public static string sysDataKeyPrefix = "A";

        //Maximum time (in seconds) that consider an auto key is valid.
        public static int sysTimeOut_AutoKey = 2 * 60; //2 Minutes

        //Default        
        public static int sysDefaultLoginAccountDayToExpire = 365;
        public static string sysSuperAdminName = "admin";
        public static string sysDefaultImageFile = "images/employee.png";

        //Country
        public static string sysDefaultCountry = "VN";


        //Date when the system start : used in create trade alert,...
        //public static DateTime sysStartDate = DateTime.Parse("2011/01/01");

        //Minimum pasword len
        public static byte sysPasswordMinLen = 0;

        public static Color sysColorTradePoint = Color.Red;
        public static Color sysColorTradePointAnnotation = Color.FromArgb(255, 255, 128);


        //Date format : use French
        public static string sysCultureCode = "vi-VN";

        //Currency
        public static string sysMainCurrency = "V";
        public static string sysMainCurrencyDisplay = "VND";
        public static string sysMainCurrencyText = "dong";
        public static string sysMainCurrencyName = "Viet nam dong";

        //Customed format
        public static int sysPrecisionPercentage = 1;
        public static int sysPrecisionPrice = 1;
        public static int sysPrecisionQty = 0;
        public static int sysPrecisionLocal = 0;
        public static int sysPrecisionForeign = 2;

        public static string sysLocalAmtMask = "###,###,###,###,##0";
        public static string sysForeignAmtMask = "###,###,###,##0.00";
        public static string sysPercentMask = "#0";
        public static string sysQtyMask = "###,###,##0.00";

        //Stock
        public static short sysStockSell2BuyInterval = 3;
        public static decimal sysStockTransFeePercent = 0.2m;
        public static decimal sysStockPriceWeight = 1000;
        public static decimal sysStockVolumeWeight = 10;
        public static decimal sysStockMaxBuyQtyPerc = 10;
        public static decimal sysStockReduceQtyPerc = 10;
        public static decimal sysStockAccumulateQtyPerc = 10;
        public static decimal sysStockTotalCapAmt = 10000000;
        public static decimal sysStockMaxBuyAmtPerc = 100;
        
        //Chart property settings
        public static Color sysChartBgColor = Color.White;
        public static Color sysChartFgColor = Color.Black;
        public static Color sysChartGridColor = Color.Black;

        public static Color sysChartVolumesColor = Color.Navy;
        public static Color sysChartLineCandleColor = Color.DarkBlue;
        public static Color sysChartBearCandleColor = Color.Red;
        public static Color sysChartBullCandleColor = Color.Green;
        public static Color sysChartBarDnColor = Color.Pink;
        public static Color sysChartBarUpColor = Color.Blue;

        public static bool sysChartShowDescription = true;
        public static bool sysChartShowVolume = true;
        public static bool sysChartShowGrid = true;
        public static bool sysChartShowLegend = true;

        public static bool sysChartAutoScaleMetric = false;
        public static bool sysChartAutoPanMetric = false;
        public static decimal sysChartYScaleMetric = 1;
        public static decimal sysChartXScaleMetric = 1;
        public static decimal sysChartXPanMetric = 1;
        public static decimal sysChartYPanMetric = 1;
    }
    public class AppTypes
    {
        public enum ChartTypes : byte { None, Line, Bar, CandleStick };

        public enum MarketTrend : byte { Unspecified = 0, Sidebar = 1, Upward = 2, Downward = 3 };
        public enum TradeActions : byte { None = 0, Buy = 1, Sell = 2, Accumulate = 3, ClearAll = 4, Select = 5 };

        /// PortfolioTypes conatain all possible values in portfolio.Type column. PortfolioTypes value is bitwise.
        /// The meaning of each type is explained bellows.
        /// - Portfolio : users can create one or may portfolios to ease their management.Stocks are put into user's portfolios when trading.
        /// - SysWatchList : stockcodes list defined by system admin and listed in their watch list.
        /// - WatchList : stockcodes list defined by users.
        public enum PortfolioTypes : byte { Portfolio = 1, WatchList = 2, SysWatchList = 4, SysPortfolio = 8 };

        public enum StrategyTypes : byte { Strategy = 1, Screening = 2 };

        //public enum PortfolioDetailDataType : byte { None = 0, Strategy = 1 };
        public enum BizSectorTypes : byte { None = 0, Industry = 1, SuperSector = 2, Sector = 3, SubSector = 4 };
        public enum CommonStatus : byte { None = 0, New = 1, Enable = 2, Disable = 4, Close = 8, Ignore = 16, All = 255 };

        public enum  TimeScaleTypes { RealTime, Minnute, Hour, Day, Week, Month, Year};
        public class TimeScale
        {
            public TimeScale(TimeScaleTypes type, byte value, string code, string text)
            {
                new TimeScale(type, value, code, text, text);
            }
            public TimeScale(TimeScaleTypes type, byte value, string code, string text, string description)
            { 
                this.Type = type;
                this.AggregationValue = value;
                this.Code = code;
                this.Text = text;
                this.Description = description ;
            }
            public TimeScaleTypes Type = TimeScaleTypes.RealTime;
            // The number of time (minute,hour,day,week...) to aggregate data
            public byte AggregationValue = 1;
            public string Code = "", Text = "",Description="";
        };
        //List all time scale used in the system
        public static TimeScale[] myTimeScales = new TimeScale[]
        { 
            new TimeScale(TimeScaleTypes.RealTime,0,"RT","M5","5 mins"), //Real time : collected in each 5 minutes
            new TimeScale(TimeScaleTypes.Hour,1, "H1","H1", "1 hour"), 
            new TimeScale(TimeScaleTypes.Hour,2, "H2","H2", "2 hours"), 
            new TimeScale(TimeScaleTypes.Day, 1, "D1","D1", "Day"), 
            new TimeScale(TimeScaleTypes.Week,1, "W1","W1", "Week"), 
            new TimeScale(TimeScaleTypes.Month,1,"O1","MN", "Month"), 
        };
        // Data collected in realtime and then aggregate to different time scales  
        // MainDataTimeScale specifies the TimeScale for the realtime data 
        public static TimeScale MainDataTimeScale
        {
            get
            {
                return myTimeScales[0];
            }
        }
        public static TimeScale TimeScaleFromCode(string str)
        {
            foreach (AppTypes.TimeScale item in myTimeScales)
            {
                if (item.Code == str) return item;
            }
            return MainDataTimeScale;
        }
        public static TimeRanges TimeRangeFromCode(string str)
        {
            foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
            {
                if (item.ToString()== str) return item;
            }
            return TimeRanges.None;
        }

        public enum TimeRanges : byte
        {
            None,W1,W2,W3,M1,M2,M3,M4,M5,M6,YTD,Y1,Y2,Y3,Y4,Y5,All
        };
        public enum Sex : byte { None = 0, Male = 1, Female = 2, Unspecified = 3 };
       
        public static string Type2Text(StrategyTypes value)
        {
            switch (value)
            {
                case StrategyTypes.Strategy: return "Strategy";
                case StrategyTypes.Screening: return "Screening";
                default: return "";
            }
        }
        public static string Type2Text(Sex value)
        {
            switch (value)
            {
                case Sex.Male: return "Male";
                case Sex.Female: return "Female";
                case Sex.Unspecified: return "Unspecified";
                default: return "";
            }
        }
        public static string Type2Text(CommonStatus value)
        {
            switch (value)
            {
                case CommonStatus.New: return "Mới";
                case CommonStatus.Enable: return "Họat động";
                case CommonStatus.Disable: return "Ngưng";
                case CommonStatus.Close: return "Đóng";
                case CommonStatus.Ignore: return "Tạm hủy";
                default: return "N/A";
            }
        }
        public static string Type2Text(TimeRanges value)
        {
            switch (value)
            {
                case TimeRanges.W1:  return "01 week";
                case TimeRanges.W2:  return "02 weeks";
                case TimeRanges.W3:  return "03 weeks";
                case TimeRanges.M1:  return "01 month";
                case TimeRanges.M2:  return "02 months";
                case TimeRanges.M3:  return "03 months";
                case TimeRanges.M4:  return "04 months";
                case TimeRanges.M5:  return "05 months";
                case TimeRanges.M6:  return "06 month";
                case TimeRanges.YTD: return "Year to date"; //Year to date
                case TimeRanges.Y1:  return "01 year";
                case TimeRanges.Y2: return "02 years";
                case TimeRanges.Y3: return "03 years";
                case TimeRanges.Y4: return "04 years";
                case TimeRanges.Y5: return "05 year";
                case TimeRanges.All: return "All";
                default: return "N/A";
            }
        }
        public static string Type2Text(ChartTypes value)
        {
            switch (value)
            {
                case ChartTypes.Line: return "Line";
                case ChartTypes.Bar: return "Bar";
                case ChartTypes.CandleStick: return "CandleStick";
                default: return "<Select>";
            }
        }
        public static string Type2Text(BizSectorTypes value)
        {
            switch (value)
            {
                case BizSectorTypes.Industry: return "Ngành/Industry)";
                case BizSectorTypes.SuperSector: return "Nhóm ngành/SuperSector";
                case BizSectorTypes.Sector: return "Nhóm lãnh vực/Sector";
                case BizSectorTypes.SubSector: return "Lãnh vực/Subsector";
                default: return "<Chọn>";
            }
        }

        public static StrategyTypes Text2StrategyType(string str)
        {
            if (str.ToLower().Trim() == StrategyTypes.Screening.ToString().ToLower()) return StrategyTypes.Screening;
            return StrategyTypes.Strategy;
        }
        public static ChartTypes Text2ChartType(string str)
        {
            str = str.Trim().ToLower();
            if (str == ChartTypes.Bar.ToString().ToLower()) return ChartTypes.Bar;
            if (str == ChartTypes.CandleStick.ToString().ToLower()) return ChartTypes.CandleStick;
            return ChartTypes.Line;
        }        
        /// <summary>
        /// Convert enum type to table (code,description);
        /// </summary>
        /// <param name="type"> enum type of byte </param>
        /// <returns>Table with 2 columns code(byte), description(string)</returns>
        public static DataTable CreateTableEnumType(Type type)
        {
            DataTable tbl = new DataTable();
            // Define columns
            DataColumn col1 = new DataColumn("code", typeof(byte)); tbl.Columns.Add(col1);
            DataColumn col2 = new DataColumn("description"); tbl.Columns.Add(col2);
            foreach (AppTypes.TradeActions item in Enum.GetValues(type))
            {
                DataRow row = tbl.Rows.Add((byte)item);
                row[1] = item.ToString();
            }
            return tbl;
        }
        public static DataTable CreateTableTimeScale()
        {
            DataTable tbl = new DataTable();
            // Define columns
            DataColumn col1 = new DataColumn("code"); tbl.Columns.Add(col1);
            DataColumn col2 = new DataColumn("description"); tbl.Columns.Add(col2);
            for (int idx = 0; idx < AppTypes.myTimeScales.Length; idx++)
            {
                DataRow row = tbl.Rows.Add(AppTypes.myTimeScales[idx].Code, AppTypes.myTimeScales[idx].Text);
            }
            return tbl;
        }

        public static DataTable CreateTableCommonStatus()
        {
            return CreateTableEnumType(typeof(CommonStatus));
        }
        public static DataTable CreateTableTradeActions()
        {
            return CreateTableEnumType(typeof(TradeActions));  
        }

        public static bool GetDate(application.AppTypes.TimeRanges timeRange, out DateTime startDate, out DateTime endDate)
        {
            startDate = common.Consts.constNullDate;
            endDate = common.Consts.constNullDate;
            bool retVal = true;
            switch (timeRange)
            {
                case application.AppTypes.TimeRanges.W1:
                    endDate = DateTime.Today;
                    startDate = endDate.AddDays(-7);
                    break;
                case application.AppTypes.TimeRanges.W2:
                    endDate = DateTime.Today;
                    startDate = endDate.AddDays(-14);
                    break;
                case application.AppTypes.TimeRanges.W3:
                    endDate = DateTime.Today;
                    startDate = endDate.AddDays(-21);
                    break;

                case application.AppTypes.TimeRanges.M1:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-1);
                    break;
                case application.AppTypes.TimeRanges.M2:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-2);
                    break;
                case application.AppTypes.TimeRanges.M3:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-3);
                    break;
                case application.AppTypes.TimeRanges.M4:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-5);
                    break;
                case application.AppTypes.TimeRanges.M5:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-5);
                    break;
                case application.AppTypes.TimeRanges.M6:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-6);
                    break;

                case application.AppTypes.TimeRanges.YTD:
                    endDate = DateTime.Today;
                    common.dateTimeLibs.MakeDate(1, 1, endDate.Year, out startDate);
                    break;
                case application.AppTypes.TimeRanges.Y1:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-1);
                    break;
                case application.AppTypes.TimeRanges.Y2:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-2);
                    break;
                case application.AppTypes.TimeRanges.Y3:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-3);
                    break;
                case application.AppTypes.TimeRanges.Y4:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-4);
                    break;
                case application.AppTypes.TimeRanges.Y5:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-5);
                    break;

                case application.AppTypes.TimeRanges.All:
                    startDate = DateTime.MinValue;
                    endDate = DateTime.MaxValue;
                    return true;
                default:
                    retVal = false;
                    break;
            }
            endDate = endDate.Date.AddDays(1).AddSeconds(-1);
            return retVal;
        }
    }
}
