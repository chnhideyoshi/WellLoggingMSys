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
using System.Collections;

namespace LoggingDataManager.WPFGraph
{
	/// <summary>
	/// Interaction logic for GridMap.xaml
	/// </summary>
    public partial class GridMap : UserControl
    {
        public GridMap()
        {
            this.InitializeComponent();
        }
        #region HorizontalCellsCountProperty
        public static readonly DependencyProperty HorizontalCellsCountProperty =
            DependencyProperty.Register(
            "HorizontalCellsCount", typeof(int),
            typeof(GridMap), new PropertyMetadata(5, HorizontalCellsCountOnValueChanged)
            );
        private static void HorizontalCellsCountOnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            GridMap pt = o as GridMap;
            pt.CA_LineContainer.Children.Clear();
            int count = (int)e.NewValue;
            if (count == 0) { return; }
            double uWidth = pt.CA_LineContainer.ActualWidth / count;
            for (int i = 0; i <= count; i++)
            {
                Line line = new Line();
                line.Width = pt.CA_LineContainer.ActualWidth;
                line.Height = pt.CA_LineContainer.ActualHeight;
                line.X1 = (i) * uWidth;
                line.X2 = (i) * uWidth;
                line.Y1 = 0;
                line.Y2 = pt.CA_LineContainer.ActualHeight;
                line.Stroke = new SolidColorBrush(Colors.Black);
                line.StrokeThickness = 1;
                pt.CA_LineContainer.Children.Add(line);
            }
        }
        public int HorizontalCellsCount
        {
            get { return (int)GetValue(HorizontalCellsCountProperty); }
            set { SetValue(HorizontalCellsCountProperty, value); }
        }
        #endregion
        #region VerticalCellsCountProperty
        public static readonly DependencyProperty VerticalCellsCountProperty =
           DependencyProperty.Register(
           "VerticalCellsCount", typeof(int),
           typeof(GridMap), new PropertyMetadata(5, VerticalCellsCountOnValueChanged)
           );
        private static void VerticalCellsCountOnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            GridMap pt = o as GridMap;
            pt.VerticalOffSet = 0;
            pt.CA_LineContainer2.Children.Clear();
            int count = (int)e.NewValue;
            double uHeight = pt.CA_LineContainer2.ActualHeight / count;
            if (count == 0) { return; }
            for (int i = 0; i < count; i++)
            {
                Line line = new Line();
                line.Width = pt.CA_LineContainer2.ActualWidth;
                line.Height = pt.CA_LineContainer2.ActualHeight;
                line.X1 = 0;
                line.X2 = pt.CA_LineContainer2.ActualWidth;
                line.Y1 = (i) * uHeight;
                line.Y2 = (i) * uHeight;
                line.Stroke = new SolidColorBrush(Colors.Black);
                line.StrokeThickness = 1;
                pt.CA_LineContainer2.Children.Add(line);
            }
        }
        public int VerticalCellsCount
        {
            get { return (int)GetValue(VerticalCellsCountProperty); }
            set { SetValue(VerticalCellsCountProperty, value); }
        }
        #endregion
        #region VerticalOffSetProperty
        public static readonly DependencyProperty VerticalOffSetProperty =
            DependencyProperty.Register(
            "VerticalOffSet", typeof(double),
            typeof(GridMap), new PropertyMetadata(0.0, VerticalOffSetPropertyChanged)
            );
        private static void VerticalOffSetPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            GridMap gm = o as GridMap;
            double offset = (double)e.NewValue;
            if (gm.VerticalCellsCount == 0) { return; }
            double uHeight = gm.CA_LineContainer2.ActualHeight / gm.VerticalCellsCount;
            int n = (int)(offset / uHeight);
            for (int i = 0; i < gm.CA_LineContainer2.Children.Count; i++)
            {
                Line line = gm.CA_LineContainer2.Children[i] as Line;
                if (line != null)
                {
                    double y = (n + i + 1) * uHeight - offset;
                    line.Y1 = y;
                    line.Y2 = y;
                }
            }
        }
        public double VerticalOffSet
        {
            get { return (double)GetValue(VerticalOffSetProperty); }
            set
            {
                SetValue(VerticalOffSetProperty, value);
                if (VerticalOffsetChanged != null)
                {
                    VerticalOffsetChanged(this, value / this.Height);
                }
            }
        }
        public double VerticalOffsetPecentage
        {
            get { return VerticalOffSet / this.Height; }
            set { VerticalOffSet = value * this.Height; }
        }
        public delegate void VerticalOffsetChangedEventHandler(object sender, double pecentage);
        public event VerticalOffsetChangedEventHandler VerticalOffsetChanged;

        #endregion
        public static byte ToByte(string s)
        {
            return byte.Parse(s, System.Globalization.NumberStyles.HexNumber);
        }
        private static Color GetColor(string name)
        {
            return Color.FromArgb(ToByte(name.Substring(0, 2)), ToByte(name.Substring(2, 2)), ToByte(name.Substring(4, 2)), ToByte(name.Substring(6, 2)));
        }
        public void AddShape(Model.Curve curve, CurveViewManager manager)
        {
            Polyline polyline = CreateGraphics(curve.CurveThickness, curve.CurveColor, curve.IsDashed);
            manager.PointCacheList = polyline.Points;
        }
        private Polyline CreateGraphics(double thickness, string color, int isDashed)
        {
            Polyline p = new Polyline();
            p.Height = this.ActualHeight;
            p.Width = this.ActualWidth;
            p.Stroke = new SolidColorBrush(GetColor(color));
            //p.Tag = curve.Id;
            if (isDashed == 1)
                p.StrokeDashArray = new DoubleCollection() { 2, 2 };
            p.StrokeThickness = thickness;
            CA_PolylineContainer.Children.Add(p);
            return p;
        }
    }
   
}