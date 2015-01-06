using System;
using System.Collections;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public static class IBitArrayExtensions
    {
        public static bool Eq(this BitArray current, BitArray other)
        {
            if (current == other)
                return true;
            for (int i = 0; i < current.Length; i++)
            {
                if (current[i] != other[i])
                    return false;
            }

            return true;
        }
    }
}
