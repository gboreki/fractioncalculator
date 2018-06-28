using System;
using Fractions;
using Fractions.Operators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    [TestCategory("Expression")]
    public class ExpressionTests
    {
        [TestMethod]
        public void ExpressionWithPriority()
        {
            string cmd = "? 1 + 2 * 5 + 6";
            var parser = new ExpressionParser();
            var sut = parser.Parse(cmd);
            var result = sut.Solve();
            Assert.AreEqual(17, result.Numerator);
            Assert.AreEqual(1, result.Denominator);
        }

        [TestMethod]
        public void ExpressionFromMail1()
        {
            string cmd = "? 1/2 * 3_3/4";
            var parser = new ExpressionParser();
            var sut = parser.Parse(cmd);
            var result = sut.Solve();
            Assert.AreEqual(7, result.Numerator);
            Assert.AreEqual(8, result.Denominator);
        }

        [TestMethod]
        public void ExpressionFromMail2()
        {
            string cmd = "? 2_3/8 + 9/8";
            var parser = new ExpressionParser();
            var sut = parser.Parse(cmd);
            var result = sut.Solve();
            Assert.AreEqual(3, result.Numerator);
            Assert.AreEqual(2, result.Denominator);
        }
    }
}
