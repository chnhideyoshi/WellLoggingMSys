namespace LoggingDataManager.PublicControls
{
    partial class DeleteForm<T>
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
            this.listViewEx1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.BTN_Cancel = new DevComponents.DotNetBar.ButtonX();
            this.BTN_Delete = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.listViewEx1);
            this.panelEx1.Controls.Add(this.BTN_Cancel);
            this.panelEx1.Controls.Add(this.BTN_Delete);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(650, 342);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // listViewEx1
            // 
            this.listViewEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listViewEx1.Border.Class = "ListViewBorder";
            this.listViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx1.FullRowSelect = true;
            this.listViewEx1.Location = new System.Drawing.Point(12, 12);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(626, 283);
            this.listViewEx1.TabIndex = 3;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTN_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BTN_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTN_Cancel.Location = new System.Drawing.Point(337, 301);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(75, 23);
            this.BTN_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTN_Cancel.TabIndex = 2;
            this.BTN_Cancel.Text = "È¡Ïû";
            // 
            // BTN_Delete
            // 
            this.BTN_Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTN_Delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BTN_Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTN_Delete.Location = new System.Drawing.Point(227, 301);
            this.BTN_Delete.Name = "BTN_Delete";
            this.BTN_Delete.Size = new System.Drawing.Size(75, 23);
            this.BTN_Delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTN_Delete.TabIndex = 1;
            this.BTN_Delete.Text = "É¾³ý";
            // 
            // DeleteForm
            // 
            this.ClientSize = new System.Drawing.Size(650, 342);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DeleteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "É¾³ýÇúÏß";
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX BTN_Cancel;
        private DevComponents.DotNetBar.ButtonX BTN_Delete;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx1;
    }
}