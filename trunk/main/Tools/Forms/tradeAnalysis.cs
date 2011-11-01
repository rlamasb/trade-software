using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;
using ZedGraph;

namespace Tools.Forms
{
    public partial class tradeAnalysis : baseClass.forms.baseGraphForm
    {
        #region private variables
        const int constPriceChartMarginBOTTOM = 45;
        const int constPriceChartMarginTOP = 5;
        const string constPaneNamePrice = "pricePanel";
        const string constPaneNameVolume = "volumePanel";
        const string constPaneNameNew = "newPanel";
        const string constCurveNamePrefixIndicator = "Indicator-";

        // Keep infomation of all indicators dynamically collected form plug-in .dll
        private application.Data myData = null;     //Working data loaded from SQL database
        private Charts.CurveList myCurveList = new Charts.CurveList();           // Keep all drawn curves in the chart
        private common.DictionaryList indicatorFormCache = new common.DictionaryList();  // To cache used indicator forms 
        private common.DictionaryList dataCache = new common.DictionaryList();           // To cache data used in indicator chart

        private baseClass.controls.graphPanel _pricePanel = null, _volumePanel = null, _newPanel = null;
        private baseClass.controls.graphPanel pricePanel
        {
            get
            {
                baseClass.controls.graphPanel pane = this.GetPane(constPaneNamePrice);
                if (pane == null)
                {
                    _pricePanel = CreatePane(constPaneNamePrice, 100);
                    _pricePanel.haveCloseButton = false;
                    _pricePanel.myGraphObj.SetFont(application.Settings.sysChartFontSize); 
                    _pricePanel.myGraphObj.ChartMarginTOP = constPriceChartMarginTOP;
                    _pricePanel.myGraphObj.ChartMarginBOTTOM = constPriceChartMarginBOTTOM;
                    _pricePanel.myGraphObj.myOnViewportChanged += new Charts.Controls.myGraphControl.OnViewportChanged(this.Chart_OnViewportChanged);
                    _pricePanel.myGraphObj.myOnPointValue += new Charts.Controls.myGraphControl.OnPointValue(PointValueEventPrice);
                }
                else _pricePanel = pane;
                return _pricePanel;
            }
        }
        private baseClass.controls.graphPanel volumePanel
        {
            get
            {
                baseClass.controls.graphPanel pane = this.GetPane(constPaneNameVolume);
                if (pane == null)
                {
                    _volumePanel = CreatePane(constPaneNameVolume, 0);
                    _volumePanel.myGraphObj.SetFont(application.Settings.sysChartFontSize); 
                    _volumePanel.Height = this.ClientRectangle.Height / 4;
                    _volumePanel.haveCloseButton = true;
                    _volumePanel.Visible = false; //Defaul is invisible
                    _volumePanel.mySizingOptions = common.controls.basePanel.SizingOptions.Top;
                    _volumePanel.myGraphObj.myOnViewportChanged += new Charts.Controls.myGraphControl.OnViewportChanged(this.Chart_OnViewportChanged);
                }
                else _volumePanel = pane;
                return _volumePanel;
            }
        }
        private baseClass.controls.graphPanel newPanel
        {
            get
            {
                baseClass.controls.graphPanel pane = this.GetPane(constPaneNameNew);
                if (pane == null)
                {
                    _newPanel = CreatePane(constPaneNameNew, 0, pricePanel.Name);
                    _newPanel.myGraphObj.SetFont(application.Settings.sysChartFontSize); 
                    _newPanel.Height = this.ClientRectangle.Height / 5;
                    _newPanel.haveCloseButton = true;
                    _newPanel.Visible = false;//Defaul is invisible
                    _newPanel.mySizingOptions = common.controls.basePanel.SizingOptions.Top; 
                    _newPanel.myGraphObj.myOnViewportChanged += new Charts.Controls.myGraphControl.OnViewportChanged(this.Chart_OnViewportChanged);
                    _newPanel.myGraphObj.myOnPointValue += new Charts.Controls.myGraphControl.OnPointValue(PointValueEventIndicator);
                    _newPanel.myOnClosing += new common.controls.basePanel.OnClosing(NewPane_OnClosing);

                }
                else _newPanel = pane;
                return _newPanel;
            }
        }


