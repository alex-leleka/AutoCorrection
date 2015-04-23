﻿using System;
using System.Collections;
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
            int digitCount = _inpDist.GetFirstLevelInputsCount();
            int secondLevelInputsCount = _inpDist.GetSecondLevelInputsCount();
            var inputBinDigits = new BitArray(digitCount, false); // 00...0
            double pCorr = 0.0, pErr = 0.0;
            do
            {
                QuattuoryNums distortionQuattuoryNums = new QuattuoryNums(digitCount + secondLevelInputsCount);
                do
                {
                    double p = GetDistortionsProbabilities(distortionQuattuoryNums);
                    BitArray input = ApplyDistortionOnBits(inputBinDigits, distortionQuattuoryNums);
                    p *= GetInputDigitsProbability(inputBinDigits);
                    var resultNoDist = _bf.GetResult(_inpDist.ConvertFirstToSecondLvlVars(inputBinDigits));
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
            return pCorr;// + pErr; 
        }

        private double GetInputDigitsProbability(BitArray inputBinDigits)
        {
            //throw new NotImplementedException();
            double p = 1.0;
            for (int i = 0; i < _inpDist.GetFirstLevelInputsCount(); i++)
            {
                p *= _inpDist.GetProbalityDigit(Convert.ToInt32(inputBinDigits[i]), i);
            }
            return p;
        }

        private double GetDistortionsProbabilities(QuattuoryNums distortionQuattuoryNums)
        {
            double p = 1.0;
            int indexBaseSecLevelProb = _inpDist.GetFirstLevelInputsCount();

            // 1st level
            for (int i = 0; i < _inpDist.GetFirstLevelInputsCount(); i++)
            {
                p *= _inpDist.GetFistLevelDistortionProbability(distortionQuattuoryNums.Value(i), i);
            }
            // 2nd level
            for (int i = 0; i < _inpDist.GetSecondLevelInputsCount(); i++)
            {
                p *= _inpDist.GetSecondLevelDistortionProbability(distortionQuattuoryNums.Value(indexBaseSecLevelProb + i), i);
            }
            return p;
        }

        private BitArray ApplyDistortionOnBits(BitArray inputBinDigits, QuattuoryNums distortionQuattuoryNums)
        {
            var result = new BitArray(_inpDist.GetSecondLevelInputsCount());
            int indexBaseSecLevelProb = _inpDist.GetFirstLevelInputsCount();
            for (int i = 0; i < result.Length; i++)
            {
                int firstLevelIndex = _inpDist.GetBitMappedVariableIndex(i);
                bool firstLevelOut = ApplyDistortion(inputBinDigits[firstLevelIndex], distortionQuattuoryNums.QValue(firstLevelIndex));
                result[i] = ApplyDistortion(firstLevelOut, distortionQuattuoryNums.QValue(indexBaseSecLevelProb + i));
            }
            return result;
        }

        private static bool ApplyDistortion(bool bit, QuattuoryNums.Quattuor distType)
        {
            QuattuoryNums.DistTypes dType = (QuattuoryNums.DistTypes) distType;
            switch (dType)
            {
                case QuattuoryNums.DistTypes.NoDist:
                    return bit;
                case QuattuoryNums.DistTypes.DistToZero:
                    return false;
                case QuattuoryNums.DistTypes.DistToOne:
                    return true;
                case QuattuoryNums.DistTypes.DistToInv:
                    return !bit;
            }
            throw new Exception("ApplyDistortion failed!");
        }


        internal double GetCorrectResultProbability()
        {
            return CalculateCorrectWorkProbWithAutoCorr();
        }
    }

    class QuattuoryNums
    {
        public enum Quattuor { Zero, One, Two, Three };
        public enum DistTypes { NoDist = Quattuor.Zero, DistToZero = Quattuor.One, DistToOne = Quattuor.Two, DistToInv = Quattuor.Three };
        private Quattuor[] _number;

        public int Value(int digitIndex)
        {
            return (int)_number[digitIndex];
        }
        public Quattuor QValue(int digitIndex)
        {
            return _number[digitIndex];
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
