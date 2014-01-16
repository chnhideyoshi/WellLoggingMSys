namespace LoggingDataManager.RTL
{
    partial class GraphEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphEditor));
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.BTN_ViewSetting = new DevComponents.DotNetBar.ButtonItem();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.curveEditor1 = new LoggingDataManager.WPFGraph.CurveEditor();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.SuspendLayout();
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
            this.BTN_ViewSetting,
            this.buttonItem1});
            this.ribbonBar1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(72, 880);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 2;
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
            this.elementHost1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.elementHost1.Location = new System.Drawing.Point(131, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(718, 880);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.curveEditor1;
            // 
            // buttonItem1
            // 
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItemsExpandWidth = 14;
            this.buttonItem1.Text = "保存编辑";
            // 
            // GraphEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.ribbonBar1);
            this.Controls.Add(this.elementHost1);
            this.Name = "GraphEditor";
            this.Size = new System.Drawing.Size(887, 619);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WPFGraph.CurveEditor curveEditor1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem BTN_ViewSetting;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
    }
}
