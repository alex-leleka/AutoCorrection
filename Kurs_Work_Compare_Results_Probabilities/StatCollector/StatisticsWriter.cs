using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Work_Compare_Results_Probabilities.StatCollector
{
    /// <summary>
    /// Write results of correct result probabilities calculation for multiple distortions and 
    /// bool functions into the text file.
    /// </summary>
    class StatisticsWriter
    {
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

        private void WriteLine(string p)
        {
            throw new NotImplementedException();
        }
    }
}
