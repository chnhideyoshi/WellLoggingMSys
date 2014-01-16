namespace LoggingDataManager.RTL
{
    partial class DepthStatePanel
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.microChart1 = new DevComponents.DotNetBar.MicroChart();
            this.LB_hEIGHT = new DevComponents.DotNetBar.LabelX();
            this.LB_Speed = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.LB_Speed);
            this.panelEx1.Controls.Add(this.LB_hEIGHT);
            this.panelEx1.Controls.Add(this.microChart1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(743, 170);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.StyleMouseDown.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.panelEx1.StyleMouseDown.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.panelEx1.StyleMouseDown.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.panelEx1.StyleMouseDown.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedText;
            this.panelEx1.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.StyleMouseOver.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground;
            this.panelEx1.StyleMouseOver.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground2;
            this.panelEx1.StyleMouseOver.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBorder;
            this.panelEx1.StyleMouseOver.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotText;
            this.panelEx1.TabIndex = 0;
            // 
            // microChart1
            // 
            this.microChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.microChart1.BackgroundStyle.Class = "";
            this.microChart1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.microChart1.FocusCuesEnabled = false;
            this.microChart1.Location = new System.Drawing.Point(0, 25);
            this.microChart1.MouseOverDataPointTooltipEnabled = false;
            this.microChart1.Name = "microChart1";
            this.microChart1.Size = new System.Drawing.Size(743, 102);
            this.microChart1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.microChart1.TabIndex = 0;
            this.microChart1.Text = "速度变化曲线";
            // 
            // LB_hEIGHT
            // 
            this.LB_hEIGHT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_hEIGHT.AutoSize = true;
            // 
            // 
            // 
            this.LB_hEIGHT.BackgroundStyle.Class = "";
            this.LB_hEIGHT.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LB_hEIGHT.Location = new System.Drawing.Point(564, 149);
            this.LB_hEIGHT.Name = "LB_hEIGHT";
            this.LB_hEIGHT.Size = new System.Drawing.Size(112, 18);
            this.LB_hEIGHT.TabIndex = 1;
            this.LB_hEIGHT.Text = "高度：1231.2（m）";
            // 
            // LB_Speed
            // 
            this.LB_Speed.AutoSize = true;
            // 
            // 
            // 
            this.LB_Speed.BackgroundStyle.Class = "";
            this.LB_Speed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LB_Speed.Location = new System.Drawing.Point(3, 3);
            this.LB_Speed.Name = "LB_Speed";
            this.LB_Speed.Size = new System.Drawing.Size(118, 18);
            this.LB_Speed.TabIndex = 2;
            this.LB_Speed.Text = "速度：1231.21（m）";
            // 
            // DepthStatePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx1);
            this.Name = "DepthStatePanel";
            this.Size = new System.Drawing.Size(743, 170);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX LB_hEIGHT;
        private DevComponents.DotNetBar.MicroChart microChart1;
        private DevComponents.DotNetBar.LabelX LB_Speed;
    }
}
