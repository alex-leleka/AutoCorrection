﻿namespace SubfunctionPrototype
{
    /// <summary>
    /// First and Last are actual indexes of the function arguments
    /// </summary>
    internal class GXIndex
    {
        private int _first;
        private int _last;

        public GXIndex(int first, int mid)
        {
            _first = first;
            _last = mid;
        }

        /// <summary>
        /// The first number in sequence. Index of the function argument starting from 0.
        /// </summary>
        public int First
        {
            get
            {
                return _first;
            }

            set
            {
                _first = value;
            }
        }

        /// <summary>
        /// The last number in sequence. Index of the function argument starting from 0.
        /// </summary>
        public int Last
        {
            get
            {
                return _last;
            }

            set
            {
                _last = value;
            }
        }
    }
}