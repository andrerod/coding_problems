using System;
using System.Collections.Generic;

namespace CodingProblems
{
    public class Chapter4
    {
        public static TreeNode Problem2(int[] sortedArray)
        {
            return Problem2(sortedArray, 0, sortedArray.Length - 1);
        }

        private static TreeNode Problem2(int[] sortedArray, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            int mid = (left + right) / 2;
            TreeNode root = new TreeNode { Value = sortedArray[mid] };
            root.Left = Problem2(sortedArray, left, mid - 1);
            root.Right = Problem2(sortedArray, mid + 1, right);

            return root;
        }

        private static int CheckHeight(TreeNode root)
        {
            if (root == null)
            {
                return -1;
            }

            int leftHeight = CheckHeight(root.Left);
            if (leftHeight == int.MinValue) return int.MinValue;

            int rightHeight = CheckHeight(root.Right);
            if (rightHeight == int.MinValue) return int.MinValue;

            int heightDiff = leftHeight - rightHeight;
            if (Math.Abs(heightDiff) > 1)
            {
                return int.MinValue;
            }
            else
            {
                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }

        public static bool Problem4(TreeNode root)
        {
            return CheckHeight(root) != int.MinValue;
        }

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

        public static List<List<TreeNode>> InLevelProblem4(TreeNode root)
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

        public static List<int> InOrder(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            var nodes = new List<int>();
            InOrder(root, nodes);

            return nodes;
        }

        public static void InOrder(TreeNode node, List<int> currentList)
        {
            if (node != null)
            {
                InOrder(node.Left, currentList);
                currentList.Add(node.Value);
                InOrder(node.Right, currentList);
            }
        }

        public static List<int> InOrderIterative(TreeNode root)
        {
            var nodes = new List<int>();
            var visited = new HashSet<TreeNode>();
            var toVisit = new Stack<TreeNode>();

            toVisit.Push(root);
            while (toVisit.Count != 0)
            {
                var currentNode = toVisit.Pop();

                if (!visited.Contains(currentNode))
                {
                    visited.Add(currentNode);

                    if (currentNode.Right != null)
                    {
                        toVisit.Push(currentNode.Right);
                    }

                    toVisit.Push(currentNode);

                    if (currentNode.Left != null)
                    {
                        toVisit.Push(currentNode.Left);
                    }
                }
                else
                {
                    nodes.Add(currentNode.Value);
                }
            }

            return nodes;
        }
    }
}
