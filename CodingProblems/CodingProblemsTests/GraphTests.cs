using CodingProblems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CodingProblemsTests
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void ShortestPathTests()
        {
            Graph g = new Graph();
            g.Add("Seattle", new Dictionary<string, int>() { { "San Francisco", 1306 }, { "Denver", 2161 }, { "Minneapolis", 2661 } });
            g.Add("San Francisco", new Dictionary<string, int>() { { "Seattle", 1306 }, { "Las Vegas", 919 }, { "Los Angeles", 629 } });
            g.Add("Las Vegas", new Dictionary<string, int>() { { "San Francisco", 919 }, { "Los Angeles", 435 }, { "Denver", 1225 }, { "Dallas", 1983 } });
            g.Add("Los Angeles", new Dictionary<string, int>() { { "San Francisco", 629 }, { "Las Vegas", 435 } });
            g.Add("Denver", new Dictionary<string, int>() { { "Seattle", 2161 }, { "Las Vegas", 1225 }, { "Minneapolis", 1483 }, { "Dallas", 1258 } });
            g.Add("Minneapolis", new Dictionary<string, int>() { { "Seattle", 2661 }, { "Denver", 1483 }, { "Dallas", 1532 }, { "Chicago", 661 } });
            g.Add("Dallas", new Dictionary<string, int>() { { "Las Vegas", 1983 }, { "Denver", 1258 }, { "Minneapolis", 1532 }, { "Washington DC", 2113 } });
            g.Add("Chicago", new Dictionary<string, int>() { { "Minneapolis", 661 }, { "Washington DC", 1145 }, { "Boston", 1613 } });
            g.Add("Washington DC", new Dictionary<string, int>() { { "Dallas", 2113 }, { "Chicago", 1145 }, { "Boston", 725 }, { "New York", 383 }, { "Miami", 1709 } });
            g.Add("Boston", new Dictionary<string, int>() { { "Chicago", 1613 }, { "Washington DC", 725 }, { "New York", 338 } });
            g.Add("New York", new Dictionary<string, int>() { { "Washington DC", 383 }, { "Boston", 338 }, { "Miami", 2145 } });
            g.Add("Miami", new Dictionary<string, int>() { { "Dallas", 2161 }, { "Washington DC", 1709 }, { "New York", 2145 } });

            var shortestPath = g.ShortestPath("Miami", "Seattle");
            Assert.AreEqual(3, shortestPath.Count);
        }

        [TestMethod]
        public void ShortestPathMineTests()
        {
            GraphMine g = new GraphMine();
            g.Add("Seattle", new Dictionary<string, int>() { { "San Francisco", 1306 }, { "Denver", 2161 }, { "Minneapolis", 2661 } });
            g.Add("San Francisco", new Dictionary<string, int>() { { "Seattle", 1306 }, { "Las Vegas", 919 }, { "Los Angeles", 629 } });
            g.Add("Las Vegas", new Dictionary<string, int>() { { "San Francisco", 919 }, { "Los Angeles", 435 }, { "Denver", 1225 }, { "Dallas", 1983 } });
            g.Add("Los Angeles", new Dictionary<string, int>() { { "San Francisco", 629 }, { "Las Vegas", 435 } });
            g.Add("Denver", new Dictionary<string, int>() { { "Seattle", 2161 }, { "Las Vegas", 1225 }, { "Minneapolis", 1483 }, { "Dallas", 1258 } });
            g.Add("Minneapolis", new Dictionary<string, int>() { { "Seattle", 2661 }, { "Denver", 1483 }, { "Dallas", 1532 }, { "Chicago", 661 } });
            g.Add("Dallas", new Dictionary<string, int>() { { "Las Vegas", 1983 }, { "Denver", 1258 }, { "Minneapolis", 1532 }, { "Washington DC", 2113 } });
            g.Add("Chicago", new Dictionary<string, int>() { { "Minneapolis", 661 }, { "Washington DC", 1145 }, { "Boston", 1613 } });
            g.Add("Washington DC", new Dictionary<string, int>() { { "Dallas", 2113 }, { "Chicago", 1145 }, { "Boston", 725 }, { "New York", 383 }, { "Miami", 1709 } });
            g.Add("Boston", new Dictionary<string, int>() { { "Chicago", 1613 }, { "Washington DC", 725 }, { "New York", 338 } });
            g.Add("New York", new Dictionary<string, int>() { { "Washington DC", 383 }, { "Boston", 338 }, { "Miami", 2145 } });
            g.Add("Miami", new Dictionary<string, int>() { { "Dallas", 2161 }, { "Washington DC", 1709 }, { "New York", 2145 } });

            var shortestDistance = g.ShortestDistance("Miami", "Seattle");
            Assert.AreEqual(5580, shortestDistance);
        }

        [TestMethod]
        public void MazeShortestPathTests()
        {
            int[,] maze = new int[10, 10];
            maze[0, 3] = 1;
            maze[1, 3] = 1;

            MazeShortestPath mazeSolver = new MazeShortestPath(maze);
            var distance = mazeSolver.ShortestPath(0, 0, 0, 9);
            Assert.AreEqual(13, distance);
        }

        [TestMethod]
        public void AStarShortestPathTests()
        {
            int[,] maze = new int[10, 10];
            maze[0, 3] = 1;
            maze[1, 3] = 1;

            AStarMine mazeSolver = new AStarMine(maze);
            var distance = mazeSolver.ShortestDistance(0, 0, 0, 9);
            Assert.AreEqual(13, distance);
        }
    }
}
