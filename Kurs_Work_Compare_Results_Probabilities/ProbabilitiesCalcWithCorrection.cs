using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;

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
        private BooleanFuntionWithInputDistortion _functionTruthTable;
        private readonly double[] _zeroProbability;

        public ProbabilitiesCalcWithCorrection(double[] distortionToZeroProbability,
            double[] distortionToOneProbability, double[] distortionToInverseProbability,
            BooleanFuntionWithInputDistortion functionTruthTable, double[] zeroProbability) : 
            base(distortionToZeroProbability, distortionToOneProbability, distortionToInverseProbability,
            functionTruthTable.InputNumberOfDigits, functionTruthTable.OutputNumberOfDigits)
        {
            _amountOfLinesInTruthTable = functionTruthTable.GetLinesCount();
            _functionTruthTable = functionTruthTable;
            _zeroProbability = zeroProbability;
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
            for (int i = 0, mask = 1; i < _inputNumberOfDigits; i++, mask *= 2)
            {
                double bitTurnInProbability;
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
            _transformedTruthTable.Add(_functionTruthTable.GetIntResultByLineIndex(0), new List<int>());
            _transformedTruthTable.ElementAt(0).Value.Add(0);
            for (int i = 1; i < _amountOfLinesInTruthTable; i++)
            {
                int iResult = _functionTruthTable.GetIntResultByLineIndex(i);
                if (!_transformedTruthTable.ContainsKey(iResult))
                {
                    _transformedTruthTable.Add(iResult, new List<int>());
                }
                _transformedTruthTable[iResult].Add(i);
            }
        }
        private void CalculateCorrectResultProbablitiesArray()
        {
            _correctResultProbablitiesArray = new double[_amountOfLinesInTruthTable];
            for (int i = 0; i < _amountOfLinesInTruthTable; i++)
            {
                _correctResultProbablitiesArray[i] = 0.0;
                foreach (int j in _transformedTruthTable[_functionTruthTable.GetIntResultByLineIndex(i)])
                {
                    _correctResultProbablitiesArray[i] += _turnInProbabilityMatrix[i][j];
                }
                _correctResultProbablitiesArray[i] *= GetOperandAppearanceProbability(i);
            }
        }

        private double GetOperandAppearanceProbability(int inputOperand)
        {
            double p = 1;
            int bitMask = 1;
            for (int i = 0; i < _inputNumberOfDigits; ++i)
            {
                if((bitMask & inputOperand) == 0)
                {
                    p *= _zeroProbability[i];
                }
                else
                {
                    p *= (1 - _zeroProbability[i]);
                }
                bitMask = bitMask << 1;
            }
            return p;
        }
        private double CalculateCorrectResultProbability() // returns Correct Result Probability
                                                           // taking into account the auto-correction
        {
           // Потрібне теоретичне пояснення!!!
           // TODO: Визначити ймовірність правильної роботи функції на основі
           //       ймовірностей  правильної роботи для кожного окремого результату
           // double probability = 1.0;
           // for (int i = 0; i < _amountOfLinesInTruthTable; i++)
           // {
           //     probability *= _correctResultProbablitiesArray[i];
           // }
           // return probability;

            // функція повертає наижню границю ймовірності правильної роботи функції
            double minProbability = 1.0;
            double averageProbability = .0;
            for (int i = 0; i < _amountOfLinesInTruthTable; i++)
            {
                if(_correctResultProbablitiesArray[i] < minProbability)
                    minProbability = _correctResultProbablitiesArray[i];
                averageProbability += _correctResultProbablitiesArray[i];
            }
            //averageProbability /= _amountOfLinesInTruthTable;
            return averageProbability;// min_probability;
        }
        public double[] CalculateCorrectResultProbabilityArr() // returns Correct Result Probability
        //taking into account the auto-correction
        {
            // TODO: fuction refactoring, the next code consist from hotfixes
            // 1
            CalculateTurnInProbabilityMatrix();
            // 2
            CreateTransformedTruthTable();
            // 3
            CalculateCorrectResultProbablitiesArray();
            
            double min_probability = 1.0;
            //double average_probability = 0;
            for (int i = 0; i < _amountOfLinesInTruthTable; i++)
            {
                if (_correctResultProbablitiesArray[i] < min_probability)
                    min_probability = _correctResultProbablitiesArray[i];
                //average_probability += _correctResultProbablitiesArray[i];
            }
            //average_probability /= _amountOfLinesInTruthTable;
            return _correctResultProbablitiesArray;
        }
        /// <summary>
        /// Calculates probabilities of correct result for all
        /// possible output. Based on that values find probability
        /// of correct result for general case.
        /// Issues: Do not take into account input probabilities of One and Zero
        /// and works as they were equal. 
        /// </summary>
        /// <returns>Probability of correct result for logic network</returns>
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
