using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Drawing;

namespace application
{
    public class Settings
    {
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
        public static string sysMainCurrencyDisplay = "VNĐ";
        public static string sysMainCurrencyText = "đồng";
        public static string sysMainCurrencyName = "Việt nam đồng";

        //Customed format
        public static int sysPrecisionPercentage = 1;
        public static int sysPrecisionQty = 2;
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
    public class Consts
    {
        //public const string constTimeScaleRealTimeCode = "RT";

        // tmpDataset.analysisData only have 10 indicator values[0-9]
        public const int constMaxIndicatorValueFld = 10;
        public const string constProductOwner = "Dung Vu";
        public const string constProductCode = "STOCKTRADING";

        public const char constUserPermissionADD = 'a';
        public const char constUserPermissionDEL = 'd';
        public const char constUserPermissionEDIT = 'e';

        public const string constNotAvailable = "N/A";
        
        public const string constWorkReward = "RE";
        public const string constWorkReward_Punish = "RP";

        //Statement type
        public const string constStatementType_wgLoan = "LOA";
        public const string constStatementType_wgPayment = "PAY";
        public const string constStatementType_wgReceive = "REI";
        public const string constStatementType_wgOutOffice = "OOF";
        public const string constStatementType_wgProduct = "WPR";
        public const string constStatementType_wgBonus = "BON";
        public const string constStatementType_wgEmSalay = "WES";
        public const string constStatementType_wgPolicy = "WPO";
        public const string constStatementType_geProdUnitCost = "PUC";

        //Worker type
        public const string constWorkerTypeAdmin = "ADM";

        //=================================================================================
        //Sys configuration 
        //=================================================================================
        //Microsoft system : http://support.microsoft.com/kb/320584
        public const int WM_KEYDOWN = 0x100;
        public const int WM_SYSKEYDOWN = 0x104;

        //Application titles
        public const string constApplicationName = "Quan ly";
        public const string constSysPermissionMenu = "MEN";   
    }
    public class myTypes
    {
        public enum ChartTypes  : byte { None,Line, Bar, CandelStick };
        public enum TradeActions : byte { None = 0, Buy = 1, Sell = 2, Accumulate = 3, ClearAll = 4, Select = 5 };

        public enum ScreeningCriteriaTypes : byte { None = 0, TotalVolume = 1, ForeignOwnVolume = 2, TargetPrice = 3, MarketCap = 4, LastMonthTransVolume = 5, };
        public class ScreeningCriteria
        {
            public ScreeningCriteriaTypes code = ScreeningCriteriaTypes.None;
            public double min = 0, max = 0;
        }

        public enum PortfolioTypes : byte { Portfolio = 1, WatchList = 2 };
        public enum StrategyTypes : byte { Strategy = 1, Screening = 2 };

        public enum PortfolioDetailDataType : byte { None = 0, Strategy = 1 };
        public enum BizSectorTypes : byte { None = 0, Industry = 1, SuperSector = 2, Sector = 3, SubSector = 4 };
        public enum CommonStatus : byte { None = 0, New = 1, Enable = 2, Disable = 4, Close = 8, Ignore = 16, All = 255 };

        public enum  TimeScaleTypes { RealTime, Minnute, Hour, Day, Week, Month, Year};
        public class TimeScale
        {
            public TimeScale(TimeScaleTypes _type, byte _value, string _code, string _text)
            { 
                this.Type =_type;
                this.AggregationValue = _value;
                this.Code =_code;
                this.Text =_text;
            }
            public TimeScaleTypes Type = TimeScaleTypes.RealTime;
            // The number of time (minute,hour,day,week...) to aggregate data
            public byte AggregationValue = 1;
            public string Code = "", Text = "";
        };
        //List all time scale used in the system
        public static TimeScale[] myTimeScales = new TimeScale[]
        { 
            new TimeScale(TimeScaleTypes.RealTime,0,"RT","M5"), //Real time : collected in each 5 minutes
            new TimeScale(TimeScaleTypes.Hour,1, "H1","H1"), 
            new TimeScale(TimeScaleTypes.Hour,2, "H2","H2"), 
            new TimeScale(TimeScaleTypes.Day, 1, "D1","D1"), 
            new TimeScale(TimeScaleTypes.Week,1, "W1","W1"), 
            new TimeScale(TimeScaleTypes.Month,1,"O1","MN"), 
            //new TimeScale(TimeScaleTypes.Year,1, "Y1","Y1")
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
            foreach (myTypes.TimeScale item in myTimeScales)
            {
                if (item.Code == str) return item;
            }
            return null;
        }


