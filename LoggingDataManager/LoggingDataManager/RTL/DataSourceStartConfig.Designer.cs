namespace LoggingDataManager.RTL
{
    partial class DataSourceStartConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.CurveName = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column2 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.SamplingRate = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.DataSource = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Started = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToResizeColumns = false;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CurveName,
            this.Column2,
            this.SamplingRate,
            this.DataSource,
            this.Started});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowHeadersWidth = 29;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(558, 210);
            this.dataGridViewX1.TabIndex = 1;
            // 
            // CurveName
            // 
            this.CurveName.FillWeight = 73.09644F;
            this.CurveName.HeaderText = "曲线名";
            this.CurveName.Name = "CurveName";
            this.CurveName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CurveName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CurveName.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 105.3807F;
            this.Column2.HeaderText = "设备名";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // SamplingRate
            // 
            this.SamplingRate.FillWeight = 105.3807F;
            this.SamplingRate.HeaderText = "采样率";
            this.SamplingRate.Name = "SamplingRate";
            this.SamplingRate.Text = "";
            this.SamplingRate.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // DataSource
            // 
            this.DataSource.FillWeight = 105.3807F;
            this.DataSource.HeaderText = "数据源";
            this.DataSource.Name = "DataSource";
            this.DataSource.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataSource.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DataSource.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // Started
            // 
            this.Started.FillWeight = 105.3807F;
            this.Started.HeaderText = "启动数据源";
            this.Started.Name = "Started";
            this.Started.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Started.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DataSourceStartConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewX1);
            this.Name = "DataSourceStartConfig";
            this.Size = new System.Drawing.Size(558, 210);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn CurveName;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column2;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn SamplingRate;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn DataSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Started;


    }
}
