using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    public partial class FuncTruthTableInput : UserControl
    {
        private int inputDigitsCount;
        private int outputDigitsCount;

        Action<BooleanFuntionWithInputDistortion> _bfProxy;
        
        public FuncTruthTableInput(Action<BooleanFuntionWithInputDistortion> bfProxy)
        {
            _bfProxy = bfProxy;
            InitializeComponent();
        }

        private void DigitsApply_Click(object sender, EventArgs e)
        {
            tablePropertiesBox.Enabled = false;
            label1.Enabled = dataGridView1.Enabled = true;
            
            inputDigitsCount = Convert.ToInt32(numericInpDigitsCount.Value);
            outputDigitsCount = Convert.ToInt32(numericOutpDigitsCount.Value);
            dataGridView1.Rows.Add((1 << inputDigitsCount) - dataGridView1.Rows.Count);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] truthTable = new int[1 << inputDigitsCount];
            // read truth table
            for (int i = 0; i < truthTable.Length; i++)
            {
                truthTable[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
            }
            var bf = new BooleanFunctionTruthTable(inputDigitsCount, outputDigitsCount);
            bf.SetResultTable(truthTable);
            _bfProxy(bf);
            this.FindForm().Close();
        }
    }
}
