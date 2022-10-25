﻿using System;
using System.Collections.Generic;
using System.Text;
using CalculatorAPI.Elements;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI
{
    /// <summary>
    /// a computing engine implements IEngine.
    /// </summary>
    public class EngineTree : IEngine
    {
        private class TreeNode
        {
            public IElement Value { get; set; }
            public TreeNode LeftNode { get; set; }
            public TreeNode RightNode { get; set; }
            
        }

        private List<IElement> Infix;
        private List<IElement> Postfix;
        private List<IElement> Prefix;
        private TreeNode Root;

        public EngineTree(List<IElement> infix)
        {
            Infix = infix;
            Postfix = new List<IElement>();
            Prefix = new List<IElement>();
            Root = null;
        }

        private List<IElement> InfixToPostfix(List<IElement> infix)
        {
            List<IElement> postfix = new List<IElement>();
            Stack<IElement> stack = new Stack<IElement>();
            stack.Push(new EndSign());

            foreach(IElement element in infix)
            {
                if(element.GetPriority() == Consts.PRIORITY_OPERAND)
                {
                    postfix.Add(element);
                }
                else if(element.GetPriority() == Consts.PRIORITY_LEFT_PARENTHESE)
                {
                    stack.Push(element);
                }
                else if(element.GetPriority() == Consts.PRIORITY_RIGHT_PARENTHESE)
                {
                    while(stack.Peek().GetPriority() != Consts.PRIORITY_LEFT_PARENTHESE)
                    {
                        postfix.Add(stack.Pop());
                    }
                    stack.Pop();
                }
                else
                {
                    while(stack.Peek().GetPriority() >= element.GetPriority())
                    {
                        postfix.Add(stack.Pop());
                    }
                    stack.Push(element);
                }
            }
            while(stack.Peek().GetPriority() != -1)
            {
                postfix.Add(stack.Pop());
            }
            return postfix;
        }

        private TreeNode PostfixToExpressionTree(List<IElement> postfix)
        {
            Stack<TreeNode> nodes = new Stack<TreeNode>();
            foreach(IElement element in postfix)
            {
                if(element.GetPriority() == Consts.PRIORITY_OPERAND)
                {
                    nodes.Push(new TreeNode { Value = element });
                }
                else
                {
                    nodes.Push(new TreeNode { Value = element, RightNode = nodes.Pop(), LeftNode = nodes.Pop() });
                }
            }
            return nodes.Pop();
        }

        private string TreeTraversal(TreeNode root)
        {
            return Solve(root).ToString("G29");
        }

        private decimal Solve(TreeNode node)
        {
            Prefix.Add(node.Value);
            if(node.LeftNode == null || node.RightNode == null)
            {
                return node.Value.GetValue();
            }
            else
            {
                decimal firstNumber = Solve(node.LeftNode);
                decimal secondNumber = Solve(node.RightNode);
                return node.Value.DoOperation(firstNumber, secondNumber);
            }
        }
        public MessageObject GetResult()
        {
            Postfix = InfixToPostfix(Infix);
            Root = PostfixToExpressionTree(Postfix);
            string Answer = TreeTraversal(Root);

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
