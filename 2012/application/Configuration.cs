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
using commonTypes;
using commonClass;

namespace application
{
    public class Configuration
    {
        public const string constXMLElement_Root = "Application";
        public const string constXMLElement_Sub_System = "System";
        public const string constXMLElement_Sub_Database = "Database";
        public static bool withEncryption
        {
            get { return common.configuration.withEncryption; }
            set { common.configuration.withEncryption = value; }
        }

        public static void GetConfig(ref StringCollection aFields)
        {
            for (int idx = 0; idx < aFields.Count; idx++)
            {
                aFields[idx] = databases.DbAccess.GetConfig(aFields[idx].Trim());
                if (withEncryption && aFields[idx].Trim() != "")
                {
                    aFields[idx] = common.cryption.Decrypt(aFields[idx].Trim());
                }
            }
        }
        public static void SaveConfig(StringCollection aFields, StringCollection aValues)
        {
            string value;
            for (int idx = 0; idx < aFields.Count; idx++)
            {
                value = aValues[idx].Trim();
                if (withEncryption && (value.Trim() != ""))
                {
                    value = common.cryption.Encrypt(value);
                }
                databases.DbAccess.SaveConfig(aFields[idx].Trim(), value);
            }
        }

        //From database
        public static void Load_Global_Settings(ref GlobalSettings settings)
        {
            int num;
            StringCollection aFields = new StringCollection();
            // System
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.DeafautLanguage }));
            aFields.Add(common.system.GetName(new { settings.PasswordMinLen }));
            aFields.Add(common.system.GetName(new { settings.UseStrongPassword }));
            GetConfig(ref aFields);

            if (aFields[0].Trim() != "") settings.DeafautLanguage = AppTypes.Code2Language(aFields[0].Trim());
            if (int.TryParse(aFields[1], out num)) settings.PasswordMinLen = (byte)num;
            if (aFields[2].Trim() != "") settings.UseStrongPassword = (aFields[2] == Boolean.TrueString);

            //Auto key
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.DataKeyPrefix }));
            aFields.Add(common.system.GetName(new { settings.DataKeySize }));
            aFields.Add(common.system.GetName(new { settings.AutoEditKeySize }));
            aFields.Add(common.system.GetName(new { settings.TimeOut_AutoKey }));
            GetConfig(ref aFields);
            if (aFields[0].Trim() != "") settings.DataKeyPrefix = aFields[0].Trim();
            if (int.TryParse(aFields[1], out num)) settings.DataKeySize = num;
            if (int.TryParse(aFields[2], out num)) settings.AutoEditKeySize = num;
            if (int.TryParse(aFields[3], out num)) settings.TimeOut_AutoKey = num;

            //Email
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.smtpAddress }));
            aFields.Add(common.system.GetName(new { settings.smtpPort }));
            aFields.Add(common.system.GetName(new { settings.smtpAuthAccount }));
            aFields.Add(common.system.GetName(new { settings.smtpAuthPassword }));
            aFields.Add(common.system.GetName(new { settings.smtpSSL}));
            GetConfig(ref aFields);

            if (aFields[0].Trim() != "") settings.smtpAddress = aFields[0];
            if (aFields[1].Trim() != "" & int.TryParse(aFields[1], out num)) settings.smtpPort = num;
            settings.smtpAuthAccount = aFields[2].Trim();
            settings.smtpAuthPassword = aFields[3].Trim();
            settings.smtpSSL = (aFields[4].Trim() == Boolean.TrueString);

            //Parameters
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.AlertDataCount }));
            aFields.Add(common.system.GetName(new { settings.ScreeningDataCount }));

            aFields.Add(common.system.GetName(new { settings.ScreeningTimeScaleCode }));
            aFields.Add(common.system.GetName(new { settings.DefaultTimeRange }));
            aFields.Add(common.system.GetName(new { settings.DefaultTimeScaleCode}));
            GetConfig(ref aFields);

            if (aFields[0].Trim() != "" & int.TryParse(aFields[0], out num)) settings.AlertDataCount = num;
            if (aFields[1].Trim() != "" & int.TryParse(aFields[1], out num)) settings.ScreeningDataCount = num;

            if (aFields[2].Trim() != "") settings.ScreeningTimeScaleCode = aFields[2];
            if (aFields[3].Trim() != "") settings.DefaultTimeRange = AppTypes.TimeRangeFromCode(aFields[3]);
            if (aFields[4].Trim() != "") settings.DefaultTimeScaleCode = aFields[4];

            //Timming
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.TimerUnitInSecs }));
            aFields.Add(common.system.GetName(new { settings.TimerUnitToAutoCheck }));
            GetConfig(ref aFields);

            if (aFields[0].Trim() != "" & int.TryParse(aFields[0], out num)) settings.TimerUnitInSecs = (short)num;
            if (aFields[1].Trim() != "" & int.TryParse(aFields[1], out num)) settings.TimerUnitToAutoCheck = (short)num;

        }
        public static void Save_Global_Settings(GlobalSettings settings)
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            //System
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.DeafautLanguage }));
            aFields.Add(common.system.GetName(new { settings.PasswordMinLen }));
            aFields.Add(common.system.GetName(new { settings.UseStrongPassword }));
            
            aValues.Clear();
            aValues.Add(settings.DeafautLanguage.ToString());
            aValues.Add(settings.PasswordMinLen.ToString());
            aValues.Add(settings.UseStrongPassword.ToString());
            SaveConfig(aFields, aValues);

            //Autokey
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.DataKeyPrefix }));
            aFields.Add(common.system.GetName(new { settings.DataKeySize }));
            aFields.Add(common.system.GetName(new { settings.AutoEditKeySize }));
            aFields.Add(common.system.GetName(new { settings.TimeOut_AutoKey }));
            
            aValues.Clear();
            aValues.Add(settings.DataKeyPrefix);
            aValues.Add(settings.DataKeySize.ToString());
            aValues.Add(settings.AutoEditKeySize.ToString());
            aValues.Add(settings.TimeOut_AutoKey.ToString());
            SaveConfig(aFields, aValues);

            //Mail
            aFields.Clear(); 
            aFields.Add(common.system.GetName(new { settings.smtpAddress }));
            aFields.Add(common.system.GetName(new { settings.smtpPort }));
            aFields.Add(common.system.GetName(new { settings.smtpAuthAccount }));
            aFields.Add(common.system.GetName(new { settings.smtpAuthPassword }));
            aFields.Add(common.system.GetName(new { settings.smtpSSL }));

            aValues.Clear();
            aValues.Add(settings.smtpAddress);
            aValues.Add(settings.smtpPort.ToString());
            aValues.Add(settings.smtpAuthAccount);
            aValues.Add(settings.smtpAuthPassword);
            aValues.Add(settings.smtpSSL ? Boolean.TrueString : Boolean.FalseString);
            SaveConfig(aFields, aValues);

            //Default
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.AlertDataCount }));
            aFields.Add(common.system.GetName(new { settings.ScreeningDataCount }));

            aFields.Add(common.system.GetName(new { settings.ScreeningTimeScaleCode }));
            aFields.Add(common.system.GetName(new { settings.DefaultTimeRange }));
            aFields.Add(common.system.GetName(new { settings.DefaultTimeScaleCode }));

            aValues.Clear();
            aValues.Add(settings.AlertDataCount.ToString());
            aValues.Add(settings.ScreeningDataCount.ToString());
            aValues.Add(settings.ScreeningTimeScaleCode);
            aValues.Add(settings.DefaultTimeRange.ToString());
            aValues.Add(settings.DefaultTimeScaleCode);
            SaveConfig(aFields, aValues);

            //Timming
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.TimerUnitInSecs }));
            aFields.Add(common.system.GetName(new { settings.TimerUnitToAutoCheck }));

            aValues.Clear();
            aValues.Add(settings.TimerUnitInSecs.ToString());
            aValues.Add(settings.TimerUnitToAutoCheck.ToString());
            SaveConfig(aFields, aValues);
        }

        //All from local config file
        public static void Load_Local_Settings()
        {
            Load_Local_Settings_STOCK();
            Load_Local_Settings_CHART();
            Load_Local_Settings_SYSTEM1();
            Load_Local_Settings_SYSTEM2();
        }
        public static void Save_Local_Settings()
        {
            Save_Local_Settings_STOCK();
            Save_Local_Settings_CHART();
            Save_Local_Settings_SYSTEM1();
            Save_Local_Settings_SYSTEM2();
        }

        public static void Load_Local_Settings_STOCK()
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysStockMaxBuyQtyPerc }));
            aFields.Add(common.system.GetName(new { Settings.sysStockReduceQtyPerc }));
            aFields.Add(common.system.GetName(new { Settings.sysStockAccumulateQtyPerc }));
            aFields.Add(common.system.GetName(new { Settings.sysStockTotalCapAmt }));
            aFields.Add(common.system.GetName(new { Settings.sysStockMaxBuyAmtPerc }));
            commonClass.Configuration.GetLocalConfig("STOCK", aFields);

            decimal d = 0; 
            if (common.system.String2Number_Common(aFields[0], out d)) Settings.sysStockMaxBuyQtyPerc = d;
            if (common.system.String2Number_Common(aFields[1], out d)) Settings.sysStockReduceQtyPerc = d;
            if (common.system.String2Number_Common(aFields[2], out d)) Settings.sysStockAccumulateQtyPerc = d;
            if (common.system.String2Number_Common(aFields[3], out d)) Settings.sysStockTotalCapAmt = d;
            if (common.system.String2Number_Common(aFields[4], out d)) Settings.sysStockMaxBuyAmtPerc = d;
        }
        public static void Save_Local_Settings_STOCK()
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysStockMaxBuyQtyPerc }));
            aFields.Add(common.system.GetName(new { Settings.sysStockReduceQtyPerc }));
            aFields.Add(common.system.GetName(new { Settings.sysStockAccumulateQtyPerc }));
            aFields.Add(common.system.GetName(new { Settings.sysStockTotalCapAmt }));
            aFields.Add(common.system.GetName(new { Settings.sysStockMaxBuyAmtPerc }));
            aValues.Clear();
            aValues.Add(common.system.Number2String_Common(Settings.sysStockMaxBuyQtyPerc));
            aValues.Add(common.system.Number2String_Common(Settings.sysStockReduceQtyPerc));
            aValues.Add(common.system.Number2String_Common(Settings.sysStockAccumulateQtyPerc));
            aValues.Add(common.system.Number2String_Common(Settings.sysStockTotalCapAmt));
            aValues.Add(common.system.Number2String_Common(Settings.sysStockMaxBuyAmtPerc));
            commonClass.Configuration.SaveLocalConfig("STOCK", aFields,aValues);
        }

        public static void Load_Local_Settings_CHART()
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
            commonClass.Configuration.GetLocalConfig("ChartColors", aFields);

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

            aFields.Add(common.system.GetName(new { Charts.Settings.sysZoom_Percent }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysZoom_MinCount }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MovePercent }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MoveMinCount}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MouseRate }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysNumberOfPoint_DEFA }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysNumberOfPoint_MIN }));
            
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewMinBarAtLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewMinBarAtRIGHT }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginRIGHT}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginTOP }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginBOT }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtRIGHT}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtTOP}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtBOT}));

            commonClass.Configuration.GetLocalConfig("ChartSettings", aFields);

            Settings.sysChartShowDescription = (aFields[0].Trim() == Boolean.TrueString);
            Settings.sysChartShowVolume = (aFields[1].Trim() == Boolean.TrueString);
            Settings.sysChartShowGrid = (aFields[2].Trim() == Boolean.TrueString);
            Settings.sysChartShowLegend = (aFields[3].Trim() == Boolean.TrueString);

            if (common.system.String2Number_Common(aFields[4], out d)) Charts.Settings.sysZoom_Percent = (int)d;
            if (common.system.String2Number_Common(aFields[5], out d)) Charts.Settings.sysZoom_MinCount = (int)d;

            if (common.system.String2Number_Common(aFields[6], out d)) Charts.Settings.sysPAN_MovePercent = (int)d;
            if (common.system.String2Number_Common(aFields[7], out d)) Charts.Settings.sysPAN_MoveMinCount = (int)d;
            if (common.system.String2Number_Common(aFields[8], out d)) Charts.Settings.sysPAN_MouseRate = (int)d;

            if (common.system.String2Number_Common(aFields[9], out d)) Charts.Settings.sysNumberOfPoint_DEFA = (int)d;
            if (common.system.String2Number_Common(aFields[10], out d)) Charts.Settings.sysNumberOfPoint_MIN = (int)d;

            if (common.system.String2Number_Common(aFields[11], out d)) Charts.Settings.sysViewMinBarAtLEFT = (int)d;
            if (common.system.String2Number_Common(aFields[12], out d)) Charts.Settings.sysViewMinBarAtRIGHT = (int)d;

            if (common.system.String2Number_Common(aFields[13], out d)) Charts.Settings.sysChartMarginLEFT = (int)d;
            if (common.system.String2Number_Common(aFields[14], out d)) Charts.Settings.sysChartMarginRIGHT = (int)d;
            if (common.system.String2Number_Common(aFields[15], out d)) Charts.Settings.sysChartMarginTOP = (int)d;
            if (common.system.String2Number_Common(aFields[16], out d)) Charts.Settings.sysChartMarginBOT = (int)d;

            if (common.system.String2Number_Common(aFields[17], out d)) Charts.Settings.sysViewSpaceAtLEFT = (int)d;
            if (common.system.String2Number_Common(aFields[18], out d)) Charts.Settings.sysViewSpaceAtRIGHT = (int)d;
            if (common.system.String2Number_Common(aFields[19], out d)) Charts.Settings.sysViewSpaceAtTOP = (double)d;
            if (common.system.String2Number_Common(aFields[20], out d)) Charts.Settings.sysViewSpaceAtBOT = (double)d; 
        }
        public static void Save_Local_Settings_CHART()
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
            commonClass.Configuration.SaveLocalConfig("ChartColors", aFields,aValues);

            //Chart page
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysChartShowDescription }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowVolume }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowGrid }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowLegend }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysZoom_Percent }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysZoom_MinCount}));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MovePercent }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MoveMinCount }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MouseRate }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysNumberOfPoint_DEFA }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysNumberOfPoint_MIN }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewMinBarAtLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewMinBarAtRIGHT }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginRIGHT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginTOP }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginBOT }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtRIGHT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtTOP }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtBOT }));

            aValues.Clear();
            aValues.Add(Settings.sysChartShowDescription.ToString());
            aValues.Add(Settings.sysChartShowVolume.ToString());
            aValues.Add(Settings.sysChartShowGrid.ToString());
            aValues.Add(Settings.sysChartShowLegend.ToString());

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysZoom_Percent));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysZoom_MinCount));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysPAN_MovePercent));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysPAN_MoveMinCount));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysPAN_MouseRate));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysNumberOfPoint_DEFA));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysNumberOfPoint_MIN));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysViewMinBarAtLEFT));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysViewMinBarAtRIGHT));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysChartMarginLEFT));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysChartMarginRIGHT));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysChartMarginTOP));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysChartMarginBOT));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysViewSpaceAtLEFT));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysViewSpaceAtRIGHT));
            aValues.Add(common.system.Number2String_Common((decimal)Charts.Settings.sysViewSpaceAtTOP));
            aValues.Add(common.system.Number2String_Common((decimal)Charts.Settings.sysViewSpaceAtBOT));

            commonClass.Configuration.SaveLocalConfig("ChartSettings", aFields, aValues);
        }

        public static void Load_Local_Settings_SYSTEM1()
        {
            int num;
            StringCollection aFields = new StringCollection();

            //Format
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysMaskGeneralValue }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskLocalAmt }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskForeignAmt }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskPercent }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskQty }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskPrice }));
            commonClass.Configuration.GetLocalConfig("Format", aFields);

            if (aFields[0].Trim() != "") Settings.sysMaskGeneralValue = aFields[2];
            if (aFields[1].Trim() != "") Settings.sysMaskLocalAmt = aFields[2];
            if (aFields[2].Trim() != "") Settings.sysMaskForeignAmt = aFields[2];
            if (aFields[3].Trim() != "") Settings.sysMaskPercent = aFields[3];
            if (aFields[4].Trim() != "") Settings.sysMaskQty = aFields[4];
            if (aFields[5].Trim() != "") Settings.sysMaskPrice = aFields[5];

            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysPrecisionLocal }));
            aFields.Add(common.system.GetName(new { Settings.sysPrecisionForeign }));
            aFields.Add(common.system.GetName(new { Settings.sysPrecisionQty }));
            aFields.Add(common.system.GetName(new { Settings.sysPrecisionPrice }));
            aFields.Add(common.system.GetName(new { Settings.sysPrecisionPercentage }));
            commonClass.Configuration.GetLocalConfig("Format", aFields);

            if (int.TryParse(aFields[0], out num)) Settings.sysPrecisionLocal = num;
            if (int.TryParse(aFields[1], out num)) Settings.sysPrecisionForeign = num;
            if (int.TryParse(aFields[2], out num)) Settings.sysPrecisionQty = num;
            if (int.TryParse(aFields[3], out num)) Settings.sysPrecisionPrice = num;
            if (int.TryParse(aFields[4], out num)) Settings.sysPrecisionPercentage = num;

            //Color
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Increase_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Increase_FG }));

            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Decrease_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Decrease_FG }));

            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_NotChange_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_NotChange_FG }));
            commonClass.Configuration.GetLocalConfig("Color", aFields);

            if (aFields[0].Trim() != "") Settings.sysPriceColor_Increase_BG = ColorTranslator.FromHtml(aFields[0]);
            if (aFields[1].Trim() != "") Settings.sysPriceColor_Increase_FG = ColorTranslator.FromHtml(aFields[1]);

            if (aFields[2].Trim() != "") Settings.sysPriceColor_Decrease_BG = ColorTranslator.FromHtml(aFields[2]);
            if (aFields[3].Trim() != "") Settings.sysPriceColor_Decrease_FG = ColorTranslator.FromHtml(aFields[3]);

            if (aFields[4].Trim() != "") Settings.sysPriceColor_NotChange_BG = ColorTranslator.FromHtml(aFields[4]);
            if (aFields[5].Trim() != "") Settings.sysPriceColor_NotChange_FG = ColorTranslator.FromHtml(aFields[5]);

            //System
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysLanguage }));
            aFields.Add(common.system.GetName(new { Settings.sysTimerUnitToRefresh }));

            commonClass.Configuration.GetLocalConfig("System", aFields);
            Settings.sysLanguage = AppTypes.Code2Language(aFields[0].Trim());
            if (int.TryParse(aFields[1].Trim(), out num)) Settings.sysTimerUnitToRefresh = (short)num;
        }
        public static void Save_Local_Settings_SYSTEM1()
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();

            //Format
            aFields.Clear();

            aFields.Add(common.system.GetName(new { Settings.sysMaskGeneralValue }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskLocalAmt }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskForeignAmt }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskPercent }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskQty }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskPrice }));

            aValues.Clear();
            aValues.Add(Settings.sysMaskGeneralValue);
            aValues.Add(Settings.sysMaskLocalAmt);
            aValues.Add(Settings.sysMaskForeignAmt);
            aValues.Add(Settings.sysMaskPercent);
            aValues.Add(Settings.sysMaskQty);
            aValues.Add(Settings.sysMaskPrice);
            commonClass.Configuration.SaveLocalConfig("Format", aFields, aValues);

            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysPrecisionLocal }));
            aFields.Add(common.system.GetName(new { Settings.sysPrecisionForeign }));
            aFields.Add(common.system.GetName(new { Settings.sysPrecisionQty }));
            aFields.Add(common.system.GetName(new { Settings.sysPrecisionPrice }));
            aFields.Add(common.system.GetName(new { Settings.sysPrecisionPercentage }));

            aValues.Clear();
            aValues.Add(Settings.sysPrecisionLocal.ToString());
            aValues.Add(Settings.sysPrecisionForeign.ToString());
            aValues.Add(Settings.sysPrecisionQty.ToString());
            aValues.Add(Settings.sysPrecisionPrice.ToString());
            aValues.Add(Settings.sysPrecisionPercentage.ToString());
            commonClass.Configuration.SaveLocalConfig("Format", aFields, aValues);

            //Color
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Increase_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Increase_FG }));

            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Decrease_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Decrease_FG }));

            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_NotChange_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_NotChange_FG }));

            aValues.Clear();
            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_Increase_BG));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_Increase_FG));

            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_Decrease_BG));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_Decrease_FG));

            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_NotChange_BG));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_NotChange_FG));
            commonClass.Configuration.SaveLocalConfig("Color", aFields, aValues);

            //System
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysLanguage }));
            aFields.Add(common.system.GetName(new { Settings.sysTimerUnitToRefresh }));

            aValues.Clear();
            aValues.Add(Settings.sysLanguage.ToString());
            aValues.Add(common.system.Number2String_Common(Settings.sysTimerUnitToRefresh));
            commonClass.Configuration.SaveLocalConfig("System", aFields, aValues);
        }

        public static void Load_Local_Settings_SYSTEM2()
        {
            StringCollection aFields = new StringCollection();
            //Company
            aFields.Clear();
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyName }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyAddr1 }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyAddr2 }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyAddr3 }));

            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyPhone }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyFax }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyEmail }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyURL }));
            commonClass.Configuration.GetLocalConfig("Investor", aFields);

            commonClass.SysLibs.sysCompanyName = aFields[0].ToString();
            commonClass.SysLibs.sysCompanyAddr1 = aFields[1].ToString();
            commonClass.SysLibs.sysCompanyAddr2 = aFields[2].ToString();
            commonClass.SysLibs.sysCompanyAddr3 = aFields[3].ToString();

            commonClass.SysLibs.sysCompanyPhone = aFields[4].ToString();
            commonClass.SysLibs.sysCompanyFax = aFields[5].ToString();
            commonClass.SysLibs.sysCompanyEmail = aFields[6].ToString();
            commonClass.SysLibs.sysCompanyURL = aFields[7].ToString();

            //Image and Icon
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathBackGround })); 
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathIcon }));
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathCompanyLogo1 }));
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathCompanyLogo2 }));
            commonClass.Configuration.GetLocalConfig("Others", aFields);

            Settings.sysImgFilePathBackGround = common.fileFuncs.MakeRelativePath(aFields[0].ToString());
            Settings.sysImgFilePathIcon = common.fileFuncs.MakeRelativePath(aFields[1].ToString());
            Settings.sysImgFilePathCompanyLogo1 = common.fileFuncs.MakeRelativePath(aFields[2].ToString());
            Settings.sysImgFilePathCompanyLogo2 = common.fileFuncs.MakeRelativePath(aFields[3].ToString());
        }
        public static void Save_Local_Settings_SYSTEM2()
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();

            //Investor
            aFields.Clear();
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyName }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyAddr1 }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyAddr2 }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyAddr3 }));

            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyPhone }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyFax }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyEmail }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyURL }));

            aValues.Clear();
            aValues.Add(commonClass.SysLibs.sysCompanyName);
            aValues.Add(commonClass.SysLibs.sysCompanyAddr1);
            aValues.Add(commonClass.SysLibs.sysCompanyAddr2);
            aValues.Add(commonClass.SysLibs.sysCompanyAddr3);

            aValues.Add(commonClass.SysLibs.sysCompanyPhone);
            aValues.Add(commonClass.SysLibs.sysCompanyFax);
            aValues.Add(commonClass.SysLibs.sysCompanyEmail);
            aValues.Add(commonClass.SysLibs.sysCompanyURL);
            commonClass.Configuration.SaveLocalConfig("Investor", aFields, aValues);

            //Image and icon
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathBackGround }));
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathIcon }));
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathCompanyLogo1 }));
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathCompanyLogo2 }));

            aValues.Clear();
            aValues.Add(common.fileFuncs.MakeRelativePath(Settings.sysImgFilePathBackGround));
            aValues.Add(common.fileFuncs.MakeRelativePath(Settings.sysImgFilePathIcon));
            aValues.Add(common.fileFuncs.MakeRelativePath(Settings.sysImgFilePathCompanyLogo1));
            aValues.Add(common.fileFuncs.MakeRelativePath(Settings.sysImgFilePathCompanyLogo2));
            commonClass.Configuration.SaveLocalConfig("Others", aFields, aValues);
        }

        public static void Load_User_Envir()
        {
            StringCollection aFields = new StringCollection();
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysLoginAccount }));
            common.configuration.GetConfiguration(Settings.sysUserConfigFile, "Environment","", aFields, false);
            commonClass.SysLibs.sysLoginAccount = aFields[0].ToString();
        }
        public static void Save_User_Envir()
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();

            aFields.Clear(); aValues.Clear();
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysLoginAccount }));
            aValues.Add(commonClass.SysLibs.sysLoginAccount);
            common.configuration.SaveConfiguration(Settings.sysUserConfigFile,"Environment","", aFields, aValues, false);
        }
    }
}
