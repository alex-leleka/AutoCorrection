using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Diplom_Work_Compare_Results_Probabilities
{
    class InputWithUnitedDistortionProbabilities
    {
        private readonly double[] _distortionToZeroProbability;
        private readonly double[] _distortionToOneProbability;
        private readonly double[] _distortionToInverseProbability;
    
        private readonly double[] _distortionToZeroProbabilityWithUnited;
        private readonly double[] _distortionToOneProbabilityWithUnited;
        private readonly double[] _distortionToInverseProbabilityWithUnited;

        private readonly double[] _probalityZero;
        /// <summary>
        /// Maps index of variable on logic network connected to input.
        /// </summary>
        private readonly int[] _inputBitMap;

        private List<int>[] _firstLevelInputsTargets;

        private void ConvertInputBitMapToFirstLevelInputsTargets()
        {
            _firstLevelInputsTargets = new List<int>[GetLogicNetworkBitsCount()];
            for (int circuitInputIndex = 0; circuitInputIndex < _inputBitMap.Length; circuitInputIndex++)
            {
                _firstLevelInputsTargets[_inputBitMap[circuitInputIndex]].Add(circuitInputIndex);
            }

        }

        public ReadOnlyCollection<int> GetFirstLevelInputsTargets(int firstLevelIndex)
        {
            Debug.Assert(_firstLevelInputsTargets != null, "_firstLevelInputsTargets != null");
            return new ReadOnlyCollection<int> (_firstLevelInputsTargets[firstLevelIndex]);
        }

        private double GetNoDistortionProbability(int index)
        {
            return 1 -_distortionToInverseProbability[index] - _distortionToOneProbability[index] - _distortionToZeroProbability[index];
        }
        private double GetNoDistortionProbabilityWithUnited(int index)
        {
            return 1 - _distortionToInverseProbabilityWithUnited[index] - _distortionToOneProbabilityWithUnited[index] - _distortionToZeroProbabilityWithUnited[index];
        }

        public InputWithUnitedDistortionProbabilities(double[] distortionToZeroProbability, double[] distortionToOneProbability, double[] distortionToInverseProbability, double[] probalityZero, double[] distortionToZeroProbabilityWithUnited, double[] distortionToOneProbabilityWithUnited, double[] distortionToInverseProbabilityWithUnited, int[] inputBitMap)
        {
            _distortionToZeroProbability = distortionToZeroProbability;
            _distortionToOneProbability = distortionToOneProbability;
            _distortionToInverseProbability = distortionToInverseProbability;
            _probalityZero = probalityZero;
            _distortionToZeroProbabilityWithUnited = distortionToZeroProbabilityWithUnited;
            _distortionToOneProbabilityWithUnited = distortionToOneProbabilityWithUnited;
            _distortionToInverseProbabilityWithUnited = distortionToInverseProbabilityWithUnited;
            _inputBitMap = inputBitMap;
            ConvertInputBitMapToFirstLevelInputsTargets();
        }

        public int GetBitMappedVariableIndex(int inputIndex)
        {
            // max index is GetCircuitBitsCount()
            return _inputBitMap[inputIndex];
        }

        /// <summary>
        /// Logic network bits count is number of variables on the input
        /// without repeating.
        /// </summary>
        /// <returns>count of different variables on input</returns>
        public int GetLogicNetworkBitsCount()
        {
            return _distortionToZeroProbabilityWithUnited.Length;
        }

        /// <summary>
        /// Circuit bits count is number of variables on the input
        /// including the same variables that repeat on different inputs(with united inputs).
        /// </summary>
        /// <returns>count of real variables on input</returns>
        public int GetCircuitBitsCount()
        {
            return _distortionToZeroProbability.Length;
        }

        public double GetDistortionToZeroProbability(int index)
        {
            return _distortionToZeroProbability[index];
        }

        public double GetDistortionToOneProbability(int index)
        {
            return _distortionToOneProbability[index];
        }

        public double GetDistortionToInverseProbability(int index)
        {
            return _distortionToInverseProbability[index];
        }

        public double GetDistortionToZeroProbabilityWithUnited(int index)
        {
            return _distortionToZeroProbabilityWithUnited[index];
        }

        public double GetDistortionToOneProbabilityWithUnited(int index)
        {
            return _distortionToOneProbabilityWithUnited[index];
        }

        public double GetDistortionToInverseProbabilityWithUnited(int index)
        {
            return _distortionToInverseProbabilityWithUnited[index];
        }

        public double GetProbalityZero(int index)
        {
            // max index GetCircuitBitsCount()
            return _probalityZero[index];
        }

        public double GetProbalityDigit(int digit, int index)
        {
            if (digit == 0)
                return _probalityZero[index];
            if (digit == 1)
                return 1 - _probalityZero[index];
            throw new ArgumentException("GetProbalityDigit argument invalid with value: " + digit.ToString());
        }

        public InputDistortionProbabilities ConvertToInputDistortionProbabilities()
        {
            double[] idpDistortionToZeroProbability = new double[GetCircuitBitsCount()];
            double[] idpDistortionToOneProbability = new double[GetCircuitBitsCount()];
            double[] idpDistortionToInverseProbability = new double[GetCircuitBitsCount()];
            double[] idpProbalityZero = new double[GetCircuitBitsCount()];

            for (int i = 0; i < idpDistortionToInverseProbability.Length; i++)
            {
                idpDistortionToZeroProbability[i] = _distortionToZeroProbabilityWithUnited[i];
                idpDistortionToOneProbability[i] = _distortionToOneProbabilityWithUnited[i];
                idpDistortionToInverseProbability[i] = _distortionToInverseProbabilityWithUnited[i];
                int imapped = _inputBitMap[i];
                idpProbalityZero[i] = _probalityZero[imapped] * (GetNoDistortionProbability(imapped) + _distortionToZeroProbability[imapped]) 
                    + (1 - _probalityZero[imapped]) * (GetNoDistortionProbability(imapped) + _distortionToInverseProbability[imapped]);
            }
            return new InputDistortionProbabilities(idpDistortionToZeroProbability, idpDistortionToOneProbability,
                idpDistortionToInverseProbability, idpProbalityZero);
        }

        internal double GetFistLevelDistortionProbability(int distortionType, int inputIndex)
        {
            switch (inputIndex)
            {
                case 0:
                    return GetNoDistortionProbability(inputIndex);
                case 1:
                    return GetDistortionToZeroProbability(inputIndex);
                case 2:
                    return GetDistortionToOneProbability(inputIndex);
                case 3:
                    return GetDistortionToInverseProbability(inputIndex);
            }
            throw new Exception(string.Format("Distortion type {0} doesn't exist.", distortionType));
        }

        internal double GetSecondLevelDistortionProbability(int distortionType, int inputIndex)
        {
            switch (inputIndex)
            {
                case 0:
                    return GetNoDistortionProbabilityWithUnited(inputIndex);
                case 1:
                    return GetDistortionToZeroProbabilityWithUnited(inputIndex);
                case 2:
                    return GetDistortionToOneProbabilityWithUnited(inputIndex);
                case 3:
                    return GetDistortionToInverseProbabilityWithUnited(inputIndex);
            }
            throw new Exception(string.Format("Distortion type {0} doesn't exist.", distortionType));
        }
    }
}
