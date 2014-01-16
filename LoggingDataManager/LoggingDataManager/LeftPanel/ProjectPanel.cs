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
    public partial class ProjectPanel : UserControl
    {
        public ProjectPanel()
        {
            InitializeComponent();
            this.Load += new EventHandler(ProjectPanel_Load);
        }

        void ProjectPanel_Load(object sender, EventArgs e)
        {
            RefreshItems();
        }
        public void RefreshItems()
        {
            try
            {
                List<Model.Project> list = Model.DataHelper.GetAllObject<Model.Project>();
                node1.Nodes.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
                    node.Text = list[i].ProjectName;
                    node.NodeDoubleClick += new EventHandler(node_NodeDoubleClick);
                    node.Tag = list[i].Id;
                    node1.Nodes.Add(node);
                }
                for (int i = 0; i < node1.Nodes.Count; i++)
                {
                    if (Program.OpenedProject != null && Program.OpenedProject.Id == (Guid)node1.Nodes[i].Tag)
                    {
                        node1.Nodes[i].Image = Properties.Resources.LeftPanel_ProjectPanel_OpenedProject;
                    }
                    else
                    {
                        node1.Nodes[i].Image = Properties.Resources.LeftPanel_ProjectPanel_ProjectItem;
                    }
                }
            }
            catch(Exception ex)
            {
                Program.SetStatusMessage(ex.Message);
            }
        }

        void node_NodeDoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (OpenProjectCommandReceived != null)
                    OpenProjectCommandReceived(this, (Guid)(sender as DevComponents.AdvTree.Node).Tag);
            }
            catch (Exception ex)
            {
                Program.SetStatusMessage(ex.Message);
            }
        }
        public delegate void OpenProjectCommandReceivedEventHandler(object sender, Guid projectId);
        public event OpenProjectCommandReceivedEventHandler OpenProjectCommandReceived;
    }
}
