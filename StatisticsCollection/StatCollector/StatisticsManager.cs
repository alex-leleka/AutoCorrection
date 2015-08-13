using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace StatisticsCollection.StatCollector
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

        private void ReportProgress(int maxProgress, int currentProgress, System.ComponentModel.BackgroundWorker worker)
        {
            if(_oldProgress >= (int)(currentProgress / maxProgress))
                return;
            _oldProgress = currentProgress / maxProgress;
            worker.ReportProgress(_oldProgress);
        }

        internal void Run(System.ComponentModel.BackgroundWorker bworker, System.ComponentModel.DoWorkEventArgs e)
        {
            if (_input == null)
                throw new Exception("StatisticsManager has no input");

            int MaxWorkers = _input.functionsText.Count * _input.filesWithDistortions.Count;
            if (MaxWorkers < 1)
                return;

            var statTasksPool = new StatisticsTasksPool(_input);
            var statWriter = new StatisticsWriter();

            for (int workersIndex = 0; workersIndex < MaxWorkers; ++workersIndex)
            {
                if (bworker.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    var worker = statTasksPool.GetNextWorker();
                    if (null == worker)
                        break;

                    statWriter.WiteStatistics(worker);
                    ReportProgress(MaxWorkers, workersIndex, bworker);
                }
            }
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
