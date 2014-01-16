namespace LoggingDataManager.RTL
{
    partial class ViewSettingForm
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.CKB_ShowGridLine = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.DI_BaseValue = new DevComponents.Editors.DoubleInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.DI_DeltaValue = new DevComponents.Editors.DoubleInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.SL_VerticalCellsCount = new DevComponents.DotNetBar.Controls.Slider();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SL_HorizontalCellsCount = new DevComponents.DotNetBar.Controls.Slider();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DI_BaseValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DI_DeltaValue)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.CKB_ShowGridLine);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.DI_BaseValue);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.DI_DeltaValue);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.SL_VerticalCellsCount);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.SL_HorizontalCellsCount);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(285, 169);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // CKB_ShowGridLine
            // 
            // 
            // 
            // 
            this.CKB_ShowGridLine.BackgroundStyle.Class = "";
            this.CKB_ShowGridLine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CKB_ShowGridLine.Location = new System.Drawing.Point(194, 137);
            this.CKB_ShowGridLine.Name = "CKB_ShowGridLine";
            this.CKB_ShowGridLine.Size = new System.Drawing.Size(79, 23);
            this.CKB_ShowGridLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CKB_ShowGridLine.TabIndex = 8;
            this.CKB_ShowGridLine.Text = "显示网格";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(28, 142);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(74, 18);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "起始高度值:";
            // 
            // DI_BaseValue
            // 
            // 
            // 
            // 
            this.DI_BaseValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.DI_BaseValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DI_BaseValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.DI_BaseValue.Increment = 1D;
            this.DI_BaseValue.Location = new System.Drawing.Point(108, 139);
            this.DI_BaseValue.Name = "DI_BaseValue";
            this.DI_BaseValue.ShowUpDown = true;
            this.DI_BaseValue.Size = new System.Drawing.Size(68, 21);
            this.DI_BaseValue.TabIndex = 6;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(3, 103);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(99, 18);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "每格表示高度值:";
            // 
            // DI_DeltaValue
            // 
            // 
            // 
            // 
            this.DI_DeltaValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.DI_DeltaValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DI_DeltaValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.DI_DeltaValue.Increment = 1D;
            this.DI_DeltaValue.Location = new System.Drawing.Point(108, 100);
            this.DI_DeltaValue.Name = "DI_DeltaValue";
            this.DI_DeltaValue.ShowUpDown = true;
            this.DI_DeltaValue.Size = new System.Drawing.Size(68, 21);
            this.DI_DeltaValue.TabIndex = 4;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(28, 62);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(74, 18);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "垂直刻度数:";
            // 
            // SL_VerticalCellsCount
            // 
            // 
            // 
            // 
            this.SL_VerticalCellsCount.BackgroundStyle.Class = "";
            this.SL_VerticalCellsCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SL_VerticalCellsCount.Location = new System.Drawing.Point(108, 62);
            this.SL_VerticalCellsCount.Name = "SL_VerticalCellsCount";
            this.SL_VerticalCellsCount.Size = new System.Drawing.Size(165, 18);
            this.SL_VerticalCellsCount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SL_VerticalCellsCount.TabIndex = 3;
            this.SL_VerticalCellsCount.Text = "0";
            this.SL_VerticalCellsCount.Value = 0;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(40, 22);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(62, 18);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "水平格数:";
            // 
            // SL_HorizontalCellsCount
            // 
            // 
            // 
            // 
            this.SL_HorizontalCellsCount.BackgroundStyle.Class = "";
            this.SL_HorizontalCellsCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SL_HorizontalCellsCount.Location = new System.Drawing.Point(108, 22);
            this.SL_HorizontalCellsCount.Name = "SL_HorizontalCellsCount";
            this.SL_HorizontalCellsCount.Size = new System.Drawing.Size(165, 18);
            this.SL_HorizontalCellsCount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SL_HorizontalCellsCount.TabIndex = 0;
            this.SL_HorizontalCellsCount.Text = "0";
            this.SL_HorizontalCellsCount.Value = 0;
            // 
            // ViewSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 169);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ViewSettingForm";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "视图设定";
            this.TopMost = true;
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DI_BaseValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DI_DeltaValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.DoubleInput DI_BaseValue;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DoubleInput DI_DeltaValue;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.Slider SL_VerticalCellsCount;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.Slider SL_HorizontalCellsCount;
        private DevComponents.DotNetBar.Controls.CheckBoxX CKB_ShowGridLine;

    }
}