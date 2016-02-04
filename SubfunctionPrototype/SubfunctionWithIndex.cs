using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

namespace SubfunctionPrototype
{
    class SubfunctionWithIndex
    {
        private readonly bool[] _booleanFuntion;
        private int _index;

        public SubfunctionWithIndex(bool[] bf, int index)
        {
            _booleanFuntion = bf;
            _index = index;
        }

        public int GetIndex()
        {
            return _index;
        }
        /// <summary>
        /// Compares own BooleanFuntion to others BooleanFuntion and set Index of 
        /// other to this.Index if they are equal.
        /// </summary>
        /// <param name="other"></param>
        public bool Compare(SubfunctionWithIndex other)
        {
            bool isEqual = _booleanFuntion.SequenceEqual(other._booleanFuntion);
            if (isEqual)
                other._index = _index;
            return isEqual;
        }
    }
}
