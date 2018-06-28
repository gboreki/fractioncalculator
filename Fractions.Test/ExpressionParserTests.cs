using System;
using Fractions;
using Fractions.Operators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    [TestCategory("ExpressionParser")]
    public class ExpressionParserTests
    {
        [TestMethod]
        public void ParsesSingleOperand()
        {
            string cmd = "? 1_2/3";
            var sut = new ExpressionParser();
            var result = (Operand)sut.Parse(cmd);
            Assert.AreEqual(3, result.Denominator);
            Assert.AreEqual(2, result.Numerator);
        }

        [TestMethod]
        public void ParsesTwoOperands()
        {
            string cmd = "? 1_2/3 + 2";
            var sut = new ExpressionParser();
            var result = (Expression)sut.Parse(cmd);
            Assert.IsInstanceOfType(result.Operator, typeof(AddOperator));
        }

        [TestMethod]
        public void ParsesAllOperands()
        {
            string cmd = "? 1_2/3 * 456 + 78/9   /  10_123/456";
            var sut = new ExpressionParser();
            var result = sut.Parse(cmd);
            Assert.AreEqual(" ( (2/3*456/1) + (78/9/4683/456) ) ", result.ToString());
        }

        [TestMethod]
        public void ParsesSwitchPriority()
        {
            string cmd = "? 1 + 2 * 5 + 6";
            var sut = new ExpressionParser();
            var result = sut.Parse(cmd);
            Assert.AreEqual(" (1/1+ ( (2/1*5/1) +6/1) ) ", result.ToString());
        }

        [TestMethod]
        public void ParsesNoMarkerThrows()
        {
            string cmd = "1_2/3";
            var sut = new ExpressionParser();
           Assert.ThrowsException<ArgumentException>(() => sut.Parse(cmd));
        }

        [TestMethod]
        public void ParsesIncompleteExpression()
        {
            string cmd = "? 1_2/3 + ";
            var sut = new ExpressionParser();
            Assert.ThrowsException<ArgumentException>(() => sut.Parse(cmd));
        }
    }
}
