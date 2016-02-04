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
        private readonly BooleanFuntionWithInputDistortion BooleanFuntion;
        private int Index;

        public SubfunctionWithIndex(BooleanFuntionWithInputDistortion bf, int index)
        {
            BooleanFuntion = bf;
            Index = index;
        }

        public int GetIndex()
        {
            return Index;
        }
        /// <summary>
        /// Compares own BooleanFuntion to others BooleanFuntion and set Index of 
        /// other to this.Index if they are equal.
        /// </summary>
        /// <param name="other"></param>
        public void Compare(SubfunctionWithIndex other)
        {
            throw new NotImplementedException();
        }
    }
}
