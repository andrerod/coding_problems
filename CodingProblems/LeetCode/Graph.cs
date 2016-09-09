using Algorithms.Implementation;
using System.Collections.Generic;
using static ClassLibrary2.GraphAlgorithms;

namespace ClassLibrary2
{
    public class GraphAlgorithms
    {
        #region Topological sort

        public class Node<T>
        {
            public T Value { get; set; }

            public List<Node<T>> DependsOn { get; set; }

            public List<Node<T>> DependentBy { get; set; }

            public Node(T value)
            {
                Value = value;
                DependsOn = new List<Node<T>>();
                DependentBy = new List<Node<T>>();
            }
        }

        public class Graph<T>
        {
            public Dictionary<T, Node<T>> Nodes { get; set; }

            public Graph()
            {
                Nodes = new Dictionary<T, Node<T>>();
            }
        }

        public static List<Node<char>> TopologicalSort()
        {
            var aNode = new Node<char>('A');
            var bNode = new Node<char>('B');
            var cNode = new Node<char>('C');
            var dNode = new Node<char>('D');
            aNode.DependsOn.Add(bNode);
            bNode.DependentBy.Add(aNode);
            aNode.DependsOn.Add(cNode);
            cNode.DependentBy.Add(aNode);
            cNode.DependsOn.Add(dNode);
            dNode.DependentBy.Add(cNode);

            // cycle
            dNode.DependsOn.Add(cNode);
            cNode.DependentBy.Add(dNode);

            var graph = new Graph<char>();
            graph.Nodes.Add('A', aNode);
            graph.Nodes.Add('B', bNode);
            graph.Nodes.Add('C', cNode);
            graph.Nodes.Add('D', dNode);

            var toVisit = new Queue<Node<char>>();
            var ordered = new List<Node<char>>();
            foreach (var node in graph.Nodes.Values)
            {
                if (node.DependsOn.Count == 0)
                {
                    toVisit.Enqueue(node);
                }
            }

            while (toVisit.Count > 0)
            {
                var currentNode = toVisit.Dequeue();
                ordered.Add(currentNode);

                foreach (var dependentNode in currentNode.DependentBy)
                {
                    dependentNode.DependsOn.Remove(currentNode);
                    if (dependentNode.DependsOn.Count == 0)
                    {
                        toVisit.Enqueue(dependentNode);
                    }
                }
            }

            if (ordered.Count < graph.Nodes.Count)
            {
                return null;
            }

            return ordered;
        }

        #endregion

        #region shortest path

        public static List<int> ShortestPath(int[] input)
        {
            var bestDistanceToPosition = new Dictionary<int, int>();
            var nodesToVisit = new PriorityQueue<int>((a, b) => bestDistanceToPosition[a] - bestDistanceToPosition[b]);
            var path = new List<int>();
            var previous = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0)
                {
                    bestDistanceToPosition[i] = 0;
                }
                else
                {
                    bestDistanceToPosition[i] = int.MaxValue;
                }

                nodesToVisit.Add(i);
            }

            while (nodesToVisit.Storage.Count > 0)
            {
                // Find node with minimum distance to
                var closestNode = nodesToVisit.ExtractRoot();
                if (closestNode == (input.Length - 1))
                {
                    path = new List<int>();
                    while (closestNode != 0)
                    {
                        path.Add(closestNode);
                        closestNode = previous[closestNode];
                    }

                    path.Reverse();
                    return path;
                }

                if (bestDistanceToPosition[closestNode] == int.MaxValue)
                {
                    return null;
                }

                for (int i = 1; i <= input[closestNode] && closestNode + i < input.Length; i++)
                {
                    var distanceToNext = bestDistanceToPosition[closestNode] + 1;
                    if (distanceToNext < bestDistanceToPosition[closestNode + i])
                    {
                        bestDistanceToPosition[closestNode + i] = distanceToNext;
                        // TODO: need to bubble up the vertex in the heap

                        previous[closestNode + i] = closestNode;
                    }
                }
            }

            return null;
        }

        #endregion
    }
}
