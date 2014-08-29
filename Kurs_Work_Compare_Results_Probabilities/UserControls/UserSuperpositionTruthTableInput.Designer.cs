namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    partial class UserSuperpositionTruthTableInput
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
            this.ViewResultButton = new System.Windows.Forms.Button();
            this.distProbInputChoiceBox = new System.Windows.Forms.GroupBox();
            this.rbHandWriteDistProb = new System.Windows.Forms.RadioButton();
            this.InputMethodChoosed = new System.Windows.Forms.Button();
            this.rbTextFileDistortion = new System.Windows.Forms.RadioButton();
            this.boolFuncInputChoice = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rbAdder = new System.Windows.Forms.RadioButton();
            this.rbDllImport = new System.Windows.Forms.RadioButton();
            this.rbTruthTable = new System.Windows.Forms.RadioButton();
            this.rbTextFile = new System.Windows.Forms.RadioButton();
            this.rbAnaliticFormula = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.distProbInputChoiceBox.SuspendLayout();
            this.boolFuncInputChoice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ViewResultButton
            // 
            this.ViewResultButton.Location = new System.Drawing.Point(319, 242);
            this.ViewResultButton.Name = "ViewResultButton";
            this.ViewResultButton.Size = new System.Drawing.Size(98, 43);
            this.ViewResultButton.TabIndex = 7;
            this.ViewResultButton.Text = "Показати результат";
            this.ViewResultButton.UseVisualStyleBackColor = true;
            this.ViewResultButton.Visible = false;
            this.ViewResultButton.Click += new System.EventHandler(this.ViewResultButton_Click);
            // 
            // distProbInputChoiceBox
            // 
            this.distProbInputChoiceBox.Controls.Add(this.rbHandWriteDistProb);
            this.distProbInputChoiceBox.Controls.Add(this.InputMethodChoosed);
            this.distProbInputChoiceBox.Controls.Add(this.rbTextFileDistortion);
            this.distProbInputChoiceBox.Location = new System.Drawing.Point(319, 15);
            this.distProbInputChoiceBox.Name = "distProbInputChoiceBox";
            this.distProbInputChoiceBox.Size = new System.Drawing.Size(247, 211);
            this.distProbInputChoiceBox.TabIndex = 6;
            this.distProbInputChoiceBox.TabStop = false;
            this.distProbInputChoiceBox.Text = "Спосіб введення ймовірностей спотворень";
            // 
            // rbHandWriteDistProb
            // 
            this.rbHandWriteDistProb.AutoSize = true;
            this.rbHandWriteDistProb.Location = new System.Drawing.Point(6, 55);
            this.rbHandWriteDistProb.Name = "rbHandWriteDistProb";
            this.rbHandWriteDistProb.Size = new System.Drawing.Size(159, 17);
            this.rbHandWriteDistProb.TabIndex = 3;
            this.rbHandWriteDistProb.TabStop = true;
            this.rbHandWriteDistProb.Text = "Ввести ймовірності вручну";
            this.rbHandWriteDistProb.UseVisualStyleBackColor = true;
            // 
            // InputMethodChoosed
            // 
            this.InputMethodChoosed.Location = new System.Drawing.Point(6, 174);
            this.InputMethodChoosed.Name = "InputMethodChoosed";
            this.InputMethodChoosed.Size = new System.Drawing.Size(108, 31);
            this.InputMethodChoosed.TabIndex = 3;
            this.InputMethodChoosed.Text = "ОК";
            this.InputMethodChoosed.UseVisualStyleBackColor = true;
            this.InputMethodChoosed.Click += new System.EventHandler(this.InputMethodChoosed_Click);
            // 
            // rbTextFileDistortion
            // 
            this.rbTextFileDistortion.AutoSize = true;
            this.rbTextFileDistortion.Location = new System.Drawing.Point(6, 32);
            this.rbTextFileDistortion.Name = "rbTextFileDistortion";
            this.rbTextFileDistortion.Size = new System.Drawing.Size(201, 17);
            this.rbTextFileDistortion.TabIndex = 2;
            this.rbTextFileDistortion.TabStop = true;
            this.rbTextFileDistortion.Text = "Файл з імовірностями спотворень";
            this.rbTextFileDistortion.UseVisualStyleBackColor = true;
            // 
            // boolFuncInputChoice
            // 
            this.boolFuncInputChoice.Controls.Add(this.button1);
            this.boolFuncInputChoice.Controls.Add(this.rbAdder);
            this.boolFuncInputChoice.Controls.Add(this.rbDllImport);
            this.boolFuncInputChoice.Controls.Add(this.rbTruthTable);
            this.boolFuncInputChoice.Controls.Add(this.rbTextFile);
            this.boolFuncInputChoice.Controls.Add(this.rbAnaliticFormula);
            this.boolFuncInputChoice.Location = new System.Drawing.Point(17, 15);
            this.boolFuncInputChoice.Name = "boolFuncInputChoice";
            this.boolFuncInputChoice.Size = new System.Drawing.Size(247, 211);
            this.boolFuncInputChoice.TabIndex = 5;
            this.boolFuncInputChoice.TabStop = false;
            this.boolFuncInputChoice.Text = "Спосіб введення булевої функції F1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbAdder
            // 
            this.rbAdder.AutoSize = true;
            this.rbAdder.Location = new System.Drawing.Point(6, 124);
            this.rbAdder.Name = "rbAdder";
            this.rbAdder.Size = new System.Drawing.Size(172, 17);
            this.rbAdder.TabIndex = 4;
            this.rbAdder.TabStop = true;
            this.rbAdder.Text = "Таблиця істинності суматора";
            this.rbAdder.UseVisualStyleBackColor = true;
            // 
            // rbDllImport
            // 
            this.rbDllImport.AutoSize = true;
            this.rbDllImport.Location = new System.Drawing.Point(6, 101);
            this.rbDllImport.Name = "rbDllImport";
            this.rbDllImport.Size = new System.Drawing.Size(108, 17);
            this.rbDllImport.TabIndex = 3;
            this.rbDllImport.TabStop = true;
            this.rbDllImport.Text = "Завантажити dll ";
            this.rbDllImport.UseVisualStyleBackColor = true;
            // 
            // rbTruthTable
            // 
            this.rbTruthTable.AutoSize = true;
            this.rbTruthTable.Location = new System.Drawing.Point(6, 78);
            this.rbTruthTable.Name = "rbTruthTable";
            this.rbTruthTable.Size = new System.Drawing.Size(160, 17);
            this.rbTruthTable.TabIndex = 2;
            this.rbTruthTable.TabStop = true;
            this.rbTruthTable.Text = "Ввести таблицю істинності";
            this.rbTruthTable.UseVisualStyleBackColor = true;
            // 
            // rbTextFile
            // 
            this.rbTextFile.AutoSize = true;
            this.rbTextFile.Location = new System.Drawing.Point(6, 55);
            this.rbTextFile.Name = "rbTextFile";
            this.rbTextFile.Size = new System.Drawing.Size(222, 17);
            this.rbTextFile.TabIndex = 1;
            this.rbTextFile.TabStop = true;
            this.rbTextFile.Text = "Текстовий файл з таблицею істинності";
            this.rbTextFile.UseVisualStyleBackColor = true;
            // 
            // rbAnaliticFormula
            // 
            this.rbAnaliticFormula.AutoSize = true;
            this.rbAnaliticFormula.Location = new System.Drawing.Point(6, 32);
            this.rbAnaliticFormula.Name = "rbAnaliticFormula";
            this.rbAnaliticFormula.Size = new System.Drawing.Size(109, 17);
            this.rbAnaliticFormula.TabIndex = 0;
            this.rbAnaliticFormula.TabStop = true;
            this.rbAnaliticFormula.Text = "Булева формула";
            this.rbAnaliticFormula.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Location = new System.Drawing.Point(17, 242);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 211);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Спосіб введення булевої функції F2";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "ОК";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 124);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(172, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Таблиця істинності суматора";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 101);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(108, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Завантажити dll ";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 78);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(160, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Ввести таблицю істинності";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 55);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(222, 17);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Текстовий файл з таблицею істинності";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(6, 32);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(109, 17);
            this.radioButton5.TabIndex = 0;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Булева формула";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // UserSuperpositionTruthTableInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ViewResultButton);
            this.Controls.Add(this.distProbInputChoiceBox);
            this.Controls.Add(this.boolFuncInputChoice);
            this.Name = "UserSuperpositionTruthTableInput";
            this.Size = new System.Drawing.Size(593, 471);
            this.distProbInputChoiceBox.ResumeLayout(false);
            this.distProbInputChoiceBox.PerformLayout();
            this.boolFuncInputChoice.ResumeLayout(false);
            this.boolFuncInputChoice.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ViewResultButton;
        private System.Windows.Forms.GroupBox distProbInputChoiceBox;
        private System.Windows.Forms.RadioButton rbHandWriteDistProb;
        private System.Windows.Forms.Button InputMethodChoosed;
        private System.Windows.Forms.RadioButton rbTextFileDistortion;
        private System.Windows.Forms.GroupBox boolFuncInputChoice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbAdder;
        private System.Windows.Forms.RadioButton rbDllImport;
        private System.Windows.Forms.RadioButton rbTruthTable;
        private System.Windows.Forms.RadioButton rbTextFile;
        private System.Windows.Forms.RadioButton rbAnaliticFormula;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;

    }
}
