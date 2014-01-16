using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoggingDataManager.WPFGraph
{
    /// <summary>
    /// Interaction logic for Graph.xaml
    /// </summary>
    public partial class Graph : UserControl, IGraph
    {
        public Graph()
        {
            this.InitializeComponent();
            Init();
        }

        private void Init()
        {
            UC_Dp.DepthBaseValue = 0;
            UC_Dp.DepthDeltaValue = MaxUnitLength;
            this.Loaded += (sender, e) => { RepaintAll(); };
            SL_Main.ValueChanged += (sender, e) => 
            {
                double perc=SL_Main.Value/SL_Main.Maximum;
                this.CurrentDepth = perc * (XRange);
                TB_dEPTH.Text = string.Format("当前深度:{0}",CurrentDepth.ToString("0.00"));
            };
            CKB_AutoScroll.Click += (sender, e) => 
            {
                SL_Main.IsEnabled = (CKB_AutoScroll.IsChecked == true);
            };
            CKB_ShowLine.Click += (sender, e) =>
            {
                ShowGridLine = CKB_ShowLine.IsChecked == true;
            };
        }

        public void AddCurve(Model.Curve curve, Data.CurveData data, int index)
        {
            curveList.Add(curve);
            #region pt
            ParaTable pt = new ParaTable();
            pt.Tag = curve.Id;
            pt.SetCurve(curve);
            #endregion
            #region dp
            UC_Dp.DepthBaseValue = CurveXMinValue;
            UC_Dp.DepthDeltaValue = MaxUnitLength;
            #endregion
            CurveViewManager manager = CreateManager(curve, data, this);
            #region index
            switch (index)
            {
                case 0:
                    {
                        STK_CurveGroupContainer1.Children.Add(pt);
                        UC_Gm1.AddShape(curve, manager);
                    } break;
                case 1:
                    {
                        STK_CurveGroupContainer2.Children.Add(pt);
                        UC_Gm2.AddShape(curve, manager);
                    } break;
                case 2:
                    {
                        STK_CurveGroupContainer3.Children.Add(pt);
                        UC_Gm3.AddShape(curve, manager);
                    } break;
                default: { throw new Exception(); };
            }
            #endregion
        }
        public void RemoveCurve(Guid id)
        {

        }
        public void Repaint(Guid id)
        {
            tableOfCurveManager[id].RePaint();
        }
        public void RepaintAll()
        {
            Dictionary<Guid, CurveViewManager>.Enumerator enumerator = tableOfCurveManager.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Value.RePaint();
            }
        }

        public double CurrentDepth
        {
            set
            {
                currentDepth = value;
                UC_Dp.VerticalOffsetPecentage = (value - CurveXMinValue) / XPresentRange;
                UC_Gm1.VerticalOffsetPecentage = (value - CurveXMinValue) / XPresentRange;
                UC_Gm2.VerticalOffsetPecentage = (value - CurveXMinValue) / XPresentRange;
                UC_Gm3.VerticalOffsetPecentage = (value - CurveXMinValue) / XPresentRange;
                Dictionary<Guid, CurveViewManager>.Enumerator enumerator = tableOfCurveManager.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Value.BaseOffsetPercentage = value / enumerator.Current.Value.XRange;
                    enumerator.Current.Value.RePaint();
                }
            }
            get { return currentDepth; }
        }
        public double UnitLength
        {
            get { return unitLength; }
            set
            {
                if (value != 0)
                {
                    unitLength = value;
                    UC_Dp.DepthDeltaValue = value;
                }
            }
        }
        public double MaxUnitLength { get { return XRange / VerticalCellsCount; } }
        public int VerticalCellsCount
        {
            get { return verticalCellsCount; }
            set
            {
                if (value != 0)
                {
                    verticalCellsCount = value;
                    UC_Gm1.VerticalCellsCount = value;
                    UC_Gm2.VerticalCellsCount = value;
                    UC_Gm3.VerticalCellsCount = value;
                    UC_Dp.VerticalGraduationCount = verticalCellsCount;
                }
            }
        }
        public double CurveXMaxValue { get { return 100; } }
        public double CurveXMinValue { get { return 0; } }
        public double XRange
        {
            get { return CurveXMaxValue - CurveXMinValue; }
        }
        public double XPresentRange
        {
            get { return UnitLength * VerticalCellsCount; }
        }
        public int HorizontalCellsCount
        {
            get { return horizontalCellsCount; }
            set
            {
                if (value >= 1)
                {
                    horizontalCellsCount = value;
                    UC_Gm1.HorizontalCellsCount = value;
                    UC_Gm2.HorizontalCellsCount = value;
                    UC_Gm3.HorizontalCellsCount = value;
                }
            }
        }
        public double ViewHeight { get { return UC_Dp.ActualHeight; } }
        public double ViewWidth { get { return UC_Gm1.ActualWidth; } }
        public bool ShowGridLine
        {
            get { return UC_Gm1.CA_LineContainer.Visibility == Visibility.Visible; }
            set
            {
                if (value)
                {
                    UC_Gm1.CA_LineContainer.Visibility = Visibility.Visible;
                    UC_Gm2.CA_LineContainer.Visibility = Visibility.Visible;
                    UC_Gm3.CA_LineContainer.Visibility = Visibility.Visible;
                    UC_Gm1.CA_LineContainer2.Visibility = Visibility.Visible;
                    UC_Gm2.CA_LineContainer2.Visibility = Visibility.Visible;
                    UC_Gm3.CA_LineContainer2.Visibility = Visibility.Visible;
                }
                else
                {
                    UC_Gm1.CA_LineContainer.Visibility = Visibility.Collapsed;
                    UC_Gm2.CA_LineContainer.Visibility = Visibility.Collapsed;
                    UC_Gm3.CA_LineContainer.Visibility = Visibility.Collapsed;
                    UC_Gm1.CA_LineContainer2.Visibility = Visibility.Collapsed;
                    UC_Gm2.CA_LineContainer2.Visibility = Visibility.Collapsed;
                    UC_Gm3.CA_LineContainer2.Visibility = Visibility.Collapsed;
                }

            }
        }

        private CurveViewManager CreateManager(Model.Curve curve, Data.CurveData dataCatche, IGraph graph)
        {
            CurveViewManager manager = new CurveViewManager(curve, graph);
            manager.CurveData = dataCatche;
            tableOfCurveManager.Add(curve.Id, manager);
            return manager;
        }


        #region private
        List<Model.Curve> curveList = new List<Model.Curve>();
        Dictionary<Guid, CurveViewManager> tableOfCurveManager = new Dictionary<Guid, CurveViewManager>();
        double currentDepth = 0;
        double unitLength = 10;
        int verticalCellsCount = 10;
        int horizontalCellsCount = 5;
        #endregion
    }
}