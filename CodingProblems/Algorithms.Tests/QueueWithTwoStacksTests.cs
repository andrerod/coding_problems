using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class QueueWithTwoStacksTests
    {
        [TestMethod]
        public void DequeWhenEmpty()
        {
            var queue = new QueueWithTwoStacks();

            var result = queue.Dequeue();
            Assert.IsNull(result);
        }

        [TestMethod]
        public void EnqueOneWhenEmpty()
        {
            const int value = 1;
            var queue = new QueueWithTwoStacks();

            queue.Enqueue(value);

            var result = queue.Dequeue();
            Assert.IsNotNull(result);
            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void EnqueMultiple()
        {
            const int first = 1;
            const int second = 2;
            var queue = new QueueWithTwoStacks();

            queue.Enqueue(first);
            queue.Enqueue(second);

            var resultFirst = queue.Dequeue();
            Assert.IsNotNull(resultFirst);
            Assert.AreEqual(first, resultFirst);

            var resultSecond = queue.Dequeue();
            Assert.IsNotNull(resultSecond);
            Assert.AreEqual(second, resultSecond);
        }
        
        [TestMethod]
        public void EnqueOneAfterEmptying()
        {
            const int first = 1;
            const int second = 2;
            var queue = new QueueWithTwoStacks();

            queue.Enqueue(first);
            queue.Dequeue();

            queue.Enqueue(second);

            var result = queue.Dequeue();
            Assert.IsNotNull(result);
            Assert.AreEqual(second, result);
        }

        [TestMethod]
        public void EnqueMultipleAfterEmptying()
        {
            const int first = 1;
            const int second = 2;
            const int third = 3;
            var queue = new QueueWithTwoStacks();

            queue.Enqueue(first);
            queue.Dequeue();

            queue.Enqueue(second);
            queue.Enqueue(third);

            var resultSecond = queue.Dequeue();
            Assert.IsNotNull(resultSecond);
            Assert.AreEqual(second, resultSecond);

            var resultThird = queue.Dequeue();
            Assert.IsNotNull(resultThird);
            Assert.AreEqual(third, resultThird);
        }    
    }
}
