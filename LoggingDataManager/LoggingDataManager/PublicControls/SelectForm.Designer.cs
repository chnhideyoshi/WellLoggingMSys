namespace LoggingDataManager.PublicControls
{
    partial class SelectForm<T>
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
            this.LV_Main = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.BTN_OK = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // LV_Main
            // 
            this.LV_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.LV_Main.Border.Class = "ListViewBorder";
            this.LV_Main.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LV_Main.Border.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LV_Main.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LV_Main.FullRowSelect = true;
            this.LV_Main.GridLines = true;
            this.LV_Main.Location = new System.Drawing.Point(0, 0);
            this.LV_Main.MultiSelect = false;
            this.LV_Main.Name = "LV_Main";
            this.LV_Main.Scrollable = false;
            this.LV_Main.ShowItemToolTips = true;
            this.LV_Main.Size = new System.Drawing.Size(578, 354);
            this.LV_Main.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.LV_Main.TabIndex = 25;
            this.LV_Main.UseCompatibleStateImageBehavior = false;
            this.LV_Main.View = System.Windows.Forms.View.Details;
            // 
            // BTN_OK
            // 
            this.BTN_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTN_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTN_OK.Location = new System.Drawing.Point(268, 360);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTN_OK.TabIndex = 26;
            this.BTN_OK.Text = "确定";
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // SelectForm
            // 
            this.ClientSize = new System.Drawing.Size(578, 393);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.LV_Main);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择项目";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ListViewEx LV_Main;
        private DevComponents.DotNetBar.ButtonX BTN_OK;
    }
}