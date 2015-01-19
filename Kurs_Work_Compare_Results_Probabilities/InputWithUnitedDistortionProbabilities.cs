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
        private readonly double[] _probalityZero;
        private readonly double[] _distortionToZeroProbabilityWithUnited;
        private readonly double[] _distortionToOneProbabilityWithUnited;
        private readonly double[] _distortionToInverseProbabilityWithUnited;
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

        int GetBitMappedVariableIndex(int inputIndex)
        {
            return _inputBitMap[inputIndex];
        }
    }
}
