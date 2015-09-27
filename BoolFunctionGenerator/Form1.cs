using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoolFunctionGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void ConnectionCheckHendlerABC()
        {
            if (radioButtonA.Checked || radioButtonB.Checked)
            {
                groupBox2.Enabled = groupBox3.Enabled = true;
                groupBox4.Enabled = false;
            }
            else // radioButtonC.Checked
            {
                groupBox2.Enabled = groupBox3.Enabled = false;
                groupBox4.Enabled = true;
            }
        }

        private void radioButtonC_CheckedChanged(object sender, EventArgs e)
        {
            
            ConnectionCheckHendlerABC();
        }

        private void radioButtonA_CheckedChanged(object sender, EventArgs e)
        {
            ConnectionCheckHendlerABC();
        }

        private void radioButtonB_CheckedChanged(object sender, EventArgs e)
        {
            ConnectionCheckHendlerABC();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Prepare base function text
            String basefunc = textBoxBaseFunction.Text;
            basefunc = basefunc.Trim();
            basefunc = basefunc.Replace(@" ", String.Empty);
            basefunc = basefunc.Replace(@"\t", String.Empty);

            // Generate new fucntion
            String result = GenFunction(basefunc);
            textBoxResult.Text = result;

            // Try to save result
            if(false == checkBoxSave.Checked)
                return;
            String fileName = textBoxFileName.Text + GetPrefix() + @".txt";
            using (var sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(result);
            }
        }

        private string GetPrefix()
        {
            string prefix = @"_t";
            if (radioButtonA.Checked)
                prefix += @"A";
            else if (radioButtonB.Checked)
                prefix += @"B";
            else
            {
                prefix += @"C";
                prefix += @"_x";
                prefix += numericUpDown1.Value.ToString() + numericUpDown2.Value.ToString();
            }

            if (radioButtonA.Checked || radioButtonB.Checked)
            {
                prefix += @"_x";
                if (radioButtonX5and.Checked)
                    prefix += @"And";
                else
                    prefix += @"Or";

                if (radioButtonX6and.Checked)
                    prefix += @"And";
                else
                    prefix += @"Or";
            }

            return prefix;
        }

        /// <summary>
        /// Get 4 bits bool function as input. Adds x[4] and x[5] to places specified by connection type and with operators selected in radiobuttons. 
        /// </summary>
        /// <param name="basefunc"></param>
        /// <returns>New bool function text.</returns>
        private string GenFunction(string basefunc)
        {
            string result;
            string x4 = @"x[4]";
            string x5 = @"x[5]";

            if (radioButtonA.Checked)
            {
                const string x4Pair = @"x[2]";
                x4 = x4Pair + GetReplaceXValue(x4, radioButtonX5and);
                result = basefunc.Replace(x4Pair, "(" + x4 + ")");

                const string x5Pair = @"x[3]";
                x5 = x5Pair + GetReplaceXValue(x5, radioButtonX6and);
                result = result.Replace(x5Pair, "(" + x5 + ")");
            }
            else if (radioButtonB.Checked)
            {
                const string x4x5Pair = @"x[3]";
                x4 = x4x5Pair + GetReplaceXValue(x4, radioButtonX5and) + GetReplaceXValue(x5, radioButtonX6and);
                result = basefunc.Replace(x4x5Pair, "(" + x4 + ")");
            }
            else //radioButtonC.Checked
            {
                string opX4 = (numericUpDown1.Value == 0) ? @"|" : @"&";
                x4 = opX4 + x4;
                string opX5 = (numericUpDown2.Value == 0) ? @"|" : @"&";
                x5 = opX5 + x5;
                result = basefunc;

                if (numericUpDown1.Value == 1)
                    result = "(" + result + ")";
                result += x4;

                if (numericUpDown2.Value == 1)
                    result = "(" + result + ")";
                result += x5;
            }
            return result;
        }

        private string GetReplaceXValue(string x, RadioButton radioButtonXand)
        {
            if (radioButtonXand.Checked)
                x = @"&" + x;
            else
                x = @"|" + x;
            return x;
        }
    }
}
