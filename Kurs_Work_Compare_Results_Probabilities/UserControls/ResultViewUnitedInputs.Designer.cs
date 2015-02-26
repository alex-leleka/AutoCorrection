namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    partial class ResultViewWithUnitedInputs
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
            this.calcWithTableBased = new System.Windows.Forms.Button();
            this.textBoxTableMethP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.dataGridView1.Enabled = false;
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
            // calcWithTableBased
            // 
            this.calcWithTableBased.Location = new System.Drawing.Point(653, 303);
            this.calcWithTableBased.Name = "calcWithTableBased";
            this.calcWithTableBased.Size = new System.Drawing.Size(148, 37);
            this.calcWithTableBased.TabIndex = 14;
            this.calcWithTableBased.Text = "Запустити обчислення прямим методом";
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
            // ResultViewWithUnitedInputs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 607);
            this.Controls.Add(this.calcWithTableBased);
            this.Controls.Add(this.textBoxTableMethP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ResultViewWithUnitedInputs";
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
        private System.Windows.Forms.Button calcWithTableBased;
        private System.Windows.Forms.TextBox textBoxTableMethP;
        private System.Windows.Forms.Label label7;
    }
}