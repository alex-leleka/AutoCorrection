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

      /*  private double[] _idpDistortionToZeroProbability;// = new double[GetSecondLevelInputsCount()];
        private double[] _idpDistortionToOneProbability;// = new double[GetSecondLevelInputsCount()];
        private double[] _idpDistortionToInverseProbability;// = new double[GetSecondLevelInputsCount()];
        private double[] _idpProbalityZero;// = new double[GetSecondLevelInputsCount()];*/


        public DistortionWithUnitedConverter(InputWithUnitedDistortionProbabilities idpDistortionToZeroProbability)
        {
            _inpDist = idpDistortionToZeroProbability;
        }

        private static double[][] InitProbsArrays(int distCount)
        {
            double[][] probsArr = new double[2][];
            probsArr[0] = new double[distCount];
            probsArr[1] = new double[distCount];
            return probsArr;
        }
        public ProductClasses GetInputDistortionProbabilities() 
        {
            int distCount = _inpDist.GetSecondLevelInputsCount();
            double[] noDistortionProbability = new double[distCount];
            double[][] autoCorrectedProbability = InitProbsArrays(distCount);
            double[][] distortedProbability = InitProbsArrays(distCount);
            double[] probalityZero = new double[distCount];
            // TODO: calc probs(convert probs using my computations)
            GetNoDConvertion(noDistortionProbability);
            GetACConvertion(autoCorrectedProbability);
            GetDConvertion(distortedProbability);
            GetPZConvertion(probalityZero);
            return new ProductClasses(noDistortionProbability, autoCorrectedProbability, distortedProbability, probalityZero);
            
        }

        private void GetDConvertion(double[][] distortedProbability)
        {
            throw new NotImplementedException();
        }

        private void GetACConvertion(double[][] autoCorrectedProbability)
        {
            throw new NotImplementedException();
        }

        private void GetNoDConvertion(double[] noDistortionProbability)
        {
            for (int i = 0; i < noDistortionProbability.Length; i++)
            {
                noDistortionProbability[i] = _inpDist.GetFistLevelDistortionProbability(0, _inpDist.GetBitMappedVariableIndex(i))
                    * _inpDist.GetSecondLevelDistortionProbability(0,i);
            }
        }

        private void GetPZConvertion(double[] probalityZero)
        {
            for (int i = 0; i < probalityZero.Length; i++)
            {
                probalityZero[i] = _inpDist.GetProbalityZero(_inpDist.GetBitMappedVariableIndex(i));
            }
        }

    }
}
