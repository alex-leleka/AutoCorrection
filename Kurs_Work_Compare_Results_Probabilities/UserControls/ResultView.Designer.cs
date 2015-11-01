namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    partial class ResultView
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.functionResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorResultProb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AutocorResultProb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorResultProb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxG0 = new System.Windows.Forms.TextBox();
            this.textBoxGc = new System.Windows.Forms.TextBox();
            this.textBoxGee = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.calcWithTableBased = new System.Windows.Forms.Button();
            this.textBoxTableMethP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxGec = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPCorrect = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonCalcAsAdder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.functionResult,
            this.CorResultProb,
            this.AutocorResultProb,
            this.ErrorResultProb});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 81;
            this.dataGridView1.Size = new System.Drawing.Size(588, 607);
            this.dataGridView1.TabIndex = 0;
            // 
            // functionResult
            // 
            this.functionResult.HeaderText = "F(X)";
            this.functionResult.Name = "functionResult";
            this.functionResult.ReadOnly = true;
            // 
            // CorResultProb
            // 
            this.CorResultProb.HeaderText = "G0";
            this.CorResultProb.Name = "CorResultProb";
            this.CorResultProb.ReadOnly = true;
            // 
            // AutocorResultProb
            // 
            this.AutocorResultProb.HeaderText = "Gc";
            this.AutocorResultProb.Name = "AutocorResultProb";
            this.AutocorResultProb.ReadOnly = true;
            // 
            // ErrorResultProb
            // 
            this.ErrorResultProb.HeaderText = "Ge";
            this.ErrorResultProb.Name = "ErrorResultProb";
            this.ErrorResultProb.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(621, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "G0 =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(621, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gc =";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(621, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Gee =";
            // 
            // textBoxG0
            // 
            this.textBoxG0.Location = new System.Drawing.Point(692, 6);
            this.textBoxG0.Name = "textBoxG0";
            this.textBoxG0.ReadOnly = true;
            this.textBoxG0.Size = new System.Drawing.Size(109, 20);
            this.textBoxG0.TabIndex = 4;
            // 
            // textBoxGc
            // 
            this.textBoxGc.Location = new System.Drawing.Point(692, 32);
            this.textBoxGc.Name = "textBoxGc";
            this.textBoxGc.ReadOnly = true;
            this.textBoxGc.Size = new System.Drawing.Size(109, 20);
            this.textBoxGc.TabIndex = 5;
            // 
            // textBoxGee
            // 
            this.textBoxGee.Location = new System.Drawing.Point(692, 84);
            this.textBoxGee.Name = "textBoxGee";
            this.textBoxGee.ReadOnly = true;
            this.textBoxGee.Size = new System.Drawing.Size(109, 20);
            this.textBoxGee.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(653, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Запустити обчислення";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(621, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Час обчислення:";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(739, 153);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(22, 13);
            this.labelTime.TabIndex = 9;
            this.labelTime.Text = "0.0";
            // 
            // calcWithTableBased
            // 
            this.calcWithTableBased.Location = new System.Drawing.Point(653, 303);
            this.calcWithTableBased.Name = "calcWithTableBased";
            this.calcWithTableBased.Size = new System.Drawing.Size(148, 37);
            this.calcWithTableBased.TabIndex = 14;
            this.calcWithTableBased.Text = "Запустити обчислення табл. методом";
            this.calcWithTableBased.UseVisualStyleBackColor = true;
            this.calcWithTableBased.Click += new System.EventHandler(this.calcWithTableBased_Click);
            // 
            // textBoxTableMethP
            // 
            this.textBoxTableMethP.Location = new System.Drawing.Point(692, 258);
            this.textBoxTableMethP.Name = "textBoxTableMethP";
            this.textBoxTableMethP.ReadOnly = true;
            this.textBoxTableMethP.Size = new System.Drawing.Size(109, 20);
            this.textBoxTableMethP.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(621, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Pcorrect(f) =";
            // 
            // textBoxGec
            // 
            this.textBoxGec.Location = new System.Drawing.Point(692, 58);
            this.textBoxGec.Name = "textBoxGec";
            this.textBoxGec.ReadOnly = true;
            this.textBoxGec.Size = new System.Drawing.Size(109, 20);
            this.textBoxGec.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(621, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Gec =";
            // 
            // textBoxPCorrect
            // 
            this.textBoxPCorrect.Location = new System.Drawing.Point(692, 110);
            this.textBoxPCorrect.Name = "textBoxPCorrect";
            this.textBoxPCorrect.ReadOnly = true;
            this.textBoxPCorrect.Size = new System.Drawing.Size(109, 20);
            this.textBoxPCorrect.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(621, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "P(Corr) =";
            // 
            // buttonCalcAsAdder
            // 
            this.buttonCalcAsAdder.Location = new System.Drawing.Point(653, 375);
            this.buttonCalcAsAdder.Name = "buttonCalcAsAdder";
            this.buttonCalcAsAdder.Size = new System.Drawing.Size(148, 37);
            this.buttonCalcAsAdder.TabIndex = 19;
            this.buttonCalcAsAdder.Text = "Запустити обчислення для суматора";
            this.buttonCalcAsAdder.UseVisualStyleBackColor = true;
            this.buttonCalcAsAdder.Click += new System.EventHandler(this.buttonCalcAsAdder_Click);
            // 
            // ResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 607);
            this.Controls.Add(this.buttonCalcAsAdder);
            this.Controls.Add(this.textBoxPCorrect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxGec);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.calcWithTableBased);
            this.Controls.Add(this.textBoxTableMethP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxGee);
            this.Controls.Add(this.textBoxGc);
            this.Controls.Add(this.textBoxG0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ResultView";
            this.Text = "ResultView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn functionResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorResultProb;
        private System.Windows.Forms.DataGridViewTextBoxColumn AutocorResultProb;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorResultProb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxG0;
        private System.Windows.Forms.TextBox textBoxGc;
        private System.Windows.Forms.TextBox textBoxGee;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button calcWithTableBased;
        private System.Windows.Forms.TextBox textBoxTableMethP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxGec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPCorrect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonCalcAsAdder;
    }
}