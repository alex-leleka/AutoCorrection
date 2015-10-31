using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;
namespace Diplom_Work_Compare_Results_Probabilities
{
    /// <summary>
    /// Class provide values for 3 class of products.
    /// Kj0 - probabilities of correct input data products 
    /// Kjc - probabilities of auto corrected input data products 
    /// Kje - probabilities of distorted input data products
    /// </summary>
    public class ProductClasses
    {
        private double[][] _correctValueProbability; // g0
        private double[][] _autoCorrectionValueProbability; // gcaij
        private double[][] _distortedValueProbability; // geaij

        private double[][] _probalityZero;

        private BitGprobabilities[] lastBitsProbabilities;
        private int lastBitsCount = 0;

        public double[][] CorrectValueProbability
        { get { return _correctValueProbability; } }
        public double[][] AutoCorrectionValueProbability
        { get { return _autoCorrectionValueProbability; } }
        public double[][] DistortedValueProbability
        { get { return _distortedValueProbability; } }
        // p[0] probability of zero(0) in i-th bit
        // p[1] can be calculeted as p1[i] = 1 - p0[i];
        public double ProbabilityZeroAndOne(int zeroOrOne, int index)
        {
            return _probalityZero[zeroOrOne][index];
        }
        public double ProbabilityZeroAndOne(bool zeroOrOne, int index)
        {
            if (zeroOrOne)
                return _probalityZero[1][index];
            return _probalityZero[0][index];
        }

        private void CalcDeterminedDistortionProbabilities(InputDistortionProbabilities inputDistProb)
        {
            const int BinaryDigitStates = 2;
            int inputNumberOfDigits = inputDistProb.ZeroProbability.Length;
            AllocateDeterminedDistortionProbalilitiesVectors(ref _autoCorrectionValueProbability, inputNumberOfDigits);
            AllocateDeterminedDistortionProbalilitiesVectors(ref _distortedValueProbability, inputNumberOfDigits);

            double[][] digitDistortionProbability = new double[BinaryDigitStates][]; // temp variable
            digitDistortionProbability[0] = inputDistProb.DistortionToZeroProbability;
            digitDistortionProbability[1] = inputDistProb.DistortionToOneProbability;
            for (int i = 0; i < inputNumberOfDigits; i++)
            {
                for (int digit = 0; digit < BinaryDigitStates; digit++)
                {
                    // gcaij = g(const_(aij)) * p_aij
                    _autoCorrectionValueProbability[digit][i] = digitDistortionProbability[digit][i];// *ProbabilityZeroAndOne(digit, i);

                    // geaij = (g(const_(not aij)) + p inv ) * p_aij
                    _distortedValueProbability[digit][i] = (digitDistortionProbability[BinaryDigitStates - digit - 1][i] //digitDistortionProbability[!digit][i]
                            + inputDistProb.DistortionToInverseProbability[i]);// *ProbabilityZeroAndOne(digit, i);
                }
            }
        }

