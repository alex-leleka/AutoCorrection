﻿using System;
using System.Diagnostics;
using System.Collections;
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
            int fixedSize = bf.Length - fixedOperand;
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
                    turnInProbabilityMatrix[i][j] = CalculateTurnInProbability(j, i, idp, indexBase) * GetInputProbability(j, indexBase, idp);
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

        private double CalculateTurnInProbability(int originalValue, int corruptedValue, InputDistortionProbabilities idp, int indexBase) // i turn in j, but not vice versa
        {
            double operandTurnInProbability = 1.0;
            for (int i = indexBase, mask = 1; i < idp.DistortionToOneProbability.Length; i++, mask *= 2)
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
            //double[][] turnInProbabilityMatrix = CalculateTurnInProbabilityMatrix(_FixedBitsCount, idp);
            //G4Probability[] subfProbs = GenerateSubfunctions(bf, idp);
            //var multipliedF = CalculateAutoCorrForSubFuncModel(turnInProbabilityMatrix, subfProbs);

            // 1) divide functionction arguments into groups
            // 1) a. create all subfunctions for every group
            // 2) b. find matching subfunctions inside each group
            // 2) for each group of arguments CalculateTurnInProbabilityMatrix
            // 3) for each matrix simplify matrix by adding rows and colums of matching subfunctions
            // 4) create final table from simplified TurnInProbabilityMatrices
            // 5) for each row in final table add product value to g4result.G[f_real][f_expected]

            // TODO: implement

            GXIndexes GXIndexes[] = PartitionArgumentsIntoGroups();

            for(int i = 0; i < GXIndexes.count; ++i)
            {

            }


            G4Probability g4result = new G4Probability();
            // calculate g4result value (expect to get originalF value)
            for (int i = 0; i < multipliedF.Length; i++)
            {
                g4result = g4result + multipliedF[i];
            }
            return g4result;
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
