using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    /// <summary>
    /// Represents and Item that can be solved and returns the operand result of that expression
    /// </summary>
    public interface ISolvable
    {
        bool CanSolve();
        Operand Solve();
    }
}
