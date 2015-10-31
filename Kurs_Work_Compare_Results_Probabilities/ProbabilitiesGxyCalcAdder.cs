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

        ProbabilitiesGxyCalcAdder(BooleanFuntionWithInputDistortion truthTable, InputDistortionProbabilities inputDistProb)
            : base(truthTable, inputDistProb) {}
        
        // Calculationg of E1 and E2:
        // probability of autocorrection and error after distortion in the corresponding tuples 
        // intermediate calculation
        protected override void CalcE1E2(BitArray result, ref double Gce, ref double Gee)
        {
            double E1 = 0.0, E2 = 0.0;
            int bitsInOp = ((_truthTable.InputNumberOfDigits - 1) / 2);
            int op1 = 0, opMax = 1 << bitsInOp;
            Debug.Assert((result.Count & 1) == 1, "Result shell contain 2*n + 1 bits.");
            int intResult = BooleanFuntionWithInputDistortion.GetIntFromBitArray(result);
            // opMax - max value of a result
            do
            {
                //if (_truthTable.GetResult(operandIt).Eq(result))
                {
                    
                    int op2 = intResult - op1;
                    BitArray ba1 = op1.ToBinary(bitsInOp);
                    BitArray ba2 = op2.ToBinary(bitsInOp);
                    var operandIt = ba1.Append(ba2);
                    ++op1;
                    GetAdderTupleProbabilityKjeClass(result, ref E1, ref E2, operandIt);
                }
            } while( op1 < opMax);
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
            for( int errVec = 1; errVec <= errVecMax; ++errVec)
            {
                double tempProbability = GetErrorVectorProbability(errVec, operandIt);
                E1 += tempProbability;
            }
        }

        private double GetErrorVectorProbability(int errVec, BitArray operandIt)
        {
            // Bitarry err;
            BitArray ba1 = errVec.ToBinary(Convert.ToInt32(operandIt.Count / 2));
            var err = ba1.Append(ba1);
            double p = 1.0;
            for( var i =0;  i < err.Count; ++i)
            {
                if (err[i])
                    p *= _inputBitsDistortionsProbabilities.GetDistortionValueProbabilityGe(
                            Convert.ToInt32(operandIt[i]), i);
                else
                    p *= _inputBitsDistortionsProbabilities.GetAutoCorrectionValueProbabilityG0(
                            Convert.ToInt32(operandIt[i]), i) + 
                            _inputBitsDistortionsProbabilities.GetAutoCorrectionValueProbabilityGc(
                            Convert.ToInt32(operandIt[i]), i);
            }
            return 0;
        }
    }
}
