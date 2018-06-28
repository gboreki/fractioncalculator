using System;
using Fractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class AddOperatorTests
    {
        [TestMethod]
        public void ParsesWhole()
        {
            var fraction = Operand.Parse("1");
            Assert.AreEqual(1, fraction.Whole);
            Assert.AreEqual(1, fraction.Denominator);
            Assert.AreEqual(1, fraction.Numerator);
        }
    }
}
