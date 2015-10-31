using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;
using System.Diagnostics;
using DotNetUtils;
using DotNetUtils.;

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
            BitArray operandIt = new BitArray(_truthTable.InputNumberOfDigits, false); // the first operand in tTable 00...0
            int bitsInOp = ((result.Count - 1) / 2);
            int op1 = 0, opMax = 1 << bitsInOp;
            Debug.Assert((result.Count & 1) == 1, "Result shell contain 2*n + 1 bits.");
            int intResult = BooleanFuntionWithInputDistortion.GetIntFromBitArray(result);
            // opMax - max value of a result
            do
            {
                if (_truthTable.GetResult(operandIt).Eq(result))
                {
                    
                    int op2 = intResult - op1;
                    BitArray ba1 = UtilsBitArray.ToBinary(op1, bitsInOp);
                    BitArray ba2 = UtilsBitArray.ToBinary(op2, bitsInOp);
                    operandIt = UtilsBitArray.Append(ba1, ba2);
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

            // int errVec = 1; // error vector of op1
            // operandIt.lenth == result.length
            // int errVecMax = 1 << ((result.length - 1) / 2);
            // do {
            // 
            // double tempProbability = GetErrorVectorProbability(err);
            // E1 += tempProbability;
            // } while (errVec < errVecMax) 
        }

        private double GetErrorVectorProbability(int err, BitArray operandIt)
        {
            // Bitarry err;
            //err = concat(bitarry(errVec), bitarry(errVec))
            // double p = 1;
            //for( var i =0;  i < err.length; ++i)
            //{
            //    if(err[i]) p *= _inputBitsDistortionsProbabilities.GetDistortionValueProbabilityGe(Convert.ToInt32(operandIt[i]), i);
            //    else p *=_inputBitsDistortionsProbabilities
            //}
            return 0;
        }
    }
}
