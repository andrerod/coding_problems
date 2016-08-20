using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Implementation;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms.Tests
{
    [TestClass]
    public class SortTests
    {

        #region QuickSort

        [TestMethod]
        public void QuickSortSimple()
        {
            int[] array = new int[] { 3, 2, 56, 7, 7, 4, 2, 2 };
            Sort.QuickSort(array);

            Assert.AreEqual(2, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual(2, array[2]);
            Assert.AreEqual(3, array[3]);
            Assert.AreEqual(4, array[4]);
            Assert.AreEqual(7, array[5]);
            Assert.AreEqual(7, array[6]);
            Assert.AreEqual(56, array[7]);
        }

        [TestMethod]
        public void ThreeWayPartition()
        {
            int[] array = new int[] { 0, 1, 2, 1, 1, 0, 0, 2, 2 };
            Sort.ThreeWayPartition(array, 1);

            Assert.AreEqual(0, array[0]);
            Assert.AreEqual(0, array[1]);
            Assert.AreEqual(0, array[2]);
            Assert.AreEqual(1, array[3]);
            Assert.AreEqual(1, array[4]);
            Assert.AreEqual(1, array[5]);
            Assert.AreEqual(2, array[6]);
            Assert.AreEqual(2, array[7]);
            Assert.AreEqual(2, array[8]);
        }
        
        #endregion

        #region Merge Two Sorted Arrays

        [TestMethod]
        public void Merge()
        {
            Sort.Merge(new int[] { -50, -49, -49, -48, -47, -45, -43, -41, -41, -41, -40, -40, -39, -39, -38, -37, -37, -36, -36, -35, -35, -33, -33, -32, -31, -31, -30, -30, -29, -28, -25, -24, -21, -19, -18, -18, -14, -13, -10, -10, -9, -9, -9, -6, -6, -5, -1, 1, 7, 10, 10, 11, 13, 14, 14, 15, 20, 21, 21, 22, 23, 25, 26, 27, 30, 30, 31, 32, 33, 35, 36, 38, 40, 40, 41, 41, 42, 44, 46, 46, 46, 46, 46, 47, 48, 0 },
                85, new int[] { 33 }, 1);
        }

        #endregion

    }
}
