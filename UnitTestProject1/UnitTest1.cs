using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectsLibrary;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUnit()
        {
            Unit unit = new Unit("100m3");
            Assert.AreEqual("m3", unit.Name);
            Assert.AreEqual(100, unit.Factor);
        }
    }
}
