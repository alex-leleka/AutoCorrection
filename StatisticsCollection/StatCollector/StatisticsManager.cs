using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int _oldProgressPercent;

        public StatisticsManager(StatisticsInput input)
        {
            SetInput(input);
            // disable logger, we don't need it
            Diplom_Work_Compare_Results_Probabilities.Logger.ResetLogger(false);
        }

        public void Run()
        {
            if (_input == null)
                throw new Exception("StatisticsManager has no input");

            int maxWorkers = _input.FunctionsText.Count * _input.FilesWithDistortions.Count;
            if(maxWorkers < 1)
                return;
        
            var statTasksPool = new StatisticsTasksPool(_input);
            var statWriter = new StatisticsWriter();

            for(int workersIndex = 0; workersIndex < maxWorkers; ++workersIndex)
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
            Debug.Assert(input.FilesWithDistortions != null);
            Debug.Assert(input.FunctionsText != null);
            Debug.Assert(input.FunctionsText != input.FilesWithDistortions);
            _oldProgressPercent = 0;
        }

        private void ReportProgress(int maxProgress, int currentProgress, BackgroundWorker worker)
        {
            int progressPercent = 100 * currentProgress / maxProgress;
            if (_oldProgressPercent >= progressPercent)
                return;
            _oldProgressPercent = progressPercent;
            worker.ReportProgress(_oldProgressPercent);
        }

        internal void Run(BackgroundWorker bworker, DoWorkEventArgs e)
        {
            if (_input == null)
                throw new Exception("StatisticsManager has no input");

            int maxWorkers = _input.FunctionsText.Count * _input.FilesWithDistortions.Count;
            if (maxWorkers < 1)
                return;

            var statTasksPool = new StatisticsTasksPool(_input);
            var statWriter = new StatisticsWriter();

            for (int workersIndex = 0; workersIndex < maxWorkers; ++workersIndex)
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
                    ReportProgress(maxWorkers, workersIndex + 1, bworker);
                }
            }
        }
    }

    /// <summary>
    /// Initialize StatisticsManager with next input.
    /// </summary>
    class StatisticsInput
    {
        public List<String> FilesWithDistortions;
        public List<String> FunctionsText;
    }
}
