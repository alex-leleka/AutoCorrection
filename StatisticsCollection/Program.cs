using System;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using StatisticsCollection.StatCollector;

namespace StatisticsCollection
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // set en locale for reading decimal point numbers
            Thread.CurrentThread.CurrentCulture =
                new CultureInfo("en-US", false); // English - US;
            Application.Run(new StatCollectorForm());
        }
    }
}
