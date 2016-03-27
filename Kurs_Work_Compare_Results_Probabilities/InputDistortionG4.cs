using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public class InputDistortionG4
    {
        private G4Probability[] _inputDistG4Probability;
        private int _inputBitsNumber;
        private int _outputDigitsNumber;

        public InputDistortionG4(int n)
        {
            _inputBitsNumber = n;
            _inputDistG4Probability = new G4Probability[_inputBitsNumber];
            Random random = new Random();
            var maximum = 0.4;
            var minimum = 0.0;
            for (int i = 0; i < _inputDistG4Probability.Length; ++i)
            {
                double max = maximum, min = minimum;
                _inputDistG4Probability[i] = new G4Probability();
                _inputDistG4Probability[i].G[0][0] = random.NextDouble() * (max - min) + min;
                max = max - _inputDistG4Probability[i].G[0][0];
                _inputDistG4Probability[i].G[0][1] = random.NextDouble() * (max - min) + min;
                max = max - _inputDistG4Probability[i].G[0][1];
                _inputDistG4Probability[i].G[1][0] = random.NextDouble() * (max - min) + min;
                max = max - _inputDistG4Probability[i].G[1][0];
                min = max;
                _inputDistG4Probability[i].G[1][1] = min;
            }
        }

        public InputDistortionG4(double[] ZeroToZeroProbability, double[] OneToZeroProbability, double[] OneToOneProbability, int outputDigitsNumber)
        {
            _inputBitsNumber = ZeroToZeroProbability.Length;
            _outputDigitsNumber = outputDigitsNumber;
            _inputDistG4Probability = new G4Probability[_inputBitsNumber];
            for (int i = 0; i < _inputDistG4Probability.Length; ++i)
            {
                _inputDistG4Probability[i] = new G4Probability();
                _inputDistG4Probability[i].G[0][0] = ZeroToZeroProbability[i];
                _inputDistG4Probability[i].G[0][1] = OneToZeroProbability[i];
                _inputDistG4Probability[i].G[1][1] = OneToOneProbability[i];
                double sum = ZeroToZeroProbability[i] + OneToZeroProbability[i] + OneToOneProbability[i];
                _inputDistG4Probability[i].G[1][0] = 1.0 - sum;
            }
            
        }

        public G4Probability GetInputProbability(int index)
        {
            return _inputDistG4Probability[index];
        }

        public void SaveDistortionsToFile(string filename)
        {
            
        }

        public int GetInputBitsNumber()
        {
            return _inputBitsNumber;
        }

        public int GetOutputBitsNumber()
        {
            return _outputDigitsNumber;
        }
    }
}
