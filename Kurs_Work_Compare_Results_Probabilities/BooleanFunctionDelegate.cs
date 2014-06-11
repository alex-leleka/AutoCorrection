using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Diplom_Work_Compare_Results_Probabilities.TruthTable
{
    class BooleanFunctionDelegate : BooleanFuntionWithInputDistortion
    {
        private Func<BitArray, BitArray> _boolFunction;
        public BooleanFunctionDelegate(int inputNumberOfDigits, int outputNumberOfDigits, Func<BitArray, BitArray> boolFunctionDelegate)
            : base(inputNumberOfDigits, outputNumberOfDigits)
        {
            _boolFunction = boolFunctionDelegate;
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
                result[i] = _boolFunction(operand)[i];
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
                result[i] = _boolFunction(operand)[i];
            }
            return result;
        }
    }
}
