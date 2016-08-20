using Algorithms.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Tests
{
    
    [TestClass]
    public class BinarySearchTests
    {

        #region Normal Search

        [TestMethod]
        public void TestBinarySearchTrue()
        {
            Assert.IsTrue(BinarySearch.Search(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 3));
            Assert.IsTrue(BinarySearch.Search(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 6));
            Assert.IsTrue(BinarySearch.Search(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1));
            Assert.IsTrue(BinarySearch.Search(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8));
        }

        [TestMethod]
        public void TestBinarySearchFalse()
        {
            Assert.IsFalse(BinarySearch.Search(new int[] { 1, 2, 3, 5, 6, 7, 8 }, 4));
            Assert.IsFalse(BinarySearch.Search(new int[] { 1, 2, 3, 4, 5, 7, 8 }, 6));
            Assert.IsFalse(BinarySearch.Search(new int[] { 2, 3, 4, 5, 6, 7, 8 }, 1));
            Assert.IsFalse(BinarySearch.Search(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 8));
        }

        #endregion

        #region Rotated Array

        [TestMethod]
        public void TestBinarySearchRotatedTrue()
        {
            Assert.IsTrue(BinarySearch.SearchRotatedArray(new int[] { 6, 7, 8, 1, 2, 3, 4, 5 }, 3));
            Assert.IsTrue(BinarySearch.SearchRotatedArray(new int[] { 8, 1, 2, 3, 4, 5, 6, 7}, 1));
            Assert.IsTrue(BinarySearch.SearchRotatedArray(new int[] { 3, 4, 5, 6, 7, 8, 1, 2 }, 6));
            Assert.IsTrue(BinarySearch.SearchRotatedArray(new int[] { 4, 5, 6, 7, 8, 1, 2, 3 }, 4));
            Assert.IsTrue(BinarySearch.SearchRotatedArray(new int[] { 6, 7, 8, 1, 2, 3, 4, 5 }, 5));
        }

        [TestMethod]
        public void TestBinarySearchRotatedFalse()
        {
            Assert.IsFalse(BinarySearch.SearchRotatedArray(new int[] { 6, 7, 8, 1, 2, 4, 5 }, 3));
            Assert.IsFalse(BinarySearch.SearchRotatedArray(new int[] { 3, 4, 5, 7, 8, 1, 2 }, 6));
            Assert.IsFalse(BinarySearch.SearchRotatedArray(new int[] { 5, 6, 7, 8, 1, 2, 3 }, 4));
            Assert.IsFalse(BinarySearch.SearchRotatedArray(new int[] { 6, 7, 8, 1, 2, 3, 4 }, 5));
        }

        #endregion

        #region Next Smallest

        [TestMethod]
        public void SearchNext()
        {
            Assert.AreEqual(3, BinarySearch.SearchNext(new int[] { 1, 2, 3, 4, 5, 6 }, 2));
            Assert.AreEqual(6, BinarySearch.SearchNext(new int[] { 1, 2, 3, 4, 5, 6 }, 5));
            Assert.AreEqual(6, BinarySearch.SearchNext(new int[] { 1, 2, 3, 5, 5, 6 }, 5));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchNextNoItem() {
            BinarySearch.SearchNext(new int[] {}, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchNextAllItemsSmaller() {
            BinarySearch.SearchNext(new int[] { 1, 2, 3, 4, 5 }, 6);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchNextAllItemsSmallerOrEqual() {
            BinarySearch.SearchNext(new int[] { 1, 2, 3, 4, 5 }, 5);
        }

        #endregion

    }

}
