using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplom_Work_Compare_Results_Probabilities
{
    class InputWithUnitedDistortionProbabilities
    {
        private double[] distortionToZeroProbability;
        private double[] distortionToOneProbability;
        private double[] distortionToInverseProbability;
        private double[] probalityZero;
        private double[] distortionToZeroProbabilityWithUnited;
        private double[] distortionToOneProbabilityWithUnited;
        private double[] distortionToInverseProbabilityWithUnited;
        private int[] inputBitMap;

        public InputWithUnitedDistortionProbabilities(double[] distortionToZeroProbability, double[] distortionToOneProbability, double[] distortionToInverseProbability, double[] probalityZero, double[] distortionToZeroProbabilityWithUnited, double[] distortionToOneProbabilityWithUnited, double[] distortionToInverseProbabilityWithUnited, int[] inputBitMap)
        {
            // TODO: Complete member initialization
            this.distortionToZeroProbability = distortionToZeroProbability;
            this.distortionToOneProbability = distortionToOneProbability;
            this.distortionToInverseProbability = distortionToInverseProbability;
            this.probalityZero = probalityZero;
            this.distortionToZeroProbabilityWithUnited = distortionToZeroProbabilityWithUnited;
            this.distortionToOneProbabilityWithUnited = distortionToOneProbabilityWithUnited;
            this.distortionToInverseProbabilityWithUnited = distortionToInverseProbabilityWithUnited;
            this.inputBitMap = inputBitMap;
        }
    }
}
