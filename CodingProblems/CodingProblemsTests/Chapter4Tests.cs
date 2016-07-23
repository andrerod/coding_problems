using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingProblems;
using System.Linq;

namespace CodingProblemsTests
{
    [TestClass]
    public class Chapter4Tests
    {
        [TestMethod]
        public void Problem4Tests()
        {
            TreeNode root = new TreeNode { Value = 3 };
            root.Left = new TreeNode { Value = 2 };
            root.Left.Left = new TreeNode { Value = 1 };
            root.Right = new TreeNode { Value = 4 };

            var result = Chapter4.InLevelProblem4(root);
            Assert.AreEqual(3, result[0][0].Value);
            Assert.AreEqual(2, result[1][0].Value);
            Assert.AreEqual(4, result[1][1].Value);
            Assert.AreEqual(1, result[2][0].Value);
        }

        [TestMethod]
        public void InOrderTests()
        {
            TreeNode root = new TreeNode { Value = 3 };
            root.Left = new TreeNode { Value = 2 };
            root.Left.Left = new TreeNode { Value = 1 };
            root.Right = new TreeNode { Value = 4 };

            var result = Chapter4.InOrder(root);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(3, result[2]);
            Assert.AreEqual(4, result[3]);
        }

        [TestMethod]
        public void InOrderIterativeTests()
        {
            TreeNode root = new TreeNode { Value = 20 };
            root.Left = new TreeNode { Value = 10 };
            root.Left.Left = new TreeNode { Value = 5 };
            root.Left.Left.Left = new TreeNode { Value = 3 };
            root.Left.Left.Right = new TreeNode { Value = 7 };
            root.Left.Right = new TreeNode { Value = 15 };
            root.Left.Right.Right = new TreeNode { Value = 17 };
            root.Right = new TreeNode { Value = 30 };

            var result = Chapter4.InOrderIterative(root);
            Assert.AreEqual(3, result[0]);
            Assert.AreEqual(5, result[1]);
            Assert.AreEqual(7, result[2]);
            Assert.AreEqual(10, result[3]);
            Assert.AreEqual(15, result[4]);
            Assert.AreEqual(17, result[5]);
            Assert.AreEqual(20, result[6]);
            Assert.AreEqual(30, result[7]);
        }

        [TestMethod]
        public void Problem2Tests()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var tree = Chapter4.Problem2(array);
            Assert.AreEqual(4, tree.Value);
            Assert.AreEqual(2, tree.Left.Value);
            Assert.AreEqual(1, tree.Left.Left.Value);
            Assert.AreEqual(3, tree.Left.Right.Value);
            Assert.AreEqual(6, tree.Right.Value);
            Assert.AreEqual(5, tree.Right.Left.Value);
            Assert.AreEqual(7, tree.Right.Right.Value);
        }
    }
}
