using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var parser = new ExpressionParser();
            var solvable = parser.Parse(input);
            Console.WriteLine(solvable.Solve().AsProperFractionString());
        }
    }
}
