﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    public interface ISolvable
    {
        bool CanSolve();
        Operand Solve();
    }
}
