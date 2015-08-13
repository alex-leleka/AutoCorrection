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
        List<String> _filesWithDistortions;
        List<String> _functionsText;
        int _distortionsIndex;
        int _funcIndex;
        List<InputWithUnitedDistortionProbabilities> _inpDist;
        List<BooleanFuntionWithInputDistortion> _boolFunc;

        public StatisticsTasksPool(List<String> filesWithDistortions, List<String> functionsText)
        {
            _filesWithDistortions = filesWithDistortions;
            _functionsText = functionsText;
            _distortionsIndex = _funcIndex = 0;
            InitResources();
        }

        public StatisticsTasksPool(StatisticsInput input)
            : this(input.filesWithDistortions, input.functionsText)
        {
        }

        public StatisticsWorker GetNextWorker()
        {
            // don't replace index increment without recheking of all possible outcomes
            while (_distortionsIndex < _filesWithDistortions.Count)
            {
                while (_funcIndex < _functionsText.Count)
                {
                    int iFunc = _funcIndex++;
                    int jDist = _distortionsIndex;

                    // skip empty lines if any
                    if (_filesWithDistortions[jDist].Length < 2 || _functionsText[iFunc].Length < 2)
                        return null;

                    return new StatisticsWorker(GetBoolFunctionWithInpDist(iFunc), GetInpDistProb(jDist),
                        _filesWithDistortions[jDist], _functionsText[iFunc]);
                }
                _funcIndex = 0;
                ++_distortionsIndex;
            }
            return null;
        }

        private InputWithUnitedDistortionProbabilities GetInpDistProb(int distortionsIndex)
        {
            if (_inpDist[distortionsIndex] == null)
            {
                // load the resource first time
                String path = _filesWithDistortions[distortionsIndex];
                var reader = new DistortionProbUnitedInputTextReader(path);
                _inpDist[distortionsIndex] = reader.GetDistortionProb();
            }
            return _inpDist[distortionsIndex];
        }

        private BooleanFuntionWithInputDistortion GetBoolFunctionWithInpDist(int funcIndex)
        {
            if (_boolFunc[funcIndex] == null)
            {
                // load the resource first time
                String[] functionText = new String[1];
                functionText[0] = _functionsText[funcIndex];
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
            _boolFunc = new List<BooleanFuntionWithInputDistortion>(_functionsText.Count);
            _inpDist = new List<InputWithUnitedDistortionProbabilities>(_filesWithDistortions.Count);
            
        }

    }
}
