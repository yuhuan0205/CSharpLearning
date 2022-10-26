using CalculatorAPI.Interfaces;

namespace CalculatorAPI
{
    /// <summary>
    /// the node of expression tree.
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// the node's value which contains a Element.
        /// </summary>
        public IElement Value { get; set; }
        
        /// <summary>
        /// node's left child.
        /// </summary>
        public TreeNode LeftNode { get; set; }

        /// <summary>
        /// node's right child.
        /// </summary>
        public TreeNode RightNode { get; set; }
    }
}