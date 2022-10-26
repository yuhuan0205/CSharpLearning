using System.Collections.Generic;

namespace CalculatorAPI.Interfaces
{
    /// <summary>
    /// a interface define what things a Element should implement.
    /// </summary>
    public interface IElement
    {
        /// <summary>
        /// Get the priority of the Element.
        /// </summary>
        /// <returns> priority </returns>
        public int GetPriority();

        /// <summary>
        /// an operator Element can do its operation with two numbers.
        /// </summary>
        /// <param name="firstNumber"> the first number </param>
        /// <param name="secondNumber"> the second number </param>
        /// <returns> the result after operation. </returns>
        public decimal DoOperation(decimal firstNumber, decimal secondNumber);

        /// <summary>
        /// Get the operand's decimal value.
        /// </summary>
        /// <returns> the operand's decimal value. </returns>
        public decimal GetValue();

        /// <summary>
        /// Get the Element's ValueString.
        /// </summary>
        /// <returns> ValueString </returns>
        public string GetValueString();

        /// <summary>
        /// Add Element into postfix.
        /// </summary>
        /// <param name="stack"> a temporary stack store operators. </param>
        /// <param name="postfix"> a postfix expression </param>
        public void AddIntoPostfix(Stack<IElement> stack, List<IElement> postfix);

        /// <summary>
        /// Add Element into expression tree.
        /// </summary>
        /// <param name="nodeStack"> a temporary stack store treenodes. </param>
        public void AddIntoTree(Stack<TreeNode> nodeStack);
    }
}