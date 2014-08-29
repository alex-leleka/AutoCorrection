namespace Diplom_Work_Compare_Results_Probabilities
{
    partial class InputData
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
            this.button2 = new System.Windows.Forms.Button();
            this.groupBoxCalcWay = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxCalcWay.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Для суперпозиції функцій";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBoxCalcWay
            // 
            this.groupBoxCalcWay.Controls.Add(this.button3);
            this.groupBoxCalcWay.Controls.Add(this.button2);
            this.groupBoxCalcWay.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCalcWay.Name = "groupBoxCalcWay";
            this.groupBoxCalcWay.Size = new System.Drawing.Size(199, 90);
            this.groupBoxCalcWay.TabIndex = 2;
            this.groupBoxCalcWay.TabStop = false;
            this.groupBoxCalcWay.Text = "Обчислити спотворення";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(187, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Для заданої функції";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Побудувати таблицю істинності";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // InputData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 430);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxCalcWay);
            this.Name = "InputData";
            this.Text = "InputData";
            this.groupBoxCalcWay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBoxCalcWay;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
    }
}