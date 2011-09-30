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

namespace Indicators.forms
{
    public partial class Bop : baseIndicatorForm
    {
        public Bop(Type indicatorType)
            : base(indicatorType)
        {
            InitializeComponent();
            colorEd1.LoadColors();
            this.colorEd1.Color = Color.Blue;
        }
        public override IndicatorFormInfo Info
        {
            get
            {
                IndicatorFormInfo info = new IndicatorFormInfo();
                info.chartType = AppTypes.ChartTypes.Line;
                info.paras = new int[] { };
                info.color = new Color[] { colorEd1.Color };
                info.weight = (byte)weightEd1.Value;
                info.inNewWindows = inNewPaneChk.Checked;

                return info;
            }
            set
            {
                inNewPaneChk.Checked = value.inNewWindows;
                colorEd1.Color = value.color[0];
                weightEd1.Value = value.weight;
            }
        }
    }
}