using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplom_Work_Compare_Results_Probabilities
{
    public class ProbabilitiesCalcWithCorrection : ProbabilitiesCalculatorAbstract
    {
        private double[][] _turnInProbabilityMatrix;// матриця ймовірностей перетворення одного набору в інший
            // на перетині i та j знаходиться ймовірність перетворення i-го набору в j-тий
        private Dictionary<int, List<int>> _transformedTruthTable; // key - fucntion result, value - array of operands
        private double[] _correctResultProbablitiesArray; // i-th element of array show probablity of correct
            // function result for i-th input operand in the left side of truth table
        private int _amountOfLinesInTruthTable;
        private int[] _functionTruthTable; // right side of truth table values
            // left side of truth table presented by index

        //private ProbabilitiesCalcWithCorrection() { }

        public ProbabilitiesCalcWithCorrection(double[] distortionToZeroProbability,
            double[] distortionToOneProbability, double[] distortionToInverseProbability,
            int inputNumberOfDigits, int outputNumberOfDigits, int [] functionTruthTable, 
            int amountOfLinesInTruthTable) : 
            base(distortionToZeroProbability, distortionToOneProbability, distortionToInverseProbability,
            inputNumberOfDigits, outputNumberOfDigits)
        {
            _amountOfLinesInTruthTable = amountOfLinesInTruthTable;
            _functionTruthTable = new int[amountOfLinesInTruthTable];
            for (int i = 0; i < amountOfLinesInTruthTable; i++)
            {
                _functionTruthTable[i] = functionTruthTable[i];
            }
        }
        private void CalculateTurnInProbabilityMatrix()
        {
            _turnInProbabilityMatrix = new double[_amountOfLinesInTruthTable][];
            for(int i = 0; i < _amountOfLinesInTruthTable; i++)
            {
                _turnInProbabilityMatrix[i] = new double[_amountOfLinesInTruthTable];
                for (int j = 0; j < _amountOfLinesInTruthTable; j++)
                {
                    _turnInProbabilityMatrix[i][j] = CalculateTurnInProbability(i, j);
                }
            }
        }

        private double CalculateTurnInProbability(int originalValue, int corruptedValue) // i turn in j, but not vice versa
        {
            double operandTurnInProbability = 1.0;
            double bitTurnInProbability;
            for (int i = 0, mask = 1; i < _inputNumberOfDigits; i++, mask *= 2)
            {
                if((mask & originalValue) != 0)
                {
                    if ((mask & corruptedValue) != 0) // 1 -> 1 /*(d)*/
                    {
                        bitTurnInProbability = _distortionToOneProbability[i] + _correctValueProbability[i];
                    }
                    else // 1 -> 0 /*(c)*/
                    {
                         bitTurnInProbability = _distortionToZeroProbability[i] + _distortionToInverseProbability[i];
                    }
                }
                else
                {
                    if ((mask & corruptedValue) != 0) // 0 -> 1 /*(b)*/
                    {
                        bitTurnInProbability = _distortionToOneProbability[i] + _distortionToInverseProbability[i];
                    }
                    else // 0 -> 0 /*(a)*/
                    {
                        bitTurnInProbability = _distortionToZeroProbability[i] + _correctValueProbability[i];
                    }
                }
                operandTurnInProbability *= bitTurnInProbability;
            }
            return operandTurnInProbability;
        }
        private void CreateTransformedTruthTable()
        {
            _transformedTruthTable = new Dictionary<int,List<int>>();
            _transformedTruthTable.Add(_functionTruthTable[0], new List<int>());
            _transformedTruthTable.ElementAt(0).Value.Add(0);
            for (int i = 1; i < _amountOfLinesInTruthTable; i++)
            {
                if (! _transformedTruthTable.ContainsKey(_functionTruthTable[i]))
                {
                    _transformedTruthTable.Add(_functionTruthTable[i], new List<int>());
                }
                _transformedTruthTable[_functionTruthTable[i]].Add(i);
            }
        }
        private void CalculateCorrectResultProbablitiesArray()
        {
            _correctResultProbablitiesArray = new double[_amountOfLinesInTruthTable];
            for (int i = 0; i < _amountOfLinesInTruthTable; i++)
            {
                _correctResultProbablitiesArray[i] = 0.0;
                foreach (int j in _transformedTruthTable[_functionTruthTable[i]])
                {
                    _correctResultProbablitiesArray[i] += _turnInProbabilityMatrix[i][j];
                }
            }
        }
        private double CalculateCorrectResultProbability() // returns Correct Result Probability
            //taking into account the auto-correction
        {
           // Потрібне грунтовне теоретичне пояснення!!!
           // TODO: Визначити ймовірність правильної роботи функції на основі
           //       ймовірностей  правильної роботи для кожного окремого результату
           // double probability = 1.0;
           // for (int i = 0; i < _amountOfLinesInTruthTable; i++)
           // {
           //     probability *= _correctResultProbablitiesArray[i];
           // }
           // return probability;

            // функція повертає наижню границю ймовірності правильної роботи функції
            double min_probability = 1.0;
            double average_probability = 0;
            for (int i = 0; i < _amountOfLinesInTruthTable; i++)
            {
                if(_correctResultProbablitiesArray[i] < min_probability)
                    min_probability = _correctResultProbablitiesArray[i];
                average_probability += _correctResultProbablitiesArray[i];
            }
            average_probability /= _amountOfLinesInTruthTable;
            return min_probability;
        }
        public double[] CalculateCorrectResultProbabilityArr() // returns Correct Result Probability
        //taking into account the auto-correction
        {
            CalculateTurnInProbabilityMatrix();
            // 2
            CreateTransformedTruthTable();
            // 3
            CalculateCorrectResultProbablitiesArray();
            // Потрібне грунтовне теоретичне пояснення!!!
            // TODO: Визначити ймовірність правильної роботи функції на основі
            //       ймовірностей  правильної роботи для кожного окремого результату
            // double probability = 1.0;
            // for (int i = 0; i < _amountOfLinesInTruthTable; i++)
            // {
            //     probability *= _correctResultProbablitiesArray[i];
            // }
            // return probability;

            // функція повертає наижню границю ймовірності правильної роботи функції
            double min_probability = 1.0;
            double average_probability = 0;
            for (int i = 0; i < _amountOfLinesInTruthTable; i++)
            {
                if (_correctResultProbablitiesArray[i] < min_probability)
                    min_probability = _correctResultProbablitiesArray[i];
                average_probability += _correctResultProbablitiesArray[i];
            }
            average_probability /= _amountOfLinesInTruthTable;
            return _correctResultProbablitiesArray;
        }
        public override double GetCorrectResultProbability()
        {
            // 1
            CalculateTurnInProbabilityMatrix();
            // 2
            CreateTransformedTruthTable();
            // 3
            CalculateCorrectResultProbablitiesArray();
            // 4
            return CalculateCorrectResultProbability();
        }
    }
}
