namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    partial class Form1
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
            this.tableGridView = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoolFunction = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericDigitsCount = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDigitsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(671, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load table";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableGridView
            // 
            this.tableGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGridView.Location = new System.Drawing.Point(-2, 0);
            this.tableGridView.Name = "tableGridView";
            this.tableGridView.Size = new System.Drawing.Size(525, 507);
            this.tableGridView.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(671, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "Load distortion table";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(538, 468);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(252, 33);
            this.button3.TabIndex = 3;
            this.button3.Text = "BuildTable";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoolFunction
            // 
            this.textBoolFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoolFunction.Location = new System.Drawing.Point(538, 326);
            this.textBoolFunction.Multiline = true;
            this.textBoolFunction.Name = "textBoolFunction";
            this.textBoolFunction.Size = new System.Drawing.Size(252, 136);
            this.textBoolFunction.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(636, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = " Input digits count";
            // 
            // numericDigitsCount
            // 
            this.numericDigitsCount.Location = new System.Drawing.Point(744, 300);
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
            this.numericDigitsCount.Size = new System.Drawing.Size(46, 20);
            this.numericDigitsCount.TabIndex = 6;
            this.numericDigitsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(671, 179);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(62, 39);
            this.button4.TabIndex = 7;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 509);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.numericDigitsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoolFunction);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tableGridView);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "TableView";
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDigitsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView tableGridView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoolFunction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericDigitsCount;
        private System.Windows.Forms.Button button4;
    }
}

