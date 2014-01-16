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
    public partial class DataSourceStatePanel : UserControl
    {
        public DataSourceStatePanel()
        {
            InitializeComponent();
            Init();
            InitEventHandler();
        }

        Timer timer = new Timer();
        private void Init()
        {
            timer.Interval = 1200;
            listViewEx1.Items.Clear();
            packCountDataCache.Clear();
        }
       
        private void InitEventHandler()
        {
            timer.Tick += new EventHandler(timer_Tick);
            this.Load += (sender, e) => { timer.Start(); };
        }

        

        void timer_Tick(object sender, EventArgs e)
        {
            RefreshIp();
            RefreshPackCount();
            RefreshPackRate();
            RefreshCoordinateCount();
            RefreshHeight();
            RefreshThreadState();
        }

        #region cache
        Dictionary<Guid, object> ipCache = new Dictionary<Guid, object>();
        Dictionary<Guid, int> packCountDataCache = new Dictionary<Guid, int>();
        Dictionary<Guid, int> coordinateCountCache = new Dictionary<Guid, int>();
        Dictionary<Guid, int[]> packRateDataCache = new Dictionary<Guid, int[]>();
        Dictionary<Guid, double> heightCache = new Dictionary<Guid, double>();
        #endregion

        private void RefreshIp()
        {
            for (int i = 0; i < listViewEx1.Items.Count; i++)
            {
                Guid id = (Guid)listViewEx1.Items[i].Tag;
                if (ipCache.ContainsKey(id))
                {
                    listViewEx1.Items[i].Text = ipCache[id].ToString();
                }
            }
        }
        private void RefreshPackCount()
        {
            for (int i = 0; i < listViewEx1.Items.Count; i++)
            {
                Guid id = (Guid)listViewEx1.Items[i].Tag;
                if (packCountDataCache.Keys.Contains<Guid>(id))
                {
                    int newValue = packCountDataCache[id];
                    listViewEx1.Items[i].SubItems[1].Tag = newValue;
                    listViewEx1.Items[i].SubItems[1].Text = newValue.ToString()+" packs";
                }
            }
        }
        private void RefreshPackRate()
        {
            for (int i = 0; i < listViewEx1.Items.Count; i++)
            {
                Guid id = (Guid)listViewEx1.Items[i].Tag;
                if (packRateDataCache.Keys.Contains<Guid>(id))
                {
                    int oldValue = packRateDataCache[id][0];
                    int newValue = packRateDataCache[id][1];
                    listViewEx1.Items[i].SubItems[2].Tag = (newValue*1000.0)/ timer.Interval ;
                    listViewEx1.Items[i].SubItems[2].Text = (newValue*1000.0 / timer.Interval).ToString("0.0") + " points/s";
                    packRateDataCache[id][0] = packRateDataCache[id][1];
                    packRateDataCache[id][1] = 0;
                }
            }
        }
        private void RefreshNames()
        {
            for (int i = 0; i < listViewEx1.Items.Count; i++)
            {
                Guid id = (Guid)listViewEx1.Items[i].Tag;
                Model.Curve curve= GlobalTable.GlobalTables.Instance.GetCurve(id);
                Model.Device device=GlobalTable.GlobalTables.Instance.GetDevice(id);
                if (curve != null)
                {
                    listViewEx1.Items[i].SubItems[4].Text = curve.CurveName; ;
                }
                if (device != null)
                {
                    listViewEx1.Items[i].SubItems[3].Text = device.Name ;
                }
            }
        }
        private void RefreshCoordinateCount()
        {
            for (int i = 0; i < listViewEx1.Items.Count; i++)
            {
                Guid id = (Guid)listViewEx1.Items[i].Tag;
                if (coordinateCountCache.Keys.Contains<Guid>(id))
                {
                    int newValue = coordinateCountCache[id];
                    listViewEx1.Items[i].SubItems[5].Tag = newValue;
                    listViewEx1.Items[i].SubItems[5].Text = newValue.ToString();
                }
            }
        } 
        private void RefreshHeight()
        {
            for (int i = 0; i < listViewEx1.Items.Count; i++)
            {
                Guid id = (Guid)listViewEx1.Items[i].Tag;
                if (heightCache.Keys.Contains<Guid>(id))
                {
                    double newValue = heightCache[id];
                    listViewEx1.Items[i].SubItems[6].Tag = newValue;
                    listViewEx1.Items[i].SubItems[6].Text = newValue.ToString("0.00") + " (m)";
                }
            }
        }
        private void RefreshThreadState()
        {
            for (int i = 0; i < listViewEx1.Items.Count; i++)
            {
                Guid id = (Guid)listViewEx1.Items[i].Tag;
                listViewEx1.Items[i].SubItems[7].Text = Data.NetDataFetcher.Instance.GetFetcherState(id);
            }
        }

        public void HandleItem(Data.NotifyEventArgs args)
        {
            ListViewItem item = GetItemById(args.Id);
            if (item == null)
            {
                item = AddItemForCurve(args);
            }
        }
        public void HandleIp(Data.NotifyEventArgs args)
        {
            if (args != null && args.Options != null)
            {
                if (ipCache.ContainsKey(args.Id))
                {
                    ipCache[args.Id] = args.Options[1].ToString() ;
                }
                else
                {
                    ipCache.Add(args.Id, args.Options[1].ToString());
                }
            }
        }
        public void HandleHeight(Data.NotifyEventArgs args)
        {
            if (args != null && args.Points != null && args.Points.Length != 0)
            {
                if (heightCache.Keys.Contains<Guid>(args.Id))
                {
                    heightCache[args.Id] = args.Points[args.Points.Length - 1].X;
                }
                else
                {
                    heightCache.Add(args.Id, args.Points[args.Points.Length - 1].X);
                }
            }
        }
        public void HandlePackRate(Data.NotifyEventArgs args)
        {
            if(args!=null&&args.Points == null) { return; }
            if (packRateDataCache.Keys.Contains<Guid>(args.Id))
            {
                packRateDataCache[args.Id][1]+=args.Points.Length;
            }
            else
            {
                packRateDataCache.Add(args.Id, new int[2] { 0, args.Points.Length });
            }
        }
        public void HandleCoordinateCount(Data.NotifyEventArgs args)
        {
            if (args != null && args.Points != null)
            {
                if (coordinateCountCache.Keys.Contains<Guid>(args.Id))
                {
                    coordinateCountCache[args.Id] += args.Points.Length;
                }
                else
                {
                    coordinateCountCache.Add(args.Id, args.Points.Length);
                }
            }
        }
        public void HandlePackCount(Data.NotifyEventArgs args)
        {
            if (packCountDataCache.Keys.Contains<Guid>(args.Id))
            {
                packCountDataCache[args.Id]++;
            }
            else
            {
                packCountDataCache.Add(args.Id, 1);
            }
        }

        private ListViewItem CreateItem(Model.Curve curve)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = curve.Id;
            System.Windows.Forms.ListViewItem.ListViewSubItem ByteNumber = new System.Windows.Forms.ListViewItem.ListViewSubItem();
            System.Windows.Forms.ListViewItem.ListViewSubItem DataRate = new System.Windows.Forms.ListViewItem.ListViewSubItem();
            System.Windows.Forms.ListViewItem.ListViewSubItem DeviceName = new System.Windows.Forms.ListViewItem.ListViewSubItem();
            System.Windows.Forms.ListViewItem.ListViewSubItem CurveName = new System.Windows.Forms.ListViewItem.ListViewSubItem();
            System.Windows.Forms.ListViewItem.ListViewSubItem CoordinateNumber = new System.Windows.Forms.ListViewItem.ListViewSubItem();
            System.Windows.Forms.ListViewItem.ListViewSubItem CurrentHeight = new ListViewItem.ListViewSubItem();
            System.Windows.Forms.ListViewItem.ListViewSubItem ThreadState = new ListViewItem.ListViewSubItem();

            item.SubItems.Add(ByteNumber);
            item.SubItems.Add(DataRate);
            item.SubItems.Add(DeviceName);
            item.SubItems.Add(CurveName);
            item.SubItems.Add(CoordinateNumber);
            item.SubItems.Add(CurrentHeight);
            item.SubItems.Add(ThreadState);

            Model.Device device = GetDeviceName(curve.Id);
            if (device != null)
            {
                DeviceName.Text = device.Name;
                DeviceName.Tag = device;
            }
            else
            {
                DeviceName.Text = "未设定";
            }
            CurveName.Tag = curve;
            CurveName.Text = curve.CurveName;
            ByteNumber.Text = "0";
            ByteNumber.Tag = 0;
            DataRate.Text = "0 points/s";
            DataRate.Tag = 0;
            CoordinateNumber.Text = "0";
            CoordinateNumber.Tag = 0;
            CurrentHeight.Text = "0m";
            CurrentHeight.Tag = 0;

            ThreadState.Text = "未启动";
            ThreadState.Tag=Data.NetDataFetcher.Instance.GetFetcherState(curve.Id);
            return item;
        }
        private Model.Device GetDeviceName(Guid guid)
        {
            Model.Device device = Model.DataHelper.GetObject<Model.Device>("CurveId",guid.ToString());
            return device;
        }
        private void RemoveItem(Guid id)
        {
            ListViewItem item = GetItemById(id);
            listViewEx1.Items.Remove(item);
            coordinateCountCache.Remove(id);
            packCountDataCache.Remove(id);

        }
        private ListViewItem GetItemById(Guid id)
        {
            try
            {
                for (int i = 0; i < listViewEx1.Items.Count; i++)
                {
                    Guid tid = (Guid)listViewEx1.Items[i].Tag;
                    if (tid == id)
                    {
                        return listViewEx1.Items[i];
                    }
                }
                return null;
            }
            catch { return null; }
        }
        private ListViewItem AddItemForCurve(Data.NotifyEventArgs args)
        {
            Model.Curve curve = Model.Curve.CreateNew();
            curve.Id = args.Id;
            curve.CurveName = args.Tag;
            ListViewItem item = CreateItem(curve);
            listViewEx1.Items.Add(item);
            return item;
        }
        private void ClearAllCurve()
        {
            listViewEx1.Items.Clear();
        }
    }
}
