using System;

using Algorithms.Implementation;
using Algorithms.Implementation.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class LinkedListTests
    {

        #region Remove

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WhenNullHeadInvalidOperationError()
        {
            var list = new LinkedList();

            list.Remove(1);
        }

        [TestMethod]
        public void CantFind()
        {
            var list = new LinkedList { Head = new Node { Value = 2 } };

            list.Remove(1);

            Assert.IsNotNull(list.Head);
        }

        [TestMethod]
        public void WhenOnlyHeadElement()
        {
            var list = new LinkedList { Head = new Node { Value = 1 } };

            list.Remove(1);

            Assert.IsNull(list.Head);
        }

        [TestMethod]
        public void WhenIsHeadElement()
        {
            var other = new Node { Value = 2 };
            var list = new LinkedList { Head = new Node { Value = 1, Next = other } };

            list.Remove(1);

            Assert.IsNotNull(list.Head);
            Assert.AreSame(other, list.Head);
        }

        [TestMethod]
        public void WhenIsHeadElementAndNext()
        {
            var other = new Node { Value = 2 };
            var next = new Node { Value = 1, Next = other };
            var list = new LinkedList { Head = new Node { Value = 1, Next = next } };

            list.Remove(1);

            Assert.IsNotNull(list.Head);
            Assert.AreSame(other, list.Head);
        }

        [TestMethod]
        public void WhenIsTailElement()
        {
            var tail = new Node { Value = 1 };
            var list = new LinkedList { Head = new Node { Value = 2, Next = tail } };

            list.Remove(1);

            Assert.IsNotNull(list.Head);
            Assert.IsNull(list.Head.Next);
        }

        [TestMethod]
        public void RemoveOne()
        {
            var tail = new Node { Value = 3 };
            var element = new Node { Value = 1, Next = tail };
            var head = new Node { Value = 2, Next = element };
            var list = new LinkedList { Head = head };

            list.Remove(1);

            Assert.IsNotNull(list.Head);
            Assert.AreSame(head, list.Head);
            Assert.AreSame(tail, head.Next);
        }

        [TestMethod]
        public void RemoveMultiple()
        {
            var tail = new Node { Value = 3 };
            var elementOne = new Node { Value = 1, Next = tail };
            var elementTwo = new Node { Value = 1, Next = elementOne };
            var head = new Node { Value = 2, Next = elementTwo };
            var list = new LinkedList { Head = head };

            list.Remove(1);

            Assert.IsNotNull(list.Head);
            Assert.AreSame(head, list.Head);
            Assert.AreSame(tail, head.Next);
        }

        #endregion

        #region Reverse

        [TestMethod]
        public void NullHeadNoError()
        {
            var list = new LinkedList();

            list.Reverse();
        }

        [TestMethod]
        public void JustHead()
        {
            var list = new LinkedList { Head = new Node() };

            list.Reverse();

            Assert.IsNotNull(list.Head);
        }

        [TestMethod]
        public void ReverseTwoItems()
        {
            var second = new Node();
            var head = new Node { Next = second };
            var list = new LinkedList { Head = head };

            list.Reverse();

            Assert.IsNotNull(list.Head);
            Assert.AreSame(second, list.Head);
            Assert.AreSame(head, second.Next);
        }

        [TestMethod]
        public void ReverseMultipleItems()
        {
            var third = new Node();
            var second = new Node { Next = third };
            var head = new Node { Next = second };
            var list = new LinkedList { Head = head };

            list.Reverse();

            Assert.IsNotNull(list.Head);
            Assert.AreSame(third, list.Head);
            Assert.AreSame(second, third.Next);
            Assert.AreSame(head, second.Next);
        }

        #endregion

        #region Convert To Bst 

        [TestMethod]
        public void ConvertToBst()
        {
            Node one = new Node { Value = 1 };
            Node two = new Node { Value = 2 };
            Node three = new Node { Value = 3 };
            Node four = new Node { Value = 4 };
            Node five = new Node { Value = 5 };
            Node six = new Node { Value = 6 };

            one.Next = two;
            two.Next = three;
            three.Next = four;
            four.Next = five;
            five.Next = six;

            LinkedList list = new LinkedList { Head = one };

            TreeNode<int> bst = list.ConvertToBst<int>();

            Assert.AreEqual(3, bst.Value);
            Assert.AreEqual(1, bst.Left.Value);
            Assert.AreEqual(2, bst.Left.Right.Value);
            Assert.AreEqual(5, bst.Right.Value);
            Assert.AreEqual(4, bst.Right.Left.Value);
            Assert.AreEqual(6, bst.Right.Right.Value);
        }

        #endregion

    }
}
