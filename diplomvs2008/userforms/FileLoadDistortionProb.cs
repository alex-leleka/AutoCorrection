using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
////using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    public partial class FileLoadDistortionProb : FileLoad
    {
        Action<InputDistortionProbabilities> _disProbProxy;
        public FileLoadDistortionProb(Action<InputDistortionProbabilities> disProbProxy) 
            : base()
        {
            _disProbProxy = disProbProxy;
            //InitializeComponent();
        }
        protected override void DoAction()
        {
            var reader = new DistortionProbTextReader(_path);
            MessageBox.Show("open file.");
            _disProbProxy(reader.GetDistortionProb());
        }
    }
}
