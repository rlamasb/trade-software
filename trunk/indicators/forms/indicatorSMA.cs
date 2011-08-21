﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using application;

namespace indicators.forms
{
    public partial class indicatorSMA : baseIndicator 
    {
        public indicatorSMA()
        {
            InitializeComponent();
        }
        private double[] paras
        {
            get { return new double[] { (int)paraEd1.Value, (int)paraEd2.Value }; }
            set
            {
                if (value.Length < 2) return;
                paraEd1.Value = (int)value[0];
                paraEd2.Value = (int)value[1];
            }
        }
        private Color[] colors
        {
            get { return new Color[] { mainColorEd.Color, color2Ed.Color }; }
            set 
            {  
                if(value.Length>0) mainColorEd.Color = value[0];
                if(value.Length>1) color2Ed.Color = value[1];
            }
        }
        
        private LineItem[] lineCurves = new LineItem[0];

        public override void Init()
        {
            base.Init();
            color2Ed.LoadColors();
            color2Ed.Color = color2Ed.GetNextColor(mainColorEd.Color);
        }
        protected override indicatorData[] MakeIndicator(data.baseDS dataSet)
        {
            indicatorData data = new indicatorData();
            data.values0 = stockLibs.MakeDataList(dataSet.priceData, 0, stockLibs.stockDataField.Close);
            int begin = 0, length = 0;
            indicatorData[] outPut = new indicatorData[paras.Length];
            for (int idx = 0; idx < paras.Length; idx++)
            {
                if ((int)paras[idx] > 0)
                {
                    double[] outVals = new double[data.values0.Length];
                    application.stockLibs.MakeMovingAverage(myTypes.indicatorType.SMA, 0, data.values0.Length - 1, data.values0, (int)paras[idx],
                                                            out begin, out length, outVals);
                    data.values1 = stockLibs.MakeDataList(this.myParentForm.myDataSet.priceData, begin, stockLibs.stockDataField.OnDate);
                    outPut[idx] = new indicatorData(0, length - 1, outVals, data.values1);
                }
                else outPut[idx] = null;
            }
            return outPut;
        }
        protected override void RemoveChart()
        {

            for (int idx = 0; idx < lineCurves.Length; idx++)
            {
                if (lineCurves[idx] == null) continue;
                workGraphPane.RemoveCurve(lineCurves[idx]);
                mainGraphPane.RemoveCurve(lineCurves[idx]);
            }
            mainGraphPane.PlotGraph();
            workGraphPane.PlotGraph();
        }
        protected override void PlotChart(PointPairList[] dataList)
        {
            if (lineCurves.Length < dataList.Length) Array.Resize(ref lineCurves, dataList.Length);
            for (int idx = 0; idx < dataList.Length; idx++)
            {
                if (dataList[idx] != null)
                    lineCurves[idx] = workGraphPane.AddLineChart(dataList[idx], "SMA" + this.paras[idx].ToString(), SymbolType.None, this.colors[idx], (int)curveWeightEd.Value);
                else lineCurves[idx] = null;
            }
        }
    }
}
