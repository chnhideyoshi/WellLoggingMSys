using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoggingDataManager.LeftPanel
{
    public partial class DevicePanel : UserControl
    {
        public DevicePanel()
        {
            InitializeComponent();
            this.Load += new EventHandler(DevicePanel_Load);
        }

        void DevicePanel_Load(object sender, EventArgs e)
        {
            RefreshItems();
        }

        public void RefreshItems()
        {
             try
            {
                List<Model.Device> list = Model.DataHelper.GetAllObject<Model.Device>();
                node1.Nodes.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
                    node.Text = list[i].Name;
                    node.Tag = list[i].Id;
                    node.Image = Properties.Resources.LeftPanel_DevicePanel_DeviceItem;
                    node1.Nodes.Add(node);
                }

             }catch(Exception ex)
             {
                 Program.SetStatusMessage(ex.Message);
             }
        }
    }
}
