using Algorithms.Implementation;
using Algorithms.Implementation.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Tests
{
    
    [TestClass]
    public class IteratorTests
    {

        #region Binary Tree Iterator

        /// <summary>
        ///          1
        ///         / \
        ///        3   5
        ///       / \   \
        ///      2   4   7
        ///     /     \
        ///    9       8
        ///    
        [TestMethod]
        public void InOrderIterative()
        {
            BinaryTree<int> bt = new BinaryTree<int>();

            TreeNode<int> root = new TreeNode<int>
            {
                Value = 1,
                Left = new TreeNode<int>
                {
                    Value = 3,
                    Left = new TreeNode<int>
                    {
                        Value = 2,
                        Left = new TreeNode<int> { Value = 9 }
                    },
                    Right = new TreeNode<int>
                    {
                        Value = 4,
                        Right = new TreeNode<int> { Value = 8 }
                    }
                },
                Right = new TreeNode<int>
                {
                    Value = 5,
                    Right = new TreeNode<int> { Value = 7 }
                }
            };

            bt.Root = root;

            Iterator.BinaryTreeInOrderIterator<int> iterator = new Iterator.BinaryTreeInOrderIterator<int>(bt);

            Assert.AreEqual(9, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(2, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(3, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(4, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(8, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(1, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(5, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(7, iterator.Current);

            Assert.IsFalse(iterator.MoveNext());
        }

        /// <summary>
        ///          1
        ///         / \
        ///        3   5
        ///       / \   \
        ///      2   4   7
        ///     /     \
        ///    9       8
        ///    
        [TestMethod]
        public void PostOrderIterative()
        {
            BinaryTree<int> bt = new BinaryTree<int>();

            TreeNode<int> root = new TreeNode<int>
            {
                Value = 1,
                Left = new TreeNode<int>
                {
                    Value = 3,
                    Left = new TreeNode<int>
                    {
                        Value = 2,
                        Left = new TreeNode<int> { Value = 9 }
                    },
                    Right = new TreeNode<int>
                    {
                        Value = 4,
                        Right = new TreeNode<int> { Value = 8 }
                    }
                },
                Right = new TreeNode<int>
                {
                    Value = 5,
                    Right = new TreeNode<int> { Value = 7 }
                }
            };

            bt.Root = root;

            Iterator.BinaryTreePostOrderIterator<int> iterator = new Iterator.BinaryTreePostOrderIterator<int>(bt);

            Assert.AreEqual(9, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(2, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(8, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(4, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(3, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(7, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(5, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(1, iterator.Current);
            
            Assert.IsFalse(iterator.MoveNext());
        }

        #endregion

        #region Deep Iterator

        [TestMethod]
        public void Empty() {
            Iterator.DeepIterator<int> iterator = new Iterator.DeepIterator<int>(new int[] { });

            Assert.IsFalse(iterator.MoveNext());
        }

        [TestMethod]
        public void Works()
        {
            Iterator.DeepIterator<int> iterator = new Iterator.DeepIterator<int>(new object[] 
                { 0, new object[] { 1, 2 }, 3, new object[] { 4, new object[] { 5, 6 } } }
            );

            Assert.AreEqual(0, iterator.Current);
            
            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(0, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(1, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(2, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(3, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(4, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(5, iterator.Current);

            Assert.IsTrue(iterator.MoveNext());
            Assert.AreEqual(6, iterator.Current);
        }

        #endregion

    }

}
