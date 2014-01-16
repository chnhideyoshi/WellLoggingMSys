using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace LoggingDataManager.DeviceManagement
{
    public partial class NewDeviceForm : DevComponents.DotNetBar.Office2007Form
    {
        public NewDeviceForm()
        {
            InitializeComponent();
            CB_Curve.Items.Clear();
            this.Load += new EventHandler(NewDeviceForm_Load);
            BTN_New.Click += new EventHandler(BTN_New_Click);
            BTN_Cancel.Click += new EventHandler(BTN_Cancel_Click);
        }

        void NewDeviceForm_Load(object sender, EventArgs e)
        {
            LoadCurves();
        }

        private void LoadCurves()
        {
            CB_Curve.Items.Clear();
            List<Model.Curve> list = Model.DataHelper.GetAllObject<Model.Curve>();
            for (int i = 0; i < list.Count; i++)
            {
                DevComponents.DotNetBar.ComboBoxItem item=new ComboBoxItem();
                item.Tag=list[i].Id;
                item.Text=list[i].CurveName;
                CB_Curve.Items.Add(item);
            }
        }

        void BTN_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void BTN_New_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TB_DeviceName.Text))
                {
                    Model.Device device = new Model.Device();
                    device.Id = Guid.NewGuid();
                    device.Name = TB_DeviceName.Text;
                    device.Producer = TB_Producer.Text;
                    device.Number = II_Number.Value;
                    device.Length = DI_Length.Value;
                    device.Series = TB_Series.Text;
                    device.ProjectId=Guid.Empty;
                    device.SamplingRate = II_SamplingRate.Value;
                    if (CB_Curve.SelectedItem != null)
                    {
                        device.CurveId = (Guid)((DevComponents.DotNetBar.ComboBoxItem)CB_Curve.SelectedItem).Tag;
                    }
                    Model.DataHelper.InsertObject<Model.Device>(device);
                    
                    this.DialogResult = DialogResult.OK;
                }
                else 
                {
                    MessageBox.Show("仪器名不能为空！");
                }
            }
            catch (Exception ex)
            {
                Program.SetStatusMessage(ex.Message);
            }
        }
    }
}