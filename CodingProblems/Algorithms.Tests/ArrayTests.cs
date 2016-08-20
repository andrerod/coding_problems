using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Implementation;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Algorithms.Tests
{
    [TestClass]
    public class ArrayTests
    {

        #region FindKthSmallest

        [TestMethod]
        public void SmallestOne()
        {
            var result = Array.FindKthSmallest(new[] {3, 5, 7, 8, 6, 34, 3}, 3);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void SmallestTwo()
        {
            var result = Array.FindKthSmallest(new[] { 3, 5, 7, 8, 6, 34, 3 }, 5);

            Assert.AreEqual(7, result);
        }

        #endregion

        #region FindMissingElementSum

        [TestMethod]
        public void Works()
        {
            var result = Array.FindMissingElementSum(new[] { 1, 2, 3 }, new[] { 1, 2 });

            Assert.AreEqual(3, result);
        }

        #endregion

        #region FindMissingElementXor

        [TestMethod]
        public void WorksXor()
        {
            var result = Array.FindMissingElementXor(new[] { 1, 2, 3 }, new[] { 1, 2 });

            Assert.AreEqual(3, result);
        }

        #endregion

        #region GetNumberAddingUpToSum

        [TestMethod]
        public void EmptyListWhenNumbersIsNull()
        {
            var result = Array.GetNumberAddingUpToSum(null, 0);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void EmptyListWhenNoNumbersAddUpToSum()
        {
            var result = Array.GetNumberAddingUpToSum(new[] { 1, 2, 3 }, 10);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void FindOnePair()
        {
            var result = Array.GetNumberAddingUpToSum(new[] { 1, 2, 3 }, 3);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0][0]);
            Assert.AreEqual(2, result[0][1]);
        }

        [TestMethod]
        public void FindMultiplePairs()
        {
            var result = Array.GetNumberAddingUpToSum(new[] { 1, 2, 5, 4 }, 6);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0][0]);
            Assert.AreEqual(5, result[0][1]);
            Assert.AreEqual(2, result[1][0]);
            Assert.AreEqual(4, result[1][1]);
        }

        [TestMethod]
        public void FindNegativePair()
        {
            var result = Array.GetNumberAddingUpToSum(new[] { 1, 2, 7, -3 }, 4);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(7, result[0][0]);
            Assert.AreEqual(-3, result[0][1]);
        }
        
        [TestMethod]
        public void EmptyListWhenNoNumbersAddUpToSumI()
        {
            var result = Array.TwoSumNoSpace(new[] { 1, 2, 3 }, 10);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void FindOnePairI()
        {
            var result = Array.TwoSumNoSpace(new[] { 1, 2, 3 }, 3);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0][0]);
            Assert.AreEqual(2, result[0][1]);
        }

        [TestMethod]
        public void FindMultiplePairsI()
        {
            var result = Array.TwoSumNoSpace(new[] { 1, 2, 5, 4 }, 6);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0][0]);
            Assert.AreEqual(5, result[0][1]);
            Assert.AreEqual(2, result[1][0]);
            Assert.AreEqual(4, result[1][1]);
        }

        [TestMethod]
        public void FindNegativePairI()
        {
            var result = Array.TwoSumNoSpace(new[] { 1, 2, 7, -3 }, 4);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(-3, result[0][0]);
            Assert.AreEqual(7, result[0][1]);
        }
        
        #endregion

        #region 3 Sum

        [TestMethod]
        public void ThreeSum()
        {
            var result = Array.ThreeSum(new[] { -25, -10, -7, -3, 2, 4, 8, 10 }, 0);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(-10, result[0][0]);
            Assert.AreEqual(2, result[0][1]);
            Assert.AreEqual(8, result[0][2]);
            Assert.AreEqual(-7, result[1][0]);
            Assert.AreEqual(-3, result[1][1]);
            Assert.AreEqual(10, result[1][2]);
        }

        #endregion

        #region Get Largest Continuous Sum

        [TestMethod]
        public void ZeroIsNullNumbers()
        {
            var result = Array.GetLargestContinuousSum(null);

            Assert.AreEqual(0, result);
        } 

        [TestMethod]
        public void AllPositiveNumbers()
        {
            var result = Array.GetLargestContinuousSum(new[] { 1, 2, 3 });

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void AllNegativeShouldBeZero()
        {
            var result = Array.GetLargestContinuousSum(new[] { -1, -2, -3 });

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ResetInTheMiddle()
        {
            var result = Array.GetLargestContinuousSum(new[] { 1, -2, 2 });

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void NegativeTheMiddle()
        {
            var result = Array.GetLargestContinuousSum(new[] { 5, -2, 5 });

            Assert.AreEqual(8, result);
        }

        #endregion

        #region FindEquilibrium

        [TestMethod]
        public void FindEquilibrium()
        {
            Assert.AreEqual(3, Array.FindEquilibrium(new int[] { -7, 1, 5, 2, -4, 3, 0 }));
        }

        #endregion

        #region Minimum Difference Two Array

        [TestMethod]
        public void MinimumDifference()
        {
            Assert.AreEqual(1, Array.MinimumDifference(new int[] { 0, 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8, 9 }));
            Assert.AreEqual(3, Array.MinimumDifference(new int[] { 2, 4, 7, 9, 19 }, new int[] { -3, 12, 14, 15, 23, 26, 30, 32, 35, 40 }));
            Assert.AreEqual(0, Array.MinimumDifference(new int[] { -4, -3, -2, -1 }, new int[] { -9, -8, -7, -3, -2 }));
        }

        #endregion

        #region Largest Continuous Product

        [TestMethod]
        public void LargestContinuousProduct()
        {
            Assert.AreEqual(180, Array.LargestContinuousProduct(new int[] { 6, -3, -10, 0, 2 }));
            Assert.AreEqual(60, Array.LargestContinuousProduct(new int[] { -1, -3, -10, 0, 60 }));
            Assert.AreEqual(80, Array.LargestContinuousProduct(new int[] { -2, -3, 0, -2, -40 }));
            Assert.AreEqual(-2, Array.LargestContinuousProduct(new int[] { -2 }));
        }

        #endregion

        #region Sum Of Nested Integers

        /// <summary>
        /// Given a nested list of integers, returns the sum of all integers in the list weighted by their depth 
        /// For example, given the list {{1,1},2,{1,1}} the function should return 10 (four 1's at depth 2, one 2 at depth 1) 
        /// Given the list {1,{4,{6}}} the function should return 27 (one 1 at depth 1, one 4 at depth 2, and one 6 at depth 3) 
        /// </summary>
        [TestMethod]
        public void SumNestedIntegers()
        {
            Assert.AreEqual(10, Array.SumNestedIntegers(new object[] { new object[] { 1, 1 }, 2, new object[] { 1, 1 } }));
            Assert.AreEqual(27, Array.SumNestedIntegers(new object[] {1, new object[] {4, new object[] {6}}}));
        }

        #endregion

        #region Triangle

        [TestMethod]
        public void NumTriangle()
        {
            var result = Array.NumTriangle(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            Assert.AreEqual(10, result.Count);

            result = Array.NumTriangle(new int[] { 10, 21, 22, 100, 101, 200, 300 });
            Assert.AreEqual(6, result.Count);
        }

        #endregion

        #region Number of columns

        [TestMethod]
        public void DisplayInNumberOfColumns()
        {
            var result = Array.DisplayInNumberOfColumns(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3);

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(3, result[0].Count);
            Assert.AreEqual(3, result[1].Count);
            Assert.AreEqual(1, result[2].Count);
        }

        #endregion

        #region Window Sum

        [TestMethod]
        public void WindowSum()
        {
            var result = Array.WindowSum(new int[] { 4,2,73,11,-5 }, 2);

            Assert.AreEqual(4, result.Count());
            Assert.AreEqual(6, result[0]);
            Assert.AreEqual(75, result[1]);
            Assert.AreEqual(84, result[2]);
            Assert.AreEqual(6, result[3]);

            result = Array.WindowSum(new int[] { 4, 2, 73, 11, -5 }, 3);

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(79, result[0]);
            Assert.AreEqual(86, result[1]);
            Assert.AreEqual(79, result[2]);
        }

        #endregion

        #region MinimumSubArray

        [TestMethod]
        public void MinimumSubArray()
        {
            var result = Array.MinimumSubArray(new int[] { 10, 12, 20, 30, 25, 40, 32, 31, 35, 50, 60 });

            Assert.AreEqual(3, result[0]);
            Assert.AreEqual(8, result[1]);

            result = Array.MinimumSubArray(new int[] { 0, 1, 15, 25, 6, 7, 30, 40, 50 });

            Assert.AreEqual(2, result[0]);
            Assert.AreEqual(5, result[1]);
        }

        #endregion

        #region Count Inversion

        [TestMethod]
        public void CountInversion()
        {
            Assert.AreEqual(3, Array.CountInversion(new int[] {1, 3, 5, 2, 4, 6}));
        }

        #endregion

        #region Largest Number Formed from Array

        [TestMethod]
        public void LargestNumber()
        {
            Assert.AreEqual(95343130, Array.LargestNumber(new int[] {31, 30, 34, 5, 9}));
        }

        #endregion

        #region Number of ways color rgb

        [TestMethod]
        public void NumberOfWaysColor()
        {
            Assert.AreEqual(24, Array.NumberOfWaysColor(3));
            Assert.AreEqual(66, Array.NumberOfWaysColor(4));
        }

        #endregion

        #region Number To String

        [TestMethod]
        public void NumberToString() {
            Assert.AreEqual("Sixty Seven", Array.NumberToString(67));
            Assert.AreEqual("Twelve", Array.NumberToString(12));
            Assert.AreEqual("Twelve Thousand", Array.NumberToString(12000));
            Assert.AreEqual("Twelve Thousand Six Hundred Forty Three", Array.NumberToString(12643));
        }

        #endregion

        #region Roman Numerals to a Number

        [TestMethod]
        public void RomanToNumber()
        {
            Assert.AreEqual(3, Array.RomanToNumber("III"));
            Assert.AreEqual(4, Array.RomanToNumber("IV"));
            Assert.AreEqual(1954, Array.RomanToNumber("MCMLIV"));
            Assert.AreEqual(1990, Array.RomanToNumber("MCMXC"));
        }

        #endregion

        #region Interval Merging

        [TestMethod]
        public void Simple()
        {
            Assert.AreEqual(6, Array.GetTotalCoveredLength(new List<int[]>
            {
                new int[] { 3, 6 },
                new int[] { 8, 9 },
                new int[] { 1, 5 }
            }));
        }

        #endregion

        #region Longest Continuous Subsequence For Sum K

        [TestMethod]
        public void LongestSubsequenceForK()
        {
            var result = Array.LongestSubsequenceForK(new int[] { 3, 5, 6, 7, 9 }, 18);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(6, result[1]);
            Assert.AreEqual(7, result[2]);
        }

        #endregion

        #region Count Lines Cross Over

        /// <summary>
        /// 
        ///                |   |
        ///         _______|___|__       |
        ///                |   |         |_______
        ///                | __|_________|__
        ///                    |
        ///                    
        /// </summary>
        [TestMethod]
        public void CountCrossOver()
        {
            List<Array.Line> lines = new List<Array.Line>();
            lines.Add(new Array.Line { Start = new Array.Point { X = 1, Y = 4 }, End = new Array.Point { X = 5, Y = 4 } });
            lines.Add(new Array.Line { Start = new Array.Point { X = 3, Y = 1 }, End = new Array.Point { X = 10, Y = 1 } });
            lines.Add(new Array.Line { Start = new Array.Point { X = 7, Y = 3 }, End = new Array.Point { X = 12, Y = 3 } });

            lines.Add(new Array.Line { Start = new Array.Point { X = 2, Y = 1 }, End = new Array.Point { X = 2, Y = 6 } });
            lines.Add(new Array.Line { Start = new Array.Point { X = 4, Y = 0 }, End = new Array.Point { X = 4, Y = 6 } });
            lines.Add(new Array.Line { Start = new Array.Point { X = 7, Y = 1 }, End = new Array.Point { X = 7, Y = 6 } });

            Assert.AreEqual(5, Array.CountCrossOver(lines.ToArray()));
        }

        #endregion

        #region Dot Product Sparse Vector
        
        [TestMethod]
        public void DotProductDictionary()
        {
            Dictionary<int, int> vector1 = new Dictionary<int, int> { { 1, 4 }, { 4, 2 }, { 5, 3 } };
            Dictionary<int, int> vector2 = new Dictionary<int, int> { { 1, 7 }, { 2, 6 }, { 5, 1 } };

            Assert.AreEqual(31, Array.DotProductDictionary(vector1, vector2));
        }

        [TestMethod]
        public void DotProductList()
        {
            List<System.Tuple<int, int>> vector1 = new List<System.Tuple<int, int>> {
                new System.Tuple<int, int>(1, 4), new System.Tuple<int, int>(4, 2), new System.Tuple<int, int>(5, 3)
            };
            List<System.Tuple<int, int>> vector2 = new List<System.Tuple<int, int>> {
                new System.Tuple<int, int>(1, 7), new System.Tuple<int, int>(2, 6), new System.Tuple<int, int>(5, 1)
            };

            Assert.AreEqual(31, Array.DotProductList(vector1, vector2));
        }

        #endregion

        #region Look To Say

        [TestMethod]
        public void LookToSay()
        {
            var result = Array.LookToSay(6);

            Assert.AreEqual(6, result.Count);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(11, result[1]);
            Assert.AreEqual(21, result[2]);
            Assert.AreEqual(1211, result[3]);
            Assert.AreEqual(111221, result[4]);
            Assert.AreEqual(312211, result[5]);
        }

        [TestMethod]
        public void LookToSayNoString()
        {
            var result = Array.LookToSayNoString(6);

            Assert.AreEqual(6, result.Count);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(11, result[1]);
            Assert.AreEqual(21, result[2]);
            Assert.AreEqual(1211, result[3]);
            Assert.AreEqual(111221, result[4]);
            Assert.AreEqual(312211, result[5]);
        }

        #endregion

        #region Max Sum Non Adjacent Sub Sequence

        [TestMethod]
        public void MaxSumNonAdjacentSubSequence()
        {
            Assert.AreEqual(13, Array.MaxSumNonAdjacentSubSequence(new int[] { 3, 2, 7, 10 }));
            Assert.AreEqual(15, Array.MaxSumNonAdjacentSubSequence(new int[] { 3, 2, 5, 10, 7 }));
            Assert.AreEqual(168, Array.MaxSumNonAdjacentSubSequence(new int[] { 4, 5, 17, 3, 12, 29, 0, -25, 25, 28, 16, 16, 16, 11, -10, -4, 3, -25, 10, -20, 1, -9, 23, 13, -25, 9, -24, 15, 5, -20 }));
        }

        #endregion

        #region Overlapping Activities

        [TestMethod]
        public void OverlappingActivities()
        {
            List<Algorithms.Implementation.Array.Times> activities = new List<Algorithms.Implementation.Array.Times> {
                new Algorithms.Implementation.Array.Times{ Start = 1, End = 5 },
                new Algorithms.Implementation.Array.Times{ Start = 7, End = 10 },
                new Algorithms.Implementation.Array.Times{ Start = 3, End = 8 },
                new Algorithms.Implementation.Array.Times{ Start = 9, End = 12 },
                new Algorithms.Implementation.Array.Times{ Start = 4, End = 9 }
            };

            Assert.AreEqual(3, Array.OverlappingActivities(activities));
        }

        #endregion

        #region Permutation Sequence

        [TestMethod]
        public void Permute()
        {
            var result = Array.Permute(new int[] { 1, 2, 3 });
            Assert.IsNotNull(result);
            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(1, result[0][0]);
            Assert.AreEqual(2, result[0][1]);
            Assert.AreEqual(3, result[0][2]);
        }

        [TestMethod]
        public void GetPermutation()
        {
            Assert.AreEqual("312", Array.GetPermutation(3, 5));
            Assert.AreEqual("321", Array.GetPermutation(3, 6));
        }

        #endregion

    }
}
