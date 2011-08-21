using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; 

namespace baseClass.forms
{
    public partial class _baseTradeAnalysis : common.forms.baseForm
    {
        private const string constSeriPRICE  = "PRICE";
        private const string constSeriVOLUME = "VOLUME";

        private const string constSeriSMA1 = "SMA1";
        private const string constSeriSMA2 = "SMA2";
        private const string constSeriMACD1 = "MACD1";
        private const string constSeriMACD2 = "MACD2";
            
        private indicatorOption _myIndicatorOptionForm = null;
        private indicatorOption myIndicatorOptionForm
        {
            get
            {
                if (_myIndicatorOptionForm == null || _myIndicatorOptionForm.IsDisposed)
                {
                    _myIndicatorOptionForm = new indicatorOption();
                    _myIndicatorOptionForm.myOnAccept += new common.forms.baseDialogForm.onProcess(DoIndicatorOptions);
                }
                return _myIndicatorOptionForm;
            }
        }

        private baseAdviceEstimate _myAdviceEstimateForm = null;
        private baseAdviceEstimate myAdviceEstimateForm
        {
            get
            {
                if (_myAdviceEstimateForm == null || _myAdviceEstimateForm.IsDisposed)
                {
                    _myAdviceEstimateForm = new baseAdviceEstimate();
                }
                return _myAdviceEstimateForm;
            }
        }

        protected data.baseDS.stockCodeRow myCurrentStock
        {
            get
            {
                if (stockCodeSource.Current == null) return null;
                return (data.baseDS.stockCodeRow)((DataRowView)stockCodeSource.Current).Row;
            }
        }

