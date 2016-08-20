using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Implementation;

namespace Algorithms.Tests
{
    [TestClass]
    public class BitsTests
    {

        #region Addition

        [TestMethod]
        public void Add()
        {
            Assert.AreEqual(4, Bits.Add(1, 3));
            Assert.AreEqual(12, Bits.Add(10, 2));
            Assert.AreEqual(-3, Bits.Add(-1, -2));
            Assert.AreEqual(8, Bits.Add(10, -2));
        }

        [TestMethod]
        public void Multiply()
        {
            Assert.AreEqual(0, Bits.Multiply(1, 0));
            Assert.AreEqual(4, Bits.Multiply(1, 4));
            Assert.AreEqual(130, Bits.Multiply(10, 13));
        }

        #endregion

    }
}