        /// <summary>
        /// Synchronize charts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="state"></param>
        private void Chart_OnViewportChanged(object sender, Charts.Controls.myGraphControl.ViewportState state)
        {
            if (pricePanel.Visible) pricePanel.myGraphObj.myViewportX = state.Range;
            if (volumePanel.Visible) volumePanel.myGraphObj.myViewportX = state.Range;
            if (newPanel.Visible) newPanel.myGraphObj.myViewportX = state.Range;
        }
        public bool NewPane_OnClosing(object sender)
        {
            Charts.DrawCurve[] list = myCurveList.CurveInPane(newPanel.Name);
            for (int idx = 0; idx < list.Length; idx++)
            {
                RemoveCurveIndicator(list[idx].CurveName, false);
            }
            this.ReArrangePanes();
            return true;
        }

        private string PointValueEventPrice(CurveItem curve, int pointIdx)
        {
            DateTime dt = DateTime.FromOADate(curve[pointIdx].X);
            string retVal = "";
            switch (this.ChartTimeScale.Type)
            { 
                case AppTypes.TimeScaleTypes.RealTime:
                case AppTypes.TimeScaleTypes.Minnute:
                case AppTypes.TimeScaleTypes.Hour: retVal = language.GetString("time") + " : " + dt.ToString(); break;
                case AppTypes.TimeScaleTypes.Day:  retVal = language.GetString("date") + " : " + dt.ToShortDateString(); break;
                case AppTypes.TimeScaleTypes.Week: retVal = language.GetString("week") + " : " + common.dateTimeLibs.WeekOfYear(dt).ToString() + "/" + dt.Year.ToString(); break;
                case AppTypes.TimeScaleTypes.Month: retVal= language.GetString("month")+ " : " + dt.Month.ToString() + "/" + dt.Year.ToString(); break;
                case AppTypes.TimeScaleTypes.Year: retVal = language.GetString("year") + " : " + dt.Year.ToString(); break;
            }
            retVal += common.Consts.constCRLF + language.GetString("openPrice") + " : " + myData.Open.Values[pointIdx].ToString(Settings.sysMaskPrice) +
                      common.Consts.constCRLF + language.GetString("highPrice") + " : " + myData.High.Values[pointIdx].ToString(Settings.sysMaskPrice) +
                      common.Consts.constCRLF + language.GetString("lowPrice") + " : " + myData.Low.Values[pointIdx].ToString(Settings.sysMaskPrice) +
                      common.Consts.constCRLF + language.GetString("closePrice") + " : " + myData.Close.Values[pointIdx].ToString(Settings.sysMaskPrice) +
                      common.Consts.constCRLF + language.GetString("volume") + " : " + myData.Volume.Values[pointIdx].ToString(Settings.sysMaskQty);
            return retVal;
        }
        private string PointValueEventIndicator(CurveItem curve, int pointIdx)
        {
            DateTime dt = DateTime.FromOADate(curve[pointIdx].X);
            string retVal = "";
            switch (this.ChartTimeScale.Type)
            {
                case AppTypes.TimeScaleTypes.RealTime:
                case AppTypes.TimeScaleTypes.Minnute:
                case AppTypes.TimeScaleTypes.Hour: retVal = language.GetString("time") + " : " + dt.ToString(); break;
                case AppTypes.TimeScaleTypes.Day: retVal = language.GetString("date") + " : " + dt.ToShortDateString(); break;
                case AppTypes.TimeScaleTypes.Week: retVal = language.GetString("week") + " : " + common.dateTimeLibs.WeekOfYear(dt).ToString() + "/" + dt.Year.ToString(); break;
                case AppTypes.TimeScaleTypes.Month: retVal = language.GetString("month") + " : " + dt.Month.ToString() + "/" + dt.Year.ToString(); break;
                case AppTypes.TimeScaleTypes.Year: retVal = language.GetString("year") + " : " + dt.Year.ToString(); break;
            }
            retVal +=  " : " + curve[pointIdx].Y.ToString(Settings.sysMaskQty);
            return retVal;
        }

