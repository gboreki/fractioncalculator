using System;
using Fractions;
using Fractions.Operators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    [TestCategory("DivideOperator")]
    public class DivideOperatorTests
    {
        [TestMethod]
        public void DivideWholes()
        {
            var result = Divide("12", "34");
           
            Assert.AreEqual(12, result.Numerator);
            Assert.AreEqual(34, result.Denominator);
        }

        [TestMethod]
        public void DivideFractions()
        {
            var result = Divide("1/2", "3/4");

            Assert.AreEqual(6, result.Denominator);
            Assert.AreEqual(4, result.Numerator);
        }

        [TestMethod]
        public void AddFractionsSameDenominator()
        {
            var result = Divide("1/4", "3/4");

            Assert.AreEqual(12, result.Denominator);
            Assert.AreEqual(4, result.Numerator);
        }

        private Operand Divide(string p1, string p2)
        {
            var fraction = Operand.Parse(p1);
            var fraction2 = Operand.Parse(p2);
            var sut = new DivideOperator();
            return sut.Solve(fraction, fraction2);
        }
    }
}
