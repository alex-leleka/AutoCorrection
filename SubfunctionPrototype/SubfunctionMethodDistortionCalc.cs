using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Diplom_Work_Compare_Results_Probabilities;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;
using DotNetUtils;

namespace SubfunctionPrototype
{
    public class SubfunctionMethodDistortionCalc
    {
        private BooleanFuntionWithInputDistortion _bf;
        private IinputDistortionProbabilities _idp;
        public SubfunctionMethodDistortionCalc(BooleanFuntionWithInputDistortion bf, IinputDistortionProbabilities idp)
        {
            _bf = bf;
            _idp = idp;
        }

        private BooleanFuntionWithInputDistortion GenerateReducedFunction(BooleanFuntionWithInputDistortion bf, int newBitsCount, int fixedOperand)
        {
            int fixedSize = bf.InputNumberOfDigits - fixedOperand;
            Func<BitArray, BitArray> boolFunction = inp => bf.GetResult(inp.Prepend(fixedOperand.ToBinary(fixedSize)));
            var subFunction = new BooleanFunctionDelegate(newBitsCount, bf.OutputNumberOfDigits, boolFunction);
            return subFunction;
        }

        /// <summary>
        /// Returns probability of turning originalValue to corruptedValue based on idp distortion probabilities.
        /// </summary>
        /// <param name="originalValue"></param>
        /// <param name="corruptedValue"></param>
        /// <param name="idp"></param>
        /// <param name="indexBase"></param>
        /// <param name="indexBound"></param>
        /// <returns></returns>
        private double CalculateTurnInProbability(int originalValue, int corruptedValue, InputDistortionProbabilities idp, int indexBase, int indexBound) 
        {
            double operandTurnInProbability = 1.0;
            double inputProbability = 1.0; 
            for (int i = indexBase; i < indexBound; i++, originalValue >>= 1, corruptedValue >>= 1)
            {
                inputProbability *= idp.ProbabilityZeroAndOne(originalValue & 1, i);
                double bitTurnInProbability;
                if ((1 & originalValue) != 0)
                {
                    if ((1 & corruptedValue) != 0) // 1 -> 1 /*(d)*/
                    {
                        bitTurnInProbability = idp.DistortionToOneProbability[i] + idp.CorrectValueProbability[i];
                    }
                    else // 1 -> 0 /*(c)*/
                    {
                        bitTurnInProbability = idp.DistortionToZeroProbability[i] + idp.DistortionToInverseProbability[i];
                    }
                }
                else
                {
                    if ((1 & corruptedValue) != 0) // 0 -> 1 /*(b)*/
                    {
                        bitTurnInProbability = idp.DistortionToOneProbability[i] + idp.DistortionToInverseProbability[i];
                    }
                    else // 0 -> 0 /*(a)*/
                    {
                        bitTurnInProbability = idp.DistortionToZeroProbability[i] + idp.CorrectValueProbability[i];
                    }
                }
                operandTurnInProbability *= bitTurnInProbability;
            }
            return operandTurnInProbability * inputProbability;
        }

        /// <summary>
        /// Returns probability of turning originalValue to corruptedValue based on idp distortion probabilities.
        /// </summary>
        /// <param name="originalValue"></param>
        /// <param name="corruptedValue"></param>
        /// <param name="idp">InputDistortionG4</param>
        /// <param name="indexBase"></param>
        /// <param name="indexBound"></param>
        /// <returns></returns>
        private double CalculateTurnInProbability(int originalValue, int corruptedValue, InputDistortionG4 idp, int indexBase, int indexBound)
        {
            double operandTurnInProbability = 1.0;
            int inputBitsCount = idp.GetInputDigitsCount();
            for (int i = indexBase; i < indexBound; i++, originalValue >>= 1, corruptedValue >>= 1)
            {
                int dist = 1 & corruptedValue;
                int orig = 1 & originalValue;
                operandTurnInProbability *= idp.GetInputProbability(i).G[dist][orig];
            }
            return operandTurnInProbability;
        }

        public G4Probability GetCorrectResultProbability()
        {
            // some preparations for test model:
            //***************************************************
            GXIndex[] gxIndexes;
            List<List<int>>[] reduceMaps;
            GenerateIndicesAndRwduceMaps(out gxIndexes, out reduceMaps);
            //***************************************************
            Stopwatch stopwatch = Stopwatch.StartNew(); // timing

            var modelF = GetAutoCorrForSubFuncModel(_bf, _idp, gxIndexes, reduceMaps);

            stopwatch.Stop(); // timing
            var originalTime = stopwatch.ElapsedMilliseconds;
            bool oldLoggerOn = true;
            if (!Logger.Init())
            {
                Logger.ResetLogger(true);
                oldLoggerOn = false;
            }
            Logger.WriteLine("Execution time (subfunction): " + originalTime + "\n time" + DateTime.Now );
            Logger.ResetLogger(oldLoggerOn); // timing

            return modelF;
        }

