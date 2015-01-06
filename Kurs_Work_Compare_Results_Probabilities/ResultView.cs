using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public partial class ResultView : Form
    {
        private IProbabilityGxyCalculator _pCalc;
        public ResultView(IProbabilityGxyCalculator probabilityGxyCalculator)
        {
            _pCalc = probabilityGxyCalculator;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int resultsCount = _pCalc.OutputNumberOfDigits();
            uint count = 1u << resultsCount;

            double G0 = 0, Gc = 0, Ge = 0;
            BitArray result = new BitArray(resultsCount, false);
            for (int i = 0; i < result.Count; i++)
                result[i] = false;
            double timeLeft = .0; 
            do
            {
                TimeSpan begin = Process.GetCurrentProcess().TotalProcessorTime;
                var prob = _pCalc.GetGprobabilitesResult(result);
                TimeSpan end = Process.GetCurrentProcess().TotalProcessorTime;
                timeLeft += (end - begin).TotalMilliseconds;
                dataGridView1.Rows.Add(ConvertNumberToBinary(result), prob.G0, prob.Gc + prob.Gce,
                    prob.Gee);
                Ge += prob.Gee;
                Gc += prob.Gc + prob.Gce;
                G0 = prob.G0;
                
            } while(BooleanFuntionWithInputDistortion.IncrementOperand(result));
            labelTime.Text = timeLeft + " ms.";
            textBoxG0.Text = G0.ToString();
            textBoxGc.Text = Gc.ToString();
            textBoxGe.Text = Ge.ToString();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }

        private static string ConvertNumberToBinary<T>(/*bool []*/T arr) where T : IEnumerable
        {
            string binary = "";
            foreach (var b in arr)
                if ((bool)b)
                    binary += "1";
                else
                    binary += "0";
            return binary;
        }
    }
}
