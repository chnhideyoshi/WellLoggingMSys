using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoggingDataManager.Project
{
    public partial class NewProjectForm : Form
    {
        public NewProjectForm()
        {
            InitializeComponent(); 
            TB_Id.Text = Guid.NewGuid().ToString();
        }


        private void BTN_New_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TB_Name.Text))
            {
                try
                {
                    Model.Project project = new Model.Project();
                    project.Id = Guid.Parse(TB_Id.Text);
                    project.ProjectName = TB_Name.Text;
                    //project.ProjectCreateDate = DateTime.Now;
                    Model.DataHelper.InsertObject<Model.Project>(project);
                    
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Program.SetStatusMessage(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("需要指定名字！");
            }
        }
    }
}
