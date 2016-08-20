using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Implementation;
using System.Collections.Generic;

namespace Algorithms.Tests
{
    [TestClass]
    public class PriorityQueueTests
    {
        ///
        ///                 4
        ///                / \
        ///               4   8
        ///              / \ / \
        ///             9  4 12 9
        ///            / \
        ///           11 13
        ///           
        [TestMethod]
        public void AddMin()
        {
            PriorityQueue<int> q = new PriorityQueue<int>((i, j) => i.CompareTo(j));

            q.Storage = new List<int> { 4, 4, 8, 9, 4, 12, 9, 11, 13 };

            q.Add(7);

            Assert.AreEqual(10, q.Storage.Count);
            Assert.AreEqual(7, q.Storage[9]);

            q.Add(10);

            Assert.AreEqual(11, q.Storage.Count);
            Assert.AreEqual(10, q.Storage[10]);

            q.Add(5);

            Assert.AreEqual(12, q.Storage.Count);
            Assert.AreEqual(5, q.Storage[2]);
            Assert.AreEqual(8, q.Storage[5]);
            Assert.AreEqual(12, q.Storage[11]);
        }

        /// <summary>
        ///            11
        ///           /  \     
        ///          5    8
        ///         / \         
        ///        3   4
        /// </summary>
        [TestMethod]
        public void AddMax()
        {
            PriorityQueue<int> q = new PriorityQueue<int>((i, j) => j.CompareTo(i));

            q.Storage = new List<int> { 11, 5, 8, 3, 4 };

            q.Add(15);

            Assert.AreEqual(6, q.Storage.Count);
            Assert.AreEqual(15, q.Storage[0]);
            Assert.AreEqual(11, q.Storage[2]);
            Assert.AreEqual(8, q.Storage[5]);
        }

        [TestMethod]
        public void ExtractRootMin()
        {
            PriorityQueue<int> q = new PriorityQueue<int>((i, j) => i.CompareTo(j));

            q.Storage = new List<int> { 4, 4, 8, 9, 4, 12, 9, 11, 13 };

            int min = q.ExtractRoot();

            Assert.AreEqual(4, min);
            Assert.AreEqual(8, q.Storage.Count);
            Assert.AreEqual(4, q.Storage[0]);
            Assert.AreEqual(4, q.Storage[1]);
            Assert.AreEqual(13, q.Storage[4]);
        }

        /// <summary>
        ///            11
        ///           /  \     
        ///          5    8
        ///         / \         
        ///        3   4
        /// </summary>
        [TestMethod]
        public void ExtractRootMax()
        {
            PriorityQueue<int> q = new PriorityQueue<int>((i, j) => j.CompareTo(i));

            q.Storage = new List<int> { 11, 5, 8, 3, 4 };

            int max = q.ExtractRoot();

            Assert.AreEqual(11, max);
            Assert.AreEqual(4, q.Storage.Count);
            Assert.AreEqual(8, q.Storage[0]);
            Assert.AreEqual(4, q.Storage[2]);
        }

    }
}
