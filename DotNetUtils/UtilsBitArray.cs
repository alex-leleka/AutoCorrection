using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUtils
{

    public static class UtilsBitArray
    {
        public static BitArray Prepend(this BitArray current, BitArray before)
        {
            var bools = new bool[current.Count + before.Count];
            before.CopyTo(bools, 0);
            current.CopyTo(bools, before.Count);
            return new BitArray(bools);
        }

        public static BitArray Append(this BitArray current, BitArray after)
        {
            var bools = new bool[current.Count + after.Count];
            current.CopyTo(bools, 0);
            after.CopyTo(bools, current.Count);
            return new BitArray(bools);
        }

        public static BitArray ToBinary(this int numeral, int bitsCount)
        {
            BitArray ar = new BitArray(bitsCount);
            BitArray arTmp = new BitArray(new[] { numeral });
            for (int i = 0; i < bitsCount; i++)
                ar[i] = arTmp[i];
            return ar;
        }
    }
}
