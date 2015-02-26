using System;
using System.Windows.Forms;

namespace Diplom_Work_Compare_Results_Probabilities.UserControls
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new Form1();
            formShow(form);
        }
        private void formShow(Form f)
        {
            f.Visible = false;
            f.Show();
            if (f.WindowState == FormWindowState.Minimized)
                f.WindowState = FormWindowState.Normal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBoxCalcWay.Visible = false;
            UserSuperpositionTruthTableInput im = new UserSuperpositionTruthTableInput();
            im.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Controls.Add(im);
        }
    }
}
