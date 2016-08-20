using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{

    public class BinarySearch
    {

        #region Normal Search

        public static bool Search(int[] array, int number)
        {
            return Search(array, number, 0, array.Length - 1);
        }

        private static bool Search(int[] array, int number, int start, int end)
        {
            while (start <= end)
            {
                int pivotIndex = start + (int)System.Math.Floor((end - start) / 2d);
                int pivot = array[pivotIndex];

                if (pivot == number)
                {
                    //we found the number
                    return true;
                }
                
                if (number < pivot)
                {
                    //if number is on the left side and there is a room to go
                    end = pivotIndex - 1;
                }
                else
                {
                    //if the number is larger
                    start = pivotIndex + 1;
                }
            }

            //if we are here, we did not find it and ran out of numbers
            return false;
        }

        #endregion

        #region Rotated Array

        public static bool SearchRotatedArray(int[] array, int number)
        {
            return SearchRotatedArray(array, number, 0, array.Length - 1);
        }

        /// <summary>
        /// looks like 4, 5, 6, 7, 1, 2, 3
        /// if we are looking at 7, look at the beginning, if it's smaller than 7, we know the rotation happened to the right
        /// if we are looking at 1, look at the beginning, if it's bigger than 1 then we know rotation happened to the left
        /// </summary>
        /// <param name="array"></param>
        /// <param name="number"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static bool SearchRotatedArray(int[] array, int number, int start, int end)
        {
            while (start <= end)
            {
                int pivotIndex = start + (int)System.Math.Floor((end - start) / 2d);
                int pivot = array[pivotIndex];

                if (pivot == number)
                {
                    //same as normal binary search, if we hit the number as the pivot, we have found it
                    return true;
                }
                
                //now look at which direction is sorted
                if (array[start] <= pivot)
                {
                    //left half is sorted, meaning rotation happend on the right
                    if ((array[start] <= number) && (number < pivot))
                    {
                        //luck we are in the sorted region...eliminate right half
                        end = pivotIndex - 1;
                    }
                    else
                    {
                        start = pivotIndex + 1;
                    }
                }
                else
                {
                    //right half is sorted, meaning rotation happened on the left
                    if ((pivot < number) && (number <= array[end]))
                    {
                        //luck we are in the sorted region...eliminate left half
                        start = pivotIndex + 1;
                    }
                    else
                    {
                        end = pivotIndex - 1;
                    }
                }
            }

            return false;
        }

        #endregion

        #region Next Smallest

        public static int SearchNext(int[] array, int number)
        {
            int start = 0;
            int end = array.Length - 1;

            int next = int.MaxValue;

            while (start <= end)
            {
                int mid = start + (int)System.Math.Floor((end - start) / 2d);

                if (array[mid] <= number)
                {
                    //since we are looking for a number larger than the number, we can discard left
                    start = mid + 1;
                }
                else
                {
                    if (array[mid] < next)
                    {
                        next = array[mid];
                    }

                    //since we captured the smallest number larger than the number, we can now discard
                    end = mid - 1;
                }
            }

            if (next == int.MaxValue)
            {
                //cannot find...all numbers smaller than number
                throw new ArgumentException();
            }

            return next;
        }

        #endregion

        #region Smallest k in union of two sorted arrays

        //given two sorted array a & b, find kth smallest element in the union of the arrays
        //if ai is between bj-1 and bj then ai is the element we seek. so i + j + 1 = k
        //1, 2, 3, 4, 5
        //1, 2,    4, 5
        //5th element (ai = 3, bj = 4), since ai = 3 is between bj-1 = 2 and bj = 4, 2 + 2 + 1 = 5
        public static int SearchTwoSortedArraysForKthSmallest(int[] a, int[] b, int k)
        {
            if ((a == null) || (b == null))
            {
                throw new ArgumentNullException();
            }

            int startA = 0;
            int endA = a.Length - 1;
            int startB = 0;
            int endB = b.Length - 1;

            while ((startA <= endA) || (startB <= endB))
            {
                //limit the bound such that we only look at maximum k elements (if everything came from one of the array)
                int i = startA + (int)System.Math.Floor((System.Math.Min(k, endA) - startA) / 2d);
                int j = k - 1 - i;

                int ai_1 = (i == startA) ? int.MinValue : a[i - 1];
                int bj_1 = (j == startB) ? int.MinValue : b[j - 1];
                int ai = (i > endA) ? int.MaxValue : a[i];
                int bj = (j > endB) ? int.MaxValue : b[j];

                //now check for the condition
                if ((bj_1 <= ai) && (ai <= bj))
                {
                    //if a between bj-1 and bj then ai is the kth element
                    return ai;
                }
                else if ((ai_1 <= bj) && (bj <= ai))
                {
                    return bj;
                }

                if (ai < bj)
                {
                    //now if above condition is not true (bj-1 < ai < bj) but ai < bj then ai < bj-1 since above condition is not true
                    //and since ai and bj should equal k and ai is smaller, left side of ai cannot be k and same for right side of bj
                    //1, 2, 3, ai, 5, 6, 7
                    //8, 9, 10, bj, 11, 12, 13
                    //we can only include more elements from right of ai and left of bj to get to k
                    startA = i;
                    endB = j;

                    //we eliminated i number of elements, so k should be decremented by the same amount
                    k = k - i - 1;
                }
                else
                {
                    //by same logic as above, we can eliminate right side of ai and left side of bj
                    startB = j;
                    endA = i;

                    k = k - j - 1;
                }
            }

            return -1;
        }

        #endregion

    }

}