        private class IndicatorCurveInfo
        {
            public IndicatorCurveInfo(string curveName, Indicators.Meta metaData)
            {
                CurveName = curveName;
                meta = metaData;
            }
            public string CurveName = "";
            public Indicators.Meta meta = null;
        }
        private string CurrentEditCurveName = "";

        #endregion 

        public tradeAnalysis()
        {
            try
            {
                InitializeComponent();
                this.myData = new application.Data();
                this.SetMasterPane(new Point(0, activeIndicatorLV.Location.Y + activeIndicatorLV.Height));
                activeIndicatorLV.Visible = true;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public static tradeAnalysis GetForm(data.baseDS.stockCodeRow stockCodeRow,
                                            AppTypes.TimeRanges timeRange, AppTypes.TimeScale timeScale)
        {
            string cacheKey = typeof(tradeAnalysis).ToString();
            tradeAnalysis form = (tradeAnalysis)common.Data.dataCache.Find(cacheKey);
            if (form == null || form.IsDisposed)
            {
                form = new Forms.tradeAnalysis();
                common.Data.dataCache.Add(cacheKey, form);
            }
            form.ChartTimeRange = timeRange;
            form.ChartTimeScale = timeScale;
            form.ChartPriceType = AppTypes.ChartTypes.Line;
            form.UseStock(stockCodeRow);
            form.Visible = true;
            return form;
        }

        protected data.baseDS.stockCodeRow myStockCodeRow = null;
        private AppTypes.ChartTypes _priceChartType = AppTypes.ChartTypes.None;
        public AppTypes.ChartTypes ChartPriceType
        {
            get { return this._priceChartType; }
            set
            {
                pricePanel.Visible = true;
                if (this._priceChartType == value) return;
                this._priceChartType = value;
                DrawCurvePRICE();
                UpdateChart();
            }
        }
        public AppTypes.TimeScale ChartTimeScale
        {
            get { return this.myData.DataTimeScale; }
            set
            {
                this.myData.DataTimeScale = value;
            }
        }

        private AppTypes.TimeRanges _chartTimeRange = AppTypes.TimeRanges.None;
        public AppTypes.TimeRanges ChartTimeRange
        {
            get { return _chartTimeRange; }
            set
            {
                _chartTimeRange = value;
                this.myData.DataTimeRange = value;
            }
        }

        public bool ChartVolumeVisibility
        {
            get { return this.volumePanel.Visible; }
            set
            {
                this.volumePanel.Visible = value;
                if (value)
                {
                    DrawCurveVOLUME();
                    UpdateChart();
                }
            }
        }
        public bool ChartHaveGrid = true;

        /// <summary>
        /// Set what stock to be used as default
        /// </summary>
        /// <param name="stockCodeRow"></param>
        public void UseStock(data.baseDS.stockCodeRow stockCodeRow)
        {
            this.myStockCodeRow = stockCodeRow;
            this.myData.DataStockCode = stockCodeRow.code;

            this.ShowMessage("");
            this.Text = stockCodeRow.tickerCode.Trim() + " - " + stockCodeRow.name;

            ReloadChart();
        }

        /// <summary>
        /// Re-draw all curves in chart
        /// </summary>
        public void ReDrawChart()
        {
            ResetChart();
            DrawAllCurves();
            UpdateChart();
        }

        public void RestoreChart()
        {
            Charts.Controls.IntRange range = pricePanel.myGraphObj.myViewportX;
            UpdateChart();
            pricePanel.myGraphObj.myViewportX = range;
        }

        /// <summary>
        /// Reload data, and re-draw chart
        /// </summary>
        public void ReloadChart()
        {
            myData.Reload();
            Indicators.Libs.ClearCache();

            //Remove all curves in chart
            myCurveList.RemoveAll();
            //And plot 2 curves : Price  and Volume 
            DrawCurvePRICE();
            DrawCurveVOLUME();
            UpdateChart();
        }

        /// <summary>
        /// Plot indicator charts. The function displays a form to collect indicator options and then plot the chart.
        /// </summary>
        /// <param name="indicatorTypeName">Indicator name to be drawn</param>
        /// 
        public void PlotIndicator(string indicatorName)
        {
            Indicators.forms.baseIndicatorForm form = GetIndicatorForm(indicatorName);
            if (form == null) return;
            form.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>

        protected void PlotStrategyTradepoints(Strategy.TradePoints tradePoints, baseClass.controls.graphPanel toPanel)
        {
            ClearStrategyTradepoints(toPanel);

            Charts.DrawCurve[] curveList = myCurveList.CurveInPane(toPanel.Name);
            if (curveList.Length == 0) return;
            CurveItem curveItem = curveList[0].Curve;
            Strategy.TradePointInfo tradePointInfo;
            for (int idx = 0; idx < tradePoints.Count; idx++)
            {
                TextObj obj = new TextObj();
                obj.FontSpec.Size = application.Settings.sysTradePointMarkerFontSize;
                obj.FontSpec.IsBold = true;
                obj.FontSpec.Border.IsVisible = true;
                obj.FontSpec.Fill.IsVisible = true;
                obj.FontSpec.Fill.Color = application.Settings.sysTradePointMarkerColorBG;

                tradePointInfo = (Strategy.TradePointInfo)tradePoints[idx];
                PointPair point = curveItem.Points[tradePointInfo.DataIdx];
                switch (tradePointInfo.TradeAction)
                {
                    case AppTypes.TradeActions.Buy:
                    case AppTypes.TradeActions.Accumulate:
                        obj.Text = application.Settings.sysTradePointMarkeBUY;
                        obj.FontSpec.FontColor = application.Settings.sysTradePointMarkerColorBUY;
                        break;
                    case AppTypes.TradeActions.Sell:
                    case AppTypes.TradeActions.ClearAll:
                        obj.Text = application.Settings.sysTradePointMarkerSELL;
                        obj.FontSpec.FontColor = application.Settings.sysTradePointMarkerColorSELL;
                        break;
                    default:
                        obj.Text = application.Settings.sysTradePointMarkerOTHER;
                        obj.FontSpec.FontColor = application.Settings.sysTradePointMarkerColorOTHER;
                        break;
                }
                obj.Location.X = point.X;
                obj.Location.Y = point.Y;
                obj.Location.CoordinateFrame = CoordType.AxisXYScale;
                toPanel.myGraphObj.myGraphPane.GraphObjList.Add(obj);
            }
            toPanel.myGraphObj.UpdateChart();

        }

        protected void ClearStrategyTradepoints(baseClass.controls.graphPanel toPanel)
        {
           toPanel.myGraphObj.myGraphPane.GraphObjList.Clear();
           toPanel.myGraphObj.UpdateChart();
        }

        public void ClearStrategyTradepoints()
        {
            ClearStrategyTradepoints(pricePanel);
        }
        public void PlotStrategyTradepoints(Strategy.Meta meta)
        {
            //Analysis cached data so we MUST clear cache to ensure the system run correctly
            Strategy.Data.ClearCache();
            Strategy.TradePoints tradePoints = Strategy.Libs.Analysis(myData, meta.Code);
            PlotStrategyTradepoints(tradePoints, pricePanel);
        }

        public void ZoomIn()
        {
            pricePanel.myGraphObj.ZoomIn();
        }
        public void ZoomOut()
        {
            pricePanel.myGraphObj.ZoomOut();
        }


        //==================================
        // Draw and remove curves
        //==================================

        //Bug : do not reset when change data source 
        private void ResetChart()
        {
            pricePanel.ResetGraph();
            volumePanel.ResetGraph();
            newPanel.ResetGraph();
        }

        private void DrawCurvePRICE()
        {
            ClearStrategyTradepoints(pricePanel);

            string curveName = pricePanel.Name;
            pricePanel.myGraphObj.myGraphPane.GraphObjList.Clear();
            myCurveList.Remove(curveName);
            switch (this.ChartPriceType)
            {
                case AppTypes.ChartTypes.Bar:
                    PlotCurveBar(curveName, pricePanel, this.myData.DateTime, myData.Close,
                                 Settings.sysChartBarUpColor, Settings.sysChartBarUpColor, 1);
                    break;
                case AppTypes.ChartTypes.Line:
                    PlotCurveLine(curveName,pricePanel, this.myData.DateTime, myData.Close,
                                  Settings.sysChartLineCandleColor, 1);
                    break;
                case AppTypes.ChartTypes.CandleStick:
                    PlotCandleStick(curveName, pricePanel, myData, Settings.sysChartBarUpColor, Settings.sysChartBarDnColor,
                                    Settings.sysChartBullCandleColor, Settings.sysChartBearCandleColor);
                    break;
            }
            pricePanel.myGraphObj.DefaultViewport();
        }

        private CurveItem PlotCurveBar(string curveName,Charts.Controls.baseGraphPanel graphPane, DataSeries xSeries, DataSeries ySeries,
                                       Color color, Color bdColor, int weight)
        {
            graphPane.myGraphObj.SetSeriesX(xSeries.Values, Charts.Controls.myAxisType.Date);
            CurveItem curveItem = graphPane.myGraphObj.AddCurveBar(curveName, ySeries.Values, color,bdColor,weight);
            myCurveList.Add(curveItem, curveName, graphPane.myGraphObj.myGraphPane, graphPane.Name);
            return curveItem;
        }
        private CurveItem PlotCurveLine(string curveName,Charts.Controls.baseGraphPanel graphPane, DataSeries xSeries, DataSeries ySeries,
                                       Color color, int weight)
        {
            graphPane.myGraphObj.SetSeriesX(xSeries.Values, Charts.Controls.myAxisType.Date);
            CurveItem curveItem = graphPane.myGraphObj.AddCurveLine(curveName, ySeries.Values, SymbolType.None, color, weight);
            myCurveList.Add(curveItem, curveName, graphPane.myGraphObj.myGraphPane, graphPane.Name);
            return curveItem;
        }
        private CurveItem PlotCandleStick(string curveName, Charts.Controls.baseGraphPanel graphPane, application.Data data,
                                          Color barUpColor,Color  barDnColor,Color bullCandleColor,Color bearCandleColor)
        {
            graphPane.myGraphObj.SetSeriesX(data.DateTime.Values, Charts.Controls.myAxisType.Date);
            CurveItem curveItem = graphPane.myGraphObj.AddCandleStick(curveName,data.High.Values,data.Low.Values,data.Open.Values,data.Close.Values,data.Volume.Values,
                                                                      barUpColor,barDnColor,bullCandleColor,bearCandleColor);
            myCurveList.Add(curveItem, curveName, graphPane.myGraphObj.myGraphPane, graphPane.Name);
            return curveItem;
        }


        private void DrawCurveVOLUME()
        {
            string curveName = volumePanel.Name;
            myCurveList.Remove(curveName);
            this.myData.DateTime.FirstValidValue = myData.Volume.FirstValidValue;
            PlotCurveBar(volumePanel.Name,volumePanel,this.myData.DateTime, myData.Volume,
                         Settings.sysChartVolumesColor, Settings.sysChartVolumesColor, 1);
            volumePanel.myGraphObj.DefaultViewport();
        }

        //Draw / Remove indicator curves
        private void RemoveCurveIndicator(string name, bool allStartWith)
        {
            myCurveList.Remove(name, allStartWith);
            activeIndicatorLV.Remove(name);
        }
        private void DrawCurveIndicator(Indicators.Meta meta)
        {
            //Indicators.Meta meta = Indicators.Libs.FindMetaByName(indicatorName);
            string curveName = constCurveNamePrefixIndicator + meta.ClassType.Name + "-" + meta.ParameterString;
            //Remove the old one if any
            if (this.CurrentEditCurveName.Trim() != "")
            {
                RemoveCurveIndicator(this.CurrentEditCurveName, true);
                this.CurrentEditCurveName = curveName;
            }

            baseClass.controls.graphPanel myGraphPanel = (meta.DrawInNewWindow ? this.newPanel : this.pricePanel);
            
            DataSeries indicatorSeries = Indicators.Libs.GetIndicatorData(this.myData, meta);
            this.myData.DateTime.FirstValidValue = indicatorSeries.FirstValidValue;
            switch (meta.Output[0].ChartType)
            {
                case AppTypes.ChartTypes.Bar:
                     PlotCurveBar(curveName,myGraphPanel, this.myData.DateTime, indicatorSeries,
                                  meta.Output[0].Color, Color.Black, meta.Output[0].Weight );
                     break;
                case AppTypes.ChartTypes.Line:
                     PlotCurveLine(curveName, myGraphPanel,this.myData.DateTime, indicatorSeries,
                                   meta.Output[0].Color, meta.Output[0].Weight);
                    break;
            }
            // Some indicator such as MACD having more than one output series.
            // In such case, indicator form MUST have [form.ExtraInfo] propery to provide information for the output series. 
            DataSeries[] extraSeries = null;
            if(meta.Output.Length>1) extraSeries = Indicators.Libs.GetIndicatorData(indicatorSeries, meta);
            if (extraSeries != null)
            {
                for (int idx = 0, metaIdx = 1; idx < extraSeries.Length && metaIdx < meta.Output.Length; idx++, metaIdx++)
                {
                    this.myData.DateTime.FirstValidValue = extraSeries[idx].FirstValidValue;
                    curveName = constCurveNamePrefixIndicator + meta.ClassType.Name + "-" + meta.ParameterString + "-" + idx.ToString();
                    switch (meta.Output[metaIdx].ChartType)
                    {
                        case AppTypes.ChartTypes.Bar:
                            PlotCurveBar(curveName, myGraphPanel, this.myData.DateTime, extraSeries[idx],
                                         meta.Output[metaIdx].Color, Color.Black, meta.Output[metaIdx].Weight);
                            break;
                        case AppTypes.ChartTypes.Line:
                            PlotCurveLine(curveName, myGraphPanel, this.myData.DateTime, extraSeries[idx],
                                                    meta.Output[metaIdx].Color, meta.Output[metaIdx].Weight);
                            break;

                    }
                }
            }

            if (meta.DrawInNewWindow)
                newPanel.myGraphObj.myViewportX = pricePanel.myGraphObj.myViewportX;

            string paraStr = meta.ParameterString;
            curveName = constCurveNamePrefixIndicator + meta.ClassType.Name + "-" + paraStr;
            string text = meta.ClassType.Name + (paraStr == "" ? "" : "(" + paraStr + ")");
            ListViewItem item = activeIndicatorLV.Add(curveName, text, meta.Output[0].Color);
            item.Tag = new IndicatorCurveInfo(curveName,meta);
        }

        private void DrawActiveIndicator()
        {
            //Indicators.forms.baseIndicatorForm form;
            //Indicators.IndicatorMeta meta;
            //for (int idx = 0; idx < activeIndicatorLV.Items.Count; idx++)
            //{
            //    meta = Indicators.Libs.FindMetaByName(activeIndicatorLV.Items[idx].Name);
            //    if (meta == null) continue;
            //    indicatorFormCache.Find(meta.FormType.Name);
            //    form = (Indicators.forms.baseIndicatorForm)this.indicatorFormCache.Find(meta.Type.Name);
            //    if (form == null || form.IsDisposed) continue;
            //    //RemoveCurves(form);
            //    //DrawIndicatorCurves(form);
            //}
        }
        private void DrawAllCurves()
        {
            DrawCurvePRICE();
            DrawCurveVOLUME();
            DrawActiveIndicator();
        }
        private void UpdateChart()
        {
            newPanel.Visible = myCurveList.CurveInPane(newPanel.Name).Length > 0;
            pricePanel.PlotGraph();
            volumePanel.PlotGraph();
            newPanel.PlotGraph();
            this.ReArrangePanes();
        }

        //Get indicator form from indicator type (SMA, MACD,Stoch...)
        private Indicators.forms.baseIndicatorForm GetIndicatorForm(string typeName)
        {
            Indicators.Meta meta = Indicators.Libs.FindMetaByName(typeName);
            if (meta == null) return null;
            return GetIndicatorForm(meta);
        }

        private Indicators.forms.baseIndicatorForm GetIndicatorForm(Indicators.Meta meta)
        {
            if (meta == null) return null;
            Indicators.forms.baseIndicatorForm form = null;

            form = (Indicators.forms.baseIndicatorForm)this.indicatorFormCache.Find(meta.ClassType.Name);
            if (form == null || form.IsDisposed)
            {
                form = Indicators.Libs.GetIndicatorForm(meta);
                form.Text = meta.Name;
                form.onPlotChart += new Indicators.forms.baseIndicatorForm.PlotChart(IndicatorFormHandler);
            }
            this.indicatorFormCache.Add(meta.ClassType.Name, form);
            return form;
        }
        private Indicators.forms.baseIndicatorForm FindIndicatorForm(string typeName)
        {
            Indicators.Meta meta = Indicators.Libs.FindMetaByName(typeName);
            if (meta == null) return null;
            Indicators.forms.baseIndicatorForm form = (Indicators.forms.baseIndicatorForm)this.indicatorFormCache.Find(meta.ClassType.Name);
            if (form == null || form.IsDisposed) return null;
            return form;
        }
        //IndicatorFormHandler : Draw / Remove indicator's curves
        private void IndicatorFormHandler(Indicators.forms.baseIndicatorForm indicatorForm, bool removeChart)
        {
            if (removeChart)
            {
                string curveName = constCurveNamePrefixIndicator + indicatorForm.FormMeta.ClassType.Name + "-" +
                                   indicatorForm.FormMeta.ParameterString;
                RemoveCurveIndicator(curveName, true);
            }
            else
            {
                DrawCurveIndicator(indicatorForm.FormMeta);
            }
            UpdateChart();
        }
        protected override void RefreshForm()
        {
            ReDrawChart();
        }

        #region event handler
        private void editIndicatorMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeIndicatorLV.FocusedItem == null) return;
                IndicatorCurveInfo info = (IndicatorCurveInfo)activeIndicatorLV.FocusedItem.Tag;
                Indicators.forms.baseIndicatorForm form = GetIndicatorForm(info.meta);
                if (form == null) return;
                this.CurrentEditCurveName = info.CurveName;
                form.ShowDialog();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                this.CurrentEditCurveName = "";
            }
        }
        private void removeIndicatorMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeIndicatorLV.FocusedItem == null) return;
                RemoveCurveIndicator(((IndicatorCurveInfo)activeIndicatorLV.FocusedItem.Tag).CurveName, true);
                UpdateChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion event handler
    }
}