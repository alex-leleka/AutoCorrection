using System;
using System.Diagnostics;
using System.IO;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public class BoolFuncTextReader
    {
        const char commentChar = '%';
        private string _path;
        public BoolFuncTextReader(string path)
        {
            _path = path;
        }

        private int ReadInt(StreamReader sr)
        {
            string line;
            do
            {
                if (sr.EndOfStream)
                    throw new Exception("Unexpecting end of file!");
                line = sr.ReadLine();
                Debug.Assert(line != null, "BoolFuncTextReader.ReadInt() : line != null");
                line = line.Trim();
            }
            while ((line.Length < 1) || (line[0] == commentChar));
            return Convert.ToInt32(line);
        }

        public BooleanFunctionTruthTable GetBoolFunc()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    int inputDigitsCount = ReadInt(sr);
                    int outputDigitsCount = ReadInt(sr);
                    int[] bfResults = new int[1 << inputDigitsCount];
                    for (int i = 0; i < bfResults.Length; i++)
                        bfResults[i] = ReadInt(sr);
                    var bfTruthTable = new BooleanFunctionTruthTable(inputDigitsCount, outputDigitsCount);
                    bfTruthTable.SetResultTable(bfResults);
                    return bfTruthTable;
                }
            }
            catch (Exception e)
            {
                throw new Exception("The file could not be read:" + e.Message);
            }
        }
    }
}
