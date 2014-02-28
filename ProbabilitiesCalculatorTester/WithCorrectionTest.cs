using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diplom_Work_Compare_Results_Probabilities;

namespace ProbabilitiesCalculatorTester
{
    /// <summary>
    /// Summary description for WithCorrectionTests
    /// </summary>
    [TestClass]
    public class WithCorrectionTest
    {
        public WithCorrectionTest()
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
        public void ElementaryTest()
        {
            //1 No corrextion
            double expected = 0.5;
            int digitsInput = 1, digitsOutput = 1;
            double[] distortionto1Probability = { 0.0 };
            double[] distortionto0Probability = { 0.0 };
            double[] distortiontoInverseProbability = { 0.5 };
            int linesInTruthTable = 2;
            int[] truthTable = { 0, 1 };
            ProbabilitiesCalcWithCorrection prCalc = new ProbabilitiesCalcWithCorrection(distortionto0Probability,
                distortionto1Probability, distortiontoInverseProbability, digitsInput, digitsOutput,
                truthTable, linesInTruthTable);
            double actual = prCalc.GetCorrectResultProbability();
            Assert.AreEqual(expected, actual, 0.00001, "Elementary test Fail");
        }
        [TestMethod]
        public void ManyOperandsSingleResultDigitCheck()
        {
            //1 No corrextion
            double expected = 0.5;
            int digitsInput = 3, digitsOutput = 1;
            double[] distortionto1Probability = { 0.0, 0.0, 0.0};
            double[] distortionto0Probability = { 0.0, 0.0, 0.0};
            double[] distortiontoInverseProbability = { 0.5, 0.5, 0.5};
            int linesInTruthTable = 8;
            int[] truthTable = { 0, 1, 0, 1, 0, 1, 0, 1 };
            ProbabilitiesCalcWithCorrection prCalc = new ProbabilitiesCalcWithCorrection(distortionto0Probability,
                distortionto1Probability, distortiontoInverseProbability, digitsInput, digitsOutput,
                truthTable, linesInTruthTable);
            double actual = prCalc.GetCorrectResultProbability();
            Assert.AreEqual(expected, actual, 0.00001, "Fail for many operands");
        }
        [TestMethod]
        public void VariousProbabilitiesCheck()
        {
            //1 No corrextion
            double expected = 0.015;
            int digitsInput = 2, digitsOutput = 2;
            double[] distortionto1Probability = { 0.1, 0.0 };
            double[] distortionto0Probability = { 0.3, 0.1 };
            double[] distortiontoInverseProbability = { 0.3, 0.5 };
            int linesInTruthTable = 4;
            int[] truthTable = { 0, 1, 2, 3 };
            ProbabilitiesCalcWithCorrection prCalc = new ProbabilitiesCalcWithCorrection(distortionto0Probability,
                distortionto1Probability, distortiontoInverseProbability, digitsInput, digitsOutput,
                truthTable, linesInTruthTable);
            double actual = prCalc.GetCorrectResultProbability();
            Assert.AreEqual(expected, actual, 0.00001, "Fail in class logic");
        }
    }
}
