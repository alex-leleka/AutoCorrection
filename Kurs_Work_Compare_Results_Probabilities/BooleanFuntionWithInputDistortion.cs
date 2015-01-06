using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Diplom_Work_Compare_Results_Probabilities.TruthTable
{
    /// <summary>
    /// Base class for Bool function. Uses as a pointer to instance of derived class.
    /// Provides interfaces for Boolean function operands and result
    /// </summary>
    public abstract class BooleanFuntionWithInputDistortion
    {
        protected double[] _distortionToZeroProbability;
        protected double[] _distortionToOneProbability;
        protected double[] _distortionToInverseProbability;
        protected double[] _correctValueProbability;
        protected int _inputNumberOfDigits;
        protected int _outputNumberOfDigits;
        public BooleanFuntionWithInputDistortion(double[] distortionToZeroProbability,
            double[] distortionToOneProbability, double[] distortionToInverseProbability, int inputNumberOfDigits, int outputNumberOfDigits)
        {
            SetDistortionProbabilitiesVectors(distortionToZeroProbability, distortionToOneProbability, distortionToInverseProbability);
            _inputNumberOfDigits = inputNumberOfDigits;
            _outputNumberOfDigits = outputNumberOfDigits;
        }
        public BooleanFuntionWithInputDistortion(int inputNumberOfDigits, int outputNumberOfDigits)
        {
            _inputNumberOfDigits = inputNumberOfDigits;
            _outputNumberOfDigits = outputNumberOfDigits;
        }
        public int InputNumberOfDigits { get { return _inputNumberOfDigits; } }
        public int OutputNumberOfDigits { get { return _outputNumberOfDigits; } }
        public double[] DistortionToZeroProbability { 
            get { return _distortionToZeroProbability; }
            set
            {
                if (value.Length == _inputNumberOfDigits) _distortionToZeroProbability = value;
                else throw new Exception("Wrong size of distortion probability array");
            }
        }
        public int Length
        {
            get { return 1 << _inputNumberOfDigits; }
        }
        public ulong LongLength
        {
            get { return 1ul << _inputNumberOfDigits; }
        }
        /// <summary>
        /// Array of probability vectors. Index values correspond to
        /// correctValue 0,  distortionToZero 1, distortionToOne 2, distortionToInverse 3
        /// </summary>
        public double[][] ProbabilityVectors
        {
            get { return new double[][] {_correctValueProbability, _distortionToZeroProbability, _distortionToOneProbability, _distortionToInverseProbability}; }
        }
        public double[] DistortionToOneProbability { get { return _distortionToOneProbability; }
            set
            {
                if (value.Length == _inputNumberOfDigits) _distortionToOneProbability = value;
                else throw new Exception("Wrong size of distortion probability array");
            }
        }
        public double[] DistortionToInverseProbability { get { return _distortionToInverseProbability; }
            set
            {
                if (value.Length == _inputNumberOfDigits) _distortionToInverseProbability = value;
                else throw new Exception("Wrong size of distortion probability array");
            }
        }
        ///<summary>
        ///Probability of no distortions.
        ///For setting value use CorrectValueProbability = null
        ///and it will automaticly calculate new values.
        ///Note: you can not directly set CorrectValueProbability.
        ///</summary>
        public double[] CorrectValueProbability { get {
            if (_correctValueProbability == null) CalculateCorrectValueProbability(); return _correctValueProbability;
        }
            set { CalculateCorrectValueProbability(); }
        }
        public void SetDistortionProbabilitiesVectors(double[] distortionToZeroProbability,
            double[] distortionToOneProbability, double[] distortionToInverseProbability)
        {
            // creating arrays
            _distortionToInverseProbability = new double[_inputNumberOfDigits];
            _distortionToZeroProbability = new double[_inputNumberOfDigits];
            _distortionToOneProbability = new double[_inputNumberOfDigits];
            _correctValueProbability = new double[_inputNumberOfDigits];
            // copy data
            for (int i = 0; i < _inputNumberOfDigits; i++)
            {
                _distortionToZeroProbability[i] = distortionToZeroProbability[i];
                _distortionToInverseProbability[i] = distortionToInverseProbability[i];
                _distortionToOneProbability[i] = distortionToOneProbability[i];
                _correctValueProbability[i] = 1.0 - distortionToOneProbability[i] - distortionToZeroProbability[i] - distortionToInverseProbability[i];
            }
        }
        public void SetDistortionProbabilitiesVectors(InputDistortionProbabilities inpDistProb)
        {
            // creating arrays
            _distortionToInverseProbability = new double[_inputNumberOfDigits];
            _distortionToZeroProbability = new double[_inputNumberOfDigits];
            _distortionToOneProbability = new double[_inputNumberOfDigits];
            _correctValueProbability = new double[_inputNumberOfDigits];
            // copy data
            for (int i = 0; i < _inputNumberOfDigits; i++)
            {
                _distortionToZeroProbability[i] = inpDistProb.DistortionToZeroProbability[i];
                _distortionToInverseProbability[i] = inpDistProb.DistortionToInverseProbability[i];
                _distortionToOneProbability[i] = inpDistProb.DistortionToOneProbability[i];
                _correctValueProbability[i] = 1.0 - _distortionToOneProbability[i] - _distortionToZeroProbability[i] - _distortionToInverseProbability[i];
            }
        }
        private void CalculateCorrectValueProbability()
        {
            if(null == _correctValueProbability)
                _correctValueProbability = new double[_inputNumberOfDigits];
            for (int i = 0; i < _correctValueProbability.Length; i++)
            {
                _correctValueProbability[i] = 1.0 - _distortionToOneProbability[i]
                    - _distortionToZeroProbability[i] - _distortionToInverseProbability[i];
            }
        }
        public ulong GetULongLinesCount()
        {
            return 1ul << (_inputNumberOfDigits);
        }
        public int GetLinesCount()
        {
            if (_inputNumberOfDigits > 31)
                throw new Exception("Int type is narrow to store truth table lines count.");
            return 1 << (_inputNumberOfDigits);
        }
        public BitArray GetOperandByLineIndex(ulong index)
        {
            if (index >= (1ul << _inputNumberOfDigits))
                throw new Exception("Error! Operand index is too large!");
            var binaryIndex = new BitArray(BitConverter.GetBytes(index));
            var operand = new BitArray(_inputNumberOfDigits, false);
            for (int i = 0; i < operand.Length; i++)
            {
                operand[i] = binaryIndex[i];
            }
            return operand;
        }
        public BitArray GetOperandByLineIndex(int index)
        {
            return GetOperandByLineIndex(Convert.ToUInt64(index));
        }
        ///<summary>
        ///Fucntion increment inputed operand. Return true on success,
        ///return false to indicate overflow.
        ///</summary>
        static public bool IncrementOperand(BitArray bArray)
        {
            for (int i = 0; i < bArray.Length; i++)
            {
                bool previous = bArray[i];
                bArray[i] = !previous;
                if (!previous)
                {
                    // Found a clear bit - now that we've set it, we're done
                    return true;
                }
            }
            return false; // overflow
        }
        ///<summary>
        ///Fucntion decrement inputed operand. Return true on success,
        ///return false to indicate carry.
        ///</summary>
        static public bool DecrementOperand(BitArray bArray)
        {
            for (int i = 0; i < bArray.Length; i++)
            {
                bool previous = bArray[i];
                bArray[i] = !previous;
                if (previous)
                {
                    // Found a set bit, clear it
                    return true;
                }
            }
            return false; // carry
        }
        // return f(i-th operand)
        public BitArray GetResultByLineIndex(int index)
        {
            return GetResultByLineIndex(Convert.ToUInt64(index));
        }
        abstract public BitArray GetResultByLineIndex(ulong index);
        // return f(operand)
        abstract public BitArray GetResult(BitArray operand);

    }
}
