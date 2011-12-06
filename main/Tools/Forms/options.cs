using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using commonClass;

namespace Tools.Forms
{
    public partial class options : baseClass.forms.baseDialogForm    
    {
        public options()
        {
            try
            {
                InitializeComponent();
                optionTab.SendToBack();
                this.myOnProcess += new onProcess(ProcessHandler);  
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("option");

            systemPg.Text = Languages.Libs.GetString("system");
            buy2SellIntervalLbl.Text = Languages.Libs.GetString("buy2SellInterval");
            dayLbl.Text = Languages.Libs.GetString("days");
            keepSellAdviceChk.Text = Languages.Libs.GetString("keepSellAdvice");
            priceWeightLbl.Text = Languages.Libs.GetString("priceWeight");
            volumeWeightLbl.Text = Languages.Libs.GetString("volumeWeight");
            maxBuyQtyPercLbl.Text = Languages.Libs.GetString("maxBuyQtyPercent");
            transFeePercLbl.Text = Languages.Libs.GetString("codeList");

            investmentPg.Text = Languages.Libs.GetString("investment");
            totalCapitalLbl.Text = Languages.Libs.GetString("totalCapital");
            maxBuyAmtPercLbl.Text = Languages.Libs.GetString("maxBuyAmtPercent");
            qtyReducePercLbl.Text = Languages.Libs.GetString("maxQtyReducePercent");
            qtyAccumulatePercLbl.Text = Languages.Libs.GetString("maxQtyAccumulatePercent");
            totalAmountLbl.Text = Languages.Libs.GetString("totalAmt");
        }
        public static options GetForm(string formName)
        {
            string cacheKey = typeof(options).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            options form = (options)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new options();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }

        protected override bool LoadConfigure()
        {
            buy2SellIntervalEd.Value = Settings.sysStockSell2BuyInterval;

            transFeePercEd.Value = Settings.sysStockTransFeePercent;
            priceWeightEd.Value = Settings.sysStockPriceWeight;
            volumeWeightEd.Value = Settings.sysStockVolumeWeight;
            maxBuyQtyPercEd.Value = Settings.sysStockMaxBuyQtyPerc;

            totalCapitalEd.Value = Settings.sysStockTotalCapAmt;
            maxBuyAmtPercEd.Value = Settings.sysStockMaxBuyAmtPerc;
            qtyAccumulatePercEd.Value = Settings.sysStockAccumulateQtyPerc;
            qtyReducePercEd.Value = Settings.sysStockReduceQtyPerc;
            return true;
        }
        protected override bool SaveConfigure()
        {
            Settings.sysStockSell2BuyInterval = (short)buy2SellIntervalEd.Value;

            Settings.sysStockTransFeePercent = transFeePercEd.Value;
            Settings.sysStockPriceWeight = priceWeightEd.Value;
            Settings.sysStockVolumeWeight = volumeWeightEd.Value;
            Settings.sysStockMaxBuyQtyPerc = maxBuyQtyPercEd.Value;

            Settings.sysStockTotalCapAmt = totalCapitalEd.Value;
            Settings.sysStockMaxBuyAmtPerc = maxBuyAmtPercEd.Value;
            Settings.sysStockAccumulateQtyPerc = qtyAccumulatePercEd.Value;
            Settings.sysStockReduceQtyPerc = qtyReducePercEd.Value;
            application.Configuration.Save_Local_Settings_STOCK();
            return true;
        }

        protected override bool BeforeAcceptProcess()
        {
            bool retVal = true;
            ClearNotifyError();
            if (totalCapitalEd.Value <= 0)
            {
                NotifyError(totalCapitalEd);
                retVal = false;
            }
            if (maxBuyAmtPercEd.Value <= 0)
            {
                NotifyError(maxBuyAmtPercEd);
                retVal = false;
            }

            if (qtyAccumulatePercEd.Value <= 0)
            {
                NotifyError(qtyAccumulatePercEd);
                retVal = false;
            }

            if (qtyReducePercEd.Value <= 0)
            {
                NotifyError(qtyReducePercEd);
                retVal = false;
            }

            if (buy2SellIntervalEd.Value < 0)
            {
                NotifyError(buy2SellIntervalEd);
                retVal = false;
            }

            if (priceWeightEd.Value <= 0)
            {
                NotifyError(priceWeightEd);
                retVal = false;
            }
            if (volumeWeightEd.Value <= 0)
            {
                NotifyError(volumeWeightLbl);
                retVal = false;
            }
            if (transFeePercEd.Value < 0)
            {
                NotifyError(transFeePercEd);
                retVal = false;
            }
            if (maxBuyQtyPercEd.Value <= 0)
            {
                NotifyError(maxBuyQtyPercEd);
                retVal = false;
            }
            return retVal;
        }
        private void ProcessHandler(object sender,common.baseDialogEvent e)
        {
            if (e.isCloseClick) return;
            this.Close();
            SaveConfigure();
        }
    }    
}