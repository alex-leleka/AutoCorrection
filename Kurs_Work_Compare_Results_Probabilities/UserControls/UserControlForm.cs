using System.Windows.Forms;

namespace Diplom_Work_Compare_Results_Probabilities.UserControls
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
