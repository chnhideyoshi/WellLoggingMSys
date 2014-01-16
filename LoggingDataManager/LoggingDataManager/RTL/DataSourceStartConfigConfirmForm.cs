using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace LoggingDataManager.RTL
{
    public partial class DataSourceStartConfigConfirmForm : DevComponents.DotNetBar.Office2007Form
    {
        public DataSourceStartConfigConfirmForm()
        {
            InitializeComponent();
            try
            {
                DI_BaseValue.Value = Global.DeepPanel_BaseHeight;
                DI_DeltaValue.Value = Global.DeepPanel_CurveUnitSegment;
                II_HCC.Value = Global.GridMap_HorizontalCellsCount;
                II_VCC.Value = Global.DeepPanel_VerticalGraduationCount;
                DI_rATE.Value = 1.00;
                DI_StartHeight.Value = 0.00;
                DI_Speed.Value = 0.5;
            }
            catch { }
        }
        public DataSourceStartConfig DataSourceStartConfigPanel { get { return dataSourceConfig1; } }

        private void BTN_Ok_Click(object sender, EventArgs e)
        {
            string message=null;
            if (ValidatedAllControls(out message))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("非法数据！"+message);
            }
        }

        private bool ValidatedAllControls(out string message)
        {
            if (DI_DeltaValue.Value <= 0) { message = ""; return false; }
            if (II_HCC.Value < 2) { message = ""; return false; }
            if (II_VCC.Value < 2) { message = ""; return false; }
            if (DI_rATE.Value <= 0) { message = ""; return false; }
            if (DI_EndHeight.Value <= 0) { message = ""; return false; }
            if (DI_StartHeight.Value < 0) { message = ""; return false; }
            if (DI_StartHeight.Value >= DI_EndHeight.Value) { message = ""; return false; }
            if (DI_Speed.Value <= 0 || DI_Speed.Value >= 10) { message = ""; return false; }
            message = "";
            return true;
        }

        public double GetDeltaValue()
        {
            return DI_DeltaValue.Value;
        }
        public double GetBaseValue()
        {
            return DI_BaseValue.Value;
        }
        public int GetVerticalCountValue()
        {
            return II_VCC.Value;
        }
        public int GetHorizontalCountValue()
        {
            return II_HCC.Value;
        }
        public double GetRateValue()
        {
            return DI_rATE.Value;
        }

        public double GetStartHeight()
        {
            return DI_StartHeight.Value;
        }

        public double GetEndHeight()
        {
            return DI_EndHeight.Value;
        }

        public double GetSpeed()
        {
            return DI_Speed.Value;
        }
        
        internal void SetRows(List<Model.Curve> clist, List<Model.Device> dlist)
        {
            DataSourceStartConfigPanel.SetRows(clist, dlist);
            DI_rATE.Value = GetSutableRate(clist, DI_DeltaValue.Value * II_VCC.Value);
        }
        internal double GetSutableRate(List<Model.Curve> curveList, double reRange)
        {
            if (curveList.Count != 0)
            {
                double range = curveList[0].XMaxValue - curveList[0].XMinValue;
                if (range / reRange - 1 > 0)
                {
                    return range / reRange - 1;
                }
            }
            return 1;
        }

        public ProcessManager.StartInfo StartInfo 
        {
            get 
            {
                ProcessManager.StartInfo startInfo = DataSourceStartConfigPanel.StartInfo;
                startInfo.EndHeight = GetEndHeight();
                startInfo.StartHeight = GetStartHeight();
                startInfo.Speed = GetSpeed();
                return startInfo;
            }
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}