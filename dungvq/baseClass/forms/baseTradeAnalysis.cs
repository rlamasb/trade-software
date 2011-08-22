using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using application;

namespace baseClass.forms
{
    public partial class baseTradeAnalysis : baseAnalysis
    {
        private indicatorOption _myIndicatorOptionForm = null;
        protected indicatorOption myIndicatorOptionForm
        {
            get
            {
                if (_myIndicatorOptionForm == null || _myIndicatorOptionForm.IsDisposed)
                {
                    _myIndicatorOptionForm = new indicatorOption();
                    _myIndicatorOptionForm.myOnProcess += new common.forms.baseDialogForm.onProcess(DoIndicatorOptions);
                }
                return _myIndicatorOptionForm;
            }
        }

        protected data.baseDS.stockCodeExtRow myStockCodeRow = null;
        public baseTradeAnalysis()
        {
            try
            {
                InitializeComponent();

                chartTiming.LoadData();
                cbStrategy.LoadData();

                chartTiming.myTimeRange = myTypes.timeRanges.Y1;
                InitChart_Main();
                GenerateIndicatorMenuItems();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public void ShowForm(data.baseDS.stockCodeExtRow stockCodeRow)
        {
            if (chartTiming.GetDate()) ShowForm(stockCodeRow, chartTiming);
        }
        public void ShowForm(data.baseDS.stockCodeExtRow stockCodeRow, baseClass.controls.chartTiming timing)
        {
            this.ShowMessage("");
            if (stockCodeRow == null) return;
            chartTiming.Set(timing);
            this.Text = "(" + stockCodeRow.tickerCode.Trim() + "," + stockCodeRow.nameEn + ")";
            this.myStockCodeRow = stockCodeRow;
            ShowChart(stockCodeRow,timing);
            this.Show();
            this.BringToFront();
        }

        //Auto generate indicator menu items in system menu 
        private void ShowIndicator(object sender, EventArgs e)
        {
            try
            {
                myIndicatorOptionForm.SetIndicatorType((myTypes.indicatorType)((ToolStripMenuItem)sender).Tag);
                myIndicatorOptionForm.ShowForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void GenerateIndicatorMenuItems()
        {
            this.indicatorMenuItem.DropDownItems.Clear();
            foreach (myTypes.indicatorType item in Enum.GetValues(typeof(myTypes.indicatorType)))
            {
                if (item == myTypes.indicatorType.None) continue;
                ToolStripMenuItem menuItem = new System.Windows.Forms.ToolStripMenuItem();
                menuItem.Name = "menuItem" + item.ToString();
                menuItem.Tag = item;
                //menuItem.Size = new System.Drawing.Size(152, 22);
                menuItem.Text = myTypes.Type2Text(item);
                this.indicatorMenuItem.DropDownItems.Add(menuItem);
                menuItem.Click += new System.EventHandler(ShowIndicator);
            }
        }
        
        private bool Validate_StockChart()
        {
            bool retVal = true;
            ClearNotifyError();
            if (this.myStockCodeRow == null)
            {
                retVal = false;
            }
            if (!chartTiming.GetDate())
            {
                NotifyError(chartTiming);
                retVal = false;
            }
            return retVal;
        }

        protected bool GetNodeData(int idx,ref DateTime onDate,ref decimal price,ref decimal volume)
        {
            if (idx>=stockChart.Series[constSeriPRICE].Points.Count) return false;
            onDate = DateTime.FromOADate(stockChart.Series[constSeriPRICE].Points[idx].XValue);
            price =  (decimal)stockChart.Series[constSeriPRICE].Points[idx].YValues[0];
            volume = (decimal)stockChart.Series[constSeriVOLUME].Points[idx].YValues[0];
            return true;
        }

        protected string GetStockTip(int idx)
        {
            DateTime onDate = common.Consts.constNullDate;
            decimal price=0,volume=0;
            if (!GetNodeData(idx, ref onDate, ref price, ref volume)) return "";
            return onDate.ToString() + " - " + price.ToString();
        }

        protected virtual void ClearTradeAdvice()
        {
            stockChart.Annotations.Clear();
        }
        protected virtual analysis.analysisResult TradeAnalysis(analysis.workData data, string strategyCode)
        {
            return null;
        }
        protected virtual void ShowTradeAdvice(analysis.analysisResult actions)
        {
            if (actions == null) return;
            for (int idx = 0; idx < actions.Count; idx++)
            {
                //Mark trade points
                int possition = actions.GetItem(idx).pointIdx;
                stockChart.Series[constSeriPRICE].Points[possition].MarkerStyle = MarkerStyle.Diamond;
                stockChart.Series[constSeriPRICE].Points[possition].Color = Settings.sysColorTradePoint;

                //Annotation on trade point
                RectangleAnnotation annotation = new RectangleAnnotation();
                annotation.AnchorDataPoint = stockChart.Series[constSeriPRICE].Points[possition];
                annotation.Text = actions.GetItem(idx).tradeAction.ToString();
                annotation.BackColor = Settings.sysColorTradePointAnnotation;
                annotation.ClipToChartArea = stockChart.ChartAreas[constChartAreaPRICE].Name;

                // Prevent moving or selecting
                annotation.AllowMoving = false;
                //annotation.AllowAnchorMoving = false;
                annotation.AllowSelecting = false;

                // Add the annotation to the collection
                stockChart.Annotations.Add(annotation);
            }
        }

        private bool Validate_TradeAdvice()
        {
            bool retVal = true;
            ClearNotifyError();
            if (this.myStockCodeRow == null)
            {
                retVal = false;
            }
            if (cbStrategy.myValue == "")
            {
                NotifyError(cbStrategy);
                retVal = false;
            }
            if (!chartTiming.GetDate())
            {
                NotifyError(chartTiming);
                retVal = false;
            }
            return retVal;
        }
        private void ShowAdvice(data.baseDS.stockCodeExtRow stockCodeRow, data.baseDS.strategyRow strategyRow, 
                                myTypes.timeScales timeScale,DateTime frDate, DateTime toDate)
        {
            analysis.analysisResult tradeActions =
                TradeAnalysis(new analysis.workData(timeScale, frDate, toDate, stockCodeRow), strategyRow.code);
            if (tradeActions != null) ShowTradeAdvice(tradeActions);
        }

        private void ShowEstimation(data.baseDS.stockCodeExtRow stockCodeRow, data.baseDS.strategyRow strategyRow,
                                    myTypes.timeScales timeScale, DateTime frDate, DateTime toDate)
        {
            analysis.workData data = new analysis.workData(timeScale,frDate, toDate, stockCodeRow);
            analysis.analysisResult tradeActions = TradeAnalysis(data, strategyRow.code);
            if (tradeActions != null)
            {
                ShowTradeAdvice(tradeActions);
                myAdviceEstimateForm.Init(data,tradeActions);
                myAdviceEstimateForm.ShowForm();
            }
        }

        private void ReSize()
        {
            int constMinWidth = 550;
            int constMinHeight = 250;
            if (this.Width < constMinWidth) this.Width = constMinWidth;
            if (this.Height < constMinHeight) this.Height = constMinHeight;
            toolPnl.Location = new Point(0, this.ClientRectangle.Height - toolPnl.Height-SystemInformation.CaptionHeight);
            toolPnl.Width = this.ClientRectangle.Width + 20;

            stockChart.Location = new Point(0, 0);
            // Leave a small margin around the outside of the control
            stockChart.Size = new Size(this.ClientRectangle.Width, toolPnl.Location.Y-3);
        }

        #region chart + indicator
        protected const int constMaxSeriesPerIndicator = 3;
        protected const string constChartAreaPRICE = "PriceArea";
        protected const string constChartAreaVOLUME = "VolumeArea";

        protected const string constSeriPRICE = "PRICE";
        protected const string constSeriVOLUME = "VOLUME";

        protected void InitChart_Main()
        {
            stockChart.ChartAreas[0].Name = constChartAreaPRICE;
            stockChart.ChartAreas[1].Name = constChartAreaVOLUME;
            stockChart.Series[0].Name = constSeriPRICE;
            stockChart.Series[1].Name = constSeriVOLUME;
            
            stockChart.Series[constSeriPRICE].MarkerSize = 8;
            stockChart.Series[constSeriPRICE].MarkerBorderWidth = 1;


            stockChart.ChartAreas[constChartAreaPRICE].Position.X = 0;
            stockChart.ChartAreas[constChartAreaPRICE].Position.Y = 8;
            stockChart.ChartAreas[constChartAreaPRICE].Position.Width = 100;
            stockChart.ChartAreas[constChartAreaPRICE].Position.Height = 82;

            stockChart.ChartAreas[constChartAreaVOLUME].Position.X = 0;
            stockChart.ChartAreas[constChartAreaVOLUME].Position.Y = 90;
            stockChart.ChartAreas[constChartAreaVOLUME].Position.Width = 100;
            stockChart.ChartAreas[constChartAreaVOLUME].Position.Height = 10;

            stockChart.ChartAreas[constChartAreaPRICE].CursorX.LineWidth = 1;
            stockChart.ChartAreas[constChartAreaPRICE].CursorX.LineDashStyle = ChartDashStyle.Solid;
            stockChart.ChartAreas[constChartAreaPRICE].CursorX.LineColor = Color.Red;
            stockChart.ChartAreas[constChartAreaPRICE].CursorX.SelectionColor = Color.LightPink;

            stockChart.ChartAreas[constChartAreaVOLUME].CursorX.LineWidth = stockChart.ChartAreas[constChartAreaPRICE].CursorX.LineWidth;
            stockChart.ChartAreas[constChartAreaVOLUME].CursorX.LineDashStyle = stockChart.ChartAreas[constChartAreaPRICE].CursorX.LineDashStyle;
            stockChart.ChartAreas[constChartAreaVOLUME].CursorX.LineColor = stockChart.ChartAreas[constChartAreaPRICE].CursorX.LineColor;
            stockChart.ChartAreas[constChartAreaVOLUME].CursorX.SelectionColor = stockChart.ChartAreas[constChartAreaPRICE].CursorX.SelectionColor;

            stockChart.ChartAreas[constChartAreaPRICE].AlignWithChartArea = stockChart.ChartAreas[constChartAreaVOLUME].Name;


            SetLegend(stockChart.Series[constSeriPRICE].Name, "Giá");
        }
        protected void InitChart_Indicator(string seriesName, Color cl)
        {
            stockChart.Series[seriesName].Enabled = true;
            stockChart.Series[seriesName].ChartArea = stockChart.ChartAreas[constChartAreaPRICE].Name;
            stockChart.Series[seriesName].ChartType = SeriesChartType.Line;
            stockChart.Series[seriesName].BorderWidth = 2;
            stockChart.Series[seriesName].ShadowOffset = 0;
            stockChart.Series[seriesName].Color = cl;
        }
        private void RefreshhChart()
        {
            stockChart.DataBind();
            RefreshIndicator();
        }

        protected void ShowChart()
        {
            if (!Validate_StockChart()) return;
            this.ShowMessage("");
            ShowChart(this.myStockCodeRow,chartTiming);
        }

        protected void ShowChart(data.baseDS.stockCodeExtRow stockRow,baseClass.controls.chartTiming timing)
        {
            //stockChart.Titles[0].Text = stockChart.Titles[0].Text = stockRow.code + "-" + stockRow.name;
            myDataSet.priceData.Clear();
            dataLibs.LoadData(myDataSet.priceData,timing.myTimeScale,timing.frDate, timing.toDate, stockRow.code);
            RefreshhChart();
        }

        protected string ChartSeriName(myTypes.indicatorType type,int idx)
        {
            return type.ToString().Trim() + idx.ToString().Trim().PadLeft(3,'0');
        }

        protected void RefreshIndicator()
        {
            myTypes.indicatorType[] enableIndicatorTypes = new myTypes.indicatorType[0];
            string seriName1, seriName2;
            foreach (myTypes.indicatorType item in Enum.GetValues(typeof(myTypes.indicatorType)))
            {
                seriName1 = ChartSeriName(item, 1); seriName2 = ChartSeriName(item, 2);
                if ((stockChart.Series.FindByName(seriName1) != null && stockChart.Series[seriName1].Enabled) ||
                    (stockChart.Series.FindByName(seriName2) != null && stockChart.Series[seriName2].Enabled))
                {
                    Array.Resize(ref enableIndicatorTypes, enableIndicatorTypes.Length + 1);
                    enableIndicatorTypes[enableIndicatorTypes.Length-1] = item;
                }
            }
            RemoveIndicator(enableIndicatorTypes);
            ShowIndicator(enableIndicatorTypes);
        }

        protected void SetLegend(string seriesName, string legendText)
        {
            stockChart.Series[seriesName].IsVisibleInLegend = true;
            stockChart.Series[seriesName].LegendText = legendText;
            stockChart.Series[seriesName].Tag = legendText;
        }

        protected void DoIndicatorOptions(object sender,common.baseDialogEvent e )
        {
            myTypes.indicatorType[] indicatorTypes = myIndicatorOptionForm.GetIndicatorType();
            switch (myIndicatorOptionForm.GetFormActions(sender))
            {
                case indicatorOption.formActions.Draw :
                     ShowIndicator(indicatorTypes); break;
                case indicatorOption.formActions.Remove:
                     RemoveIndicator(indicatorTypes); break;
            }
        }
        
        protected void ShowIndicatorMA(myTypes.indicatorType maType, string seriName, byte period, Color color)
        {
            myChartDataPoint[] dataList = null;
            MakeChartDataMA(maType, period, ref dataList);
            DrawChart(dataList, color, seriName, maType.ToString() + "(" + period.ToString() + ")"); 
        }
        protected void ShowIndicatorMACD(string macdSeriName, string emaSeriName, byte fast, byte slow, byte signal, Color macdColor, Color emaColor)
        {
            myChartDataPoint[] dataList = null;
            MakeChartDataMACD(fast, slow, signal, ref dataList);
            string legendTxt;
            
            legendTxt = "MACD(" + fast.ToString() + "," + slow.ToString() + ")";
            DrawChart(dataList, 0, false, macdColor, macdSeriName, legendTxt);

            legendTxt = "EMA(" + signal.ToString() + ")";
            DrawChart(dataList, 1, false, emaColor, emaSeriName, legendTxt);
        }
        protected void ShowIndicatorDI(myTypes.indicatorType diType, string seriName, byte period, Color color)
        {
            myChartDataPoint[] dataList = null;
            MakeChartDataDI(diType, period, ref dataList);
            DrawChart(dataList, color, seriName, diType.ToString() + "(" + period.ToString() + ")");
        }
        protected void ShowIndicatorDM(myTypes.indicatorType diType, string seriName, byte period, Color color)
        {
            myChartDataPoint[] dataList = null;
            MakeChartDataDM(diType, period, ref dataList);
            DrawChart(dataList, color, seriName, diType.ToString() + "(" + period.ToString() + ")");
        }
        protected void ShowIndicatorStochF(string kSeriName, string dSeriName, byte fastK, byte slowK, Color kColor, Color dColor)
        {
            myChartDataPoint[] dataList = null;
            MakeChartDataStochF(fastK, slowK,ref dataList);
            string legendTxt;

            legendTxt = "FStochK(" + fastK.ToString() + ")";
            DrawChart(dataList, 0, false, kColor, kSeriName, legendTxt);

            legendTxt = "FStochK(" + slowK.ToString() + ")";
            DrawChart(dataList, 1, false, dColor, dSeriName, legendTxt);
        }
        protected void ShowIndicatorStochS(string kSeriName, string dSeriName, byte fastK, byte slowK, byte slowD, Color kColor, Color dColor)
        {
            myChartDataPoint[] dataList = null;
            MakeChartDataStochS(fastK, slowK,slowD, ref dataList);
            string legendTxt;

            legendTxt = "SStoch K(" + fastK.ToString() + ")";
            DrawChart(dataList, 0, false, kColor, kSeriName, legendTxt);

            legendTxt = "SStoch K(" + slowK.ToString() + ")";
            DrawChart(dataList, 1, false, dColor, dSeriName, legendTxt);
        }
        protected void ShowIndicatorBBANDS(string upSeriName, string miSeriName, string loSeriName,
                                           byte period, byte kUp, byte kDown, Color upColor, Color miColor, Color loColor)
        {
            myChartDataPoint[] dataList = null;
            MakeChartDataBBANDS(period, kUp, kDown, ref dataList);
            string legendTxt;

            legendTxt = "BBANDS (" + period.ToString() + "," + kUp.ToString() + "," + kDown.ToString() + ")";
            DrawChart(dataList, 0, false, upColor, upSeriName, legendTxt);
            DrawChart(dataList, 1, false, miColor, miSeriName, legendTxt);
            DrawChart(dataList, 2, false, loColor, loSeriName, legendTxt);
        }
        protected void ShowIndicatorStockRSI(string kSeriName, string dSeriName,byte period, byte fastK, byte fastD, Color kColor, Color dColor)
        {
            myChartDataPoint[] dataList = null;
            MakeChartDataStockRSI(period,fastK,fastD,ref dataList);
            string legendTxt;

            legendTxt = "StochRSI (" + fastK.ToString() +"," + fastD.ToString() + ")";
            DrawChart(dataList, 0, false, kColor, kSeriName, legendTxt);
            DrawChart(dataList, 1, false, dColor, dSeriName, legendTxt);
        }
        
        protected void MakeChartDataMA(myTypes.indicatorType maType, byte period,ref myChartDataPoint[] dataList)
        {
            double[] priceList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.Close);
            double[] outList = new double[myDataSet.priceData.Count];
            int begin = 0, len = 0;
            if (!stockLibs.MakeMovingAverage(maType, 0, priceList.Length - 1, priceList, period, out begin, out len, outList)) return;
            dataList = new myChartDataPoint[len];
            for (int idx = 0; idx < len; idx++)
            {
                dataList[idx]= new myChartDataPoint();
                dataList[idx].onDate = myDataSet.priceData[idx + begin].onDate;
                dataList[idx].value0 =  outList[idx];
            }
        }
        protected void MakeChartDataMACD(byte fast, byte slow, byte signal,ref myChartDataPoint[] outList)
        {
            double[] priceList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.Close);
            double[] tmpList = new double[myDataSet.priceData.Count];
            double[] tmpSigList = new double[myDataSet.priceData.Count];
            double[] tmpHistList = new double[myDataSet.priceData.Count];

            int begin = 0, len = 0;
            if (!stockLibs.MakeMACD(0, priceList.Length - 1, priceList, fast, slow, signal, out begin, out len, tmpList, tmpSigList, tmpHistList)) return;
            outList = new myChartDataPoint[len];
            for (int idx = 0; idx < len; idx++)
            {
                outList[idx] = new myChartDataPoint();
                outList[idx].onDate = myDataSet.priceData[idx + begin].onDate;
                outList[idx].value0 = tmpList[idx];
                outList[idx].value1 = tmpSigList[idx];
                outList[idx].value2 = tmpHistList[idx];
            }
        }
        protected void MakeChartDataDI(myTypes.indicatorType diType,byte period, ref myChartDataPoint[] outList)
        {
            double[] closeList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.Close);
            double[] hiList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.High);
            double[] loList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.Low);

