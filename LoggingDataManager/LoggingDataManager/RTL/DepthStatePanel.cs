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
    public partial class DepthStatePanel : UserControl
    {
        public DepthStatePanel()
        {
            InitializeComponent();
            timer.Interval = 2000;
            microChart1.DataMinValue = 0;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            //Data.NetDataFetcher.Instance.ProgressChanged += new Data.DataFetchingProgressChangedEventHandler(Instance_ProgressChanged);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            SetHeight(currentHeight);
            SetSpeed((currentHeight-oldHeight)/2.0);
            oldHeight = currentHeight;
           
            microChart1.DataPoints.Add(currentHeight);
            if (microChart1.DataPoints.Count >= 500)
            {
                microChart1.DataPoints.RemoveRange(0, 100);
            }
        }
        double oldHeight = 0;
        double currentHeight = 0;
        public void RecordDepth(double currentValue)
        {
            currentHeight = currentValue;
        }
        //void Instance_ProgressChanged(object sender, Data.NotifyEventArgs args)
        //{
        //    if (args != null&&args.Points!=null&&args.Points.Length!=0)
        //    {
        //        currentHeight = args.Points[args.Points.Length - 1].X;
        //    }
        //}

        Timer timer = new Timer();

        private void SetHeight(double height)
        {
            LB_hEIGHT.Text = string.Format("高度：{0}（m）", height.ToString("0.00"));
        }

        private void SetSpeed(double speed)
        {
            LB_Speed.Text = string.Format("速度：{0}（m/s）", speed.ToString("0.00"));
        }
    }
}
