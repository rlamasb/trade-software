using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace baseClass.forms
{
    public partial class chartProperties : baseDialogForm  
    {
        public chartProperties()
        {
            try
            {
                InitializeComponent();
                this.myOnProcess += new onProcess(ProcessHandler);  
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        public static chartProperties GetForm(string formName)
        {
            string cacheKey = typeof(chartProperties).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            chartProperties form = (chartProperties)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new chartProperties();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }

        protected override bool LoadConfigure()
        {
            bgColorCb.Color = application.Settings.sysChartBgColor;
            fgColorCb.Color = application.Settings.sysChartFgColor;
            gridColorCb.Color = application.Settings.sysChartGridColor;

            volumesColorCb.Color = application.Settings.sysChartVolumesColor;
            lineCandleColorCb.Color = application.Settings.sysChartLineCandleColor;
            bearCandleColorCb.Color = application.Settings.sysChartBearCandleColor;
            bullCandleColorCb.Color = application.Settings.sysChartBullCandleColor;
            barDnColorCb.Color = application.Settings.sysChartBarDnColor;
            barUpColorCb.Color = application.Settings.sysChartBarUpColor;

            showDescriptionChk.Checked = application.Settings.sysChartShowDescription;
            showVolumeChk.Checked = application.Settings.sysChartShowVolume;
            showGridChk.Checked = application.Settings.sysChartShowGrid;
            showLegendChk.Checked = application.Settings.sysChartShowLegend;

            scaleMetricChk.Checked = application.Settings.sysChartAutoScaleMetric;
            panMetricChk.Checked = application.Settings.sysChartAutoPanMetric;
            yScaleEd.Value = application.Settings.sysChartYScaleMetric;
            xScaleEd.Value = application.Settings.sysChartXScaleMetric;
            yPanEd.Value = application.Settings.sysChartXPanMetric;
            xPanEd.Value = application.Settings.sysChartYPanMetric;
            return true;
        }
        protected override bool SaveConfigure()
        {
            application.Settings.sysChartBgColor = bgColorCb.Color;
            application.Settings.sysChartFgColor = fgColorCb.Color;
            application.Settings.sysChartGridColor = gridColorCb.Color;

            application.Settings.sysChartVolumesColor = volumesColorCb.Color;
            application.Settings.sysChartLineCandleColor = lineCandleColorCb.Color;
            application.Settings.sysChartBearCandleColor = bearCandleColorCb.Color;
            application.Settings.sysChartBullCandleColor = bullCandleColorCb.Color;
            application.Settings.sysChartBarDnColor = barDnColorCb.Color;
            application.Settings.sysChartBarUpColor = barUpColorCb.Color;

            application.Settings.sysChartShowDescription = showDescriptionChk.Checked;
            application.Settings.sysChartShowVolume = showVolumeChk.Checked;
            application.Settings.sysChartShowGrid = showGridChk.Checked;
            application.Settings.sysChartShowLegend = showLegendChk.Checked;

            application.Settings.sysChartAutoScaleMetric = scaleMetricChk.Checked;
            application.Settings.sysChartAutoPanMetric = panMetricChk.Checked;
            application.Settings.sysChartYScaleMetric = yScaleEd.Value;
            application.Settings.sysChartXScaleMetric = xScaleEd.Value;
            application.Settings.sysChartXPanMetric = yPanEd.Value;
            application.Settings.sysChartYPanMetric = xPanEd.Value;
            application.configuration.Save_Sys_Settings_CHART();
            return true;
        }

        protected override bool BeforeAcceptProcess()
        {
            bool retVal = true;
            ClearNotifyError();
            return retVal;
        }
        private void ProcessHandler(object sender,common.baseDialogEvent e)
        {
            if (e.isCloseClick) return;
            myFormStatus.acceptClose = true;
            SaveConfigure();
        }

        private void scaleMetricChk_CheckedChanged(object sender, EventArgs e)
        {
            xScaleEd.Enabled = scaleMetricChk.Checked;
            yScaleEd.Enabled = scaleMetricChk.Checked;
        }

        private void panMetricChk_CheckedChanged(object sender, EventArgs e)
        {
            xPanEd.Enabled = panMetricChk.Checked;
            yPanEd.Enabled = panMetricChk.Checked;
        }
    }    
}