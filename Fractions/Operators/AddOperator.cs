using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions.Operators
{
    public class AddOperator : IOperator
    {
        public Operand Solve(Operand p1, Operand p2)
        {
            p1 = p1.Simplify();
            p2 = p2.Simplify();

            if (p1.Denominator == p2.Denominator)
            {
                return Operand.Create(1, p1.Numerator + p2.Numerator, p1.Denominator);
            }

            var denominator1 = p1.Denominator;
            var denominator2 = p2.Denominator;

        }
    }
}
