using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private readonly int[] _inputBitMap;

        public InputWithUnitedDistortionProbabilities(double[] distortionToZeroProbability, double[] distortionToOneProbability, double[] distortionToInverseProbability, double[] probalityZero, double[] distortionToZeroProbabilityWithUnited, double[] distortionToOneProbabilityWithUnited, double[] distortionToInverseProbabilityWithUnited, int[] inputBitMap)
        {
            // TODO: Complete member initialization
            this._distortionToZeroProbability = distortionToZeroProbability;
            this._distortionToOneProbability = distortionToOneProbability;
            this._distortionToInverseProbability = distortionToInverseProbability;
            this._probalityZero = probalityZero;
            this._distortionToZeroProbabilityWithUnited = distortionToZeroProbabilityWithUnited;
            this._distortionToOneProbabilityWithUnited = distortionToOneProbabilityWithUnited;
            this._distortionToInverseProbabilityWithUnited = distortionToInverseProbabilityWithUnited;
            this._inputBitMap = inputBitMap;
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
            throw new NotImplementedException();
            return new InputDistortionProbabilities(idpDistortionToZeroProbability, idpDistortionToOneProbability,
                idpDistortionToInverseProbability, idpProbalityZero);
        }
    }
}
