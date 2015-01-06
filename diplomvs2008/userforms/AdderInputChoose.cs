using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    public partial class AdderInputChoose : UserControl
    {
        public AdderInputChoose(Action<BooleanFuntionWithInputDistortion> bfProxy)
        {
            _bfProxy = bfProxy;
            InitializeComponent();
        }
        Action<BooleanFuntionWithInputDistortion> _bfProxy;
        private void numericInpDigitsCount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbBitIndex_CheckedChanged(object sender, EventArgs e)
        {
            label1.Enabled = numericBitIndex.Enabled = cbBitIndex.Checked;
        }

        private void DigitsApply_Click(object sender, EventArgs e)
        {
            int inputDigitsCount = Convert.ToInt32(numericInpDigitsCount.Value);
            AdderTruthTableBuilder tBuilder = new AdderTruthTableBuilder(inputDigitsCount);
            var adderTable = tBuilder.BuildTable();
            if (cbBitIndex.Checked)
            {
                int bitIndex = Convert.ToInt32(numericBitIndex.Value);
                var bitAdderTable = new BitAdderTruthTable(bitIndex - 1, adderTable);
                _bfProxy(bitAdderTable);
            }
            else
            {
                _bfProxy(adderTable);
            }
            this.FindForm().Close();
        }
    }
}
