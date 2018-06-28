using System;
using Fractions;
using Fractions.Operators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    [TestCategory("SubtractOperator")]
    public class SubtractOperatorTests
    {
        [TestMethod]
        public void SubtractWholes()
        {
            var result = Subtract("34", "12");
           
            Assert.AreEqual(1, result.Denominator);
            Assert.AreEqual(22, result.Numerator);
        }

        [TestMethod]
        public void SubtractFractions()
        {
            var result = Subtract("3/4", "1/2");

            Assert.AreEqual(4, result.Denominator);
            Assert.AreEqual(1, result.Numerator);
        }

        [TestMethod]
        public void SubtractFractionsSameDenominator()
        {
            var result = Subtract("1/4", "3/4");

            Assert.AreEqual(4, result.Denominator);
            Assert.AreEqual(-2, result.Numerator);
        }

        private Operand Subtract(string p1, string p2)
        {
            var fraction = Operand.Parse(p1);
            var fraction2 = Operand.Parse(p2);
            var sut = new SubtractOperator();
            return sut.Solve(fraction, fraction2);
        }
    }
}
