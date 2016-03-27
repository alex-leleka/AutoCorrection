using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom_Work_Compare_Results_Probabilities;

namespace SubfunctionPrototype
{
    class MultifunctionDistortionCalc
    {
        private Func<int, int> _boolFunction;
        private InputDistortionG4 _inputDistortions;
        private int _outputBitsCount;
        private GFProductsMatrix _matrix;

        public MultifunctionDistortionCalc(InputDistortionG4 inputDistortions, Func<int, int> boolFunction)
        {
            _outputBitsCount = inputDistortions.GetOutputBitsNumber();
            _inputDistortions = inputDistortions;
            _boolFunction = boolFunction;
        }

        public MultifunctionDistortionCalc(InputDistortionG4 inputDistortions, Func<int, int> boolFunction, int outputBitsCount)
        {
            _outputBitsCount = outputBitsCount;
            _inputDistortions = inputDistortions;
            _boolFunction = boolFunction;
        }

        public virtual G4Probability[] GetResultDistortinProbabilities()
        {
            // Generate _matrix
            GenerateGFMatrix();
            // make resuling G4Probability[] based on _matrix
            var g4Arr = MakeResultsProbability();
            return g4Arr;

        }

        private G4Probability[] MakeResultsProbability()
        {
            var res = new G4Probability[_outputBitsCount];
            for (int i = 0; i < _outputBitsCount; ++i)
                res[i] = new G4Probability();

            for (int i = 0; i < (1 << _outputBitsCount); ++i)
            {
                for (int j = 0; j < (1 << _outputBitsCount); ++j)
                {
                    for (int maskedI = i, maskedJ = j, iter = 0;
                        iter < _outputBitsCount;
                        ++iter, maskedI >>= 1, maskedJ >>= 1)
                    {
                        int corr = j & 1;
                        int dist = i & 1;
                        res[iter].G[dist][corr] += _matrix.Get(i, j);
                    }
                }
            }
            return res;
        }

        private void GenerateGFMatrix()
        {
            int mSize = 1 << _outputBitsCount;
            _matrix = new GFProductsMatrix(mSize, mSize);

            int rangeSize = _inputDistortions.GetInputBitsNumber();
            int maxOperandBound = 1 << rangeSize;

            for (int i = 0; i < maxOperandBound; ++i)
                for (int j = 0; j < maxOperandBound; ++j)
                {
                    double prob = CalculateTurnInProbability(i, j);
                    int originalValue = _boolFunction(i);
                    int corruptedValue = _boolFunction(j);
                    _matrix.AddNumber(corruptedValue, originalValue, prob);
                }
        }

        /// <summary>
        /// Returns probability of turning originalValue to corruptedValue based on idp distortion probabilities.
        /// </summary>
        /// <param name="originalValue"></param>
        /// <param name="corruptedValue"></param>
        /// <returns></returns>
        private double CalculateTurnInProbability(int originalValue, int corruptedValue)
        {
            double operandTurnInProbability = 1.0;
            int inputBitsCount = _inputDistortions.GetInputBitsNumber();
            for (int i = 0; i < inputBitsCount; i++, originalValue >>= 1, corruptedValue >>= 1)
            {
                int dist = 1 & corruptedValue;
                int orig = 1 & originalValue;
                operandTurnInProbability *= _inputDistortions.GetInputProbability(i).G[dist][orig];
            }
            return operandTurnInProbability;
        }
    }
}
