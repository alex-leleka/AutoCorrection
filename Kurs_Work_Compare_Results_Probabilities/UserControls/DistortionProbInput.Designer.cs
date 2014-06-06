namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    partial class DistortionProbHandInput
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ZeroProbability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistortionToZeroProb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistortiontoOneProb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistortionToInverseProb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeight = 90;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ZeroProbability,
            this.DistortionToZeroProb,
            this.DistortiontoOneProb,
            this.DistortionToInverseProb});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 40;
            this.dataGridView1.Size = new System.Drawing.Size(481, 427);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ZeroProbability
            // 
            this.ZeroProbability.HeaderText = "Ймовірність нуля на вході";
            this.ZeroProbability.Name = "ZeroProbability";
            this.ZeroProbability.Width = 112;
            // 
            // DistortionToZeroProb
            // 
            this.DistortionToZeroProb.HeaderText = "Ймовірність спотворення типу \"константа 0\"";
            this.DistortionToZeroProb.Name = "DistortionToZeroProb";
            this.DistortionToZeroProb.Width = 105;
            // 
            // DistortiontoOneProb
            // 
            this.DistortiontoOneProb.HeaderText = "Ймовірність спотворення типу \"константа 1\"";
            this.DistortiontoOneProb.Name = "DistortiontoOneProb";
            this.DistortiontoOneProb.Width = 105;
            // 
            // DistortionToInverseProb
            // 
            this.DistortionToInverseProb.HeaderText = "Ймовірність спотворення типу інверсія";
            this.DistortionToInverseProb.Name = "DistortionToInverseProb";
            this.DistortionToInverseProb.Width = 114;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(530, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DistortionProbHandInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DistortionProbHandInput";
            this.Size = new System.Drawing.Size(722, 430);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZeroProbability;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistortionToZeroProb;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistortiontoOneProb;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistortionToInverseProb;
        private System.Windows.Forms.Button button1;
    }
}
