namespace LoggingDataManager.RTL
{
    partial class GraphControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CKB_Auto = new System.Windows.Forms.CheckBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.DI_SrollRate = new DevComponents.Editors.DoubleInput();
            this.SL_XRange = new DevComponents.DotNetBar.Controls.Slider();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.BTN_RefreshCurve = new DevComponents.DotNetBar.ButtonItem();
            this.BTN_BeginFetcher = new DevComponents.DotNetBar.ButtonItem();
            this.BTN_PauseAllFetcher = new DevComponents.DotNetBar.ButtonItem();
            this.BTN_ClearAllCurve = new DevComponents.DotNetBar.ButtonItem();
            this.BTN_ViewSetting = new DevComponents.DotNetBar.ButtonItem();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.graph1 = new LoggingDataManager.WPFGraph.Graph();
            this.BTN_BuildCurveSample = new DevComponents.DotNetBar.ButtonItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DI_SrollRate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.CKB_Auto);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.DI_SrollRate);
            this.panel1.Controls.Add(this.SL_XRange);
            this.panel1.Controls.Add(this.ribbonBar1);
            this.panel1.Controls.Add(this.elementHost1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 546);
            this.panel1.TabIndex = 0;
            // 
            // CKB_Auto
            // 
            this.CKB_Auto.AutoSize = true;
            this.CKB_Auto.Location = new System.Drawing.Point(882, 81);
            this.CKB_Auto.Name = "CKB_Auto";
            this.CKB_Auto.Size = new System.Drawing.Size(72, 16);
            this.CKB_Auto.TabIndex = 5;
            this.CKB_Auto.Text = "自动滚动";
            this.CKB_Auto.UseVisualStyleBackColor = true;
            this.CKB_Auto.Visible = false;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(882, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(61, 23);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "滚动比例";
            this.labelX1.Visible = false;
            // 
            // DI_SrollRate
            // 
            // 
            // 
            // 
            this.DI_SrollRate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.DI_SrollRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DI_SrollRate.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.DI_SrollRate.Increment = 0.5D;
            this.DI_SrollRate.Location = new System.Drawing.Point(882, 32);
            this.DI_SrollRate.Name = "DI_SrollRate";
            this.DI_SrollRate.ShowUpDown = true;
            this.DI_SrollRate.Size = new System.Drawing.Size(55, 21);
            this.DI_SrollRate.TabIndex = 3;
            this.DI_SrollRate.Value = 1D;
            this.DI_SrollRate.Visible = false;
            // 
            // SL_XRange
            // 
            // 
            // 
            // 
            this.SL_XRange.BackgroundStyle.Class = "";
            this.SL_XRange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SL_XRange.Location = new System.Drawing.Point(893, 103);
            this.SL_XRange.Maximum = 1000;
            this.SL_XRange.Name = "SL_XRange";
            this.SL_XRange.Size = new System.Drawing.Size(44, 439);
            this.SL_XRange.SliderOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.SL_XRange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SL_XRange.TabIndex = 2;
            this.SL_XRange.Value = 1000;
            this.SL_XRange.Visible = false;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.Class = "";
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.Class = "";
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.BTN_RefreshCurve,
            this.BTN_BeginFetcher,
            this.BTN_PauseAllFetcher,
            this.BTN_ClearAllCurve,
            this.BTN_ViewSetting});
            this.ribbonBar1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(72, 880);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 1;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.Class = "";
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.Class = "";
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // BTN_RefreshCurve
            // 
            this.BTN_RefreshCurve.Image = ((System.Drawing.Image)(resources.GetObject("BTN_RefreshCurve.Image")));
            this.BTN_RefreshCurve.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.BTN_RefreshCurve.Name = "BTN_RefreshCurve";
            this.BTN_RefreshCurve.SubItemsExpandWidth = 14;
            this.BTN_RefreshCurve.Text = "重绘曲线";
            // 
            // BTN_BeginFetcher
            // 
            this.BTN_BeginFetcher.Image = ((System.Drawing.Image)(resources.GetObject("BTN_BeginFetcher.Image")));
            this.BTN_BeginFetcher.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.BTN_BeginFetcher.Name = "BTN_BeginFetcher";
            this.BTN_BeginFetcher.SubItemsExpandWidth = 14;
            this.BTN_BeginFetcher.Text = "采集控制";
            // 
            // BTN_PauseAllFetcher
            // 
            this.BTN_PauseAllFetcher.Image = ((System.Drawing.Image)(resources.GetObject("BTN_PauseAllFetcher.Image")));
            this.BTN_PauseAllFetcher.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.BTN_PauseAllFetcher.Name = "BTN_PauseAllFetcher";
            this.BTN_PauseAllFetcher.SubItemsExpandWidth = 14;
            this.BTN_PauseAllFetcher.Text = "全部暂停";
            // 
            // BTN_ClearAllCurve
            // 
            this.BTN_ClearAllCurve.Image = ((System.Drawing.Image)(resources.GetObject("BTN_ClearAllCurve.Image")));
            this.BTN_ClearAllCurve.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.BTN_ClearAllCurve.Name = "BTN_ClearAllCurve";
            this.BTN_ClearAllCurve.SubItemsExpandWidth = 14;
            this.BTN_ClearAllCurve.Text = "清除曲线";
            // 
            // BTN_ViewSetting
            // 
            this.BTN_ViewSetting.Image = ((System.Drawing.Image)(resources.GetObject("BTN_ViewSetting.Image")));
            this.BTN_ViewSetting.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.BTN_ViewSetting.Name = "BTN_ViewSetting";
            this.BTN_ViewSetting.SubItemsExpandWidth = 14;
            this.BTN_ViewSetting.Text = "视图设定";
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(131, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(745, 880);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.graph1;
            // 
            // BTN_BuildCurveSample
            // 
            this.BTN_BuildCurveSample.Image = ((System.Drawing.Image)(resources.GetObject("BTN_BuildCurveSample.Image")));
            this.BTN_BuildCurveSample.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.BTN_BuildCurveSample.Name = "BTN_BuildCurveSample";
            this.BTN_BuildCurveSample.SubItemsExpandWidth = 14;
            this.BTN_BuildCurveSample.Text = "启动样例";
            // 
            // GraphControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "GraphControl";
            this.Size = new System.Drawing.Size(967, 546);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DI_SrollRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WPFGraph.Graph graph1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.Controls.Slider SL_XRange;
        private DevComponents.DotNetBar.ButtonItem BTN_RefreshCurve;
        private DevComponents.DotNetBar.ButtonItem BTN_BeginFetcher;
        private DevComponents.DotNetBar.ButtonItem BTN_PauseAllFetcher;
        private DevComponents.DotNetBar.ButtonItem BTN_ClearAllCurve;
        private DevComponents.DotNetBar.ButtonItem BTN_ViewSetting;
        private DevComponents.DotNetBar.ButtonItem BTN_BuildCurveSample;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DoubleInput DI_SrollRate;
        private System.Windows.Forms.CheckBox CKB_Auto;

    }
}
