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
        String _boolFinctionText;
        String _distFileName;

        public StatisticsWorker(BooleanFuntionWithInputDistortion bfWithInpDist, 
            InputWithUnitedDistortionProbabilities inpDistProb, 
            String distFileName = "None", String boolFinctionText = "None")
        {
            _bfWithInpDist = bfWithInpDist;
            _inpDistProb = inpDistProb;
            distFileName = _distFileName;
            boolFinctionText = _boolFinctionText;

        }

        public Dictionary<int, double> GetResult()
        {
            var pCalc = new ProbabilitiesCorrLogicNetWithUnitedInputs(_inpDistProb, _bfWithInpDist);
            var pCorrectResult = pCalc.GetCorrectResultProbability();
            return pCorrectResult;
        }

        public String GetBoolFunctionText()
        {
            return _boolFinctionText;
        }

        public String GetDistortionFileName()
        {
            return _distFileName;
        }
    }
}
