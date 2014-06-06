using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

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
        private void showTable(BooleanFuntionWithInputDistortion table)
        {
            DataView v = TruthTableView.GetView(table);
            tableGridView.DataSource = v;
            foreach (DataGridViewRow row in tableGridView.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
            tableGridView.AutoResizeRowHeadersWidth(
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string[] text;// = new string[1];
            text = textBoolFunction.Lines;
            //text[0] = "x[0] || x[1] || x[2] && x[3]";
            int bitsInput = Convert.ToInt32(numericDigitsCount.Value);
            showTable(new BooleanFunctionAnalytic(bitsInput, text.Length, text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int digitsInput = 4, digitsOutput = 1;
            double[] distortionto1Probability = { 0.0, 0.0, 0.0, 0.0 };
            double[] distortionto0Probability = { 0.0, 0.0, 0.0, 0.0 };
            double[] distortiontoInverseProbability = { 0.5, 0.5, 0.5, 0.5 };
            double[] zeroProbability = { 0.5, 0.5, 0.5, 0.5 };
            string[] func = new string[1];
            func[0] = "(x[0] ^ x[1]) ^ (x[2] ^ x[3])";
            var f = new BooleanFunctionAnalytic(digitsInput, digitsOutput, func);
            f.SetDistortionProbabilitiesVectors(distortionto0Probability, distortionto1Probability, distortiontoInverseProbability);
            ProbabilitiesGxyCalc pGxy = new ProbabilitiesGxyCalc(f, zeroProbability);
            var actual = pGxy.GetGprobabilitesResult(new BitArray(digitsOutput, true));
            var actual1 = pGxy.GetGprobabilitesResult(new BitArray(digitsOutput, false));
            var Ge = actual1.Gce + actual.Gce + actual1.Gee + actual.Gee;
            var G = Ge + actual.G0 + actual.Gc + actual1.Gc;
            string[] func1 = new string[1];
            string[] func2 = new string[1];
            func1[0] = "(x[0] ^ x[1]) ^ x[2]";
            func2[0] = "x[0] ^ x[1]";
            var digitsInputf1 = 3;
            var digitsInputf2 = 2;
            var f1 = new BooleanFunctionAnalytic(digitsInputf1, digitsOutput, func1);
            var f2 = new BooleanFunctionAnalytic(digitsInputf2, digitsOutput, func2);
            InputDistortionProbabilities inpDist = 
                new InputDistortionProbabilities(distortionto0Probability, distortionto1Probability,
                    distortiontoInverseProbability, zeroProbability);
            ProbGxyCalcSuperposition pSprPos = new ProbGxyCalcSuperposition(f1, f2, inpDist);
            var actual2 = pSprPos.GetGprobabilitesResult(new BitArray(digitsOutput, true));
            var actual3 = pSprPos.GetGprobabilitesResult(new BitArray(digitsOutput, false));
        }
     }
}
