using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for CurveEditor.xaml
    /// </summary>
    public partial class CurveEditor : UserControl,IGraph
    {
        public CurveEditor()
        {
            InitializeComponent();
            Init();
            InitEventHandler();
        }

        private void Init()
        {
            InitShape();
        }

        private void InitEventHandler()
        {
            this.Loaded += new RoutedEventHandler(CurveEditor_Loaded);
            BTN_ZoomIn.Click += new RoutedEventHandler(BTN_ZoomIn_Click);
            BTN_Back.Click += new RoutedEventHandler(BTN_Back_Click);
            SL_Main.ValueChanged += new RoutedPropertyChangedEventHandler<double>(SL_Main_ValueChanged);
            SL_Zoom.ValueChanged += new RoutedPropertyChangedEventHandler<double>(SL_Zoom_ValueChanged);
            CKB_ShowGrid.Click += new RoutedEventHandler(CKB_ShowGrid_Click);
            BTN_Move.Click += new RoutedEventHandler(BTN_Move_Click);
            BTN_Delete.Click += new RoutedEventHandler(BTN_Delete_Click);
        }

        void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {
            double up = 0, down = 0;
            GetRange(ref up,ref down);
            if (MessageBox.Show(string.Format("确定需要删除范围({0},{1})之间的所有点吗？",up,down), "提示", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                DeleteRange(up, down);
            }

        }

        

        void BTN_Move_Click(object sender, RoutedEventArgs e)
        {
            LoggingDataManager.MoveWindow w = new LoggingDataManager.MoveWindow(CurveXMinValue,CurveXMaxValue,curve.YMinValue,curve.YMaxValue,this);
            w.ShowDialog();
        }

        void SL_Zoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double percentage = e.NewValue / SL_Main.Maximum;
            if (percentage == 0) { return; }
            double value = percentage * (MaxUnitLength);
            UnitLength = value;
            CurrentDepth = currentDepth;
            this.TBK_Zoom.Text = string.Format("刻度:{0}", UnitLength.ToString("0.00"));
            RepaintAll();
            this.ShowModifiablePoints();
        }

        void CKB_ShowGrid_Click(object sender, RoutedEventArgs e)
        {
            ShowGridLine = CKB_ShowGrid.IsChecked == true;
        }

        void SL_Main_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double percentage = e.NewValue / SL_Main.Maximum;
            double height = percentage * XRange;
            TBK_dEPTH.Text = string.Format("深度:{0}", height.ToString("0.00"));
            CurrentDepth = height;
            this.ShowModifiablePoints();
            RepaintAll();
        }

        void BTN_Back_Click(object sender, RoutedEventArgs e)
        {
            ZoomOut();
            ShowModifiablePoints();
        }

        void BTN_ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            ZoomIn();
            ShowModifiablePoints();
        }

        void CurveEditor_Loaded(object sender, RoutedEventArgs e)
        {
            layer = AdornerLayer.GetAdornerLayer(CA_OverLay);
            layer.Add(new ResizingAdorner(REC_Overlay));
            RepaintAll();
        }


        public void SetCurve(Model.Curve curve, Data.CurveData data)
        {
            this.curve = curve;
            UC_PT.SetCurve(curve);
            UC_Dp.DepthBaseValue = CurveXMinValue;
            UC_Dp.DepthDeltaValue = MaxUnitLength;
            curveManager = CreateManager(curve, data, this);
            UC_Gm.AddShape(curve, curveManager);
        }

        private void InitShape()
        {
            CA_OverLay.PreviewMouseMove += (sender, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed && CA_OverLay.Tag != null)
                {
                    Ellipse el = CA_OverLay.Tag as Ellipse;
                    Point p = e.GetPosition(CA_OverLay);
                    Canvas.SetLeft(el, p.X - 0.5 * el.ActualWidth);
                    MovePoints((Point)el.Tag, p);
                }
                else
                {
                    CA_OverLay.Tag = null;
                }
            };
            for (int i = 0; i < 100; i++)
            {
                Ellipse el = new Ellipse();
                el.MouseDown += (sender, e) =>
                {
                    CA_OverLay.Tag = sender;
                };
                el.MouseUp += (sender, e) => { CA_OverLay.Tag = null; };
                el.MouseEnter += (sender, e) => { (sender as Ellipse).Style = this.FindResource("EllipseStyle2") as Style; };
                el.MouseLeave += (sender, e) => { (sender as Ellipse).Style = this.FindResource("EllipseStyle1") as Style; };
                shapeList.Add(el);
                el.Style = this.FindResource("EllipseStyle1") as Style;
                el.Visibility = Visibility.Collapsed;
                CA_OverLay.Children.Add(el);
            }
        }
        private void DeleteRange(double up, double down)
        {
            curveManager.CurveData.DeleleRange(up, down);
            RepaintAll();
            ShowModifiablePoints();
        }
        private void MovePoints(Point from, Point to)
        {
            double fcox = 0, fcoy = 0, tcox = 0, tcoy = 0;
            curveManager.GetOriginCoodinate(ref fcox, ref fcoy, from);
            curveManager.GetOriginCoodinate(ref tcox, ref tcoy, to);
            curveManager.CurveData.SetValueTo(fcox, tcoy);
            RepaintAll();
            ShowModifiablePoints();
        }
        private void ZoomIn()
        {
            double upBound = 0;
            double downBound = 0;
            GetRange(ref upBound, ref downBound);
            //UC_Dp.DepthDeltaValue = (downBound - upBound) / UC_Dp.VerticalGraduationCount;
            UnitLength = (downBound - upBound) / VerticalCellsCount;
            CurrentDepth = upBound;
            RepaintAll();
        }
        private void ZoomOut()
        {
            CurrentDepth = CurveXMinValue;
            UnitLength = MaxUnitLength;
            RepaintAll();
        }
        private void GetRange(ref double upBound, ref double downBound)
        {
            double top = Canvas.GetTop(REC_Overlay);
            double height = REC_Overlay.ActualHeight;
            double pecentage1 = top / CA_OverLay.ActualHeight;
            double pecentage2 = (top + height) / CA_OverLay.ActualHeight;
            upBound = CurrentDepth + XPresentRange * pecentage1;
            downBound = CurrentDepth + XPresentRange * pecentage2;
        }
        private void ShowModifiablePoints()
        {
            List<Point> list = curveManager.GetRangePoints(CurrentDepth, XRange);
            ClearShape();
            if (list.Count <= 100)
            {
                CreateShape(list);
            }
        }
        private void ClearShape()
        {
            for (int i = 0; i < shapeList.Count; i++)
            {
                shapeList[i].Visibility = Visibility.Collapsed;
            }
        }
        private void CreateShape(List<Point> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Ellipse el = shapeList[i];
                if (el != null)
                {
                    el.Tag = list[i];
                    el.Visibility = Visibility.Visible;
                    Canvas.SetLeft(el, list[i].X - 0.5 * el.ActualWidth);
                    Canvas.SetTop(el, list[i].Y - 0.5 * el.ActualHeight);
                }
            }
        }
        private CurveViewManager CreateManager(Model.Curve curve, Data.CurveData dataCatche, IGraph graph)
        {
            CurveViewManager manager = new CurveViewManager(curve, graph);
            manager.CurveData = dataCatche;
            return manager;
        }

        public double CurrentDepth
        {
            set
            {
                currentDepth = value;
                UC_Dp.VerticalOffsetPecentage = (value - CurveXMinValue) / XPresentRange;
                UC_Gm.VerticalOffsetPecentage = (value - CurveXMinValue) / XPresentRange;
                curveManager.BaseOffsetPercentage = value / curveManager.XRange;
            }
            get { return currentDepth; }
        }
        public double CurveXMaxValue
        {
            get { return curve.XMaxValue; }
        }
        public double CurveXMinValue
        {
            get { return curve.XMinValue; }
        }
        public double MaxUnitLength
        {
            get { return XRange / VerticalCellsCount; }
        }
        public void RepaintAll()
        {
            curveManager.RePaint();
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
        public int VerticalCellsCount
        {
            get { return verticalCellsCount; }
            set
            {
                if (value != 0)
                {
                    verticalCellsCount = value;
                    UC_Gm.VerticalCellsCount = value;
                    UC_Dp.VerticalGraduationCount = verticalCellsCount;
                }
            }
        }
        public int HorizontalCellsCount
        {
            get { return horizontalCellsCount; }
            set
            {
                if (value >= 1)
                {
                    horizontalCellsCount = value;
                    UC_Gm.HorizontalCellsCount = value;
                }
            }
        }
        public double XPresentRange
        {
            get { return UnitLength * VerticalCellsCount; }
        }
        public double XRange
        {
            get { return CurveXMaxValue - CurveXMinValue; }
        }
        public double ViewHeight
        {
            get { return UC_Dp.ActualHeight; }
        }
        public double ViewWidth
        {
            get { return UC_Gm.ActualWidth; }
        }
        public bool ShowGridLine
        {
            get { return UC_Gm.CA_LineContainer.Visibility == Visibility.Visible; }
            set
            {
                if (value)
                {
                    UC_Gm.CA_LineContainer.Visibility = Visibility.Visible;
                    UC_Gm.CA_LineContainer2.Visibility = Visibility.Visible;
                }
                else
                {
                    UC_Gm.CA_LineContainer.Visibility = Visibility.Collapsed;
                    UC_Gm.CA_LineContainer2.Visibility = Visibility.Collapsed;
                }
            }
        }
        public void CurveXYMove(double deltaX,double deltaY)
        {
            curveManager.CurveData.XYMove(deltaX, deltaY);
            RepaintAll();
        }


        #region private
        private List<Ellipse> shapeList = new List<Ellipse>();
        AdornerLayer layer = null;
        Model.Curve curve = null;
        CurveViewManager curveManager = null;
        double currentDepth = 0;
        double unitLength = 10;
        int verticalCellsCount = 10;
        int horizontalCellsCount = 5;
        #endregion

        
    }
}
