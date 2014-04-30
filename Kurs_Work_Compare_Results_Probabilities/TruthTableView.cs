﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;
using System.Collections;

namespace Diplom_Work_Compare_Results_Probabilities
{
    class TruthTableView
    {
        private DataTable _dataTable;
        private AdderTruthTable _truthTable;
        public TruthTableView(AdderTruthTable truthTable) 
        { 
            _dataTable = new DataTable();
            _truthTable = truthTable;
        }
        public DataView GetView()
        {
            //_dataTable column names and types
            _dataTable.Columns.Add("A", typeof(string));
            _dataTable.Columns.Add("B", typeof(string));
            _dataTable.Columns.Add("Sum", typeof(string));

            int shiftValue = sizeof(int) * 8 - _truthTable.InputNumberOfDigits;
            // mask for second operand
            int maskB = (int)((uint.MaxValue << shiftValue) >> shiftValue); // Warning: cast
            int maskA = maskB << _truthTable.InputNumberOfDigits;
            // add unsorted data to the DataTable and return.
            for (int i = 0; i < _truthTable.functionValue.Count; i++)
            {
                _dataTable.Rows.Add(ConvertNumberToBinary((int)((uint)i & maskA) >> _truthTable.InputNumberOfDigits,
                   _truthTable.InputNumberOfDigits), ConvertNumberToBinary(i & maskB, _truthTable.InputNumberOfDigits),
                   ConvertNumberToBinary(_truthTable.functionValue[i]));

            }
            return _dataTable.AsDataView();
        }
        public static DataView GetView(AbstractBooleanFuntionWithInputDistortion tTable)
        {
            var dataTable = new DataTable();
            //_dataTable column names and types
            dataTable.Columns.Add("X", typeof(string));
            dataTable.Columns.Add("F(X)", typeof(string));

            // add unsorted data to the DataTable and return.
            for (int i = 0; i < tTable.GetLinesCount(); i++)
            {
                dataTable.Rows.Add(ConvertNumberToBinary(tTable.GetOperandByLineIndex(i)), ConvertNumberToBinary(tTable.GetResultByLineIndex(i)));

            }
            return dataTable.AsDataView();
        }
        public DataView GetViewWithProbabilities()
        {
            //_dataTable column names and types
            _dataTable.Columns.Add("A", typeof(string));
            _dataTable.Columns.Add("B", typeof(string));
            _dataTable.Columns.Add("Sum", typeof(string));
            _dataTable.Columns.Add("P", typeof(double));

            int shiftValue = sizeof(int) * 8 - _truthTable.InputNumberOfDigits;
            // mask for second operand
            int maskB = (int)((uint.MaxValue << shiftValue) >> shiftValue); // Warning: cast
            int maskA = maskB << _truthTable.InputNumberOfDigits;
            // add unsorted data to the DataTable and return.
            int[] intTable = AdderTruthTableBuilder.ConvertBoolArrToIntTable(_truthTable);
             double[] distortionto1Probability =       { 0.1, 0.0, 0.3, 0.3, 0.1, 0.1, 0.0, 0.3, 0.3, 0.1 };
            double[] distortionto0Probability =       { 0.3, 0.1, 0.2, 0.1, 0.2, 0.3, 0.1, 0.2, 0.1, 0.2 };
            double[] distortiontoInverseProbability = { 0.3, 0.5, 0.0, 0.2, 0.1, 0.3, 0.5, 0.0, 0.2, 0.1 };

            var pcalc = new ProbabilitiesCalcWithCorrection(distortionto0Probability, distortionto1Probability,
                distortiontoInverseProbability, 10, 11, intTable, intTable.Length);
            var p = pcalc.CalculateCorrectResultProbabilityArr();
            for (int i = 0; i < _truthTable.functionValue.Count; i++)
            {
                _dataTable.Rows.Add(ConvertNumberToBinary((int)((uint)i & maskA) >> _truthTable.InputNumberOfDigits,
                   _truthTable.InputNumberOfDigits), ConvertNumberToBinary(i & maskB, _truthTable.InputNumberOfDigits),
                   ConvertNumberToBinary(_truthTable.functionValue[i]), p[i]);

            }
            return _dataTable.AsDataView();
        }
        private string ConvertNumberToBinary(int number, int digits)
        {
            // convert number
            // remove "0x"
            // add left padding fill 0
            string binary = Convert.ToString(number, 2);
            //binary.Remove(0, 2);
            return binary.PadLeft(digits, '0');
        }
        private static string ConvertNumberToBinary<T>(/*bool []*/T arr) where T : IEnumerable
        {
            string binary = "";
            foreach (var b in arr)
                if ((bool)b)
                    binary += "1";
                else
                    binary += "0";
            return binary;
        }
    }
}
