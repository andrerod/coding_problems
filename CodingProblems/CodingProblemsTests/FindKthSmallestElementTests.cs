using CodingProblems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingProblemsTests
{
    [TestClass]
    public class FindKthSmallestElementTests
    {
        [TestMethod]
        public void FindElement()
        {
            TreeNode root = new TreeNode { Value = 5 };
            root.Left = new TreeNode { Value = 3 };
            root.Left.Left = new TreeNode { Value = 1 };

            var kthNode = KThSmallestElementInTree.FindKthSmallestElement(root, 2);
            Assert.AreEqual(3, kthNode.Value);
        }

        [TestMethod]
        public void FindNullElement()
        {
            TreeNode root = new TreeNode { Value = 5 };
            root.Left = new TreeNode { Value = 3 };
            root.Left.Left = new TreeNode { Value = 1 };

            var kthNode = KThSmallestElementInTree.FindKthSmallestElement(root, 4);
            Assert.IsNull(kthNode);
        }
    }
}
