using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms.Implementation.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Implementation;

namespace Algorithms.Tests
{
    [TestClass]
    public class CircularLinkedListTests
    {
        #region Detect

        [TestMethod]
        public void FalseIfHeadNull()
        {
            var list = new CircularLinkedList();

            Assert.IsFalse(list.Detect());
        }

        [TestMethod]
        public void TrueSingleCircular()
        {
            var list = new CircularLinkedList();
            list.InsertAtEnd(1);

            Assert.IsTrue(list.Detect());
        }

        [TestMethod]
        public void TrueMultipleItemsCircular()
        {
            var list = new CircularLinkedList();
            list.InsertAtEnd(1);
            list.InsertAtEnd(2);

            Assert.IsTrue(list.Detect());
        }

        [TestMethod]
        public void TrueLoopAtTheEnd()
        {
            var list = new CircularLinkedList();

            var third = new Node {Value = 3};
            var second = new Node { Value = 2, Next = third };
            var head = new Node { Value = 1, Next = second };
            third.Next = second;

            list.Head = head;

            Assert.IsTrue(list.Detect());
        }

        [TestMethod]
        public void FalseLinkedListOneItem()
        {
            var list = new CircularLinkedList();

            var head = new Node { Value = 1 };

            list.Head = head;

            Assert.IsFalse(list.Detect());
        }

        [TestMethod]
        public void FalseLinkedListMultipleItems()
        {
            var list = new CircularLinkedList();

            var second = new Node { Value = 2 };
            var head = new Node { Value = 1, Next = second };

            list.Head = head;

            Assert.IsFalse(list.Detect());
        }

        #endregion

        #region InsertSorted

        [TestMethod]
        public void HandleNullHeadSorted()
        {
            var list = new CircularLinkedList();
            list.InsertSorted(1);

            var head = list.Head;
            Assert.IsNotNull(head);
            Assert.AreEqual(1, head.Value);
        }

        [TestMethod]
        public void HandleValueSmallerThanHead()
        {
            var list = new CircularLinkedList();
            list.InsertSorted(5);
            list.InsertSorted(2);

            var head = list.Head;
            Assert.IsNotNull(head);
            Assert.AreEqual(2, head.Value);

            var next = head.Next;
            Assert.IsNotNull(next);
            Assert.AreEqual(5, next.Value);

            var circular = next.Next;
            Assert.IsNotNull(circular);
            Assert.AreEqual(2, circular.Value);
        }

        [TestMethod]
        public void HandleValueLargerThanHead()
        {
            var list = new CircularLinkedList();
            list.InsertSorted(1);
            list.InsertSorted(2);

            var head = list.Head;
            Assert.IsNotNull(head);
            Assert.AreEqual(1, head.Value);

            var next = head.Next;
            Assert.IsNotNull(next);
            Assert.AreEqual(2, next.Value);

            var circular = next.Next;
            Assert.IsNotNull(circular);
            Assert.AreEqual(1, circular.Value);
        }

        [TestMethod]
        public void HandleValueLargerThanAll()
        {
            var list = new CircularLinkedList();
            list.InsertSorted(1);
            list.InsertSorted(2);
            list.InsertSorted(3);

            var head = list.Head;
            Assert.IsNotNull(head);
            Assert.AreEqual(1, head.Value);

            var second = head.Next;
            Assert.IsNotNull(second);
            Assert.AreEqual(2, second.Value);

            var third = second.Next;
            Assert.IsNotNull(third);
            Assert.AreEqual(3, third.Value);

            var circular = third.Next;
            Assert.IsNotNull(circular);
            Assert.AreEqual(1, circular.Value);
        }

        [TestMethod]
        public void HandleValueInTheMiddle()
        {
            var list = new CircularLinkedList();
            list.InsertSorted(1);
            list.InsertSorted(3);
            list.InsertSorted(2);

            var head = list.Head;
            Assert.IsNotNull(head);
            Assert.AreEqual(1, head.Value);

            var second = head.Next;
            Assert.IsNotNull(second);
            Assert.AreEqual(2, second.Value);

            var third = second.Next;
            Assert.IsNotNull(third);
            Assert.AreEqual(3, third.Value);

            var circular = third.Next;
            Assert.IsNotNull(circular);
            Assert.AreEqual(1, circular.Value);
        }
   
        #endregion

        #region InsertAtEnd

        [TestMethod]
        public void HandleNullHead()
        {
            var list = new CircularLinkedList(); 
            list.InsertAtEnd(1);

            var head = list.Head;
            Assert.IsNotNull(head);
            Assert.AreEqual(1, head.Value);
        }

        [TestMethod]
        public void InsertValueOnlyOne()
        {
            var list = new CircularLinkedList();
            list.InsertAtEnd(1);
            list.InsertAtEnd(2);

            var head = list.Head;
            Assert.IsNotNull(head);
            Assert.AreEqual(1, head.Value);

            var next = head.Next;
            Assert.IsNotNull(next);
            Assert.AreEqual(2, next.Value);

            var circular = next.Next;
            Assert.IsNotNull(circular);
            Assert.AreEqual(1, circular.Value);
        }

        [TestMethod]
        public void InsertValueCircular()
        {
            var list = new CircularLinkedList();
            list.InsertAtEnd(1);
            list.InsertAtEnd(2);
            list.InsertAtEnd(3);

            var head = list.Head;
            Assert.IsNotNull(head);
            Assert.AreEqual(1, head.Value);

            var second = head.Next;
            Assert.IsNotNull(second);
            Assert.AreEqual(2, second.Value);

            var third = second.Next;
            Assert.IsNotNull(third);
            Assert.AreEqual(3, third.Value);

            var circular = third.Next;
            Assert.IsNotNull(circular);
            Assert.AreEqual(1, circular.Value);
        }

        #endregion
    }
}
