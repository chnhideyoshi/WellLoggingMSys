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
	/// Interaction logic for Graph.xaml
	/// </summary>
	public partial class Graph : UserControl
	{
		public Graph()
		{
			this.InitializeComponent();
            Loaded += new RoutedEventHandler(Graph_Loaded);
		}

        void Graph_Loaded(object sender, RoutedEventArgs e)
        {
            InitParameters();
        }

        private void InitParameters()
        {
            UC_Dp.VerticalGraduationCount = 20;
            UC_Dp.VerticalOffset = 0;
            UC_Gm1.HorizontalCellsCount = 8;
            UC_Gm1.VerticalCellsCount = 20;
            UC_Gm1.VerticalOffSet = 0;
            UC_Gm2.HorizontalCellsCount = 8;
            UC_Gm2.VerticalCellsCount = 20;
            UC_Gm2.VerticalOffSet = 0;
            UC_Gm3.HorizontalCellsCount = 8;
            UC_Gm3.VerticalCellsCount = 20;
            UC_Gm3.VerticalOffSet = 0;
        }

        public void AddCurve(CurveView view,int groupIndex)
        {

        }
        #region ViewHeight
        double viewHeight = 764;
        public double ViewHeight
        {
            get { return viewHeight; }
            set
            {
                viewHeight = value;
                UC_Gm1.Height = value;
                UC_Gm2.Height = value;
                UC_Gm3.Height = value;
                UC_Dp.Height = value;
            }
        }
        #endregion
    }
}