namespace BoolFunctionGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonA = new System.Windows.Forms.RadioButton();
            this.radioButtonB = new System.Windows.Forms.RadioButton();
            this.radioButtonC = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxBaseFunction = new System.Windows.Forms.TextBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonX5and = new System.Windows.Forms.RadioButton();
            this.radioButtonX5or = new System.Windows.Forms.RadioButton();
            this.radioButtonX6or = new System.Windows.Forms.RadioButton();
            this.radioButtonX6and = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxSave = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(438, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Base function (4 bits):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Generated function (6 bits):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.radioButtonC);
            this.groupBox1.Controls.Add(this.radioButtonB);
            this.groupBox1.Controls.Add(this.radioButtonA);
            this.groupBox1.Location = new System.Drawing.Point(15, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 221);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection type";
            // 
            // radioButtonA
            // 
            this.radioButtonA.AutoSize = true;
            this.radioButtonA.Checked = true;
            this.radioButtonA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonA.Location = new System.Drawing.Point(101, 185);
            this.radioButtonA.Name = "radioButtonA";
            this.radioButtonA.Size = new System.Drawing.Size(35, 20);
            this.radioButtonA.TabIndex = 0;
            this.radioButtonA.TabStop = true;
            this.radioButtonA.Text = "A";
            this.radioButtonA.UseVisualStyleBackColor = true;
            this.radioButtonA.CheckedChanged += new System.EventHandler(this.radioButtonA_CheckedChanged);
            // 
            // radioButtonB
            // 
            this.radioButtonB.AutoSize = true;
            this.radioButtonB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonB.Location = new System.Drawing.Point(269, 185);
            this.radioButtonB.Name = "radioButtonB";
            this.radioButtonB.Size = new System.Drawing.Size(35, 20);
            this.radioButtonB.TabIndex = 1;
            this.radioButtonB.Text = "B";
            this.radioButtonB.UseVisualStyleBackColor = true;
            this.radioButtonB.CheckedChanged += new System.EventHandler(this.radioButtonB_CheckedChanged);
            // 
            // radioButtonC
            // 
            this.radioButtonC.AutoSize = true;
            this.radioButtonC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonC.Location = new System.Drawing.Point(423, 185);
            this.radioButtonC.Name = "radioButtonC";
            this.radioButtonC.Size = new System.Drawing.Size(35, 20);
            this.radioButtonC.TabIndex = 2;
            this.radioButtonC.Text = "C";
            this.radioButtonC.UseVisualStyleBackColor = true;
            this.radioButtonC.CheckedChanged += new System.EventHandler(this.radioButtonC_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(35, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(484, 150);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxBaseFunction
            // 
            this.textBoxBaseFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxBaseFunction.Location = new System.Drawing.Point(151, 28);
            this.textBoxBaseFunction.Name = "textBoxBaseFunction";
            this.textBoxBaseFunction.Size = new System.Drawing.Size(420, 26);
            this.textBoxBaseFunction.TabIndex = 4;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxResult.Location = new System.Drawing.Point(15, 467);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(556, 26);
            this.textBoxResult.TabIndex = 5;
            this.textBoxResult.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonX5or);
            this.groupBox2.Controls.Add(this.radioButtonX5and);
            this.groupBox2.Location = new System.Drawing.Point(17, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 81);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "X[5]";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonX6or);
            this.groupBox3.Controls.Add(this.radioButtonX6and);
            this.groupBox3.Location = new System.Drawing.Point(183, 295);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 81);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "X[6]";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // radioButtonX5and
            // 
            this.radioButtonX5and.AutoSize = true;
            this.radioButtonX5and.Checked = true;
            this.radioButtonX5and.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonX5and.Location = new System.Drawing.Point(21, 35);
            this.radioButtonX5and.Name = "radioButtonX5and";
            this.radioButtonX5and.Size = new System.Drawing.Size(49, 20);
            this.radioButtonX5and.TabIndex = 4;
            this.radioButtonX5and.TabStop = true;
            this.radioButtonX5and.Text = "and";
            this.radioButtonX5and.UseVisualStyleBackColor = true;
            // 
            // radioButtonX5or
            // 
            this.radioButtonX5or.AutoSize = true;
            this.radioButtonX5or.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonX5or.Location = new System.Drawing.Point(90, 35);
            this.radioButtonX5or.Name = "radioButtonX5or";
            this.radioButtonX5or.Size = new System.Drawing.Size(38, 20);
            this.radioButtonX5or.TabIndex = 5;
            this.radioButtonX5or.Text = "or";
            this.radioButtonX5or.UseVisualStyleBackColor = true;
            // 
            // radioButtonX6or
            // 
            this.radioButtonX6or.AutoSize = true;
            this.radioButtonX6or.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonX6or.Location = new System.Drawing.Point(90, 32);
            this.radioButtonX6or.Name = "radioButtonX6or";
            this.radioButtonX6or.Size = new System.Drawing.Size(38, 20);
            this.radioButtonX6or.TabIndex = 9;
            this.radioButtonX6or.Text = "or";
            this.radioButtonX6or.UseVisualStyleBackColor = true;
            // 
            // radioButtonX6and
            // 
            this.radioButtonX6and.AutoSize = true;
            this.radioButtonX6and.Checked = true;
            this.radioButtonX6and.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonX6and.Location = new System.Drawing.Point(21, 32);
            this.radioButtonX6and.Name = "radioButtonX6and";
            this.radioButtonX6and.Size = new System.Drawing.Size(49, 20);
            this.radioButtonX6and.TabIndex = 8;
            this.radioButtonX6and.TabStop = true;
            this.radioButtonX6and.Text = "and";
            this.radioButtonX6and.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.numericUpDown2);
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(349, 295);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(222, 81);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Const";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(49, 34);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown1.TabIndex = 0;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(147, 34);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(5, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "X[5]=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(103, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "X[6]=";
            // 
            // checkBoxSave
            // 
            this.checkBoxSave.AutoSize = true;
            this.checkBoxSave.Checked = true;
            this.checkBoxSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSave.Location = new System.Drawing.Point(462, 382);
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.Size = new System.Drawing.Size(109, 20);
            this.checkBoxSave.TabIndex = 11;
            this.checkBoxSave.Text = "Append to file";
            this.checkBoxSave.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(18, 386);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "File name:";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(93, 385);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(160, 20);
            this.textBoxFileName.TabIndex = 13;
            this.textBoxFileName.Text = "functionText";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(259, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "+postfix+ .txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 579);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxSave);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.textBoxBaseFunction);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "FunctionGenerator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radioButtonC;
        private System.Windows.Forms.RadioButton radioButtonB;
        private System.Windows.Forms.RadioButton radioButtonA;
        private System.Windows.Forms.TextBox textBoxBaseFunction;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonX5or;
        private System.Windows.Forms.RadioButton radioButtonX5and;
        private System.Windows.Forms.RadioButton radioButtonX6or;
        private System.Windows.Forms.RadioButton radioButtonX6and;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox checkBoxSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label label6;
    }
}

