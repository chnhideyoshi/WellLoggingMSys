using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace LoggingDataManager.CurveSettings
{
    public partial class NewCurveForm : DevComponents.DotNetBar.Office2007Form
    {
        public NewCurveForm()
        {
            InitializeComponent();
            currentCurve = Model.Curve.CreateNew();
            #region InputChangedEvent
            TB_Name.TextChanged += (sender, e) =>
            {
                try
                {
                    (elementHost1.Child as LoggingDataManager.WPFGraph.ParaTable).CurveName = TB_Name.Text;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            };
            TB_Unit.TextChanged += (sender, e) =>
            {
                try
                {
                    (elementHost1.Child as LoggingDataManager.WPFGraph.ParaTable).CurveUnit = TB_Unit.Text;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            };
            DI_YMax.ValueChanged += (sender, e) =>
            {
                try
                {
                    (elementHost1.Child as LoggingDataManager.WPFGraph.ParaTable).MaxValue = DI_YMax.Value.ToString();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            };
            DI_YMin.ValueChanged += (sender, e) =>
            {
                try
                {
                    (elementHost1.Child as LoggingDataManager.WPFGraph.ParaTable).MinValue = DI_YMin.Value.ToString();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            };
            CB_Thickness.SelectedIndexChanged += (sender, e) =>
            {
                try
                {
                    (elementHost1.Child as LoggingDataManager.WPFGraph.ParaTable).Thickness = int.Parse(CB_Thickness.SelectedItem.ToString());
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            };
            CP_Color.SelectedColorChanged += (sender, e) =>
            {
                try
                {
                    (elementHost1.Child as LoggingDataManager.WPFGraph.ParaTable).CurveBackColor = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(CP_Color.SelectedColor.R, CP_Color.SelectedColor.G, CP_Color.SelectedColor.B));
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            };
            CBK_IsDashed.CheckedChanged += (sender, e) =>
            {
                try
                {
                    (elementHost1.Child as LoggingDataManager.WPFGraph.ParaTable).IsDashed = CBK_IsDashed.Checked;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            };
            #endregion
            this.Load += (sender, e) => 
            {
                SetObjToControl(currentCurve);
            };
            BTN_New.Click += (sender, e) =>
            {
                try
                {
                    SaveControlValueToObj(currentCurve);
                    if (EnableDBOperation)
                    {
                        Model.DataHelper.InsertObject<Model.Curve>(currentCurve);
                    }
                    MessageBox.Show("创建曲线成功！");
                    this.DialogResult = DialogResult.OK;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.DialogResult = DialogResult.Cancel;
                }
            };
        }
        bool enableDBOperation = true;

        public bool EnableDBOperation
        {
            get { return enableDBOperation; }
            set { enableDBOperation = value; }
        }

        Model.Curve currentCurve;

        public Model.Curve CurrentCurve
        {
            get { return currentCurve; }
            set { currentCurve = value; }
        }

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

        private void SetObjToControl(Model.Curve currentCurve)
        {
            try
            {
                TB_Id.Text = currentCurve.Id.ToString();
                TB_Name.Text = currentCurve.CurveName;
                TB_Unit.Text = currentCurve.CurveUnit;
                CB_Group.Text = currentCurve.CurveGroupIndex.ToString();
                CB_Thickness.Text = currentCurve.CurveThickness.ToString();
                CBK_IsDashed.Checked =IntToBool( currentCurve.IsDashed);
                DI_XMax.Value = currentCurve.XMaxValue;
                DI_XMin.Value = currentCurve.XMinValue;
                DI_YMax.Value = currentCurve.YMaxValue;
                DI_YMin.Value = currentCurve.YMinValue;
                CP_Color.SelectedColor = CurveSettings.CurveSetting.GetColor(currentCurve.CurveColor);
            }
            catch (Exception e)
            {
                Program.SetStatusMessage(e.Message);
            }
        }
        private Model.Curve SaveControlValueToObj(Model.Curve currentCurve)
        {
            try
            {
                currentCurve.CurveName = TB_Name.Text;
                currentCurve.CurveUnit = TB_Unit.Text;
                currentCurve.CurveGroupIndex = int.Parse(CB_Group.Text);
                currentCurve.CurveThickness = int.Parse(CB_Thickness.Text);
                currentCurve.IsDashed =BoolToInt( CBK_IsDashed.Checked);
                currentCurve.XMaxValue = DI_XMax.Value;
                currentCurve.XMinValue = DI_XMin.Value;
                currentCurve.YMaxValue = DI_YMax.Value;
                currentCurve.YMinValue = DI_YMin.Value;
                currentCurve.CurveColor = CP_Color.SelectedColor.Name;
                return currentCurve;
            }
            catch (Exception e)
            {
                Program.SetStatusMessage(e.Message);
                return currentCurve;
            }
        }
    }
}