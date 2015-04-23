using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    public partial class ResultViewWithUnitedInputs : Form
    {

        private BooleanFuntionWithInputDistortion _bfWithInpDist;
        private InputWithUnitedDistortionProbabilities _inpDistProb;
        public ResultViewWithUnitedInputs()
        {
            _inpDistProb = null;
            _bfWithInpDist = null;
            InitializeComponent();
        }

        public void SetBoolFunc(BooleanFuntionWithInputDistortion bfWithInpDist)
        {
            _bfWithInpDist = bfWithInpDist;
        }

        public void SetInputDistProb(InputWithUnitedDistortionProbabilities inpDistProb)
        {
            _inpDistProb = inpDistProb;
        }

        private void calcWithTableBased_Click(object sender, EventArgs e)
        {
            if (_inpDistProb == null || _bfWithInpDist == null)
                return;
            var pCalc = new ProbabilitiesCorrLogicNetWithUnitedInputs(_inpDistProb, _bfWithInpDist);

            var resultsProbs = pCalc.GetCorrectResultProbability();
            double pCorrectResult = resultsProbs.Sum(a => a.Value);
            // TODO: add values from map to form table view 
            textBoxTableMethP.Text = pCorrectResult.ToString();

            foreach(var kv in resultsProbs)
            {
                dataGridView1.Rows.Add(kv.Key, kv.Value);
            }
            
            foreach (DataGridViewRow row in dataGridView1.Rows.Cast<DataGridViewRow>().Where(row => !row.IsNewRow))
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }
    }
}
