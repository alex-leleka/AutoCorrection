namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    partial class FuncTruthTableInput
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
            this.DigitsApply = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.truthTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.numericInpDigitsCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericOutpDigitsCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tablePropertiesBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInpDigitsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOutpDigitsCount)).BeginInit();
            this.tablePropertiesBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DigitsApply
            // 
            this.DigitsApply.Location = new System.Drawing.Point(150, 98);
            this.DigitsApply.Name = "DigitsApply";
            this.DigitsApply.Size = new System.Drawing.Size(107, 30);
            this.DigitsApply.TabIndex = 0;
            this.DigitsApply.Text = "&Create Table";
            this.DigitsApply.UseVisualStyleBackColor = true;
            this.DigitsApply.Click += new System.EventHandler(this.DigitsApply_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.truthTable});
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(13, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(358, 399);
            this.dataGridView1.TabIndex = 1;
            // 
            // truthTable
            // 
            this.truthTable.HeaderText = "F(X)";
            this.truthTable.Name = "truthTable";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введіть десяткові значення правої чатини таблиці істинності";
            // 
            // numericInpDigitsCount
            // 
            this.numericInpDigitsCount.Location = new System.Drawing.Point(185, 24);
            this.numericInpDigitsCount.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.numericInpDigitsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericInpDigitsCount.Name = "numericInpDigitsCount";
            this.numericInpDigitsCount.Size = new System.Drawing.Size(45, 20);
            this.numericInpDigitsCount.TabIndex = 11;
            this.numericInpDigitsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(23, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Кількість вхідних розрядів";
            // 
            // numericOutpDigitsCount
            // 
            this.numericOutpDigitsCount.Location = new System.Drawing.Point(185, 50);
            this.numericOutpDigitsCount.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.numericOutpDigitsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericOutpDigitsCount.Name = "numericOutpDigitsCount";
            this.numericOutpDigitsCount.Size = new System.Drawing.Size(45, 20);
            this.numericOutpDigitsCount.TabIndex = 13;
            this.numericOutpDigitsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(23, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Кількість розрядів результату";
            // 
            // tablePropertiesBox
            // 
            this.tablePropertiesBox.Controls.Add(this.DigitsApply);
            this.tablePropertiesBox.Controls.Add(this.numericOutpDigitsCount);
            this.tablePropertiesBox.Controls.Add(this.label2);
            this.tablePropertiesBox.Controls.Add(this.label3);
            this.tablePropertiesBox.Controls.Add(this.numericInpDigitsCount);
            this.tablePropertiesBox.Location = new System.Drawing.Point(380, 32);
            this.tablePropertiesBox.Name = "tablePropertiesBox";
            this.tablePropertiesBox.Size = new System.Drawing.Size(263, 134);
            this.tablePropertiesBox.TabIndex = 14;
            this.tablePropertiesBox.TabStop = false;
            this.tablePropertiesBox.Text = "Властивості таблиці істинності";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(530, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "O&K";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FuncTruthTableInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tablePropertiesBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FuncTruthTableInput";
            this.Size = new System.Drawing.Size(650, 441);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInpDigitsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOutpDigitsCount)).EndInit();
            this.tablePropertiesBox.ResumeLayout(false);
            this.tablePropertiesBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DigitsApply;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn truthTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericInpDigitsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericOutpDigitsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox tablePropertiesBox;
        private System.Windows.Forms.Button button1;
    }
}
