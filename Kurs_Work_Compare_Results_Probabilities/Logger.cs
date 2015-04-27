using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public class Logger
    {
        private const string LogName = "resultlog.txt";
        private const bool LoggerOn = true;

        public static bool Init()
        {
            if (!LoggerOn)
                return false;
            return true;
        }

        public static void WriteLine(string line)
        {
            if (!LoggerOn)
                return;
            try
            {
                using (StreamWriter sw = new StreamWriter(LogName))
                {
                    sw.WriteLine(line);
                    sw.Flush();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error while writig log:" + e.Message);
            }
        }

        public static void Write(string text)
        {
            if (!LoggerOn)
                return;
            try
            {
                using (StreamWriter sw = new StreamWriter(LogName))
                {
                    sw.WriteLine(text);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error while writig log:" + e.Message);
            }
        }
    }
}
