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

namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    public partial class UserSuperpositionTruthTableInput : UserControl
    {


        public UserSuperpositionTruthTableInput()
        {
            InitializeComponent();
        }
        private BooleanFuntionWithInputDistortion _bf1;
        private BooleanFuntionWithInputDistortion _bf2;
        private InputDistortionProbabilities _inpDistProb;

        private void SetBoolFunction1(BooleanFuntionWithInputDistortion bf)
        {
            _bf1 = bf;
        }
        private void SetBoolFunction2(BooleanFuntionWithInputDistortion bf)
        {
            _bf2 = bf;
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
        private void ShowInput(UserControl control, string formCaption)
        {
            var form = new UserControlForm(control);
            if (formCaption != null && formCaption.Length > 0)
                form.Text = formCaption;
            formShow(form);
        }
        private void ViewResultButton_Click(object sender, EventArgs e)
        {
            //LoadDistortionToBoolFunction(_bf, _inpDistProb);
            var f = new ResultView();
            f.Visible = false;
            // set values for calculation of probability with table method
            f.SetInputDistProb(_inpDistProb);
            f.SetBoolFunc(_bf1);
            f.Show();
            if (f.WindowState == FormWindowState.Minimized)
                f.WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // select function input way
            if (rbAnaliticFormula.Checked)
            {
                ShowInput(new BoolFuncHandInput(SetBoolFunction1), null);
            }
            else if (rbTextFile.Checked)
            {
                ShowInput(new BooleanFunctionTextFileInput(SetBoolFunction1), "Select text file with truth table");
            }
            else if (rbTruthTable.Checked)
            {
                ShowInput(new FuncTruthTableInput(SetBoolFunction1), null);
            }
            else if (rbDllImport.Checked)
            {
                //_bf1 = new BooleanFunctionDelegate(6, 1, f6);
            }
            else if (rbAdder.Checked)
            {
                ShowInput(new AdderInputChoose(SetBoolFunction1), null);
            }
        }

        private void InputMethodChoosed_Click(object sender, EventArgs e)
        {
            if ((_bf2 == null) || (_bf1 == null))
            {
                MessageBox.Show("Please, choose function at first.");
            }
            else
            {
                // select distortion input way
                if (rbTextFileDistortion.Checked)
                {
                    ShowInput(new FileLoadDistortionProb(SetDistProb), "Select text file with input distortions");
                }
                else if (rbHandWriteDistProb.Checked)
                {
                    ShowInput(new DistortionProbHandInput(_bf1.InputNumberOfDigits + _bf2.InputNumberOfDigits - _bf2.OutputNumberOfDigits, SetDistProb), null);
                }
                ViewResultButton.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // select function input way
            if (rbAnaliticFormula.Checked)
            {
                ShowInput(new BoolFuncHandInput(SetBoolFunction2), null);
            }
            else if (rbTextFile.Checked)
            {
                ShowInput(new BooleanFunctionTextFileInput(SetBoolFunction1), "Select text file with truth table");
            }
            else if (rbTruthTable.Checked)
            {
                ShowInput(new FuncTruthTableInput(SetBoolFunction2), null);
            }
            else if (rbDllImport.Checked)
            {
                //_bf2 = new BooleanFunctionDelegate(6, 1, f6);
            }
            else if (rbAdder.Checked)
            {
                ShowInput(new AdderInputChoose(SetBoolFunction2), null);
            }
        }
    }
}
