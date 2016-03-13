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
                //reducedBfArr[i] = SubfunctionMethodDistortionCalc.GenerateReducedFunction(bf, newBitsCount, i);
            }
            // calculate sunfuncions autocorrection (G4 vector)
            G4Probability[] probs = new G4Probability[subfunctionsCount];
            for (int i = 0; i < subfunctionsCount; i++)
            {
                probs[i] = CalculateFunctionDistortion(reducedBfArr[i], reducedIdp);
            }
            return probs;

        }

        private double GetInputProbability(int inputValue, int indexBase, int indexBound, InputDistortionProbabilities idp)
        {
            double p = 1.0;
            for (int i = indexBase; i < indexBound; i++, inputValue = inputValue >> 1)
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

        private BooleanFuntionWithInputDistortion GetBoolFunc()
        {
            BooleanFuntionWithInputDistortion boolFuncD = new BooleanFunctionDelegate(5, 1, f16);
            return boolFuncD;
            // load the resource first time
            String[] functionText = new String[1];
            functionText[0] = @"x[5]|x[4]|x[0]|x[1]&x[2]&(x[3]^x[0])";
            int inputNumberOfDigits = 8;
            const int outputNumberOfDigits = 1; // Always one, input data format don't allow us anything else
            BooleanFuntionWithInputDistortion boolFunc = new BooleanFunctionAnalytic(inputNumberOfDigits,
                outputNumberOfDigits, functionText);
            return boolFunc;
        }

        public static BitArray f16(BitArray x)
        {
            BitArray result = new BitArray(1, false);
            bool r = false;
            for (int i = 0; i < 5; ++i)
                r |= x[i];
            result[0] = r;///*x[15] | (x[14] & x[13] )*/ x[12] | x[11] & x[0] | x[10] & x[9] | x[8] & x[7] | x[6] & x[5] | x[4] | x[0] | x[1] & x[2] & (x[3] ^ x[0]);
            return result;
        }

        private InputDistortionProbabilities GetInputDistortionProb()
        {
            String path = @"C:\Study\DiplomInput\InputDistortion5bit.txt";
            var reader = new DistortionProbTextReader(path);
            var idp = reader.GetDistortionProb();
            return idp;
            
        }

        private void StartRoutine(BooleanFuntionWithInputDistortion bf, InputDistortionProbabilities idp)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            // calc original func dist
            var originalF = new G4Probability();//CalculateFunctionDistortion(bf, idp);  // 
            stopwatch.Stop();
            var originalTime = stopwatch.ElapsedMilliseconds;
            // calc our model result
            // some preparations for test model:
            //***************************************************
            var pCalc = new SubfunctionMethodDistortionCalc(bf, idp);
            GXIndex[] gxIndexes;
            List<List<int>>[] reduceMaps;
            pCalc.GenerateIndicesAndRwduceMaps(out gxIndexes, out reduceMaps);
            //***************************************************
            stopwatch = Stopwatch.StartNew();
            var modelF = pCalc.GetAutoCorrForSubFuncModel(bf, idp, gxIndexes, reduceMaps);
            stopwatch.Stop();
            var modelTime = stopwatch.ElapsedMilliseconds;

            string origResult;
            origResult = "G[0][0] " + originalF.G[0][0] + Environment.NewLine +
                "G[0][1] " + originalF.G[0][1] + Environment.NewLine +
                "G[1][0] " + originalF.G[1][0] + Environment.NewLine +
                "G[1][1] " + originalF.G[1][1] + Environment.NewLine;
            textBoxOriginal.Text = origResult + Environment.NewLine + originalTime;
            string modelResult;
            modelResult = "G[0][0] " + modelF.G[0][0] + Environment.NewLine +
                "G[0][1] " + modelF.G[0][1] + Environment.NewLine +
                "G[1][0] " + modelF.G[1][0] + Environment.NewLine +
                "G[1][1] " + modelF.G[1][1] + Environment.NewLine;
            textBoxModel.Text = modelResult + Environment.NewLine + modelTime;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bf = GetBoolFunc();
            var idp = GetInputDistortionProb();
            StartRoutine(bf, idp);
        }
    }
}
