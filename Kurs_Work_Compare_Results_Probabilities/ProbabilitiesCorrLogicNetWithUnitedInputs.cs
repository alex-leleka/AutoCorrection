using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace Diplom_Work_Compare_Results_Probabilities
{
    class ProbabilitiesCorrLogicNetWithUnitedInputs
    {
        private readonly InputWithUnitedDistortionProbabilities _inpDist;
        private readonly BooleanFuntionWithInputDistortion _bf;
        public ProbabilitiesCorrLogicNetWithUnitedInputs(InputWithUnitedDistortionProbabilities inpDist, BooleanFuntionWithInputDistortion bf)
        {
            _inpDist = inpDist;
            _bf = bf;
        }

        private double CalculateCorrectWorkProbWithAutoCorr()
        {
            int digitCount = _inpDist.GetLogicNetworkBitsCount();
            int realInputsCount = _inpDist.GetCircuitBitsCount();
            var inputBinDigits = new BitArray(digitCount, false); // 00...0
            double pCorr = 0.0, pErr = 0.0;
            do
            {
                // TODO: Rework count and indexes for 2nd level inputs distortions;
                QuattuoryNums distortionQuattuoryNums = new QuattuoryNums(realInputsCount + InputsUnitedSourcesCount);
                do
                {
                    double p = GetDistortionsProbabilities(inputBinDigits, distortionQuattuoryNums);
                    BitArray input = ApplyDistortionOnBits(inputBinDigits, distortionQuattuoryNums);
                    var resultNoDist = _bf.GetResult(inputBinDigits);
                    var resultDistorted = _bf.GetResult(input);
                    if (resultNoDist.Eq(resultDistorted))
                    {
                        pCorr += p;
                    }
                    else
                    {
                        pErr += p;
                    }

                } while (distortionQuattuoryNums.Increment());
            } while (BooleanFuntionWithInputDistortion.IncrementOperand(inputBinDigits));
            return pCorr; 
        }

        private double GetDistortionsProbabilities(BitArray inputBinDigits, QuattuoryNums distortionQuattuoryNums)
        {
            double p = 1.0;
            for (int i = 0; i < _inpDist.GetCircuitBitsCount(); i++)
            {
                var connInputs = _inpDist.GetFirstLevelInputsTargets(i);
                if (connInputs.Count == 1)
                {
                    p *= _inpDist.GetFistLevelDistortionProbability(distortionQuattuoryNums.Value(i), i);
                }
                else
                {
                    double pFistLevel = _inpDist.GetFistLevelDistortionProbability(distortionQuattuoryNums.Value(i), i);
                    foreach (var index2NdLevel in connInputs)
                    {
                        p *= _inpDist.GetSecondLevelDistortionProbability(distortionQuattuoryNums.Value(index2NdLevel), index2NdLevel);
                    }
                    p *= pFistLevel;
                }
            }
            return p;
        }

        private BitArray ApplyDistortionOnBits(BitArray inputBinDigits, QuattuoryNums distortionQuattuoryNums)
        {
            throw new NotImplementedException();
        }

    }

    class QuattuoryNums
    {
        enum Quattuor {Zero, One, Two, Three};

        private Quattuor[] _number;

        public int Value(int digitIndex)
        {
            return (int)_number[digitIndex];
        }
        public QuattuoryNums(int digitCount, int initVal = 0)
        {
            _number = new Quattuor[digitCount];
            if (initVal == 0)
                return;
            for (int i = 0; i < _number.Length; i++)
            {
                _number[i] = (Quattuor)initVal;
            }
        }

        public int Count
        { get { return _number.Length; }}

        public bool Increment()
        {
            for (int i = 0; i < _number.Length; i++)
            {
                if (_number[i] != Quattuor.Three)
                {
                    ++_number[i];
                    // highest digit set
                    return true;
                }
                _number[i] = Quattuor.Zero;
            }
            return false; // overflow
        }

        public bool Decrement()
        {
            for (int i = 0; i < _number.Length; i++)
            {
                if (_number[i] != Quattuor.Zero)
                {
                    --_number[i];
                    // highest digit set
                    return true;
                }
                _number[i] = Quattuor.Three;
            }
            return false; // carry
        }

    }
}
