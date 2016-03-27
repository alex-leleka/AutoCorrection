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
        public MultifunctionDistortionCalcAdadapter(InputDistortionG4 inputDistortions, Func<int, int>[] boolFunctions, int separateBitsNumber)
            : base(inputDistortions, null)
        {
            _inputDistortions = inputDistortions;
            _boolFunctions = boolFunctions;
            _separateBitsNumber = separateBitsNumber;
            // _indexes = indexes;

        }

        public override G4Probability[] GetResultDistortinProbabilities()
        {
            if (null == _boolFunctions)
                return base.GetResultDistortinProbabilities();

            if (_separateBitsNumber >= _inputDistortions.GetInputBitsNumber())
                throw new Exception("separate bits number should be less than InputBitsNumber");
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

            return resDistHigher;

        }
    }
}
