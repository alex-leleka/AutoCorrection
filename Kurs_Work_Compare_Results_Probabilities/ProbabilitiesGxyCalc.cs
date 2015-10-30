using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;
namespace Diplom_Work_Compare_Results_Probabilities
{
    
    public class ProbabilitiesGxyCalc : IProbabilityGxyCalculator
    {
        protected BooleanFuntionWithInputDistortion _truthTable;

        // data members for calculating Gxy
        // input data
        protected ProductClasses _inputBitsDistortionsProbabilities; // contain probabilites g0, gcaij, geaij, p0i, p1i

        public ProbabilitiesGxyCalc(BooleanFuntionWithInputDistortion truthTable, double[] probalityZero)
        {
            _truthTable = truthTable;
            // TODO: move probalityZero to truthTable class (AbstractBooleanFuntionWithInputDistortion)
            if (probalityZero.Length != truthTable.InputNumberOfDigits)
                throw new Exception("Length of probalityZero array don't fit the InputNumberOfDigits of truth table");
            _inputBitsDistortionsProbabilities = new ProductClasses(probalityZero, truthTable);
        }

        public ProbabilitiesGxyCalc(BooleanFuntionWithInputDistortion truthTable, InputDistortionProbabilities inputDistProb)
        {
            _truthTable = truthTable;
            _inputBitsDistortionsProbabilities = new ProductClasses(inputDistProb);
        }
        public ProbabilitiesGxyCalc(BooleanFuntionWithInputDistortion truthTable, ProductClasses prodClasses)
        {
            _truthTable = truthTable;
            _inputBitsDistortionsProbabilities = prodClasses;
        }

        // Get probability of correct (0||1) result == Result without distortion
        public double GetProbabilityG0Result(BitArray result)
        {
            double G0 = 0;
            BitArray operandIt = new BitArray(_truthTable.InputNumberOfDigits, false); // the first operand in tTable 00...0
            G0 += GetTupleProbabilityKj0Class(operandIt);
            int resultCount = 0;
            do
            {
                if ( _truthTable.GetResult(operandIt).Eq(result) )
                    ++resultCount;
            } while (BooleanFuntionWithInputDistortion.IncrementOperand(operandIt));
            return G0 / (1 << _truthTable.InputNumberOfDigits) * resultCount;
        }
        private double GetTupleProbabilityKj0Class(BitArray tuple)
        {
            double pCorrectWithoutDistortion = 1.0;
            int index = 0;

            foreach (double g0 in _truthTable.CorrectValueProbability)
            {
                pCorrectWithoutDistortion *= g0; // * _inputBitsDistortionsProbalities.ProbabilityZeroAndOne(tuple[index], index)
                // p(Aj) = P(i=1,n){g0[i]*p[aij][i]}
                ++index;
            }

            return pCorrectWithoutDistortion;
        }
        // Get probability of correct (0||1) result == Result with distortion
        public double GetProbabilityGcResult(BitArray result)
        {
            double pGc = 0.0;
            BitArray operandIt = new BitArray(_truthTable.InputNumberOfDigits, false); // the first operand in tTable 00...0
            do
            {
                if (_truthTable.GetResult(operandIt).Eq(result))
                {
                    pGc += GetTupleProbabilityKjcClass(operandIt);
                }
            } while (BooleanFuntionWithInputDistortion.IncrementOperand(operandIt));
            return pGc;
        }

        private double GetTupleProbabilityKjcClass(BitArray tuple)
        {
            double Kjc = 0;
            BitArray distortionVect = new BitArray(_truthTable.InputNumberOfDigits, false); // 00...0
            distortionVect[0] = true; // 00..01
            do
            {
                double tempProbability = 1.0;
                // find the probability of the operandIt tuple with distortionVect distortion
                for (int i = 0; i < _truthTable.InputNumberOfDigits; i++)
                {
                    int bitValue = Convert.ToInt32(tuple[i]); // value of i-th: zero or one
                    if (distortionVect[i])
                    {
                        tempProbability *= _inputBitsDistortionsProbabilities.AutoCorrectionValueProbability[bitValue][i];
                    }
                    else
                    {
                        tempProbability *= _truthTable.CorrectValueProbability[i];
                    }
                    tempProbability *= _inputBitsDistortionsProbabilities.ProbabilityZeroAndOne(bitValue, i);
                }
                Kjc += tempProbability;
            } while (BooleanFuntionWithInputDistortion.IncrementOperand(distortionVect));
            return Kjc;
        }
        // Get probability of distorted (0||1) result == Result without distortion
        public Gprobabilites GetGprobabilitesResult(BitArray result)
        {
            Gprobabilites boolFunctionGp = new Gprobabilites
            {
                G0 = GetProbabilityG0Result(result),
                Gc = GetProbabilityGcResult(result)
            };
            CalcE1E2(result, ref boolFunctionGp.Gce, ref boolFunctionGp.Gee);
            return boolFunctionGp;
        }
        // calculation of gc0, ge0, gc1 ...
        // minor calculation - calculate the sum of the probabilities determined distortion Or gxy
        

