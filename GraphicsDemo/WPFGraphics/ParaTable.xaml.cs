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
	/// Interaction logic for ParaTable.xaml
	/// </summary>
	public partial class ParaTable : UserControl
	{
		public ParaTable()
		{
			this.InitializeComponent();
		}
        public static readonly DependencyProperty CurveBackColorProperty =
            DependencyProperty.Register(
            "CurveBackColor", typeof(Brush),
            typeof(ParaTable), new PropertyMetadata(null, OnValueChanged)
            );
        private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ParaTable pt = o as ParaTable;
            if (pt != null)
            {
                pt.line4.Stroke = e.NewValue as Brush;
            }
        }
        public Brush CurveBackColor
        {
            get { return (Brush)GetValue(CurveBackColorProperty); }
            set { SetValue(CurveBackColorProperty, value); }
        }
        public string CurveName
        {
            get { return R_CurveName.Text; }
            set { R_CurveName.Text = value; }
        }
        public string CurveUnit
        {
            get { return R_CurveUnit.Text; }
            set { R_CurveUnit.Text = value; }
        }
        public string MaxValue
        {
            get { return TBK_MaxValue.Text; }
            set { TBK_MaxValue.Text = value; }
        }
        public string MinValue
        {
            get { return TBK_MinValue.Text; }
            set { TBK_MinValue.Text = value; }
        }
        bool isDashed = false;
        public bool IsDashed
        {
            get { return isDashed; }
            set 
            {
                isDashed=value;
                if (value)
                {
                    line4.StrokeDashArray = new DoubleCollection() { 2, 2 };
                }
                else
                {
                    line4.StrokeDashArray = new DoubleCollection() { 1, 0 };
                }
            }
        }
	}
}