        private void CalcDeterminedDistortionProbabilities(BooleanFuntionWithInputDistortion truthTable)
        {
            const int binaryDigitStates = 2;
            AllocateDeterminedDistortionProbalilitiesVectors(ref _autoCorrectionValueProbability, truthTable.CorrectValueProbability.Length);
            AllocateDeterminedDistortionProbalilitiesVectors(ref _distortedValueProbability, truthTable.CorrectValueProbability.Length);

            double[][] digitDistortionProbability = new double[binaryDigitStates][]; // temp variable
            digitDistortionProbability[0] = truthTable.DistortionToZeroProbability;
            digitDistortionProbability[1] = truthTable.DistortionToOneProbability;
            for (int i = 0; i < truthTable.InputNumberOfDigits; i++)
            {
                for (int digit = 0; digit < binaryDigitStates; digit++)
                {
                    // gcaij = g(const_(aij)) * p_aij
                    _autoCorrectionValueProbability[digit][i] = digitDistortionProbability[digit][i];// *ProbabilityZeroAndOne(digit, i);

                    // geaij = (g(const_(not aij)) + p inv ) * p_aij
                    _distortedValueProbability[digit][i] = (digitDistortionProbability[binaryDigitStates - digit - 1][i] //digitDistortionProbability[!digit][i]
                            + truthTable.DistortionToInverseProbability[i]);// *ProbabilityZeroAndOne(digit, i);
                }
            }
        }
        public ProductClasses(double[] correctValueProbability, double[][] autoCorrectionValueProbability,
            double[][] distortedValueProbability, double[] probalityZero, BooleanFuntionWithInputDistortion truthTable)
        {
            _correctValueProbability = new double[2][];
            _correctValueProbability[1] = _correctValueProbability[0] = new double[truthTable.InputNumberOfDigits];
            AllocateDeterminedDistortionProbalilitiesVectors(ref _autoCorrectionValueProbability, truthTable.InputNumberOfDigits);
            AllocateDeterminedDistortionProbalilitiesVectors(ref _distortedValueProbability, truthTable.InputNumberOfDigits);
            //_probalityZero = new double[probalityZero.Length];
            for (int i = 0; i < correctValueProbability.Length; i++)
            {
                _correctValueProbability[0][i + truthTable.InputNumberOfDigits - correctValueProbability.Length] = correctValueProbability[i];
                _autoCorrectionValueProbability[0][i + truthTable.InputNumberOfDigits - correctValueProbability.Length] = 
                    autoCorrectionValueProbability[0][i];
                _autoCorrectionValueProbability[1][i + truthTable.InputNumberOfDigits - correctValueProbability.Length] = 
                    autoCorrectionValueProbability[1][i];
                _distortedValueProbability[0][i + truthTable.InputNumberOfDigits - correctValueProbability.Length] = 
                    distortedValueProbability[0][i];
                _distortedValueProbability[1][i + truthTable.InputNumberOfDigits - correctValueProbability.Length] = 
                    distortedValueProbability[1][i];
            }
            const int BinaryDigitStates = 2;
            double[][] digitDistortionProbability = new double[BinaryDigitStates][]; // temp variable
            digitDistortionProbability[0] = truthTable.DistortionToZeroProbability;
            digitDistortionProbability[1] = truthTable.DistortionToOneProbability;
            for (int i = 0; i < truthTable.InputNumberOfDigits - correctValueProbability.Length; i++)
            {
                _correctValueProbability[0][i] = truthTable.CorrectValueProbability[i];
                for (int digit = 0; digit < BinaryDigitStates; digit++)
                {
                    // gcaij = g(const_(aij)) * p_aij
                    _autoCorrectionValueProbability[digit][i] = digitDistortionProbability[digit][i];// *ProbabilityZeroAndOne(digit, i);

                    // geaij = (g(const_(not aij)) + p inv ) * p_aij
                    _distortedValueProbability[digit][i] = (digitDistortionProbability[BinaryDigitStates - digit - 1][i] //digitDistortionProbability[!digit][i]
                            + truthTable.DistortionToInverseProbability[i]);// *ProbabilityZeroAndOne(digit, i);
                }
            }
        }
        public ProductClasses(InputDistortionProbabilities inputDistProb, Gprobabilites[][] bitProbabilities, int lenInput)
        {
            _correctValueProbability = new double[2][];
            int lenF2Result =  bitProbabilities[0].Length;
            _correctValueProbability[1] = _correctValueProbability[0] = new double[lenInput];
            AllocateDeterminedDistortionProbalilitiesVectors(ref _autoCorrectionValueProbability, lenInput);
            AllocateDeterminedDistortionProbalilitiesVectors(ref _distortedValueProbability, lenInput);
            const int BinaryDigitStates = 2;
            double[][] digitDistortionProbability = new double[BinaryDigitStates][]; // temp variable
            digitDistortionProbability[0] = inputDistProb.DistortionToZeroProbability;
            digitDistortionProbability[1] = inputDistProb.DistortionToOneProbability;
            _probalityZero = new double[2][];
            _probalityZero[0] = new double[lenInput];
            _probalityZero[1] = new double[lenInput];
            // set gxx values for bits 1..t
            for (int i = 0; i < lenInput - lenF2Result; i++)
            {
                _correctValueProbability[0][i] = inputDistProb.CorrectValueProbability[i];
                _probalityZero[0][i] = inputDistProb.ZeroProbability[i];
                _probalityZero[1][i] = 1 - inputDistProb.ZeroProbability[i];
                for (int digit = 0; digit < BinaryDigitStates; digit++)
                {
                    // gcaij = g(const_(aij)) * p_aij
                    _autoCorrectionValueProbability[digit][i] = digitDistortionProbability[digit][i];// *ProbabilityZeroAndOne(digit, i);

                    // geaij = (g(const_(not aij)) + p inv ) * p_aij
                    _distortedValueProbability[digit][i] = (digitDistortionProbability[BinaryDigitStates - digit - 1][i] //digitDistortionProbability[!digit][i]
                            + inputDistProb.DistortionToInverseProbability[i]);// *ProbabilityZeroAndOne(digit, i);
                }
            }
            // set gxx values for bits t+1..n
            int indexbitProb = 0;
            for (int i = lenInput - lenF2Result; i < lenInput; i++)
            {
                _probalityZero[0][i] = _probalityZero[1][i] = 1.0;
                _correctValueProbability[0][i] = bitProbabilities[0][indexbitProb].G0;
                for (int digit = 0; digit < BinaryDigitStates; digit++)
                {
                    // gcaij = g(const_(aij)) * p_aij
                    _autoCorrectionValueProbability[digit][i] = (bitProbabilities[digit][indexbitProb].Gc + bitProbabilities[digit][indexbitProb].Gce);// *ProbabilityZeroAndOne(digit, i);

                    // geaij = (g(const_(not aij)) + p inv ) * p_aij
                    _distortedValueProbability[digit][i] = bitProbabilities[digit][indexbitProb].Gee;// *ProbabilityZeroAndOne(digit, i);
                }
                double check = _correctValueProbability[0][i] + _autoCorrectionValueProbability[0][i] + _autoCorrectionValueProbability[1][i] +
                    _distortedValueProbability[0][i] + _distortedValueProbability[1][i];
                if (check > 1.0001)
                {
                    throw new Exception("Oh no!");
                }
                indexbitProb++;
            }
        }
        public ProductClasses(double[] correctValueProbability, double[][] autoCorrectionValueProbability,
            double[][] distortedValueProbability, double[] probalityZero)
        {
            //if (_probalityZeroAndOne == null)
            //    throw new Exception("Error! Zero probalities for fucntion are not set.");
            _correctValueProbability = new double[2][];
            _correctValueProbability[1] = _correctValueProbability[0] = new double[correctValueProbability.Length];
            AllocateDeterminedDistortionProbalilitiesVectors(ref _autoCorrectionValueProbability, autoCorrectionValueProbability.Length);
            AllocateDeterminedDistortionProbalilitiesVectors(ref _distortedValueProbability, distortedValueProbability.Length);
            _probalityZero = new double[2][];
            _probalityZero[0] = new double[probalityZero.Length];
            _probalityZero[1] = new double[probalityZero.Length];
            for (int i = 0; i < probalityZero.Length; i++)
            {
                _probalityZero[0][i] = probalityZero[i];
                _probalityZero[1][i] = 1 - probalityZero[i];
                _correctValueProbability[0][i] = correctValueProbability[i];

                _autoCorrectionValueProbability[0][i] = autoCorrectionValueProbability[0][i];
                _autoCorrectionValueProbability[1][i] = autoCorrectionValueProbability[1][i];
                _distortedValueProbability[0][i] = distortedValueProbability[0][i];
                _distortedValueProbability[1][i] = distortedValueProbability[1][i];
            }
        }
        public ProductClasses(double[] probalityZero, BooleanFuntionWithInputDistortion truthTable)
        {
            _probalityZero = new double[2][];
            _probalityZero[0] = new double[probalityZero.Length];
            _probalityZero[1] = new double[probalityZero.Length];
            for (int i = 0; i < probalityZero.Length; i++)
            {
                _probalityZero[0][i] = probalityZero[i];
                _probalityZero[1][i] = 1 - probalityZero[i];
            }
            CalcDeterminedDistortionProbabilities(truthTable);
        }

