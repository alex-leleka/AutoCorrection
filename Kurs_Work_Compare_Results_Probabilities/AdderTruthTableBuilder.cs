using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace Diplom_Work_Compare_Results_Probabilities
{
    class AdderTruthTableBuilder
    {
        private int _inputDigits; // size of One operand in bits, actually adder has 2 oprands
        private int _resultDigits; // size of result in bits
        private Random _random = new Random();
        protected double[] _distortionToZeroProbability;
        protected double[] _distortionToOneProbability;
        protected double[] _distortionToInverseProbability;
        // getters and setters
        public int InputDigits
        {
            get { return _inputDigits; }
            set { _inputDigits = value; }
        }
        public int ResultDigits
        {
            get { return _resultDigits; }
            set { _resultDigits = value; }
        }
        public void SetDistortionProbabities(double[] distortionToZeroProbability,
            double[] distortionToOneProbability, double[] distortionToInverseProbability)
        {
            _distortionToZeroProbability = distortionToZeroProbability;
            _distortionToInverseProbability = distortionToInverseProbability;
            _distortionToOneProbability = distortionToOneProbability;
        }
        public AdderTruthTableBuilder(int inputDigits)
        {
            _inputDigits = inputDigits;
            _resultDigits = inputDigits + 1;
            _distortionToZeroProbability = null;
            _distortionToInverseProbability = null;
            _distortionToOneProbability = null;
        }
        public AdderTruthTable BuildTable()
        {   // TODO: refactor BuildTable mathods avoid code duplication
            if ((_inputDigits < 1) || (_resultDigits < 1))
            { throw new System.Exception("Wrong Table Builder Arguments"); }
            AdderTruthTable table = new AdderTruthTable(_inputDigits, _resultDigits, _inputDigits << 1);
            return CalculateFunctionValues(table ,null);
        }
        public AdderTruthTable BuildTable(bool[] fixedValues)
        {
            if ((_inputDigits < 1) || (_resultDigits < 1))
            { throw new System.Exception("Wrong Table Builder Arguments"); }
            AdderTruthTable table = new AdderTruthTable(_inputDigits, _resultDigits, (_inputDigits << 1)
                - fixedValues.Length);
            return CalculateFunctionValues(table, fixedValues);
        }
        public AdderTruthTable BuildDistortedTable()
        {
            if ((_distortionToInverseProbability == null)||
                (_distortionToOneProbability == null)||
                (_distortionToZeroProbability == null))
            { throw new System.Exception("Empty distirtion probabilities in TableBuilder"); }
            AdderTruthTable table = new AdderTruthTable(_inputDigits, _resultDigits, _inputDigits << 1);
            return CalculateDistotedFunctionValues(table);
        }
        private AdderTruthTable CalculateDistotedFunctionValues(AdderTruthTable table)
        {
            bool[] op1 = new bool[_inputDigits];
            bool[] op2 = new bool[_inputDigits];
            // for every line in truth table
            for (int i = 0; i < table.functionValue.Count; i++)
            {
                // calculate sum result
                SetOperand(op1, i, op1.Length);
                SetOperand(op2, i);
                // attach incoming distortion
                DoOperandsDistortion(op1, op2);
                AddOperands(table, op1, op2, i);
            }
            return table;
        }
        private AdderTruthTable CalculateFunctionValues(AdderTruthTable table, bool[] fixedValues)
        {                 
            bool[] op1 = new bool[_inputDigits];
            bool[] op2 = new bool[_inputDigits];
            // for every line in truth table
            for (int i = 0; i < table.functionValue.Count; i++)
            {
                // calculate sum result
                if(fixedValues == null)
                    SetOperand(op1, i, op1.Length);
                else
                    SetOperand(op1, i, op1.Length, fixedValues);
                SetOperand(op2, i);
                AddOperands(table, op1, op2, i);
            }
            return table;
        }

        private void AddOperands(AdderTruthTable table, bool[] op1, bool[] op2, int i)
        {
            bool carryFlag = false;
            for (int j = 0; j < _inputDigits; j++)
            {
                // data saves in reverse oder for good view in table
                table.functionValue[i][_resultDigits - j - 1] = op1[j] ^ op2[j] ^ carryFlag;
                carryFlag = op1[j] & op2[j] | (op1[j] ^ op2[j]) & carryFlag;
            }
            table.functionValue[i][0] = carryFlag;
        }

        private void SetOperand(bool[] op, int number)
        {
            SetOperand(op, number, 0);
        }
        private void SetOperand(bool[] op, int number, int startingShift)
        {
            int mask = 1 << startingShift;
            for (int i = 0; i < op.Length; i++)
            {
                op[i] = (mask & number) != 0;
                mask = mask << 1;
            }
        }
        private void SetOperand(bool[] op, int number, int startingShift, bool[] fixedValues)
        {
            
            for (int i = 0; i < fixedValues.Length; i++)
            {
                op[i] = fixedValues[i];
            }
            int mask = 1 << startingShift;
            for (int i = fixedValues.Length; i < (op.Length - fixedValues.Length); i++)
            {
                op[op.Length - i - 1] = (mask & number) != 0;
                mask = mask << 1;
            }
        }
        private void DoOperandsDistortion(bool[] op1, bool[] op2)
        {
            for(int i = 0; i < op1.Length; i++)
            {
                op1[i] = DoBitDistirtion(op1[i], i);
                op2[i] = DoBitDistirtion(op2[i], i + op1.Length);
            }
        }
        private bool DoBitDistirtion(bool bitVaule, int distortionProbabilitiesIndex)
        {
            double rand = GetRandomNumber();
            double eventProbability = _distortionToZeroProbability[distortionProbabilitiesIndex];
            if(eventProbability > rand)
            return false;
            eventProbability += _distortionToOneProbability[distortionProbabilitiesIndex];
            if (eventProbability > rand)
                return true;
            eventProbability += _distortionToInverseProbability[distortionProbabilitiesIndex];
            if (eventProbability > rand)
                return !bitVaule;
            return bitVaule;
        }
        private double GetRandomNumber()
        {
            return _random.NextDouble();
        }
        static public int[] ConvertBoolArrToIntTable(AdderTruthTable table)
        {
            int[] intTable = new int[table.functionValue.Count];
            int index = 0;
            foreach (bool[] bits in table.functionValue)
            {
                int r = 0;
                for (int i = 0; i < bits.Length; i++) if (bits[i]) r |= 1 << (bits.Length - i);
                intTable[index] = r;
                ++index;
            }
            return intTable;
        }
    }
    public class AdderTruthTable : BooleanFuntionWithInputDistortion
    {
        public List<bool[]> functionValue;
        public AdderTruthTable(int inputDigitsInt, int resultDigitsInt,int operandsBits) : base(2 * inputDigitsInt, resultDigitsInt)
        {
            int linesCount = 1 << operandsBits;// = 2 ipower of inputDigits
            functionValue = new List<bool[]>(linesCount);
            for (int i = 0; i < linesCount; i++)
            {
                functionValue.Add(new bool[OutputNumberOfDigits]);
            }
        }
        public AdderTruthTable(AdderTruthTable table)
            : base(table.InputNumberOfDigits, table.OutputNumberOfDigits)
        {
            functionValue = table.functionValue;
        }
        // return f(i-th operand)
        public override BitArray GetResultByLineIndex(ulong index)
        {
            return new BitArray(functionValue[Convert.ToInt32(index)]);
        }
        // return f(operand)
        public override BitArray GetResult(BitArray operand)
        {
            if (operand.Length > 31)
                throw new ArgumentException("Argument length shall be at most 31 bits.");
            int[] array = new int[1];
            operand.CopyTo(array, 0);
            return new BitArray(functionValue[array[0]]);
        }
    }
    public class BitAdderTruthTable : AdderTruthTable
    {
        private AdderTruthTable _table;
        private int _bitIndex;
        public BitAdderTruthTable(int bitIndex, AdderTruthTable table)
            : base(table)
        {
            _table = table;
            this._outputNumberOfDigits = 1;
            _bitIndex = bitIndex;
        }
        // return f(i-th operand)
        public override BitArray GetResultByLineIndex(ulong index)
        {
            return new BitArray(1,functionValue[Convert.ToInt32(index)][_bitIndex]);
        }
        // return f(operand)
        public override BitArray GetResult(BitArray operand)
        {
            if (operand.Length > 31)
                throw new ArgumentException("Argument length shall be at most 31 bits.");
            int[] array = new int[1];
            operand.CopyTo(array, 0);
            return new BitArray(1, functionValue[array[0]][_bitIndex]);
        }
    }
}
