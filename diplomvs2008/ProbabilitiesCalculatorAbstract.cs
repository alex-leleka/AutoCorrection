using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public abstract class ProbabilitiesCalculatorAbstract 
    {
        protected double[] _distortionToZeroProbability;
        protected double[] _distortionToOneProbability;
        protected double[] _distortionToInverseProbability;
        protected double[] _correctValueProbability;
        protected int _inputNumberOfDigits;
        protected int _outputNumberOfDigits;

        private ProbabilitiesCalculatorAbstract() { }
        public ProbabilitiesCalculatorAbstract(double[] distortionToZeroProbability,
            double[] distortionToOneProbability, double[] distortionToInverseProbability, int inputNumberOfDigits, int outputNumberOfDigits)
        {
            // creating arrays
            _distortionToInverseProbability = new double[inputNumberOfDigits];
            _distortionToZeroProbability = new double[inputNumberOfDigits];
            _distortionToOneProbability = new double[inputNumberOfDigits];
            _correctValueProbability = new double[inputNumberOfDigits];
            // copy data
            for (int i = 0; i < inputNumberOfDigits; i++)
            {
                _distortionToZeroProbability[i] = distortionToZeroProbability[i];
                _distortionToInverseProbability[i] = distortionToInverseProbability[i];
                _distortionToOneProbability[i] = distortionToOneProbability[i];
                _correctValueProbability[i] = 1.0 - distortionToOneProbability[i] - distortionToZeroProbability[i] - distortionToInverseProbability[i];
            }
            _inputNumberOfDigits = inputNumberOfDigits;
            _outputNumberOfDigits = outputNumberOfDigits;
        }
        abstract public double GetCorrectResultProbability();
    }
}