        public enum TimeRanges : byte
        {
            None = 0, D1 = 1, D3 = 2, W = 10, M1 = 20, M3 = 21, YTD = 30,
            Y1 = 40, Y2 = 41, Y3 = 42, Y4 = 43, Y5 = 44, Range = 255
        };
        public enum sex : byte { None = 0, Male = 1, Female = 2, Unspecified = 3 };


        public static string Type2Text(ScreeningCriteriaTypes value)
        {
            switch (value)
            {
                case ScreeningCriteriaTypes.LastMonthTransVolume: return "KLGD tháng cuối";
                case ScreeningCriteriaTypes.TotalVolume: return "Tổng KL";
                case ScreeningCriteriaTypes.ForeignOwnVolume: return "KLNN sở hữu";
                case ScreeningCriteriaTypes.TargetPrice: return "Giá đích";
                case ScreeningCriteriaTypes.MarketCap: return "Vốn";
                default: return "";
            }
        }
        public static string Type2Text(StrategyTypes value)
        {
            switch (value)
            {
                case StrategyTypes.Strategy: return "Strategy";
                case StrategyTypes.Screening: return "Screening";
                default: return "";
            }
        }
        public static string Type2Text(PortfolioTypes value)
        {
            switch (value)
            {
                case PortfolioTypes.Portfolio: return "Portfolio";
                case PortfolioTypes.WatchList: return "WatchList";
                default: return "";
            }
        }
        public static string Type2Text(sex value)
        {
            switch (value)
            {
                case sex.Male: return "Nam";
                case sex.Female: return "Nữ";
                case sex.Unspecified: return "Không xác định";
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
                case TimeRanges.D1: return "1 ngày";
                case TimeRanges.D3: return "3 ngày";
                case TimeRanges.W: return "1 tuần";
                case TimeRanges.M1: return "1 tháng";
                case TimeRanges.M3: return "3 tháng";
                case TimeRanges.YTD: return "Từ đầu năm"; //Year to date
                case TimeRanges.Y1: return "1 năm";
                case TimeRanges.Y2: return "2 năm";
                case TimeRanges.Y3: return "3 năm";
                case TimeRanges.Y4: return "4 năm";
                case TimeRanges.Y5: return "5 năm";
                case TimeRanges.Range: return "Tự chọn";
                default: return "N/A";
            }
        }
        public static string Type2Text(ChartTypes value)
        {
            switch (value)
            {
                case ChartTypes.Line: return "Dạng Đường";
                case ChartTypes.Bar: return "Dạng Thanh";
                case ChartTypes.CandelStick: return "Dạng Nến";
                default: return "<Chọn>";
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

        ///// <summary>
        ///// Convert myTypes.CommonStatus to table (code,description);
        ///// </summary>
        ///// <returns></returns>
        //public static DataTable CreateTableCommonStatus()
        //{
        //    DataTable tbl = new DataTable();
        //    // Define columns
        //    DataColumn col1 = new DataColumn("code", typeof(byte)); tbl.Columns.Add(col1);
        //    DataColumn col2 = new DataColumn("description"); tbl.Columns.Add(col2);
        //    foreach (myTypes.CommonStatus item in Enum.GetValues(typeof(myTypes.CommonStatus)))
        //    {
        //        DataRow row = tbl.Rows.Add((byte)item);
        //        row[1] = myTypes.Type2Text(item);
        //    }
        //    return tbl;
        //}
        ///// <summary>
        ///// Convert myTypes.TradeActions to table (code,description);
        ///// </summary>
        ///// <returns></returns>
        //public static DataTable CreateTradeActionsTable()
        //{
        //    DataTable tbl = new DataTable();
        //    // Define columns
        //    DataColumn col1 = new DataColumn("code", typeof(byte)); tbl.Columns.Add(col1);
        //    DataColumn col2 = new DataColumn("description"); tbl.Columns.Add(col2);
        //    foreach (myTypes.TradeActions item in Enum.GetValues(typeof()))
        //    {
        //        DataRow row = tbl.Rows.Add((byte)item);
        //        row[1] = item.ToString();
        //    }
        //    return tbl;
        //}

        
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
            foreach (myTypes.TradeActions item in Enum.GetValues(type))
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
            for (int idx = 0; idx < myTypes.myTimeScales.Length; idx++)
            {
                DataRow row = tbl.Rows.Add(myTypes.myTimeScales[idx].Code, myTypes.myTimeScales[idx].Text);
            }
            return tbl;
        }
    }
}