        private void AllocateDeterminedDistortionProbalilitiesVectors(ref double[][] vectValueProbability)
        {
            const int BinaryDigitStates = 2;
            vectValueProbability = new double[BinaryDigitStates][];
            vectValueProbability[0] = new double[_truthTable.InputNumberOfDigits];
            vectValueProbability[1] = new double[_truthTable.InputNumberOfDigits];
        }

        // Calculationg of E1 and E2:
        // probability of autocorrection and error after distortion in the corresponding tuples 
        // intermediate calculation 
        // TODO: rename method
        protected virtual void CalcE1E2(BitArray result, ref double Gce, ref double Gee)
        {
            double E1 = 0.0, E2 = 0.0;
            BitArray operandIt = new BitArray(_truthTable.InputNumberOfDigits, false); // the first operand in tTable 00...0
            do
            {
                if (_truthTable.GetResult(operandIt).Eq(result))
                {
                    GetTupleProbabilityKjeClass(result, ref E1, ref E2, operandIt);
                }
            } while (BooleanFuntionWithInputDistortion.IncrementOperand(operandIt));
            Gce = E1;
            Gee = E2;
        }

        private void GetTupleProbabilityKjeClass(BitArray result, ref double E1, ref double E2, BitArray operandIt)
        {
            const int CORRECT = 0; // no distortion
            const int AUTOCOR = 1; // input autocorection
            const int DIST = 2; // distortion

            BitArray distortionVect = new BitArray(_truthTable.InputNumberOfDigits, false); // the first operand in tTable 00...0
            int index = 0, indexMax = IntPow(3, (uint)_truthTable.InputNumberOfDigits);
            do
            {
                int[] digits = Base3(index, _truthTable.InputNumberOfDigits);
                bool distortionPresent = false;
                foreach (var d in digits)
                {
                    if (d == DIST)
                        distortionPresent = true;
                }
                if (!distortionPresent)
                    continue;
                double tempProbability = 1.0;
                // find the probability of the operandIt tuple with distortionVect distortion
                for (int i = 0; i < _truthTable.InputNumberOfDigits; i++)
                {
                    int bitValue = Convert.ToInt32(operandIt[i]); // value of i-th: zero or one
                   /* if (distortionVect[i])
                    {
                        tempProbability *= _inputBitsDistortionsProbalities.DistortedValueProbability[bitValue][i] * _inputBitsDistortionsProbalities.ProbabilityZeroAndOne(temp[i], i);
                    }
                    else
                    {
                        tempProbability *= (_truthTable.CorrectValueProbability[i] + _inputBitsDistortionsProbalities.AutoCorrectionValueProbability[bitValue][i]) * _inputBitsDistortionsProbalities.ProbabilityZeroAndOne(temp[i], i);
                    }*/
                    switch (digits[i])
                    {
                        case CORRECT:
                            tempProbability *= _truthTable.CorrectValueProbability[i] * _inputBitsDistortionsProbabilities.ProbabilityZeroAndOne(operandIt[i], i);
                            distortionVect[i] = false;
                            break;
                        case AUTOCOR:
                            tempProbability *= _inputBitsDistortionsProbabilities.AutoCorrectionValueProbability[bitValue][i] * _inputBitsDistortionsProbabilities.ProbabilityZeroAndOne(operandIt[i], i);
                            distortionVect[i] = false;
                            break;
                        case DIST:
                            tempProbability *= _inputBitsDistortionsProbabilities.DistortedValueProbability[bitValue][i] * _inputBitsDistortionsProbabilities.ProbabilityZeroAndOne(operandIt[i], i);
                            distortionVect[i] = true;
                            break;
                        default:
                            throw new Exception("Mod3 wrong index");
                         
                    }
                }
                BitArray temp = new BitArray(distortionVect);
                temp.Xor(operandIt);
                if (_truthTable.GetResult(temp).Eq(result))
                {
                    E1 += tempProbability;
                }
                else
                {
                    E2 += tempProbability;
                }
            } while (++index < indexMax);
        }
        private static int IntPow(int x, uint pow)
        {
            int ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }
        /// <summary>
        /// Convert positive integer to array of trinary digits.
        /// </summary>
        /// <param name="n">Number to convert.</param>
        /// <param name="size">Number of trinary digits.</param>
        /// <returns>trinary digits array</returns>
        public int[] Base3(int n, int size)
        {
            const int base3 = 3;
            int[] v = new int[size];
            for (int i = 0; (i < size) && (n > 0); i++)
            {
                v[i] = n % base3;
                n = n / base3;
            }
            return v;
        }
        public int OutputNumberOfDigits()
        {
            return _truthTable.OutputNumberOfDigits;
        }
    }
}
