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
        public MultifunctionDistortionCalcAdadapter(InputDistortionG4 inputDistortions, Func<int, int> boolFunction) : base(inputDistortions, boolFunction)
        {
        }

    }
}
