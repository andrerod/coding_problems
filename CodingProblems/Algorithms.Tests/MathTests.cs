using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Math = Algorithms.Implementation.Math;

namespace Algorithms.Tests
{
    
    [TestClass]
    public class MathTests
    {
        [TestMethod]
        public void SimpleSquareRoot()
        {
            Assert.AreEqual(354.045, Math.SquareRoot(125348, 6));
            Assert.AreEqual(354.045, Math.SqrtBinarySearch(125348, 0.001));
            Assert.AreEqual(354.045, Math.SqrtImprovedBinarySearch(125348, 0.001));
            Assert.AreEqual(354.045, Math.SqrtNewtonBinarySearch(125348, 0.001));
        }

        [TestMethod]
        public void SquareRootLessThanOne()
        {
            Assert.AreEqual(0.300, Math.SqrtBinarySearch(0.09, 0.001));
            Assert.AreEqual(0.500, Math.SqrtBinarySearch(0.25, 0.001));
        }

        [TestMethod]
        public void SumOfAllFactorOf3And5()
        {
            Assert.AreEqual(14, Math.SumOfAllFactorOf3And5(9));
            Assert.AreEqual(23, Math.SumOfAllFactorOf3And5(10));
        }

        #region Number Palindrome

        [TestMethod]
        public void IsPalindrome()
        {
            Assert.IsFalse(Math.IsPalindrome(10));
            Assert.IsFalse(Math.IsPalindrome(100));
            Assert.IsTrue(Math.IsPalindrome(9999));
        }

        #endregion

    } 

}
