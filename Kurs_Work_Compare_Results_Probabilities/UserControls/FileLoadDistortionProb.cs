using System;
using System.Windows.Forms;

namespace Diplom_Work_Compare_Results_Probabilities.UserControls
{
    public partial class FileLoadDistortionProb : FileLoad
    {
        private Action<InputDistortionProbabilities> _disProbProxy;
        public FileLoadDistortionProb(Action<InputDistortionProbabilities> disProbProxy) : base()
        {
            _disProbProxy = disProbProxy;
        }
        protected override void DoAction()
        {
            var reader = new DistortionProbTextReader(_path);
            MessageBox.Show(@"Opening file.");
            _disProbProxy(reader.GetDistortionProb());
        }
    }

    public partial class FileLoadDistortionProbWithUnited : FileLoad
    {
        private Action<InputDistortionProbabilities> _disProbProxy;
        public FileLoadDistortionProbWithUnited(Action<InputDistortionProbabilities> disProbProxy)
            : base()
        {
            _disProbProxy = disProbProxy;
        }
        protected override void DoAction()
        {
            var reader = new DistortionProbUnitedInputTextReader(_path);
            MessageBox.Show(@"Opening file.");
            var distWithUnitedInps = reader.GetDistortionProb();
            var converter = new DistortionWithUnitedConverter(distWithUnitedInps);
            //_disProbProxy(converter.GetInputDistortionProbabilities());
        }
    }

    public partial class FileLoadDistortionProbWithUnitedDirect : FileLoad
    {
        private Action<InputWithUnitedDistortionProbabilities> _disProbProxy;
        public FileLoadDistortionProbWithUnitedDirect(Action<InputWithUnitedDistortionProbabilities> disProbProxy)
            : base()
        {
            _disProbProxy = disProbProxy;
        }
        protected override void DoAction()
        {
            var reader = new DistortionProbUnitedInputTextReader(_path);
            MessageBox.Show(@"Opening file.");
            _disProbProxy(reader.GetDistortionProb());
        }
    }
}
