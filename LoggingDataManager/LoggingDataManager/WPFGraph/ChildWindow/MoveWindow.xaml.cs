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
using System.Windows.Shapes;

namespace LoggingDataManager
{
    /// <summary>
    /// Interaction logic for MoveWindow.xaml
    /// </summary>
    public partial class MoveWindow : Window
    {
        public MoveWindow()
        {
            this.InitializeComponent();
        }
        public MoveWindow(double xmin,double xmax,double ymin,double ymax,WPFGraph.CurveEditor editor)
        {
            this.InitializeComponent();
            SL_X.ValueChanged += new RoutedPropertyChangedEventHandler<double>(SL_X_ValueChanged);
            SL_Y.ValueChanged += new RoutedPropertyChangedEventHandler<double>(SL_Y_ValueChanged);
            XMin = xmin;
            XMax = xmax;
            YMin = ymin;
            YMax = ymax;
            SL_X.Minimum = -XRange;
            SL_X.Maximum =XRange;
            SL_Y.Minimum = -YRange;
            SL_Y.Maximum = YRange;
            Editor = editor;
            SL_X.Value = 0;
            SL_Y.Value = 0;
            BTN_Cancel.Click += new RoutedEventHandler(BTN_Cancel_Click);
            BTN_OK.Click += new RoutedEventHandler(BTN_OK_Click);
        }

        void BTN_OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult=true;
        }

        void BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        double XMin = 0;
        double XMax = 100;
        double YMin = -100;
        double YMax = 100;
        WPFGraph.CurveEditor Editor = null;
 
       private double XRange { get { return XMax - XMin; } }
       private double YRange { get { return YMax - YMin; } }

        void SL_Y_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TB_Y.Text = e.NewValue.ToString("0.00");
            if(Editor!=null)
            {
                Editor.CurveXYMove(0, e.NewValue-e.OldValue);
            }
        }

        void SL_X_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TB_X.Text = e.NewValue.ToString("0.00");
            if (Editor != null)
            {
                Editor.CurveXYMove(e.NewValue - e.OldValue, 0);
            }
        }
    }

}