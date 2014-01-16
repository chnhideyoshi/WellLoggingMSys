namespace LoggingDataManager.RTL
{
    partial class DataSourceConfigConfirmForm
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.BTN_Confirm = new DevComponents.DotNetBar.ButtonX();
            this.dataSourceConfigPanel1 = new LoggingDataManager.RTL.DataSourceConfigPanel();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dataSourceConfigPanel1);
            this.groupPanel1.Location = new System.Drawing.Point(12, -1);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(567, 325);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 4;
            this.groupPanel1.Text = "数据源配置";
            // 
            // BTN_Confirm
            // 
            this.BTN_Confirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTN_Confirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BTN_Confirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTN_Confirm.Location = new System.Drawing.Point(256, 330);
            this.BTN_Confirm.Name = "BTN_Confirm";
            this.BTN_Confirm.Size = new System.Drawing.Size(75, 23);
            this.BTN_Confirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTN_Confirm.TabIndex = 5;
            this.BTN_Confirm.Text = "确认配置";
            this.BTN_Confirm.Click += new System.EventHandler(this.BTN_Confirm_Click);
            // 
            // dataSourceConfigPanel1
            // 
            this.dataSourceConfigPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSourceConfigPanel1.Location = new System.Drawing.Point(0, 0);
            this.dataSourceConfigPanel1.Name = "dataSourceConfigPanel1";
            this.dataSourceConfigPanel1.Size = new System.Drawing.Size(561, 301);
            this.dataSourceConfigPanel1.TabIndex = 0;
            // 
            // DataSourceConfigConfirmForm
            // 
            this.ClientSize = new System.Drawing.Size(591, 365);
            this.Controls.Add(this.BTN_Confirm);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DataSourceConfigConfirmForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "确认配置";
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX BTN_Confirm;
        private DataSourceConfigPanel dataSourceConfigPanel1;
    }
}