using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Work_Compare_Results_Probabilities
{

    class DistortionWithUnitedConverter
    {
        private InputWithUnitedDistortionProbabilities _inpDist;
        private readonly ReadOnlyCollection<int> _firstLevelInputsTargets;

        private double[] _idpDistortionToZeroProbability;// = new double[GetSecondLevelInputsCount()];
        private double[] _idpDistortionToOneProbability;// = new double[GetSecondLevelInputsCount()];
        private double[] _idpDistortionToInverseProbability;// = new double[GetSecondLevelInputsCount()];
        private double[] _idpProbalityZero;// = new double[GetSecondLevelInputsCount()];
    }
}
