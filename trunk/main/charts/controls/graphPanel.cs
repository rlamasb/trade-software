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
        public myGraphControl myGraphObj = new myGraphControl();
       
        public baseGraphPanel()
        {
            this.haveCloseButton = true;
            this.Controls.Add(myGraphObj);

            myGraphObj.Location = new Point(0, -25);
            
            myGraphObj.GraphPane.XAxis.Scale.FontSpec.Family = myGraphObj.Font.FontFamily.Name;
            myGraphObj.GraphPane.XAxis.Scale.FontSpec.Size = myGraphObj.Font.Size;

            myGraphObj.GraphPane.YAxis.Scale.FontSpec.Family = myGraphObj.Font.FontFamily.Name;
            myGraphObj.GraphPane.YAxis.Scale.FontSpec.Size = myGraphObj.Font.Size;
        }
        
        public void ResetGraph()
        {
            myGraphObj.DefaultViewport();
        }

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
            myGraphObj.CalcGraphSize();
            base.OnResize(e);
        }
        #endregion override functions
    }

}