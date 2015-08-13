using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace StatisticsCollection.StatCollector
{
    public partial class StatCollectorForm : Form
    {
        private StatisticsInput _input;

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
            if (null == _input) return;
            backgroundWorker1.RunWorkerAsync(/*_input*/);
            button4.Enabled = true;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dr = openDistortionsFilesDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                var count = openDistortionsFilesDialog.FileNames.Length;
                if (count == 0)
                    return;
                _input.FilesWithDistortions = new List<String>();
                _input.FilesWithDistortions.AddRange(openDistortionsFilesDialog.FileNames);
            }

            textBoxDistFileNames.Text = "";
            foreach (var s in _input.FilesWithDistortions)
                textBoxDistFileNames.Text += _input.FilesWithDistortions + Environment.NewLine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dr = openBoolFuncFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                var count = openBoolFuncFileDialog.FileName.Length;
                if (count == 0)
                    return;
                _input.FunctionsText = new List<String>();
                using (var sr = new StreamReader(openBoolFuncFileDialog.FileName))
                {
                    var line = sr.ReadLine();
                    if(!string.IsNullOrEmpty(line))
                        _input.FunctionsText.Add(line);
                }
            }

            textBoxBoolFunc.Text = "";
            foreach (var s in _input.FunctionsText)
                textBoxBoolFunc.Text += s + Environment.NewLine;
        }

        private void StatCollectorForm_Load(object sender, EventArgs e)
        {
            _input = new StatisticsInput();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            var worker = sender as BackgroundWorker;

            var sm = new StatisticsManager(_input);
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
    }
}