        public _baseTradeAnalysis()
        {
            try
            {
                InitializeComponent();

                stockCodeGrid.DisableReadOnlyColumn = false;

                chartTiming.LoadData();
                cbStrategy.LoadData();

                stockListFilterCb.SelectedIndex = 1;
                LoadData_StockCode();

                chartTiming.myTiming = application.myTypes.chartTiming.Y1;
                InitChart_Main();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
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
            return onDate.ToShortDateString() + " - " + price.ToString();
        }

        protected virtual application.stockLibs.analysisInfo[] TradeAnalysis(string stockCode, string strategyCode,DateTime frDate,DateTime toDate)
        {
            data.baseDS.indicatorDataDataTable dataTbl = new data.baseDS.indicatorDataDataTable();
            dataTbl.Clear();
            application.dataLibs.LoadData(dataTbl, frDate,toDate, "SMA", stockCode);

            //listBox.Items.Clear();
            application.stockLibs.cutInfo[] cutPoints = application.stockLibs.CutPoint(dataTbl);
            application.stockLibs.analysisInfo[] adviceInfo = new application.stockLibs.analysisInfo[cutPoints.Length];
            for (int idx = 0; idx < cutPoints.Length; idx++)
            {
                //listBox.Items.Add(dataTbl[cutPoints[idx].position].onDate);
                adviceInfo[idx] = new application.stockLibs.analysisInfo();
                adviceInfo[idx].position = cutPoints[idx].position;
                adviceInfo[idx].tradeAction = (cutPoints[idx].state == application.stockLibs.cutState.Up ?
                                                                        application.stockLibs.tradeActions.Buy :
                                                                        application.stockLibs.tradeActions.Sell);
            }
            //countLbl.Text = cutPoints.Length.ToString();
            return adviceInfo;
        }
        protected virtual void ClearTradeAdvice()
        {
            stockChart.Annotations.Clear();
        }
        protected virtual void ShowTradeAdvice(application.stockLibs.analysisInfo[] actions)
        {
            if (actions == null) return;
            for (int idx = 0; idx < actions.Length; idx++)
            {
                if (stockChart.Series[constSeriPRICE].Points.Count <= actions[idx].position) continue; 

                
                //Mark trade points
                stockChart.Series[constSeriPRICE].Points[actions[idx].position].MarkerStyle = MarkerStyle.Diamond;
                stockChart.Series[constSeriPRICE].MarkerSize = 8;
                stockChart.Series[constSeriPRICE].MarkerBorderWidth = 1;
                stockChart.Series[constSeriPRICE].Points[actions[idx].position].Color = application.Settings.sysColorTradePoint;
                //Annotation on trade point
                RectangleAnnotation annotation = new RectangleAnnotation();
                annotation.AnchorDataPoint = stockChart.Series[constSeriPRICE].Points[actions[idx].position];
                annotation.Text = actions[idx].tradeAction.ToString();
                annotation.BackColor = application.Settings.sysColorTradePointAnnotation;
                annotation.ClipToChartArea = stockChart.ChartAreas[0].Name;

                // Prevent moving or selecting
                annotation.AllowMoving = false;
                //annotation.AllowAnchorMoving = false;
                annotation.AllowSelecting = false;

                // Add the annotation to the collection
                stockChart.Annotations.Add(annotation);
            }
        }
        protected virtual void ShowTradeAdviceEstimation(application.stockLibs.analysisInfo[] actions){}

        private void ShowAdvice(string stockCode, string strategyCode, DateTime frDate, DateTime toDate)
        {
            application.stockLibs.analysisInfo[] tradeActions = TradeAnalysis(stockCode, strategyCode,frDate,toDate);
            if (tradeActions != null) ShowTradeAdvice(tradeActions);
        }
        private void ShowEstimation(string stockCode, string strategyCode, DateTime frDate, DateTime toDate)
        {
            application.stockLibs.analysisInfo[] tradeActions = TradeAnalysis(stockCode, strategyCode,frDate,toDate);
            if (tradeActions != null)
            {
                ShowTradeAdviceEstimation(tradeActions);
                myAdviceEstimateForm.myTradeAdvices = tradeActions;

                DateTime onDate = common.Consts.constNullDate;
                decimal price = 0, volume = 0;
                for (int idx = 0; idx < tradeActions.Length; idx++)
                {
                    GetNodeData(tradeActions[idx].position, ref onDate, ref price, ref volume);
                    tradeActions[idx].onDate = onDate;
                    tradeActions[idx].price = price;
                }
                myAdviceEstimateForm.ReLoad();
                myAdviceEstimateForm.ShowForm();
            }
        }

        private void LoadData_StockCode()
        {
            myDataSet.stockCode.Clear();
            switch (stockListFilterCb.SelectedIndex)
            {
                case 0: application.dataLibs.LoadData(myDataSet.stockCode);
                    break;
                case 1: application.dataLibs.LoadStockCode_ByStockCode(myDataSet.stockCode, application.sysLibs.sysLoginInterestedStockCode);
                    break;
                case 2: application.dataLibs.LoadStockCode_ByBizSector(myDataSet.stockCode, application.sysLibs.sysLoginInterestedBizSectors);
                    break;

            }
            this.stockCountlbl.Text = "[" + stockCodeSource.Count.ToString() + "]";
        }
        protected void InitChart_Main()
        {
            // Cursor object for scrolling and viewing
            stockChart.ChartAreas[0].Position.X = 0;
            stockChart.ChartAreas[0].Position.Y = 10;
            stockChart.ChartAreas[0].Position.Width = 100;
            stockChart.ChartAreas[0].Position.Height = 70;

            stockChart.ChartAreas[1].Position.X = 0;
            stockChart.ChartAreas[1].Position.Y = 80;
            stockChart.ChartAreas[1].Position.Width = 100;
            stockChart.ChartAreas[1].Position.Height = 20;

            stockChart.ChartAreas[0].CursorX.LineWidth = 1;
            stockChart.ChartAreas[0].CursorX.LineDashStyle = ChartDashStyle.Solid;
            stockChart.ChartAreas[0].CursorX.LineColor = Color.Red;
            stockChart.ChartAreas[0].CursorX.SelectionColor = Color.LightPink;

            stockChart.ChartAreas[1].CursorX.LineWidth = stockChart.ChartAreas[0].CursorX.LineWidth;
            stockChart.ChartAreas[1].CursorX.LineDashStyle = stockChart.ChartAreas[0].CursorX.LineDashStyle;
            stockChart.ChartAreas[1].CursorX.LineColor = stockChart.ChartAreas[0].CursorX.LineColor;
            stockChart.ChartAreas[1].CursorX.SelectionColor = stockChart.ChartAreas[0].CursorX.SelectionColor;

            stockChart.ChartAreas[0].AlignWithChartArea = stockChart.ChartAreas[1].Name;

            stockChart.Series[0].Name = constSeriPRICE;
            stockChart.Series[1].Name = constSeriVOLUME;

            SetLegend(stockChart.Series[constSeriPRICE].Name, "Giá");
        }
        protected void InitChart_Indicator(string seriesName, Color cl)
        {
            stockChart.Series[seriesName].Enabled = true;
            stockChart.Series[seriesName].ChartArea = stockChart.ChartAreas[0].Name;
            stockChart.Series[seriesName].ChartType = SeriesChartType.Line;
            stockChart.Series[seriesName].BorderWidth = 1;
            stockChart.Series[seriesName].ShadowOffset = 0;
            stockChart.Series[seriesName].Color = cl;
        }
        
        private void ReSize()
        {
            if (this.Width < 780) this.Width = 780;
            if (this.Height < 450) this.Height = 450;
            toolPnl.Location = new Point(0, this.ClientRectangle.Height - toolPnl.Height);
            stockCodeGrid.Height = this.ClientRectangle.Height - stockCodeGrid.Location.Y - toolPnl.Height;
            toolPnl.Width = this.ClientRectangle.Width + 20;

            stockChart.Location = new Point(stockCodeGrid.Width, 0);
            // Leave a small margin around the outside of the control
            stockChart.Size = new Size(this.ClientRectangle.Width - stockCodeGrid.Width, this.ClientRectangle.Height - toolPnl.Height);
        }

        private void ShowChart()
        {
            ClearNotifyError();
            this.ShowMessage("");
            data.baseDS.stockCodeRow stockCodeRow = this.myCurrentStock;
            if (stockCodeRow == null)
            {
                NotifyError(stockCodeGrid);
                this.ShowMessage("Xin vui lòng chọn một cổ phiếu");
                return;
            }
            myDataSet.priceData.Clear();
            application.dataLibs.LoadData(myDataSet.priceData, chartTiming.frDate, chartTiming.toDate, stockCodeRow.code);
            stockChart.DataBind();

            RefreshIndicator();
        }

        protected void RefreshIndicator()
        {
            if ((stockChart.Series.FindByName(constSeriSMA1) != null && stockChart.Series[constSeriSMA1].Enabled) ||
                (stockChart.Series.FindByName(constSeriSMA2) != null && stockChart.Series[constSeriSMA2].Enabled))
            {
                RemoveIndicator(application.myTypes.indicatorType.SMA);
                ShowIndicator(application.myTypes.indicatorType.SMA);
            }

            if ((stockChart.Series.FindByName(constSeriMACD1) != null && stockChart.Series[constSeriMACD1].Enabled))
            {
                RemoveIndicator(application.myTypes.indicatorType.MACD);
                ShowIndicator(application.myTypes.indicatorType.MACD);
            }
        }

        protected void SetLegend(string seriesName, string legendText)
        {
            stockChart.Series[seriesName].IsVisibleInLegend = true;
            stockChart.Series[seriesName].LegendText = legendText;
            stockChart.Series[seriesName].Tag = legendText;
        }

        protected void ShowIndicatorOption(application.myTypes.indicatorType indicatorType)
        {
            myIndicatorOptionForm.myIndicatorType = indicatorType;
            myIndicatorOptionForm.ShowForm();
        }
        protected void DoIndicatorOptions(object sender)
        {
            switch (myIndicatorOptionForm.GetFormActions(sender))
            {
                case  indicatorOption.formActions.Draw :
                      ShowIndicator(myIndicatorOptionForm.myIndicatorType); break;
                case indicatorOption.formActions.Remove:
                    RemoveIndicator(myIndicatorOptionForm.myIndicatorType); break;
            }
        }
        protected void ShowIndicator(application.myTypes.indicatorType indicatorType)
        {
            RemoveIndicator(indicatorType);
            if (stockChart.Series[constSeriPRICE].Points.Count <= 0) return;
            switch (indicatorType)
            {
                case application.myTypes.indicatorType.SMA:
                    if (myIndicatorOptionForm.smaVal1 != 0)
                    {
                        stockChart.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, myIndicatorOptionForm.smaVal1.ToString(), stockChart.Series[constSeriPRICE].Name, constSeriSMA1);
                        InitChart_Indicator(constSeriSMA1, myIndicatorOptionForm.smaColor1);
                        SetLegend(constSeriSMA1, "SMA(" + myIndicatorOptionForm.smaVal1.ToString() + ")");
                    }
                    if (myIndicatorOptionForm.smaVal2 != 0)
                    {
                        stockChart.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, myIndicatorOptionForm.smaVal2.ToString(), stockChart.Series[constSeriPRICE].Name, constSeriSMA2);
                        InitChart_Indicator(constSeriSMA2, myIndicatorOptionForm.smaColor2);
                        SetLegend(constSeriSMA2, "SMA(" + myIndicatorOptionForm.smaVal2.ToString() + ")");
                    }
                    break;

                case application.myTypes.indicatorType.MACD:
                    
                    if (myIndicatorOptionForm.macdValFast == 0 || myIndicatorOptionForm.macdValSlow == 0 || myIndicatorOptionForm.macdValSignal == 0) break;
                    string tmp1 = myIndicatorOptionForm.macdValFast.ToString() + "," + myIndicatorOptionForm.macdValSlow.ToString();
                    string tmp2 = myIndicatorOptionForm.macdValSignal.ToString();

                    //For testing
                    //stockChart.DataManipulator.FinancialFormula(FinancialFormula.MovingAverageConvergenceDivergence, tmp1, stockChart.Series[0].Name, "test");
                    //InitChart_Indicator("test", Color.Red);
                    //SetLegend("test", "test(" + tmp1 + ")");

                    //MACD
                    Series macdSeri = stockChart.Series.FindByName(constSeriMACD1);
                    Series emaSeri = stockChart.Series.FindByName(constSeriMACD2);
                    if (macdSeri == null)
                    {
                        macdSeri = new Series();
                        macdSeri.Name = constSeriMACD1;
                        macdSeri.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
                        macdSeri.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                        stockChart.Series.Add(macdSeri);
                    }
                    if (emaSeri == null)
                    {
                        emaSeri = new Series();
                        emaSeri.Name = constSeriMACD2;
                        emaSeri.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
                        emaSeri.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                        stockChart.Series.Add(emaSeri);
                    }
                    macdSeri.Points.Clear(); 
                    emaSeri.Points.Clear();
                    application.stockLibs.MakeIndicatorMACD(myDataSet.priceData, application.stockLibs.stockDataField.Close,
                                                              myIndicatorOptionForm.macdValFast,
                                                              myIndicatorOptionForm.macdValSlow, 
                                                              myIndicatorOptionForm.macdValSignal, 
                                                              macdSeri.Points,emaSeri.Points);
                    SetLegend(macdSeri.Name, macdSeri.Name + "(" + tmp1 + ")");
                    InitChart_Indicator(macdSeri.Name, myIndicatorOptionForm.macdColor1);

                    SetLegend(macdSeri.Name, emaSeri.Name + "(" + tmp2 + ")");
                    InitChart_Indicator(emaSeri.Name, myIndicatorOptionForm.macdColor2);
                    break;
            }
        }
        protected void RemoveIndicator(application.myTypes.indicatorType indicatorType)
        {
            switch (indicatorType)
            {
                case application.myTypes.indicatorType.SMA:
                    stockChart.Series.Remove(stockChart.Series.FindByName(constSeriSMA1));
                    stockChart.Series.Remove(stockChart.Series.FindByName(constSeriSMA2));
                    break;
                case application.myTypes.indicatorType.MACD:
                    stockChart.Series.Remove(stockChart.Series.FindByName("MACD"));
                    stockChart.Series.Remove(stockChart.Series.FindByName("EMA"));
                    break;
            }
        }

