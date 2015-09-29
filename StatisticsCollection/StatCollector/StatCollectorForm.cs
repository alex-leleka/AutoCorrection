using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace StatisticsCollection.StatCollector
{
    public partial class StatCollectorForm : Form
    {
        private List<String> _filesWithDistortions;
        private List<String> _functionsText;
        private String _resultFileName;

        public StatCollectorForm()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            _functionsText = null;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // if we don't have distortions file there is nothing to do here
            if (_filesWithDistortions == null || _filesWithDistortions.Count == 0)
                return;

            // select IStatisticsInput instance by trying cheking possible input for null
            IStatisticsInput inputAnaliticFunc = null;
            if (_functionsText != null)
                inputAnaliticFunc = new StatisticsInputAnaliticFunc(_functionsText, _filesWithDistortions);
            //if (_functionsTable != null)
            //    inputAnaliticFunc = new StatisticsInputTableFunc(_functionsTable, _filesWithDistortions);


            progressBar1.Value = 0;
            if (null == inputAnaliticFunc) return;
            if(false)
            {
                // run in main thread (to see all exception)
                var sm = new StatisticsManager(inputAnaliticFunc);
                sm.Run();
                buttonViewResult.Enabled = true;
                return;
            }
            else
            {
                backgroundWorker1.RunWorkerAsync(inputAnaliticFunc);
                button4.Enabled = true;
                button3.Enabled = false;
                buttonViewResult.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dr = openDistortionsFilesDialog.ShowDialog();
            if (dr != DialogResult.OK)
                return;
            var count = openDistortionsFilesDialog.FileNames.Length;
            if (count == 0)
                return;
            _filesWithDistortions = new List<String>();
            _filesWithDistortions.AddRange(openDistortionsFilesDialog.FileNames);

            textBoxDistFileNames.Text = "";
            foreach (var s in _filesWithDistortions)
                textBoxDistFileNames.Text += s + Environment.NewLine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dr = openBoolFuncFileDialog.ShowDialog();
            if (dr != DialogResult.OK)
                return;
            var count = openBoolFuncFileDialog.FileName.Length;
            if (count == 0)
                return;
            _functionsText = new List<String>();
            using (var sr = new StreamReader(openBoolFuncFileDialog.FileName))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                        _functionsText.Add(line);
                }
            }

            textBoxBoolFunc.Text = "";
            foreach (var s in _functionsText)
                textBoxBoolFunc.Text += s + Environment.NewLine;
        }

        private void StatCollectorForm_Load(object sender, EventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // we need to do it again in a new thread
            // set en locale for reading decimal point numbers
            Thread.CurrentThread.CurrentCulture =
                new CultureInfo("en-US", false); // English - US;

            // Get the BackgroundWorker that raised this event.
            var worker = sender as BackgroundWorker;
            IStatisticsInput input = (IStatisticsInput)e.Argument;
            var sm = new StatisticsManager(input);
            sm.Run(worker, e);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation. 
            backgroundWorker1.CancelAsync();

            // Disable the Cancel button.
            button4.Enabled = false;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled == true)
            {
                MessageBox.Show(@"Canceled!");
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, @"Error in background worker.");
            }
            else
            {
                _resultFileName = (string) e.Result;
                buttonViewResult.Enabled = true;
            }
        }

        private void buttonViewResult_Click(object sender, EventArgs e)
        {
            if (_resultFileName == null) 
                return;
            var process = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = _resultFileName
                }
            };
            process.Start();
            process.WaitForExit();
        }
    }
}
