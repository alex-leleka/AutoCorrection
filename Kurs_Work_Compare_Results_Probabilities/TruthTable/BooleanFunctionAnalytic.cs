using System;
using System.Collections;

namespace Diplom_Work_Compare_Results_Probabilities.TruthTable
{
    public class BooleanFunctionAnalytic : BooleanFuntionWithInputDistortion
    {
        private AnalyticFunctionBuilder _boolFunction;
        public BooleanFunctionAnalytic(int inputNumberOfDigits, int outputNumberOfDigits, string [] boolFunctions)
            : base(inputNumberOfDigits, outputNumberOfDigits)
        {
            if (boolFunctions.Length != outputNumberOfDigits)
                throw new Exception("Error! Number of boolean fuctions !=  number output digits");
            _boolFunction = new AnalyticFunctionBuilder(boolFunctions);
            Logger.Init();
            Logger.WriteLine(@"BooleanFunctionAnalytic");
            foreach (var f in boolFunctions)
            {
                Logger.WriteLine(f);
            }
        }
        // return f(i-th operand)
        public override BitArray GetResultByLineIndex(ulong index)
        {
            BitArray operand = new BitArray(_inputNumberOfDigits);
            BitArray bitIndex = new BitArray(BitConverter.GetBytes(index));
            // maybe bitIndex size != inputNumberOfDigits, so we copy bits in 
            // array with correct size
            for (int i = 0; i < operand.Length; i++)
            {
                operand[i] = bitIndex[i];
            }
            var result = new BitArray(OutputNumberOfDigits, false);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = _boolFunction[i](operand);
            }
            return result;
        }
        // return f(operand)
        public override BitArray GetResult(BitArray operand)
        {
            if (operand.Length > 64)
                throw new ArgumentException("Argument length shall be at most 64 bits.");
            var result = new BitArray(OutputNumberOfDigits, false);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = _boolFunction[i](operand);
            }
            return result;
        }
    }
}
