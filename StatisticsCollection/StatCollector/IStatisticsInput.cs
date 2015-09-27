using System;
using System.Collections.Generic;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace StatisticsCollection.StatCollector
{
    interface IStatisticsInput
    {
        BooleanFuntionWithInputDistortion GetBoolFunc(int funcIndex, int inputNumberOfDigits);
        //List<String> FunctionsText { get; }
        List<string> FilesWithDistortions { get; }
        int FunctionsTextCount();
        int FilesWithDistortionsCount();

        bool FunctionValidate(int iFunc);
        String GetFunctionText(int iFunc);
    }
}