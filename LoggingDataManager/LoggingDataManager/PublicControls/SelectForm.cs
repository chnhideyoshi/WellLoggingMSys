using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Reflection;
using DevComponents.DotNetBar.Controls;
using System.Collections;
namespace LoggingDataManager.PublicControls
{
    public partial class SelectForm<T> : DevComponents.DotNetBar.Office2007Form where T:Model.BaseObject
    {
        public SelectForm()
        {
            InitializeComponent();
            LV_Main.DoubleClick += new EventHandler(LV_Main_DoubleClick);
        }

        void LV_Main_DoubleClick(object sender, EventArgs e)
        {
            SelectObject();
        }

        private void SelectObject()
        {
            if (LV_Main.SelectedItems.Count > 0)
            {
                Guid id = (Guid)LV_Main.SelectedItems[0].Tag;
                SelectedObject = Model.DataHelper.GetObjectById<T>(id);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Î´Ñ¡ÖÐÏî£¡");
                this.DialogResult = DialogResult.Cancel;
            }
           
        }
        public T SelectedObject { get; set; }
        public void SetList<T1>(IList<T1> objList) where T1 : Model.BaseObject
        {
            InitColumns(typeof(T1));
            InitRows<T1>(objList);
        }

        private void InitRows<T2>(IList<T2> list) where T2 : Model.BaseObject
        {
            PropertyInfo[] pis = typeof(T2).GetProperties();
            if (list != null && list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string[] values = SelectForm<T2>.GetAllValue<T2>(list[i]);
                    ListViewItem item = new ListViewItem(values);
                    item.Tag = list[i].Id;
                    LV_Main.Items.Add(item);
                }
            }
        }

        private void InitColumns(Type type)
        {
            LV_Main.Columns.Clear();
            LV_Main.Items.Clear();
            PropertyInfo[] info = type.GetProperties();
            for (int i = 0; i < info.Length; i++)
            {
                LV_Main.Columns.Add(info[i].Name,Model.BaseObject.GetRealName(info[i]));
            }
        }

        public static string[] GetAllValue<T1>(object p) where T1 : Model.BaseObject
        {
            System.Reflection.PropertyInfo[] pis = typeof(T1).GetProperties();
            string[] values = new string[pis.Length];
            for (int i = 0; i < pis.Length; i++)
            {
                values[i] = pis[i].GetValue(p, null).ToString();
            }
            return values;
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            SelectObject();
        }
    }
}