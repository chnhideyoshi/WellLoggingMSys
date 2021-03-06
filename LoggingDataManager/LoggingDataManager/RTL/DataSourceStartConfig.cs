﻿using System;
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
    public partial class DataSourceStartConfig : UserControl
    {
        public DataSourceStartConfig()
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
            tableOfCheckBoxes.Clear();
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
                DataGridViewLabelXCell cell4 = new DataGridViewLabelXCell();
                cell4.Tag=curveList[i].Id;
                Data.DataFetcher fe = GlobalTable.GlobalTables.Instance.GetFetcher(curveList[i].Id);
                if (fe == null)
                {
                    cell4.Value = "未设定";
                }
                else
                {
                    cell4.Value = fe.ToString();
                }

                //DataGridViewLabelXCell cell5 = new DataGridViewLabelXCell();
                //cell5.Tag = curveList[i].Id;
                //if (fe is Data.NetDataFetcher)
                //    cell5.Value = (fe as Data.NetDataFetcher).GetFetcherState(curveList[i].Id);
                //else
                //    cell5.Value = "位置";

                DataGridViewCheckBoxCell cell6 = new DataGridViewCheckBoxCell();
                tableOfCheckBoxes.Add(curveList[i].Id, cell6);
                cell6.Tag = curveList[i].Id;
                //if (cell5.Value.ToString() == "传输中")
                //{
                //    cell6.Value = true;
                //}

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
               // row.Cells.Add(cell5);
                row.Cells.Add(cell6);
                dataGridViewX1.Rows.Add(row);
            }
        }

        void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewX1.ColumnCount-1)
            {
                dataGridViewX1.EndEdit();
                if (dataGridViewX1.Rows[e.RowIndex].Cells["DataSource"].Value.ToString() == "未设定")
                {
                    dataGridViewX1.Rows[e.RowIndex].Cells["Started"].Value = false;
                }
            }
        }

        public ProcessManager.StartInfo StartInfo
        {
            get
            {
                return GetStartInfo();
            }
        }

        private ProcessManager.StartInfo GetStartInfo()
        {
            ProcessManager.StartInfo startInfo = new ProcessManager.StartInfo();
            List<Guid> list = new List<Guid>();
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cbk = dataGridViewX1.Rows[i].Cells["Started"] as DataGridViewCheckBoxCell;
                if (cbk != null && cbk.Value != null && (bool)cbk.Value)
                {
                    Guid id = (Guid)cbk.Tag;
                    list.Add(id);
                }
            }
            startInfo.IdList = list;
            startInfo.curveList = this.curveList;
            startInfo.deviceList = this.deviceList;
            return startInfo;
        }

        public List<Guid> GetChoosenCurves()
        {
            List<Guid> dic = new List<Guid>();
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cbk = dataGridViewX1.Rows[i].Cells["Started"] as DataGridViewCheckBoxCell;
                if (cbk != null && cbk.Value != null && (bool)cbk.Value)
                {
                    Guid id = (Guid)cbk.Tag;
                    dic.Add(id);
                }
            }
            return dic;
        }
    }
}
