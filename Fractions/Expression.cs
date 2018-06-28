using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    /// <summary>
    /// Represents an expression tree. Basic form with a right, operator and left
    /// </summary>
    public class Expression : ISolvable
    {
        public Expression(IOperator op, Expression parent)
        {
            Operator = op;
            Parent = parent;
        }

        public Expression Parent { get; set; }
        public IOperator Operator { get; private set; }
        public ISolvable Right { get; set; }
        public ISolvable Left { get; set; }

        public bool CanSolve()
        {
            return true;    // Assume all operations are solvable
        }

        public Operand Solve()
        {
            Operand right = null;
            Operand left = null;
            if (Right != null)
            {
                right = Right.Solve();
            }
            if (Left != null)
            {
                left = Left.Solve();
            }

            return Operator.Solve(right, left);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" (");
            if (Left != null)
                sb.Append(Left.ToString());

            sb.Append(Operator.Symbol);

            if (Right != null)
                sb.Append(Right.ToString());

            sb.Append(") ");
            return sb.ToString();
        }
    }
}
