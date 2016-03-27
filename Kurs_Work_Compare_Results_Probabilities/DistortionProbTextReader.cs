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
                /*/ < remove next code
                StreamWriter sw = new StreamWriter(_path + ".csv");
                for (int i = 0; i < inputDigitsCount; ++i)
                {
                    double pcorr = 1.0 - distortionToZeroProbability[i] - distortionToOneProbability[i]
                                   - distortionToInverseProbability[i];

                    double g00 = (pcorr + distortionToZeroProbability[i]) * probalityZero[i];
                    double g01 = (distortionToZeroProbability[i] + distortionToInverseProbability[i]) * (1.0 - probalityZero[i]);
                    double g10 = (distortionToOneProbability[i] + distortionToInverseProbability[i]) * probalityZero[i];
                    double g11 = (pcorr + distortionToOneProbability[i]) * (1.0 - probalityZero[i]);
                    sw.Write(g00 + " ;");
                    sw.Write(g01 + " ;");
                    sw.Write(g10 + " ;");
                    sw.Write(g11 + " ;");
                    sw.WriteLine("");
                }
                sw.Close();
                // /> */
                return new InputDistortionProbabilities(distortionToZeroProbability,
                    distortionToOneProbability, distortionToInverseProbability,
                    probalityZero);


            }

        }

        public InputDistortionG4 GetG4DistortionProb()
        {

            using (StreamReader sr = new StreamReader(_path))
            {
                int inputDigitsCount = ReadInt(sr);
                int outputDigitsCount = ReadInt(sr);
                double[] ZeroToZeroProbability = ReadDoubleArr(sr, inputDigitsCount);
                double[] OneToZeroProbability = ReadDoubleArr(sr, inputDigitsCount);
                double[] OneToOneProbability = ReadDoubleArr(sr, inputDigitsCount);

                return new InputDistortionG4(ZeroToZeroProbability,
                    OneToZeroProbability, OneToOneProbability, outputDigitsCount);


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
