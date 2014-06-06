using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;
namespace Diplom_Work_Compare_Results_Probabilities
{
    /// <summary>
    /// Calculate corrarect work probability of function presented as
    /// superposition of two functions. f(x0,..., xN) = f1(x0,..., xT, f2(x[T+1], ..., xN)).
    /// </summary>
    class ProbGxyCalcSuperposition : IProbabilityGxyCalculator
    {
        private BooleanFuntionWithInputDistortion _f1;
        private BooleanFuntionWithInputDistortion _f2;
        private InputDistortionProbabilities _inputDistortionProb;
        private ProbabilitiesGxyCalc _probCalcF1;
        public ProbGxyCalcSuperposition(BooleanFuntionWithInputDistortion truthTable1,
            BooleanFuntionWithInputDistortion truthTable2, InputDistortionProbabilities inputDistortionProb)
        {
            _f1 = truthTable1;
            _f2 = truthTable2;
            if (inputDistortionProb.ZeroProbability.Length != _f1.InputNumberOfDigits + _f2.InputNumberOfDigits - _f2.OutputNumberOfDigits)
                throw new Exception("Size of probalityZero array don't fit the InputNumberOfDigits of truth table composition.");
            _inputDistortionProb = inputDistortionProb;

            // copy distortion for f2
            LoadDistortionToBoolFunction(_f2, _f1.InputNumberOfDigits - _f2.OutputNumberOfDigits, 0);
            LoadDistortionToBoolFunction(_f1, 0, _f2.OutputNumberOfDigits);
            _probCalcF1 = null;
        }

