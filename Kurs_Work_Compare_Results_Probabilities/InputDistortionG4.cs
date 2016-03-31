using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public class InputDistortionG4 : IinputDistortionProbabilities
    {
        private G4Probability[] _inputDistG4Probability;
        private int _inputBitsNumber;
        private int _outputDigitsNumber;

        public InputDistortionG4(G4Probability[] inputDistG4Probability, int outputDigitsNumber)
        {
            _inputDistG4Probability = inputDistG4Probability;
            _inputBitsNumber = inputDistG4Probability.Length;
            _outputDigitsNumber = outputDigitsNumber;
        }

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

        public int GetInputDigitsCount()
        {
            return _inputBitsNumber;
        }

        public int GetOutputBitsNumber()
        {
            return _outputDigitsNumber;
        }

        public InputDistortionG4 GetAdderLowerBitsDistortion(int separateBitsNumber)
        {
            int size = 2*separateBitsNumber;
            G4Probability[] inputDistG4Probability = new G4Probability[size];

            for (int i = 0; i < separateBitsNumber; ++i)
            {
                // copy op1 lower bits distotions
                inputDistG4Probability[i] = _inputDistG4Probability[i];
                // copy op2 lower bits distotions
                inputDistG4Probability[separateBitsNumber + i] = _inputDistG4Probability[_inputBitsNumber/2 + i];
            }
            var inpDist = new InputDistortionG4(inputDistG4Probability, separateBitsNumber + 1);
            return inpDist;
        }

        public InputDistortionG4 GetAdderHigherBitsDistortion(int separateBitsNumber, G4Probability g4Probability)
        {
            int size = _inputBitsNumber - 2 * separateBitsNumber + 1;
            int bitsInOperand = _inputBitsNumber/2 - separateBitsNumber;
            G4Probability[] inputDistG4Probability = new G4Probability[size];

            inputDistG4Probability[0] = g4Probability; // carry bit
            for (int i = 0; i < bitsInOperand; ++i)
            {
                inputDistG4Probability[i + 1] = _inputDistG4Probability[separateBitsNumber + i];
                inputDistG4Probability[bitsInOperand + i + 1] = _inputDistG4Probability[_inputBitsNumber / 2 + separateBitsNumber + i];
            }
            var inpDist = new InputDistortionG4(inputDistG4Probability, bitsInOperand + 1);
            return inpDist;
        }
    }
}
