using System;
using System.Text.RegularExpressions;

namespace Fractions
{
    // 6:47
    /// <summary>
    /// An instance of this class represents a valid fraction,
    /// The whole part is ommited during calculations
    /// </summary>
    public sealed class Operand : ISolvable
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public static Operand Create(int numerator, int denominator)
        {
            return new Operand
            {
                Numerator = numerator,
                Denominator = denominator
            };
        }
        public static Operand Parse(string candidate)
        {
            var match = Regex.Match(candidate, @"^(((?<numerator>\d+)/(?<denominator>\d+))|((?<whole>\d+)_(?<numerator>\d+)/(?<denominator>\d+))|(?<whole>\d+))");
            if (!match.Success)
                throw new ArgumentException("Invalid Fraction");

            var whole = ParseGroup(match.Groups["whole"]);            
            var numerator = ParseGroup(match.Groups["numerator"]);
            var denominator = ParseGroup(match.Groups["denominator"]);

            // fraction + whole
            if (whole.HasValue && whole > 1 && numerator.HasValue && denominator.HasValue)
            {
                numerator = numerator + whole * denominator;
            }
            else if (whole.HasValue  && !numerator.HasValue && !denominator.HasValue)
            {
                numerator = whole;
                denominator = 1;
            }

            var candidateFraction = new Operand
            {
                Denominator = denominator.Value,
                Numerator = numerator.Value
            };

            candidateFraction.ValidateOrThrow();
            return candidateFraction;
        }

        // We can 'solve' a fraction if it can be simplyfied. e.g. If there is a whole part
        // or numerator is divisible by denominator
        public bool CanSolve()
        {
            return (Numerator > 1 && (Denominator % Numerator == 0))
                || Denominator > 1 && Denominator <= Numerator && (Numerator % Denominator == 0);
        }

        public Operand Solve()
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
                Numerator = Numerator,
                Denominator = Denominator
            };

            if (newFraction.Numerator > 1 && (newFraction.Denominator % newFraction.Numerator == 0))
            {
                newFraction.Denominator = newFraction.Denominator / newFraction.Numerator;
                newFraction.Numerator = 1;
            }

            if (newFraction.Denominator > 1 && newFraction.Denominator <= newFraction.Numerator && (newFraction.Numerator % newFraction.Denominator == 0))
            {
                newFraction.Numerator = newFraction.Numerator / newFraction.Denominator;
                newFraction.Denominator = 1;                
            }
            // 
            return newFraction;
        }

        public bool IsFraction()
        {
            return Numerator != Denominator;
        }

        public override string ToString()
        {
            return Numerator.ToString() + "/" + Denominator.ToString();
        }

        private void ValidateOrThrow()
        {
            if (Denominator == 0)
                throw new ArgumentException("Denominator can't be null");
        }

        private static int? ParseGroup(Group group)
        {
            if (group.Success)
            {
                return Int32.Parse(group.Value);
            }

            return null;
        }

        private bool IsProper()
        {
            return Numerator <= Denominator;
        }
    }
}
