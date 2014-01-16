namespace VirturalDeviceManager
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.添加数据源设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.删除设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动模拟ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加数据源设备ToolStripMenuItem,
            this.删除设备ToolStripMenuItem,
            this.启动模拟ToolStripMenuItem,
            this.分组ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(618, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 添加数据源设备ToolStripMenuItem
            // 
            this.添加数据源设备ToolStripMenuItem.Name = "添加数据源设备ToolStripMenuItem";
            this.添加数据源设备ToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.添加数据源设备ToolStripMenuItem.Text = "添加数据源设备";
            this.添加数据源设备ToolStripMenuItem.Click += new System.EventHandler(this.添加数据源设备ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(618, 298);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(610, 272);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // 删除设备ToolStripMenuItem
            // 
            this.删除设备ToolStripMenuItem.Name = "删除设备ToolStripMenuItem";
            this.删除设备ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.删除设备ToolStripMenuItem.Text = "删除设备";
            this.删除设备ToolStripMenuItem.Click += new System.EventHandler(this.删除设备ToolStripMenuItem_Click);
            // 
            // 启动模拟ToolStripMenuItem
            // 
            this.启动模拟ToolStripMenuItem.Name = "启动模拟ToolStripMenuItem";
            this.启动模拟ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.启动模拟ToolStripMenuItem.Text = "启动模拟";
            this.启动模拟ToolStripMenuItem.Click += new System.EventHandler(this.启动模拟ToolStripMenuItem_Click);
            // 
            // 分组ToolStripMenuItem
            // 
            this.分组ToolStripMenuItem.Name = "分组ToolStripMenuItem";
            this.分组ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.分组ToolStripMenuItem.Text = "分组";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 326);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加数据源设备ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripMenuItem 删除设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动模拟ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分组ToolStripMenuItem;
    }
}

