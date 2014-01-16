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

namespace WPFGraphics
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
            double uWidth=pt.CA_LineContainer.ActualWidth/count;
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
            GridMap gm=o as GridMap;
            double offset = (double)e.NewValue;
            double uHeight = gm.CA_LineContainer2.ActualHeight / gm.VerticalCellsCount;
            int n = (int)(offset / uHeight);
            for (int i = 0; i < gm.CA_LineContainer2.Children.Count; i++)
            {
                Line line = gm.CA_LineContainer2.Children[i] as Line;
                if (line != null)
                {
                    double y = (n +i+ 1) * uHeight - offset;
                    line.Y1 = y;
                    line.Y2 = y;
                }
            }
        }
        public double VerticalOffSet
        {
            get { return (double)GetValue(VerticalOffSetProperty); }
            set { SetValue(VerticalOffSetProperty, value); }
        }
        #endregion
        List<CurveView> listOfCurveData = new List<CurveView>(3);
        public void Add(CurveView curveData)
        {
            if (curveData != null)
            {
                listOfCurveData.Add(curveData);
                //ShowData(curveData);
            }
        }
        //private void ShowData(CurveView curveData)
        //{
        //    Polyline polyline = new Polyline();
        //    polyline.Height = CA_PolylineContainer.Height;
        //    polyline.Width = CA_PolylineContainer.Width;
        //    polyline.Stroke = new SolidColorBrush(Colors.Red);
        //    int pxNum = (int)this.ActualHeight;
        //    this.CA_PolylineContainer.Children.Add(polyline);
        //}
    }
   
}