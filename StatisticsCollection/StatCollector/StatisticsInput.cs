using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace StatisticsCollection.StatCollector
{
    /// <summary>
    /// Initialize StatisticsManager with next input.
    /// </summary>
    class StatisticsInput
    {
        public List<String> FilesWithDistortions;
        public List<String> _functionsText;
        private List<BooleanFuntionWithInputDistortion> _boolFunc;

        public StatisticsInput()
        {
            _boolFunc = new List<BooleanFuntionWithInputDistortion>();
        }

        public List<String> FunctionsText
        {
            get { return _functionsText; }
        }

        public BooleanFuntionWithInputDistortion GetBoolFunc(int funcIndex, int inputNumberOfDigits)
        {
            BooleanFuntionWithInputDistortion _boolFunc;
            // load the resource first time
            String[] functionText = new String[1];
            functionText[0] = _functionsText[funcIndex];
            int outputNumberOfDigits = 1; // Always one, input data format don't allow us anything else
            _boolFunc = new BooleanFunctionAnalytic(inputNumberOfDigits,
                outputNumberOfDigits, functionText);
            return _boolFunc;
        }
    }
}