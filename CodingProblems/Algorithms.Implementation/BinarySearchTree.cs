using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms.Implementation.Models;

namespace Algorithms.Implementation
{

    /// <summary>
    /// In order - left, current, right
    /// Pre order - current, left, right
    /// Post order - left, right, current
    /// 
    /// for BST, we cannot determine the structure unless we have in order traversal
    /// </summary>

    public class BinarySearchTree
    {
        public TreeNode<int> Root { get; set; }

        public object NthLargestItem()
        {
            //do reverse of inorder traversal, in order traversal is always sorted by value, so it's matter of doing this and then counting

            //visit right
            //visit self
            //visit left

            return null;
        }

        public bool IsValidBST()
        {
            if (Root == null)
            {
                return true;
            }

            return IsValidBstNode(Root, int.MinValue, int.MaxValue);
        }

        private static bool IsValidBstNode(TreeNode<int> root, int minValue, int maxValue)
        {
            var left = (root.Left == null) ? true : IsValidBstNode(root.Left, minValue, root.Value);
            var right = (root.Right == null) ? true : IsValidBstNode(root.Right, root.Value, maxValue);

            return left && right && (minValue < root.Value) && (maxValue > root.Value);
        }
                
        #region Serialize & Deserialize

        // if BST, we can serialize by doing pre-order
        public List<int> SerializeTree()
        {
            List<int> result = new List<int>();

            this.SerializeTree(this.Root, result);

            return result;
        }

        private void SerializeTree(TreeNode<int> node, List<int> list) {
            if (node == null) {
                return;
            }

            list.Add(node.Value);

            this.SerializeTree(node.Left, list);
            this.SerializeTree(node.Right, list);
        }

	    public void Deserialize(List<int> data) {
            int index = 0;
            this.Root = this.Deserialize(data, ref index, int.MinValue, int.MaxValue);
        }

        private TreeNode<int> Deserialize(List<int> data, ref int index, int min, int max) {
            TreeNode<int> node = new TreeNode<int> { Value = data[index] };

            if ((data.Count > (index + 1)) && (data[index + 1] < max) && (data[index + 1] > min) && (data[index + 1] < node.Value))
            {
                index++;
                node.Left = this.Deserialize(data, ref index, min, node.Value);
            }
            if ((data.Count > (index + 1)) && (data[index + 1] < max) && (data[index + 1] > min) && (data[index + 1] > node.Value))
            {
                index++;
                node.Right = this.Deserialize(data, ref index, node.Value, max);
            }

            return node;
        }

        #endregion

        #region Next Smallest

        /// <summary>
        /// Handle the following
        /// 
        ///     if all numbers are smaller than the number, return x
        ///     
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int NextSmallest(int number)
        {
            return this.NextSmallest(this.Root, number);
        }
        
        /// <summary>
        /// if current value is smaller or equal to the number, then return something from right subtree
        /// 
        /// if current value is larger, we have two conditions
        ///     if there is a left subtree, see if it returns a value
        ///     if not return the current
        /// </summary>
        /// <param name="node"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private int NextSmallest(TreeNode<int> node, int number)
        {
            if (node.Value <= number)
            {
                if (node.Right != null)
                {
                    return this.NextSmallest(node.Right, number);
                }

                //if there is no more right to traverse, maybe all numbers are smaller than the number
                return -1;
            }

            int result = node.Value;

            if (node.Left != null)
            {
                int possibility = this.NextSmallest(node.Left, number);
                if (possibility != -1)
                {
                    result = possibility;
                }
            }

            return result;
        }

        #endregion

    }
}
