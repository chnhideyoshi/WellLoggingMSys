using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace LoggingDataManager.PublicControls
{
    public partial class DeleteForm<T> : DevComponents.DotNetBar.Office2007Form where T:Model.BaseObject
    {
        public DeleteForm()
        {
            InitializeComponent();
            listViewEx1.Items.Clear();
            listViewEx1.MultiSelect = true;
            BTN_Delete.Click += new EventHandler(BTN_Delete_Click);
            BTN_Cancel.Click += new EventHandler(BTN_Cancel_Click);
        }

        void BTN_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        void BTN_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewEx1.SelectedItems.Count != 0)
                {
                    for (int i = 0; i < listViewEx1.SelectedItems.Count; i++)
                    {
                        Guid id = (Guid)listViewEx1.SelectedItems[i].Tag;
                        Model.DataHelper.DeleteObjectById<T>(id);
                    }
                    int count = listViewEx1.SelectedItems.Count;
                    for (int i = 0; i < listViewEx1.SelectedItems.Count; i++)
                    {
                        listViewEx1.Items.Remove(listViewEx1.SelectedItems[i]);
                    }
                    MessageBox.Show("É¾³ý" + count + "ÏîÍê³É£¡");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SetList<T1>(List<T1> list) where T1 :Model.BaseObject
        {
            listViewEx1.Items.Clear();
            listViewEx1.Columns.Clear();

            System.Reflection.PropertyInfo[] pis=typeof(T1).GetProperties();
            for (int i = 0; i < pis.Length; i++)
            {
                listViewEx1.Columns.Add(Model.BaseObject.GetRealName(pis[i]));
            }

            if (list != null && list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string[] values = SelectForm<T1>.GetAllValue<T1>(list[i]);
                    ListViewItem item = new ListViewItem(values);
                    item.Tag = list[i].Id;
                    listViewEx1.Items.Add(item);
                }
            }
        }

        


    }
}