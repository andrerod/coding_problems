using Algorithms.Implementation;
using Algorithms.Implementation.Models.Graphes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Tests
{

    [TestClass]
    public class ShortestPathTests
    {

        /// <summary>
        ///         3---5
        ///       / | \ |
        ///      /  |  \|
        ///    1----2---4
        /// </summary>
        [TestMethod]
        public void TestBfs()
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            graph.Add(1, new List<int> { 2, 3 });
            graph.Add(2, new List<int> { 1, 3, 4 });
            graph.Add(3, new List<int> { 1, 2, 4, 5 });
            graph.Add(4, new List<int> { 2, 3, 5 });
            graph.Add(5, new List<int> { 3, 4 });

            var result = ShortestPath.BFS(graph, 1, 5);

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(3, result[1]);
            Assert.AreEqual(5, result[2]);
        }

        /// <summary>
        ///         3---5
        ///       / | \ |
        ///      /  |  \|
        ///    1----2---4
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestBfsNoPath()
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            graph.Add(1, new List<int> { 2, 3 });
            graph.Add(2, new List<int> { 1, 3, 4 });
            graph.Add(3, new List<int> { 1, 2, 4, 5 });
            graph.Add(4, new List<int> { 2, 3, 5 });
            graph.Add(5, new List<int> { 3, 4 });

            var result = ShortestPath.BFS(graph, 1, 6);
        }

        [TestMethod]
        public void TestDjikstra()
        {
            Graph<int> graph = new Graph<int> { Nodes = new List<Node<int>>(), Edges = new List<Edge<int>>() };
            graph.Nodes.Add(new Node<int> { Value = 1 });
            graph.Nodes.Add(new Node<int> { Value = 2 });
            graph.Nodes.Add(new Node<int> { Value = 3 });
            graph.Nodes.Add(new Node<int> { Value = 4 });
            graph.Nodes.Add(new Node<int> { Value = 5 });

            graph.Edges.Add(new Edge<int> { Left = graph.Nodes[0], Right = graph.Nodes[1], Weight = 10 });
            graph.Edges.Add(new Edge<int> { Left = graph.Nodes[0], Right = graph.Nodes[3], Weight = 5 });
            graph.Edges.Add(new Edge<int> { Left = graph.Nodes[1], Right = graph.Nodes[2], Weight = 1 });
            graph.Edges.Add(new Edge<int> { Left = graph.Nodes[1], Right = graph.Nodes[3], Weight = 2 });
            graph.Edges.Add(new Edge<int> { Left = graph.Nodes[2], Right = graph.Nodes[4], Weight = 4 });
            graph.Edges.Add(new Edge<int> { Left = graph.Nodes[3], Right = graph.Nodes[1], Weight = 3 });
            graph.Edges.Add(new Edge<int> { Left = graph.Nodes[3], Right = graph.Nodes[2], Weight = 9 });
            graph.Edges.Add(new Edge<int> { Left = graph.Nodes[3], Right = graph.Nodes[4], Weight = 2 });
            graph.Edges.Add(new Edge<int> { Left = graph.Nodes[4], Right = graph.Nodes[0], Weight = 7 });
            graph.Edges.Add(new Edge<int> { Left = graph.Nodes[4], Right = graph.Nodes[2], Weight = 6 });

            var result = ShortestPath.Djikstra(graph, 1, 3);

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(4, result[1]);
            Assert.AreEqual(2, result[2]);
            Assert.AreEqual(3, result[3]);
        }

        [TestMethod]
        public void WordLadder()
        {
            var result = ShortestPath.WordLadder(new List<string> { "hot", "dot", "dog", "lot", "log" }, "hit", "cog");

            Assert.AreEqual(5, result.Count);
            Assert.AreEqual("hit", result[0]);
            Assert.AreEqual("hot", result[1]);
            Assert.AreEqual("dot", result[2]);
            Assert.AreEqual("dog", result[3]);
            Assert.AreEqual("cog", result[4]);
        }

        [TestMethod]
        public void WordLadder2()
        {
            var result = ShortestPath.WordLadder2("hit", "cog", new HashSet<string> { "hot", "dot", "dog", "lot", "log" });

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("hit", result[0][0]);
            Assert.AreEqual("hot", result[0][1]);
            Assert.AreEqual("dot", result[0][2]);
            Assert.AreEqual("dog", result[0][3]);
            Assert.AreEqual("cog", result[0][4]);

            Assert.AreEqual("hit", result[1][0]);
            Assert.AreEqual("hot", result[1][1]);
            Assert.AreEqual("lot", result[1][2]);
            Assert.AreEqual("log", result[1][3]);
            Assert.AreEqual("cog", result[1][4]);
        }

    }

}
