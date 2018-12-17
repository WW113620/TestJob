using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadCSVFile;

namespace UnitTesReadCSVFile
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(UnitTestMethod.TestLPMedianDataTable());

            Assert.AreEqual(UnitTestMethod.TestTOUMedianDataTable(),2870);

        }
    }
}
