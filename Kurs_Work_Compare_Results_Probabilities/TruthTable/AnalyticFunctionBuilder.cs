using System.Collections;
using Tech.CodeGeneration;

namespace Diplom_Work_Compare_Results_Probabilities.TruthTable
{
    
    // Creates Boolean fuctoins array from string array
    // function text sample: "x[0] || x[2] && ( x[4] || x[5] ) && ( !x[3] )"
    // logic don't check is function text correct or no. In case of wrong text 
    // class constructor or fucntion call trow exception
    class AnalyticFunctionBuilder
    {
        public delegate T Func<T>(params object[] parameterValues);
        private Sandbox _sandbox;
        private Func<bool>[] _booleanFunctions;
        public AnalyticFunctionBuilder(string[] analyticFuntion)
        {
            _sandbox = new Sandbox();
            _booleanFunctions = new Func<bool>[analyticFuntion.Length];
            for (int i = 0; i < analyticFuntion.Length; i++)
            {
                _booleanFunctions[i] = CodeGenerator.CreateCode<bool>(_sandbox,
                    "return " + analyticFuntion[i].ToLower() + ";",
                    new CodeParameter("x", typeof(BitArray))).Execute;
            }
        }

        // Use this method to call boolean fucntion
        public Func<bool> this[int outputBitIndex]
        {
            get
            {
                return _booleanFunctions[outputBitIndex];
            }
        }
    }
}
