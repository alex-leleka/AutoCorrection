using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubfunctionPrototype;

namespace ProbabilitiesCalculatorTester
{
    [TestClass]
    public class GxIndexesCombinationTest
    {
        private TestContext testContextInstance;

        [TestMethod]
        public void TestDimentions()
        {
            int[] bounds = new[] {1, 1};
            GxIndexesCombination gxIC = new GxIndexesCombination(bounds);
            int expected = bounds.Length;
            int actual = gxIC.GetDimentions();
            Assert.AreEqual(expected, actual, 0.00001, "Dimentions number is wrong.");
        }

        [TestMethod]
        public void TestInitialValues()
        {
            int[] bounds = new[] {1, 1};
            GxIndexesCombination gxIC = new GxIndexesCombination(bounds);
            for (int i = 0; i < gxIC.GetDimentions(); ++i)
            {
                int expected = 0;
                int actual = gxIC.GetIndexOf(i);
                Assert.AreEqual(expected, actual, 0.00001, "Initial value is not zero");
            }
        }

        [TestMethod]
        public void TestIncrementCondition()
        {
            int[] bounds = new[] { 2, 2 };
            GxIndexesCombination gxIC = new GxIndexesCombination(bounds);
            bool expectedBool = true;
            bool actualIsIncremented;
            actualIsIncremented = gxIC.Increment();
            Assert.AreEqual(expectedBool, actualIsIncremented, "Increment #1 failed");
            actualIsIncremented = gxIC.Increment();
            Assert.AreEqual(expectedBool, actualIsIncremented, "Increment #2 failed");
            actualIsIncremented = gxIC.Increment();
            Assert.AreEqual(expectedBool, actualIsIncremented, "Increment #3 failed");
            actualIsIncremented = gxIC.Increment();
            expectedBool = false;
            Assert.AreEqual(expectedBool, actualIsIncremented, "We should stop increment this time. Increment #4 failed");
            actualIsIncremented = gxIC.Increment();
            expectedBool = false;
            Assert.AreEqual(expectedBool, actualIsIncremented, "Increment #5 failed.");
        }

        private void CopyIndexesToArray(ref int[] actualIncremented, GxIndexesCombination gxIC)
        {
            for (int i = 0; i < gxIC.GetDimentions(); ++i)
            {
                actualIncremented[i] = gxIC.GetIndexOf(i);
            }
        }

        [TestMethod]
        public void TestIncrementValue1()
        {
            int[] bounds = new[] { 2, 2 };
            GxIndexesCombination gxIC = new GxIndexesCombination(bounds);
            int[] expectedIndxs = new int[] {0,0};
            int[] actualIncremented = new int[] { 0, 0 };
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(actualIncremented, actualIncremented, "Increment #1 failed");
            gxIC.Increment();
            expectedIndxs[0] = 1;
            expectedIndxs[1] = 0;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(actualIncremented, actualIncremented, "Increment #2 failed");
            gxIC.Increment();
            expectedIndxs[0] = 0;
            expectedIndxs[1] = 1;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(actualIncremented, actualIncremented, "Increment #3 failed");
            gxIC.Increment();
            expectedIndxs[0] = 1;
            expectedIndxs[1] = 1;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(actualIncremented, actualIncremented, "Increment #4 failed");
            gxIC.Increment();
            expectedIndxs[0] = 1;
            expectedIndxs[1] = 1;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(expectedIndxs, actualIncremented, "Increment #5 failed. Indexes:" 
                + actualIncremented[0] + " " + +actualIncremented[1]);
        }

        [TestMethod]
        public void TestIncrementValue2()
        {
            int[] bounds = new[] { 3, 3, 2 };
            GxIndexesCombination gxIC = new GxIndexesCombination(bounds);
            int[] expectedIndxs = new int[] { 0, 0, 0 };
            int[] actualIncremented = new int[] { 0, 0, 0 };
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(actualIncremented, actualIncremented, "Increment #1 failed");
            gxIC.Increment();
            expectedIndxs[0] = 1;
            expectedIndxs[1] = 0;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(actualIncremented, actualIncremented, "Increment #2 failed");
            gxIC.Increment();
            expectedIndxs[0] = 2;
            expectedIndxs[1] = 0;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(actualIncremented, actualIncremented, "Increment #3 failed");
            gxIC.Increment();
            expectedIndxs[0] = 0;
            expectedIndxs[1] = 1;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(actualIncremented, actualIncremented, "Increment #4 failed");
            gxIC.Increment();
            expectedIndxs[0] = 1;
            expectedIndxs[1] = 1;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(expectedIndxs, actualIncremented, "Increment #5 failed.");
            gxIC.Increment();
            expectedIndxs[0] = 2;
            expectedIndxs[1] = 1;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(expectedIndxs, actualIncremented, "Increment #6 failed.");
            gxIC.Increment();
            expectedIndxs[0] = 0;
            expectedIndxs[1] = 2;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(expectedIndxs, actualIncremented, "Increment #7 failed.");
            gxIC.Increment();
            expectedIndxs[0] = 1;
            expectedIndxs[1] = 2;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(expectedIndxs, actualIncremented, "Increment #8 failed.");
            gxIC.Increment();
            expectedIndxs[0] = 2;
            expectedIndxs[1] = 2;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(expectedIndxs, actualIncremented, "Increment #9 failed.");
            gxIC.Increment();
            expectedIndxs[0] = 0;
            expectedIndxs[1] = 0;
            expectedIndxs[2] = 1;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(expectedIndxs, actualIncremented, "Increment #10 failed.");
            gxIC.Increment();
            expectedIndxs[0] = 1;
            expectedIndxs[1] = 0;
            expectedIndxs[2] = 1;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(expectedIndxs, actualIncremented, "Increment #11 failed.");
            gxIC.Increment();
            expectedIndxs[0] = 2;
            expectedIndxs[1] = 0;
            expectedIndxs[2] = 1;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(expectedIndxs, actualIncremented, "Increment #12 failed.");
            gxIC.Increment();
            expectedIndxs[0] = 0;
            expectedIndxs[1] = 1;
            expectedIndxs[2] = 1;
            CopyIndexesToArray(ref actualIncremented, gxIC);
            CollectionAssert.AreEqual(expectedIndxs, actualIncremented, "Increment #13 failed.");
        }
    }
}
