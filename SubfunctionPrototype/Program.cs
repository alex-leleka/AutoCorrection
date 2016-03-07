using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubfunctionPrototype
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
            Application.Run(new Form1());
        }
    }
}
