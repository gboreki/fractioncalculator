namespace Fractions.Operators
{
    public class DivideOperator : IOperator
    {
        public int Priority => 0;

        public char Symbol => '/';

        public Operand Solve(Operand p1, Operand p2)
        {
            p1 = p1.Simplify();
            p2 = p2.Simplify();

            return Operand.Create(p1.Numerator * p2.Denominator, p1.Denominator * p2.Numerator);
        }
    }
}
