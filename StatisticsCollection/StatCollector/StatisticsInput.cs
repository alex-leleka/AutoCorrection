using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace StatisticsCollection.StatCollector
{

    interface IStatisticsInput
    {
        BooleanFuntionWithInputDistortion GetBoolFunc(int funcIndex, int inputNumberOfDigits);
        //List<String> FunctionsText { get; }
        List<String> FilesWithDistortions { get; }
        int FunctionsTextCount();
        int FilesWithDistortionsCount();

        bool FunctionValidate(int iFunc);
        String GetFunctionText(int iFunc);
    }
    /// <summary>
    /// Initialize StatisticsManager with next input.
    /// </summary>
    class StatisticsInputAnaliticFunc : IStatisticsInput
    {
        private readonly List<String> _functionsText;
        private List<String> _filesWithDistortions;
        public StatisticsInputAnaliticFunc(List<String> functionsText, List<String> filesWithDistortions)
        {
            _functionsText = functionsText;
            _filesWithDistortions = filesWithDistortions;
        }

        public List<String> FunctionsText
        {
            get { return _functionsText;  }
            private set { throw new NotImplementedException(); }
        }

        public List<String> FilesWithDistortions 
        { 
            get { return _filesWithDistortions; }
            private set { throw new NotImplementedException(); }
        }

        public int FunctionsTextCount()
        {
            return _functionsText.Count();
        }

        public int FilesWithDistortionsCount()
        {
            return _filesWithDistortions.Count();
        }

        public bool FunctionValidate(int iFunc)
        {
            return _functionsText[iFunc] != null &&
                   _functionsText[iFunc].Count() > 2;
        }

        public string GetFunctionText(int iFunc)
        {
            return _functionsText[iFunc];
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

    class StatisticsInputGenFunc : IStatisticsInput
    {
        private readonly List<String> _filesWithDistortions;

        public StatisticsInputGenFunc(List<String> functionsText, List<String> filesWithDistortions)
        {
            FunctionsText = functionsText;
            _filesWithDistortions = filesWithDistortions;
        }

        public List<String> FunctionsText { get; private set; }

        public List<String> FilesWithDistortions
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