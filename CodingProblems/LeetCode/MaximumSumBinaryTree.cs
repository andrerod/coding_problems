using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }

    public class MaximumSumBinaryTree
    {
        public int MaxPathSum(TreeNode root)
        {
            int maxSum = int.MinValue;
            int currentValue = FindMaxPathSum(root, ref maxSum);
            return maxSum;
        }

        public int FindMaxPathSum(TreeNode node, ref int maxSum)
        {
            if (node == null)
            {
                return 0;
            }

            int sumLeft = Math.Max(FindMaxPathSum(node.left, ref maxSum), 0);
            int sumRight = Math.Max(FindMaxPathSum(node.right, ref maxSum), 0);

            int currentNodeValue = Math.Max(sumLeft, sumRight) + node.val;
            int currentRootValue = sumLeft + sumRight + node.val;
            maxSum = Math.Max(maxSum, Math.Max(currentRootValue, currentNodeValue));

            return currentNodeValue;
        }
    }
}
