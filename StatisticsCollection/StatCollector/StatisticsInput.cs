using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace StatisticsCollection.StatCollector
{

    interface IStatisticsInput
    {
        BooleanFuntionWithInputDistortion GetBoolFunc(int funcIndex, int inputNumberOfDigits);
        List<String> FunctionsText { get; }
        List<String> FilesWithDistortions { get; }
        int FunctionsTextCount();
        int FilesWithDistortionsCount();
    }
    /// <summary>
    /// Initialize StatisticsManager with next input.
    /// </summary>
    class StatisticsInputAnaliticFunc : IStatisticsInput
    {
        public StatisticsInputAnaliticFunc(List<String> functionsText, List<String> filesWithDistortions)
        {
            FunctionsText = functionsText;
            FilesWithDistortions = filesWithDistortions;
        }

        public List<String> FunctionsText { get; private set; }

        public List<String> FilesWithDistortions { get; private set; }

        public int FunctionsTextCount()
        {
            throw new NotImplementedException();
        }

        public int FilesWithDistortionsCount()
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

    class StatisticsInputGenFunc : IStatisticsInput
    {
        public StatisticsInputGenFunc(List<String> functionsText, List<String> filesWithDistortions)
        {
            FunctionsText = functionsText;
            FilesWithDistortions = filesWithDistortions;
        }

        public List<String> FunctionsText { get; private set; }

        public List<String> FilesWithDistortions { get; private set; }

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