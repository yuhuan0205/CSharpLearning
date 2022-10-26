using System;
using System.Collections.Generic;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI.Elements
{
    /// <summary>
    /// NumberElement is an Element implements IElement.
    /// </summary>
    public class NumberElement : IElement
    {
        /// <summary>
        /// operand's value.
        /// </summary>
        private decimal Value;

        /// <summary>
        /// operand's value string.
        /// </summary>
        private string ValueString;

        /// <summary>
        /// a operand's priority.
        /// </summary>
        private int Priority;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value"> operand </param>
        public NumberElement(string value)
        {
            ValueString = value;
            Value = Convert.ToDecimal(ValueString);
            Priority = Consts.PRIORITY_NONE;
        }

        /// <summary>
        /// Add operand into postfix.
        /// </summary>
        /// <param name="stack"> a temporary stack store operators. </param>
        /// <param name="postfix"> a postfix expression. </param>
        public void AddIntoPostfix(Stack<IElement> stack, List<IElement> postfix)
        {
            postfix.Add(this);
        }

        /// <summary>
        /// Add TreeNode into expression tree.
        /// </summary>
        /// <param name="nodeStack"> a temporary stack store treenodes. </param>
        public void AddIntoTree(Stack<TreeNode> nodeStack)
        {
            nodeStack.Push(new TreeNode { Value = this });
        }

        /// <summary>
        /// operand dose not have operation.
        /// </summary>
        /// <param name="firstNumber"> the first number </param>
        /// <param name="secondNumber"> the second number </param>
        /// <returns> operand </returns>
        public decimal DoOperation(decimal firstNumber, decimal secondNumber)
        {
            return Value;
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
        /// Get the operand's Value.
        /// </summary>
        /// <returns> zero </returns>
        public decimal GetValue()
        {
            return Value;
        }

        /// <summary>
        /// Get the operand's ValueString.
        /// </summary>
        /// <returns> operand's ValueString. </returns>
        public string GetValueString()
        {
            return ValueString;
        }
    }
}