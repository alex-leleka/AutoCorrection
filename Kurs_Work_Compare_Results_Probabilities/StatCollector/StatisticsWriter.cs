using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Diplom_Work_Compare_Results_Probabilities.StatCollector
{
    /// <summary>
    /// Write results of correct result probabilities calculation for multiple distortions and 
    /// bool functions into the text file.
    /// </summary>
    class StatisticsWriter
    {
        String _fileName;
        StreamWriter _sw;
        DisposableDelegate _swDisposer;
        public StatisticsWriter(String fileNamePrefix = "")
        {
            _fileName = fileNamePrefix + string.Format("Stats-{0:yyyy-MM-dd_hh-mm-ss-tt}.csv",
                DateTime.Now);
            // Open stream only once in constructor
            _sw = new StreamWriter(_fileName, true);
            // Colse stream when _swDisposer leave scope
            _swDisposer = new DisposableDelegate(() => _sw.Close());
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
        }

        // contains exception handling, couldn't be inline
        private void WriteLine(string line)
        {
            try
            {
                _sw.WriteLine(line);
            }
            catch (Exception e)
            {
                throw new Exception("StatisticsWriter: Error while witing statistics:" + e.Message);
            }
        }

        private void WriteLineFast(string line)
        {
            _sw.WriteLine(line);
        }
    }

    public class DisposableDelegate : IDisposable
    {
        private Action dispose;

        public DisposableDelegate(Action dispose)
        {
            if (dispose == null)
            {
                throw new ArgumentNullException("dispose");
            }

            this.dispose = dispose;
        }

        public void Dispose()
        {
            if (this.dispose != null)
            {
                Action d = this.dispose;
                this.dispose = null;
                d();
            }
        }
    }
}
