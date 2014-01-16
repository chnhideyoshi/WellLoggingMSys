using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace LoggingDataManager
{
    public partial class MainForm : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
            Init();
            InitEventHandler();
        }

        private void Init()
        {
            this.Height = 800;
            this.Width = 1200;
        }

        private void InitEventHandler()
        {
            this.Load += new EventHandler(MainForm_Load);
            BTN_CurveSetting.Click += new EventHandler(BTN_CurveSetting_Click);
            BTN_RTLView.Click += new EventHandler(BTN_RTLView_Click);
            BTN_NewProject.Click += new EventHandler(BTN_NewProject_Click);
            BTN_AddDevice.Click += new EventHandler(BTN_AddDevice_Click);
            BTN_OpenProject.Click += new EventHandler(BTN_OpenProject_Click);
            BTN_DeviceInfo.Click += new EventHandler(BTN_DeviceInfo_Click);
            BTN_DataSourceConfig.Click += new EventHandler(BTN_DataSourceConfig_Click);
            BTN_StartDataSource.Click += new EventHandler(BTN_StartDataSource_Click);
            BTN_ImageProcess.Click += new EventHandler(BTN_ImageProcess_Click);
            BTN_StopListen.Click += new EventHandler(BTN_StopListen_Click);
            BTN_CurveEdit.Click += new EventHandler(BTN_CurveEdit_Click);
        }

        void BTN_CurveEdit_Click(object sender, EventArgs e)
        {
            //NavigateTo<LoggingDataManager.RTL.>();
            PublicControls.SelectForm<Model.Curve> form = new PublicControls.SelectForm<Model.Curve>();
            form.TitleText = "选择曲线";
            List<Model.Curve> curveList = Model.DataHelper.GetAllObject<Model.Curve>();
            form.SetList<Model.Curve>(curveList);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Model.Curve curve = form.SelectedObject;
                LoggingDataManager.RTL.GraphEditor panel = NavigateTo<LoggingDataManager.RTL.GraphEditor>();
                panel.SetCurve(curve);
                UpdateUI();
            }
        }

        void BTN_StopListen_Click(object sender, EventArgs e)
        {
            Data.NetDataFetcher.Instance.CloseConnection();
        }

        void BTN_ImageProcess_Click(object sender, EventArgs e)
        {
             AppHelper.RunProccess(Global.ImageJPath);
        }

        void BTN_StartDataSource_Click(object sender, EventArgs e)
        {
           LoggingDataManager.RTL.RTLPanel panel = NavigateTo<LoggingDataManager.RTL.RTLPanel>();
           panel.HandleStartDataSourceEvents(sender, e);
        }

        void BTN_DataSourceConfig_Click(object sender, EventArgs e)
        {
            LoggingDataManager.RTL.RTLPanel panel = NavigateTo<LoggingDataManager.RTL.RTLPanel>();
            panel.HandleDataSourceConfigEvents(sender, e);
        }

        void BTN_DeviceInfo_Click(object sender, EventArgs e)
        {
            PublicControls.DeleteForm<Model.Device> form = new PublicControls.DeleteForm<Model.Device>();
            form.TitleText = "删除仪器";
            List<Model.Device> list = Model.DataHelper.GetAllObject<Model.Device>();
            form.SetList<Model.Device>(list);
            form.ShowDialog();
            UpdateUI();
        }

        void BTN_OpenProject_Click(object sender, EventArgs e)
        {
            PublicControls.SelectForm<Model.Project> form = new PublicControls.SelectForm<Model.Project>();
            List<Model.Project> list = Model.DataHelper.GetAllObject<Model.Project>();
            form.SetList<Model.Project>(list);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Model.Project project = form.SelectedObject;
                this.CurrentProject = project;
                UpdateUI();
            }
        }

        void BTN_AddDevice_Click(object sender, EventArgs e)
        {
            DeviceManagement.NewDeviceForm form = new DeviceManagement.NewDeviceForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("仪器添加成功！");
                UC_DevicePanel.RefreshItems();
            }
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            SetProjectState();
            LoadLeftPanel();
        }

        private void SetProjectState()
        {
            
        }

        private void LoadLeftPanel()
        {
            LeftPanel.ProjectPanel panel = new LeftPanel.ProjectPanel();
            UC_ProjectPanel = panel;
            panel.OpenProjectCommandReceived += (sender, e) => 
            {
                OpenProject(e);
            };
            panel.Dock = DockStyle.Fill;
            this.tabControlPanel1.Controls.Add(panel);
            LeftPanel.DevicePanel dpanel = new LeftPanel.DevicePanel();
            UC_DevicePanel = dpanel;
            dpanel.Dock = DockStyle.Fill;
            this.tabControlPanel2.Controls.Add(dpanel);
        }

        private void OpenProject(Guid id)
        {
            Model.Project project = Model.DataHelper.GetObjectById<Model.Project>(id);
            CurrentProject = project;
        }

        void BTN_NewProject_Click(object sender, EventArgs e)
        {
            Project.NewProjectForm form = new Project.NewProjectForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Program.SetStatusMessage("新建成功！");
                MessageBox.Show("新建成功！");
                UC_ProjectPanel.RefreshItems();
            }
        }

        void BTN_RTLView_Click(object sender, EventArgs e)
        {
            NavigateTo<LoggingDataManager.RTL.RTLPanel>();
        }

        void BTN_CurveSetting_Click(object sender, EventArgs e)
        {
            NavigateTo<LoggingDataManager.CurveSettings.CurveSetting>();
        }

        public T NavigateTo<T>() where T : UserControl
        {
            if (panelEx3.Controls.Count != 0)
            {
                #region ReserveControls
                GlobalControlCache.ReserveControl(panelEx3.Controls[0]);
                #endregion
            }
            panelEx3.Controls.Clear();
            if (GlobalControlCache.ExistControl(typeof(T)))
            {
                panelEx3.Controls.Add(GlobalControlCache.GetInstance<T>());
                return GlobalControlCache.GetInstance<T>();
            }
            else
            {
                T a = Activator.CreateInstance<T>();
                panelEx3.Controls.Add(a);
                a.Dock = DockStyle.Fill;
                return a;
            }
        }

        public void ShowInStatusBar(string message)
        {
            labelItem1.Text = message;
        }
        public void UpdateUI()
        {

        }

        public Model.Project CurrentProject { get; set; }
        #region Controls
        LeftPanel.ProjectPanel UC_ProjectPanel=null;
        LeftPanel.DevicePanel UC_DevicePanel = null;
        #endregion
    }
}