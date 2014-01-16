namespace LoggingDataManager.DeviceManagement
{
    partial class NewDeviceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TB_DeviceName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.II_SamplingRate = new DevComponents.Editors.IntegerInput();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.CB_Curve = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.BTN_Cancel = new DevComponents.DotNetBar.ButtonX();
            this.BTN_New = new DevComponents.DotNetBar.ButtonX();
            this.II_Number = new DevComponents.Editors.IntegerInput();
            this.DI_Length = new DevComponents.Editors.DoubleInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.TB_Series = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.TB_Producer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.II_SamplingRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_Number)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DI_Length)).BeginInit();
            this.SuspendLayout();
            // 
            // TB_DeviceName
            // 
            // 
            // 
            // 
            this.TB_DeviceName.Border.Class = "TextBoxBorder";
            this.TB_DeviceName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TB_DeviceName.Location = new System.Drawing.Point(97, 22);
            this.TB_DeviceName.Name = "TB_DeviceName";
            this.TB_DeviceName.Size = new System.Drawing.Size(119, 21);
            this.TB_DeviceName.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(29, 25);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(62, 18);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "仪器名称:";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.II_SamplingRate);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Controls.Add(this.CB_Curve);
            this.panelEx1.Controls.Add(this.BTN_Cancel);
            this.panelEx1.Controls.Add(this.BTN_New);
            this.panelEx1.Controls.Add(this.II_Number);
            this.panelEx1.Controls.Add(this.DI_Length);
            this.panelEx1.Controls.Add(this.labelX6);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.TB_Series);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.TB_Producer);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.TB_DeviceName);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(281, 308);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            // 
            // II_SamplingRate
            // 
            // 
            // 
            // 
            this.II_SamplingRate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.II_SamplingRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.II_SamplingRate.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.II_SamplingRate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.II_SamplingRate.Location = new System.Drawing.Point(97, 221);
            this.II_SamplingRate.Name = "II_SamplingRate";
            this.II_SamplingRate.ShowUpDown = true;
            this.II_SamplingRate.Size = new System.Drawing.Size(136, 21);
            this.II_SamplingRate.TabIndex = 18;
            this.II_SamplingRate.Value = 10;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(17, 224);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(74, 18);
            this.labelX7.TabIndex = 17;
            this.labelX7.Text = "仪器采样率:";
            // 
            // CB_Curve
            // 
            this.CB_Curve.DisplayMember = "Text";
            this.CB_Curve.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CB_Curve.FormattingEnabled = true;
            this.CB_Curve.ItemHeight = 15;
            this.CB_Curve.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.CB_Curve.Location = new System.Drawing.Point(97, 191);
            this.CB_Curve.Name = "CB_Curve";
            this.CB_Curve.Size = new System.Drawing.Size(136, 21);
            this.CB_Curve.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CB_Curve.TabIndex = 16;
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTN_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTN_Cancel.Location = new System.Drawing.Point(160, 261);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(75, 23);
            this.BTN_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTN_Cancel.TabIndex = 15;
            this.BTN_Cancel.Text = "取消";
            // 
            // BTN_New
            // 
            this.BTN_New.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTN_New.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTN_New.Location = new System.Drawing.Point(54, 261);
            this.BTN_New.Name = "BTN_New";
            this.BTN_New.Size = new System.Drawing.Size(75, 23);
            this.BTN_New.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTN_New.TabIndex = 14;
            this.BTN_New.Text = "新建仪器";
            // 
            // II_Number
            // 
            // 
            // 
            // 
            this.II_Number.BackgroundStyle.Class = "DateTimeInputBackground";
            this.II_Number.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.II_Number.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.II_Number.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.II_Number.Location = new System.Drawing.Point(97, 154);
            this.II_Number.Name = "II_Number";
            this.II_Number.ShowUpDown = true;
            this.II_Number.Size = new System.Drawing.Size(136, 21);
            this.II_Number.TabIndex = 13;
            this.II_Number.Value = 1;
            // 
            // DI_Length
            // 
            // 
            // 
            // 
            this.DI_Length.BackgroundStyle.Class = "DateTimeInputBackground";
            this.DI_Length.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DI_Length.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.DI_Length.Increment = 1D;
            this.DI_Length.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.DI_Length.Location = new System.Drawing.Point(97, 121);
            this.DI_Length.Name = "DI_Length";
            this.DI_Length.ShowUpDown = true;
            this.DI_Length.Size = new System.Drawing.Size(136, 21);
            this.DI_Length.TabIndex = 12;
            this.DI_Length.Value = 0.05D;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(54, 191);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(37, 18);
            this.labelX6.TabIndex = 11;
            this.labelX6.Text = "曲线:";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(54, 157);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(37, 18);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "编号:";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(29, 124);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(62, 18);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "仪器长度:";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(54, 91);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(37, 18);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "系列:";
            // 
            // TB_Series
            // 
            // 
            // 
            // 
            this.TB_Series.Border.Class = "TextBoxBorder";
            this.TB_Series.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TB_Series.Location = new System.Drawing.Point(97, 88);
            this.TB_Series.Name = "TB_Series";
            this.TB_Series.Size = new System.Drawing.Size(119, 21);
            this.TB_Series.TabIndex = 4;
            this.TB_Series.Text = "01";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(29, 58);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(62, 18);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "生产厂家:";
            // 
            // TB_Producer
            // 
            // 
            // 
            // 
            this.TB_Producer.Border.Class = "TextBoxBorder";
            this.TB_Producer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TB_Producer.Location = new System.Drawing.Point(97, 55);
            this.TB_Producer.Name = "TB_Producer";
            this.TB_Producer.Size = new System.Drawing.Size(119, 21);
            this.TB_Producer.TabIndex = 2;
            this.TB_Producer.Text = "Aria";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "comboItem1";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "comboItem2";
            // 
            // NewDeviceForm
            // 
            this.ClientSize = new System.Drawing.Size(281, 308);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewDeviceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建仪器";
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.II_SamplingRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.II_Number)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DI_Length)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX TB_DeviceName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX TB_Producer;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX TB_Series;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.ButtonX BTN_New;
        private DevComponents.Editors.IntegerInput II_Number;
        private DevComponents.Editors.DoubleInput DI_Length;
        private DevComponents.DotNetBar.ButtonX BTN_Cancel;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CB_Curve;
        private DevComponents.Editors.IntegerInput II_SamplingRate;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
    }
}