using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class ContinuousRegionTests
    {
        [TestMethod]
        public void CountOneBeginning()
        {
            var region = new ContinuousRegion(new int[,]
                             {
                                {1, 0}
                             });

            Assert.AreEqual(1, region.Count());
        }

        [TestMethod]
        public void CountOneMiddle()
        {
            var region = new ContinuousRegion(new int[,]
                             {
                                {0, 1, 0}
                             });

            Assert.AreEqual(1, region.Count());
        }

        [TestMethod]
        public void CountOneEnd()
        {
            var region = new ContinuousRegion(new int[,]
                             {
                                {0, 1}
                             });

            Assert.AreEqual(1, region.Count());
        }

        [TestMethod]
        public void CountMultiple()
        {
            var region = new ContinuousRegion(new int[,]
                             {
                                {0, 1, 0, 1}
                             });

            Assert.AreEqual(2, region.Count());
        }

        [TestMethod]
        public void CountContinuous()
        {
            var region = new ContinuousRegion(new int[,]
                             {
                                {0, 1, 1, 1}
                             });

            Assert.AreEqual(1, region.Count());
        }

        [TestMethod]
        public void CountMultipleVertically()
        {
            var region = new ContinuousRegion(new int[,]
                             {
                                {0, 1, 0, 0},
                                {0, 0, 0, 1}
                             });

            Assert.AreEqual(2, region.Count());
        }

        [TestMethod]
        public void CountMultipleVerticallyTwo()
        {
            var region = new ContinuousRegion(new int[,]
                             {
                                {0, 1, 0, 0},
                                {0, 0, 0, 0},
                                {0, 1, 0, 0}
                             });

            Assert.AreEqual(2, region.Count());
        }

        [TestMethod]
        public void CountContinuousVertically()
        {
            var region = new ContinuousRegion(new int[,]
                             {
                                {0, 1, 0, 0},
                                {0, 1, 0, 0}
                             });

            Assert.AreEqual(1, region.Count());
        }

        [TestMethod]
        public void CountContinuousDiagnal()
        {
            var region = new ContinuousRegion(new int[,]
                             {
                                {0, 1, 0, 0},
                                {0, 1, 1, 0}
                             });

            Assert.AreEqual(1, region.Count());
        }

        [TestMethod]
        public void CountContinuousConnected()
        {
            var region = new ContinuousRegion(new int[,]
                             {
                                {0, 1, 1, 0},
                                {0, 1, 1, 0}
                             });

            Assert.AreEqual(1, region.Count());
        }

        [TestMethod]
        public void CountContinuousDisconnected()
        {
            var region = new ContinuousRegion(new int[,]
                             {
                                {0, 1, 0, 1},
                                {0, 1, 1, 1}
                             });

            Assert.AreEqual(1, region.Count());
        }

        [TestMethod]
        public void CountContinuousDisconnected2()
        {
            var region = new ContinuousRegion(new int[,]
                             {
                                {0, 1, 0, 1},
                                {0, 1, 1, 1},
                                {0, 1, 0, 1}
                             });

            Assert.AreEqual(1, region.Count());
        }

    }
}
