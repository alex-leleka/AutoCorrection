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
    /// Take as input array of files with distortions for logic networks with united input
    /// and array of analytic boolean functions. All of them should have the same number of 2nd level inputs
    /// and the same number of inputs in function.
    /// </summary>
    class StatisticsTasksPool
    {
        private readonly StatisticsInput _input;
        int _distortionsIndex;
        int _funcIndex;
        List<InputWithUnitedDistortionProbabilities> _inpDist;
        List<BooleanFuntionWithInputDistortion> _boolFunc;

        public StatisticsTasksPool(StatisticsInput input)
        {
            _input = input;
            _distortionsIndex = _funcIndex = 0;
            InitResources();
        }

        public StatisticsWorker GetNextWorker()
        {
            // don't replace index increment without recheking of all possible outcomes
            while (_distortionsIndex < _input.FilesWithDistortions.Count)
            {
                while (_funcIndex < _input.FunctionsText.Count)
                {
                    int iFunc = _funcIndex++;
                    int jDist = _distortionsIndex;

                    // skip empty lines if any
                    if (_input.FilesWithDistortions[jDist].Length < 2 || _input.FunctionsText[iFunc].Length < 2)
                        return null;

                    return new StatisticsWorker(GetBoolFunctionWithInpDist(iFunc), GetInpDistProb(jDist),
                        _input.FilesWithDistortions[jDist], _input.FunctionsText[iFunc]);
                }
                _funcIndex = 0;
                ++_distortionsIndex;
            }
            return null;
        }

        private InputWithUnitedDistortionProbabilities GetInpDistProb(int distortionsIndex)
        {
            if (_inpDist.Count <= distortionsIndex)
                _inpDist.Add(null);
            if (_inpDist[distortionsIndex] == null)
            {
                // load the resource first time
                String path = _input.FilesWithDistortions[distortionsIndex];
                var reader = new DistortionProbUnitedInputTextReader(path);
                _inpDist[distortionsIndex] = reader.GetDistortionProb();
            }
            return _inpDist[distortionsIndex];
        }

        private BooleanFuntionWithInputDistortion GetBoolFunctionWithInpDist(int funcIndex)
        {
            if (_boolFunc.Count <= funcIndex) // fixme: works only in case of sequential access
                _boolFunc.Add(null);
            if (_boolFunc[funcIndex] == null)
            {
                // load the resource first time
                String[] functionText = new String[1];
                functionText[0] = _input.FunctionsText[funcIndex];
                int inputNumberOfDigits = GetInpDistProb(0).GetSecondLevelInputsCount();
                int outputNumberOfDigits = 1; // Always one, input data format don't allow us anything else
                _boolFunc[funcIndex] = new BooleanFunctionAnalytic(inputNumberOfDigits, 
                    outputNumberOfDigits,functionText);
            }
            return _boolFunc[funcIndex];
        }

        private void InitResources()
        {
            // create empty lists, we don't need to allocate all at time.
            // we will load them as needed.
            _boolFunc = new List<BooleanFuntionWithInputDistortion>(_input.FunctionsText.Count);
            _inpDist = new List<InputWithUnitedDistortionProbabilities>(_input.FilesWithDistortions.Count);
            
        }

    }
}
