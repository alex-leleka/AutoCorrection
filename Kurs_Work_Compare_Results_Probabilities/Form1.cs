using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = 5;
            AdderTruthTableBuilder attBuilder = new AdderTruthTableBuilder(size);
            AdderTruthTable tt = attBuilder.BuildTable();
            TruthTableView truthTableView = new TruthTableView(tt);
            DataView v = truthTableView.GetView();
            tableGridView.DataSource = v;
            foreach (DataGridViewRow row in tableGridView.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
            tableGridView.AutoResizeRowHeadersWidth(
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
         }

        private void button2_Click(object sender, EventArgs e)
        {
            int size = 5;
            double[] distortionto1Probability =       { 0.1, 0.0, 0.3, 0.3, 0.1, 0.1, 0.0, 0.3, 0.3, 0.1 };
            double[] distortionto0Probability =       { 0.3, 0.1, 0.2, 0.1, 0.2, 0.3, 0.1, 0.2, 0.1, 0.2 };
            double[] distortiontoInverseProbability = { 0.3, 0.5, 0.0, 0.2, 0.1, 0.3, 0.5, 0.0, 0.2, 0.1 };
            AdderTruthTableBuilder attBuilder = new AdderTruthTableBuilder(size);
            attBuilder.SetDistortionProbabities(distortionto0Probability,
                distortionto1Probability, distortiontoInverseProbability);
            AdderTruthTable tt = attBuilder.BuildDistortedTable();
            TruthTableView truthTableView = new TruthTableView(tt);
            DataView v = truthTableView.GetViewWithProbabilities();
            tableGridView.DataSource = v;
            foreach (DataGridViewRow row in tableGridView.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
            tableGridView.AutoResizeRowHeadersWidth(
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }
     }
}
