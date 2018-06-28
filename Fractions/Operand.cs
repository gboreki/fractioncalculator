using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fractions
{
    // 6:47
    /// <summary>
    /// An instance of this class represents a valid fraction
    /// </summary>
    public sealed class Operand : ISolvable
    {
        public int Whole { get; private set;  }
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public static Operand Create(int whole, int numerator, int denominator)
        {
            return new Operand
            {
                Whole = whole,
                Numerator = numerator,
                Denominator = denominator
            };
        }
        public static Operand Parse(string candidate)
        {
            var match = Regex.Match(candidate, @"^(((?<numerator>\d+)/(?<denominator>\d+))|((?<whole>\d+)_(?<numerator>\d+)/(?<denominator>\d+))|(?<whole>\d+))");
            if (!match.Success)
                throw new ArgumentException("Invalid Fraction");

            var numerator = ParseGroup(match.Groups["numerator"], 1);
            var denominator = ParseGroup(match.Groups["denominator"], 1);
            var whole = ParseGroup(match.Groups["whole"], 1);

            var candidateFraction = new Operand
            {
                Denominator = denominator,
                Numerator = numerator,
                Whole = whole
            };

            candidateFraction.ValidateOrThrow();
            return candidateFraction;
        }

        // We can 'solve' a fraction if it can be simplyfied. e.g. If there is a whole part
        // or numerator is divisible by denominator
        public bool CanSolve()
        {
            return (Whole > 1 && Denominator > 1) 
                || (Numerator > 1 && (Denominator % Numerator == 0));
        }

        public ISolvable Solve()
        {
            return Simplify();
        }

        public Operand Simplify()
        {
            if (!CanSolve())
            {
                return this;
            }

            var newFraction = new Operand
            {
                Whole = Whole,
                Numerator = Numerator,
                Denominator = Denominator
            };

            if (newFraction.Whole > 1)
            {
                newFraction.Numerator = newFraction.Numerator * newFraction.Whole;
                newFraction.Whole = 1;
            }

            if (newFraction.Numerator > 1 && (newFraction.Denominator % newFraction.Numerator == 0))
            {
                newFraction.Denominator = newFraction.Denominator / newFraction.Numerator;
                newFraction.Numerator = 1;
            }

            if (newFraction.Denominator > 1 && newFraction.Denominator <= newFraction.Numerator && (newFraction.Numerator % newFraction.Denominator == 0))
            {
                newFraction.Whole = newFraction.Numerator / newFraction.Denominator;
                newFraction.Denominator = 1;
                newFraction.Numerator = 1;
            }
            // 
            return newFraction;
        }

        public bool IsFraction()
        {
            return Numerator != Denominator;
        }

        private void ValidateOrThrow()
        {
            if (Denominator == 0)
                throw new ArgumentException("Denominator can't be null");

            if (!IsProper() && Whole > 1)
                throw new ArgumentException("Fraction can't be Improper and have whole part");
        }

        private static int ParseGroup(Group group, int defaultInt)
        {
            if (group.Success)
            {
                return Int32.Parse(group.Value);
            }

            return defaultInt;
        }

        private bool IsProper()
        {
            return Numerator <= Denominator;
        }
    }
}
