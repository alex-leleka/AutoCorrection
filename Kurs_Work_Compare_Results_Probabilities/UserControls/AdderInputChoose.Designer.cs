namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    partial class AdderInputChoose
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
            this.tablePropertiesBox = new System.Windows.Forms.GroupBox();
            this.DigitsApply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericInpDigitsCount = new System.Windows.Forms.NumericUpDown();
            this.cbBitIndex = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericBitIndex = new System.Windows.Forms.NumericUpDown();
            this.tablePropertiesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericInpDigitsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBitIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePropertiesBox
            // 
            this.tablePropertiesBox.Controls.Add(this.numericBitIndex);
            this.tablePropertiesBox.Controls.Add(this.label1);
            this.tablePropertiesBox.Controls.Add(this.cbBitIndex);
            this.tablePropertiesBox.Controls.Add(this.DigitsApply);
            this.tablePropertiesBox.Controls.Add(this.label2);
            this.tablePropertiesBox.Controls.Add(this.numericInpDigitsCount);
            this.tablePropertiesBox.Location = new System.Drawing.Point(54, 35);
            this.tablePropertiesBox.Name = "tablePropertiesBox";
            this.tablePropertiesBox.Size = new System.Drawing.Size(293, 177);
            this.tablePropertiesBox.TabIndex = 15;
            this.tablePropertiesBox.TabStop = false;
            this.tablePropertiesBox.Text = "Властивості таблиці істинності суматора";
            // 
            // DigitsApply
            // 
            this.DigitsApply.Location = new System.Drawing.Point(180, 141);
            this.DigitsApply.Name = "DigitsApply";
            this.DigitsApply.Size = new System.Drawing.Size(107, 30);
            this.DigitsApply.TabIndex = 0;
            this.DigitsApply.Text = "&Create Table";
            this.DigitsApply.UseVisualStyleBackColor = true;
            this.DigitsApply.Click += new System.EventHandler(this.DigitsApply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Кількість вхідних розрядів одного операнда";
            // 
            // numericInpDigitsCount
            // 
            this.numericInpDigitsCount.Location = new System.Drawing.Point(242, 24);
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
            this.numericInpDigitsCount.ValueChanged += new System.EventHandler(this.numericInpDigitsCount_ValueChanged);
            // 
            // cbBitIndex
            // 
            this.cbBitIndex.AutoSize = true;
            this.cbBitIndex.Location = new System.Drawing.Point(9, 52);
            this.cbBitIndex.Name = "cbBitIndex";
            this.cbBitIndex.Size = new System.Drawing.Size(143, 17);
            this.cbBitIndex.TabIndex = 12;
            this.cbBitIndex.Text = "Для окремого розряду";
            this.cbBitIndex.UseVisualStyleBackColor = true;
            this.cbBitIndex.CheckedChanged += new System.EventHandler(this.cbBitIndex_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(6, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Номер вихідного розряду";
            // 
            // numericBitIndex
            // 
            this.numericBitIndex.Enabled = false;
            this.numericBitIndex.Location = new System.Drawing.Point(242, 80);
            this.numericBitIndex.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.numericBitIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericBitIndex.Name = "numericBitIndex";
            this.numericBitIndex.Size = new System.Drawing.Size(45, 20);
            this.numericBitIndex.TabIndex = 14;
            this.numericBitIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AdderInputChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePropertiesBox);
            this.Name = "AdderInputChoose";
            this.Size = new System.Drawing.Size(451, 279);
            this.tablePropertiesBox.ResumeLayout(false);
            this.tablePropertiesBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericInpDigitsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBitIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox tablePropertiesBox;
        private System.Windows.Forms.Button DigitsApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericInpDigitsCount;
        private System.Windows.Forms.NumericUpDown numericBitIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbBitIndex;
    }
}
