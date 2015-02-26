using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using Diplom_Work_Compare_Results_Probabilities.UserControls;

namespace Diplom_Work_Compare_Results_Probabilities
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
            // set en lacale for reading decimal point numbers
            Thread.CurrentThread.CurrentCulture =
                new CultureInfo("en-US", false); // English - US
            Application.Run(new InputData());//Form1());
        }
    }
}
