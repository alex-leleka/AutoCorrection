using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Diplom_Work_Compare_Results_Probabilities;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace StatisticsCollection.StatCollector
{
    /// <summary>
    /// Take as input array of files with distortions for logic networks with united input
    /// and array of analytic boolean functions. All of them should have the same number of 2nd level inputs
    /// and the same number of inputs in function.
    /// </summary>
    class StatisticsTasksPool
    {
        private readonly IStatisticsInput _inputAnaliticFunc;
        int _distortionsIndex;
        int _funcIndex;
        List<InputWithUnitedDistortionProbabilities> _inpDist;
        List<BooleanFuntionWithInputDistortion> _boolFunc;

        public StatisticsTasksPool(IStatisticsInput inputAnaliticFunc)
        {
            _inputAnaliticFunc = inputAnaliticFunc;
            _distortionsIndex = _funcIndex = 0;
            InitResources();
        }

        public StatisticsWorker GetNextWorker()
        {
            // don't replace index increment without recheking of all possible outcomes
            while (_distortionsIndex < _inputAnaliticFunc.FilesWithDistortionsCount())
            {
                while (_funcIndex < _inputAnaliticFunc.FunctionsTextCount())
                {
                    int iFunc = _funcIndex++;
                    int jDist = _distortionsIndex;

                    // skip empty lines if any
                    if ((_inputAnaliticFunc.FilesWithDistortions[jDist].Length < 2) || !_inputAnaliticFunc.FunctionValidate(iFunc))
                        return null;

                    return new StatisticsWorker(GetBoolFunctionWithInpDist(iFunc), GetInpDistProb(jDist),
                        _inputAnaliticFunc.FilesWithDistortions[jDist], _inputAnaliticFunc.GetFunctionText(iFunc));
                }
                _funcIndex = 0;
                ++_distortionsIndex;
            }
            // TODO: replace while with for

            return null;
        }

        private InputWithUnitedDistortionProbabilities GetInpDistProb(int distortionsIndex)
        {
            if (_inpDist.Count <= distortionsIndex)
                _inpDist.Add(null);
            if (_inpDist[distortionsIndex] == null)
            {
                // load the resource first time
                String path = _inputAnaliticFunc.FilesWithDistortions[distortionsIndex];
                var reader = new DistortionProbUnitedInputTextReader(path);
                _inpDist[distortionsIndex] = reader.GetDistortionProb();
            }
            return _inpDist[distortionsIndex];
        }

        private BooleanFuntionWithInputDistortion GetBoolFunctionWithInpDist(int funcIndex)
        {
            while (_boolFunc.Count <= funcIndex)
                _boolFunc.Add(null);
            if (_boolFunc[funcIndex] == null)
            {
                int inputNumberOfDigits = GetInpDistProb(0).GetSecondLevelInputsCount();

                _boolFunc[funcIndex] = _inputAnaliticFunc.GetBoolFunc(funcIndex, inputNumberOfDigits);
            }
            return _boolFunc[funcIndex];
        }

        private void InitResources()
        {
            // create empty lists, we don't need to allocate all at time.
            // we will load them as needed.
            _boolFunc = new List<BooleanFuntionWithInputDistortion>(_inputAnaliticFunc.FunctionsTextCount());
            _inpDist = new List<InputWithUnitedDistortionProbabilities>(_inputAnaliticFunc.FilesWithDistortionsCount());
            
        }

    }
}
