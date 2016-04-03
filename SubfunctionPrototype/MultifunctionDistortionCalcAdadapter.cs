using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom_Work_Compare_Results_Probabilities;

namespace SubfunctionPrototype
{
    class MultifunctionDistortionCalcAdadapter : MultifunctionDistortionCalc
    {
        private InputDistortionG4 _inputDistortions;
        private readonly Func<int, int>[] _boolFunctions;
        private readonly int _separateBitsNumber;

        public MultifunctionDistortionCalcAdadapter(InputDistortionG4 inputDistortions, Func<int, int> boolFunction) : base(inputDistortions, boolFunction)
        {
            _boolFunctions = null;
        }

        /// <summary>
        /// Creates calculation that will be done 
        /// </summary>
        /// <param name="inputDistortions"></param>
        /// <param name="boolFunctions"> Array of two boolean functions</param>
        /// <param name="separateBitsNumber"></param>
        public MultifunctionDistortionCalcAdadapter(InputDistortionG4 inputDistortions, Func<int, int>[] boolFunctions)
            : base(inputDistortions, null)
        {
            _inputDistortions = inputDistortions;
            _boolFunctions = boolFunctions;
            _separateBitsNumber = inputDistortions.GetInputDigitsCount() / 2 / boolFunctions.Length;
            // _indexes = indexes;

        }

        public override G4Probability[] GetResultDistortinProbabilities()
        {
            if (null == _boolFunctions)
                return base.GetResultDistortinProbabilities();

            if (_separateBitsNumber >= _inputDistortions.GetInputDigitsCount())
                throw new Exception("separate bits number should be less than InputBitsNumber");
            if (_inputDistortions.GetInputDigitsCount() < 20)
                return ConvertToTwoAddersAndGetDistortion();
            return ConvertToMultpleAddersGetDistortion();
        }

        private G4Probability[] ConvertToTwoAddersAndGetDistortion()
        {
            // create inputDistortions[0]
            var inpDistLower = _inputDistortions.GetAdderLowerBitsDistortion(_separateBitsNumber);
            // calculate result g4 probabilities for adder lower bits
            MultifunctionDistortionCalc pCalc = new MultifunctionDistortionCalc(inpDistLower, _boolFunctions[0]);
            var resDistLower = pCalc.GetResultDistortinProbabilities();
            // create inputDistortions[1] from _inputDistortions and resDistLower higher bit probabilities
            int carryBitIndex = resDistLower.Length - 1;
            var inpDistHigher = _inputDistortions.GetAdderHigherBitsDistortion(_separateBitsNumber,
                resDistLower[carryBitIndex]);
            // calculate result g4 probabilities for adder higher bits
            pCalc = new MultifunctionDistortionCalc(inpDistHigher, _boolFunctions[1]);
            var resDistHigher = pCalc.GetResultDistortinProbabilities();
            var resG4 = GetAdderResultDistortionG4Probs(resDistLower, resDistHigher);
            return resG4;
        }

        private G4Probability[] ConvertToMultpleAddersGetDistortion()
        {
            int maxAdderBound = _boolFunctions.Length;
            G4Probability carry = null;
            G4Probability[] resG4 = null;
            for(int adderNumber = 0; adderNumber < maxAdderBound; ++adderNumber)
            {
                // get input distortion for current adder
                var inpDist = _inputDistortions.GetAdderBitsDistortion(adderNumber * _separateBitsNumber, _separateBitsNumber, carry);
                // calc dist for current adder
                MultifunctionDistortionCalc pCalc = new MultifunctionDistortionCalc(inpDist, _boolFunctions[adderNumber]);
                var resDist = pCalc.GetResultDistortinProbabilities();
                // save higher bit as carry
                int carryBitIndex = resDist.Length - 1;
                carry = resDist[carryBitIndex];
                resG4 = GetAdderResultDistortionG4Probs(resG4, resDist);
            }

            return resG4;
        }

        private G4Probability[] GetAdderResultDistortionG4Probs(G4Probability[] resDistLower, G4Probability[] resDistHigher)
        {
            if (resDistLower == null)
                return resDistHigher;
            int outputBitsCount = resDistLower.Length - 1 + resDistHigher.Length; // we subtract one for carry bit
            var res = new G4Probability[outputBitsCount];
            for (int i = 0; i < resDistLower.Length - 1; ++i)
                res[i] = resDistLower[i];
            for (int i = 0; i < resDistHigher.Length; ++i)
                res[i + resDistLower.Length - 1] = resDistHigher[i];
            return res;
        }
    }
}
