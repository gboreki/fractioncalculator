using System.Diagnostics;

namespace Fractions.Operators
{
    public class SubtractOperator : IOperator
    {
        public int Priority => 1;

        public char Symbol => '-';

        public Operand Solve(Operand p1, Operand p2)
        {
            p1 = p1.Simplify();
            p2 = p2.Simplify();

            if (p1.Denominator == p2.Denominator)
            {
                return Operand.Create(p1.Numerator - p2.Numerator, p1.Denominator);
            }

            var denominator1 = p1.Denominator;
            var denominator2 = p2.Denominator;

            var newOperand1 = Operand.Create(denominator2 * p1.Numerator, denominator2 * p1.Denominator);
            var newOperand2 = Operand.Create(denominator1 * p2.Numerator, denominator1 * p2.Denominator);

            Debug.Assert(newOperand1.Denominator == newOperand2.Denominator);
            return Operand.Create(newOperand1.Numerator - newOperand2.Numerator, newOperand1.Denominator).Simplify();

        }
    }
}