        private bool Validate_TradeAdvice()
        {
            bool retVal = true;
            ClearNotifyError();
            if (this.myCurrentStock == null)
            {
                NotifyError(stockCodeGrid);
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

        #region event handler

        private void stockListFilterCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData_StockCode();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

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

        private void chartTiming_myDateAccept(object sender)
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

        private void indicatorSMA_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowIndicatorOption(application.myTypes.indicatorType.SMA);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void indicatorMACD_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowIndicatorOption(application.myTypes.indicatorType.MACD);
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
                if (!Validate_TradeAdvice()) return;
                data.baseDS.stockCodeRow stockCodeRow = this.myCurrentStock;
                ClearTradeAdvice();
                ShowAdvice(stockCodeRow.code, cbStrategy.myValue, chartTiming.frDate, chartTiming.toDate);
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
                myDataSet.investor.Clear();
                application.dataLibs.LoadData(myDataSet.investor, application.sysLibs.sysLoginCode);
                if (myDataSet.investor.Count > 0) myAdviceEstimateForm.myInitCapitalAmt = myDataSet.investor[0].cashAmt; 

                data.baseDS.stockCodeRow stockCodeRow = this.myCurrentStock;
                ClearTradeAdvice();
                ShowAdvice(stockCodeRow.code, cbStrategy.myValue, chartTiming.frDate, chartTiming.toDate);
                ShowEstimation(stockCodeRow.code, cbStrategy.myValue, chartTiming.frDate, chartTiming.toDate);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion
    }
}