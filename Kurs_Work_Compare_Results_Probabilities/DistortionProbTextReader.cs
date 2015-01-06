using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public class DistortionProbTextReader
    {
        const char commentChar = '%';
        private string _path;
        public DistortionProbTextReader(string path)
        {
            _path = path;
        }
        public InputDistortionProbabilities GetDistortionProb()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    int inputDigitsCount = ReadInt(sr);
                    int outputDigitsCount = ReadInt(sr);
                    double[] distortionToZeroProbability = ReadDoubleArr(sr, inputDigitsCount);
                    double[] distortionToOneProbability = ReadDoubleArr(sr, inputDigitsCount);
                    double[] distortionToInverseProbability = ReadDoubleArr(sr, inputDigitsCount);
                    double[] probalityZero = ReadDoubleArr(sr, inputDigitsCount);
                    return new InputDistortionProbabilities(distortionToZeroProbability,
                        distortionToOneProbability, distortionToInverseProbability,
                        probalityZero);
                }
            }
            catch (Exception e)
            {
                throw new Exception("The file could not be read:"+ e.Message);
            }
        }
        private int ReadInt(StreamReader sr)
        {
            string line;
            do
            {
                if (sr.EndOfStream)
                    throw new Exception("Unexpecting end of file!");
                line = sr.ReadLine();
                line = line.Trim();
            }
            while ((line.Length < 1) || (line[0] == commentChar));
            return Convert.ToInt32(line);
        }
        private int[] ReadIntArr(StreamReader sr, int length)
        {
            string line;
            do
            {
                if (sr.EndOfStream)
                    throw new Exception("Unexpecting end of file!");
                line = sr.ReadLine();
                line = line.Trim();
            }
            while ((line.Length < 1) || (line[0] == commentChar));
            int[] arr = new int[length];
            var values = line.Split();
            for(int i = 0; i < length;i++)
            {
                arr[i] = Convert.ToInt32(values[i]);
            }
            return arr;
        }
        private double[] ReadDoubleArr(StreamReader sr, int length)
        {
            string line;
            do
            {
                if (sr.EndOfStream)
                    throw new Exception("Unexpecting end of file!");
                line = sr.ReadLine();
                line = line.Trim();
            }
            while ((line.Length < 1) || (line[0] == commentChar));
            double[] arr = new double[length];
            var values = line.Split();
            for(int i = 0; i < length;i++)
            {
                arr[i] = Convert.ToDouble(values[i]);
            }
            return arr;
        }
    }
}
