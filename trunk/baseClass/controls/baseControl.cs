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
    public class formContainer : common.control.baseContainer
    {
        public override void ArrangeChildren()
        {
            switch(this.myArrangeOptions)
            {
                case common.control.childArrangeOptions.Casscade: Arrange_Casscade(); break;
                case common.control.childArrangeOptions.Tiled: Arrange_Tiled(); break;
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
    public class graphPaneContainer : common.control.baseContainer
    {
        public override void ArrangeChildren()
        {
            if (this.ChildCount <= 0) return;
            graphPane myPane;
            int totalWeight = 0, totalHeight = this.ClientRectangle.Height-1;
            for (int idx = 0; idx < this.ChildCount; idx++)
            {
                myPane = (graphPane)this.GetChild(idx);
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
                myPane = (graphPane)this.GetChild(idx);
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
    public class graphPane : common.control.baseGraphPane
    {
        private bool fResizing = false;
        public graphPaneContainer myContainer = null;
        public JapaneseCandleStickItem AddCandleStickChart(data.baseDS.priceDataDataTable data, string title, Color color, Color stickColor, Color fallingColor)
        {
            return application.chart.PlotChartCandleStick(myGraphPane, data, title, color, stickColor, fallingColor);
        }

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
    public class baseCheckedLB : common.control.baseCheckedListBox
    {
        public baseCheckedLB() { }
        protected override string GetItemValue(object obj)
        {
            return ((common.myComboBoxItem)obj).Value;
        }
    }
    public class baseListBox : common.control.baseListBox
    {
        public baseListBox() { }
        protected override string GetItemValue(object obj)
        {
            return ((common.myComboBoxItem)obj).Value;
        }
    }
    #endregion 

    #region comboBox
    public class cbStrategyType : common.control.baseComboBox
    {
        public cbStrategyType()
        {
        }
        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (myTypes.strategyType item in Enum.GetValues(typeof(myTypes.strategyType)))
            {
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(myTypes.strategyType[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual myTypes.strategyType myValue
        {
            get
            {
                if (this.SelectedItem == null) return myTypes.strategyType.Strategy;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (myTypes.strategyType item in Enum.GetValues(typeof(myTypes.strategyType)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return myTypes.strategyType.Strategy;
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
                this.myValue = myTypes.strategyType.Strategy;
                foreach (myTypes.strategyType item in Enum.GetValues(typeof(myTypes.strategyType)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbPortfolioType : common.control.baseComboBox
    {
        public cbPortfolioType()
        {
        }
        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (myTypes.portfolioType item in Enum.GetValues(typeof(myTypes.portfolioType)))
            {
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(myTypes.portfolioType[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual myTypes.portfolioType myValue
        {
            get
            {
                if (this.SelectedItem == null) return myTypes.portfolioType.WatchList;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (myTypes.portfolioType item in Enum.GetValues(typeof(myTypes.portfolioType)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return myTypes.portfolioType.WatchList;
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
                this.myValue = myTypes.portfolioType.WatchList;
                foreach (myTypes.portfolioType item in Enum.GetValues(typeof(myTypes.portfolioType)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbTimeRange : common.control.baseComboBox
    {
        public cbTimeRange()
        {
        }
        public override void LoadData()
        {
            this.Items.Clear();
            foreach (myTypes.timeRanges item in Enum.GetValues(typeof(myTypes.timeRanges)))
            {
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual myTypes.timeRanges myValue
        {
            get
            {
                if (this.SelectedItem == null) return myTypes.timeRanges.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (myTypes.timeRanges item in Enum.GetValues(typeof(myTypes.timeRanges)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return myTypes.timeRanges.None;
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
                this.myValue = myTypes.timeRanges.None;
                foreach (myTypes.timeRanges item in Enum.GetValues(typeof(myTypes.timeRanges)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbTimeScale : common.control.baseComboBox
    {
        public cbTimeScale()
        {
        }
        public override void LoadData()
        {
            LoadData(true);
        }
        public void LoadData(bool excludeNONE)
        {
            myTypes.timeScales[] list = new myTypes.timeScales[0];
            foreach (myTypes.timeScales item in Enum.GetValues(typeof(myTypes.timeScales)))
            {
                if (excludeNONE && (item == myTypes.timeScales.None)) continue;
                Array.Resize(ref list, list.Length + 1);
                list[list.Length - 1] = item;
            }
            LoadList(list);
        }
        public void LoadList(myTypes.timeScales[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual myTypes.timeScales myValue
        {
            get
            {
                if (this.SelectedItem == null) return myTypes.timeScales.RealTime;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (myTypes.timeScales item in Enum.GetValues(typeof(myTypes.timeScales)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return myTypes.timeScales.RealTime; 
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
                this.myValue = myTypes.timeScales.RealTime;
                foreach (myTypes.timeScales item in Enum.GetValues(typeof(myTypes.timeScales)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbTradeAction : common.control.baseComboBox
    {
        public cbTradeAction()
        {
        }
        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (analysis.tradeActions item in Enum.GetValues(typeof(analysis.tradeActions)))
            {
                if (!allItem && item == analysis.tradeActions.None) continue;
                this.Items.Add(new common.myComboBoxItem(item.ToString(), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(analysis.tradeActions[] list)
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

        public new virtual analysis.tradeActions myValue
        {
            get
            {
                if (this.SelectedItem == null) return analysis.tradeActions.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (analysis.tradeActions item in Enum.GetValues(typeof(analysis.tradeActions)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return analysis.tradeActions.None;
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
                this.myValue = analysis.tradeActions.None;
                foreach (analysis.tradeActions item in Enum.GetValues(typeof(analysis.tradeActions)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbBizSectorType : common.control.baseComboBox
    {
        public cbBizSectorType()
        {
        }
        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (myTypes.bizSectorType item in Enum.GetValues(typeof(myTypes.bizSectorType)))
            {
                if (!allItem && item == myTypes.bizSectorType.None) continue;
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(myTypes.bizSectorType[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual myTypes.bizSectorType myValue
        {
            get
            {
                if (this.SelectedItem == null) return myTypes.bizSectorType.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (myTypes.bizSectorType item in Enum.GetValues(typeof(myTypes.commonStatus)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return myTypes.bizSectorType.None;
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
                this.myValue = myTypes.bizSectorType.None;
                foreach (myTypes.bizSectorType item in Enum.GetValues(typeof(myTypes.bizSectorType)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbChartType : common.control.baseComboBox
    {
        public cbChartType()
        {
        }
        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem )
        {
            this.Items.Clear();
            foreach (myTypes.chartType item in Enum.GetValues(typeof(myTypes.chartType)))
            {
                if (!allItem && item== myTypes.chartType.None) continue;
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(myTypes.chartType[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual myTypes.chartType myValue
        {
            get
            {
                if (this.SelectedItem == null) return myTypes.chartType.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (myTypes.chartType item in Enum.GetValues(typeof(myTypes.commonStatus)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return myTypes.chartType.None;
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
                this.myValue = myTypes.chartType.None;
                foreach (myTypes.chartType item in Enum.GetValues(typeof(myTypes.chartType)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbCommonStatus : common.control.baseComboBox
    {
        public cbCommonStatus()
        {
        }
        public override void LoadData() { LoadData(false); }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (myTypes.commonStatus item in Enum.GetValues(typeof(myTypes.commonStatus)))
            {
                if (!allItem && item == myTypes.commonStatus.None) continue;
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public void LoadList(myTypes.commonStatus[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual myTypes.commonStatus myValue
        {
            get
            {
                if (this.SelectedItem == null) return myTypes.commonStatus.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (myTypes.commonStatus item in Enum.GetValues(typeof(myTypes.commonStatus)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return myTypes.commonStatus.None;
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
                this.myValue = myTypes.commonStatus.None;
                foreach (myTypes.commonStatus item in Enum.GetValues(typeof(myTypes.commonStatus)))
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
            LoadList(new myTypes.commonStatus[] { myTypes.commonStatus.New, myTypes.commonStatus.Ignore, myTypes.commonStatus.Close});
        }
    }
    public class cbStockStatus : cbCommonStatus
    {
        public cbStockStatus()
        {
        }
        public override void LoadData()
        {
            LoadList(new myTypes.commonStatus[] { myTypes.commonStatus.Enable, myTypes.commonStatus.Disable});
        }
    }

    public class cbSysCodeCat : common.control.baseComboBox
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
    public class cbCurrency : common.control.baseComboBox
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
    public class cbCountry : common.control.baseComboBox
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
    public class cbIndicatorCat : common.control.baseComboBox
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
    public class cbInvestorCat : common.control.baseComboBox
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
    public class cbStrategyCat : common.control.baseComboBox
    {
        public cbStrategyCat()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
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
    public class cbEmployeeRange : common.control.baseComboBox
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
    public class cbStockExchange : common.control.baseComboBox
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
    public class cbPorpolio : common.control.baseComboBox
    {
        public cbPorpolio()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            LoadData(application.sysLibs.sysLoginCode,false);
        }
        public virtual void LoadData(string investorCode,bool AddAllItem)
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
            dataLibs.LoadPortfolioByInvestor(tbl,investorCode);
            this.DisplayMember = tbl.nameColumn.ColumnName;
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
                if(tbl[idx].code == Settings.sysString_All_Code) continue;
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
    public class cbSex : common.control.baseComboBox
    {
        public cbSex()
        {
        }
        public void LoadData(bool allItem)
        {
            this.Items.Clear();
            foreach (myTypes.sex item in Enum.GetValues(typeof(myTypes.sex)))
            {
                if (!allItem && item == myTypes.sex.None) continue;
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(item), item.ToString()));
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
        public override void LoadData() { LoadData(false);}
        public void LoadList(myTypes.sex[] list)
        {
            if (list == null)
            {
                LoadData();
                return;
            }
            this.Items.Clear();
            for (int idx = 0; idx < list.Length; idx++)
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(list[idx]), list[idx].ToString()));
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        public new virtual myTypes.sex myValue
        {
            get
            {
                if (this.SelectedItem == null) return myTypes.sex.None;
                common.myComboBoxItem selectedItem = (common.myComboBoxItem)this.SelectedItem;
                foreach (myTypes.sex item in Enum.GetValues(typeof(myTypes.sex)))
                {
                    if (item.ToString() == selectedItem.Value) return item;
                }
                return myTypes.sex.None;
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
                this.myValue = myTypes.sex.None;
                foreach (myTypes.sex item in Enum.GetValues(typeof(myTypes.sex)))
                {
                    if ((byte)item != value) continue;
                    this.myValue = item;
                    break;
                }
            }
        }
    }
    public class cbStrategy : common.control.baseComboBox
    {
        public cbStrategy()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public override void LoadData()
        {
            data.baseDS.strategyDataTable tbl = new data.baseDS.strategyDataTable();
            dataLibs.LoadData(tbl,true);
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public void LoadData(myTypes.strategyType typeMask, bool onlyEnableData)
        {
            data.baseDS.strategyDataTable tbl = new data.baseDS.strategyDataTable();
            dataLibs.LoadData(tbl, typeMask, onlyEnableData);
            this.DisplayMember = tbl.descriptionColumn.ColumnName;
            this.ValueMember = tbl.codeColumn.ColumnName;
            this.DataSource = tbl;
            if (tbl.Count > 0) this.MaxDropDownItems = tbl.Count;
        }
        public data.baseDS.strategyRow GetDataInfo()
        {
            return this.GetDataInfo(this.myValue);
        }
        public data.baseDS.strategyRow GetDataInfo(string code)
        {
            data.baseDS.strategyDataTable dataTbl = (data.baseDS.strategyDataTable)this.DataSource;
            return dataTbl.FindBycode(code);
        }
    }

    #endregion

    #region Checked Listbox
    public class clbTimeScale : baseCheckedLB
    {
        public clbTimeScale() { }
        public override void LoadData()
        {
            LoadData(true);
        }
        public void LoadData(bool excludeNONE)
        {
            foreach (myTypes.timeScales item in Enum.GetValues(typeof(myTypes.timeScales)))
            {
                if (excludeNONE && item == myTypes.timeScales.None) continue;
                this.Items.Add(new common.myComboBoxItem(myTypes.Type2Text(item), ((byte)item).ToString()));
            }
            SaveItems();
        }
    }

    public class clbIndicator : baseCheckedLB
    {
        private data.baseDS.indicatorDataTable dataTbl = new data.baseDS.indicatorDataTable();
        public clbIndicator() 
        {
        }
        public override void LoadData()
        {
            LoadData(true);
        }
        public void LoadData(bool onlyEnableItem)
        {
            dataTbl.Clear();
            dataLibs.LoadData(dataTbl, onlyEnableItem);
            for (int idx = 0; idx < dataTbl.Count; idx++)
                this.Items.Add(new common.myComboBoxItem(dataTbl[idx].description.Trim(), dataTbl[idx].code.Trim()), false);
            SaveItems();
        }
        public data.baseDS.indicatorRow GetRow(string code)
        {
            return dataTbl.FindBycode(code);
        }
    }
    public class clbStrategy : baseCheckedLB
    {
        private data.baseDS.strategyDataTable dataTbl = new data.baseDS.strategyDataTable();
        public clbStrategy() { }
        public override void LoadData()
        {
            dataTbl.Clear();
            dataLibs.LoadData(dataTbl, true);
            for (int idx = 0; idx < dataTbl.Count; idx++)
                this.Items.Add(new common.myComboBoxItem(dataTbl[idx].description.Trim(), dataTbl[idx].code.Trim()), false);
            SaveItems();
        }
        public void LoadData(myTypes.strategyType typeMask,bool onlyEnableItems,  bool checkedAll)
        {
            dataTbl.Clear();
            dataLibs.LoadData(dataTbl,typeMask,onlyEnableItems);
            for (int idx = 0; idx < dataTbl.Count; idx++)
                this.Items.Add(new common.myComboBoxItem(dataTbl[idx].description.Trim(), dataTbl[idx].code.Trim()), checkedAll);
            SaveItems();
        }
        public void SetFilter(string catCode)
        {
            this.Items.Clear();
            if (catCode!=null) catCode = catCode.Trim();
            for (int idx = 0; idx < dataTbl.Count; idx++)
            {
                if (catCode!=null  && dataTbl[idx].catCode.Trim()!= catCode) continue; 
                this.Items.Add(new common.myComboBoxItem(dataTbl[idx].description.Trim(), dataTbl[idx].code.Trim()), false);
            }
            SaveItems();
        }
        public data.baseDS.strategyRow GetRow(string code)
        {
            return dataTbl.FindBycode(code);
        }
    }
    public class clbStockCode : baseCheckedLB
    {
        private data.baseDS.companyRow companyRow;
        private data.baseDS.companyDataTable myCompamyTbl = new data.baseDS.companyDataTable();
        private data.baseDS.stockCodeExtDataTable _myDataTbl = null;
        public clbStockCode() { }
        public data.baseDS.stockCodeExtDataTable myDataTbl
        {
            get { return _myDataTbl; }
            set
            {
                this.Items.Clear();
                this._myDataTbl = value;
                if (_myDataTbl == null) return;
                string tmp;
                data.baseDS.companyRow companyRow;
                for (int idx = 0; idx < value.Count; idx++)
                {
                    companyRow = dataLibs.FindAndCache(myCompamyTbl, value[idx].comCode);
                    tmp = value[idx].tickerCode.Trim() + (companyRow == null ? "" : " - " + companyRow.name);
                    this.Items.Add(new common.myComboBoxItem(tmp, value[idx].code.Trim()), false);
                }
                this.SaveItems();
            }
        }

        public override void LoadData()
        {
            data.baseDS.stockCodeExtDataTable dataTbl = new data.baseDS.stockCodeExtDataTable();
            dataTbl.Clear();
            dataLibs.LoadData(dataTbl,(byte)application.myTypes.commonStatus.Enable);
            this.myDataTbl = dataTbl;
            return;
        }
        public void LoadDataByBizSector(StringCollection list)
        {
            data.baseDS.stockCodeExtDataTable dataTbl = new data.baseDS.stockCodeExtDataTable();
            dataTbl.Clear();
            dataLibs.LoadStockCode_ByBizSectors(dataTbl,list);
            this.myDataTbl = dataTbl;
        }
        public data.baseDS.stockCodeExtRow GetRow(string code)
        {
            return myDataTbl.FindBycode(code);
        }
        protected override object MakeItem(string value)
        {
            companyRow = dataLibs.FindAndCache(myCompamyTbl, value);
            if (companyRow == null) return new common.myComboBoxItem(value, value);
            return new common.myComboBoxItem(value + " - " + companyRow.name, value);
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
        private data.baseDS.companyDataTable myCompamyTbl = new data.baseDS.companyDataTable();
        private data.baseDS.companyRow companyRow;
        public lbStockCode() { }
        public override void LoadData() { }
        protected override object MakeItem(string value)
        {
            companyRow = dataLibs.FindAndCache(myCompamyTbl,value);
            if (companyRow == null) return new common.myComboBoxItem(value, value);
            return new common.myComboBoxItem(value + " - " + companyRow.name, value);
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
    public class txtDate : common.control.baseDate 
    {
        public txtDate()
        {
            this.BackColor = common.settings.sysColorNormalBG;
            this.ForeColor = common.settings.sysColorNormalFG;
        }
    }
    public class txtCompanyCode : common.control.baseTextBox
    {
        public txtCompanyCode()
        {
            this.BackColor = common.settings.sysColorNormalBG;
            this.ForeColor = common.settings.sysColorNormalFG;
            this.isToUpperCase = true;
            this.myOnFind += new onFind(DoFind);
        }
        private void DoFind(object sender)
        {
            interfaces.myCompanyFind.Find(this.Text);
            data.baseDS.companyRow row = interfaces.myCompanyFind.selectedDataRow;
            if (row == null) return;
            this.Text = row.code;
            return;
        }
    }
    public class txtStockCode : common.control.baseTextBox
    {
        public txtStockCode()
        {
            this.BackColor = common.settings.sysColorNormalBG;
            this.ForeColor = common.settings.sysColorNormalFG;
            this.isToUpperCase = true;
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
