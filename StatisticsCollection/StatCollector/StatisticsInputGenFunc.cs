using System;
using System.Collections.Generic;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace StatisticsCollection.StatCollector
{
    class StatisticsInputGenFunc : IStatisticsInput
    {
        private readonly List<string> _filesWithDistortions;

        public StatisticsInputGenFunc(List<string> functionsText, List<string> filesWithDistortions)
        {
            FunctionsText = functionsText;
            _filesWithDistortions = filesWithDistortions;
        }

        public List<string> FunctionsText { get; private set; }

        public List<string> FilesWithDistortions
        {
            get { return _filesWithDistortions; }
            private set { throw new NotImplementedException(); }
        }

        public int FunctionsTextCount()
        {
            return FunctionsText.Count;
        }

        public int FilesWithDistortionsCount()
        {
            return _filesWithDistortions.Count;
        }

        public bool FunctionValidate(int iFunc)
        {
            throw new NotImplementedException();
        }

        public string GetFunctionText(int iFunc)
        {
            throw new NotImplementedException();
        }

        public BooleanFuntionWithInputDistortion GetBoolFunc(int funcIndex, int inputNumberOfDigits)
        {
            // load the resource first time
            String[] functionText = new String[1];
            functionText[0] = FunctionsText[funcIndex];
            const int outputNumberOfDigits = 1; // Always one, input data format don't allow us anything else
            BooleanFuntionWithInputDistortion boolFunc = new BooleanFunctionAnalytic(inputNumberOfDigits,
                outputNumberOfDigits, functionText);
            return boolFunc;
        }
    }
}