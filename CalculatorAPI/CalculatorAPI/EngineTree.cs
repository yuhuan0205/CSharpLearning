using System.Collections.Generic;
using System.Text;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI
{
    /// <summary>
    /// a computing engine implements IEngine.
    /// </summary>
    public class EngineTree : IEngine
    {
        /// <summary>
        /// a infix expression contains Elements which contain operands and operators.
        /// </summary>
        private List<IElement> Infix;

        /// <summary>
        /// a postfix expression contains Elements which contain operands and operators.
        /// </summary>
        private List<IElement> Postfix;

        /// <summary>
        /// a prefix expression contains Elements which contain operands and operators.
        /// </summary>
        private List<IElement> Prefix;

        /// <summary>
        /// Tree's root.
        /// </summary>
        private TreeNode Root;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="infix"> a infix expression. </param>
        public EngineTree(List<IElement> infix)
        {
            Infix = infix;
            Postfix = new List<IElement>();
            Prefix = new List<IElement>();
            Root = null;
        }

        /// <summary>
        /// get a postfix expression from infix expression.
        /// </summary>
        /// <param name="infix"> a infix expression. </param>
        /// <returns> a postfix list of Elements </returns>
        private List<IElement> InfixToPostfix(List<IElement> infix)
        {
            List<IElement> postfix = new List<IElement>();
            Stack<IElement> stack = new Stack<IElement>();

            foreach(IElement element in infix)
            {
                element.AddIntoPostfix(stack, postfix);
            }
            while(stack.Count != 0)
            {
                postfix.Add(stack.Pop());
            }
            return postfix;
        }

        /// <summary>
        /// build a expression tree from postfix expression.
        /// </summary>
        /// <param name="postfix"></param>
        /// <returns> the root of the tree. </returns>
        private TreeNode PostfixToExpressionTree(List<IElement> postfix)
        {
            Stack<TreeNode> nodes = new Stack<TreeNode>();
            foreach(IElement element in postfix)
            {
                element.AddIntoTree(nodes);
            }
            return nodes.Pop();
        }

        /// <summary>
        /// Traverse the tree in postorder.
        /// </summary>
        /// <param name="root"> the tree's root. </param>
        /// <returns> Answer </returns>
        private string TraverseTreeGetAnswer(TreeNode root)
        {
            return PostorderTraversalAndGetPrefix(root).ToString("G29");
        }

        /// <summary>
        /// Recursively traverse the expression tree to get the answer.
        /// And when traversed the tree, the prefix was done.
        /// </summary>
        /// <param name="node"> tree node contains operator or operand. </param>
        /// <returns> answer </returns>
        private decimal PostorderTraversalAndGetPrefix(TreeNode node)
        {
            //Preorder get prefix.
            Prefix.Add(node.Value);

            //ending condition.
            if(node.LeftNode == null || node.RightNode == null)
            {
                return node.Value.GetValue();
            }
            else
            {
                //Traverse Left child.
                decimal firstNumber = PostorderTraversalAndGetPrefix(node.LeftNode);
                //Traverse Right child.
                decimal secondNumber = PostorderTraversalAndGetPrefix(node.RightNode);
                //Do a operation with two child.
                return node.Value.DoOperation(firstNumber, secondNumber);
            }
        }

        /// <summary>
        /// A function for calculator calling.
        /// In order to get answer, prefix and postfix from infix expression.
        /// </summary>
        /// <returns> a jsonlike object contain answer and expression(infix, postfix, prefix) </returns>
        public MessageObject GetResult()
        {
            Postfix = InfixToPostfix(Infix);
            Root = PostfixToExpressionTree(Postfix);
            string Answer = TraverseTreeGetAnswer(Root);

            StringBuilder processBuilder = new StringBuilder();
            foreach(IElement element in Infix)
            {
                processBuilder.Append(element.GetValueString());
            }
            processBuilder.Append("\n");
            foreach (IElement element in Postfix)
            {
                processBuilder.Append(element.GetValueString());
            }
            processBuilder.Append("\n");
            foreach (IElement element in Prefix)
            {
                processBuilder.Append(element.GetValueString());
            }

            return new MessageObject
            {
                InputNumber = Answer,
                CalculatedProcess = processBuilder.ToString()
            };
        }
    }
}