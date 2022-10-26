using System.Collections.Generic;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI.Elements
{
    /// <summary>
    /// RightParenthese is an Element implements IElement.
    /// </summary>
    public class RightParenthese : IElement
    {
        /// <summary>
        /// a string represent ")"
        /// </summary>
        private string ValueString;

        /// <summary>
        /// a RightParenthese's priority.
        /// </summary>
        private int Priority;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RightParenthese()
        {
            ValueString = Consts.RIGHT_PARENTHESE;
            Priority = Consts.PRIORITY_NONE;
        }

        /// <summary>
        /// Add RightParenthese into postfix.
        /// </summary>
        /// <param name="stack"> a temporary stack store operators. </param>
        /// <param name="postfix"> a postfix expression. </param>
        public void AddIntoPostfix(Stack<IElement> stack, List<IElement> postfix)
        {
            while (stack.Peek().GetPriority() != Consts.PRIORITY_NONE)
            {
                postfix.Add(stack.Pop());
            }
            stack.Pop();
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
        /// Get the RightParenthese's ValueString.
        /// </summary>
        /// <returns> ")" </returns>
        public string GetValueString()
        {
            return ValueString;
        }
    }
}