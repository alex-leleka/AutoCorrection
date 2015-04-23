using System;
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
            // TODO: pass map<BitArray, double> to GetCorrectResultProbability
            // TODO: inside GetCorrectResultProbability add corr value probs of result to map
            double pCorrectResult = pCalc.GetCorrectResultProbability();
            // TODO: add values from map to form table view 
            textBoxTableMethP.Text = pCorrectResult.ToString();
        }
    }
}
