using System.Collections.Generic;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI.Elements
{
    /// <summary>
    /// Multipyer is an Element implements IElement.
    /// </summary>
    public class Multipyer : IElement
    {
        /// <summary>
        /// a string represent "*"
        /// </summary>
        private string ValueString;

        /// <summary>
        /// a Multipyer's priority.
        /// </summary>
        private int Priority;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Multipyer()
        {
            ValueString = Consts.MULTIPY_SIGN;
            Priority = Consts.PRIORITY_OPERTOR_HIGH;
        }

        /// <summary>
        /// Add Multipyer into postfix.
        /// </summary>
        /// <param name="stack"> a temporary stack store operators. </param>
        /// <param name="postfix"> a postfix expression. </param>
        public void AddIntoPostfix(Stack<IElement> stack, List<IElement> postfix)
        {
            while (stack.Count != Consts.ZERO && stack.Peek().GetPriority() >= this.GetPriority())
            {
                postfix.Add(stack.Pop());
            }
            stack.Push(this);
        }

        /// <summary>
        /// Add TreeNode into expression tree.
        /// </summary>
        /// <param name="nodeStack"> a temporary stack store treenodes. </param>
        public void AddIntoTree(Stack<TreeNode> nodeStack)
        {
            nodeStack.Push(new TreeNode { Value = this, RightNode = nodeStack.Pop(), LeftNode = nodeStack.Pop() });
        }

        /// <summary>
        /// multipy two numbers.
        /// </summary>
        /// <param name="firstNumber"> the first number </param>
        /// <param name="secondNumber"> the second number </param>
        /// <returns> the result after operation. </returns>
        public decimal DoOperation(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber * secondNumber;
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
        /// Get the Multipyer's ValueString.
        /// </summary>
        /// <returns> "*" </returns>
        public string GetValueString()
        {
            return ValueString;
        }
    }
}
