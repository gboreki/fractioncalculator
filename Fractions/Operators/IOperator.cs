namespace Fractions
{
    /// <summary>
    /// Represents an operator
    /// </summary>
    public interface IOperator
    {
        // Symbol used by expressions to represent this operator
        char Symbol { get; }

        // Priority of this item regarding other operators
        int Priority { get; }

        // Returns a new operator that represents the result of this operation
        Operand Solve(Operand p1, Operand p2);
    }
}
