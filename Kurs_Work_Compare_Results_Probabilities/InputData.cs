﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public partial class InputData : Form
    {
        public InputData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            UserTruthTableInput utti = new UserTruthTableInput();
            utti.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Controls.Add(utti);
             * */
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBoxCalcWay.Visible = false;
            UserTruthTableInput im = new UserTruthTableInput();
            im.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Controls.Add(im);
        }
    }
}
