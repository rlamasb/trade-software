using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;

namespace wsStockServices
{
    public class wsData
    {
        [DataContract]
        public class EstOptions
        {
            [DataMember]
            public decimal TotalCapAmt = application.Settings.sysStockTotalCapAmt;
            [DataMember]
            public decimal MaxBuyAmtPerc = application.Settings.sysStockMaxBuyAmtPerc;
            [DataMember]
            public decimal QtyReducePerc = application.Settings.sysStockReduceQtyPerc;
            [DataMember]
            public decimal QtyAccumulatePerc = application.Settings.sysStockAccumulateQtyPerc;
            [DataMember]
            public decimal TransFeecPerc = application.Settings.sysStockTransFeePercent;
            [DataMember]
            public decimal PriceWeight = application.Settings.sysStockPriceWeight;
            [DataMember]
            public decimal MaxBuyQtyPerc = application.Settings.sysStockMaxBuyQtyPerc;
            [DataMember]
            public short Buy2SellInterval = application.Settings.sysStockSell2BuyInterval;

            public EstOptions()
            {
                Init();
            }

            //See http://social.msdn.microsoft.com/forums/en-US/wcf/thread/447149d5-b44c-47cd-a690-20928244b52b/
            //[OnDeserializing]
            //public void OnDeserializing(StreamingContext context)
            //{
               
            //}

            private void Init()
            {
                this.TotalCapAmt = application.Settings.sysStockTotalCapAmt;
                this.MaxBuyAmtPerc = application.Settings.sysStockMaxBuyAmtPerc;
                this.QtyReducePerc = application.Settings.sysStockReduceQtyPerc;
                this.QtyAccumulatePerc = application.Settings.sysStockAccumulateQtyPerc;
                this.TransFeecPerc = application.Settings.sysStockTransFeePercent;
                this.PriceWeight = application.Settings.sysStockPriceWeight;
                this.MaxBuyQtyPerc = application.Settings.sysStockMaxBuyQtyPerc;
                this.Buy2SellInterval = application.Settings.sysStockSell2BuyInterval;
            }

            [OnDeserialized]
            public void OnDeserialized(StreamingContext context)
            {
                Init();
            }
        }
    }
}
