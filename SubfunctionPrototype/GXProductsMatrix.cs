using System.Collections.Generic;

namespace SubfunctionPrototype
{
    public class GXProductsMatrix
    {
        // TODO: optimize matrix operations 
        private List<List<double>> _matrix;

        public GXProductsMatrix(int rowsNum, int columnsNum)
        {
            _matrix = new List<List<double>>(rowsNum);
            for (int i = 0; i < rowsNum; i++)
            {
                _matrix.Add(new List<double>(columnsNum));
                for (int j = 0; j < columnsNum; j++)
                {
                    _matrix[i].Add(0.0);
                }
            }
        }

        public double Get(int row,int column)
        {
            return _matrix[row][column];
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
            for (int i = 0; i < _matrix[rowAddTo].Count; ++i)
            {
                _matrix[rowAddTo][i] += _matrix[rowToAdd][i];
            }
            RemoveRow(rowToAdd);
        }

        public void AddColumn(int colAddTo, int colToAdd)
        {
            for (int i = 0; i < _matrix.Count; ++i)
            {
                _matrix[i][colAddTo] += _matrix[i][colToAdd];
            }
            RemoveCol(colToAdd);
        }

        private void RemoveCol(int col)
        {
            for (int i = 0; i < _matrix.Count; ++i)
            {
                _matrix[i].RemoveAt(col);
            }
        }

        private void RemoveRow(int row)
        {
            _matrix.RemoveAt(row);
        }

        public int GetRowsCount()
        {
            return _matrix.Count;
        }

        public int GetColumnsCount()
        {
            return _matrix[0].Count;
        }
    }
}