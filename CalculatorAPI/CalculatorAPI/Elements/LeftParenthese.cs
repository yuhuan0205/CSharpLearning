using System.Collections.Generic;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI.Elements
{
    /// <summary>
    /// LeftParenthese is an Element implements IElement.
    /// </summary>
    public class LeftParenthese : IElement
    {
        /// <summary>
        /// a string represent "("
        /// </summary>
        public string ValueString;

        /// <summary>
        /// a LeftParenthese's priority.
        /// </summary>
        public int Priority;

        /// <summary>
        /// Constructor.
        /// </summary>
        public LeftParenthese()
        {
            ValueString = Consts.LEFT_PARENTHESE;
            Priority = Consts.PRIORITY_NONE;
        }

        /// <summary>
        /// Add LeftParenthese into postfix.
        /// </summary>
        /// <param name="stack"> a temporary stack store operators. </param>
        /// <param name="postfix"> a postfix expression. </param>
        public void AddIntoPostfix(Stack<IElement> stack, List<IElement> postfix)
        {
            stack.Push(this);
        }

        /// <summary>
        /// parenthese does not add into Tree.
        /// </summary>
        /// <param name="nodeStack"> a temporary stack store treenodes. </param>
        public void AddIntoTree(Stack<TreeNode> nodeStack)
        {
        }

        /// <summary>
        /// parenthese dose not have operation.
        /// </summary>
        /// <param name="firstNumber"> the first number </param>
        /// <param name="secondNumber"> the second number </param>
        /// <returns> zero </returns>
        public decimal DoOperation(decimal firstNumber, decimal secondNumber)
        {
            return Consts.ZERO;
        }

        /// <summary>
        /// Get the priority of the Element.
        /// </summary>
        /// <returns> priority </returns>
        public int GetPriority()
        {
            return Priority;
        }

        /// <summary>
        /// Get the Element's Value but operator has not value.
        /// </summary>
        /// <returns> zero </returns>
        public decimal GetValue()
        {
            return Consts.ZERO;
        }

        /// <summary>
        /// Get the LeftParenthese's ValueString.
        /// </summary>
        /// <returns> "(" </returns>
        public string GetValueString()
        {
            return ValueString;
        }
    }
}
