using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom_Work_Compare_Results_Probabilities;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;


namespace StatisticsCollection.StatCollector
{
    /// <summary>
    /// Get boolean function and distortin as parameters.
    /// Return autocorrection result.
    /// Only for logical networks with united inputs.
    /// </summary>
    class StatisticsWorker<InputDistortionType> //InputWithUnitedDistortionProbabilities
    {
        private BooleanFuntionWithInputDistortion _bfWithInpDist;
        private InputDistortionType _inpDistProb;
        // data for stat writer
        private String _boolFunctionText;
        private String _distFileName;

        public StatisticsWorker(BooleanFuntionWithInputDistortion bfWithInpDist,
            InputDistortionType inpDistProb, 
            String distFileName = "None", String boolFunctionText = "None")
        {
            _bfWithInpDist = bfWithInpDist;
            _inpDistProb = inpDistProb;
            _distFileName = distFileName;
            _boolFunctionText = boolFunctionText;

        }

        public Dictionary<int, double> GetResult()
        {
            var pCalc = new GenericProbCalculator<InputDistortionType>(_inpDistProb, _bfWithInpDist);
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
