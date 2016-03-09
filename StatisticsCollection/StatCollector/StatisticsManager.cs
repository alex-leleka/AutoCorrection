﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Diplom_Work_Compare_Results_Probabilities;

namespace StatisticsCollection.StatCollector
{
    /// <summary>
    /// Manage all work related to statistics collections for multiple distortions and 
    /// bool functions. Reports progress to main thred.
    /// </summary>
    class StatisticsManager
    {
        private IStatisticsInput _inputAnaliticFunc;
        private int _oldProgressPercent;

        public StatisticsManager(IStatisticsInput inputAnaliticFunc)
        {
            SetInput(inputAnaliticFunc);
            // disable logger, we don't need it
            Diplom_Work_Compare_Results_Probabilities.Logger.ResetLogger(false);
        }

        public void Run()
        {
            if (_inputAnaliticFunc == null)
                throw new Exception("StatisticsManager has no input");

            int maxWorkers = _inputAnaliticFunc.FunctionsTextCount() * _inputAnaliticFunc.FilesWithDistortionsCount();
            if(maxWorkers < 1)
                return;

            var statTasksPool = GetStatisticsTasksPool();
            var statWriter = new StatisticsWriter();

            for(int workersIndex = 0; workersIndex < maxWorkers; ++workersIndex)
            {
                var worker = statTasksPool.GetNextWorker();
                if (null == worker)
                    break;

                statWriter.WiteStatistics(worker);
            }
        }

        private void SetInput(IStatisticsInput inputAnaliticFunc)
        {
            _inputAnaliticFunc = inputAnaliticFunc;
            Debug.Assert(inputAnaliticFunc != null);
            Debug.Assert(inputAnaliticFunc.FilesWithDistortions != null);
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

        private dynamic GetStatisticsTasksPool()
        {
            if (_inputAnaliticFunc.FilesWithDistortions.Count > 0)
            {
                String path = _inputAnaliticFunc.FilesWithDistortions[0];
                try
                {
                    var reader = new DistortionProbUnitedInputTextReader(path);
                    reader.GetDistortionProb();
                    return new StatisticsTasksPool<InputWithUnitedDistortionProbabilities>(_inputAnaliticFunc);
                }
                catch (Exception )
                {
                    // ignore
                }
                try
                {
                    var reader = new DistortionProbTextReader(path);
                    reader.GetDistortionProb();
                    return new StatisticsTasksPool<InputDistortionProbabilities>(_inputAnaliticFunc);
                }
                catch (Exception)
                {
                    // ignore
                }
            }
            return null;
        }
        internal void Run(BackgroundWorker bworker, DoWorkEventArgs e)
        {
            if (_inputAnaliticFunc == null)
                throw new Exception("StatisticsManager has no input");

            int maxWorkers = _inputAnaliticFunc.FunctionsTextCount() * _inputAnaliticFunc.FilesWithDistortionsCount();
            if (maxWorkers < 1)
                return;

            var statTasksPool = GetStatisticsTasksPool();
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
            e.Result = statWriter.GetFileName();
        }
    }

}
