using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace Diplom_Work_Compare_Results_Probabilities.StatCollector
{
    /// <summary>
    /// Get boolean function and distortin as parameters.
    /// Return autocorrection result.
    /// Only for logical networks with united inputs.
    /// </summary>
    class StatisticsWorker
    {
        private BooleanFuntionWithInputDistortion _bfWithInpDist;
        private InputWithUnitedDistortionProbabilities _inpDistProb;
        // data for stat writer
        String _boolFunctionText;
        String _distFileName;

        public StatisticsWorker(BooleanFuntionWithInputDistortion bfWithInpDist, 
            InputWithUnitedDistortionProbabilities inpDistProb, 
            String distFileName = "None", String boolFunctionText = "None")
        {
            _bfWithInpDist = bfWithInpDist;
            _inpDistProb = inpDistProb;
            distFileName = _distFileName;
            boolFunctionText = _boolFunctionText;

        }

        public Dictionary<int, double> GetResult()
        {
            var pCalc = new ProbabilitiesCorrLogicNetWithUnitedInputs(_inpDistProb, _bfWithInpDist);
            var pCorrectResult = pCalc.GetCorrectResultProbability();
            return pCorrectResult;
        }

        public String GetBoolFunctionText()
        {
            return _boolFunctionText;
        }

        public String GetDistortionFileName()
        {
            return _distFileName;
        }
    }
}