        internal void GenerateIndicesAndRwduceMaps(out GXIndex[] gxIndexes, out List<List<int>>[] reduceMaps)
        {
// divide functionction arguments into groups
            gxIndexes = PartitionArgumentsIntoGroups(_idp.GetInputDigitsCount());
            // create reduce map based on matching functions
            reduceMaps = new List<List<int>>[gxIndexes.Length];
            for (int i = 0; i < gxIndexes.Length; ++i)
            {
                reduceMaps[i] = GetReduceMap(_bf, gxIndexes[i]);
            }

            const bool logSubfunctionsCount = true;
            if (logSubfunctionsCount)
            {
                bool oldLoggerOn = true;
                if (!Logger.Init())
                {
                    Logger.ResetLogger(true);
                    oldLoggerOn = false;
                }

                foreach (var reduceMap in reduceMaps)
                {
                    Logger.WriteLine("logSubfunctionsCount = " + reduceMap.Count);
                }
                Logger.WriteLine("------------");
                Logger.ResetLogger(oldLoggerOn);
            }
        }

        internal G4Probability GetAutoCorrForSubFuncModel(BooleanFuntionWithInputDistortion bf, IinputDistortionProbabilities idp, GXIndex[] gxIndexes, List<List<int>>[] reduceMaps)
        {
            GXProductsMatrix[] gxProductsMatrices = new GXProductsMatrix[gxIndexes.Length];

            for (int i = 0; i < gxIndexes.Length; ++i)
            {
                gxProductsMatrices[i] = GetReducedMatrix(bf, idp, gxIndexes[i], reduceMaps[i]);
            }

            // create indexes bounds
            int[] gxProductsMatricesIndexesInts = new int[gxProductsMatrices.Length * 2];
            // matrix has two dimesions, so we create pair of indexes per matrix
            for (int i = 0; i < gxProductsMatrices.Length; ++i)
            {
                gxProductsMatricesIndexesInts[i] = gxProductsMatrices[i].GetRowsCount();
                gxProductsMatricesIndexesInts[i + gxProductsMatrices.Length] = gxProductsMatrices[i].GetColumnsCount();
            }

            // first half of indexes for a bfReal and next for a bfExpected
            var indexesIterator = new GxIndexesCombination(gxProductsMatricesIndexesInts);
            /* TODO: check does we cover all cases: statements "matrix has two dimesions" and "first half of indexes for a bfReal and next for a bfExpected" are mutually exclusive.
            */

            // instead of creating final table from simplified TurnInProbabilityMatrices
            // we gonna iterate all possible inputs and add product value to g4result.G[f_real][f_expected]
            G4Probability g4Result = new G4Probability();
            int[] currentIndInts = new int[gxProductsMatrices.Length];
            for(int i = 0; i < gxProductsMatrices.Length; ++i)
                gxProductsMatrices[i].ConvertDictionatyToArray();

            do
            {
                // indexes that mean matrix real values
                indexesIterator.CopyTo(currentIndInts, 0);
                int bfReal = CalcBooleanFuntionResult(bf, currentIndInts, gxIndexes, gxProductsMatrices, true);
                // indexes that mean matrix expected values
                indexesIterator.CopyTo(currentIndInts, currentIndInts.Length);
                int bfExpected = CalcBooleanFuntionResult(bf, currentIndInts, gxIndexes, gxProductsMatrices, false);
                double fProduct = GetResultProbability(gxProductsMatrices, indexesIterator);
                g4Result.G[bfReal][bfExpected] += fProduct;
            } while (indexesIterator.Increment());


            return g4Result;
        }

        private static int GetFunctionInputFromGxProductsMatrices(GXProductsMatrix[] gxProductsMatrices, bool byRow, int matrixIndex, int index)
        {
            return byRow ? gxProductsMatrices[matrixIndex].GetRowKeyByIndex(index) : gxProductsMatrices[matrixIndex].GetColumnKeyByIndex(index);
        }

