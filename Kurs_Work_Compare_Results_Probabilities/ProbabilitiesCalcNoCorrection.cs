using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public class ProbabilitiesCalcNoCorrection : ProbabilitiesCalculatorAbstract
    {

        //private ProbabilitiesCalcNoCorrection() { }

        public ProbabilitiesCalcNoCorrection(double[] distortionToZeroProbability,
            double[] distortionToOneProbability, double[] distortionToInverseProbability,
            int inputNumberOfDigits, int outputNumberOfDigits) : 
            base(distortionToZeroProbability, distortionToOneProbability, distortionToInverseProbability,
            inputNumberOfDigits, outputNumberOfDigits)
        {
            
        }

        public override double GetCorrectResultProbability()
        {
            // the probability of correct answer equals to probability
            // of correct input data, so
            // P(Z=Z') = P(X'=X) = for(int i = 0; i < n; i++){ P *= x[i].correctValue }
            // where n - number of digits of input
            double correctAnswerProbability = 1;
            double multiplier = 1048576;
            correctAnswerProbability *= multiplier; // to reduce the error of a floating-point number multiplication
            for (int i = 0; i < _inputNumberOfDigits; i++)
            {
                correctAnswerProbability *= _correctValueProbability[i];
            }
            correctAnswerProbability /= multiplier; // to reduce the error of a floating-point number multiplication
            return correctAnswerProbability;
        }
    }
}