        private void LoadDistortionToBoolFunction(BooleanFuntionWithInputDistortion f, int indexBase, int countDecrement)
        {
            double[] distortionToZeroProbability = new double[f.InputNumberOfDigits];
            double[] distortionToOneProbability = new double[f.InputNumberOfDigits];
            double[] distortionToInverseProbability = new double[f.InputNumberOfDigits];
            for (int i = 0; i < f.InputNumberOfDigits - countDecrement; i++)
            {
                distortionToZeroProbability[i] = _inputDistortionProb.DistortionToZeroProbability[i + indexBase];
                distortionToOneProbability[i] = _inputDistortionProb.DistortionToOneProbability[i + indexBase];
                distortionToInverseProbability[i] = _inputDistortionProb.DistortionToInverseProbability[i + indexBase];
            }
            f.DistortionToZeroProbability = distortionToZeroProbability;
            f.DistortionToOneProbability = distortionToOneProbability;
            f.DistortionToInverseProbability = distortionToInverseProbability;
        }
        public void SetDistortionProbabilities()
        {
        }
        private void CalcF2ProbabilitiesGxy()
        {
            if (null != _probCalcF1)
                return;
            int resultsCount = 1 << _f2.OutputNumberOfDigits;
            Gprobabilites[] boolFunc2Gp = new Gprobabilites[resultsCount];
            double[] f2ProbalityZero = new double[_f2.InputNumberOfDigits];

            for(int i = 0; i < f2ProbalityZero.Length; i++)
                f2ProbalityZero[i] = _inputDistortionProb.ZeroProbability[i + _f1.InputNumberOfDigits - _f2.OutputNumberOfDigits];

            var f2Calc = new ProbabilitiesGxyCalc(_f2, f2ProbalityZero);

            double[] probabilityZeroF1 = new double[_f1.InputNumberOfDigits];
            // copy input zero probability for function f1 in range [1,..,t]
            for (int i = 0; i < _f1.InputNumberOfDigits - _f2.OutputNumberOfDigits; i++)
            {
                probabilityZeroF1[i] = _inputDistortionProb.ZeroProbability[i];
            }
            for (int i = 0; i < _f2.OutputNumberOfDigits; i++)
            {
                probabilityZeroF1[i + _f1.InputNumberOfDigits - _f2.OutputNumberOfDigits] = 0.0;
            }
            // get zero probability 
            int indexBoolFunc2Gp = 0;
            BitArray resultVect = new BitArray(_f2.OutputNumberOfDigits, false); // 00...0
            do
            {
                boolFunc2Gp[indexBoolFunc2Gp] = f2Calc.GetGprobabilitesResult(resultVect);

                 // calc input zero probability for function f1 in range [t+1,..., t+_f2.OutputNumberOfDigits]
                for (int i = 0; i < _f2.OutputNumberOfDigits; i++)
                {
                    if(!resultVect[i]) // if res[i] == 0
                    {
                        probabilityZeroF1[i + _f1.InputNumberOfDigits - _f2.OutputNumberOfDigits] +=
                             boolFunc2Gp[indexBoolFunc2Gp].SumCorrectionAndError(); // sum without G0
                    }
                }
                ++indexBoolFunc2Gp;
            } while (BooleanFuntionWithInputDistortion.IncrementOperand(resultVect));
            // add G0
            for (int i = 0; i < _f2.OutputNumberOfDigits; i++)
            {

                    probabilityZeroF1[i + _f1.InputNumberOfDigits - _f2.OutputNumberOfDigits] +=
                         boolFunc2Gp[0].G0 / _f2.Length;
            }
            // get distortion prob
            const int DistortionTypes = 3;
            double[][] distProb = new double[DistortionTypes][];
            for (int r = 0; r < distProb.Length; r++)
            {
                distProb[r] = new double[_f1.InputNumberOfDigits];
                for (int i = 0; i < _f1.InputNumberOfDigits - _f2.OutputNumberOfDigits; i++)
                {
                    distProb[r][i] = _f1.ProbabilityVectors[r + 1][i];
                }
                int indexBase = _f1.InputNumberOfDigits - _f2.OutputNumberOfDigits;
                for (int i = 0; i < _f2.OutputNumberOfDigits; i++)
                {
                    distProb[r][indexBase + i] = 0;
                }
            }
            indexBoolFunc2Gp = 0;
            resultVect = new BitArray(_f2.OutputNumberOfDigits, false); // 00...0
            do
            {
                int indexBase = _f1.InputNumberOfDigits - _f2.OutputNumberOfDigits;
                for (int i = 0; i < resultVect.Length; i++)
                {
                    double bitProb = 0.0;
                    if (resultVect[i]) // distortionTo1
                    {
                        bitProb = 1 - probabilityZeroF1[indexBase + i];
                        distProb[1][i + indexBase] += (boolFunc2Gp[indexBoolFunc2Gp].Gc + boolFunc2Gp[indexBoolFunc2Gp].Gce);// / bitProb;
                    }
                    else // distortionTo0
                    {
                        bitProb = probabilityZeroF1[indexBase + i];
                        distProb[0][i + indexBase] += (boolFunc2Gp[indexBoolFunc2Gp].Gc + boolFunc2Gp[indexBoolFunc2Gp].Gce);// / bitProb;
                    }
                    distProb[DistortionTypes - 1][i + indexBase] += boolFunc2Gp[indexBoolFunc2Gp].Gee;// / (1 - bitProb);
                }
                ++indexBoolFunc2Gp;
            } while (BooleanFuntionWithInputDistortion.IncrementOperand(resultVect));
            // Set zero prob and dist prob to _f1
            _f1.DistortionToZeroProbability = distProb[0];
            _f1.DistortionToOneProbability = distProb[1];
            _f1.DistortionToInverseProbability = distProb[2];
            _f1.CorrectValueProbability = null;
            double[] correctValueProbability = new double[_f1.InputNumberOfDigits];
            double[][] autoCorrectionValueProbability = null;
            double[][] distortedValueProbability = null;
            AllocateDeterminedDistortionProbalilitiesVectors(ref autoCorrectionValueProbability);
            AllocateDeterminedDistortionProbalilitiesVectors(ref distortedValueProbability);


            _probCalcF1 = new ProbabilitiesGxyCalc(_f1, probabilityZeroF1);
        }
        private void AllocateDeterminedDistortionProbalilitiesVectors(ref double[][] vectValueProbability)
        {
            const int BinaryDigitStates = 2;
            vectValueProbability = new double[BinaryDigitStates][];
            vectValueProbability[0] = new double[_f1.InputNumberOfDigits];
            vectValueProbability[1] = new double[_f1.InputNumberOfDigits];
        }
        // Get probability of distorted (0||1) result == Result without distortion
        public Gprobabilites GetGprobabilitesResult(BitArray result)
        {
            if (null == _probCalcF1)
                CalcF2ProbabilitiesGxy();
            return _probCalcF1.GetGprobabilitesResult(result);
        }
        public int OutputNumberOfDigits()
        {
            return _f2.OutputNumberOfDigits;
        }
    }
}
