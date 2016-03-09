﻿using System;
using System.Collections.Generic;
using System.Linq;
using Diplom_Work_Compare_Results_Probabilities;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace StatisticsCollection.StatCollector
{
    /// <summary>
    /// Initialize StatisticsManager with next input.
    /// </summary>
    class StatisticsInputTextTruthTableFunc : IStatisticsInput
    {
        private readonly List<String> _filesPathText;
        private readonly List<String> _filesWithDistortions;
        private BooleanFuntionWithInputDistortion _boolFunc;
        public StatisticsInputTextTruthTableFunc(List<String> filesPathText, List<String> filesWithDistortions)
        {
            _boolFunc = null;
            _filesPathText = filesPathText;
            _filesWithDistortions = filesWithDistortions;
        }

        public List<String> FilesPathText
        {
            get { return _filesPathText;  }
            private set { throw new NotImplementedException(); }
        }

        public List<String> FilesWithDistortions 
        { 
            get { return _filesWithDistortions; }
            private set { throw new NotImplementedException(); }
        }

        public int FunctionsTextCount()
        {
            return _filesPathText.Count();
        }

        public int FilesWithDistortionsCount()
        {
            return _filesWithDistortions.Count();
        }

        public bool FunctionValidate(int iFunc)
        {
            if (_boolFunc != null)
                return true;
            // load the resource first time
            String path = FilesPathText[iFunc];
            var reader = new BoolFuncTextReader(path);
#if !DEBUG
            try
            {
#endif             
                _boolFunc = reader.GetBoolFunc();
#if !DEBUG
            }
            catch (Exception e)
            {

                Logger.WriteLine("StatisticsInputTextTruthTableFunc.FunctionValidate error: " + e.Message);
                return false;
            }
#endif
            return true; // text bool function should be fine
        }

        public string GetFunctionText(int iFunc)
        {
            return _filesPathText[iFunc];
        }

        public BooleanFuntionWithInputDistortion GetBoolFunc(int funcIndex, int inputNumberOfDigits)
        {
            if (_boolFunc != null)
                return _boolFunc;
            // load the resource first time
            String path = FilesPathText[funcIndex];
            var reader = new BoolFuncTextReader(path);
            _boolFunc = reader.GetBoolFunc();
            return _boolFunc;
        }
    }
}