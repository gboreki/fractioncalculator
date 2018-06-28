using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    public class Expression : ISolvable
    {
        private readonly IOperator _operator;
        public ISolvable Right { get; private set; }
        public ISolvable Left { get; private set; }

        public bool CanSolve()
        {
            return true;    // Assume all operations are solvable
        }

        public ISolvable Solve()
        {
            return _operator.Solve(Right, Left);
        }
    }
}
