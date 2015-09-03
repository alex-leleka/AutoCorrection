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
        private StatisticsInputAnaliticFunc _inputAnaliticFunc;
        private String _resultFileName;

        public StatCollectorForm()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            if (null == _inputAnaliticFunc) return;
            if(false)
            {
                // run in main thread (to see all exception)
                var sm = new StatisticsManager(_inputAnaliticFunc);
                sm.Run();
                buttonViewResult.Enabled = true;
                return;
            }
            else
            {
                backgroundWorker1.RunWorkerAsync(/*_input*/);
                button4.Enabled = true;
                button3.Enabled = false;
                buttonViewResult.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dr = openDistortionsFilesDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                var count = openDistortionsFilesDialog.FileNames.Length;
                if (count == 0)
                    return;
                _inputAnaliticFunc.FilesWithDistortions = new List<String>();
                _inputAnaliticFunc.FilesWithDistortions.AddRange(openDistortionsFilesDialog.FileNames);
            }

            textBoxDistFileNames.Text = "";
            foreach (var s in _inputAnaliticFunc.FilesWithDistortions)
                textBoxDistFileNames.Text += s + Environment.NewLine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dr = openBoolFuncFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                var count = openBoolFuncFileDialog.FileName.Length;
                if (count == 0)
                    return;
                _inputAnaliticFunc.FunctionsText = new List<String>();
                using (var sr = new StreamReader(openBoolFuncFileDialog.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                            _inputAnaliticFunc.FunctionsText.Add(line);
                    }
                }
            }

            textBoxBoolFunc.Text = "";
            foreach (var s in _inputAnaliticFunc.FunctionsText)
                textBoxBoolFunc.Text += s + Environment.NewLine;
        }

        private void StatCollectorForm_Load(object sender, EventArgs e)
        {
            _inputAnaliticFunc = new StatisticsInputAnaliticFunc();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // we need to do it again in a new thread
            // set en locale for reading decimal point numbers
            Thread.CurrentThread.CurrentCulture =
                new CultureInfo("en-US", false); // English - US;

            // Get the BackgroundWorker that raised this event.
            var worker = sender as BackgroundWorker;

            var sm = new StatisticsManager(_inputAnaliticFunc);
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
