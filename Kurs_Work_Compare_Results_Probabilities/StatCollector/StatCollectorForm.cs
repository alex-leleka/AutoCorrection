using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_Work_Compare_Results_Probabilities.StatCollector
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
            if (null != _input)
            {
                backgroundWorker1.RunWorkerAsync(/*_input*/);
                button4.Enabled = true;
                button3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openDistortionsFilesDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                int count = openDistortionsFilesDialog.FileNames.Length;
                if (count == 0)
                    return;
                _input.filesWithDistortions = new List<String>();
                _input.filesWithDistortions.AddRange(openDistortionsFilesDialog.FileNames);
            }

            textBoxDistFileNames.Text = "";
            foreach (var s in _input.filesWithDistortions)
                textBoxDistFileNames.Text += _input.filesWithDistortions + Environment.NewLine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openBoolFuncFileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                int count = openBoolFuncFileDialog.FileName.Length;
                if (count == 0)
                    return;
                _input.functionsText = new List<String>();
                using (StreamReader sr = new StreamReader(openBoolFuncFileDialog.FileName))
                {
                    String line = sr.ReadLine();
                    if(line.Length > 0)
                        _input.functionsText.Add(line);
                }
            }

            textBoxBoolFunc.Text = "";
            foreach (var s in _input.functionsText)
                textBoxBoolFunc.Text += s + Environment.NewLine;
        }

        private void StatCollectorForm_Load(object sender, EventArgs e)
        {
            _input = new StatisticsInput();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            StatisticsManager sm = new StatisticsManager(_input);
            sm.Run(worker, e);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation. 
            this.backgroundWorker1.CancelAsync();

            // Disable the Cancel button.
            button4.Enabled = false;
        }
    }
}
