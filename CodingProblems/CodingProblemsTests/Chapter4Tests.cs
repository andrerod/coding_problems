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

            var result = Chapter4.Problem4(root);
            Assert.AreEqual(3, result[0][0].Value);
            Assert.AreEqual(2, result[1][0].Value);
            Assert.AreEqual(4, result[1][1].Value);
            Assert.AreEqual(1, result[2][0].Value);
        }
    }
}
