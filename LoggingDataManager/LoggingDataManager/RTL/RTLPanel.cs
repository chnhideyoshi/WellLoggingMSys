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
    public partial class RTLPanel : UserControl
    {
        #region GlobalControls
        static RichTextBox RTB_ShowMessage = null;
        static DataSourceStatePanel dataStatePanel = null;
        public static DataSourceStatePanel DataStatePanel
        {
            get { return RTLPanel.dataStatePanel; }
        }
        public static void ClearConsoleShow() { if (RTB_ShowMessage != null) { RTB_ShowMessage.Text = string.Empty; } }
        public static void ConsoleShow(string title, string message)
        {
            if (RTB_ShowMessage != null)
            {
                    RTB_ShowMessage.Text = "  " + message + Environment.NewLine + RTB_ShowMessage.Text+Environment.NewLine;
                    RTB_ShowMessage.Text = "------ " + title + " ------" + Environment.NewLine + RTB_ShowMessage.Text;
            }
        }
        #endregion
        
        public RTLPanel()
        {
            InitializeComponent();
            Init();
            InitEventHandler();
        }

        private void InitEventHandler()
        {
            Data.NetDataFetcher.Instance.LoggingEventsFired += new Data.LoggingEventsFiredEventHandler(Instance_LoggingEventsFired);
            Data.NetDataFetcher.Instance.ErrorOccured += new Data.ErrorOccuredEventHandler(Instance_ErrorOccured);
            Data.NetDataFetcher.Instance.ProgressChanged += new Data.DataFetchingProgressChangedEventHandler(Instance_ProgressChanged);
            Data.NetDataFetcher.Instance.DataFetchingPackReceived += new Data.DataFetchingPackReceivedEventHandler(Instance_DataFetchingPackReceived);
          
        }

        void Instance_DataFetchingPackReceived(object sender, Data.NotifyEventArgs args)
        {
            dataStatePanel.HandleItem(args);
            dataStatePanel.HandleIp(args);
            dataStatePanel.HandlePackCount(args);
        }

        void Instance_ProgressChanged(object sender, Data.NotifyEventArgs args)
        {
            if (args != null && args.Points != null && args.Points.Length != 0)
            {
                double currentHeight = args.Points[args.Points.Length - 1].X;
                depthStatePanel1.RecordDepth(currentHeight);
                graphControl1.RecordDepth(currentHeight);
                graphControl1.Graph.Repaint(args.Id);
            }
            dataStatePanel.HandleItem(args);
            dataStatePanel.HandleIp(args);
            dataStatePanel.HandlePackCount(args);
            dataStatePanel.HandleCoordinateCount(args);
            dataStatePanel.HandlePackRate(args);
            dataStatePanel.HandleHeight(args);
        }

        void Instance_ErrorOccured(object sender, Data.NotifyEventArgs args)
        {
                ConsoleShow("data source error event",args.Message);
        }

        void Instance_LoggingEventsFired(object sender,Data.NotifyEventArgs args)
        {
              ConsoleShow("data source event",args.Message);
        }

        private void Init()
        {
            RTB_ShowMessage = this.richTextBox1;
            dataStatePanel = this.UC_DataState;
        }


        internal void HandleStartDataSourceEvents(object sender, EventArgs e)
        {
            graphControl1.HandleStartDataSourceEvents(sender, e);
        }

        internal void HandleDataSourceConfigEvents(object sender, EventArgs e)
        {
            graphControl1.HandleDataSourceConfigEvents(sender, e);
        }
    }
}
