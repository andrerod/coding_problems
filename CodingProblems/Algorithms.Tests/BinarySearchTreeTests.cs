using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms.Implementation;
using Algorithms.Implementation.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void TrueIfNull()
        {
            var tree = new BinarySearchTree();

            Assert.IsTrue(tree.IsValidBST());
        }

        [TestMethod]
        public void TrueIfRootOnly()
        {
            var tree = new BinarySearchTree
                           {
                               Root = new TreeNode<int> {Value = 1}
                           };

            Assert.IsTrue(tree.IsValidBST());
        }

        [TestMethod]
        public void TrueSmallerLeft()
        {
            var tree = new BinarySearchTree
            {
                Root = new TreeNode<int> { Value = 5, Left = new TreeNode<int> { Value = 2 } }
            };

            Assert.IsTrue(tree.IsValidBST());
        }

        [TestMethod]
        public void FalseLargerLeft()
        {
            var tree = new BinarySearchTree
            {
                Root = new TreeNode<int> { Value = 5, Left = new TreeNode<int> { Value = 7 } }
            };

            Assert.IsFalse(tree.IsValidBST());
        }

        [TestMethod]
        public void TrueLargerRight()
        {
            var tree = new BinarySearchTree
            {
                Root = new TreeNode<int> { Value = 5, Right = new TreeNode<int> { Value = 7 } }
            };

            Assert.IsTrue(tree.IsValidBST());
        }

        [TestMethod]
        public void FalseSmallerRight()
        {
            var tree = new BinarySearchTree
            {
                Root = new TreeNode<int> { Value = 5, Right = new TreeNode<int> { Value = 2 } }
            };

            Assert.IsFalse(tree.IsValidBST());
        }

        [TestMethod]
        public void TrueMultiLevel()
        {
            /*
             *       5
             *    2
             *  1   3
             */
            var tree = new BinarySearchTree
            {
                Root = new TreeNode<int> { Value = 5, 
                    Left = new TreeNode<int> { Value = 2, 
                        Left = new TreeNode<int> { Value = 1 },
                        Right = new TreeNode<int> { Value = 3 }
                    }
                }
            };

            Assert.IsTrue(tree.IsValidBST());
        }

        [TestMethod]
        public void FalseMultiLevelAbsoluteLimit()
        {
            /*
             *       5
             *    2
             *  1   8
             */
            var tree = new BinarySearchTree
            {
                Root = new TreeNode<int> { Value = 5, 
                    Left = new TreeNode<int> { Value = 2, 
                        Left = new TreeNode<int> { Value = 1 }, 
                        Right = new TreeNode<int> { Value = 8 } } }
            };

            Assert.IsFalse(tree.IsValidBST());
        }

        #region Serialize & Deserialize

        [TestMethod]
        public void SerializeDeserialize()
        {
            /*
             *       5
             *    2
             *  1   3
             */
            var tree = new BinarySearchTree
            {
                Root = new TreeNode<int>
                {
                    Value = 5,
                    Left = new TreeNode<int>
                    {
                        Value = 2,
                        Left = new TreeNode<int> { Value = 1 },
                        Right = new TreeNode<int> { Value = 3 }
                    }
                }
            };

            List<int> data = tree.SerializeTree();

            tree.Deserialize(data);

            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(5, tree.Root.Value);
            Assert.AreEqual(2, tree.Root.Left.Value);
            Assert.AreEqual(1, tree.Root.Left.Left.Value);
            Assert.AreEqual(3, tree.Root.Left.Right.Value);
        }

        #endregion

        #region Next Smallest

        [TestMethod]
        public void NextSmallest()
        {
            /*
             *       5
             *    2
             *  1   3
             */
            var tree = new BinarySearchTree
            {
                Root = new TreeNode<int>
                {
                    Value = 5,
                    Left = new TreeNode<int>
                    {
                        Value = 2,
                        Left = new TreeNode<int> { Value = 1 },
                        Right = new TreeNode<int> { Value = 3 }
                    }
                }
            };

            Assert.AreEqual(3, tree.NextSmallest(2));
            Assert.AreEqual(2, tree.NextSmallest(1));
            Assert.AreEqual(5, tree.NextSmallest(3));
            Assert.AreEqual(-1, tree.NextSmallest(5));
        }

        #endregion

    }
}
