namespace StatisticsCollection.StatCollector
{
    partial class StatCollectorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxBoolFunc = new System.Windows.Forms.TextBox();
            this.textBoxDistFileNames = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openDistortionsFilesDialog = new System.Windows.Forms.OpenFileDialog();
            this.openBoolFuncFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonViewResult = new System.Windows.Forms.Button();
            this.buttonSelectTruthTables = new System.Windows.Forms.Button();
            this.checkBoxMultiThead = new System.Windows.Forms.CheckBox();
            this.checkBoxUseSubfunctionMethods = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(489, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select distortions files names";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(489, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 54);
            this.button2.TabIndex = 1;
            this.button2.Text = "Select bool functions text";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxBoolFunc
            // 
            this.textBoxBoolFunc.Location = new System.Drawing.Point(22, 187);
            this.textBoxBoolFunc.Multiline = true;
            this.textBoxBoolFunc.Name = "textBoxBoolFunc";
            this.textBoxBoolFunc.ReadOnly = true;
            this.textBoxBoolFunc.Size = new System.Drawing.Size(461, 118);
            this.textBoxBoolFunc.TabIndex = 2;
            // 
            // textBoxDistFileNames
            // 
            this.textBoxDistFileNames.Location = new System.Drawing.Point(22, 39);
            this.textBoxDistFileNames.Multiline = true;
            this.textBoxDistFileNames.Name = "textBoxDistFileNames";
            this.textBoxDistFileNames.ReadOnly = true;
            this.textBoxDistFileNames.Size = new System.Drawing.Size(461, 118);
            this.textBoxDistFileNames.TabIndex = 3;
            this.textBoxDistFileNames.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(408, 354);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 54);
            this.buttonRun.TabIndex = 4;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.button3_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(96, 368);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(225, 26);
            this.progressBar1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Progress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(18, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Preview:";
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(327, 354);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 54);
            this.button4.TabIndex = 8;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // openDistortionsFilesDialog
            // 
            this.openDistortionsFilesDialog.FileName = "DistortionsFileName";
            this.openDistortionsFilesDialog.Multiselect = true;
            // 
            // openBoolFuncFileDialog
            // 
            this.openBoolFuncFileDialog.FileName = "BoolFuncFileName";
            // 
            // buttonViewResult
            // 
            this.buttonViewResult.Enabled = false;
            this.buttonViewResult.Location = new System.Drawing.Point(489, 354);
            this.buttonViewResult.Name = "buttonViewResult";
            this.buttonViewResult.Size = new System.Drawing.Size(75, 54);
            this.buttonViewResult.TabIndex = 9;
            this.buttonViewResult.Text = "View Result";
            this.buttonViewResult.UseVisualStyleBackColor = true;
            this.buttonViewResult.Click += new System.EventHandler(this.buttonViewResult_Click);
            // 
            // buttonSelectTruthTables
            // 
            this.buttonSelectTruthTables.Location = new System.Drawing.Point(489, 247);
            this.buttonSelectTruthTables.Name = "buttonSelectTruthTables";
            this.buttonSelectTruthTables.Size = new System.Drawing.Size(75, 54);
            this.buttonSelectTruthTables.TabIndex = 10;
            this.buttonSelectTruthTables.Text = "Select files with truth tables";
            this.buttonSelectTruthTables.UseVisualStyleBackColor = true;
            this.buttonSelectTruthTables.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkBoxMultiThead
            // 
            this.checkBoxMultiThead.AutoSize = true;
            this.checkBoxMultiThead.Location = new System.Drawing.Point(450, 320);
            this.checkBoxMultiThead.Name = "checkBoxMultiThead";
            this.checkBoxMultiThead.Size = new System.Drawing.Size(114, 17);
            this.checkBoxMultiThead.TabIndex = 11;
            this.checkBoxMultiThead.Text = "Run MultiTheaded";
            this.checkBoxMultiThead.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseSubfunctionMethods
            // 
            this.checkBoxUseSubfunctionMethods.AutoSize = true;
            this.checkBoxUseSubfunctionMethods.Location = new System.Drawing.Point(327, 320);
            this.checkBoxUseSubfunctionMethods.Name = "checkBoxUseSubfunctionMethods";
            this.checkBoxUseSubfunctionMethods.Size = new System.Drawing.Size(111, 17);
            this.checkBoxUseSubfunctionMethods.TabIndex = 12;
            this.checkBoxUseSubfunctionMethods.Text = "Subfunctions calc";
            this.checkBoxUseSubfunctionMethods.UseVisualStyleBackColor = true;
            // 
            // StatCollectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 420);
            this.Controls.Add(this.checkBoxUseSubfunctionMethods);
            this.Controls.Add(this.checkBoxMultiThead);
            this.Controls.Add(this.buttonSelectTruthTables);
            this.Controls.Add(this.buttonViewResult);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.textBoxDistFileNames);
            this.Controls.Add(this.textBoxBoolFunc);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "StatCollectorForm";
            this.Text = "StatCollectorForm";
            this.Load += new System.EventHandler(this.StatCollectorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxBoolFunc;
        private System.Windows.Forms.TextBox textBoxDistFileNames;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openDistortionsFilesDialog;
        private System.Windows.Forms.OpenFileDialog openBoolFuncFileDialog;
        private System.Windows.Forms.Button buttonViewResult;
        private System.Windows.Forms.Button buttonSelectTruthTables;
        private System.Windows.Forms.CheckBox checkBoxMultiThead;
        private System.Windows.Forms.CheckBox checkBoxUseSubfunctionMethods;
    }
}