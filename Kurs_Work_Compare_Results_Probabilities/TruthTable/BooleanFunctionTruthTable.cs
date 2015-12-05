using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Diplom_Work_Compare_Results_Probabilities.TruthTable
{

    public class BooleanFunctionTruthTable : BooleanFuntionWithInputDistortion
    {
        private BitArray[] _resultArr;
        public BooleanFunctionTruthTable(int inputNumberOfDigits, int outputNumberOfDigits, BitArray[] resultArr)
            : base(inputNumberOfDigits, outputNumberOfDigits)
        {
            _resultArr = new BitArray[resultArr.LongLength];
            for (ulong i = 0; i < Convert.ToUInt64(resultArr.LongLength); i++)
            {
                _resultArr[i] = resultArr[i];
            }
        }
        public BooleanFunctionTruthTable(int inputNumberOfDigits, int outputNumberOfDigits)
            : base(inputNumberOfDigits, outputNumberOfDigits)
        {
        }

        public void SetResultTable(IList<int> resultsArr)
        {
            _resultArr = new BitArray[resultsArr.Count()];
            for (int i = 0; i < _resultArr.Length; i++)
            {
                _resultArr[i] = new BitArray(_outputNumberOfDigits);
                int index = 0;
                for (int mask = 1; mask != 0 && index < _outputNumberOfDigits; mask = mask << 1)
                {
                    _resultArr[i].Set(index, (resultsArr[i] & mask) != 0);
                    ++index;
                }
            }
        }

        public void SetResultTable(IList<bool[]> resultsArr)
        {
            _resultArr = new BitArray[resultsArr.Count()];
            for (int i = 0; i < _resultArr.Length; i++)
            {
                _resultArr[i] = new BitArray(resultsArr[i]);
            }
        }
        public void SetResultTable(bool[] resultsArr)
        {
            _resultArr = new BitArray[resultsArr.Count()];
            for (int i = 0; i < _resultArr.Length; i++)
            {
                _resultArr[i] = new BitArray(1, resultsArr[i]);
            }
        }
        // return f(i-th operand)
        public override BitArray GetResultByLineIndex(ulong index)
        {
            return _resultArr[index];
        }
        // return f(operand)
        public override BitArray GetResult(BitArray operand)
        {
            if (operand.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");
            int[] array = new int[1];
            operand.CopyTo(array, 0);
            return _resultArr[array[0]];
        }
    }
}
