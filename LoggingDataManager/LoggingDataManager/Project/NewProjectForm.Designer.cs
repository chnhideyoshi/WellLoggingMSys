namespace LoggingDataManager.Project
{
    partial class NewProjectForm
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.TB_Name = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.BTN_New = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.TB_Id = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.TB_Id);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.BTN_New);
            this.panelEx1.Controls.Add(this.TB_Name);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(307, 124);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(23, 59);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "项目名称：";
            // 
            // TB_Name
            // 
            // 
            // 
            // 
            this.TB_Name.Border.Class = "TextBoxBorder";
            this.TB_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TB_Name.Location = new System.Drawing.Point(85, 59);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(177, 21);
            this.TB_Name.TabIndex = 1;
            // 
            // BTN_New
            // 
            this.BTN_New.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTN_New.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTN_New.Location = new System.Drawing.Point(109, 89);
            this.BTN_New.Name = "BTN_New";
            this.BTN_New.Size = new System.Drawing.Size(75, 23);
            this.BTN_New.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTN_New.TabIndex = 2;
            this.BTN_New.Text = "新建";
            this.BTN_New.Click += new System.EventHandler(this.BTN_New_Click);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(31, 30);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(67, 19);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "项目ID：";
            // 
            // TB_Id
            // 
            // 
            // 
            // 
            this.TB_Id.Border.Class = "TextBoxBorder";
            this.TB_Id.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TB_Id.Location = new System.Drawing.Point(85, 30);
            this.TB_Id.Name = "TB_Id";
            this.TB_Id.ReadOnly = true;
            this.TB_Id.Size = new System.Drawing.Size(177, 21);
            this.TB_Id.TabIndex = 4;
            // 
            // NewProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 124);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewProjectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建项目";
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX TB_Id;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX BTN_New;
        private DevComponents.DotNetBar.Controls.TextBoxX TB_Name;
    }
}