using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace baseClass.forms
{
    public partial class baseSysOptions : common.forms.baseDialogForm  
    {
        public baseSysOptions()
        {
            try
            {
                InitializeComponent();
                this.myOnProcess += new onProcess(ProcessHandler);  
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        protected override bool LoadConfigure()
        {
            buy2SellIntervalEd.Value = application.Settings.sysStockSell2BuyInterval;

            transFeePercEd.Value = application.Settings.sysStockTransFeePercent;
            priceWeightEd.Value = application.Settings.sysStockPriceWeight;
            volumeWeightEd.Value = application.Settings.sysStockVolumeWeight;
            maxBuyQtyPercEd.Value = application.Settings.sysStockMaxBuyQtyPerc;

            totalCapAmtEd.Value = application.Settings.sysStockTotalCapAmt;
            maxBuyAmtPercEd.Value = application.Settings.sysStockMaxBuyAmtPerc;
            qtyAccumulatePercEd.Value = application.Settings.sysStockAccumulateQtyPerc;
            qtyReducePercEd.Value = application.Settings.sysStockReduceQtyPerc;
            return true;
        }
        protected override bool SaveConfigure()
        {
            application.Settings.sysStockSell2BuyInterval = (short)buy2SellIntervalEd.Value;

            application.Settings.sysStockTransFeePercent = transFeePercEd.Value;
            application.Settings.sysStockPriceWeight = priceWeightEd.Value;
            application.Settings.sysStockVolumeWeight = volumeWeightEd.Value;
            application.Settings.sysStockMaxBuyQtyPerc = maxBuyQtyPercEd.Value;

            application.Settings.sysStockTotalCapAmt = totalCapAmtEd.Value;
            application.Settings.sysStockMaxBuyAmtPerc = maxBuyAmtPercEd.Value;
            application.Settings.sysStockAccumulateQtyPerc = qtyAccumulatePercEd.Value;
            application.Settings.sysStockReduceQtyPerc = qtyReducePercEd.Value;
            application.configuration.Save_Sys_Settings_STOCK();
            return true;
        }

        protected override bool BeforeAcceptProcess()
        {
            bool retVal = true;
            ClearNotifyError();
            if (totalCapAmtEd.Value <= 0)
            {
                NotifyError(totalCapAmtEd);
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
            this.Hide();
            SaveConfigure();
        }
    }    
}