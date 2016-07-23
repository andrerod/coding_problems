using System.Collections.Generic;

namespace CodingProblems
{
    public class KThSmallestElementInTree
    {
        //  find the k smallest values in a binary search tree.
        public static TreeNode FindKthSmallestElement(TreeNode root, int elementNumber)
        {
            Stack<TreeNode> nodesToVisit = new Stack<TreeNode>();
            HashSet<TreeNode> visited = new HashSet<TreeNode>();

            int currentNodeCount = 0;
            nodesToVisit.Push(root);
            while (nodesToVisit.Count > 0)
            {
                var currentNode = nodesToVisit.Pop();
                if (visited.Contains(currentNode))
                {
                    currentNodeCount++;
                    if (currentNodeCount == elementNumber)
                    {
                        return currentNode;
                    }
                }
                else
                {
                    visited.Add(currentNode);

                    if (currentNode.Right != null)
                    {
                        nodesToVisit.Push(currentNode.Right);
                    }

                    nodesToVisit.Push(currentNode);

                    if (currentNode.Left != null)
                    {
                        nodesToVisit.Push(currentNode.Left);
                    }
                }
            }

            return null;
        }
    }
}