        public ProductClasses(InputDistortionProbabilities inputDistProb)
        {
            _probalityZero = new double[2][];
            int probalityZeroLen = inputDistProb.ZeroProbability.Length;
            _probalityZero[0] = new double[probalityZeroLen];
            _probalityZero[1] = new double[probalityZeroLen];
            for (int i = 0; i < probalityZeroLen; i++)
            {
                _probalityZero[0][i] = inputDistProb.ZeroProbability[i];
                _probalityZero[1][i] = 1 - inputDistProb.ZeroProbability[i];
            }
            CalcDeterminedDistortionProbabilities(inputDistProb);
        }

        public ProductClasses(double[] probalityZero, BooleanFuntionWithInputDistortion truthTable, BitGprobabilities[] prob)
        {
            _probalityZero = new double[2][];
            _probalityZero[0] = new double[probalityZero.Length];
            _probalityZero[1] = new double[probalityZero.Length];
            for (int i = 0; i < probalityZero.Length; i++)
            {
                _probalityZero[0][i] = probalityZero[i];
                _probalityZero[1][i] = 1 - probalityZero[i];
            }
            CalcDeterminedDistortionProbabilities(truthTable);
            lastBitsCount = prob.Length;
            lastBitsProbabilities = prob;
        }
        private void AllocateDeterminedDistortionProbalilitiesVectors(ref double[][] vectValueProbability, int size)
        {
            const int BinaryDigitStates = 2;
            vectValueProbability = new double[BinaryDigitStates][];
            vectValueProbability[0] = new double[size];
            vectValueProbability[1] = new double[size];
        }
        public double[][] this[int productsClassIndex]
        {
            get
            {
                switch (productsClassIndex)
                {
                    case 0:
                        return _correctValueProbability;
                    case 1:
                        return _autoCorrectionValueProbability;
                    case 2:
                        return _distortedValueProbability;
                    default:
                        throw new IndexOutOfRangeException("ProductClasses index out of range.");
                 }
            }
        }
        /// <summary>
        /// Kj0
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        public double GetNoDistortionClassProduct(BitArray tuple)
        {
            return GetNoDistortionClassProductAlt(tuple);
        }
        public double GetNoDistortionClassProductAlt(BitArray tuple)
        {
            double d = 1.0;
            for (int i = 0; i < tuple.Length; i++)
            {
                d *= GetNoDistortionValueProbability(i);
            }
            return d;
        }
        private double GetNoDistortionValueProbability(int index)
        {
            if (index < _probalityZero.Length)
            {
                return _correctValueProbability[0][index];
            }
            return lastBitsProbabilities[index - _probalityZero.Length].G0.Sum();
        }
        /// <summary>
        /// Kjc
        /// </summary>
        /// <param name="tuple"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public double GetAutoCorrectionClassProduct(BitArray tuple/*Aj*/, ulong index)
        {
            return GetAutoCorrectionClassProductAlt(tuple, index);
        }
        public double GetAutoCorrectionClassProductAlt(BitArray tuple/*Aj*/, ulong index)
        {
            double d = 1.0;
            BitArray errorsVect = new BitArray(BitConverter.GetBytes(index));
            for (int i = 0; i < tuple.Length; i++)
            {
                if (errorsVect[i]) // g0i or gci
                {
                    d *= GetAutoCorrectionValueProbabilityG0(Convert.ToInt32(tuple[i]),i);
                }
                else
                {
                    d *= GetAutoCorrectionValueProbabilityGc(Convert.ToInt32(tuple[i]), i);
                }

            }
            return d;
        }
        internal double GetAutoCorrectionValueProbabilityG0(int bit, int index)
        {
            if (index < _probalityZero.Length)
            {
                return _correctValueProbability[0][index] * ProbabilityZeroAndOne(bit, index);
            }
            throw new IndexOutOfRangeException("Out of range, superposition not supported code usage");
            return lastBitsProbabilities[index - _probalityZero.Length].G0[bit];
        }
        internal double GetAutoCorrectionValueProbabilityGc(int bit, int index)
        {
            if (index < _probalityZero.Length)
            {
                return _autoCorrectionValueProbability[bit][index] * ProbabilityZeroAndOne(bit, index);
            }
            throw new IndexOutOfRangeException("Out of range, superposition not supported code usage");
            return lastBitsProbabilities[index - _probalityZero.Length].Gc[bit];
        }
        internal double GetDistortionValueProbabilityGe(int bit, int index)
        {
            if (index < _probalityZero.Length)
            {
                return _distortedValueProbability[bit][index] * ProbabilityZeroAndOne(bit, index);
            }
            throw new IndexOutOfRangeException("Out of range, superposition not supported code usage");
            return lastBitsProbabilities[index - _probalityZero.Length].Ge[bit];
        }
        /// <summary>
        /// Kje
        /// </summary>
        /// <param name="tuple"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public double GetDistortionClassProduct(BitArray tuple/*Aj*/, ulong index)
        {
            return GetDistortionClassProductAlt(tuple, index);
        }
        public double GetDistortionClassProductAlt(BitArray tuple/*Aj*/, ulong index) 
        {
            double d = 1.0;
            byte[] productsIndicator = binaryToTernary(new BitArray(BitConverter.GetBytes(index)), _probalityZero.Length);
            for (int i = 0; i < tuple.Length; i++)
            {

                switch(productsIndicator[i])
                {
                    case 0:
                        d *= GetAutoCorrectionValueProbabilityG0(Convert.ToInt32(tuple[i]),i);
                        break;
                    case 1:
                        d *= GetAutoCorrectionValueProbabilityGc(Convert.ToInt32(tuple[i]), i);
                        break;
                    case 2:
                        d *= GetDistortionValueProbabilityGe(Convert.ToInt32(tuple[i]), i);
                        break;
                }
                //d *= ProbabilityZeroAndOne(tuple[i], i);

            }
            return d;
        }

        private byte[] binaryToTernary(BitArray number, int size)
        {
            var ternary = new byte[size];
            int binIndex = 0;
            int i = 0;
            for (; i < size - 1; i++)
            {
                if (number[binIndex])
                    ternary[i] = 1;
                else
                {
                    ++binIndex;
                    ternary[i] =  (byte)(Convert.ToByte(number[binIndex]) << 1);
                }
                ternary[++i] = (byte)(Convert.ToByte(number[binIndex]) + Convert.ToByte(number[++binIndex]) << 1);
                ++binIndex;
            }
            if ((size & 1) == 1)
            {
                if (number[binIndex])
                    ternary[i] = 1;
                else
                {
                    ++binIndex;
                    ternary[i] = (byte)(Convert.ToByte(number[binIndex]) << 1);
                }
            }
            return ternary;
        }
    }
}
