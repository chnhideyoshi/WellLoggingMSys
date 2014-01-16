using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoggingDataManager.RTL
{
    public partial class GraphEditor : UserControl
    {
        public GraphEditor()
        {
            InitializeComponent();
        }
        public void SetCurve(Model.Curve curve)
        {
            #region Test
            Data.CurveData data = Data.CurveData.CreateSample();
            Editor.SetCurve(curve,data);
            Editor.VerticalCellsCount = 20;
            Editor.UnitLength = 5;
            Editor.HorizontalCellsCount = 6;
            #endregion
        }
        public WPFGraph.CurveEditor Editor
        {
            get { return elementHost1.Child as WPFGraph.CurveEditor; }
        }
    }
}
