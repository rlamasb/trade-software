﻿//Copyright by NHQ, HCM city, 2011 
//Basic DMI strategy
//Buy when there is cut between DI+ and DI-
//The cut loss function work with some cut loss level

using application;

namespace Strategy
{
    #region ATR Helper
    public class BasicATR_Helper : baseHelper
    {
        public BasicATR_Helper()
            : base(typeof(BasicATR))
        {
        }
    }

    public class BasicATRSCR_Helper : baseHelper
    {
        public BasicATRSCR_Helper()
            : base(typeof(BasicATRSCR))
        {
        }
    }

    public class HybridEMAATR_Helper : baseHelper
    {
        public HybridEMAATR_Helper()
            : base(typeof(HybridEMAATR))
        {
        }
    }
    #   endregion

    #region DMI Rule, Screening and Strategy

    /// <summary>
    /// Rule using DMI indicator
    /// </summary>
    public class BasicATRRule : Rule
    {
        DataSeries atr;
        DataBars data;
        public BasicATRRule(DataBars db, double period, string name)
        {
            atr = Indicators.ATR.Series(db, period, name);
            data = db;
        }
        public override bool isValid()
        {
            return isValid_forBuy(atr.Count - 1);
        }

        public override bool isValid_forBuy(int idx)
        {
            if (idx - 1 < data.Close.FirstValidValue) return false;
            if (data.Close[idx] > atr[idx] + data.Close[idx - 1])
                return true;
            return false;
        }

        public override bool isValid_forSell(int idx)
        {
            if (idx - 1 < data.Close.FirstValidValue) return false;
            if (data.Close[idx] < -atr[idx] + data.Close[idx - 1])
                return true;
            return false;
        }

        public override bool DownTrend(int index)
        {
            return false;
        }

        public override bool UpTrend(int index)
        {
            return false;
        }
    }

    public class BasicATRSCR : GenericStrategy
    {
        protected override void StrategyExecute()
        {
            Rule rule = new BasicATRRule(data.Bars, parameters[0],"atr");
            if (rule.isValid())
            {
                int Bar = data.Close.Count - 1;
                wsData.BusinessInfo info = new wsData.BusinessInfo();
                info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }
        }
    }

    public class BasicATR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            BasicATRRule rule = new BasicATRRule(data.Bars, parameters[0], "atr");
            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[0], "max");

            for (int idx = 0; idx < data.Close.Count - 1; idx++)
            {
                if (rule.isValid_forBuy(idx))
                {
                    wsData.BusinessInfo info = new wsData.BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
                else
                    if (rule.isValid_forSell(idx))
                    {
                        wsData.BusinessInfo info = new wsData.BusinessInfo();
                        info.SetTrend(AppTypes.MarketTrend.Downward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                        info.Short_Target = min[idx];
                        info.Stop_Loss = max[idx];
                        SellAtClose(idx, info);
                    }
            }
        }
    }

    public class HybridEMAATR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            BasicATRRule rule = new BasicATRRule(data.Bars, parameters[0], "atr");
            TwoEMARule emaRule = new TwoEMARule(data.Close, parameters[1], parameters[2]);
            int cutlosslevel = (int)parameters[3];
            int trailingstoplevel = (int)parameters[4];
            int takeprofitlevel = (int)parameters[5];

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[0], "max");

            for (int idx = 0; idx < data.Close.Count - 1; idx++)
            {
                if (rule.isValid_forBuy(idx)&&emaRule.UpTrend(idx))
                {
                    wsData.BusinessInfo info = new wsData.BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
                else
                    if (rule.isValid_forSell(idx)||emaRule.isValid_forSell(idx))
                    {
                        wsData.BusinessInfo info = new wsData.BusinessInfo();
                        info.SetTrend(AppTypes.MarketTrend.Downward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                        info.Short_Target = min[idx];
                        info.Stop_Loss = max[idx];
                        SellAtClose(idx, info);
                    }
                if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                    SellCutLoss(idx);

                if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                    SellTakeProfit(idx);

                if (trailingstoplevel > 0)
                    TrailingStopWithBuyBack(rule, data.Close[idx], trailingstoplevel, idx);
            }
        }
    }  
    #   endregion
}