using System.Collections.Generic;
using System.Linq;

namespace SubfunctionPrototype
{
    public class GXProductsMatrix
    {
        // TODO: optimize matrix operations 
        private Dictionary<int, Dictionary<int, double>> _matrix;
        private double[][] _arrInts;
        public GXProductsMatrix(int rowsNum, int columnsNum)
        {
            _arrInts = null;
            _matrix = new Dictionary<int, Dictionary<int, double>>(rowsNum);
            for (int i = 0; i < rowsNum; i++)
            {
                _matrix.Add(i, new Dictionary<int, double>(columnsNum));
                for (int j = 0; j < columnsNum; j++)
                {
                    _matrix[i].Add(j, 0.0);
                }
            }
        }

        /// <summary>
        /// Optimization for accessing elements by index.
        /// </summary>
        public void ConvertDictionatyToArray()
        {
            int size = _matrix.Count;
            _arrInts = new double[size][];
            for (int i = 0; i < size; ++i)
            {
                _arrInts[i] = _matrix.ElementAt(i).Value.Values.ToArray();
            }
        }
        public Dictionary<int, Dictionary<int, double>>.KeyCollection GetRowsKeys()
        {
            return _matrix.Keys;
        }

        public Dictionary<int, double>.KeyCollection GetColumsKeys(int rowKey)
        {
            return _matrix[rowKey].Keys;
        }

        public double Get(int row,int column)
        {
            if (_arrInts != null)
                return _arrInts[row][column];
            return _matrix.ElementAt(row).Value.ElementAt(column).Value; // HACK , access elements by index not by key (original matrix index)
        }

        public int GetRowKeyByIndex(int index)
        {
            return _matrix.ElementAt(index).Key;
        }

        public int GetColumnKeyByIndex(int index)
        {
            return _matrix[0].ElementAt(index).Key;
        }

        public void Set(int row, int column, double val)
        {
            _matrix[row][column] = val;
        }
        /// <summary>
        /// Add values in rows, save result to rowAddTo, removes rowToAdd row.
        /// </summary>
        /// <param name="rowAddTo"></param>
        /// <param name="rowToAdd"></param>
        public void AddRow(int rowAddTo, int rowToAdd)
        {
            foreach (var columnKey in _matrix[rowToAdd].Keys)
            {
                _matrix[rowAddTo][columnKey] += _matrix[rowToAdd][columnKey];
            }
            RemoveRow(rowToAdd);
        }

        public void AddColumn(int colAddTo, int colToAdd)
        {
            foreach (var row in _matrix)
            {
                row.Value[colAddTo] += row.Value[colToAdd];
            }
            RemoveCol(colToAdd);
        }

        private void RemoveCol(int col)
        {
            foreach (var row in _matrix)
            {
                row.Value.Remove(col);
            }
        }

        private void RemoveRow(int row)
        {
            _matrix.Remove(row);
        }

        public int GetRowsCount()
        {
            return _matrix.Count;
        }

        public int GetColumnsCount()
        {
            return _matrix[0].Count;
        }

        public double GetByKey(int rowKey, int columnKey)
        {
            return _matrix[rowKey][columnKey];
        }
    }

    public class GFProductsMatrix
    {
        // TODO: optimize matrix operations 
        private double[][] _matrix;
        public GFProductsMatrix(int rowsNum, int columnsNum)
        {
            _matrix = new double[(rowsNum)][];
            for (int i = 0; i < rowsNum; i++)
            {
                _matrix[i] = new double[columnsNum];
            }
        }

        /// <summary>
        /// Optimization for accessing elements by index.
        /// </summary>
        public void ConvertDictionatyToArray()
        {

        }


        public double Get(int row, int column)
        {
            return _matrix[row][column];
        }

        public void Reset(int row, int column)
        {
            _matrix[row][column] = 0;
        }

        public void AddNumber(int row, int column, double p)
        {
            _matrix[row][column] += p;
        }

        public void Set(int row, int column, double val)
        {
            _matrix[row][column] = val;
        }
        /// <summary>
        /// Add values in rows, save result to rowAddTo, removes rowToAdd row.
        /// </summary>
        /// <param name="rowAddTo"></param>
        /// <param name="rowToAdd"></param>
        public void AddRow(int rowAddTo, int rowToAdd)
        {
            for(var i =0; i < _matrix[0].Length; ++i)
            {
                _matrix[rowAddTo][i] += _matrix[rowToAdd][i];
            }
            RemoveRow(rowToAdd);
        }

        public void AddColumn(int colAddTo, int colToAdd)
        {
            for (var i = 0; i < _matrix.Length; ++i)
            {
                _matrix[i][colAddTo] += _matrix[i][colToAdd];
            }
            RemoveCol(colToAdd);
        }

        private void RemoveCol(int col)
        {
        }

        private void RemoveRow(int row)
        {
        }

        public int GetRowsCount()
        {
            return _matrix.Length;
        }

        public int GetColumnsCount()
        {
            return _matrix[0].Length;
        }

        public double GetByKey(int rowKey, int columnKey)
        {
            return _matrix[rowKey][columnKey];
        }
    }
}