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

        [TestMethod]
        public void DetectLoopsTest()
        {
            Node nodes = new Node
            {
                Value = 1,
                Next = new Node
                {
                    Value = 2,
                    Next = new Node
                    {
                        Value = 3,
                        Next = new Node
                        {
                            Value = 4
                        }
                    }
                }
            };

            nodes.Next.Next.Next.Next = nodes;

            Assert.IsTrue(Chapter2.DetectLoops(nodes));
        }

        [TestMethod]
        public void DetectNoLoopsTest()
        {
            Node nodes = new Node
            {
                Value = 1,
                Next = new Node
                {
                    Value = 2,
                    Next = new Node
                    {
                        Value = 3,
                        Next = new Node
                        {
                            Value = 4
                        }
                    }
                }
            };

            Assert.IsFalse(Chapter2.DetectLoops(nodes));
        }
    }
}
