using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace LoggingDataManager.RTL
{
    public partial class DataSourceConfigPanel : UserControl
    {
        public DataSourceConfigPanel()
        {
            InitializeComponent();
            dataGridViewX1.CellEndEdit += new DataGridViewCellEventHandler(dataGridViewX1_CellContentClick);
            dataGridViewX1.CellContentClick += new DataGridViewCellEventHandler(dataGridViewX1_CellContentClick);
            dataGridViewX1.CellContentDoubleClick += new DataGridViewCellEventHandler(dataGridViewX1_CellContentClick);
        }
        List<Model.Curve> curveList=null;
        List<Model.Device> deviceList=null;
        Dictionary<Guid, DataGridViewComboBoxCell> tableOfComboBoxes = new Dictionary<Guid, DataGridViewComboBoxCell>();

        public void SetRows(List<Model.Curve> curveList, List<Model.Device> deviceList)
        {
            this.curveList=curveList;
            this.deviceList=deviceList;
            tableOfComboBoxes.Clear();
            dataGridViewX1.Rows.Clear();
            for (int i = 0; i < curveList.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                Model.Device device = deviceList.Find((de) => { return de.CurveId == curveList[i].Id; });
                DataGridViewLabelXCell cell1 = new DataGridViewLabelXCell();
                cell1.Value = curveList[i].CurveName;
                DataGridViewLabelXCell cell2 = new DataGridViewLabelXCell();
                DataGridViewLabelXCell cell3 = new DataGridViewLabelXCell();
                if (device != null)
                {
                    cell2.Value = device.Name;
                    cell3.Value = device.SamplingRate;
                }
                else
                {
                    cell2.Value = "未设定";
                    cell3.Value = "未设定";
                }
                DataGridViewComboBoxCell cell4 = new DataGridViewComboBoxCell();
                cell4.Tag = curveList[i].Id;
                tableOfComboBoxes.Add(curveList[i].Id, cell4);
                cell4.Items.AddRange(new string[1] { Data.NetDataFetcher.Instance.ToString()});
                cell4.Value = Data.NetDataFetcher.Instance.ToString();
                Data.DataFetcher fetcher= GlobalTable.GlobalTables.Instance.GetFetcher(curveList[i].Id);
                if (fetcher != null)
                {
                    cell4.Value = fetcher.ToString();
                }
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
               dataGridViewX1.Rows.Add(row);
            }
        }
        void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public Dictionary<Guid, string> GetCurveFetcherMap()
        {
            Dictionary<Guid, string> dic = new Dictionary<Guid, string>();
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                DataGridViewComboBoxCell cb = dataGridViewX1.Rows[i].Cells["DataSource"] as DataGridViewComboBoxCell;
                if (cb != null && cb.Value != null)
                {
                    Guid id = (Guid)cb.Tag;
                    dic.Add(id, tableOfComboBoxes[id].Value.ToString());
                }
            }
            return dic;
        }

        
    }
}
