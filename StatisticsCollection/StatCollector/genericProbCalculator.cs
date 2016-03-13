using System;
using System.Collections.Generic;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;
using Diplom_Work_Compare_Results_Probabilities;
using SubfunctionPrototype;

namespace StatisticsCollection.StatCollector
{
    class GenericProbCalculator<T>
    {
        private T _inpDistProb;
        private BooleanFuntionWithInputDistortion _bfWithInpDist;
        private readonly bool _useSubfunctionMethod;

        public GenericProbCalculator(T inpDistProb, BooleanFuntionWithInputDistortion bfWithInpDist, bool useSubfunctionMethod)
        {
            // TODO: Complete member initialization
            _inpDistProb = inpDistProb;
            _bfWithInpDist = bfWithInpDist;
            _useSubfunctionMethod = useSubfunctionMethod;
        }
        internal Dictionary<int, double> GetCorrectResultProbability()
        {
            var inputWithUnitedDistortionProbabilities = _inpDistProb as InputWithUnitedDistortionProbabilities;
            if (inputWithUnitedDistortionProbabilities != null)
            {
                var pcalc = new ProbabilitiesCorrLogicNetWithUnitedInputs(inputWithUnitedDistortionProbabilities, _bfWithInpDist);
                return pcalc.GetCorrectResultProbability();
            }
            var idp = _inpDistProb as InputDistortionProbabilities;
            if (idp != null)
            {
                G4Probability originalF;
                if (_useSubfunctionMethod)
                {
                    var pCalc = new SubfunctionMethodDistortionCalc(_bfWithInpDist, idp);
                    originalF = pCalc.GetCorrectResultProbability();
                }
                else
                {
                    originalF = ProbabilitiesGxyCalc.CalculateFunctionDistortion(_bfWithInpDist, idp); 
                }

                Dictionary<int, double> d = new Dictionary<int, double>(4);
                d.Add(0, originalF.G[0][0]);
                d.Add(1, originalF.G[0][1]);
                d.Add(10, originalF.G[1][0]);
                d.Add(11, originalF.G[1][1]);
                return d;
            }
            throw new Exception("InputDistortionType is unknown type!");
        }
    }
}
