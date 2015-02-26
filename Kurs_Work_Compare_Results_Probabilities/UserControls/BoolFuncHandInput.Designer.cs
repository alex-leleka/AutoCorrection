namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    partial class BoolFuncHandInput
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
            this.numericDigitsCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoolFunction = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AcceptAnaliticFucntion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericDigitsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // numericDigitsCount
            // 
            this.numericDigitsCount.Location = new System.Drawing.Point(255, 21);
            this.numericDigitsCount.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.numericDigitsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDigitsCount.Name = "numericDigitsCount";
            this.numericDigitsCount.Size = new System.Drawing.Size(45, 20);
            this.numericDigitsCount.TabIndex = 9;
            this.numericDigitsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Кількість вхідних розрядів";
            // 
            // textBoolFunction
            // 
            this.textBoolFunction.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoolFunction.Location = new System.Drawing.Point(26, 47);
            this.textBoolFunction.MaxLength = 10000;
            this.textBoolFunction.Multiline = true;
            this.textBoolFunction.Name = "textBoolFunction";
            this.textBoolFunction.Size = new System.Drawing.Size(274, 159);
            this.textBoolFunction.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "Кількість вихідних розрядів рівна кількості формул\r\nвведених з нового рядка";
            // 
            // AcceptAnaliticFucntion
            // 
            this.AcceptAnaliticFucntion.Location = new System.Drawing.Point(217, 300);
            this.AcceptAnaliticFucntion.Name = "AcceptAnaliticFucntion";
            this.AcceptAnaliticFucntion.Size = new System.Drawing.Size(83, 28);
            this.AcceptAnaliticFucntion.TabIndex = 11;
            this.AcceptAnaliticFucntion.Text = "OK";
            this.AcceptAnaliticFucntion.UseVisualStyleBackColor = true;
            this.AcceptAnaliticFucntion.Click += new System.EventHandler(this.AcceptAnaliticFucntion_Click);
            // 
            // BoolFuncHandInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AcceptAnaliticFucntion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericDigitsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoolFunction);
            this.Name = "BoolFuncHandInput";
            this.Size = new System.Drawing.Size(337, 351);
            ((System.ComponentModel.ISupportInitialize)(this.numericDigitsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericDigitsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoolFunction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AcceptAnaliticFucntion;
    }
}
