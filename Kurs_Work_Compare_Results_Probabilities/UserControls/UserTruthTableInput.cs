using System;
using System.Collections;
using System.Windows.Forms;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    public partial class UserTruthTableInput : UserControl
    {
        private BooleanFuntionWithInputDistortion _bf;
        private InputDistortionProbabilities _inpDistProb;
        private InputWithUnitedDistortionProbabilities _inpWithUnitedDistProb;

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

        private void SetDistProb(InputWithUnitedDistortionProbabilities inpWithUnitedDistProb)
        {
            _inpWithUnitedDistProb = inpWithUnitedDistProb;
        }

        private void formShow(Form f)
        {
            f.Visible = false;
            f.Show();
            if (f.WindowState == FormWindowState.Minimized)
                f.WindowState = FormWindowState.Normal;
        }

        private void ShowInput(UserControl control, string formCaption)
        {
            var form = new UserControlForm(control);
            if (!string.IsNullOrEmpty(formCaption))
                form.Text = formCaption;
            formShow(form);
        }

        private void InputMethodChoosed_Click(object sender, EventArgs e)
        {
            if (_bf == null)
            {
                MessageBox.Show(@"Please, choose function at first.");
            }
            else
            {
                // TODO: add pass for withUnited calc(ProbabilitiesCorrLogicNetWithUnitedInputs) 
                // select distortion input way
                if (rbTextFileDistortion.Checked)
                {
                    ShowInput(new FileLoadDistortionProb(SetDistProb), @"Select text file with input distortions");
                }
                else if (rbHandWriteDistProb.Checked)
                {
                    ShowInput(new DistortionProbHandInput(_bf.InputNumberOfDigits, SetDistProb), null);
                }
                else if (rbTextFileDistWithUnitedInp.Checked)
                {
                    ShowInput(new FileLoadDistortionProbWithUnited(SetDistProb),
                        @"Select text file with input distortions of 2 levels logic network");
                }
                else if (rbTextFileDistWithUnitedInpDirect.Checked)
                {
                    ShowInput(new FileLoadDistortionProbWithUnitedDirect(SetDistProb),
                        @"Select text file with input distortions of 2 levels logic network");
                }
                ViewResultButton.Visible = true;
            }
        }

        private void ViewResultButton_Click(object sender, EventArgs e)
        {
            if (_inpWithUnitedDistProb != null)
            {
                ViewResultWithUnitedDistDirect();
                return;
            }
            LoadDistortionToBoolFunction(_bf, _inpDistProb);
            var pCalc = new ProbabilitiesGxyCalc(_bf, _inpDistProb.ZeroProbability);
            var f = new ResultView {Visible = false};
            // set values for calculation of probability with table method
            f.SetInputDistProb(_inpDistProb);
            f.SetBoolFunc(_bf);
            f.Show();
            if (f.WindowState == FormWindowState.Minimized)
                f.WindowState = FormWindowState.Normal;
        }

        private void ViewResultWithUnitedDistDirect()
        {
            var f = new ResultViewWithUnitedInputs {Visible = false};
            // set values for calculation of probability with table method
            f.SetInputDistProb(_inpWithUnitedDistProb);
            f.SetBoolFunc(_bf);
            f.Show();
            if (f.WindowState == FormWindowState.Minimized)
                f.WindowState = FormWindowState.Normal;
        }

        private void LoadDistortionToBoolFunction(BooleanFuntionWithInputDistortion f,
            InputDistortionProbabilities inputDistortionProb)
        {
            f.SetDistortionProbabilitiesVectors(inputDistortionProb.DistortionToZeroProbability,
                inputDistortionProb.DistortionToOneProbability, inputDistortionProb.DistortionToInverseProbability);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // select function input way
            if (rbAnaliticFormula.Checked)
            {
                ShowInput(new BoolFuncHandInput(SetBoolFunction), null);
            }
            else if (rbTextFile.Checked)
            {
                ShowInput(new BooleanFunctionTextFileInput(SetBoolFunction), @"Select text file with truth table");
            }
            else if (rbTruthTable.Checked)
            {
                ShowInput(new FuncTruthTableInput(SetBoolFunction), null);
            }
            else if (rbDllImport.Checked)
            {
                _bf = new BooleanFunctionDelegate(6, 1, f6and);
                Logf6and();
            }
            else if (rbAdder.Checked)
            {
                ShowInput(new AdderInputChoose(SetBoolFunction), null);
            }
        }

        public static BitArray f10(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = (x[0] & x[1] & x[2] & x[3] & x[4]) ^
                        (x[5] | x[6] | x[7] | x[8] | x[9]);
            return result;
        }

        public static BitArray f5(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = (x[5 - 5] | x[6 - 5] | x[7 - 5] | x[8 - 5] | x[9 - 5]);
            return result;
        }

        public static BitArray f6(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = (x[0] & x[1] & x[2] & x[3] & x[4]) ^
                        (x[5]);
            return result;
        }

        public static BitArray f6and(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = x[0] & x[1] & x[2] & x[3] & x[4] & x[5];
            return result;
        }

        public static void Logf6and()
        {
            Logger.WriteLine("");
            Logger.WriteLine("Bool Func");
            Logger.WriteLine("x[0] & x[1] & x[2] & x[3] & x[4] & x[5]");
        }

        public static BitArray f6xor(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = x[0] ^ x[1] ^ x[2] ^ x[3] ^ x[4] ^ x[5];
            return result;
        }

        public static void Logf6xor()
        {
            Logger.WriteLine("");
            Logger.WriteLine("Bool Func XOR");
            Logger.WriteLine("x[0] ^ x[1] ^ x[2] ^ x[3] ^ x[4] ^ x[5]");
        }

        public static BitArray f8and(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = x[0] & x[1] & x[2] & x[3] & x[4] & x[5] & x[6] & x[7];
            return result;
        }

        public static void Logf8and()
        {
            Logger.WriteLine("");
            Logger.WriteLine("Bool Func");
            Logger.WriteLine("x[0] & x[1] & x[2] & x[3] & x[4] & x[5] & x[6] & x[7]");
        }

        public static BitArray f9and(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = x[0] & x[1] & x[2] & x[3] & x[4] & x[5] & x[6] & x[7] & x[8];
            return result;
        }

        public static void Logf9and()
        {
            Logger.WriteLine("");
            Logger.WriteLine("Bool Func");
            Logger.WriteLine("x[0] & x[1] & x[2] & x[3] & x[4] & x[5] & x[6] & x[7] & x[8]");
        }

        public static BitArray f12and(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = x[0] & x[1] & x[2] & x[3] & x[4] & x[5] & x[6] & x[7] & x[8] & x[9] & x[10] & x[11];
            return result;
        }

        public static void Logf12and()
        {
            Logger.WriteLine("");
            Logger.WriteLine("Bool Func");
            Logger.WriteLine("x[0] & x[1] & x[2] & x[3] & x[4] & x[5] & x[6] & x[7] & x[8] & x[9] & x[10] & x[11]");
        }

        public static BitArray f10and(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = x[0] & x[1] & x[2] & x[3] & x[4] & x[5] & x[6] & x[7] & x[8] & x[9];
            return result;
        }

        public static void Logf10and()
        {
            Logger.WriteLine("");
            Logger.WriteLine("Bool Func");
            Logger.WriteLine("x[0] & x[1] & x[2] & x[3] & x[4] & x[5] & x[6] & x[7] & x[8] & x[9]");
        }

        public static BitArray f6Or(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = x[0] | x[1] | x[2] | x[3] | x[4] | x[5];
            return result;
        }

        public static void Logf6Or()
        {
            Logger.WriteLine("");
            Logger.WriteLine("Bool Func");
            Logger.WriteLine("x[0] | x[1] | x[2] | x[3] | x[4] | x[5]");
        }

        public static BitArray f8Or(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = x[0] | x[1] | x[2] | x[3] | x[4] | x[5] | x[6] | x[7];
            return result;
        }

        public static void Logf8Or()
        {
            Logger.WriteLine("");
            Logger.WriteLine("Bool Func");
            Logger.WriteLine("x[0] | x[1] | x[2] | x[3] | x[4] | x[5] | x[6] | x[7]");
        }

        public static BitArray f9Or(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = x[0] | x[1] | x[2] | x[3] | x[4] | x[5] | x[6] | x[7] | x[8];
            return result;
        }

        public static void Logf9Or()
        {
            Logger.WriteLine("");
            Logger.WriteLine("Bool Func");
            Logger.WriteLine("x[0] | x[1] | x[2] | x[3] | x[4] | x[5] | x[6] | x[7] | x[8]");
        }

        public static BitArray f10Or(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = x[0] | x[1] | x[2] | x[3] | x[4] | x[5] | x[6] | x[7] | x[8] | x[9];
            return result;
        }

        public static void Logf10Or()
        {
            Logger.WriteLine("");
            Logger.WriteLine("Bool Func");
            Logger.WriteLine("x[0] | x[1] | x[2] | x[3] | x[4] | x[5] | x[6] | x[7] | x[8] | x[9]");
        }

        public static BitArray f3Regular(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = (x[0] & x[1]) | (x[2] & x[1]) |(x[0] & x[2]);
            return result;
        }

        public static void Logf3Regular()
        {
            Logger.WriteLine("");
            Logger.WriteLine("Bool Func");
            Logger.WriteLine("(x[0] & x[1]) | (x[2] & x[1]) |(x[0] & x[2])");
        }

        public static BitArray f6Regular(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = (x[0] & x[1] & x[3] & x[4]) | (x[2] & x[1] & x[5] & x[4]) | (x[0] & x[2] & x[3] & x[5]);
            return result;
        }

        public static void Logf6Regular()
        {
            Logger.WriteLine("");
            Logger.WriteLine("Bool Func");
            Logger.WriteLine("(x[0] & x[1] & x[3] & x[4]) | (x[2] & x[1] & x[5] & x[4]) | (x[0] & x[2] & x[3] & x[5])");
        }

        public static BitArray f9Regular(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            result[0] = (x[0] & x[1] & x[3] & x[4] & x[6] & x[7]) | (x[2] & x[1] & x[5] & x[4] & x[8] & x[7]) | (x[0] & x[2] & x[3] & x[5] & x[6] & x[8]);
            return result;
        }

        public static void Logf9Regular()
        {
            Logger.WriteLine("");
            Logger.WriteLine("Bool Func");
            Logger.WriteLine("(x[0] & x[1] & x[3] & x[4] & x[6] & x[7]) | (x[2] & x[1] & x[5] & x[4] & x[8] & x[7]) | (x[0] & x[2] & x[3] & x[5] & x[6] & x[8])");
        }
    }
}
