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
namespace Diplom_Work_Compare_Results_Probabilities
{
    public partial class BoolFuncHandInput : UserControl
    {
        Action<BooleanFuntionWithInputDistortion> _bfProxy;
        public BoolFuncHandInput(Action<BooleanFuntionWithInputDistortion> bfProxy)
        {
            _bfProxy = bfProxy;
            InitializeComponent();
        }

        private void AcceptAnaliticFucntion_Click(object sender, EventArgs e)
        {
            if(textBoolFunction.Text.Trim().Length < 1)
                return;
            string[] text;
            text = textBoolFunction.Lines;
            int bitsInput = Convert.ToInt32(numericDigitsCount.Value);
            BooleanFunctionAnalytic bf = new BooleanFunctionAnalytic(bitsInput, text.Length, text);
            _bfProxy(bf);
            this.FindForm().Close();
        }
    }
}
