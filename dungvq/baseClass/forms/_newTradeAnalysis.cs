using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using application;

namespace test
{
    public partial class newTradeAnalysis : baseClass.forms.baseGraphForm 
    {
        private const string constPricePaneName = "pricePane", constVolumePaneName = "volume";
        private const byte constPricePaneWeight = 100;
        public newTradeAnalysis()
        {
            try
            {
                InitializeComponent();
                //Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567

                //For testing
                LoadAppConfig();

                cbStrategy.LoadData();
                timeScaleCb.LoadData();

                cbStrategy.SelectFirstIfNull();
                timeScaleCb.SelectFirstIfNull();

                this.pricePane = CreatePane(constPricePaneName,constPricePaneWeight);
                this.volumePane = CreateVolumePane();

                //pricePane.mySizingOptions = common.control.basePanel.SizingOptions.Top | common.control.basePanel.SizingOptions.Bottom;
                //pricePane.Visible = false;
                //volumePane.Visible = false;

                mainContainer.Location = new Point(0, toolBarPnl.Location.Y + toolBarPnl.Height);
                
                pricePane.haveCloseButton = false;
                volumePane.haveCloseButton = true;

                CreateIndicatorContextMenu();

                //For testing
                data.baseDS.stockCodeExtDataTable tbl = new data.baseDS.stockCodeExtDataTable();
                myStockCodeRow = application.dataLibs.GetStockData("SSI");
                ShowForm(myStockCodeRow);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private baseClass.controls.graphPane CreateVolumePane()
        {
            baseClass.controls.graphPane myPane = CreatePane(constVolumePaneName, 0);
            myPane.Height = this.ClientRectangle.Height / 3;
            myPane.mySizingOptions = common.control.basePanel.SizingOptions.Top;
            myPane.minSizingHeight = 50;
            return myPane;
        }

        private bool LoadAppConfig()
        {
            data.system.dbConnectionString = "Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";

            application.sysLibs.sysProductOwner = application.Consts.constProductOwner;
            application.sysLibs.sysProductCode = application.Consts.constProductCode;

            //common.settings.sysConfigFile = common.system.myConfigFileName;
            application.configuration.withEncryption = true;
            application.configuration.Load_User_Envir();
            
            //Check data connection after db-setting were loaded
            application.configuration.Load_Sys_Settings();
            application.configuration.Load_User_Config(application.sysLibs.sysUseLocalConfigFile);
            
            application.sysLibs.SetAppEnvironment();
            return true;
        }

        protected baseClass.controls.graphPane pricePane = null, volumePane = null;
        
        protected enum chartTypeEnum : byte {Line, Bar,CandelStick};
        protected chartTypeEnum myChartType
        {
            get
            {
                if (chartBarBtn.isDownState) return chartTypeEnum.Bar;
                if (chartCandelBtn.isDownState) return chartTypeEnum.CandelStick;
                return chartTypeEnum.Line;
            }
            set
            {
                switch (value)
                {
                    case chartTypeEnum.Bar:
                         chartBarBtn.isDownState = true;
                         chartLineBtn.isDownState = false;
                         chartCandelBtn.isDownState = false;
                         break;
                    case chartTypeEnum.CandelStick:
                         chartBarBtn.isDownState = false;
                         chartLineBtn.isDownState = false;
                         chartCandelBtn.isDownState = true;
                         break;
                    default:
                         chartBarBtn.isDownState = false;
                         chartLineBtn.isDownState = true;
                         chartCandelBtn.isDownState = false;
                         break;
                }
            }

        }

        protected data.baseDS.stockCodeExtRow myStockCodeRow = null;
        protected virtual baseClass.forms.baseChartDataOptions CreateChartDataOptionForm()
        {
            return new baseClass.forms.baseChartDataOptions();
        }
        private baseClass.forms.baseChartDataOptions _myChartDataOptionForm = null;
        protected baseClass.forms.baseChartDataOptions myChartDataOptionForm
        {
            get
            {
                if (_myChartDataOptionForm == null)
                {
                    _myChartDataOptionForm = CreateChartDataOptionForm();
                    _myChartDataOptionForm.InitData();
                    _myChartDataOptionForm.myOnProcess += new common.forms.baseDialogForm.onProcess(ChartDataOptionHandler);
                }
                return _myChartDataOptionForm;
            }
        }

        public void ShowForm(data.baseDS.stockCodeExtRow stockCodeRow)
        {
            ShowForm(stockCodeRow, myChartDataOptionForm.myTimeRange);
        }
        public void ShowForm(data.baseDS.stockCodeExtRow stockCodeRow, application.myTypes.timeRanges timing)
        {
            this.ShowMessage("");
            if (stockCodeRow == null) return;
            myChartDataOptionForm.myTimeRange = timing;
            this.Text = "(" + stockCodeRow.tickerCode.Trim() + "," + stockCodeRow.nameEn + ")";
            this.myStockCodeRow = stockCodeRow;

            if (!Validate_StockChart()) return;

            LoadData();
            RefreshForm();
            this.Show();
            this.BringToFront();
            this.FormReSize();
        }

        private void LoadData()
        {
            myDataSet.priceData.Clear();
            dataLibs.LoadData(myDataSet.priceData, timeScaleCb.myValue, myChartDataOptionForm.frDate, myChartDataOptionForm.toDate, myStockCodeRow.code);
        }
        private void PlotChart()
        {
            PlotMainChart();
            smaIndicatorForm.PlotChart();
        }
        private void PlotMainChart()
        {
            pricePane.RemoveAllCurves();
            if (myDataSet.priceData.Count <= 0) return;
            PointPairList dataList;
            switch (this.myChartType)
            {
                case chartTypeEnum.Bar:
                     dataList = application.chart.MakePointPairList(myDataSet.priceData, stockLibs.stockDataField.Close);
                     pricePane.AddStickChart(dataList, "Stick", Color.Blue);
                     break;
                case chartTypeEnum.CandelStick:
                     pricePane.AddCandleStickChart(myDataSet.priceData, "Candle", Color.Blue, Color.Black, Color.Red);
                     break;
                default:
                     dataList = application.chart.MakePointPairList(myDataSet.priceData, stockLibs.stockDataField.Close);
                     pricePane.AddLineChart(dataList, "Line", SymbolType.Circle, Color.Blue, 1);
                     break;
            }
            //Test
            //pricePane.myGraphPane.XAxis.Type = AxisType.DateAsOrdinal;
            //pricePane.myGraphPane.XAxis.Scale.MinorUnit = DateUnit.Day;

            //pricePane.myGraphPane.XAxis.Scale.Min = new XDate(myDataSet.priceData[0].onDate);
            //pricePane.myGraphPane.XAxis.Scale.Max = new XDate(myDataSet.priceData[myDataSet.priceData.Count - 1].onDate);

            pricePane.PlotGraph();
            if (mainContainer.GetChild(volumePane)  != null)
            {
                volumePane.RemoveAllCurves();
                dataList = application.chart.MakePointPairList(myDataSet.priceData, stockLibs.stockDataField.Volume);
                volumePane.AddStickChart(dataList, "Stick", Color.Navy);
                volumePane.myGraphPane.XAxis.Type = AxisType.DateAsOrdinal;
                volumePane.myGraphPane.XAxis.Scale.Min = new XDate(myDataSet.priceData[0].onDate);
                volumePane.myGraphPane.XAxis.Scale.Max = new XDate(myDataSet.priceData[myDataSet.priceData.Count - 1].onDate);
                volumePane.PlotGraph();
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
            if (!myChartDataOptionForm.GetDate())
            {
                retVal = false;
            }
            return retVal;
        }

        //Indicator form
        private indicators.forms.indicatorSMA _smaIndicatorForm = null;
        private indicators.forms.indicatorSMA smaIndicatorForm 
        {
            get
            {
                if (_smaIndicatorForm == null)
                {
                    _smaIndicatorForm = new indicators.forms.indicatorSMA();
                    _smaIndicatorForm.mainGraphPane = pricePane;
                    _smaIndicatorForm.myParentForm = this;
                    _smaIndicatorForm.Init();
                }
                return _smaIndicatorForm;
            }
        }

        private void ShowIndicator(object sender, EventArgs e)
        {
            try
            {
                smaIndicatorForm.ShowForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void CreateIndicatorContextMenu()
        {
            ContextMenu mainContextMenu = new ContextMenu();
            data.baseDS.indicatorCatDataTable indicatorCatTbl = new data.baseDS.indicatorCatDataTable();
            data.baseDS.indicatorDataTable indicatorTbl = new data.baseDS.indicatorDataTable();
            application.dataLibs.LoadData(indicatorCatTbl);
            application.dataLibs.LoadData(indicatorTbl,true);
            
            DataView indicatorView = new DataView(indicatorTbl);
            data.baseDS.indicatorRow indicatorRow;
            for (int idx1 = 0; idx1 < indicatorCatTbl.Count; idx1++)
            {
                indicatorView.RowFilter = indicatorTbl.catCodeColumn.ColumnName + "='" + indicatorCatTbl[idx1].code + "'";
                if (indicatorView.Count == 0) continue;
                MenuItem catMenuItem = new MenuItem();
                catMenuItem.Name = "catMenuItem" + indicatorCatTbl[idx1].code;
                catMenuItem.Text = indicatorCatTbl[idx1].description;
                mainContextMenu.MenuItems.Add(catMenuItem);
                for (int idx2 = 0; idx2 < indicatorView.Count; idx2++)
                {
                    indicatorRow = (data.baseDS.indicatorRow)indicatorView[idx2].Row;
                    MenuItem menuItem = new MenuItem();
                    menuItem.Name = "menuItem" + indicatorRow.code;
                    menuItem.Tag = indicatorRow.code.Trim();
                    menuItem.Text = indicatorRow.description;
                    catMenuItem.MenuItems.Add(menuItem);
                    menuItem.Click += new System.EventHandler(ShowIndicator);
                }
            }
            for (int idx2 = 0; idx2 < indicatorTbl.Count; idx2++)
            {
                indicatorRow = indicatorTbl[idx2];
                if (indicatorCatTbl.FindBycode(indicatorRow.catCode.Trim()) != null) continue;
                MenuItem menuItem = new MenuItem();
                menuItem.Name = "menuItem" + indicatorRow.code;
                menuItem.Tag = indicatorRow.code.Trim();
                menuItem.Text = indicatorRow.description;
                mainContextMenu.MenuItems.Add(menuItem);
                menuItem.Click += new System.EventHandler(ShowIndicator);
            }
            indicatorBtn.ContextMenu = mainContextMenu;
        }

        protected override void RefreshForm() 
        {
            PlotChart();
        }

        #region event handler
        //protected void RefreshForm() { ChartDataOptionHandler(null, null); }
        private void ChartDataOptionHandler(object sender,common.baseDialogEvent e)
        {
            if (e != null && e.isCloseClick) return; 
            if (!Validate_StockChart()) return;
            LoadData();
            PlotChart();
        }
        
        private void dataBtn_Click(object sender, EventArgs e)
        {
            try
            {
                myChartDataOptionForm.ShowForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void indicatorBtn_Click(object sender, EventArgs e)
        {
            indicatorBtn.ContextMenu.Show(indicatorBtn,
                                          new Point(indicatorBtn.Location.X + 150, indicatorBtn.Location.Y + indicatorBtn.Height-10),
                                          LeftRightAlignment.Left);
        }
        private void estimationBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!Validate_TradeAdvice()) return;
                //ClearTradeAdvice();
                //ShowChart();
                //ShowEstimation(this.myStockCodeRow, cbStrategy.GetDataInfo(), chartTiming.myTimeScale,chartTiming.frDate, chartTiming.toDate);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void chartLineBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.myChartType = chartTypeEnum.Line; 
                PlotChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void chartCandelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.myChartType = chartTypeEnum.CandelStick;
                PlotChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void chartBarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.myChartType = chartTypeEnum.Bar;
                PlotChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void volumeChartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                volumeChartBtn.isDownState = !volumeChartBtn.isDownState;
                if (volumeChartBtn.isDownState)
                {
                    if (mainContainer.GetChild(volumePane) == null)   this.volumePane = CreateVolumePane();
                    volumePane.Visible = true;
                }
                else
                {
                    RemovePane(volumePane);
                }
                mainContainer.ArrangeChildren();
                PlotChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void timeScaleCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                PlotChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void cbStrategy_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }       

        private void test_myOnChildPaneClosed(baseClass.controls.graphPane sender)
        {
            if (sender.Name == constVolumePaneName)
            {
                volumeChartBtn.isDownState = false;
            }
        }
        #endregion event handler
    }
}