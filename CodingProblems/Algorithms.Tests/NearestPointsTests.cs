using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Implementation;

namespace Algorithms.Tests
{
    [TestClass]
    public class NearestPointsTests
    {
        
        [TestMethod]
        public void Simple()
        {
            List<int[]> points = new List<int[]> {
                new int[] {0, 1},
                new int[] {0, 2},
                new int[] {0, 3},
                new int[] {0, 4},
                new int[] {0, 5},
                new int[] {0, 6}
            };

            var result = NearestPoints.Find(points, new int[] { 0, 0 }, 3);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);

            Assert.AreEqual(3, result[0][1]);
            Assert.AreEqual(2, result[1][1]);
            Assert.AreEqual(1, result[2][1]);
        }

    }
}
