using System;
using System.Collections.Generic;
using System.Collections;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;
using System.Diagnostics;
using DotNetUtils;

namespace Diplom_Work_Compare_Results_Probabilities
{
    class ProbabilitiesGxyCalcAdder : ProbabilitiesGxyCalc
    {
        // Nested data
        //protected BooleanFuntionWithInputDistortion _truthTable;
        //protected ProductClasses _inputBitsDistortionsProbabilities; // contain probabilites g0, gcaij, geaij, p0i, p1i

        public ProbabilitiesGxyCalcAdder(BooleanFuntionWithInputDistortion truthTable, double[] probalityZero)
            : base(truthTable, probalityZero) { }
        
        // Calculationg of E1 and E2:
        // probability of autocorrection and error after distortion in the corresponding tuples 
        // intermediate calculation
        protected override void CalcE1E2(BitArray result, ref double Gce, ref double Gee)
        {
            double E1 = 0.0, E2 = 0.0;
            int bitsInOp = _truthTable.InputNumberOfDigits / 2;
            int op1 = 0, opMax = 1 << bitsInOp;
            Debug.Assert((result.Count & 1) == 1, "Result shell contain n + 1 bits.");
            int intResult = BooleanFuntionWithInputDistortion.GetIntFromBitArray(result);
            // opMax - max value of a result
            /*do
            {
                //if (_truthTable.GetResult(operandIt).Eq(result))
                {
                    
                    int op2 = intResult - op1;
                    BitArray ba1 = op1.ToBinary(bitsInOp);
                    BitArray ba2 = op2.ToBinary(bitsInOp);
                    var operandIt = ba1.Append(ba2);
                    ++op1;
                    if (_truthTable.GetResult(operandIt).Eq(result))  GetAdderTupleProbabilityKjeClass(result, ref E1, ref E2, operandIt);
                }
            } while( op1 < opMax);*/
            BitArray operandIt = new BitArray(_truthTable.InputNumberOfDigits, false); // the first operand in tTable 00...0
            do
            {
                if (_truthTable.GetResult(operandIt).Eq(result))
                {
                    GetAdderTupleProbabilityKjeClass(result, ref E1, ref E2, operandIt);
                }
            } while (BooleanFuntionWithInputDistortion.IncrementOperand(operandIt));
            Gce = E1;
            Gee = E2;
        }

        private void GetAdderTupleProbabilityKjeClass(BitArray result, ref double E1, ref double E2, BitArray operandIt)
        {
            // for every error containing tuple that return result calc probability to get it from operandIt
            // add value to E1

            // Next routine calculates probability of correct result for input operandIt when we have distortion at input 
            // (aka output autocorrection probability). We don't calc distorted result probability to reduce problem complexity.
            // if and only if the same error vector influences op1 & op2 we would have correct result.

            //int errVec = 0; // error vector of op1
            // important assumtion operandIt.lenth == result.length - 1
            int errVecMax = 1 << (operandIt.Count / 2);
            double operandInputP = GetOperandAppearanceProbability(operandIt);
            for( int errVec = 1; errVec < errVecMax; ++errVec)
            {
                double tempProbability = GetErrorVectorProbability(errVec, operandIt) * operandInputP;
                E1 += tempProbability;
            }
        }

        private double GetOperandAppearanceProbability(BitArray operandIt)
        {
            double p = 1;
            for (int i = 0; i < operandIt.Count; ++i)
            {
                p *= _inputBitsDistortionsProbabilities.ProbabilityZeroAndOne(operandIt[i], i);
            }
            return p;
        }

        private double GetErrorVectorProbability(int errVec, BitArray operandIt)
        {
            // TODO: clac only products that errVec&op1 != errVec&op2

            BitArray ba1 = errVec.ToBinary(Convert.ToInt32(operandIt.Count / 2));
            var err = ba1.Append(ba1);
            const double factor = 1000000000.0;
            double p = 1 * factor;
            /*for (var i = 0; i < operandIt.Count; ++i)
            {
             *  int bit = Convert.ToInt32(operandIt[i]);
                if (err[i])
                    p *= _inputBitsDistortionsProbabilities[2][bit][i];
                else
                    p *= _inputBitsDistortionsProbabilities[0][bit][i] +
                         _inputBitsDistortionsProbabilities[1][bit][i];
            }*/
            for (var i = 0; i < ba1.Count; ++i)
            {
                int bit = Convert.ToInt32(operandIt[i]);
                if (ba1[i])
                    p *= _inputBitsDistortionsProbabilities[2][bit][i];
                else
                    p *= _inputBitsDistortionsProbabilities[0][bit][i] +
                         _inputBitsDistortionsProbabilities[1][bit][i];
            }
            int inc = ba1.Count;
            for (var i = 0; i < ba1.Count; ++i)
            {
                int bit = Convert.ToInt32(operandIt[i + inc]);
                if (ba1[i])
                    p *= _inputBitsDistortionsProbabilities[2][bit][i + inc];
                else
                    p *= _inputBitsDistortionsProbabilities[0][bit][i + inc] +
                         _inputBitsDistortionsProbabilities[1][bit][i + inc];
            }
            return p / factor;
        }
    }
}
