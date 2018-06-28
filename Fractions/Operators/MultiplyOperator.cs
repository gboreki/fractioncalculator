using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions.Operators
{
    public class MultiplyOperator : IOperator
    {
        public int Priority => 0;

        public char Symbol => '*';

        public Operand Solve(Operand p1, Operand p2)
        {
            p1 = p1.Simplify();
            p2 = p2.Simplify();

            return Operand.Create(p1.Numerator * p2.Numerator, p1.Denominator * p2.Denominator);
        }
    }
}
