using System;
using System.Collections.Generic;

namespace CodingProblems
{
    public class AStartBetter
    {
        public int[,] Maze { get; set; }

        public AStartBetter(int[,] maze)
        {
            Maze = maze;
        }

        public int EstimateCost(int startX, int startY, int endX, int endY)
        {
            return Math.Abs(endY - startY) + Math.Abs(endX - startX);
        }

        public int ShortestPath(int startX, int startY, int endX, int endY)
        {
            var nextNodes = new MinHeap<MazeLocation<Tuple<int, int>>>();
            var locations = new MazeLocation<Tuple<int, int>>[Maze.GetLength(0), Maze.GetLength(1)];

            for (int i = 0; i < Maze.GetLength(0); i++)
            {
                for (int j = 0; j < Maze.GetLength(1); j++)
                {
                    var node = new Tuple<int, int>(i, j);
                    var distance = int.MaxValue;
                    var fscore = int.MaxValue;
                    if (i == startX && j == startY)
                    {
                        distance = 0;
                        fscore = EstimateCost(startX, startY, endX, endY);
                    }

                    var mazeLocation = new MazeLocation<Tuple<int, int>> { Node = node, FScore = fscore, GScore = distance };
                    locations[i, j] = mazeLocation;

                    if (i == startX && j == startY)
                    {
                        nextNodes.Add(mazeLocation);
                    }
                }
            }

            while (nextNodes.Length > 0)
            {
                var currentNode = nextNodes.PopMin();

                if (currentNode.Node.Item1 == endX && currentNode.Node.Item2 == endY)
                {
                    return currentNode.GScore;
                }

                foreach (var adjacent in GetAdjacentCoordinates(currentNode.Node.Item1, currentNode.Node.Item2, Maze.GetLength(0), Maze.GetLength(1)))
                {
                    if (locations[adjacent.Item1, adjacent.Item2] != null)
                    {
                        var newDistance = currentNode.GScore + 1;
                        if (newDistance < locations[adjacent.Item1, adjacent.Item2].GScore)
                        {
                            locations[adjacent.Item1, adjacent.Item2].GScore = newDistance;
                            locations[adjacent.Item1, adjacent.Item2].FScore = newDistance + EstimateCost(adjacent.Item1, adjacent.Item2, endX, endY);
                            nextNodes.Heapify();
                        }
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
