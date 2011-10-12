using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
using application;

namespace baseClass.controls
{
    public class formContainer : common.controls.baseContainer
    {
        public override void ArrangeChildren()
        {
            switch(this.myArrangeOptions)
            {
                case common.controls.childArrangeOptions.Casscade: Arrange_Casscade(); break;
                case common.controls.childArrangeOptions.Tiled: Arrange_Tiled(); break;
            }
        }

        private void Arrange_Tiled()
        {
            if (this.ChildCount <= 0) return;
            Form myForm;
            int noFormInCol = (int)Math.Round(Math.Sqrt(this.ChildCount),0);
            int noFormInRow = noFormInCol;
            if (noFormInRow * noFormInCol < this.ChildCount) noFormInRow++;
            int width = this.Size.Width + 4;
            int height = this.Size.Height + SystemInformation.BorderSize.Height;
            Size formSize = new Size((int)width/noFormInCol, (int)height / noFormInRow);
            Point startLocation = this.Location;

            int colCount = 0,rowCount = 0;
            for (int idx = 0; idx < this.ChildCount; idx++)
            {
                if (colCount == noFormInCol)
                {
                    colCount = 0; rowCount++;
                }
                width = formSize.Width + 4;
                height = formSize.Height + SystemInformation.BorderSize.Height;
                startLocation = new Point(Location.X + colCount * width,Location.Y + rowCount*height);
                myForm = (Form)this.GetChild(idx);
                myForm.Location = startLocation;
                myForm.Size = formSize;
                colCount++;
            }
        }
        private void Arrange_Casscade()
        {
            if (this.ChildCount <= 0) return;
            Form myForm;
            Size formSize = ((Form)this.GetChild(0)).Size;
            Point startLocation = this.Location;
            for (int idx = 0; idx < this.ChildCount; idx++)
            {
                myForm = (Form)this.GetChild(idx);
                myForm.Location = startLocation;
                myForm.Size = formSize;
                startLocation = new Point(startLocation.X + SystemInformation.CaptionHeight, startLocation.Y + SystemInformation.CaptionHeight);
            }
        }

    }
    public class graphPaneContainer : common.controls.baseContainer
    {
        public override void ArrangeChildren()
        {
            if (this.ChildCount <= 0) return;
            graphPanel myPane;
            int totalWeight = 0, totalHeight = this.ClientRectangle.Height-1;
            for (int idx = 0; idx < this.ChildCount; idx++)
            {
                myPane = (graphPanel)this.GetChild(idx);
                if (!myPane.isVisible) continue;
                if (myPane.myWeight <= 0)
                {
                    totalHeight -= myPane.Height;
                    continue;
                }
                totalWeight += myPane.myWeight;
            }
            int startY = 0;
            for (int idx = 0; idx < this.ChildCount; idx++)
            {
                myPane = (graphPanel)this.GetChild(idx);
                if (!myPane.isVisible) continue;
                //Dont size panes having myWeight<=0
                if (myPane.myWeight > 0)
                {
                    myPane.Size = new Size(this.Width, totalHeight * (myPane.myWeight / totalWeight) - 1);
                }
                else myPane.Size = new Size(this.Width, myPane.Height);

                myPane.Location = new Point(0, startY);
                startY += myPane.Height + 1;
            }
        }
    }
    public class graphPanel : common.controls.baseGraphPanel
    {
        private bool fResizing = false;
        public graphPaneContainer myContainer = null;
        protected override void OnResize(EventArgs eventargs)
        {
            try
            {
                if (fResizing) return;
                fResizing = true;
                base.OnResize(eventargs);
                if (myContainer != null) myContainer.ArrangeChildren();
                fResizing = false;
            }
            catch (Exception er)
            {
                fResizing = false;
                common.system.ThrowException(er);
            }
        }
    }

    #region multi-value object
    public class baseCheckedLB : common.controls.baseCheckedListBox
    {
        public baseCheckedLB() { }
        protected override string GetItemValue(object obj)
        {
            return ((common.myComboBoxItem)obj).Value;
        }
    }
    public class baseListBox : common.controls.baseListBox
    {
        public baseListBox() { }
        protected override string GetItemValue(object obj)
        {
            return ((common.myComboBoxItem)obj).Value;
        }
    }
    #endregion 

    #region comboBox
    public class cbStockSelection : common.controls.baseComboBox
    {
        public cbStockSelection()
        {
        }
        public enum Options : byte { None, All, StockExchange, WatchList, SysWatchList, Others };
        private object lastOptions = null;
        public override void SetLanguage()
        {
            int saveSelectedIdx = this.SelectedIndex;
            if (lastOptions == null) return;
            LoadData((Options[])lastOptions);
            if (saveSelectedIdx>=0) this.SelectedIndex = saveSelectedIdx;
        }

