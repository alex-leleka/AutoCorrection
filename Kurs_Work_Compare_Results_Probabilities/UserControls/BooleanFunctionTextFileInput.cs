using System;
using System.Collections.Generic;
using System.Text;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;
using System.Windows.Forms;

namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{

    public partial class BooleanFunctionTextFileInput : FileLoad
    {
        Action<BooleanFuntionWithInputDistortion> _bfProxy;
        public BooleanFunctionTextFileInput(Action<BooleanFuntionWithInputDistortion> bfProxy) 
            : base()
        {
            _bfProxy = bfProxy;
            //InitializeComponent();
        }

        protected override void DoAction()
        {
            var reader = new BoolFuncTextReader(_path);
            MessageBox.Show("open file.");
            _bfProxy(reader.GetBoolFunc());
        }
    }
}
