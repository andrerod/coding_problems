using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    using System.Collections.Generic;

    using Algorithms.Implementation.Models;
    using Algorithms.Implementation.Models.Graphes;
    using System;

    [TestClass]
    public class GraphTests
    {

        #region DetectCircular

        [TestMethod]
        public void FalseHeadIsNull()
        {
            var graph = new Graph();

            var result = graph.DetectCircular();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FalseWhenJustHead()
        {
            var graph = new Graph { Head = new GraphNode { Value = 'A' } };

            var result = graph.DetectCircular();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FalseWhenNotCircular()
        {
            var graph = new Graph
            {
                Head = new GraphNode
                {
                    Value = 'A',
                    Edges = new List<GraphNode> {
                        new GraphNode { Value = 'B' }
                    }
                }
            };

            var result = graph.DetectCircular();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FalseWhenNotCircularComplex()
        {
            var head = new GraphNode { Value = 'A' };
            var childOne = new GraphNode { Value = 'B' };
            var childTwo = new GraphNode { Value = 'C' };
            var common = new GraphNode { Value = 'D' };
            head.Edges.Add(childOne);
            head.Edges.Add(childTwo);
            childOne.Edges.Add(common);
            childTwo.Edges.Add(common);

            var graph = new Graph
            {
                Head = head
            };

            var result = graph.DetectCircular();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TrueWhenCircular()
        {
            var head = new GraphNode { Value = 'A' };
            var child = new GraphNode { Value = 'B' };
            head.Edges.Add(child);
            child.Edges.Add(head);

            var graph = new Graph
            {
                Head = head
            };

            var result = graph.DetectCircular();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TrueWhenCircularIndirectly()
        {
            var head = new GraphNode { Value = 'A' };
            var childOne = new GraphNode { Value = 'B' };
            var childTwo = new GraphNode { Value = 'C' };
            head.Edges.Add(childOne);
            childOne.Edges.Add(childTwo);
            childTwo.Edges.Add(head);

            var graph = new Graph
            {
                Head = head
            };

            var result = graph.DetectCircular();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TrueWhenCircularInSubset()
        {
            var head = new GraphNode { Value = 'A' };
            var childOne = new GraphNode { Value = 'B' };
            var childTwo = new GraphNode { Value = 'C' };
            head.Edges.Add(childOne);
            childOne.Edges.Add(childTwo);
            childTwo.Edges.Add(childOne);

            var graph = new Graph
            {
                Head = head
            };

            var result = graph.DetectCircular();

            Assert.IsTrue(result);
        }

        #endregion

        #region ShowDepedency

        [TestMethod]
        public void EmptyCollectionWhenHeadIsNull()
        {
            var graph = new Graph();

            var result = graph.ShowDepedency();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void OneResultWithEmptyCollectionWhenJustHead()
        {
            var graph = new Graph { Head = new GraphNode { Value = 'A' }};

            var result = graph.ShowDepedency();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(0, result['A'].Count);
        }

        [TestMethod]
        public void SingleDependency()
        {
            var graph = new Graph
            {
                Head = new GraphNode
                {
                    Value = 'A',
                    Edges = new List<GraphNode> {
                        new GraphNode { Value = 'B' }
                    }
                }
            };

            var result = graph.ShowDepedency();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result['A'].Count);
            Assert.AreEqual('B', result['A'][0]);
            Assert.AreEqual(0, result['B'].Count);
        }

        [TestMethod]
        public void MultipleDependency()
        {
            var graph = new Graph { Head = new GraphNode
                {
                    Value = 'A',
                    Edges = new List<GraphNode> {
                        new GraphNode { Value = 'B' },
                        new GraphNode { Value = 'C' }
                    }
                } };

            var result = graph.ShowDepedency();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(2, result['A'].Count);
            Assert.AreEqual('B', result['A'][0]);
            Assert.AreEqual('C', result['A'][1]);
            Assert.AreEqual(0, result['B'].Count);
            Assert.AreEqual(0, result['C'].Count);
        }

        [TestMethod]
        public void ChildDependency()
        {
            var graph = new Graph
            {
                Head = new GraphNode
                {
                    Value = 'A',
                    Edges = new List<GraphNode> {
                        new GraphNode { 
                            Value = 'B', 
                            Edges = new List<GraphNode>
                            {
                                new GraphNode { Value = 'C' }
                            }}
                    }
                }
            };

            var result = graph.ShowDepedency();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(2, result['A'].Count);
            Assert.AreEqual('B', result['A'][0]);
            Assert.AreEqual('C', result['A'][1]);
            Assert.AreEqual(1, result['B'].Count);
            Assert.AreEqual('C', result['B'][0]);
            Assert.AreEqual(0, result['C'].Count);
        }

        [TestMethod]
        public void ChildDependencySame()
        {
            var common = new GraphNode { Value = 'D' };
            var graph = new Graph
            {
                Head = new GraphNode
                {
                    Value = 'A',
                    Edges = new List<GraphNode> {
                        new GraphNode { 
                            Value = 'B', 
                            Edges = new List<GraphNode>
                            {
                                new GraphNode { Value = 'C', Edges = { common }},
                                common
                            }}
                    }
                }
            };

            var result = graph.ShowDepedency();

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(3, result['A'].Count);
            Assert.AreEqual('B', result['A'][0]);
            Assert.AreEqual('C', result['A'][1]);
            Assert.AreEqual('D', result['A'][2]);
            Assert.AreEqual(2, result['B'].Count);
            Assert.AreEqual('C', result['B'][0]);
            Assert.AreEqual('D', result['B'][1]);
            Assert.AreEqual(1, result['C'].Count);
            Assert.AreEqual('D', result['C'][0]);
        }

        #endregion

        #region Job Dependency

        [TestMethod]
        public void SingleThreaded()
        {
            Graph.Job job5 = new Graph.Job { Name = "5", dependencies = new List<Graph.Job>() };
            Graph.Job job4 = new Graph.Job { Name = "4", dependencies = new List<Graph.Job>() { job5 } };
            Graph.Job job3 = new Graph.Job { Name = "3", dependencies = new List<Graph.Job>() { job4 } };
            Graph.Job job2 = new Graph.Job { Name = "2", dependencies = new List<Graph.Job>() { job3 } };
            Graph.Job job1 = new Graph.Job { Name = "1", dependencies = new List<Graph.Job>() { job2 } };

            List<Graph.Job> jobs = new List<Graph.Job> { job1, job2, job3, job4, job5 };

            var result = Graph.SingleThreaded(jobs);

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual("5", result[0]);
            Assert.AreEqual("4", result[1]);
            Assert.AreEqual("3", result[2]);
            Assert.AreEqual("2", result[3]);
            Assert.AreEqual("1", result[4]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SingleThreadedCyclic()
        {
            Graph.Job job5 = new Graph.Job { Name = "5", dependencies = new List<Graph.Job>() };
            Graph.Job job4 = new Graph.Job { Name = "4", dependencies = new List<Graph.Job>() { job5 } };
            Graph.Job job3 = new Graph.Job { Name = "3", dependencies = new List<Graph.Job>() { job4 } };
            Graph.Job job2 = new Graph.Job { Name = "2", dependencies = new List<Graph.Job>() { job3 } };
            Graph.Job job1 = new Graph.Job { Name = "1", dependencies = new List<Graph.Job>() {  } };
            job5.dependencies.Add(job2);

            List<Graph.Job> jobs = new List<Graph.Job> { job1, job2, job3, job4, job5 };

            Graph.SingleThreaded(jobs);
        }

        #endregion

        #region Topological Sort

        [TestMethod]
        public void TopologicalSort()
        {
            Node<char> a = new Node<char> { Value = 'A' };
            Node<char> b = new Node<char> { Value = 'B' };
            Node<char> c = new Node<char> { Value = 'C' };
            Node<char> d = new Node<char> { Value = 'D' };
            Node<char> e = new Node<char> { Value = 'E' };
            Node<char> f = new Node<char> { Value = 'F' };

            Graph<char> graph = new Graph<char>();
            graph.Nodes = new List<Node<char>> { a, b, c, d, e, f };
            graph.Edges = new List<Edge<char>>();

            graph.Edges.Add(new Edge<char> { Left = d, Right = b });
            graph.Edges.Add(new Edge<char> { Left = d, Right = c });
            graph.Edges.Add(new Edge<char> { Left = e, Right = c });
            graph.Edges.Add(new Edge<char> { Left = e, Right = f });
            graph.Edges.Add(new Edge<char> { Left = b, Right = a });
            graph.Edges.Add(new Edge<char> { Left = a, Right = f });

            var result = Graph.TopologicalSort(graph);

            Assert.IsNotNull(result);
            Assert.AreEqual(6, result.Count);
            Assert.AreEqual('F', result[0]);
            Assert.AreEqual('A', result[1]);
            Assert.AreEqual('C', result[2]);
            Assert.AreEqual('B', result[3]);
            Assert.AreEqual('E', result[4]);
            Assert.AreEqual('D', result[5]);
        }

        #endregion

    }
}

