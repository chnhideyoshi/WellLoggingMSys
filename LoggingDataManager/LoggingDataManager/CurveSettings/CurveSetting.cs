using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Windows.Forms.Integration;

namespace LoggingDataManager.CurveSettings
{
    public partial class CurveSetting : UserControl
    {
        public CurveSetting()
        {
            InitializeComponent();
            InitEventHander();
           
        }

        private void InitEventHander()
        {
            this.Load += (sender, e) => 
            {
                try
                {
                    RefreshList();
                }
                catch (Exception ex)
                {
                    Program.SetStatusMessage(ex.Message);
                }
            };
            BTN_NewCurve.Click += (sender, e) =>
            {
                try
                {
                    CurveSettings.NewCurveForm form = new CurveSettings.NewCurveForm();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        RefreshList();
                    }
                }
                catch (Exception ex)
                {
                    Program.SetStatusMessage(ex.Message);
                }
            };
            BTN_DeleteCurve.Click += (sender, e) => 
            {
                try
                {
                    PublicControls.DeleteForm<Model.Curve> form = new PublicControls.DeleteForm<Model.Curve>();
                    form.SetList<Model.Curve>(Model.DataHelper.GetAllObject<Model.Curve>());
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        RefreshList();
                    }
                }
                catch(Exception ex)
                {
                    Program.SetStatusMessage(ex.Message);
                }
            };
            BTN_Modify.Click += (sender, e) =>
            {
                try
                {
                    SaveControlValueToObj();
                    Guid id = currentCurve.Id;
                    Model.DataHelper.UpdataObjectById<Model.Curve>(currentCurve);
                    RefreshList();
                    Program.SetStatusMessage("已保存修改！");
                    currentCurve = Model.DataHelper.GetObjectById<Model.Curve>(id);
                }
                catch (Exception ex)
                {
                    Program.SetStatusMessage(ex.Message);
                }
            };
        }
        void button_Click(object sender, EventArgs e)
        {
            try
            {
                DevComponents.AdvTree.Node node = sender as DevComponents.AdvTree.Node;
                Model.Curve curve = Model.DataHelper.GetObjectById<Model.Curve>((Guid)(node.Tag));
                CurrentCurve = curve;
                //ElementHost host = hosts.Find(new Predicate<ElementHost>((obj) => { return (Guid)obj.Tag == curve.Id; }));
                //hosts.ForEach(new Action<ElementHost>((obj) => { highlighter1.SetHighlightColor(obj, DevComponents.DotNetBar.Validator.eHighlightColor.None); }));
                //if (host != null)
                //{
                //    highlighter1.SetHighlightColor(host, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                //}
            }
            catch (Exception ex)
            {
                Program.SetStatusMessage(ex.Message);
            }
        }
        private void RefreshList()
        {
            //IP_Curves.Items.Clear();
            node1.Nodes.Clear();
            PL_G1.Controls.Clear();
            PL_G2.Controls.Clear();
            PL_G3.Controls.Clear();
            hosts.Clear();
            
            List<Model.Curve> list = Model.DataHelper.GetAllObject<Model.Curve>();
            if (list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    //DevComponents.DotNetBar.ButtonItem button = new DevComponents.DotNetBar.ButtonItem();
                    DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
                    node.Text = list[i].CurveName;
                    node.Tag = list[i].Id;
                    node.Image = Properties.Resources.curvesetting_curvesetingItem;
                    node.NodeClick += new EventHandler(button_Click);
                    node1.Nodes.Add(node);
                }
                RefreshGroup(list);
                groupPanel2.Enabled = true;
                BTN_Modify.Enabled = true;
            }
            else
            {
                groupPanel2.Enabled = false;
                BTN_Modify.Enabled = false;
            }
            
        }
        List<ElementHost> hosts = new List<ElementHost>();
        private void RefreshGroup(List<Model.Curve> list)
        {
            List<Model.Curve> g1list = list.FindAll(new Predicate<Model.Curve>((obj) => { return obj.CurveGroupIndex == 0; }));
            List<Model.Curve> g2list = list.FindAll(new Predicate<Model.Curve>((obj) => { return obj.CurveGroupIndex == 1; }));
            List<Model.Curve> g3list = list.FindAll(new Predicate<Model.Curve>((obj) => { return obj.CurveGroupIndex == 2; }));

            for (int i = 0; i < g1list.Count; i++)
            {
                ElementHost host = new ElementHost();
                hosts.Add(host);
                host.Height = 36;
                WPFGraph.ParaTable pt = new WPFGraph.ParaTable();
                pt.SetCurve(g1list[i]);
                host.Child = pt;
                host.Tag = g1list[i].Id;
                host.Dock = DockStyle.Top;
                PL_G1.Controls.Add(host);
            }
            for (int i = 0; i < g2list.Count; i++)
            {
                ElementHost host = new ElementHost();
                hosts.Add(host);
                host.Height = 36;
                WPFGraph.ParaTable pt = new WPFGraph.ParaTable();
                pt.SetCurve(g2list[i]);
                host.Tag = g2list[i].Id;
                host.Child = pt;
                host.Dock = DockStyle.Top;
                PL_G2.Controls.Add(host);
            }
            for (int i = 0; i < g3list.Count; i++)
            {
                ElementHost host = new ElementHost();
                hosts.Add(host);
                host.Height = 36;
                WPFGraph.ParaTable pt = new WPFGraph.ParaTable();
                pt.SetCurve(g3list[i]);
                host.Child = pt;
                host.Tag = g3list[i].Id;
                host.Dock = DockStyle.Top;
                PL_G3.Controls.Add(host);
            }
        }
        #region CurrentCurveProperty
        Model.Curve currentCurve;
        Model.Curve CurrentCurve
        {
            get { return currentCurve; }
            set
            {
                if (value == null) { return; }
                if (currentCurve == null || value.Id != currentCurve.Id)
                {
                    currentCurve = value;
                    SetObjToControl();
                }
            }
        } 
        #endregion

        private int BoolToInt(bool b)
        {
            if (b) { return 1; }
            return 0;
        }
        private bool IntToBool(int b)
        {
            if (b == 0) { return false; }
            return true;
        }

        private void SetObjToControl()
        {
            try
            {
                TB_Id.Text = currentCurve.Id.ToString();
                TB_Name.Text = currentCurve.CurveName;
                TB_Unit.Text = currentCurve.CurveUnit;
                CB_Group.Text = currentCurve.CurveGroupIndex.ToString();
                CB_Thickness.Text = currentCurve.CurveThickness.ToString();
                CBK_IsDashed.Checked =IntToBool(currentCurve.IsDashed);
                DI_XMax.Value = currentCurve.XMaxValue;
                DI_XMin.Value = currentCurve.XMinValue;
                DI_YMax.Value = currentCurve.YMaxValue;
                DI_YMin.Value = currentCurve.YMinValue;
                CP_Color.SelectedColor =GetColor(currentCurve.CurveColor);
            }
            catch (Exception e)
            {
                Program.SetStatusMessage(e.Message);
            }
        }
        private void SaveControlValueToObj()
        {
            try
            {
                currentCurve.CurveName = TB_Name.Text;
                currentCurve.CurveUnit = TB_Unit.Text;
                currentCurve.CurveGroupIndex = int.Parse(CB_Group.Text);
                currentCurve.CurveThickness = int.Parse(CB_Thickness.Text);
                currentCurve.IsDashed =BoolToInt(CBK_IsDashed.Checked);
                currentCurve.XMaxValue = DI_XMax.Value;
                currentCurve.XMinValue = DI_XMin.Value;
                currentCurve.YMaxValue = DI_YMax.Value;
                currentCurve.YMinValue = DI_YMin.Value;
                currentCurve.CurveColor = CP_Color.SelectedColor.Name;
            }
            catch (Exception e)
            {
                Program.SetStatusMessage(e.Message);
            }
        }

        public static Color GetColor(string name)
        {
            return Color.FromArgb(ToByte(name.Substring(0, 2)), ToByte(name.Substring(2, 2)), ToByte(name.Substring(4, 2)), ToByte(name.Substring(6, 2)));
        }
        public static byte ToByte(string s)
        {
            return byte.Parse(s, System.Globalization.NumberStyles.HexNumber);
        }
    }
}