        private int CalcBooleanFuntionResult(BooleanFuntionWithInputDistortion bf, int[] currentIndInts, GXIndex[] gxIndexes, GXProductsMatrix[] gxProductsMatrices, bool byRow)
        {
            int argument = GetFunctionInputFromGxProductsMatrices(gxProductsMatrices, byRow, 0, currentIndInts[0]);
            BitArray bfArgument = argument.ToBinary(gxIndexes[0].GetBitsCount());

            for (int i = 1; i < currentIndInts.Length; ++i)
            {
                argument = GetFunctionInputFromGxProductsMatrices(gxProductsMatrices, byRow, i, currentIndInts[i]);
                bfArgument = bfArgument.Append(argument.ToBinary(gxIndexes[i].GetBitsCount()));
            }
            int result = bf.GetIntResult(bfArgument);
            return result;
        }

        private double GetResultProbability(GXProductsMatrix[] gxProductsMatrices, GxIndexesCombination indexesIterator)
        {
            double product = 1;
            for (int i = 0; i < gxProductsMatrices.Length; ++i)
            {
                product *= gxProductsMatrices[i].Get(indexesIterator.GetIndexOf(i) /*actual*/,
                    indexesIterator.GetIndexOf(i + gxProductsMatrices.Length) /*expected*/);
            }
            return product;
        }

        /// <summary>
        /// row - actual value, column - expected value
        /// </summary>
        /// <param name="bf"></param>
        /// <param name="idp"></param>
        /// <param name="gXIndex"></param>
        /// <returns></returns>
        private GXProductsMatrix GetReducedMatrix(BooleanFuntionWithInputDistortion bf, IinputDistortionProbabilities idp, GXIndex gXIndex, List<List<int>> reduceMap)
        {
            int rangeSize = 1 << gXIndex.GetBitsCount();
            // create turninprobability matrix
            // row - actual value, column - expected value
            var turnInProbMatrix = new GXProductsMatrix(rangeSize, rangeSize);
            for(int i = 0; i < rangeSize; ++i)
                for (int j = 0; j < rangeSize; ++j)
                {
                    double prob = 0;
                    
                    var inpDist = idp as InputDistortionProbabilities;
                    if (inpDist != null)
                    {
                        prob = CalculateTurnInProbability(i, j, inpDist, gXIndex.First, gXIndex.Last + 1);
                    }
                    var inpDistG4 = idp as InputDistortionG4;
                    if (inpDistG4 != null)
                    {
                        prob = CalculateTurnInProbability(i, j, inpDistG4, gXIndex.First, gXIndex.Last + 1);
                    }

                    turnInProbMatrix.Set(j, i, prob);
                }
            //Debug step
            //TestGxProductsMatrix(turnInProbMatrix);

            //var reduceMap = GetReduceMap(bf, gXIndex);
            //for each matrix simplify matrix by adding rows and colums of matching subfunctions
            foreach (var matchingFunctionsClass in reduceMap)
            {
                if (matchingFunctionsClass.Count < 2) continue; // if there less than 2 functions we couldn't reduce
                int firtstIndexInMatchingFuncClass = matchingFunctionsClass[0];
                for (int i = 1; i < matchingFunctionsClass.Count; ++i)
                    turnInProbMatrix.AddRow(firtstIndexInMatchingFuncClass, matchingFunctionsClass[i]);
                for (int i = 1; i < matchingFunctionsClass.Count; ++i)
                    turnInProbMatrix.AddColumn(firtstIndexInMatchingFuncClass, matchingFunctionsClass[i]);
            }
            //Debug step
            //TestGxProductsMatrix(turnInProbMatrix);
            return turnInProbMatrix;
        }

        private static void TestGxProductsMatrix(GXProductsMatrix turnInProbMatrix)
        {
#if DEBUG
            // test sum of all matrix elements to be 1
            double sum = 0.0;
            double eps = 0.0001;
            foreach (var rowKey in turnInProbMatrix.GetRowsKeys())
            {
                foreach (var columnKey in turnInProbMatrix.GetColumsKeys(rowKey))
                {
                    sum += turnInProbMatrix.GetByKey(rowKey, columnKey);
                }
            }
            if (sum - eps > 1.0 || sum + eps < 1.0)
                throw new Exception("GXProductsMatrix is bad.");
#endif
        }

