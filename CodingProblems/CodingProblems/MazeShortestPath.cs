using System;
using System.Collections.Generic;

namespace CodingProblems
{
    public class MazeShortestPath
    {
        public int[,] Maze { get; set; }

        public MazeShortestPath(int [,] maze)
        {
            Maze = maze;
        }

        public int ShortestPath(int startX, int startY, int endX, int endY)
        {
            GraphEdge<Tuple<int, int>>[,] distances = new GraphEdge<Tuple<int, int>>[Maze.GetLength(0), Maze.GetLength(1)];
            var minDistances = new MinHeap<GraphEdge<Tuple<int, int>>>();
            List<Tuple<int, int>> nodesToVisit = new List<Tuple<int, int>>();

            for (int i = 0; i < Maze.GetLength(0); i++)
            {
                for (int j = 0; j < Maze.GetLength(1); j++)
                {
                    if (Maze[i, j] == 0)
                    {
                        var node = new Tuple<int, int>(i, j);
                        var distance = 0;
                        if (i != startX || j != startY)
                        {
                            distance = int.MaxValue;
                        }

                        distances[i, j] = new GraphEdge<Tuple<int, int>> { Node = node, Distance = distance };
                        minDistances.Add(distances[i, j]);
                        nodesToVisit.Add(node);
                    }
                }
            }

            while (nodesToVisit.Count != 0)
            {
                var currentNode = minDistances.PopMin();
                nodesToVisit.Remove(currentNode.Node);

                if (currentNode.Node.Item1 == endX && currentNode.Node.Item2 == endY)
                {
                    return currentNode.Distance;
                }

                if (currentNode.Distance == int.MaxValue)
                {
                    return int.MaxValue;
                }

                foreach (var adjacent in GetAdjacentCoordinates(currentNode.Node.Item1, currentNode.Node.Item2, Maze.GetLength(0), Maze.GetLength(1)))
                {
                    var newDistance = currentNode.Distance + 1;
                    if (distances[adjacent.Item1, adjacent.Item2] != null && newDistance < distances[adjacent.Item1, adjacent.Item2].Distance)
                    {
                        distances[adjacent.Item1, adjacent.Item2].Distance = newDistance;

                        minDistances.Heapify();
                    }
                }
            }

            return int.MaxValue;
        }

        public List<Tuple<int, int>> GetAdjacentCoordinates(int x, int y, int width, int height)
        {
            List<Tuple<int, int>> adjacent = new List<Tuple<int, int>>();
            if ((x + 1) < width)
            {
                adjacent.Add(new Tuple<int, int>(x + 1, y));
            }
            if ((y + 1) < height)
            {
                adjacent.Add(new Tuple<int, int>(x, y + 1));
            }
            if ((x - 1) >= 0)
            {
                adjacent.Add(new Tuple<int, int>(x - 1, y));
            }
            if ((y - 1) >= 0)
            {
                adjacent.Add(new Tuple<int, int>(x, y - 1));
            }

            return adjacent;
        }
    }
}