            double[] tmpList = new double[myDataSet.priceData.Count];
            int begin = 0, len = 0;
            if (!stockLibs.MakeDI(diType, 0, closeList.Length - 1,hiList,loList,closeList, period, out begin, out len, tmpList)) return;
            outList = new myChartDataPoint[len];
            for (int idx = 0; idx < len; idx++)
            {
                outList[idx] = new myChartDataPoint();
                outList[idx].onDate = myDataSet.priceData[idx + begin].onDate;
                outList[idx].value0 = tmpList[idx];
            }
        }
        protected void MakeChartDataDM(myTypes.indicatorType dmType, byte period, ref myChartDataPoint[] outList)
        {
            double[] hiList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.High);
            double[] loList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.Low);

            double[] tmpList = new double[myDataSet.priceData.Count];
            int begin = 0, len = 0;
            if (!stockLibs.MakeDM(dmType, 0, hiList.Length - 1, hiList, loList, period, out begin, out len, tmpList)) return;
            outList = new myChartDataPoint[len];
            for (int idx = 0; idx < len; idx++)
            {
                outList[idx] = new myChartDataPoint();
                outList[idx].onDate = myDataSet.priceData[idx + begin].onDate;
                outList[idx].value0 = tmpList[idx];
            }
        }
        protected void MakeChartDataStochF(byte fastK, byte fastD, ref myChartDataPoint[] outList)
        {
            double[] closeList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.Close);
            double[] hiList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.High);
            double[] loList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.Low);

            double[] tmpListK = new double[myDataSet.priceData.Count];
            double[] tmpListD = new double[myDataSet.priceData.Count];
            int begin = 0, len = 0;
            if (!stockLibs.MakeStochasticFast(0, closeList.Length - 1, hiList, loList, closeList, fastK,fastD, 
                                              out begin, out len, tmpListK,tmpListD)) return;
            outList = new myChartDataPoint[len];
            for (int idx = 0; idx < len; idx++)
            {
                outList[idx] = new myChartDataPoint();
                outList[idx].onDate = myDataSet.priceData[idx + begin].onDate;
                outList[idx].value0 = tmpListK[idx];
                outList[idx].value1 = tmpListD[idx];
            }
        }
        protected void MakeChartDataStochS(byte fastK, byte slowK, byte slowD, ref myChartDataPoint[] outList)
        {
            double[] closeList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.Close);
            double[] hiList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.High);
            double[] loList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.Low);

            double[] tmpListK = new double[myDataSet.priceData.Count];
            double[] tmpListD = new double[myDataSet.priceData.Count];
            int begin = 0, len = 0;
            if (!stockLibs.MakeStochasticSlow(0, closeList.Length - 1, hiList, loList, closeList, fastK, slowK, slowD,
                                              out begin, out len, tmpListK, tmpListD)) return;
            outList = new myChartDataPoint[len];
            for (int idx = 0; idx < len; idx++)
            {
                outList[idx] = new myChartDataPoint();
                outList[idx].onDate = myDataSet.priceData[idx + begin].onDate;
                outList[idx].value0 = tmpListK[idx];
                outList[idx].value1 = tmpListD[idx];
            }
        }
        protected void MakeChartDataBBANDS(byte period,byte kUp, byte kDown,ref myChartDataPoint[] outList)
        {
            double[] closeList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.Close);

            double[] tmpListUp = new double[myDataSet.priceData.Count];
            double[] tmpListLo = new double[myDataSet.priceData.Count];
            double[] tmpListMi = new double[myDataSet.priceData.Count];
            int begin = 0, len = 0;
            if (!stockLibs.MakeBBANDS(0, closeList.Length - 1,closeList,period,kUp,kDown,out begin, out len,tmpListUp,tmpListMi,tmpListLo)) return;
            outList = new myChartDataPoint[len];
            for (int idx = 0; idx < len; idx++)
            {
                outList[idx] = new myChartDataPoint();
                outList[idx].onDate = myDataSet.priceData[idx + begin].onDate;
                outList[idx].value0 = tmpListUp[idx];
                outList[idx].value1 = tmpListMi[idx];
                outList[idx].value2 = tmpListLo[idx];
            }
        }
        protected void MakeChartDataStockRSI(byte period, byte fastK, byte fastD, ref myChartDataPoint[] outList)
        {
            double[] closeList = stockLibs.MakeDataList(myDataSet.priceData, 0, stockLibs.stockDataField.Close);

            double[] tmpListK = new double[myDataSet.priceData.Count];
            double[] tmpListD = new double[myDataSet.priceData.Count];
            int begin = 0, len = 0;
            if (!stockLibs.MakeStockRSI(0, closeList.Length - 1,closeList,period,fastK, fastD,out begin, out len, tmpListK, tmpListD)) return;
            outList = new myChartDataPoint[len];
            for (int idx = 0; idx < len; idx++)
            {
                outList[idx] = new myChartDataPoint();
                outList[idx].onDate = myDataSet.priceData[idx + begin].onDate;
                outList[idx].value0 = tmpListK[idx];
                outList[idx].value1 = tmpListD[idx];
            }
        }
        
        public class myChartDataPoint
        {
            public DateTime onDate = common.Consts.constNullDate;
            public double value0 = 0, value1 = 0, value2 = 0, value3 = 0;
        }
        protected void DrawChart(myChartDataPoint[] list, Color color, string seriName, string legendTxt)
        {
            DrawChart(list, 0, false, color, seriName, legendTxt);
        }
        protected void DrawChart(myChartDataPoint[] list, byte valueIdx, bool valueIsInt, Color color, string seriName, string legendTxt)
        {
            Series seri = stockChart.Series.FindByName(seriName);
            if (seri == null)
            {
                seri = new Series();
                seri.Name = seriName;
                seri.XValueType = ChartValueType.Date;
                seri.YValueType = (valueIsInt?ChartValueType.Int32:ChartValueType.Double);
                stockChart.Series.Add(seri);
            }
            seri.Points.Clear();
            switch (valueIdx)
            {
                case 0:
                        for (int idx = 0; idx < list.Length; idx++)
                        {
                            if (list[idx].value0 == 0) continue;
                            seri.Points.AddXY(list[idx].onDate,list[idx].value0);
                        }
                        break;
                case 1:
                        for (int idx = 0; idx < list.Length; idx++)
                        {
                            if (list[idx].value1 == 0) continue;
                            seri.Points.AddXY(list[idx].onDate, list[idx].value1);
                        }
                        break;
                case 2:
                        for (int idx = 0; idx < list.Length; idx++)
                        {
                            if (list[idx].value2 == 0) continue;
                            seri.Points.AddXY(list[idx].onDate, list[idx].value2);
                        }
                        break;
                case 3:
                        for (int idx = 0; idx < list.Length; idx++)
                        {
                            if (list[idx].value3 == 0) continue;
                            seri.Points.AddXY(list[idx].onDate, list[idx].value3);
                        }
                        break;
            }
            stockChart.Series[seriName].Enabled = true;
            stockChart.Series[seriName].ChartArea = stockChart.ChartAreas[constChartAreaPRICE].Name;
            stockChart.Series[seriName].ChartType = SeriesChartType.Line;
            stockChart.Series[seriName].BorderWidth = 2;
            stockChart.Series[seriName].ShadowOffset = 0;
            stockChart.Series[seriName].Color = color;
            //Set legend
            stockChart.Series[seriName].IsVisibleInLegend = true;
            stockChart.Series[seriName].LegendText = legendTxt;
            stockChart.Series[seriName].Tag = legendTxt;
        }

        protected void ShowIndicator(myTypes.indicatorType[] indicatorType)
        {
            RemoveIndicator(indicatorType);
            if (stockChart.Series[constSeriPRICE].Points.Count <= 0) return;
            string seriName0, seriName1,seriName2;

            for (int idx = 0; idx < indicatorType.Length; idx++)
            {
                seriName0 = ChartSeriName(indicatorType[idx], 0);
                seriName1 = ChartSeriName(indicatorType[idx], 1);
                seriName2 = ChartSeriName(indicatorType[idx], 2);
                switch (indicatorType[idx])
                {
                    case myTypes.indicatorType.SMA:
                        if (myIndicatorOptionForm.smaVal1 != 0)
                            ShowIndicatorMA(indicatorType[idx], seriName0, myIndicatorOptionForm.smaVal1, myIndicatorOptionForm.smaColor1);
                        if (myIndicatorOptionForm.smaVal2 != 0)
                            ShowIndicatorMA(indicatorType[idx], seriName1, myIndicatorOptionForm.smaVal2, myIndicatorOptionForm.smaColor2);
                        break;
                    case myTypes.indicatorType.EMA:
                        if (myIndicatorOptionForm.emaVal1 != 0)
                            ShowIndicatorMA(indicatorType[idx], seriName0, myIndicatorOptionForm.emaVal1, myIndicatorOptionForm.emaColor1);
                        if (myIndicatorOptionForm.emaVal2 != 0)
                            ShowIndicatorMA(indicatorType[idx], seriName1, myIndicatorOptionForm.emaVal2, myIndicatorOptionForm.emaColor2);
                        break;

                    case myTypes.indicatorType.WMA:
                        if (myIndicatorOptionForm.wmaVal1 != 0)
                            ShowIndicatorMA(indicatorType[idx], seriName0, myIndicatorOptionForm.wmaVal1, myIndicatorOptionForm.wmaColor1);
                        if (myIndicatorOptionForm.wmaVal2 != 0)
                            ShowIndicatorMA(indicatorType[idx], seriName1, myIndicatorOptionForm.wmaVal2, myIndicatorOptionForm.wmaColor2);
                        break;

                    case myTypes.indicatorType.RSI:
                        if (myIndicatorOptionForm.rsiVal1 != 0)
                            ShowIndicatorMA(indicatorType[idx], seriName0, myIndicatorOptionForm.rsiVal1, myIndicatorOptionForm.rsiColor1);
                        if (myIndicatorOptionForm.rsiVal2 != 0)
                            ShowIndicatorMA(indicatorType[idx], seriName1, myIndicatorOptionForm.rsiVal2, myIndicatorOptionForm.rsiColor2);
                        break;

                    case myTypes.indicatorType.MACD:

                        if (myIndicatorOptionForm.macdValFast == 0 || myIndicatorOptionForm.macdValSlow == 0 || myIndicatorOptionForm.macdValSignal == 0) break;
                        ShowIndicatorMACD(seriName0, seriName1,
                                        myIndicatorOptionForm.macdValFast, myIndicatorOptionForm.macdValSlow, myIndicatorOptionForm.macdValSignal,
                                        myIndicatorOptionForm.macdColor1, myIndicatorOptionForm.macdColor2);
                        break;

                    case myTypes.indicatorType.DI:
                        if (myIndicatorOptionForm.diVal != 0)
                            ShowIndicatorDI(indicatorType[idx], seriName0, myIndicatorOptionForm.diVal, myIndicatorOptionForm.diColor);
                        break;
                    case myTypes.indicatorType.DIPlus:
                        if (myIndicatorOptionForm.diPlusVal!= 0)
                            ShowIndicatorDI(indicatorType[idx], seriName1, myIndicatorOptionForm.diPlusVal, myIndicatorOptionForm.diPlusColor);
                        break;
                    case myTypes.indicatorType.DIMinus:
                        if (myIndicatorOptionForm.diMinusVal != 0)
                            ShowIndicatorDI(indicatorType[idx], seriName2, myIndicatorOptionForm.diMinusVal, myIndicatorOptionForm.diMinusColor);
                        break;

                    case myTypes.indicatorType.DMPlus:
                        if (myIndicatorOptionForm.dmPlusVal != 0)
                            ShowIndicatorDM(indicatorType[idx], seriName0, myIndicatorOptionForm.dmPlusVal, myIndicatorOptionForm.dmPlusColor);
                        break;
                    case myTypes.indicatorType.DMMinus:
                        if (myIndicatorOptionForm.dmMinusVal != 0)
                            ShowIndicatorDM(indicatorType[idx], seriName1, myIndicatorOptionForm.dmMinusVal, myIndicatorOptionForm.dmMinusColor);
                        break;

                    case myTypes.indicatorType.StochF:
                        if (myIndicatorOptionForm.stochfKVal != 0 && myIndicatorOptionForm.stochfDVal != 0)
                            ShowIndicatorStochF(seriName0,seriName1,myIndicatorOptionForm.stochfKVal, myIndicatorOptionForm.stochfDVal,
                                                myIndicatorOptionForm.stochfKColor, myIndicatorOptionForm.stochfDColor);
                        break;
                    case myTypes.indicatorType.StochS:
                        if (myIndicatorOptionForm.stochsKVal1 != 0 && myIndicatorOptionForm.stochsKVal2 != 0 && myIndicatorOptionForm.stochsDVal != 0)
                            ShowIndicatorStochS(seriName0, seriName1,myIndicatorOptionForm.stochsKVal1,myIndicatorOptionForm.stochsKVal2,myIndicatorOptionForm.stochsDVal,
                                                myIndicatorOptionForm.stochsKColor, myIndicatorOptionForm.stochsDColor);
                        break;
                    
                    case myTypes.indicatorType.StockRSI:
                        if (myIndicatorOptionForm.stockRsiKVal1 != 0 && myIndicatorOptionForm.stockRsiKVal2 != 0 && 
                            myIndicatorOptionForm.stockRsiDVal != 0 && myIndicatorOptionForm.stockRsiPeriod != 0)
                            ShowIndicatorStockRSI(seriName0, seriName1, myIndicatorOptionForm.stockRsiPeriod, 
                                                  myIndicatorOptionForm.stockRsiKVal1,myIndicatorOptionForm.stockRsiKVal2,
                                                  myIndicatorOptionForm.stockRsiKColor, myIndicatorOptionForm.stockRsiDColor);
                        break;
                    
                    case myTypes.indicatorType.BBANDS:
                        if (myIndicatorOptionForm.bbandsPeriod != 0 && myIndicatorOptionForm.bbandsUpVal != 0 && myIndicatorOptionForm.bbandsDownVal != 0)
                            ShowIndicatorBBANDS(seriName0, seriName1, seriName2, myIndicatorOptionForm.bbandsPeriod,
                                                myIndicatorOptionForm.bbandsUpVal, myIndicatorOptionForm.bbandsDownVal,
                                                myIndicatorOptionForm.bbandsUpperColor,myIndicatorOptionForm.bbandsMiddleColor,myIndicatorOptionForm.bbandsLowerColor);
                        break;
                }
            }
        }
        
        protected void RemoveIndicator(myTypes.indicatorType[] indicatorType)
        {
            for (int idx1 = 0; idx1 < indicatorType.Length; idx1++)
            {
                for (int idx2 = 0; idx2 < constMaxSeriesPerIndicator; idx2++)
                {
                    stockChart.Series.Remove(stockChart.Series.FindByName(ChartSeriName(indicatorType[idx1], idx2)));
                }
            }
        }

        #endregion chart + indicator

        #region event handler

        private void tradeAnalysis_Resize(object sender, EventArgs e)
        {
            try
            {
                ReSize();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
 
        }

        private void stockCodeGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ShowChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void timeRanges_myDateAccept(object sender)
        {
            try
            {
                if (!this.isLoaded) return;
                ShowChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void stockChart_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            // Check selected chart element and set tooltip text
            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                    e.Text = GetStockTip(e.HitTestResult.PointIndex);
                    break;
            }
        }

        private void cbStrategy_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (!Validate_TradeAdvice()) return;
                ClearTradeAdvice();
                ShowChart();
                RefreshhChart();
                ShowAdvice(myStockCodeRow, cbStrategy.GetDataInfo(), chartTiming.myTimeScale, chartTiming.frDate, chartTiming.toDate);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void resetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ClearNotifyError();
                ClearTradeAdvice();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tradeEstimateMenuItem_Click(object sender, EventArgs e)
        {
            tradeEstimateBtn_Click(sender, e);
        }

        private void tradeEstimateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate_TradeAdvice()) return;
                ClearTradeAdvice();
                ShowChart();
                ShowEstimation(this.myStockCodeRow, cbStrategy.GetDataInfo(), chartTiming.myTimeScale,chartTiming.frDate, chartTiming.toDate);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion
    }
}