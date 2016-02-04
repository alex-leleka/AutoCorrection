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

        public static BitArray Insert(this BitArray current, int first, int last, BitArray other)
        {
            var bools = new bool[current.Count + last - first + 1];
            for (int i = 0; i < first; ++i)
            {
                bools[i] = current[i];
            }
            for (int i = first; i < last + 1; ++i)
            {
                bools[i] = other[i];
            }
            for (int i = last + 1; i < bools.Length; ++i)
            {
                bools[i] = current[i];
            }
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

        /// <summary>
        /// Get op1 from adder operand.
        /// </summary>
        /// <param name="operand"></param>
        /// <param name="addendBitsCount"></param>
        /// <returns>op1 argument for adder.</returns>
        public static int GetAdderLowerOperand(this int operand, int addendBitsCount)
        {
            int opBitMask = (1 << addendBitsCount) - 1;
            int op1 = opBitMask & operand;
            return op1;
        }

        /// <summary>
        /// Get op2 from adder operand.
        /// </summary>
        /// <param name="operand"></param>
        /// <param name="addendBitsCount"></param>
        /// <returns>op2 argument for adder.</returns>
        public static int GetAdderHigherOperand(this int operand, int addendBitsCount)
        {
            int opBitMask = (1 << addendBitsCount) - 1;
            int op2 = opBitMask & (operand >> addendBitsCount);
            return op2;
        }
    }
}
