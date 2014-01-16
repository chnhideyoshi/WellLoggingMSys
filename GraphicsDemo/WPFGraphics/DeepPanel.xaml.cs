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
	/// Interaction logic for DeepPanel.xaml
	/// </summary>
	public partial class DeepPanel : UserControl
	{
		public DeepPanel()
		{
			this.InitializeComponent();
            this.LayoutRoot.Children.Clear();
		}
        #region VerticalGraduationCountProperty
        public static readonly DependencyProperty VerticalGraduationCountProperty =
           DependencyProperty.Register(
           "VerticalGraduationCount", typeof(int),
           typeof(DeepPanel), new PropertyMetadata(5, VerticalGraduationCountOnValueChanged)
           );
        private static void VerticalGraduationCountOnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            DeepPanel pt = o as DeepPanel;
            pt.VerticalOffset = 0;
            int count=(int)e.NewValue;
            pt.LayoutRoot.Children.Clear();
            pt.lineList.Clear();
            pt.textBlockList.Clear();
            SetLinePos(pt,count);
            SetTextBlockPos(pt,count);
        }
        private static void SetTextBlockPos(DeepPanel control, int count)
        {
            if (count != control.lineList.Count) { return; }
            for (int i = 0; i < count; i++)
            {
                Line line = control.lineList[i];
                TextBlock tb = new TextBlock();
                tb.Width = 65;
                tb.Height = 16;
                tb.TextAlignment = TextAlignment.Center;
                tb.Background = control.LayoutRoot.Background;
                tb.Text = (control.depthDeltaValue*i+control.depthBaseValue).ToString();
                control.LayoutRoot.Children.Add(tb);
                control.textBlockList.Add(tb);
                double centerLeft = (line.X1+line.X2) / 2;
                double centerTop = (line.Y1 + line.Y2) / 2;
                double left = centerLeft - 0.5 * tb.Width;
                double top = centerTop - 0.5 * tb.Height;
                Canvas.SetLeft(tb, left);
                Canvas.SetTop(tb, top);
            }
        }
        private static void SetLinePos(DeepPanel control,int count)
        {
            double uHeight = control.ActualHeight / count;
            for (int i = 0; i < count; i++)
            {
                Line line = new Line();
                line.Stroke = new SolidColorBrush(Colors.Black);
                line.Width = control.LayoutRoot.ActualWidth;
                line.Height = control.LayoutRoot.ActualHeight;
                line.X1 = 0;
                line.Y1 = uHeight * i;
                line.Y2 = uHeight * i;
                line.X2 = control.LayoutRoot.ActualWidth;
                control.LayoutRoot.Children.Add(line);
                control.lineList.Add(line);
            }
        }
        List<Line> lineList = new List<Line>();
        List<TextBlock> textBlockList = new List<TextBlock>();
        public int VerticalGraduationCount
        {
            get { return (int)GetValue(VerticalGraduationCountProperty); }
            set { SetValue(VerticalGraduationCountProperty, value); }
        }
        #endregion
        #region VerticalOffsetProperty
        public static readonly DependencyProperty VerticalOffsetProperty =
           DependencyProperty.Register(
           "VerticalOffsetProperty", typeof(double),
           typeof(DeepPanel), new PropertyMetadata(0.0, VerticalOffsetPropertyOnValueChanged)
           );
        private static void VerticalOffsetPropertyOnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            DeepPanel pt = o as DeepPanel;
            double offset=(double)e.NewValue;
            double uHeight = pt.LayoutRoot.ActualHeight / pt.VerticalGraduationCount;
            int n = (int)(offset / uHeight);
            #region LinesChange
            for (int i = 0; i < pt.lineList.Count; i++)
            {
                Line line = pt.lineList[i];
                double y = (n + 1) * uHeight - offset + i * uHeight;
                line.Y1 = y;
                line.Y2 = y;
            } 
            #endregion
            #region TBKsChange
            for (int i = 0; i < pt.textBlockList.Count; i++)
            {
                TextBlock tb = pt.textBlockList[i];
                Line line = pt.lineList[i];
                double centerTop = (line.Y1 + line.Y2) / 2;
                double top = centerTop - 0.5 * tb.Height;
                Canvas.SetTop(tb, top);
                double representValue = pt.DepthBaseValue + (1+i +n) * pt.DepthDeltaValue;
                tb.Text = (representValue).ToString();
            } 
            #endregion
        }
        public double VerticalOffset
        {
            get { return (double)GetValue(VerticalOffsetProperty); }
            set { SetValue(VerticalOffsetProperty, value); }
        }
        #endregion
        #region DepthBaseValue&DepthDeltaValue
        double depthBaseValue = 0;
        public double DepthBaseValue 
        {
            get { return depthBaseValue; }
            set
            { 
                depthBaseValue = value;
                for (int i = 0; i < textBlockList.Count; i++)
                {
                    textBlockList[i].Text = (i * DepthDeltaValue + depthBaseValue).ToString() ;
                }
            }
        }
        double depthDeltaValue = 100;
        public double DepthDeltaValue
        {
            get { return depthDeltaValue; }
            set 
            {
                depthDeltaValue = value;
                for (int i = 0; i < textBlockList.Count; i++)
                {
                    textBlockList[i].Text = (i * depthDeltaValue + DepthBaseValue).ToString();
                }
            }
        }
        #endregion
    }
}