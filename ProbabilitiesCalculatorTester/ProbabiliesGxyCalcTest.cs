using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diplom_Work_Compare_Results_Probabilities;
using Diplom_Work_Compare_Results_Probabilities.TruthTable;
using System.Collections;
namespace ProbabilitiesCalculatorTester
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ProbabiliesGxyCalcTest
    {
        public ProbabiliesGxyCalcTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ElementaryLogicCheck()
        {
            double expected_G0 = 0.5;
            double expected_Gc = 0.0, expected_Gce = 0.0;
            double expected_Gee = 0.25;
            int digitsInput = 1, digitsOutput = 1;
            double[] distortionto1Probability = { 0.0 };
            double[] distortionto0Probability = { 0.0 };
            double[] distortiontoInverseProbability = { 0.5 };
            double[] zeroProbability = { 0.5 };
            string[] func = new string[1];
            func[0] = "x[0]";
            var f = new BooleanFunctionAnalytic(digitsInput, digitsOutput,func);
            f.SetDistortionProbabilitiesVectors(distortionto0Probability, distortionto1Probability, distortiontoInverseProbability);
            ProbabilitiesGxyCalc pGxy = new ProbabilitiesGxyCalc(f, zeroProbability);
            var actual = pGxy.GetGprobabilitesResult(new BitArray(1, true));
            Assert.AreEqual(expected_G0, actual.G0, 0.00001, "Elementary test Fail G0");
            Assert.AreEqual(expected_Gc, actual.Gc, 0.00001, "Elementary test Fail Gc");
            Assert.AreEqual(expected_Gce, actual.Gce, 0.00001, "Elementary test Fail Gce");
            Assert.AreEqual(expected_Gee, actual.Gee, 0.00001, "Elementary test Fail Gee");
        }
        [TestMethod]
        public void Base3Check()
        {
            int digitsInput = 1, digitsOutput = 1;
            double[] distortionto1Probability = { 0.0 };
            double[] distortionto0Probability = { 0.0 };
            double[] distortiontoInverseProbability = { 0.5 };
            double[] zeroProbability = { 0.5 };
            string[] func = new string[1];
            func[0] = "x[0]";
            var f = new BooleanFunctionAnalytic(digitsInput, digitsOutput, func);
            f.SetDistortionProbabilitiesVectors(distortionto0Probability, distortionto1Probability, distortiontoInverseProbability);
            ProbabilitiesGxyCalc pGxy = new ProbabilitiesGxyCalc(f, zeroProbability);
            var a1 = pGxy.Base3(0, 3);
            int[] exp1 = new int[3];
            for (int i = 0; i < exp1.Length; i++)
            {
                Assert.AreEqual(exp1[i], a1[i], "Base3 test Fail");
            }
            var a2 = pGxy.Base3(4, 3);
            int[] exp2 = new int[3];
            exp2[1] = exp2[0] = 1;
            for (int i = 0; i < exp2.Length; i++)
            {
                Assert.AreEqual(exp2[i], a2[i], "Base3 test Fail");
            }
            const int size = 20;
            var a3 = pGxy.Base3(3456345, size);
            int[] exp3 = new int[size];
            exp3[13 - 0] = 2;
                exp3[13 - 1] = 0;
                exp3[13 - 2] =
                exp3[13 - 3] =
                exp3[13 - 4] =
                exp3[13 - 5] = 1;
                exp3[13 - 6] = 2;
                exp3[13 - 7] = 1;
                exp3[13 - 8] = 0;
                exp3[13 - 9] = 1;
                exp3[13 - 10] =
                exp3[13 - 11] = 2;
            exp3[13 - 12] = 1;
            exp3[13 - 13] = 0;
            for (int i = 0; i < exp3.Length; i++)
            {
                Assert.AreEqual(exp3[i], a3[i], "Base3 test Fail with index " + i);
            }
        }

        [TestMethod]
        public void ManyOperandsCheck()
        {
            int digitsInput = 4, digitsOutput = 1;
            double[] distortionto1Probability = { 0.0, 0.0, 0.0, 0.0 };
            double[] distortionto0Probability = { 0.0, 0.0, 0.0, 0.0 };
            double[] distortiontoInverseProbability = { 0.5, 0.5, 0.5, 0.5 };
            double expected_G0 = 0.0625;
            double expected_Gc = 0.0, expected_Gce = 0.0;
            double expected_Gee = 0.25;
            double[] zeroProbability = { 0.5, 0.5, 0.5, 0.5 };
            string[] func = new string[1];
            func[0] = "(x[0] ^ x[1]) ^ (x[2] ^ x[3])";
            var f = new BooleanFunctionAnalytic(digitsInput, digitsOutput, func);
            f.SetDistortionProbabilitiesVectors(distortionto0Probability, distortionto1Probability, distortiontoInverseProbability);
            ProbabilitiesGxyCalc pGxy = new ProbabilitiesGxyCalc(f, zeroProbability);
            var actual1 = pGxy.GetGprobabilitesResult(new BitArray(digitsOutput, true));
            var actual0 = pGxy.GetGprobabilitesResult(new BitArray(digitsOutput, false));
            Assert.AreEqual(expected_G0, actual1.G0, 0.00001, "Fail for many operands G0");
            Assert.AreEqual(expected_Gc, actual1.Gc, 0.00001, "Fail for many operands Gc");
            //Assert.AreEqual(expected_Gce, actual.Gce, 0.00001, "Fail for many operands Gce");
            Assert.AreEqual(expected_Gee, actual1.Gee, 0.00001, "Fail for many operands Gee");
            Assert.AreEqual(actual1.G0 + actual1.Gc + actual1.Gce + actual1.Gee
                + actual0.Gc + actual0.Gce + actual0.Gee, 1.0, 0.001, "Fail sum of probabilities"); 
        }
        [TestMethod]
        public void AutoCorrectionCalcCheck()
        {
            int digitsInput = 4, digitsOutput = 1;
            double[] distortionto1Probability = { 0.1, 0.03, 0.1, 0.04 };
            double[] distortionto0Probability = { 0.09, 0.01, 0.02, 0.03 };
            double[] distortiontoInverseProbability = { 0.1, 0.05, 0.04, 0.08 };
            double[] zeroProbability = { 0.5, 0.5, 0.5, 0.5 };
            string[] func = new string[1];
            func[0] = "(x[0]) & (x[2] | x[3])";
            var f = new BooleanFunctionAnalytic(digitsInput, digitsOutput, func);
            f.SetDistortionProbabilitiesVectors(distortionto0Probability, distortionto1Probability, distortiontoInverseProbability);
            ProbabilitiesGxyCalc pGxy = new ProbabilitiesGxyCalc(f, zeroProbability);
            var actual1 = pGxy.GetGprobabilitesResult(new BitArray(digitsOutput, true));
            var actual0 = pGxy.GetGprobabilitesResult(new BitArray(digitsOutput, false));
            Assert.AreEqual(actual1.G0 + actual1.Gc + actual1.Gce + actual1.Gee
                + actual0.Gc + actual0.Gce + actual0.Gee, 1.0, 0.001, "Fail sum of probabilities");
        }/*
        [TestMethod]
        public void VariousProbabilitiesCheck()
        {
            //1 No corrextion
            double expected = 0.015;
            int digitsInput = 4, digitsOutput = 1;
            double[] distortionto1Probability =       { 0.25, 0.0, 0.1, 0.0 };
            double[] distortionto0Probability =       { 0.25, 0.0, 0.3, 0.1 };
            double[] distortiontoInverseProbability = { 0.25, 0.5, 0.3, 0.5 };
            ProbabilitiesCalcNoCorrection prCalc = new ProbabilitiesCalcNoCorrection(distortionto0Probability,
                distortionto1Probability, distortiontoInverseProbability, digitsInput, digitsOutput);
            double actual = prCalc.GetCorrectResultProbability();
            Assert.AreEqual(expected, actual, 0.00001, "Fail in class logic");
        }*/
    }
}
