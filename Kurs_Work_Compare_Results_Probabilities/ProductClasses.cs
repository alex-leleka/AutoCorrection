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

        private double[] _probalityZero;

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
            if(zeroOrOne == 0)
                return _probalityZero[index];
            return 1 - _probalityZero[index];
        }
        public double ProbabilityZeroAndOne(bool zeroOrOne, int index)
        {
            if (zeroOrOne == false)
                return _probalityZero[index];
            return 1 - _probalityZero[index];
        }
        private void CalcDeterminedDistortionProbabilities(AbstractBooleanFuntionWithInputDistortion truthTable)
        {
            const int BinaryDigitStates = 2;
            AllocateDeterminedDistortionProbalilitiesVectors(ref _autoCorrectionValueProbability, truthTable.CorrectValueProbability.Length);
            AllocateDeterminedDistortionProbalilitiesVectors(ref _distortedValueProbability, truthTable.CorrectValueProbability.Length);

            double[][] digitDistortionProbability = new double[BinaryDigitStates][]; // temp variable
            digitDistortionProbability[0] = truthTable.DistortionToZeroProbability;
            digitDistortionProbability[1] = truthTable.DistortionToOneProbability;
            for (int i = 0; i < truthTable.InputNumberOfDigits; i++)
            {
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
        public ProductClasses(double[] correctValueProbability, double[][] autoCorrectionValueProbability,
            double[][] distortedValueProbability, double[] probalityZero)
        {
            //if (_probalityZeroAndOne == null)
            //    throw new Exception("Error! Zero probalities for fucntion are not set.");
            _correctValueProbability = new double[2][];
            _correctValueProbability[1] = _correctValueProbability[0] = new double[correctValueProbability.Length];
            AllocateDeterminedDistortionProbalilitiesVectors(ref _autoCorrectionValueProbability, autoCorrectionValueProbability.Length);
            AllocateDeterminedDistortionProbalilitiesVectors(ref _distortedValueProbability, distortedValueProbability.Length);
            _probalityZero = new double[probalityZero.Length];
            for (int i = 0; i < probalityZero.Length; i++)
            {
                _probalityZero[i] = probalityZero[i];
                _correctValueProbability[0][i] = correctValueProbability[i];

                _autoCorrectionValueProbability[0][i] = autoCorrectionValueProbability[0][i];
                _autoCorrectionValueProbability[1][i] = autoCorrectionValueProbability[1][i];
                _distortedValueProbability[0][i] = distortedValueProbability[0][i];
                _distortedValueProbability[1][i] = distortedValueProbability[1][i];
            }
        }
        public ProductClasses(double[] probalityZero, AbstractBooleanFuntionWithInputDistortion truthTable)
        {
            //if (_probalityZeroAndOne == null)
            //    throw new Exception("Error! Zero probalities for fucntion are not set.");
            _probalityZero = new double[probalityZero.Length];
            for (int i = 0; i < probalityZero.Length; i++)
            {
                _probalityZero[i] = probalityZero[i];
            }
            CalcDeterminedDistortionProbabilities(truthTable);
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
        public double Kj0(BitArray tuple)
        {
            double d = 1.0;
            for(int i = 0; i < tuple.Length; i++)
            {
              /*  if(tuple[i])
                {
                    d *= _probalityZero[i];
                }else
                {
                    d *= 1 - _probalityZero[i];
                }*/
                d *= _correctValueProbability[0][i];
            }
            return d;
        }
        public double Kjc(BitArray tuple/*Aj*/, ulong index)
        {
            double d = 1.0;
            BitArray errorsVect = new BitArray(BitConverter.GetBytes(index));
            for (int i = 0; i < tuple.Length; i++)
            {
                if (errorsVect[i]) // g0i or gci
                {
                    d *= _correctValueProbability[0][i];
                }
                else
                {
                    d *= _autoCorrectionValueProbability[Convert.ToInt32(tuple[i])][i];
                }

                if (tuple[i]) // pi^aij
                {
                    d *= _probalityZero[i];
                }
                else
                {
                    d *= 1 - _probalityZero[i];
                }
                
            }
            return d;
        }
        public double Kje(BitArray tuple/*Aj*/, ulong index)
        {
            double d = 1.0;
            var productsIndicator = binartToTernary(new BitArray(BitConverter.GetBytes(index)), _probalityZero.Length);
            for (int i = 0; i < tuple.Length; i++)
            {
   
                d *= this[productsIndicator[i]] [Convert.ToInt32(tuple[i])] [i];

                if (tuple[i]) // pi^aij
                {
                    d *= _probalityZero[i];
                }
                else
                {
                    d *= 1 - _probalityZero[i];
                }

            }
            return d;
        }
        private byte[] binartToTernary(BitArray number, int size)
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
