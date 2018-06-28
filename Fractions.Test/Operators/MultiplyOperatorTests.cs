using System;
using Fractions;
using Fractions.Operators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    [TestCategory("MultiplyOperator")]
    public class MultiplyOperatorTests
    {
        [TestMethod]
        public void MultiplyWholes()
        {
            var result = Multiply("12", "34");
           
            Assert.AreEqual(408, result.Numerator);
        }

        [TestMethod]
        public void MultiplyFractions()
        {
            var result = Multiply("1/2", "3/4");

            Assert.AreEqual(8, result.Denominator);
            Assert.AreEqual(3, result.Numerator);
        }

        [TestMethod]
        public void AddFractionsSameDenominator()
        {
            var result = Multiply("1/4", "3/4");

            Assert.AreEqual(16, result.Denominator);
            Assert.AreEqual(3, result.Numerator);
        }

        private Operand Multiply(string p1, string p2)
        {
            var fraction = Operand.Parse(p1);
            var fraction2 = Operand.Parse(p2);
            var sut = new MultiplyOperator();
            return sut.Solve(fraction, fraction2);
        }
    }
}
