using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{
    
    public class Sort
    {

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int start, int end) {
            //now element at pivotIndex is in correct position
            int pivotIndex = Partition(array, start, end);

            //if there are more elements to the left, recurse
            if ((pivotIndex - 1) > start)
            {
                QuickSort(array, start, pivotIndex - 1);
            }

            //if there are more elements to the right, recurse
            if ((pivotIndex + 1) < end)
            {
                QuickSort(array, pivotIndex + 1, end);
            }
        }

        /// <summary>
        /// arranges the numbers such that all elements left of the pivot is smaller or equal than the pivot
        /// and all elements right of the pivot is larger than the pivot
        /// returns the pivot index
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start">index of start</param>
        /// <param name="end">index of end</param>
        /// <returns></returns>
        private static int Partition(int[] array, int start, int end)
        {
            //we could randomly choose here to get better run time
            int pivot = array[start];

            //plllluuuuuhhhhh
            //s    l   r

            int left = start + 1;
            int right = end;

            //while there is an element in unknown region
            while (left <= right)
            {
                if (array[left] > pivot)
                {
                    swap(array, left, right);
                    right--;
                }
                else
                {
                    left++;
                }
            }

            //put the pivot in the right place
            swap(array, start, right);

            return right;
        }

        /// <summary>
        /// Slightly more efficient way to partition by not moving the mid element,
        /// Used for dutch flag sort
        /// given 0, 1, 2...sort all elements such that it's 0001111222222
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static void ThreeWayPartition(int[] array, int pivot)
        {
            int low = 0; //beginning of mid regon...+1 from end of low region
            int mid = 0; //beginning of unknown region...+1 from end of mid region
            int high = array.Length - 1; //end of unknown region...-1 from beginning of high region
            
            //000110XXXXX2222
            //   l m    h 
            //0000110XXXX2222
            //    l m   h

            //while there is some element in the unknown region
            while (mid <= high)
            {
                if (array[mid] < pivot)
                {
                    swap(array, low, mid);
                    low++;
                    mid++;
                }
                else if (array[mid] > pivot)
                {
                    swap(array, mid, high);
                    high--;
                }
                else
                {
                    mid++;
                }
            }
        }

        private static void swap(int[] array, int left, int right)
        {
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }

        #region Merging k lists

        // Typically used in external sort scenario
        // Have a pointer for each list
        // Extract the first element from each list into a min heap
        // Take the min element into a new list and then move the pointer for that
        // list by one...until all elements are exhausted
        // n log k (where n is the total number of items in all lists) 

        #endregion
        
        #region Merge Two Sorted Arrays

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            //validation
            if ((nums1 == null) || (nums2 == null))
            {
                throw new ArgumentException();
            }
            if (nums1.Length < (m + n))
            {
                throw new ArgumentException();
            }

            //if we populate from the back this should work i think
            int leftIndex = m - 1;
            for (int rightIndex = n - 1; rightIndex >= 0; rightIndex--)
            {
                //move larger number from left to end of left
                int mergedIndex = 0;
                while ((leftIndex >= 0 ? nums1[leftIndex] : int.MinValue) > nums2[rightIndex])
                {
                    mergedIndex = leftIndex + rightIndex + 1;
                    nums1[mergedIndex] = nums1[leftIndex];
                    leftIndex--;
                }

                //now move right one by one
                mergedIndex = leftIndex + rightIndex + 1;
                nums1[mergedIndex] = nums2[rightIndex];
            }
        }

        #endregion

    }

}
