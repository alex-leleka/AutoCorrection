using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public class DistortionProbUnitedInputTextReader : DistortionProbTextReader
    {
        public DistortionProbUnitedInputTextReader(string path) : base(path)
        {
        }

        new public InputWithUnitedDistortionProbabilities GetDistortionProb()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    int inputDigitsCount = ReadInt(sr);
                    int outputDigitsCount = ReadInt(sr);
                    int inputDigitsCountWithUnited = ReadInt(sr);
                    var inputBitMap = ReadIntArr(sr, inputDigitsCountWithUnited);
                    double[] distortionToZeroProbability = ReadDoubleArr(sr, inputDigitsCount);
                    double[] distortionToOneProbability = ReadDoubleArr(sr, inputDigitsCount);
                    double[] distortionToInverseProbability = ReadDoubleArr(sr, inputDigitsCount);
                    double[] probalityZero = ReadDoubleArr(sr, inputDigitsCount);

                    double[] distortionToZeroProbabilityWithUnited = ReadDoubleArr(sr, inputDigitsCountWithUnited);
                    double[] distortionToOneProbabilityWithUnited = ReadDoubleArr(sr, inputDigitsCountWithUnited);
                    double[] distortionToInverseProbabilityWithUnited = ReadDoubleArr(sr, inputDigitsCountWithUnited);
                    return new InputWithUnitedDistortionProbabilities(distortionToZeroProbability,
                        distortionToOneProbability, distortionToInverseProbability, probalityZero, 
                        distortionToZeroProbabilityWithUnited, distortionToOneProbabilityWithUnited, 
                        distortionToInverseProbabilityWithUnited, inputBitMap);
                }
            }
            catch (Exception e)
            {
                throw new Exception("The file could not be read:" + e.Message);
            }
        }
    }
}
