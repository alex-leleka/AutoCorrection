using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    public partial class DistortionProbHandInput : UserControl
    {
        Action<InputDistortionProbabilities> _disProbProxy;

        private int _inputDigitsCount;
        public DistortionProbHandInput(int inputDigitsCount, Action<InputDistortionProbabilities> disProbProxy)
        {
            _inputDigitsCount = inputDigitsCount;
            InitializeComponent();
            if (inputDigitsCount - dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Add(inputDigitsCount - dataGridView1.Rows.Count);
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
            _disProbProxy = disProbProxy;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] distortionto1Probability = new double[_inputDigitsCount];
            double[] distortionto0Probability = new double[_inputDigitsCount];
            double[] distortiontoInverseProbability = new double[_inputDigitsCount];
            double[] zeroProbability = new double[_inputDigitsCount];
            double[][] probabilArrays = new double[dataGridView1.Columns.Count][];
            probabilArrays[1] = distortionto0Probability;
            probabilArrays[2] = distortionto1Probability;
            probabilArrays[3] = distortiontoInverseProbability;
            probabilArrays[0] = zeroProbability;
            for (int i = 0; i < _inputDigitsCount; i++)
            {
                for (int columnIndex = 0; columnIndex < dataGridView1.Columns.Count; columnIndex++)
                    probabilArrays[columnIndex][i] = Convert.ToDouble(dataGridView1.Rows[i].Cells[columnIndex].Value);
            }
            _disProbProxy(new InputDistortionProbabilities(distortionto0Probability, distortionto1Probability,
                distortiontoInverseProbability, zeroProbability));
            this.FindForm().Close();
        }
    }
}
