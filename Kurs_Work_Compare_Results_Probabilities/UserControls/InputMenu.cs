using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;
using Diplom_Work_Compare_Results_Probabilities.UserControls;
namespace Diplom_Work_Compare_Results_Probabilities
{
    public partial class UserTruthTableInput : UserControl
    {
        private BooleanFuntionWithInputDistortion _bf;
        private InputDistortionProbabilities _inpDistProb;
        public UserTruthTableInput()
        {
            InitializeComponent();
        }
        private void SetBoolFunction(BooleanFuntionWithInputDistortion bf)
        {
            _bf = bf;
        }
        private void SetDistProb(InputDistortionProbabilities inpDistProb)
        {
            _inpDistProb = inpDistProb;
        }
        private void formShow(Form f)
        {
            f.Visible = false;
            f.Show();
            if (f.WindowState == FormWindowState.Minimized)
                f.WindowState = FormWindowState.Normal;
        }
        private void ShowInput(UserControl control)
        {
            var form = new UserControlForm(control);
            formShow(form);
        }
        private void InputMethodChoosed_Click(object sender, EventArgs e)
        {
            if (_bf == null)
            {
                MessageBox.Show("Please, choose functuion at first.");
            }
            else
            {
                // select distortion input way
                if (rbTextFileDistortion.Checked)
                {
                    ShowInput(new FileLoadDistortionProb(SetDistProb));
                }
                else if (rbHandWriteDistProb.Checked)
                {
                    ShowInput(new DistortionProbHandInput(_bf.InputNumberOfDigits, SetDistProb));
                }
                ViewResultButton.Visible = true;
            }
        }

        private void ViewResultButton_Click(object sender, EventArgs e)
        {
            LoadDistortionToBoolFunction(_bf, _inpDistProb);
            var pCalc = new ProbabilitiesGxyCalc(_bf, _inpDistProb.ZeroProbability);
            var f = new ResultView(pCalc);
            f.Visible = false;
            f.Show();
            if (f.WindowState == FormWindowState.Minimized)
                f.WindowState = FormWindowState.Normal;
        }
        private void LoadDistortionToBoolFunction(BooleanFuntionWithInputDistortion f, InputDistortionProbabilities inputDistortionProb)
        {
            f.SetDistortionProbabilitiesVectors(inputDistortionProb.DistortionToZeroProbability,
                inputDistortionProb.DistortionToOneProbability, inputDistortionProb.DistortionToInverseProbability);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // select function input way
            if (rbAnaliticFormula.Checked)
            {
                ShowInput(new BoolFuncHandInput(SetBoolFunction));
            }
            else if (rbTextFile.Checked)
            {
                //ShowInput(new 
            }
            else if (rbTruthTable.Checked)
            {
                ShowInput(new FuncTruthTableInput(SetBoolFunction));
            }
            else if (rbDllImport.Checked)
            {

            }
            else if (rbAdder.Checked)
            {
                ShowInput(new AdderInputChoose(SetBoolFunction));
            }
        }
    }
}
