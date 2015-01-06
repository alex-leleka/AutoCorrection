using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
////using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public partial class UserControlForm : Form
    {
        public UserControlForm(UserControl uc)
        {
            uc.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.Controls.Add(uc);
            InitializeComponent();
        }

    }
}