        public override void LoadData() 
        {
            LoadData(new Options[] { Options.All, Options.StockExchange, Options.WatchList, Options.SysWatchList, Options.Others }); 
        }
        public void LoadData(Options[] options)
        {
            common.myKeyValueExt item;
            this.Items.Clear();
            if (InList(options, Options.All))
            {
                item = new common.myKeyValueExt(Settings.sysString_All_Description, Settings.sysString_All_Code);
                item.Attribute1 = ((byte)Options.All).ToString();
                this.Items.Add(item);
            }

            //stockExchange
            if (InList(options, Options.StockExchange))
            {
                data.baseDS.stockExchangeDataTable stockExchangeTbl = new data.baseDS.stockExchangeDataTable();
                stockExchangeTbl.Clear();
                dataLibs.LoadData(stockExchangeTbl);
                for (int idx = 0; idx < stockExchangeTbl.Count; idx++)
                {
                    item = new common.myKeyValueExt(stockExchangeTbl[idx].code, stockExchangeTbl[idx].code);
                    item.Attribute1 = ((byte)Options.StockExchange).ToString();
                    this.Items.Add(item);
                }
            }
            //Portfolio
            data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
            if (InList(options, Options.SysWatchList))
            {
                
                portfolioTbl.Clear();
                dataLibs.LoadData(portfolioTbl,AppTypes.PortfolioTypes.SysWatchList);
                if (portfolioTbl.Count > 0)
                {
                    item = new common.myKeyValueExt("--" + language.GetString("system") + "--", "");
                    item.Attribute1 = ((byte)Options.SysWatchList).ToString();
                    this.Items.Add(item);
                }
                for (int idx = 0; idx < portfolioTbl.Count; idx++)
                {
                    item = new common.myKeyValueExt(portfolioTbl[idx].name, portfolioTbl[idx].code);
                    item.Attribute1 = ((byte)Options.SysWatchList).ToString();
                    this.Items.Add(item);
                }
            }
            if (InList(options, Options.WatchList))
            {
                portfolioTbl.Clear();
                dataLibs.LoadPortfolioByInvestor(portfolioTbl, sysLibs.sysLoginCode, AppTypes.PortfolioTypes.WatchList);
                if (portfolioTbl.Count > 0)
                {
                    item = new common.myKeyValueExt("--" + language.GetString("watchList") + "--","");
                    item.Attribute1 = ((byte)Options.WatchList).ToString();
                    this.Items.Add(item);
                }
                for (int idx = 0; idx < portfolioTbl.Count; idx++)
                {
                    item = new common.myKeyValueExt(portfolioTbl[idx].name, portfolioTbl[idx].code);
                    item.Attribute1 = ((byte)Options.WatchList).ToString();
                    this.Items.Add(item);
                }
            }

            if (InList(options, Options.Others))
            {
                item = new common.myKeyValueExt("--" + language.GetString("others") + "--", "");
                item.Attribute1 = ((byte)Options.Others).ToString();
                this.Items.Add(item);
            }

            if (this.Items.Count > 0)
            {
                this.MaxDropDownItems = this.Items.Count;
                this.SelectedIndex = 0;
            }
            lastOptions = options;
        }
        public data.tmpDS.stockCodeDataTable GetStockList()
        {
            if (this.SelectedItem == null) return null;
            data.tmpDS.stockCodeDataTable tbl = new data.tmpDS.stockCodeDataTable();
            common.myKeyValueExt item = (common.myKeyValueExt)this.SelectedItem;
            Options watchListType = (Options)byte.Parse(item.Attribute1);
            switch (watchListType)
            {
                case Options.All:
                    dataLibs.LoadData(tbl, AppTypes.CommonStatus.Enable);
                    break;
                case Options.StockExchange:
                    dataLibs.LoadStockCode_ByStockExchange(tbl, item.Value, AppTypes.CommonStatus.Enable);
                    break;
                case Options.SysWatchList:
                case Options.WatchList:
                    StringCollection watchList = new StringCollection();
                    //All stock codes of  specified type ??
                    if (item.Value != "")
                    {
                        watchList.Add(item.Value);
                    }
                    else
                    {
                        for (int idx = 0; idx < this.Items.Count; idx++)
                        {
                            common.myKeyValueExt tmpItem = (common.myKeyValueExt)this.Items[idx];
                            if (watchListType != (Options)byte.Parse(tmpItem.Attribute1) || (tmpItem.Value == "")) continue;
                            watchList.Add(tmpItem.Value);
                        }
                    }
                    dataLibs.LoadStockCode_ByWatchList(tbl, watchList);
                    break;
                default: return null;
            }
            return tbl;
        }
        public new virtual Options myValue
        {
            get
            {
                if (this.SelectedItem == null) return Options.None;
                common.myKeyValueExt item = (common.myKeyValueExt)this.SelectedItem;
                return (Options)byte.Parse(item.Attribute1);
            }
            set
            {
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    common.myKeyValueExt item = (common.myKeyValueExt)this.SelectedItem;
                    if ((Options)byte.Parse(item.Attribute1) == value)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        private bool InList(Options[] list, Options item)
        {
            for (int idx = 0; idx < list.Length; idx++)
            {
                if (list[idx] == item) return true;
            }
            return false;
        }
    }

    public class cbStrategyType : common.controls.baseComboBox
    {
        public cbStrategyType()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.StrategyTypes));
        }
        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (AppTypes.StrategyTypes item in Enum.GetValues(typeof(AppTypes.StrategyTypes)))
            {
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(AppTypes.StrategyTypes[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual AppTypes.StrategyTypes myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.StrategyTypes.Strategy;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.StrategyTypes item in Enum.GetValues(typeof(AppTypes.StrategyTypes)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.StrategyTypes.Strategy;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.StrategyTypes.Strategy;
                foreach (AppTypes.StrategyTypes item in Enum.GetValues(typeof(AppTypes.StrategyTypes)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbTimeRange : common.controls.baseComboBox
    {
        public cbTimeRange()
        {
            //this.myValue = application.AppTypes.TimeRanges.YTD;
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.TimeRanges));
        }
        public void LoadData(AppTypes.TimeRanges[] ranges)
        {
            this.Items.Clear();
            for(int idx=0;idx<ranges.Length;idx++)
            {
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(ranges[idx]), ranges[idx].ToString()));
            }
            this.myValue = Settings.sysDefaultTimeRange;
            if (this.Items.Count > 0) this.MaxDropDownItems = this.Items.Count;
        }
        public void LoadDataWithout(AppTypes.TimeRanges[] excludeList)
        {
            this.Items.Clear();
            foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
            {
                bool fAccept = true;
                for (int idx = 0; idx < excludeList.Length; idx++)
                {
                    if (excludeList[idx] == item)
                    {
                        fAccept = false;
                        break;
                    }
                }
                if (fAccept)
                    this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            this.myValue = Settings.sysDefaultTimeRange;
            if (this.Items.Count > 0) this.MaxDropDownItems = this.Items.Count;
        }

        public override void LoadData()
        {
            LoadDataWithout(new AppTypes.TimeRanges[] { AppTypes.TimeRanges.None });
        }

        public new virtual AppTypes.TimeRanges myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.TimeRanges.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.TimeRanges.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.TimeRanges.None;
                foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }

        public DateTime StartDate = common.Consts.constNullDate;
        public DateTime EndDate = common.Consts.constNullDate;
        public bool GetDate()
        {
            return AppTypes.GetDate(this.myValue, out this.StartDate, out this.EndDate);
        }
    }

    public class ToolStripCbTimeRange : ToolStripComboBox
    {
        public ToolStripCbTimeRange()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList; 
        }
        public void SetLanguage()
        {
            int saveIdx = this.SelectedIndex;
            language.SetLanguage(this.Items, typeof(AppTypes.TimeRanges));
            if (saveIdx >= 0) this.SelectedIndex = saveIdx;
        }
        public void LoadData(AppTypes.TimeRanges[] ranges)
        {
            this.Items.Clear();
            for (int idx = 0; idx < ranges.Length; idx++)
            {
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(ranges[idx]), ranges[idx].ToString()));
            }
            this.myValue = Settings.sysDefaultTimeRange;
            if (this.Items.Count > 0) this.MaxDropDownItems = this.Items.Count;
        }
        public void LoadDataWithout(AppTypes.TimeRanges[] excludeList)
        {
            this.Items.Clear();
            foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
            {
                bool fAccept = true;
                for (int idx = 0; idx < excludeList.Length; idx++)
                {
                    if (excludeList[idx] == item)
                    {
                        fAccept = false;
                        break;
                    }
                }
                if (fAccept) this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            this.myValue = Settings.sysDefaultTimeRange;
            if (this.Items.Count > 0) this.MaxDropDownItems = this.Items.Count;
        }

        public void LoadData()
        {
            LoadDataWithout(new AppTypes.TimeRanges[] { AppTypes.TimeRanges.None });
        }

        public virtual AppTypes.TimeRanges myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.TimeRanges.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.TimeRanges.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.TimeRanges.None;
                foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }

