using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace LoggingDataManager.RTL
{
    public partial class DataSourceConfigConfirmForm : DevComponents.DotNetBar.Office2007Form
    {
        public DataSourceConfigConfirmForm()
        {
            InitializeComponent();
        }

        private void BTN_Confirm_Click(object sender, EventArgs e)
        {
            Dictionary<Guid, string> dic = dataSourceConfigPanel1.GetCurveFetcherMap();
            foreach (Guid id in dic.Keys)
            {
                string fetcherName = dic[id];
                Data.DataFetcher fetcher =GlobalTable.GlobalTables.GetFetcherByName(fetcherName);
                if (fetcher != null)
                {
                    LoggingDataManager.GlobalTable.GlobalTables.Instance.CreateConnection(id, Data.NetDataFetcher.Instance);
                }
            }
            MessageBox.Show("“—±£¥Ê…Ë÷√.");
            this.DialogResult = DialogResult.OK;
        }

        internal void SetRows(List<Model.Curve> clist, List<Model.Device> dlist)
        {
            dataSourceConfigPanel1.SetRows(clist, dlist);
        }
    }
}