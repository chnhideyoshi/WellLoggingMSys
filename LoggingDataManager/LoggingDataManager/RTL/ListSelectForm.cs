using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace LoggingDataManager.RTL
{
    public partial class ListSelectForm : DevComponents.DotNetBar.Office2007Form
    {
        public ListSelectForm()
        {
            InitializeComponent();
            dataGridViewX1.CellEndEdit += new DataGridViewCellEventHandler(dataGridViewX1_CellContentClick);
            dataGridViewX1.CellContentClick += new DataGridViewCellEventHandler(dataGridViewX1_CellContentClick);
            dataGridViewX1.CellContentDoubleClick += new DataGridViewCellEventHandler(dataGridViewX1_CellContentClick);
        }

        List<Model.Curve> curveList = null;
        List<Model.Device> deviceList = null;
        Dictionary<Guid, DataGridViewCheckBoxCell> tableOfCheckBoxes = new Dictionary<Guid, DataGridViewCheckBoxCell>();

        public void SetRows(List<Model.Curve> curveList, List<Model.Device> deviceList)
        {
            this.curveList = curveList;
            this.deviceList = deviceList;
            dataGridViewX1.Rows.Clear();
            for (int i = 0; i < curveList.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                Model.Device device = deviceList.Find((de) => { return de.CurveId == curveList[i].Id; });
                DataGridViewLabelXCell cell1 = new DataGridViewLabelXCell();
                row.Cells.Add(cell1);
                cell1.Value = curveList[i].CurveName;
                DataGridViewLabelXCell cell2 = new DataGridViewLabelXCell();
                row.Cells.Add(cell2);
                DataGridViewLabelXCell cell3 = new DataGridViewLabelXCell();
                row.Cells.Add(cell3);
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

                DataGridViewLabelXCell cell4 = new DataGridViewLabelXCell();
                row.Cells.Add(cell4);
                cell4.Tag = curveList[i].Id;
                DataGridViewCheckBoxXCell cell5 = new DataGridViewCheckBoxXCell();
                row.Cells.Add(cell5);
                cell5.Tag = curveList[i].Id;
                DataGridViewCheckBoxXCell cell6 = new DataGridViewCheckBoxXCell();
                row.Cells.Add(cell6);
                cell6.Tag = curveList[i].Id;
              

                cell5.ReadOnly = true;
                Data.NetDataFetcher fe = GlobalTable.GlobalTables.Instance.GetFetcher(curveList[i].Id) as Data.NetDataFetcher;
                if (fe == null)
                {
                    cell4.Value = "未设定";
                    cell5.Value = false;
                    cell6.Value = false;
                    cell6.ReadOnly = true;
                }
                else
                {
                    cell4.Value = fe.ToString();
                    if (fe.GetFetcherState(curveList[i].Id) != Data.NetDataFetcher.UnknownStateDescription)
                    {
                        cell5.Value = true;
                        if (fe.GetFetcherState(curveList[i].Id) == Data.NetDataFetcher.PausedStateDescription)
                        {
                            cell6.Value = false;
                            cell6.ReadOnly = false;
                        }
                        else
                        {
                            cell6.Value = true;
                            cell6.ReadOnly = false;
                        }
                    }
                    else
                    {
                        cell5.Value = false;
                        cell6.Value = false;
                        cell6.ReadOnly = false;
                    }
                }

               
                
               
               
                dataGridViewX1.Rows.Add(row);
            }
        }

        void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                dataGridViewX1.EndEdit();
            }
        }


        private void BTN_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public Dictionary<Guid,bool> GetFetchingMap()
        {
            Dictionary<Guid, bool> list = new Dictionary<Guid, bool>();
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                DataGridViewCheckBoxXCell cbk = dataGridViewX1.Rows[i].Cells[5] as DataGridViewCheckBoxXCell;
                if (cbk != null && cbk.Value != null)
                {
                    Guid id = (Guid)cbk.Tag;
                    Data.NetDataFetcher fe = GlobalTable.GlobalTables.Instance.GetFetcher(id) as Data.NetDataFetcher;
                    if (fe != null)
                    {
                        list.Add(id, (bool)cbk.Value);
                    }
                }
            }
            return list;
        }
    }
}