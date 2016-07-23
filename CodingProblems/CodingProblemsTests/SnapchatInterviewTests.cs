using CodingProblems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingProblemsTests
{
    [TestClass]
    public class SnapchatInterviewTests
    {
        [TestMethod]
        public void TestProblem1a()
        {
            var numbers = new int[] { 1, 1, 1, 2, 3 };
            var res = SnapChatInterview.Problem1(numbers);
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void TestProblem1b()
        {
            var numbers = new int[] { 1, 2, 3 };
            var res = SnapChatInterview.Problem1(numbers);
            Assert.AreEqual(-1, res);
        }

        [TestMethod]
        public void TestProblem1c()
        {
            var numbers = new int[] { 1, 2, 3, 1, 1 };
            var res = SnapChatInterview.Problem1(numbers);
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void TestProblem1d()
        {
            var numbers = new int[] { 1, 1 };
            var res = SnapChatInterview.Problem1(numbers);
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void TestProblem2a()
        {
            var numbers = new int[] { 1, 1, 1, 2, 3 };
            var res = SnapChatInterview.Problem2(numbers);
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void TestProblem2c()
        {
            var numbers = new int[] { 1, 2, 3, 1, 1 };
            var res = SnapChatInterview.Problem2(numbers);
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void TestProblem2d()
        {
            var numbers = new int[] { 1, 1 };
            var res = SnapChatInterview.Problem2(numbers);
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void TestProblem3a()
        {
            var numbers = new int[] { 1, 1, 1, 2, 3 };
            var res = SnapChatInterview.Problem3(numbers);
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void TestProblem3c()
        {
            var numbers = new int[] { 1, 2, 3, 1 };
            var res = SnapChatInterview.Problem3(numbers);
            Assert.AreEqual(-1, res);
        }

        [TestMethod]
        public void FindPathTest1()
        {
            var numbers = new int[] { 3, 1, 5, 1, 0 };
            var res = SnapChatInterview.FindPath(numbers);
            var firstPosition = res.Pop();
            Assert.AreEqual(0, firstPosition);

            var secondPosition = res.Pop();
            Assert.AreEqual(3, secondPosition);

            var thirdPosition = res.Pop();
            Assert.AreEqual(4, thirdPosition);
        }
    }
}
