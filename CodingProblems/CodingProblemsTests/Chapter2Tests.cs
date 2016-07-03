using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingProblems;
using System.Linq;

namespace CodingProblemsTests
{
    [TestClass]
    public class Chapter2Tests
    {
        [TestMethod]
        public void Problem2Test1()
        {
            Node newNode = new Node { Value = 1 };
            newNode.AddToTail(new Node { Value = 2 });
            newNode.AddToTail(new Node { Value = 5 });

            newNode = Chapter2.Problem2(newNode, 2);
            Assert.IsFalse(newNode.Contains(2));
            Assert.IsTrue(newNode.Contains(1));
            Assert.IsTrue(newNode.Contains(5));
        }

        [TestMethod]
        public void Problem2Test2()
        {
            Node newNode = new Node { Value = 1 };

            newNode = Chapter2.Problem2(newNode, 1);
            Assert.IsNull(newNode);
        }

        [TestMethod]
        public void Problem2Test3()
        {
            Node newNode = new Node { Value = 1 };
            newNode.AddToTail(new Node { Value = 2 });

            newNode = Chapter2.Problem2(newNode, 2);
            Assert.IsFalse(newNode.Contains(1));
            Assert.IsTrue(newNode.Contains(2));
        }
    }
}
