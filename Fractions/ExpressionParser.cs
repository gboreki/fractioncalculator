using Fractions.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fractions
{
    public class ExpressionParser
    {
        public ISolvable Parse(string candidate)
        {
            if (!candidate.StartsWith("? "))
            {
                throw new ArgumentException("Expression missing marker");
            }

            candidate = candidate.Substring(2);

            // Split the string based on the format of operators
            var tokens = Regex.Split(candidate, @"(\s+[*]\s+)|(\s+[/]\s+)|(\s+[+]\s+)|(\s+[-]\s+)");

            // Since we dont support parenthesis, we can check based on expected number
            // of operands and operator. 
            if (tokens.Length != 1 && ((tokens.Length -1) % 2 != 0))  
            {
                throw new ArgumentException("Incomplete expression");
            }

            Expression root = null;
            Expression previous = null;

            // Short circuit for single operand
            if (tokens.Length == 1)
            {
                return Operand.Parse(tokens[0]);
            }

            // Iterate through pottential operators
            for (int i = 1; i <= tokens.Length -2; i+=2)
            {
                var newExpr = new Expression(OperatorFactory.CreateOperator(tokens[i]), previous);
                var op2 = tokens[i + 1];
                newExpr.Right = Operand.Parse(op2);

                if (root == null)
                {
                    root = newExpr;

                    var op1 = tokens[i - 1];
                    newExpr.Left = Operand.Parse(op1);
                }
                // Previous had a higher priority e.g. * over +
                else if (previous.Operator.Priority > newExpr.Operator.Priority)
                {
                    newExpr.Left = previous.Right;
                    previous.Right = newExpr;
                }
                // Previous is lower priority, so we need to switch parents
                else 
                {
                    newExpr.Left = previous;

                    // new root
                    if (previous.Parent == null)
                    {
                        root = newExpr;

                    }
                    else
                    {
                        previous.Parent.Right = newExpr;
                        newExpr.Parent = previous.Parent;   // fix the parent since we attaching higher in the tree
                    }
                }

                previous = newExpr;
            }

            return root;
        }
    }
}
