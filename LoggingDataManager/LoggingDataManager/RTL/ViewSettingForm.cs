using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoggingDataManager.RTL
{
    public partial class ViewSettingForm : Form
    {
        public ViewSettingForm()
        {
            InitializeComponent();
        }
        public ViewSettingForm(WPFGraph.Graph graph)
        {
            InitializeComponent();
            Graph = graph;
            InitEventHandler();
            Init();
        }

        private void Init()
        {
            if(Graph==null){return;}
            SL_VerticalCellsCount.Value = Graph.VerticalCellsCount;
            SL_VerticalCellsCount.Text = SL_VerticalCellsCount.Value.ToString();
            SL_VerticalCellsCount.Minimum = 0;
            SL_VerticalCellsCount.Maximum = 50;
            SL_VerticalCellsCount.Step = 1;
            SL_HorizontalCellsCount.Value = Graph.HorizontalCellsCount;
            SL_HorizontalCellsCount.Text = SL_HorizontalCellsCount.Value.ToString();
            SL_HorizontalCellsCount.Minimum = 0;
            SL_HorizontalCellsCount.Maximum = 50;
            SL_HorizontalCellsCount.Step = 1;
            DI_BaseValue.Value = Graph.CurveXMinValue;
            DI_DeltaValue.Value = Graph.UnitLength;
            CKB_ShowGridLine.Checked = Graph.ShowGridLine;
        }

        private void InitEventHandler()
        {
            SL_HorizontalCellsCount.ValueChanged += new EventHandler(SL_HorizontalCellsCount_ValueChanged);
            SL_VerticalCellsCount.ValueChanged += new EventHandler(SL_VerticalCellsCount_ValueChanged);
            DI_BaseValue.ValueChanged += new EventHandler(DI_BaseValue_ValueChanged);
            DI_DeltaValue.ValueChanged += new EventHandler(DI_DeltaValue_ValueChanged);
            CKB_ShowGridLine.CheckedChanged += new EventHandler(CKB_ShowGridLine_CheckedChanged);
        }

        void CKB_ShowGridLine_CheckedChanged(object sender, EventArgs e)
        {
            Graph.ShowGridLine = CKB_ShowGridLine.Checked;
        }

        void DI_DeltaValue_ValueChanged(object sender, EventArgs e)
        {

            Graph.UnitLength=DI_DeltaValue.Value;
        }

        void DI_BaseValue_ValueChanged(object sender, EventArgs e)
        {
            //Graph.SetBaseValue(DI_BaseValue.Value);
        }

        void SL_VerticalCellsCount_ValueChanged(object sender, EventArgs e)
        {
            SL_VerticalCellsCount.Text = SL_VerticalCellsCount.Value.ToString();
            Graph.VerticalCellsCount=(SL_VerticalCellsCount.Value);
        }

        void SL_HorizontalCellsCount_ValueChanged(object sender, EventArgs e)
        {
            SL_HorizontalCellsCount.Text = SL_HorizontalCellsCount.Value.ToString();
            Graph.HorizontalCellsCount=(SL_HorizontalCellsCount.Value);
        }
        WPFGraph.Graph Graph { get; set; }

    }
}