        /// <summary>
        /// Reduce map (vetor of vetors) has next structure:
        /// v[i][j] - where v - vector of vectors, i - index of matching functions class (means nothing),
        /// j - index of fuction in set of mathing functions. Index j is the same as corresponding row and column index
        /// in turninprobability matrix.
        /// </summary>
        /// <param name="bf"></param>
        /// <param name="gXIndex"></param>
        /// <returns></returns>
        private List<List<int>> GetReduceMap(BooleanFuntionWithInputDistortion bf, GXIndex gXIndex)
        {
            // Create vector of function with class index. Initial value of class index is function index in vector.
            // For every functions in vector if its class index == index in vector go through all other functions in vector and
            // if its class index == index in vector check if they are matching and if yes set other functions class index to class 
            // index of current function.
            int subfunctionsCount = 1 << gXIndex.GetBitsCount();
            List<SubfunctionWithIndex> subfunctionWithIndices = new List<SubfunctionWithIndex>(subfunctionsCount);

            for (int i = 0; i < subfunctionsCount; ++i)
            {
                var subfunc = CreateSubfunction(bf, gXIndex, i);
                subfunctionWithIndices.Add(new SubfunctionWithIndex(subfunc, i));
            }

            for (int i = 0; i < subfunctionsCount; ++i)
            {
                if (subfunctionWithIndices[i].GetIndex() != i) continue; // function already has its class, skip it
                for (int otherIndex = i + 1; otherIndex < subfunctionsCount; ++otherIndex)
                {
                    if (subfunctionWithIndices[otherIndex].GetIndex() != otherIndex) continue; // function already has its class, skip it
                    subfunctionWithIndices[i].Compare(subfunctionWithIndices[otherIndex]);
                }
            }

            List < List < int >> reduceMap = new List<List<int>>(subfunctionsCount);
            for (int i = 0; i < subfunctionsCount; ++i)
                reduceMap.Add(new List<int>());

            for (int i = 0; i < reduceMap.Count; ++i)
            {
                int index = subfunctionWithIndices[i].GetIndex();
                reduceMap[index].Add(i);
            }

            // remove empty lists from reduceMap
            for (int i = 0; i < reduceMap.Count; ++i)
            {
                if (reduceMap[i].Count == 0)
                {
                    reduceMap.RemoveAt(i);
                    --i;
                }
            }

            return reduceMap;
        }

        private bool[] CreateSubfunction(BooleanFuntionWithInputDistortion bf, GXIndex gXIndex, int i)
        {
            int newBfArgBitsCount = bf.InputNumberOfDigits - gXIndex.GetBitsCount();
            int newBfSize = 1 << newBfArgBitsCount;
            // we create new subfunction as truth table so it would be easy to compare them
            bool[] newBf = new bool[newBfSize];

            Func<BitArray, BitArray> boolFunction;

            if (newBfArgBitsCount == 0) // handle calculation without partition
            {
                newBf[0] = false;
                return newBf;
            }
                if (gXIndex.First == 0)
            {
                boolFunction = inp => bf.GetResult(inp.Prepend(i.ToBinary(gXIndex.GetBitsCount())));
            }
            else if (gXIndex.Last == bf.InputNumberOfDigits - 1)
            {
                boolFunction = inp => bf.GetResult(inp.Append(i.ToBinary(gXIndex.GetBitsCount())));
            }
            else
            {
                boolFunction = inp => bf.GetResult(inp.Insert(gXIndex.First, gXIndex.Last, i.ToBinary(gXIndex.GetBitsCount())));
            }

            for (int argument = 0; argument < newBf.Length; ++argument)
            {
                newBf[argument] = boolFunction(argument.ToBinary(newBfArgBitsCount))[0];
            }

            return newBf;
        }

        private GXIndex[] PartitionArgumentsIntoGroups(int inputDigitsCount)
        {
            // temp wothout patition
            GXIndex[] partGxIndicest = new GXIndex[1];
            int firstt = 0;
            int lastt = inputDigitsCount - 1;
            partGxIndicest[0] = new GXIndex(firstt, lastt);
            return partGxIndicest;
            //*/
            if ((inputDigitsCount % 3 == 0) && false)
            {
                // if we could create 3 groups, lets do it
                const int N = 3;
                int numberInGroup = inputDigitsCount / N;
                GXIndex[] partGxIndices3 = new GXIndex[N];
                for (int i = 0, first3 = 0, last3 = numberInGroup; i < N; i++, first3 = last3, last3 += numberInGroup)
                {
                    partGxIndices3[i] = new GXIndex(first3, last3 - 1);
                }
                return partGxIndices3;
            }
            // we have no algotithm for this step yet
            // just divide by 2 and go further 
            // TODO: implement algorithm
            GXIndex[] partGxIndices = new GXIndex[2];
            int first = 0;
            int last = inputDigitsCount - 1;
            int mid = inputDigitsCount / 2 - 1;
            partGxIndices[0] = new GXIndex(first, mid);
            partGxIndices[1] = new GXIndex(mid + 1, last);
            return partGxIndices;
        }
    }
}