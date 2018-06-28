using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions.Operators
{
    public static class OperatorFactory
    {
        private static readonly Dictionary<char, IOperator> _operators = new Dictionary<char, IOperator>();
        static OperatorFactory()
        {
            _operators.Add('+', new AddOperator());
            _operators.Add('*', new MultiplyOperator());
            _operators.Add('-', new SubtractOperator());
            _operators.Add('/', new DivideOperator());
        }

        public static IOperator CreateOperator(string op)
        {
            char singleOper = op.Trim().First();
            if (_operators.ContainsKey(singleOper))
            {
                return _operators[singleOper];
            }

            throw new ArgumentException("Unknown Operator");
        }
    }
}
