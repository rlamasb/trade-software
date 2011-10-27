using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace Charts.Controls
{
    public partial class baseGraphPanel : common.controls.basePanel
    {
        public delegate string OnPointValue(CurveItem curve, int iPt);
        public event OnPointValue onPointValueEvent = null;

        public myGraphControl myGraphObj = new myGraphControl();

        private string GraphObj_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            if (onPointValueEvent != null) return onPointValueEvent(curve, iPt); 
            return "";
        }

        public baseGraphPanel()
        {
            this.haveCloseButton = true;
            this.myGraphObj.PointValueEvent += new ZedGraphControl.PointValueHandler(GraphObj_PointValueEvent);
            

            this.Controls.Add(myGraphObj);

            myGraphObj.Location = new Point(0, -25);
            
            myGraphObj.GraphPane.XAxis.Scale.FontSpec.Family = myGraphObj.Font.FontFamily.Name;
            myGraphObj.GraphPane.XAxis.Scale.FontSpec.Size = myGraphObj.Font.Size;

            myGraphObj.GraphPane.YAxis.Scale.FontSpec.Family = myGraphObj.Font.FontFamily.Name;
            myGraphObj.GraphPane.YAxis.Scale.FontSpec.Size = myGraphObj.Font.Size;

            //SetXAxisType(typeof(DateTime),true);
            //SetYAxisType(typeof(double),false);
        }
        
        public void ResetGraph()
        {
            myGraphObj.DefaultViewport();
        }

        //public void SetYAxisType(Type type, bool asOrdinal)
        //{
        //    if (type == typeof(DateTime))
        //    {
        //        myGraphObj.myGraphPane.YAxis.Type = (asOrdinal ? AxisType.DateAsOrdinal : AxisType.Date);
        //    }
        //    else
        //    {
        //        myGraphObj.myGraphPane.YAxis.Type = (asOrdinal ? AxisType.LinearAsOrdinal : AxisType.Linear);
        //    }
        //}

        public void PlotGraph()
        {
            // Tell ZedGraph to calculate the axis ranges
            myGraphObj.AxisChange();
            myGraphObj.Invalidate();
        }
        public void RemoveAllCurves()
        {
            while (myGraphObj.myGraphPane.CurveList.Count > 0)
                myGraphObj.myGraphPane.CurveList.Remove(myGraphObj.myGraphPane.CurveList[0]);
        }
        public void RemoveCurve(CurveItem item)
        {
            myGraphObj.myGraphPane.CurveList.Remove(item);
        }
        #region override functions
        protected override void OnResize(EventArgs e)
        {
            myGraphObj.Location = new Point(0, 0);
            myGraphObj.Size = new Size(this.Width, this.Height);
            base.OnResize(e);
        }
        #endregion override functions
    }

}