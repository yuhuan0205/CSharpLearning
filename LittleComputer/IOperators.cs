using System.Collections.Generic;

namespace LittleComputer
{
    /// <summary>
    /// Operators insterface.
    /// </summary>
    public interface IOperators
    {
        /// <summary>
        /// every child class should implement this abstract function.
        /// it makes each Operator has its own operation with two numbers.
        /// </summary>
        public void MultipyOrDivide(List<decimal> oldOperands, List<decimal> newOperands);

        public void AddOrMinus(List<decimal> oldOperands);

        public string GetSign();
    }
}
