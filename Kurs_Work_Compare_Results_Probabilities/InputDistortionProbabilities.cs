using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public class InputDistortionProbabilities
    {
        protected double[] _distortionToZeroProbability;
        protected double[] _distortionToOneProbability;
        protected double[] _distortionToInverseProbability;
        protected double[] _correctValueProbability;
        double[] _probalityZero;
        public InputDistortionProbabilities(double[] distortionToZeroProbability,
            double[] distortionToOneProbability, double[] distortionToInverseProbability, double[] zeroProbability)
        {
            if ((distortionToInverseProbability.Length == distortionToZeroProbability.Length)
                && (distortionToZeroProbability.Length == distortionToOneProbability.Length)
                && (zeroProbability.Length == distortionToOneProbability.Length))
                SetDistortionProbabilitiesVectors(distortionToZeroProbability, distortionToOneProbability, distortionToInverseProbability, zeroProbability);
            else
                throw new Exception("InputDistortionProbabilities array length not match");
        }
        private void SetDistortionProbabilitiesVectors(double[] distortionToZeroProbability,
            double[] distortionToOneProbability, double[] distortionToInverseProbability, double[] zeroProbability)
        {
            // creating arrays
            int len = distortionToInverseProbability.Length;
            _distortionToInverseProbability = new double[len];
            _distortionToZeroProbability = new double[len];
            _distortionToOneProbability = new double[len];
            _correctValueProbability = new double[len];
            _probalityZero = new double[len];
            // copy data
            for (int i = 0; i < len; i++)
            {
                _distortionToZeroProbability[i] = distortionToZeroProbability[i];
                _distortionToInverseProbability[i] = distortionToInverseProbability[i];
                _distortionToOneProbability[i] = distortionToOneProbability[i];
                _correctValueProbability[i] = 1.0 - distortionToOneProbability[i] - distortionToZeroProbability[i] - distortionToInverseProbability[i];
                _probalityZero = zeroProbability;
            }
        }
        /// <summary>
        /// Array of probability vectors. Index values correspond to
        /// correctValue 0,  distortionToZero 1, distortionToOne 2, distortionToInverse 3
        /// </summary>
        public double[][] ProbabilityVectors
        {
            get { return new double[][] { _correctValueProbability, _distortionToZeroProbability, _distortionToOneProbability, _distortionToInverseProbability }; }
        }
        public double[] DistortionToZeroProbability
        {
            get { return _distortionToZeroProbability; }
        }
        public double[] DistortionToOneProbability
        {
            get { return _distortionToOneProbability; }
        }
        public double[] DistortionToInverseProbability
        {
            get { return _distortionToInverseProbability; }
        }
        public double[] ZeroProbability
        {
            get { return _probalityZero; }
        }
        // p[0] probability of zero(0) in i-th bit
        // p[1] can be calculeted as p1[i] = 1 - p0[i];
        public double ProbabilityZeroAndOne(int zeroOrOne, int index)
        {
            if (zeroOrOne == 0)
                return _probalityZero[index];
            return 1 - _probalityZero[index];
        }
        public double ProbabilityZeroAndOne(bool zeroOrOne, int index)
        {
            if (zeroOrOne == false)
                return _probalityZero[index];
            return 1 - _probalityZero[index];
        }
    }
}
