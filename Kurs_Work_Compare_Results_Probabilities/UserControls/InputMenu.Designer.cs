namespace Diplom_Work_Compare_Results_Probabilities
{
    partial class UserTruthTableInput
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
            this.rbAnaliticFormula = new System.Windows.Forms.RadioButton();
            this.boolFuncInputChoice = new System.Windows.Forms.GroupBox();
            this.rbAdder = new System.Windows.Forms.RadioButton();
            this.rbDllImport = new System.Windows.Forms.RadioButton();
            this.rbTruthTable = new System.Windows.Forms.RadioButton();
            this.rbTextFile = new System.Windows.Forms.RadioButton();
            this.distProbInputChoiceBox = new System.Windows.Forms.GroupBox();
            this.rbHandWriteDistProb = new System.Windows.Forms.RadioButton();
            this.rbTextFileDistortion = new System.Windows.Forms.RadioButton();
            this.InputMethodChoosed = new System.Windows.Forms.Button();
            this.ViewResultButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.boolFuncInputChoice.SuspendLayout();
            this.distProbInputChoiceBox.SuspendLayout();
            this.SuspendLayout();
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
            // boolFuncInputChoice
            // 
            this.boolFuncInputChoice.Controls.Add(this.button1);
            this.boolFuncInputChoice.Controls.Add(this.rbAdder);
            this.boolFuncInputChoice.Controls.Add(this.rbDllImport);
            this.boolFuncInputChoice.Controls.Add(this.rbTruthTable);
            this.boolFuncInputChoice.Controls.Add(this.rbTextFile);
            this.boolFuncInputChoice.Controls.Add(this.rbAnaliticFormula);
            this.boolFuncInputChoice.Location = new System.Drawing.Point(15, 31);
            this.boolFuncInputChoice.Name = "boolFuncInputChoice";
            this.boolFuncInputChoice.Size = new System.Drawing.Size(247, 211);
            this.boolFuncInputChoice.TabIndex = 1;
            this.boolFuncInputChoice.TabStop = false;
            this.boolFuncInputChoice.Text = "Спосіб введення булевої функції";
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
            // distProbInputChoiceBox
            // 
            this.distProbInputChoiceBox.Controls.Add(this.rbHandWriteDistProb);
            this.distProbInputChoiceBox.Controls.Add(this.InputMethodChoosed);
            this.distProbInputChoiceBox.Controls.Add(this.rbTextFileDistortion);
            this.distProbInputChoiceBox.Location = new System.Drawing.Point(317, 31);
            this.distProbInputChoiceBox.Name = "distProbInputChoiceBox";
            this.distProbInputChoiceBox.Size = new System.Drawing.Size(247, 211);
            this.distProbInputChoiceBox.TabIndex = 2;
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
            // ViewResultButton
            // 
            this.ViewResultButton.Location = new System.Drawing.Point(15, 262);
            this.ViewResultButton.Name = "ViewResultButton";
            this.ViewResultButton.Size = new System.Drawing.Size(98, 43);
            this.ViewResultButton.TabIndex = 4;
            this.ViewResultButton.Text = "Показати результат";
            this.ViewResultButton.UseVisualStyleBackColor = true;
            this.ViewResultButton.Visible = false;
            this.ViewResultButton.Click += new System.EventHandler(this.ViewResultButton_Click);
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
            // UserTruthTableInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ViewResultButton);
            this.Controls.Add(this.distProbInputChoiceBox);
            this.Controls.Add(this.boolFuncInputChoice);
            this.Name = "UserTruthTableInput";
            this.Size = new System.Drawing.Size(577, 351);
            this.boolFuncInputChoice.ResumeLayout(false);
            this.boolFuncInputChoice.PerformLayout();
            this.distProbInputChoiceBox.ResumeLayout(false);
            this.distProbInputChoiceBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbAnaliticFormula;
        private System.Windows.Forms.GroupBox boolFuncInputChoice;
        private System.Windows.Forms.RadioButton rbDllImport;
        private System.Windows.Forms.RadioButton rbTruthTable;
        private System.Windows.Forms.RadioButton rbTextFile;
        private System.Windows.Forms.GroupBox distProbInputChoiceBox;
        private System.Windows.Forms.RadioButton rbHandWriteDistProb;
        private System.Windows.Forms.RadioButton rbTextFileDistortion;
        private System.Windows.Forms.Button InputMethodChoosed;
        private System.Windows.Forms.Button ViewResultButton;
        private System.Windows.Forms.RadioButton rbAdder;
        private System.Windows.Forms.Button button1;
    }
}
