namespace Diplom_Work_Compare_Results_Probabilities
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
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(555, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 36);
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
            this.tableGridView.Size = new System.Drawing.Size(525, 486);
            this.tableGridView.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(555, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "Load distortion table";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 488);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tableGridView);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "TableView";
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView tableGridView;
        private System.Windows.Forms.Button button2;
    }
}

