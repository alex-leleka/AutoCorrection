using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubfunctionPrototype
{
    /// <summary>
    /// Class allow us to get all combinations of elements indexes in range of their bounds.
    /// So we could iterate over any number of arrays.
    /// </summary>
    public class GxIndexesCombination
    {
        private readonly int[] _bounds;
        private int[] _indexes;
        private bool _finish;

        public GxIndexesCombination(int[] bounds)
        {
            _finish = false;
            _bounds = bounds;
            _indexes = new int[bounds.Length];
        }

        public int GetIndexOf(int gxNumber)
        {
            return _indexes[gxNumber];
        }

        public int GetDimentions()
        {
            return _indexes.Length;
        }

        public void CopyTo(int [] destination, int startIndex)
        {
            _indexes.CopyTo(destination, startIndex);
        }

        public bool Increment()
        {
            if (_finish)
                return false;

            for (int i = 0; i < _indexes.Length; ++i)
                if (_indexes[i] + 1 == _bounds[i])
                {
                    _indexes[i] = 0;
                    continue;
                }
                else
                {
                    ++_indexes[i];
                    return true;
                }

            for (int i = 0; i < _bounds.Length; ++i)
            {
                _indexes[i] = _bounds[i] - 1;
            }

            _finish = true;
            return true;
        }


    }
}
