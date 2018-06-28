using System;
using Fractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    [TestCategory("Operand")]
    public class FractionsTests
    {
        [TestMethod]
        public void ParsesWhole()
        {
            var fraction = Operand.Parse("1");
            Assert.AreEqual(1, fraction.Denominator);
            Assert.AreEqual(1, fraction.Numerator);
            Assert.IsFalse(fraction.IsFraction());
        }

        [TestMethod]
        public void ParsesWholeAsZero()
        {
            var fraction = Operand.Parse("0");
            Assert.AreEqual(1, fraction.Denominator);
            Assert.AreEqual(0, fraction.Numerator);
        }

        [TestMethod]
        public void ParsesFraction()
        {
            var fraction = Operand.Parse("1/2");
            Assert.AreEqual(2, fraction.Denominator);
            Assert.AreEqual(1, fraction.Numerator);
        }

        [TestMethod]
        public void ParsesFractionAndWhole()
        {
            var fraction = Operand.Parse("1_2/3");
            Assert.AreEqual(2, fraction.Numerator);
            Assert.AreEqual(3, fraction.Denominator);
        }

        [TestMethod]
        public void ParsesFractionAndWholeManyDigits()
        {
            var fraction = Operand.Parse("12_34/56");
            Assert.AreEqual(706, fraction.Numerator);
            Assert.AreEqual(56, fraction.Denominator);
        }

        [TestMethod]
        public void ParsesFractionImproper()
        {
            var fraction = Operand.Parse("11/2");
            Assert.AreEqual(11, fraction.Numerator);
            Assert.AreEqual(2, fraction.Denominator);
        }

        [TestMethod]
        public void ParsesFractionWithZeroThrows()
        {
            Assert.ThrowsException<ArgumentException>(() => Operand.Parse("11/0"));
        }

        [TestMethod]
        public void ParsesFractionSimplified()
        {
            var fraction = Operand.Parse("1/2");
            Assert.IsFalse(fraction.CanSolve());
        }

        [TestMethod]
        public void ParsesFractionSimplifable()
        {
            var fraction = Operand.Parse("2/10");
            Assert.IsTrue(fraction.CanSolve());

            var newFraction = fraction.Solve() as Operand;
            Assert.IsFalse(newFraction.CanSolve());
            Assert.AreEqual(1, newFraction.Numerator);
            Assert.AreEqual(5, newFraction.Denominator);
        }

        [TestMethod]
        public void ParsesFractionSimplifableWholeAndFraction()
        {
            var fraction = Operand.Parse("2_20/10");
            Assert.IsTrue(fraction.CanSolve());

            var newFraction = fraction.Solve() as Operand;
            Assert.IsFalse(newFraction.CanSolve());
            Assert.AreEqual(4, newFraction.Numerator);
            Assert.AreEqual(1, newFraction.Denominator);
        }

        [TestMethod]
        public void ParsesFractionSimplifableWholeOnly()
        {
            var fraction = Operand.Parse("2_1/11");
            Assert.IsFalse(fraction.CanSolve());

            Assert.AreEqual(23, fraction.Numerator);
            Assert.AreEqual(11, fraction.Denominator);
        }

        [TestMethod]
        public void ParsesFractionSimplifableDivisible()
        {
            var fraction = Operand.Parse("10_2/2");
            Assert.IsTrue(fraction.CanSolve());

            var newFraction = fraction.Solve() as Operand;
            Assert.IsFalse(newFraction.CanSolve());
            Assert.AreEqual(11, newFraction.Numerator);
            Assert.AreEqual(1, newFraction.Denominator);
        }
    }
}
