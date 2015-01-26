using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    public partial class FileLoad : UserControl
    {
        public FileLoad()
        {
            InitializeComponent();
        }
        protected string _path;
        protected virtual void DoAction(){}
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if ((openFileDialog1.ShowDialog() == DialogResult.OK) && (openFileDialog1.FileName != ""))
            {
                //open file or send name throug
                _path = openFileDialog1.FileName;
                DoAction();
            }
            else
            {
                // file not choosed
                MessageBox.Show(@"Please, open file.");
            }
            var findForm = FindForm();
            if (findForm != null) findForm.Close();
        }
    }
}
