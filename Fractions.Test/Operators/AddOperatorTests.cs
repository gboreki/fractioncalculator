using System;
using Fractions;
using Fractions.Operators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    [TestCategory("AddOperator")]
    public class AddOperatorTests
    {
        [TestMethod]
        public void AddWholes()
        {
            var result = Add("12", "34");
           
            Assert.AreEqual(1, result.Denominator);
            Assert.AreEqual(46, result.Numerator);
        }

        [TestMethod]
        public void AddFractions()
        {
            var result = Add("1/2", "3/4");

            Assert.AreEqual(8, result.Denominator);
            Assert.AreEqual(10, result.Numerator);
        }

        [TestMethod]
        public void AddFractionsSameDenominator()
        {
            var result = Add("1/4", "3/4");

            Assert.AreEqual(4, result.Denominator);
            Assert.AreEqual(4, result.Numerator);
        }

        private Operand Add(string p1, string p2)
        {
            var fraction = Operand.Parse(p1);
            var fraction2 = Operand.Parse(p2);
            var sut = new AddOperator();
            return sut.Solve(fraction, fraction2);
        }
    }
}
