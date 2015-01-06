namespace Diplom_Work_Compare_Results_Probabilities
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
            this.textBoxGe = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(675, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "G0 =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(675, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gc =";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(675, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ge =";
            // 
            // textBoxG0
            // 
            this.textBoxG0.Location = new System.Drawing.Point(711, 10);
            this.textBoxG0.Name = "textBoxG0";
            this.textBoxG0.ReadOnly = true;
            this.textBoxG0.Size = new System.Drawing.Size(69, 20);
            this.textBoxG0.TabIndex = 4;
            // 
            // textBoxGc
            // 
            this.textBoxGc.Location = new System.Drawing.Point(711, 36);
            this.textBoxGc.Name = "textBoxGc";
            this.textBoxGc.ReadOnly = true;
            this.textBoxGc.Size = new System.Drawing.Size(69, 20);
            this.textBoxGc.TabIndex = 5;
            // 
            // textBoxGe
            // 
            this.textBoxGe.Location = new System.Drawing.Point(711, 62);
            this.textBoxGe.Name = "textBoxGe";
            this.textBoxGe.ReadOnly = true;
            this.textBoxGe.Size = new System.Drawing.Size(69, 20);
            this.textBoxGe.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(678, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Запустити обчислення";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(594, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Час обчислення:";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(758, 100);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(22, 13);
            this.labelTime.TabIndex = 9;
            this.labelTime.Text = "0.0";
            // 
            // ResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 607);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxGe);
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
        private System.Windows.Forms.TextBox textBoxGe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTime;
    }
}