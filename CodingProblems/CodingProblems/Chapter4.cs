using System;
using System.Collections.Generic;

namespace CodingProblems
{
    public class Chapter4
    {
        public bool Problem1(TreeNode root)
        {
            return IsBalanced(root);
        }

        public static int MaxDepth(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(MaxDepth(node.Left), MaxDepth(node.Right));
        }

        public static int MinDepth(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Min(MinDepth(node.Left), MinDepth(node.Right));
        }

        public static bool IsBalanced(TreeNode node)
        {
            return MaxDepth(node) - MinDepth(node) <= 1;
        }

        public static List<List<TreeNode>> Problem4(TreeNode root)
        {
            Queue<TreeNode> nextNodes = new Queue<TreeNode>();
            nextNodes.Enqueue(root);

            var result = new List<List<TreeNode>>();

            while (nextNodes.Count > 0)
            {
                var levelList = new List<TreeNode>();
                result.Add(levelList);

                var nodesLevel = nextNodes.Count;
                for (int i = 0; i < nodesLevel; i++)
                {
                    var currentNode = nextNodes.Dequeue();
                    levelList.Add(currentNode);

                    if (currentNode.Left != null)
                    {
                        nextNodes.Enqueue(currentNode.Left);
                    }

                    if (currentNode.Right != null)
                    {
                        nextNodes.Enqueue(currentNode.Right);
                    }
                }
            }

            return result;
        }
    }
}
