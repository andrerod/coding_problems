using Algorithms.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Tests
{
    [TestClass]
    public class BackTrackingTests
    {

        /// <summary>
        /// (0)--(1)--(2)
        ///  |   / \   |
        ///  |  /   \  | 
        ///  | /     \ |
        /// (3)-------(4)
        /// </summary>
        [TestMethod]
        public void DetectTrue()
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            graph.Add(0, new List<int> { 1, 3 });
            graph.Add(1, new List<int> { 0, 2, 3, 4 });
            graph.Add(2, new List<int> { 1, 4 });
            graph.Add(3, new List<int> { 0, 1, 4 });
            graph.Add(4, new List<int> { 1, 2, 3 });

            Assert.IsTrue(BackTracking.HamiltonianExists(graph));
        }

        /// <summary>
        /// (0)--(1)--(2)
        ///  |   / \   |
        ///  |  /   \  | 
        ///  | /     \ |
        /// (3)       (4) 
        /// </summary>
        [TestMethod]
        public void DetectFalse()
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            graph.Add(0, new List<int> { 1, 3 });
            graph.Add(1, new List<int> { 0, 2, 3, 4 });
            graph.Add(2, new List<int> { 1, 4 });
            graph.Add(3, new List<int> { 0, 1 });
            graph.Add(4, new List<int> { 1, 2 });

            Assert.IsFalse(BackTracking.HamiltonianExists(graph));
        }

        [TestMethod]
        public void Can1Win()
        {            
            Assert.IsTrue(BackTracking.Can1Win(1, 1));
            Assert.IsTrue(BackTracking.Can1Win(2, 1));
            Assert.IsTrue(BackTracking.Can1Win(3, 5));
            Assert.IsTrue(BackTracking.Can1Win(5, 12));
        }

        [TestMethod]
        public void Can1Win3_4()
        {
            Assert.IsFalse(BackTracking.Can1Win(3, 4));
        }

    }
}
