using System;
using System.IO;
using System.Linq;

namespace StatisticsCollection.StatCollector
{
    /// <summary>
    /// Write results of correct result probabilities calculation for multiple distortions and 
    /// bool functions into the text file.
    /// </summary>
    class StatisticsWriter
    {
        private readonly String _fileName;
        //private StreamWriter _sw;
        //DisposableDelegate _swDisposer;
        public StatisticsWriter(String fileNamePrefix = "")
        {
            _fileName = fileNamePrefix + string.Format("Stats-{0:yyyy-MM-dd_hh-mm-ss-tt}.csv",
                DateTime.Now);
            // Open stream only once in constructor
            //_sw = new StreamWriter(_fileName, true);
            // Colse stream when _swDisposer leave scope
            //_swDisposer = new DisposableDelegate(() => _sw.Close());
        }
        public void WiteStatistics(StatisticsWorker worker)
        {
            var resultsProbs = worker.GetResult();
            double pCorrectResult = resultsProbs.Sum(a => a.Value);
            WriteLine(worker.GetBoolFunctionText());
            WriteLine(worker.GetDistortionFileName());
            WriteLine(pCorrectResult.ToString());
            foreach (var kv in resultsProbs)
            {
                WriteLine(kv.Key + ";" + "\t" + kv.Value);
            }
            WriteLine("");
        }

        // contains exception handling, couldn't be inline
        private void WriteLine(string line)
        {
            using (StreamWriter sw = new StreamWriter(_fileName, true))
            {
                sw.WriteLine(line);
            }
        }

    }

    public class DisposableDelegate : IDisposable
    {
        private Action _dispose;

        public DisposableDelegate(Action dispose)
        {
            if (dispose == null)
            {
                throw new ArgumentNullException("dispose");
            }

            _dispose = dispose;
        }

        public void Dispose()
        {
            if (_dispose == null) return;
            Action d = _dispose;
            _dispose = null;
            d();
        }
    }
}
