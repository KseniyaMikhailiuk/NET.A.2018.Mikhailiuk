using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day_3.Tests
{
    [TestClass]
    public class MathExtensionTests
    {
        private TestContext _testContextInstanse;

        public TestContext TestContext
        {
            get { return _testContextInstanse; }
            set { _testContextInstanse = value; }
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\FindingRootTests.csv",
        "FindingRootTests#csv", DataAccessMethod.Sequential), DeploymentItem("FindingRootTests.csv")]
        public void GetNthRoot_Test()
        {
            double number = double.Parse(TestContext.DataRow["Number"].ToString());
            int power = int.Parse(TestContext.DataRow["Root"].ToString());
            double eps = double.Parse(TestContext.DataRow["Eps"].ToString());
            double expected = double.Parse(TestContext.DataRow["Result"].ToString());
            double actual = MathExtension.GetNthRoot(number, power, eps);
            Assert.AreEqual(actual, expected, eps);
        }

        [TestMethod]
        [DataRow(-0.01, 2, 0.0001)]
        [DataRow(0.001, -2, 0.0001)]
        [DataRow(0.01, 2, -1)]
        public void GetNthRootTest_DataTable_ExpectedData(double number, int root, double eps)
        {
            Assert.ThrowsException<ArgumentException>(() => MathExtension.GetNthRoot(number, root, eps));
        }
    }
}