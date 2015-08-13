using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Diplom_Work_Compare_Results_Probabilities.StatCollector
{
    /// <summary>
    /// Manage all work related to statistics collections for multiple distortions and 
    /// bool functions. Report progress to main thred.
    /// </summary>
    class StatisticsManager
    {
        private StatisticsInput _input;
        private int _oldProgress;

        public StatisticsManager(StatisticsInput input)
        {
            SetInput(input);
        }

        public void Run()
        {
            if (_input == null)
                throw new Exception("StatisticsManager has no input");

            int MaxWorkers = _input.functionsText.Count * _input.filesWithDistortions.Count;
            if(MaxWorkers < 1)
                return;
        
            var statTasksPool = new StatisticsTasksPool(_input);
            var statWriter = new StatisticsWriter();

            for(int workersIndex = 0; workersIndex < MaxWorkers; ++workersIndex)
            {
                var worker = statTasksPool.GetNextWorker();
                if (null == worker)
                    break;

                statWriter.WiteStatistics(worker);
                ReportProgress(MaxWorkers, workersIndex);
            }
        }

        private void SetInput(StatisticsInput input)
        {
            _input = input;
            Debug.Assert(input != null);
            Debug.Assert(input.filesWithDistortions != null);
            Debug.Assert(input.functionsText != null);
            Debug.Assert(input.functionsText != input.filesWithDistortions);
            _oldProgress = 0;
        }

        private void ReportProgress(int maxProgress, int currentProgress)
        {
            if(_oldProgress >= (int)(currentProgress / maxProgress))
                return;
            _oldProgress = currentProgress / maxProgress;
            // TODO: support report to main thread
            // ReportToMainThrea(_oldProgress);
        }
    }

    /// <summary>
    /// Initialize StatisticsManager with next input.
    /// </summary>
    class StatisticsInput
    {
        public List<String> filesWithDistortions;
        public List<String> functionsText;
    }
}
