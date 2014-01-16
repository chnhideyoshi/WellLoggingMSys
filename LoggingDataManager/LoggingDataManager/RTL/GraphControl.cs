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
    public partial class GraphControl : UserControl
    {
        public GraphControl()
        {
            InitializeComponent();
            Init();
            InitEventHandler();
        }

        private void Init()
        {
            SL_XRange.Maximum=1000;
            SL_XRange.Value = SL_XRange.Maximum;
            SL_XRange.Visible = false;
            #region InitProjectParams
            BTN_BeginFetcher.Enabled = true;
            BTN_PauseAllFetcher.Enabled = false;
            #endregion
        }

        private void InitEventHandler()
        {
            #region Curve
            //Data.NetDataFetcher.Instance.ProgressChanged += (sender, e) =>
            //    {
            //        if (e.Points != null && e.Points.Length != 0)
            //        {
            //            double height = e.Points[e.Points.Length - 1].X;
            //            //Graph.SetBaseValue(height-Graph.GetDeltaValue()*Graph.GetVerticalCellsCount());
                        
            //            Graph.Repaint();
            //        }
            //    };
            CKB_Auto.CheckedChanged += (sender, e) =>
            {
                if (CKB_Auto.Checked)
                {
                    SL_XRange.Enabled = false;
                }
                else
                {
                    SL_XRange.Enabled = true;
                }
            };
            #endregion
            #region ValueChanged
            DI_SrollRate.ValueChanged += (sender, e) =>
                {
                    if (DI_SrollRate.Value <= 0)
                    {
                        DI_SrollRate.Value = 0.1;
                    }
                };
            SL_XRange.ValueChanged += (sender, e) =>
                {
                    try
                    {
                        double pecentage =(double)SL_XRange.Value / (double)SL_XRange.Maximum;
                        Graph.CurrentDepth =(1- pecentage) * Graph.XRange;
                        //Graph.SetPercentage(DI_SrollRate.Value*(1-pecentage));
                    }
                    catch (Exception ex)
                    {
                        Program.SetStatusMessage(ex.Message); 
                    }
                }; 
            #endregion
            #region ClearAllCurve
            BTN_ClearAllCurve.Click += (sender, e) =>
             {
                 try
                 {
                     if (MessageBox.Show("确定删除面板上的所有曲线？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                     {
                         //Graph.RemoveAllCurve();
                         Program.SetStatusMessage("清除失败！");
                     }
                 }
                 catch (Exception ex)
                 {
                     Program.SetStatusMessage(ex.Message);
                 }
             }; 
            #endregion
            #region ViewSetting
            BTN_ViewSetting.Click += (sender, e) =>
                {
                    try
                    {
                        ViewSettingForm form = new ViewSettingForm(this.Graph);
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        Program.SetStatusMessage(ex.Message);
                    }
                }; 
            #endregion
            #region BeginFetcher
            BTN_BeginFetcher.Click += (sender, e) =>
               {
                   List<Model.Curve> clist = Model.DataHelper.GetAllObject<Model.Curve>();
                   List<Model.Device> dlist = Model.DataHelper.GetAllObject<Model.Device>();
                   ListSelectForm form = new ListSelectForm();
                   form.SetRows(clist,dlist);
                   if (form.ShowDialog() == DialogResult.OK)
                   {
                       Dictionary<Guid, bool> dic = form.GetFetchingMap();
                       foreach (Guid id in dic.Keys)
                       {
                           #region Fetcher
                           Data.NetDataFetcher fe = GlobalTable.GlobalTables.Instance.GetFetcher(id) as Data.NetDataFetcher;
                           if (fe != null)
                           {
                               if (dic[id])
                               {
                                   fe.Start(id);
                               }
                               else
                               {
                                   fe.Pause(id);
                               }
                           } 
                           #endregion
                       }
                   }
               }; 
            #endregion
            #region PauseFetcher
            BTN_PauseAllFetcher.Click += (sender, e) =>
                {
                    //if (MessageBox.Show("确定停止数据源？", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    //{
                        Data.NetDataFetcher.Instance.PauseAll();
                   // }
                }; 
            #endregion
        }
        internal void HandleDataSourceConfigEvents(object sender, EventArgs e)
        {
            List<Model.Curve> clist = Model.DataHelper.GetAllObject<Model.Curve>();
            List<Model.Device> dlist = Model.DataHelper.GetAllObject<Model.Device>();
            DataSourceConfigConfirmForm form = new DataSourceConfigConfirmForm();
            form.SetRows(clist, dlist);
            form.ShowDialog();
        }

        public void HandleStartDataSourceEvents(object sender, EventArgs e)
        {
            List<Model.Curve> clist = Model.DataHelper.GetAllObject<Model.Curve>();
            List<Model.Device> dlist = Model.DataHelper.GetAllObject<Model.Device>();
            DataSourceStartConfigConfirmForm form = new DataSourceStartConfigConfirmForm();
            form.SetRows(clist, dlist);
            if (form.ShowDialog() == DialogResult.OK)
            {
                List<Guid> idList = form.StartInfo.IdList;
                Data.NetDataFetcher.Instance.ClearAllRegisteredIds();
                idList.ForEach(id => 
                {
                    Model.Curve curve = GlobalTable.GlobalTables.Instance.GetCurve(id);
                    if (curve == null)
                        curve = Model.DataHelper.GetObjectById<Model.Curve>(id);
                    this.Graph.AddCurve(curve,GlobalTable.GlobalTables.Instance.GetDataCatche(curve.Id),curve.CurveGroupIndex);
                    Data.NetDataFetcher.Instance.AddRegisteredId(id);
                });
                if (!ProcessManager.CheckSourceProcessRunning())
                {
                    ProcessManager.StartDataSourceProccess(form.StartInfo);
                }
                //this.Graph.ManipulationBoundaryFeedback\(form.GetBaseValue());
                this.Graph.UnitLength=(form.GetDeltaValue());
                this.Graph.HorizontalCellsCount=(form.GetHorizontalCountValue());
                this.Graph.VerticalCellsCount=(form.GetVerticalCountValue());
                this.DI_SrollRate.Value = form.GetRateValue();
            }
        }
       
        public WPFGraph.Graph Graph
        {
            get {  return elementHost1.Child as WPFGraph.Graph; }
        }


        internal void RecordDepth(double currentHeight)
        {
            //double s= currentHeight - Graph.UC_Dp.XRepresentRange;
            //if ( s>= 0)
            //{
            //   // Graph.ScrollToDepth(s);
            //}
        }
    }
}
