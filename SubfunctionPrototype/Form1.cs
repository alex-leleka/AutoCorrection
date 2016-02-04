using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using Diplom_Work_Compare_Results_Probabilities;
using DotNetUtils;
using System.Windows.Forms;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;
using System.Linq.Expressions;

namespace SubfunctionPrototype
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int _FixedBitsCount = 2;

        private G4Probability CalculateFunctionDistortion(BooleanFuntionWithInputDistortion bf, InputDistortionProbabilities idp)
        {
            bf.LoadDistortionToBoolFunction(idp);
            var pCalc = new ProbabilitiesGxyCalc(bf, idp);
            const int binaryFunctionResultCount = 2;
            Gprobabilites[] prob = new Gprobabilites[binaryFunctionResultCount];
            for (int i = 0; i < binaryFunctionResultCount; i++)
            {
                prob[i] = pCalc.GetGprobabilitesResult(i.ToBinary(1));
            }
            return new G4Probability(prob);
        }

        private G4Probability[] GenerateSubfunctions(BooleanFuntionWithInputDistortion bf, InputDistortionProbabilities idp)
        {
            int newBitsCount = idp.ZeroProbability.Length - _FixedBitsCount;
            // generate new InputDistortionProbabilities
            var reducedIdp = GenerateReducedInpDistProbs(idp, newBitsCount);
            int subfunctionsCount = 1 << _FixedBitsCount;
            var reducedBfArr = new BooleanFuntionWithInputDistortion[subfunctionsCount];
            // Generate subfunctions
            for (int i = 0; i < subfunctionsCount; i++)
            {
                reducedBfArr[i] = GenerateReducedFunction(bf, newBitsCount, i);
            }
            // calculate sunfuncions autocorrection (G4 vector)
            G4Probability[] probs = new G4Probability[subfunctionsCount];
            for (int i = 0; i < subfunctionsCount; i++)
            {
                probs[i] = CalculateFunctionDistortion(reducedBfArr[i], reducedIdp);
            }
            return probs;

        }

        private BooleanFuntionWithInputDistortion GenerateReducedFunction(BooleanFuntionWithInputDistortion bf, int newBitsCount, int fixedOperand)
        {
            int fixedSize = bf.InputNumberOfDigits - fixedOperand;
            Func<BitArray, BitArray> boolFunction = inp => bf.GetResult(inp.Prepend(fixedOperand.ToBinary(fixedSize)));
            var subFunction = new BooleanFunctionDelegate(newBitsCount, bf.OutputNumberOfDigits, boolFunction);
            return subFunction;
        }

        private double[][] CalculateTurnInProbabilityMatrix(int fixedOperandSize, InputDistortionProbabilities idp)
        {
            int matrixSize = 1 << fixedOperandSize;
            int indexBase = idp.ZeroProbability.Length - fixedOperandSize;
            double[][] turnInProbabilityMatrix = new double[matrixSize][];
            for (int i = 0; i < matrixSize; i++)
            {
                turnInProbabilityMatrix[i] = new double[matrixSize];
                for (int j = 0; j < matrixSize; j++)
                {
                    turnInProbabilityMatrix[i][j] = CalculateTurnInProbability(j, i, idp, indexBase, idp.ZeroProbability.Length) * GetInputProbability(j, indexBase, idp);
                }
            }
            return turnInProbabilityMatrix;
        }

        private double GetInputProbability(int inputValue, int indexBase, InputDistortionProbabilities idp)
        {
            double p = 1.0;
            for (int i = indexBase; i < idp.ZeroProbability.Length; i++, inputValue = inputValue >> 1)
            {
                p *= idp.ProbabilityZeroAndOne(inputValue & 1, i);
            }
            return p;
        }

        private G4Probability[] CalculateAutoCorrForSubFuncModel(double[][] turnInProbabilityMatrix, G4Probability[] subfProbs)
        {
            // calculate the sum of values in rows
            double[] turnInPMRowSum = new double[turnInProbabilityMatrix.Length];
            for (int i = 0; i < turnInProbabilityMatrix.Length; i++)
                foreach (var p in turnInProbabilityMatrix[i])
                    turnInPMRowSum[i] += p;

            // multiply function by corresponding turnInPMRowSum element
            for (int i = 0; i < subfProbs.Length; i++)
            {
                subfProbs[i] = subfProbs[i] * turnInPMRowSum[i];
            }

            return subfProbs;
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
            for (int i = indexBase, mask = 1; i < indexBound; i++, mask *= 2)
            {
                double bitTurnInProbability;
                if ((mask & originalValue) != 0)
                {
                    if ((mask & corruptedValue) != 0) // 1 -> 1 /*(d)*/
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
                    if ((mask & corruptedValue) != 0) // 0 -> 1 /*(b)*/
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
            return operandTurnInProbability;
        }

        private InputDistortionProbabilities GenerateReducedInpDistProbs(InputDistortionProbabilities idp, int newBitsCount)
        {
            double[] distortionToZeroProbability = new double[newBitsCount];
            double[] distortionToOneProbability = new double[newBitsCount];
            double[] distortionToInverseProbability = new double[newBitsCount];
            double[] zeroProbability = new double[newBitsCount];
            for (int i = 0; i < newBitsCount; i++)
            {
                distortionToZeroProbability[i] = idp.DistortionToZeroProbability[i];
                distortionToOneProbability[i] = idp.DistortionToOneProbability[i];
                distortionToInverseProbability[i] = idp.DistortionToInverseProbability[i];
                zeroProbability[i] = idp.ZeroProbability[i];
            }
            var newIdp = new InputDistortionProbabilities(distortionToZeroProbability, distortionToOneProbability, 
                distortionToInverseProbability, zeroProbability);
            return newIdp;
        }

        private G4Probability GetAutoCorrForSubFuncModel(BooleanFuntionWithInputDistortion bf, InputDistortionProbabilities idp)
        {
            // divide functionction arguments into groups
            var gxIndexes = PartitionArgumentsIntoGroups(idp);
            GXProductsMatrix[] gxProductsMatrices = new GXProductsMatrix[gxIndexes.Length];

            for (int i = 0; i < gxIndexes.Length; ++i)
            {
                gxProductsMatrices[i] = GetReducedMatrix(bf, idp, gxIndexes[i]);
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
            do
            {
                // indexes that mean matrix real values
                indexesIterator.CopyTo(currentIndInts, 0);
                int bfReal = CalcBooleanFuntionResult(bf, currentIndInts, gxIndexes);
                // indexes that mean matrix expected values
                indexesIterator.CopyTo(currentIndInts, currentIndInts.Length);
                int bfExpected = CalcBooleanFuntionResult(bf, currentIndInts, gxIndexes);
                double fProduct = GetResultProbability(gxProductsMatrices, indexesIterator);
                g4Result.G[bfReal][bfExpected] += fProduct;
            } while (indexesIterator.Increment());


            return g4Result;
        }

        private int CalcBooleanFuntionResult(BooleanFuntionWithInputDistortion bf, int[] currentIndInts, GXIndex[] gxIndexes)
        {
            BitArray bfArgument = currentIndInts[0].ToBinary(gxIndexes[0].GetBitsCount());

            for (int i = 1; i < currentIndInts.Length; ++i)
            {
                bfArgument = bfArgument.Append(currentIndInts[i].ToBinary(gxIndexes[i].GetBitsCount()));
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
        private GXProductsMatrix GetReducedMatrix(BooleanFuntionWithInputDistortion bf, InputDistortionProbabilities idp, GXIndex gXIndex)
        {
            int rangeSize = 1 << gXIndex.GetBitsCount();
            // create turninprobability matrix
            // row - actual value, column - expected value
            var turnInProbMatrix = new GXProductsMatrix(rangeSize, rangeSize);
            for(int i = 0; i < rangeSize; ++i)
                for (int j = 0; j < rangeSize; ++j)
                {
                    double prob = CalculateTurnInProbability(i, j, idp, gXIndex.First, gXIndex.Last);
                    turnInProbMatrix.Set(j, i, prob);
                }

            var reduceMap = GetReduceMap(bf, gXIndex);
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

            return turnInProbMatrix;
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
            int newBfSize = 1 << (bf.InputNumberOfDigits - gXIndex.GetBitsCount());
            // we create new subfunction as truth table so it would be easy to compare them
            bool[] newBf = new bool[newBfSize];

            Func<BitArray, BitArray> boolFunction;
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
                newBf[argument] = boolFunction(argument.ToBinary(gXIndex.GetBitsCount()))[0];
            }

            return newBf;
        }

        private GXIndex[] PartitionArgumentsIntoGroups(InputDistortionProbabilities idp)
        {
            // we have no algotithm for this step yet
            // just divide by 2 and go further 
            // TODO: implement algorithm
            GXIndex[] partGxIndices = new GXIndex[2];
            int first = 0;
            int last = idp.GetInputDigitsCount() - 1;
            int mid = idp.GetInputDigitsCount() / 2 - 1;
            partGxIndices[0] = new GXIndex(first, mid);
            partGxIndices[1] = new GXIndex(mid + 1, last);
            return partGxIndices;
        }

        private BooleanFuntionWithInputDistortion GetBoolFunc()
        {
            // load the resource first time
            String[] functionText = new String[1];
            functionText[0] = @"x[0]&x[1]&x[2]&x[3]";
            int inputNumberOfDigits = 4;
            const int outputNumberOfDigits = 1; // Always one, input data format don't allow us anything else
            BooleanFuntionWithInputDistortion boolFunc = new BooleanFunctionAnalytic(inputNumberOfDigits,
                outputNumberOfDigits, functionText);
            return boolFunc;
        }

        private InputDistortionProbabilities GetInputDistortionProb()
        {
            String path = @"C:\Study\DiplomInput\InputDistortion4bit.txt";
            var reader = new DistortionProbTextReader(path);
            var idp = reader.GetDistortionProb();
            return idp;
            
        }

        private void StartRoutine(BooleanFuntionWithInputDistortion bf, InputDistortionProbabilities idp)
        {
            // calc original func dist
            var originalF = CalculateFunctionDistortion(bf, idp);
            // calc our model result
            var modelF = GetAutoCorrForSubFuncModel(bf, idp);

            string origResult;
            origResult = "G[0][0] " + originalF.G[0][0] + Environment.NewLine +
                "G[0][1] " + originalF.G[0][1] + Environment.NewLine +
                "G[1][0] " + originalF.G[1][0] + Environment.NewLine +
                "G[1][1] " + originalF.G[1][1] + Environment.NewLine;
            textBoxOriginal.Text = origResult;
            string modelResult;
            modelResult = "G[0][0] " + modelF.G[0][0] + Environment.NewLine +
                "G[0][1] " + modelF.G[0][1] + Environment.NewLine +
                "G[1][0] " + modelF.G[1][0] + Environment.NewLine +
                "G[1][1] " + modelF.G[1][1] + Environment.NewLine;
            textBoxModel.Text = modelResult;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bf = GetBoolFunc();
            var idp = GetInputDistortionProb();
            StartRoutine(bf, idp);
        }
    }
}
