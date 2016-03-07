using System;
using System.IO;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public class DistortionProbTextReader
    {
        protected const char CommentChar = '%';
        // ReSharper disable once InconsistentNaming
        protected string _path;
        public DistortionProbTextReader(string path)
        {
            _path = path;
        }
        public InputDistortionProbabilities GetDistortionProb()
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
        protected int ReadInt(StreamReader sr)
        {
            string line;
            do
            {
                if (sr.EndOfStream)
                    throw new Exception("Unexpecting end of file!");
                line = sr.ReadLine();
                line = line.Trim();
            }
            while ((line.Length < 1) || (line[0] == CommentChar));
            return Convert.ToInt32(line);
        }
        protected int[] ReadIntArr(StreamReader sr, int length)
        {
            string line;
            do
            {
                if (sr.EndOfStream)
                    throw new Exception("Unexpecting end of file!");
                line = sr.ReadLine();
                line = line.Trim();
            }
            while ((line.Length < 1) || (line[0] == CommentChar));
            int[] arr = new int[length];
            var values = line.Split();
            for(int i = 0; i < length;i++)
            {
                arr[i] = Convert.ToInt32(values[i]);
            }
            return arr;
        }
        protected double[] ReadDoubleArr(StreamReader sr, int length)
        {
            string line;
            do
            {
                if (sr.EndOfStream)
                    throw new Exception("Unexpecting end of file!");
                line = sr.ReadLine();
                line = line.Trim();
            }
            while ((line.Length < 1) || (line[0] == CommentChar));
            double[] arr = new double[length];
            var values = line.Split();
            #if DEBUG
            if(values.Length != length)
                throw new IndexOutOfRangeException("Index out range in ReadDoubleArr() expected,values.Length != length, check the text file!");
            #endif
            
            for(int i = 0; i < length;i++)
            {
                arr[i] = Convert.ToDouble(values[i]);
            }
            return arr;
        }
    }
}
