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
using System.Windows.Shapes;

namespace WPFGraphics
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            MessageBox.Show((-1001%3).ToString());
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
            BTN_sTART.Click += new RoutedEventHandler(BTN_sTART_Click);
            SL_mAIN.ValueChanged += new RoutedPropertyChangedEventHandler<double>(SL_mAIN_ValueChanged);
            PL_LIne.Points.Clear();
            SL_mAIN.Value = 0;
            SL_mAIN.Maximum = 480000;
        }

        void SL_mAIN_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           int newv= (int)(e.NewValue);
            if (index !=newv )
            {
                index = newv;
                for (int i = 0; i < PC.Count; i++)
                {
                    Point p = PC[i];
                    p.Y = list[i + index].Y;
                    PC[i] = p ;
                }
                Line1.X1 = index%480;
                Line2.X1 = index % 480+240;
            }
        }
        int x = 0;
        Random R = new Random();
        List<Point> list = new List<Point>(50000);
        int index = 0;
        PointCollection PC = new PointCollection(480);
        void BTN_sTART_Click(object sender, RoutedEventArgs e)
        {
            while (x<480000)
            {
                int Y = R.Next(0, 304);
                list.Add(new Point(x, Y));
                x++;
            }
            for (int i = 0; i < 480; i++)
            {
                PC.Add(list[i]);
            }
            PL_LIne.Points = PC;

        }

        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            //CA_Main.Children.Add();
            

        }

    }
}
