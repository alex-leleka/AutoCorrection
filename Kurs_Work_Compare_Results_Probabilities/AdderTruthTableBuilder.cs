using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;
using DotNetUtils;

namespace Diplom_Work_Compare_Results_Probabilities
{
    class AdderTruthTableBuilder
    {
        private readonly int _inputDigits; // size of One operand in bits, actually adder has 2 oprands
        private int _resultDigits; // size of result in bits

        public AdderTruthTableBuilder(int addendBitsCount, int resultDigitsInt)
        {
            _inputDigits = 2*addendBitsCount;
            _resultDigits = resultDigitsInt;
        }

        public AdderTruthTableBuilder(int addendBitsCount)
        {
            _inputDigits = 2 * addendBitsCount;
            _resultDigits = addendBitsCount + 1;
        }

        public List<BitArray> GetTable()
        {
            List<BitArray> table = new List<BitArray>();
            int addendBitsCount = _inputDigits / 2;
            int maxOperandBorder = 1 << _inputDigits;
            int opBitMask = 1 << addendBitsCount - 1;
            for (int operand = 0; operand < maxOperandBorder; ++operand)
            {
                int op1 = opBitMask & operand;
                int op2 = opBitMask & (operand >> addendBitsCount);
                int result = op1 + op2;
                BitArray resultBitArray = result.ToBinary(_resultDigits);
                table.Add(resultBitArray);
            }
            return table;
        }

        public AdderTruthTable BuildTable()
        {
            int addendBitsCount = _inputDigits / 2;
            return new AdderTruthTable(addendBitsCount);
        }
    }
    public class AdderTruthTable : BooleanFuntionWithInputDistortion
    {
        protected List<BitArray> FunctionValues;
        public AdderTruthTable(int addendBitsCount)
            : base(2 * addendBitsCount, addendBitsCount + 1)
        {
            int bitsCount = 2 * addendBitsCount;
            int linesCount = 1 << bitsCount;// = 2 ipower of inputDigits
            FunctionValues = BuildTable(addendBitsCount, addendBitsCount + 1);
        }

        public AdderTruthTable(AdderTruthTable table)
            : base(table.InputNumberOfDigits, table.OutputNumberOfDigits)
        {
            FunctionValues = table.FunctionValues;
        }

        private List<BitArray> BuildTable(int addendBitsCount, int resultDigitsInt)
        {
            var builder = new AdderTruthTableBuilder(addendBitsCount, resultDigitsInt);
            return builder.GetTable();
        }

        // return f(i-th operand)
        public override BitArray GetResultByLineIndex(ulong index)
        {
            return FunctionValues[Convert.ToInt32(index)];
        }

        public BitArray GetResultByLineIndex(int index)
        {
            return FunctionValues[index];
        }

        // return f(operand)
        public override BitArray GetResult(BitArray operand)
        {
            if (operand.Length > 31)
                throw new ArgumentException("Argument length shall be at most 31 bits.");
            int[] array = new int[1];
            operand.CopyTo(array, 0);
            return FunctionValues[array[0]];
        }
    }
    public class BitAdderTruthTable : AdderTruthTable
    {
        private AdderTruthTable _table;
        private readonly int _bitIndex;
        public BitAdderTruthTable(int bitIndex, AdderTruthTable table)
            : base(table)
        {
            _table = table;
            _outputNumberOfDigits = 1;
            _bitIndex = bitIndex;
        }
        // return f(i-th operand)
        public override BitArray GetResultByLineIndex(ulong index)
        {
            return new BitArray(1, FunctionValues[Convert.ToInt32(index)][_bitIndex]);
        }
        // return f(operand)
        public override BitArray GetResult(BitArray operand)
        {
            if (operand.Length > 31)
                throw new ArgumentException("Argument length shall be at most 31 bits.");
            int[] array = new int[1];
            operand.CopyTo(array, 0);
            return new BitArray(1, FunctionValues[array[0]][_bitIndex]);
        }
    }
}
