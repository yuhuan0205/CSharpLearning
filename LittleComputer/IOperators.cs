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
        /// it makes each Operator has its own multipy fuction and divide fuction with two numbers.
        /// </summary>
        /// <param name="originalOperands"> original Operands List</param>
        /// <param name="newOperands"> new Operands List </param>
        public void MultipyOrDivide(List<decimal> originalOperands, List<decimal> newOperands);

        /// <summary>
        /// every child class should implement this abstract function.
        /// it makes each Operator has its own add fuction and minus fuction with two numbers.
        /// </summary>
        /// <param name="originalOperands"> original Operands List</param>
        public void AddOrMinus(List<decimal> originalOperands);

        /// <summary>
        /// get operator's sign.
        /// </summary>
        /// <returns> operator's sign </returns>
        public string GetSign();
    }
}