    public class cbTimeScale : common.controls.baseComboBox
    {
        public cbTimeScale()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.TimeScale));
        }

        public override void LoadData()
        {
            LoadList(AppTypes.myTimeScales);
        }
        public void LoadList(AppTypes.TimeScale[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(list[idx].Description, list[idx].Code));
            if (this.Items.Count > 0)
            {
                this.MaxDropDownItems = this.Items.Count;
                this.myValue = AppTypes.TimeScaleFromCode(Settings.sysDefaultTimeScaleCode);
            }
        }
        public new virtual AppTypes.TimeScale myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.MainDataTimeScale;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                return AppTypes.TimeScaleFromCode(selectedItem.Value);
            }
            set
            {
                //if (value == null) return;
                string statStr = value.Code;
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new AppTypes.TimeScale SelectedValue
        {
            get
            {
                return this.myValue;
            }
            set
            {
                this.myValue = value;
            }
        }
    }
    public class cbTradeAction : common.controls.baseComboBox
    {
        public cbTradeAction()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.TradeActions));
        }
        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (AppTypes.TradeActions item in Enum.GetValues(typeof(AppTypes.TradeActions)))
            {
                if (!allItem && item == AppTypes.TradeActions.None) continue;
                this.Items.Add(new common.myComboBoxItem(item.ToString(), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(AppTypes.TradeActions[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(list[idx].ToString(), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual AppTypes.TradeActions myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.TradeActions.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.TradeActions item in Enum.GetValues(typeof(AppTypes.TradeActions)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.TradeActions.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.TradeActions.None;
                foreach (AppTypes.TradeActions item in Enum.GetValues(typeof(AppTypes.TradeActions)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbBizSectorType : common.controls.baseComboBox
    {
        public cbBizSectorType()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.BizSectorTypes));
        }

        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (AppTypes.BizSectorTypes item in Enum.GetValues(typeof(AppTypes.BizSectorTypes)))
            {
                if (!allItem && item == AppTypes.BizSectorTypes.None) continue;
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(AppTypes.BizSectorTypes[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual AppTypes.BizSectorTypes myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.BizSectorTypes.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.BizSectorTypes item in Enum.GetValues(typeof(AppTypes.BizSectorTypes)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.BizSectorTypes.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.BizSectorTypes.None;
                foreach (AppTypes.BizSectorTypes item in Enum.GetValues(typeof(AppTypes.BizSectorTypes)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbChartType : common.controls.baseComboBox
    {
        public cbChartType()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.ChartTypes));
        }
        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem )
        {
            this.Items.Clear();
            foreach (AppTypes.ChartTypes item in Enum.GetValues(typeof(AppTypes.ChartTypes)))
            {
                if (!allItem && item== AppTypes.ChartTypes.None) continue;
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(AppTypes.ChartTypes[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual AppTypes.ChartTypes myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.ChartTypes.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.ChartTypes item in Enum.GetValues(typeof(AppTypes.CommonStatus)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.ChartTypes.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.ChartTypes.None;
                foreach (AppTypes.ChartTypes item in Enum.GetValues(typeof(AppTypes.ChartTypes)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbCommonStatus : common.controls.baseComboBox
    {
        public cbCommonStatus()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.CommonStatus));
        }
        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (AppTypes.CommonStatus item in Enum.GetValues(typeof(AppTypes.CommonStatus)))
            {
                if (!allItem && item == AppTypes.CommonStatus.None) continue;
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(AppTypes.CommonStatus[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual AppTypes.CommonStatus myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.CommonStatus.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.CommonStatus item in Enum.GetValues(typeof(AppTypes.CommonStatus)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.CommonStatus.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.CommonStatus.None;
                foreach (AppTypes.CommonStatus item in Enum.GetValues(typeof(AppTypes.CommonStatus)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbTradeAlertStatus : cbCommonStatus
    {
        public cbTradeAlertStatus()
        {
        }
        public override void LoadData() 
        {
            LoadList(new AppTypes.CommonStatus[] { AppTypes.CommonStatus.New,AppTypes.CommonStatus.Close});
        }
    }
    public class cbStockStatus : cbCommonStatus
    {
        public cbStockStatus()
        {
        }
        public override void LoadData()
        {
            LoadList(new AppTypes.CommonStatus[] { AppTypes.CommonStatus.Enable, AppTypes.CommonStatus.Disable});
        }
    }

    public class cbSysCodeCat : common.controls.baseComboBox
    {
        public cbSysCodeCat()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            data.baseDS.sysCodeCatDataTable tbl = new data.baseDS.sysCodeCatDataTable();
            dataLibs.LoadData(tbl);
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.categoryColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public data.baseDS.sysCodeCatRow GetRow(string code)
        {
            return ((data.baseDS.sysCodeCatDataTable)this.DataSource).FindBycategory(code);
        }
    }
    public class cbCurrency : common.controls.baseComboBox
    {
        public cbCurrency()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            data.baseDS.currencyDataTable tbl = new data.baseDS.currencyDataTable();
            dataLibs.LoadData(tbl);
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public data.baseDS.currencyRow GetRow(string code)
        {
            return ((data.baseDS.currencyDataTable)this.DataSource).FindBycode(code);
        }
    }
    public class cbCountry : common.controls.baseComboBox
    {
        public cbCountry()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            data.baseDS.countryDataTable tbl = new data.baseDS.countryDataTable();
            dataLibs.LoadData(tbl);
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public data.baseDS.countryRow GetRow(string code)
        {
            return ((data.baseDS.countryDataTable)this.DataSource).FindBycode(code);
        }
    }
    public class cbIndicatorCat : common.controls.baseComboBox
    {
        public cbIndicatorCat()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            data.baseDS.indicatorCatDataTable tbl = new data.baseDS.indicatorCatDataTable();
            dataLibs.LoadData(tbl);
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
    }
    public class cbInvestorCat : common.controls.baseComboBox
    {
        public cbInvestorCat()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            data.baseDS.investorCatDataTable tbl = new data.baseDS.investorCatDataTable();
            dataLibs.LoadData(tbl);
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
    }
    public class cbStrategyCat : common.controls.baseComboBox
    {
        public cbStrategyCat()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void SetLanguage()
        {
            data.baseDS.strategyCatDataTable tbl = (data.baseDS.strategyCatDataTable)this.DataSource;
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                if (tbl[idx].code == Settings.sysString_All_Code)
                {
                    tbl[idx].description = Settings.sysString_All_Description;
                    break;
                }
            }
        }
        public override void LoadData()
        {
            LoadData(false);
        }
        public virtual void LoadData(bool AddAllItem)
        {
            data.baseDS.strategyCatDataTable tbl = new data.baseDS.strategyCatDataTable();
            if (AddAllItem)
            {
                data.baseDS.strategyCatRow row = tbl.NewstrategyCatRow();
                row.code = Settings.sysString_All_Code;
                row.description = Settings.sysString_All_Description;
                tbl.AddstrategyCatRow(row);
            }
            dataLibs.LoadData(tbl);
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public virtual bool IsAllValueSelected()
        {
            return (this.myValue == Settings.sysString_All_Code);
        }
        public virtual string[] GetAllValues()
        {
            string[] list = new string[0];
            data.baseDS.portfolioDataTable tbl = (data.baseDS.portfolioDataTable)this.DataSource;

            for (int idx = 0; idx < tbl.Count; idx++)
            {
                if (tbl[idx].code == Settings.sysString_All_Code) continue;
                Array.Resize(ref list, list.Length + 1);
                list[list.Length - 1] = tbl[idx].code;
            }
            return list;
        }
        public virtual string[] GetValues()
        {
            if (IsAllValueSelected()) return GetAllValues();
            return new string[] { this.myValue };
        }
    }
    public class cbEmployeeRange : common.controls.baseComboBox
    {
        public cbEmployeeRange()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            data.baseDS.employeeRangeDataTable tbl = new data.baseDS.employeeRangeDataTable();
            dataLibs.LoadData(tbl);
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public new int myValue
        {
            get 
            { 
                int no = 0;
                if (!int.TryParse(base.myValue, out no)) return 0;
                return no;
            }
            set 
            {
                if (this.DataSource == null) return;
                data.baseDS.employeeRangeDataTable tbl = (data.baseDS.employeeRangeDataTable)this.DataSource;
                int no = 0;
                for (int idx = 0; idx < tbl.Count; idx++)
                {
                    if (!int.TryParse(tbl[idx].code, out no)) continue;
                    if (no == value)
                    {
                        base.myValue = tbl[idx].code;
                        break;
                    }
                }
            }
        }
    }
    public class cbStockExchange : common.controls.baseComboBox
    {
        public cbStockExchange()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            data.baseDS.stockExchangeDataTable tbl = new data.baseDS.stockExchangeDataTable();
            dataLibs.LoadData(tbl);
            this.DisplayMember = tbl.codeColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
    }
    public class cbWatchList : common.controls.baseComboBox
    {
        public cbWatchList()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void LoadData(AppTypes.PortfolioTypes type)
        {
            LoadData(type, application.sysLibs.sysLoginCode,false);
        }
        public void LoadData(AppTypes.PortfolioTypes type, string investorCode,bool AddAllItem)
        {
            data.baseDS.portfolioDataTable tbl = new data.baseDS.portfolioDataTable();
            if (AddAllItem)
            {
                data.baseDS.portfolioRow row = tbl.NewportfolioRow();
                dataLibs.InitData(row);
                row.investorCode = investorCode;
                row.name = Settings.sysString_All_Description;
                row.code = Settings.sysString_All_Code;
                tbl.AddportfolioRow(row);
            }
            dataLibs.LoadPortfolioByInvestor(tbl, investorCode, type);
            this.DisplayMember = tbl.nameColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public void LoadData(string investorCode, bool AddAllItem)
        {
            data.baseDS.portfolioDataTable tbl = new data.baseDS.portfolioDataTable();
            if (AddAllItem)
            {
                data.baseDS.portfolioRow row = tbl.NewportfolioRow();
                dataLibs.InitData(row);
                row.investorCode = investorCode;
                row.name = Settings.sysString_All_Description;
                row.code = Settings.sysString_All_Code;
                tbl.AddportfolioRow(row);
            }
            dataLibs.LoadPortfolioByInvestor(tbl, investorCode);
            this.DisplayMember = tbl.nameColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public void LoadDataByCode(string code)
        {
            data.baseDS.portfolioDataTable tbl = new data.baseDS.portfolioDataTable();
            dataLibs.LoadData(tbl, code);
            this.DisplayMember = tbl.nameColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public virtual bool IsAllValueSelected()
        {
            return (this.myValue == Settings.sysString_All_Code);
        }
        public virtual StringCollection GetAllValues()
        {
            StringCollection list = new StringCollection();
            data.baseDS.portfolioDataTable tbl = (data.baseDS.portfolioDataTable)this.DataSource;
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                if(tbl[idx].code == Settings.sysString_All_Code) continue;
                list.Add(tbl[idx].code);
            }
            return list;
        }
        public virtual string[] GetValues()
        {
            if (IsAllValueSelected())
            {
                return common.system.Collection2List(GetAllValues());
            }
            return new string[] { this.myValue };
        }
    }
    public class cbSex : common.controls.baseComboBox
    {
        public cbSex()
        {
        }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.Sex));
        }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (AppTypes.Sex item in Enum.GetValues(typeof(AppTypes.Sex)))
            {
                if (!allItem && item == AppTypes.Sex.None) continue;
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public override void LoadData() { LoadData(false);}
        public void LoadList(AppTypes.Sex[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual AppTypes.Sex myValue
        {
            get
            {
                if (this.SelectedItem == null) return AppTypes.Sex.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (AppTypes.Sex item in Enum.GetValues(typeof(AppTypes.Sex)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return AppTypes.Sex.None;
            }
            set
            {
                string statStr = value.ToString();
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value.ToString() == statStr)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new byte SelectedValue
        {
            get
            {
                return (byte)this.myValue;
            }
            set
            {
                this.myValue = AppTypes.Sex.None;
                foreach (AppTypes.Sex item in Enum.GetValues(typeof(AppTypes.Sex)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }

    public class cbStrategy : common.controls.baseComboBox
    {
        public cbStrategy()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            LoadData(AppTypes.StrategyTypes.Strategy);
        }
        public virtual void LoadData(AppTypes.StrategyTypes type)
        {
            string[] keys = Strategy.Data.MetaList.Keys;
            object[] values = Strategy.Data.MetaList.Values;
            this.Items.Clear();
            for (int idx = 0; idx < keys.Length; idx++)
            {
                Strategy.Meta meta = (Strategy.Meta)values[idx];
                if (meta.Type != type) continue;
                this.Items.Add(new common.myComboBoxItem(meta.Name, meta.Code));
            }
            if (this.Items.Count > 0)
            {
                this.SelectedIndex = 0;
                this.MaxDropDownItems = this.Items.Count;
            }
        }
        public override string myValue
        {
            get
            {
                if (this.SelectedItem == null) return "";
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                return selectedItem.Value;
            }
            set
            {
                common.myComboBoxItem item;
                for (int idx = 0; idx < this.Items.Count; idx++)
                {
                    item = (common.myComboBoxItem)this.Items[idx];
                    if (item.Value == value)
                    {
                        this.SelectedIndex = idx;
                        break;
                    }
                }
            }
        }
        public new string SelectedValue
        {
            get
            {
                return this.myValue;
            }
            set
            {
                this.myValue = value; 
            }
        }
    }

    #endregion

    #region Checked Listbox
    public class clbWatchList : baseCheckedLB
    {
        private AppTypes.PortfolioTypes _watchType = AppTypes.PortfolioTypes.Portfolio;
        public AppTypes.PortfolioTypes WatchType
        {
            get { return this._watchType; }
            set { this._watchType = value; }
        }

        public clbWatchList()
        {
        }
        public override void LoadData()
        {
            LoadData(application.sysLibs.sysLoginCode, false);
        }
        public virtual void LoadData(string investorCode, bool checkedAll)
        {
            data.baseDS.portfolioDataTable tbl = new data.baseDS.portfolioDataTable();
            dataLibs.LoadPortfolioByInvestor(tbl, investorCode, this.WatchType);
            this.Items.Clear(); 
            for (int idx = 0; idx < tbl.Count; idx++)
                this.Items.Add(new common.myComboBoxItem(tbl[idx].name.Trim(), tbl[idx].code.Trim()), checkedAll);
            SaveItems();
        }
    }

    public class clbTimeScale : baseCheckedLB
    {
        public clbTimeScale() { }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.TimeRanges));
        }
        public override void LoadData()
        {
            AppTypes.TimeScale defauTimeScale = AppTypes.TimeScaleFromCode(Settings.sysDefaultTimeScaleCode);
            foreach (AppTypes.TimeScale item in AppTypes.myTimeScales)
            {
                this.Items.Add(new common.myComboBoxItem(item.Text, item.Code), item.Code == defauTimeScale.Code);
            }
            SaveItems();
        }
    }
    public class clbTimeRange : baseCheckedLB
    {
        public clbTimeRange() { }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.TimeRanges));
        }
        public override void LoadData()
        {
            this.Items.Clear();
            foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
            {
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(item), item.ToString()));
            }
            SaveItems();
        }
        public void LoadData(AppTypes.TimeRanges[] ranges)
        {
            this.Items.Clear();
            for (int idx = 0; idx < ranges.Length; idx++)
            {
                this.Items.Add(new common.myComboBoxItem(AppTypes.Type2Text(ranges[idx]), ranges[idx].ToString()));
            }
            SaveItems();
        }
    }

    public class clbStrategy : baseCheckedLB
    {
        private AppTypes.StrategyTypes strategyType = AppTypes.StrategyTypes.Strategy; 
        public clbStrategy() { }
        public override void SetLanguage()
        {
            language.SetLanguage(this, typeof(AppTypes.StrategyTypes));
        }
        public override void LoadData()
        {
            LoadData(AppTypes.StrategyTypes.Strategy);
        }
        public void LoadData(AppTypes.StrategyTypes type)
        {
            LoadData(type,null);
            SaveItems();
        }

        protected void LoadData(AppTypes.StrategyTypes type,string catCode)
        {
            this.strategyType = type;
            string[] keys = Strategy.Data.MetaList.Keys;
            object[] values = Strategy.Data.MetaList.Values;
            this.Items.Clear();
            for (int idx = 0; idx < keys.Length; idx++)
            {
                Strategy.Meta meta = (Strategy.Meta)values[idx];
                if (meta.Type != type) continue;
                if (catCode==null || meta.Category == catCode) 
                    this.Items.Add(new common.myComboBoxItem(meta.Name,meta.Code));
            }
        }
        public void SetFilter(string catCode)
        {
            LoadData(this.strategyType,catCode);
            SaveItems();
        }
    }
    public class clbStockCode : baseCheckedLB
    {
        private data.baseDS.stockCodeRow stockCodeRow;
        private data.baseDS.stockCodeDataTable myCompamyTbl = new data.baseDS.stockCodeDataTable();
        private data.baseDS.stockCodeDataTable _myDataTbl = null;
        public clbStockCode() { }
        public data.baseDS.stockCodeDataTable myDataTbl
        {
            get { return _myDataTbl; }
            set
            {
                this.Items.Clear();
                this._myDataTbl = value;
                if (_myDataTbl == null) return;
                string tmp;
                data.baseDS.stockCodeRow stockCodeRow;
                for (int idx = 0; idx < value.Count; idx++)
                {
                    stockCodeRow = dataLibs.FindAndCache(myCompamyTbl, value[idx].code);
                    tmp = value[idx].tickerCode.Trim() + (stockCodeRow == null ? "" : " - " + (stockCodeRow.IsnameEnNull()?"":stockCodeRow.nameEn));
                    this.Items.Add(new common.myComboBoxItem(tmp, value[idx].code.Trim()), false);
                }
                this.SaveItems();
            }
        }

        public override void LoadData()
        {
            data.baseDS.stockCodeDataTable dataTbl = new data.baseDS.stockCodeDataTable();
            dataTbl.Clear();
            dataLibs.LoadData(dataTbl,AppTypes.CommonStatus.Enable);
            this.myDataTbl = dataTbl;
            return;
        }
        public void LoadDataByBizSector(StringCollection list)
        {
            data.baseDS.stockCodeDataTable dataTbl = new data.baseDS.stockCodeDataTable();
            dataTbl.Clear();
            dataLibs.LoadStockCode_ByBizSectors(dataTbl,list);
            this.myDataTbl = dataTbl;
        }
        public data.baseDS.stockCodeRow GetRow(string code)
        {
            return myDataTbl.FindBycode(code);
        }
        protected override object MakeItem(string value)
        {
            stockCodeRow = dataLibs.FindAndCache(myCompamyTbl, value);
            if (stockCodeRow == null) return new common.myComboBoxItem(value, value);
            return new common.myComboBoxItem(value + " - " + (stockCodeRow.IsnameEnNull()?"":stockCodeRow.nameEn), value);
        }
    }
    public class clbBizSector : baseCheckedLB
    {
        private data.baseDS.bizSubSectorDataTable bizSubSectorTbl = new data.baseDS.bizSubSectorDataTable();
        public clbBizSector() { }
        public override void LoadData()
        {
            LoadData(false);
        }
        public void LoadData(bool checkedAll)
        {
            bizSubSectorTbl.Clear();
            dataLibs.LoadData(bizSubSectorTbl);
            for (int idx = 0; idx < bizSubSectorTbl.Count; idx++)
                this.Items.Add(new common.myComboBoxItem(bizSubSectorTbl[idx].description1.Trim(), bizSubSectorTbl[idx].code.Trim()), checkedAll);
            SaveItems();
        }
        protected override object MakeItem(string value)
        {
            data.baseDS.bizSubSectorRow bizSubSectorRow;
            bizSubSectorRow = dataLibs.FindAndCache(bizSubSectorTbl, value);
            string tmp = value + (bizSubSectorRow == null ? "" : " - " + bizSubSectorRow.description1);
            return new common.myComboBoxItem(tmp, value.Trim());
        }
    }
    public class clbBizSubSector : baseCheckedLB
    {
        private data.baseDS.bizSubSectorDataTable mySubSectorTbl = new data.baseDS.bizSubSectorDataTable();
        private data.baseDS.bizSubSectorRow subSectorRow;
        public clbBizSubSector() { }
        protected override object MakeItem(string value)
        {
            subSectorRow = dataLibs.FindAndCache(mySubSectorTbl, value);
            if (subSectorRow == null) return new common.myComboBoxItem(value, value);
            return new common.myComboBoxItem(value + " - " + subSectorRow.description1, value);
        }
    }
    public class clbBizSupperSector : baseCheckedLB
    {
        private data.baseDS.bizSuperSectorDataTable dataTbl = new data.baseDS.bizSuperSectorDataTable();
        public clbBizSupperSector() { }
        public override void LoadData()
        {
            LoadData(false);
        }
        public void LoadData(bool checkedAll)
        {
            dataTbl.Clear();
            dataLibs.LoadData(dataTbl);
            for (int idx = 0; idx < dataTbl.Count; idx++)
                this.Items.Add(new common.myComboBoxItem(dataTbl[idx].description1.Trim(), dataTbl[idx].code.Trim()), checkedAll);
            SaveItems();
        }
        public data.baseDS.bizSuperSectorRow GetRow(string code)
        {
            return dataTbl.FindBycode(code);
        }
    }
    public class clbBizIndustry : baseCheckedLB
    {
        private data.baseDS.bizIndustryDataTable dataTbl = new data.baseDS.bizIndustryDataTable();
        public clbBizIndustry() { }
        public override void LoadData()
        {
            LoadData(false);
        }
        public void LoadData(bool checkedAll)
        {
            dataTbl.Clear();
            dataLibs.LoadData(dataTbl);
            for (int idx = 0; idx < dataTbl.Count; idx++)
                this.Items.Add(new common.myComboBoxItem(dataTbl[idx].description1.Trim(), dataTbl[idx].code.Trim()), checkedAll);
            SaveItems();
        }
        public data.baseDS.bizIndustryRow GetRow(string code)
        {
            return dataTbl.FindBycode(code);
        }
    }
    #endregion Checked Listbox

    #region Listbox
    public class lbStockCode : baseListBox 
    {
        private data.baseDS.stockCodeDataTable myCompamyTbl = new data.baseDS.stockCodeDataTable();
        private data.baseDS.stockCodeRow stockCodeRow;
        public lbStockCode() { }
        public override void LoadData() { }
        protected override object MakeItem(string value)
        {
            stockCodeRow = dataLibs.FindAndCache(myCompamyTbl,value);
            if (stockCodeRow == null) return new common.myComboBoxItem(value, value);
            return new common.myComboBoxItem(value + " - " + (stockCodeRow.IsnameEnNull()?"":stockCodeRow.nameEn), value);
        }
    }
    public class lbSubSectorCode : baseListBox
    {
        private data.baseDS.bizSubSectorDataTable mySubSectorTbl = new data.baseDS.bizSubSectorDataTable();
        private data.baseDS.bizSubSectorRow subSectorRow;
        public lbSubSectorCode() { }
        public override void LoadData() { }
        protected override object MakeItem(string value)
        {
            subSectorRow = dataLibs.FindAndCache(mySubSectorTbl, value);
            if (subSectorRow == null) return new common.myComboBoxItem(value, value);
            return new common.myComboBoxItem(value + " - " + subSectorRow.description1, value);
        }
    }
    #endregion Listbox

    #region textBox
    public class txtDate : common.controls.baseDate 
    {
        public txtDate()
        {
            this.BackColor = common.settings.sysColorNormalBG;
            this.ForeColor = common.settings.sysColorNormalFG;
        }
    }
    
    public class txtStockCode : common.controls.baseTextBox
    {
        public txtStockCode()
        {
            this.BackColor = common.settings.sysColorNormalBG;
            this.ForeColor = common.settings.sysColorNormalFG;
            this.isToUpperCase = true;
            this.myOnFind += new onFind(DoFind);
        }
        public data.baseDS.stockCodeRow GetData()
        {
            return dataLibs.GetStockData(this.Text);
        }
        private void DoFind(object sender)
        {
            forms.companyFind form = forms.companyFind.GetForm("");
            form.Find(this.Text);
            data.baseDS.stockCodeRow row = form.selectedDataRow;
            if (row == null) return;
            this.Text = row.tickerCode;
            return;
        }
    }

    #endregion

    #region other
    public class baseLabel : System.Windows.Forms.Label
    {
        public baseLabel()
        {
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
    public class baseButton : System.Windows.Forms.Button
    {
        public baseButton()
        {
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
    public class baseCheckBox : System.Windows.Forms.CheckBox
    {
        public baseCheckBox()
        {
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
    #endregion other
}
