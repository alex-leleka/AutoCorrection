using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diplom_Work_Compare_Results_Probabilities;
namespace ProbabilitiesCalculatorTester
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class NoCorrectionTest
    {
        public NoCorrectionTest()
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
            //1 No corrextion
            double expected = 0.5;
            int digitsInput = 1, digitsOutput = 1;
            double[] distortionto1Probability = { 0.0 };
            double[] distortionto0Probability = { 0.0 };
            double[] distortiontoInverseProbability = { 0.5 };
            ProbabilitiesCalcNoCorrection prCalc = new ProbabilitiesCalcNoCorrection(distortionto0Probability,
                distortionto1Probability, distortiontoInverseProbability, digitsInput, digitsOutput);
            double actual = prCalc.GetCorrectResultProbability();
            Assert.AreEqual(expected, actual, 0.00001, "Elementary test Fail");
        }
        [TestMethod]
        public void ManyOperandsCheck()
        {
            //1 No corrextion
            double expected = 0.0625;
            int digitsInput = 4, digitsOutput = 1;
            double[] distortionto1Probability = { 0.0, 0.0, 0.0, 0.0 };
            double[] distortionto0Probability = { 0.0, 0.0, 0.0, 0.0 };
            double[] distortiontoInverseProbability = { 0.5, 0.5, 0.5, 0.5 };
            ProbabilitiesCalcNoCorrection prCalc = new ProbabilitiesCalcNoCorrection(distortionto0Probability,
                distortionto1Probability, distortiontoInverseProbability, digitsInput, digitsOutput);
            double actual = prCalc.GetCorrectResultProbability();
            Assert.AreEqual(expected, actual, 0.00001, "Fail for many operands");
        }
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
        }
    }
}
