using System.Collections.Generic;

namespace CodingProblems
{
    public class GraphMine
    {
        public Dictionary<string, Dictionary<string, int>> Vertices { get; set; }

        public GraphMine()
        {
            Vertices = new Dictionary<string, Dictionary<string, int>>();
        }

        public void Add(string name, Dictionary<string, int> paths)
        {
            Vertices.Add(name, paths);
        }

        public int ShortestDistance(string origin, string destination)
        {
            MinHeap<GraphEdge<string>> minDistances = new MinHeap<GraphEdge<string>>();
            var distances = new Dictionary<string, GraphEdge<string>>();

            foreach (var node in Vertices)
            {
                var edge = new GraphEdge<string> { Node = node.Key, Distance = node.Key == origin ? 0 : int.MaxValue };
                minDistances.Add(edge);
                distances.Add(node.Key, edge);
            }

            while (minDistances.Length > 0)
            {
                var currentNode = minDistances.PopMin();

                if (currentNode.Node == destination)
                {
                    // Shortest path found
                    return currentNode.Distance;
                }

                if (currentNode.Distance == int.MaxValue)
                {
                    // Impossible path
                    return int.MaxValue;
                }

                foreach (var adjacent in Vertices[currentNode.Node])
                {
                    var newDistance = currentNode.Distance + adjacent.Value;
                    if (newDistance < distances[adjacent.Key].Distance)
                    {
                        distances[adjacent.Key].Distance = newDistance;
                        minDistances.Heapify();
                    }
                }
            }

            return int.MaxValue;
        }
    }
}
