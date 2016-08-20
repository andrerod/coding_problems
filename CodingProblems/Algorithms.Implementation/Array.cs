using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Algorithms.Implementation
{
	public class Array
	{

		#region Find kth Smallest using Quick Select

		public static int FindKthSmallest(int[] array, int k)
		{
			if (array.Length == 1)
			{
				return array[0];
			}

			var start = 0;
			var end = array.Length;
			var kIndex = k - 1;

			while(true)
			{
				var pivotIndex = (start + end)/2;
				var newPivotIndex = Partition(array, start, end, pivotIndex);

				if (newPivotIndex == kIndex)
				{
					//we found it
					return array[kIndex];
				}
				else if (kIndex < newPivotIndex)
				{
					end = newPivotIndex;
				}
				else if (kIndex > newPivotIndex)
				{
					start = newPivotIndex + 1;
				}
			}
		}

		private static int Partition(int[] array, int start, int end, int pivotIndex)
		{
			var pivotValue = array[pivotIndex];
			
			//mode pivot to the end so we don't have to process it
			swap(array, pivotIndex, end - 1);

			var processedIndex = 0;
			for(var index = start; index < end; index++)
			{
				if (array[index] < pivotValue)
				{
					swap(array, processedIndex, index);
					processedIndex++;
				}
			}

			//move pivot back
			swap(array, processedIndex, end - 1);
			return processedIndex;
		}

		private static void swap(int[] array, int index1, int index2)
		{
			int tmp = array[index2];
			array[index2] = array[index1];
			array[index1] = tmp;
		}

		#endregion

		#region Find Missing Element

		public static int FindMissingElementSum(IEnumerable<int> original, IEnumerable<int> shuffled)
		{
			return original.Sum() - shuffled.Sum();
		}

		public static int FindMissingElementXor(IEnumerable<int> original, IEnumerable<int> shuffled)
		{
			var result = 0;

			foreach(var number in original)
			{
				result = result ^ number;
			}
			foreach (var number in shuffled)
			{
				result = result ^ number;
			}

			return result;
		}

		#endregion

		#region Get Number Adding Up To A Sum

		public static IList<int[]> GetNumberAddingUpToSum(IEnumerable<int> numbers, int sum)
		{
			var result = new List<int[]>();
			var lookup = new Dictionary<int, int>();

			if (numbers != null)
			{
				foreach (var number in numbers)
				{
					int? pair = null;

					if (lookup.ContainsKey(sum - number))
					{
						pair = sum - number;
					}

					if (pair.HasValue)
					{
						result.Add(new[] { pair.Value, number });
					}

					lookup[number] = number;
				}
			}

			return result;
		}

		/// <summary>
		/// This involves sorting the array and carefully moving left and right pointer
		/// </summary>
		/// <param name="numbers"></param>
		/// <param name="sum"></param>
		/// <returns></returns>
		public static List<int[]> TwoSumNoSpace(int[] numbers, int sum)
		{
			List<int[]> result = new List<int[]>();

			// n log n already
			System.Array.Sort(numbers);

			int i = 0;
			int j = numbers.Length - 1;

			while (i < j)
			{
				if (sum == (numbers[i] + numbers[j]))
				{
					//we found one
					result.Add(new int[] { numbers[i], numbers[j] });

					i++;
					j--;
				}
				else if (sum > (numbers[i] + numbers[j]))
				{
					//if sum is larger, only way is to increase meaning we want to move left pointer
					i++;
				}
				else
				{
					j--;
				}
			}

			return result;
		}

		#endregion

		#region 3 Sum

		/// <summary>
		/// Two ways of solving this
		/// 
		///     n^2 with n space, store all numbers in a dictionary and then search for 2 pairs + remainder
		///     
		///     n^2 with no space, for every number, do two sum with remainder
		///         "-25" '-10' -7 -3 2 4 8 $10$  (a+b+c==-25)
		///         "-25" -10 '-7' -3 2 4 8 $10$  (a+b+c==-22)
		///         "-25" -10 -7 -3 2 4 '8' $10$  (a+b+c==-7)
		///         
		///         -25 "-10" -7 -3 '2' 4 8 $10$  (a+b+c==2)
		///         -25 "-10" -7 -3 '2' 4 $8$ 10  (a+b+c==0)
		/// </summary>
		/// <returns></returns>
		public static List<int[]> ThreeSum(int[] numbers, int sum)
		{
			List<int[]> result = new List<int[]>();

			System.Array.Sort(numbers);

			for (int count = 0; count < numbers.Length; count++)
			{
				int i = count + 1;
				int j = numbers.Length - 1;
				int remainder = sum - numbers[count];

				while (i < j)
				{
					if (remainder == (numbers[i] + numbers[j]))
					{
						//we found one
						result.Add(new int[] { numbers[count], numbers[i], numbers[j] });

						i++;
						j--;
					}
					else if (remainder > (numbers[i] + numbers[j]))
					{
						//if sum is larger, only way is to increase meaning we want to move left pointer
						i++;
					}
					else
					{
						j--;
					}
				}
			}

			return result;
		}

		#endregion

		#region Get Largest Continuous Sum

		public static int GetLargestContinuousSum(IEnumerable<int> numbers)
		{
			var result = 0;

			if (numbers != null)
			{
				var runningCount = 0;
				foreach(var number in numbers)
				{
					runningCount += number;
					if (runningCount < 0)
					{
						runningCount = 0;
					}

					if (runningCount > result)
					{
						result = runningCount;
					}
				}
			}

			return result;
		}

		#endregion

		#region Largest Continuous Product

		/// <summary>
		/// This is similar to continuous some but slightly more complex due to handling of 0 and negative numbers
		/// {6, -3, -10, 0, 2}
		/// 180  // The subarray is {6, -3, -10}
		/// 
		/// {-1, -3, -10, 0, 60}
		/// 60  // The subarray is {60}
		/// 
		/// {-2, -3, 0, -2, -40}
		/// 80  // The subarray is {-2, -40}
		/// </summary>
		/// <param name="numbers"></param>
		/// <returns></returns>
		public static int LargestContinuousProduct(int[] numbers)
		{
            if (numbers == null)
            {
                throw new ArgumentException();
            }

            if (numbers.Length == 0)
            {
                return 0;
            }

			int min = numbers[0];
            int max = numbers[0];
            int finalMax = numbers[0];

            for (int count = 1; count < numbers.Length; count++)
            {
                int number = numbers[count];
                //we need to think about the following:
                //  negative - last min value * current might give you maximum
                //  first number / 0, take the current number

                int tempMax = max;
                max = System.Math.Max(System.Math.Max(max * number, min * number), number);
                min = System.Math.Min(System.Math.Min(min * number, tempMax * number), number);
                finalMax = System.Math.Max(finalMax, max);
            }

			return finalMax;
		}

		#endregion

		#region Equilibrium

		/// <summary>
		/// Find the index where sum of left side is equal to sum of right side
		/// 
		/// -7, 1, 5, 2, -4, 3, 0
		/// index 3
		/// 
		/// Get the sum of all numbers first, then as we iterate, calculate left sum and
		/// right sum (total sum - left sum)
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public static int FindEquilibrium(int[] array)
		{
			int sum = array.Sum();

			int leftSum = 0;

			for (int index = 0; index < array.Length; index++)
			{
				//right sum need to subtract current cell
				sum -= array[index];

				//we want to compare excluding current cell (so right sum should subtract but left
				//sum shouldn't have added)
				if (sum == leftSum)
				{
					return index;
				}

				leftSum += array[index];
			}

			//not found
			return -1;
		}

		#endregion

		#region Minimum Difference Two Array

		/// <summary>
		/// Given two sorted arrays find min(abs(x-y)) where x and y are one elements from each array
		/// 
		/// Seems like I need to compare x < y < x + 1
		/// 
		/// Works for all numbers
		/// 3 & 4 = 1, 4 & 3 = 1, -4 & -3 = 1
		/// 
		/// Doesn't break in negative case
		/// -4 & 5 = 9
		/// </summary>
		/// <param name="array1"></param>
		/// <param name="array2"></param>
		/// <returns></returns>
		public static int MinimumDifference(int[] array1, int[] array2)
		{
			int minimum = int.MaxValue;

			int secondIndex = 0;
			for (int firstIndex = 0; firstIndex < array1.Length; firstIndex++)
			{
				while ((secondIndex < array2.Length) && (array1[firstIndex] > array2[secondIndex]))
				{
					secondIndex++;
				}

				//since second array is not equal or greater
				//minimum of existing minimum, x - 1 and x
				minimum = System.Math.Min(
					minimum, System.Math.Min(
					System.Math.Abs((secondIndex < array2.Length) ? array1[firstIndex] - array2[secondIndex] : int.MaxValue),
					System.Math.Abs((secondIndex > 0) ? array1[firstIndex] - array2[secondIndex - 1] : int.MaxValue)));
			}

			return minimum;
		}

		#endregion

		#region Sum Of Nested Integers

		/// <summary>
		/// Given a nested list of integers, returns the sum of all integers in the list weighted by their depth 
		/// For example, given the list {{1,1},2,{1,1}} the function should return 10 (four 1's at depth 2, one 2 at depth 1) 
		/// Given the list {1,{4,{6}}} the function should return 27 (one 1 at depth 1, one 4 at depth 2, and one 6 at depth 3) 
		/// </summary>
		/// <param name="integers"></param>
		/// <returns></returns>
		public static int SumNestedIntegers(IEnumerable<object> integers)
		{
			return SumNestedIntegers(integers, 1);
		}

		private static int SumNestedIntegers(IEnumerable<object> integers, int level)
		{
			int sum = 0;
			foreach (object o in integers)
			{
				if (o is IEnumerable<object>)
				{
					sum += SumNestedIntegers((IEnumerable<object>)o, level + 1);
				}
				else
				{
					sum += ((int)o * level);
				}
			}
			return sum;
		}

		#endregion

		#region Triangle

		/// <summary>
		/// Three segments of lengths A, B, C form a triangle if
		///     A + B > C
		///     B + C > A
		///     A + C > B
		/// 
		/// e.g.
		///     6, 4, 5 can form a triangle
		///     10, 2, 7 can't
		///     
		/// Given a list of segments lengths algorithm should find at least one triplet of segments that form a triangle (if any).
		/// 
		/// Naive way would be n^3 solution where we try every combination of sides
		/// This can be optimized to n^2 if we sort the array
		///     Sort the array
		///     Scan through 1st side
		///     Scan through 2nd side
		///     Knowing two find the last element where it's below the sum of first two sides
		///     
		///     1, 2, 3, 4, 5, 6, 7
		///     i = 1, j = 2, k = 3
		///     i = 1, j = 3, k = 3, and still no match,
		///     i = 1, j = 3, k = 4, no good what we have is not a valid triangle (1, 3, 4), moving on
		///     i = 1, j = 4, k = 5, (1, 4, 5) still not valid
		///     i = 1, j = 5, k = 6, (1, 5, 6) no good
		///     i = 2, j = 3, k = 4, (2, 3, 4) 2+3 > 4, 3+4 > 2, 2+4 > 3
		///     i = 2, j = 3, k = 5, (2, 3, 5) no good
		///     i = 2, j = 4, k = 6, (2, 4, 6) no good
		///     i = 3, j = 4, k = 5, (3, 4, 5) 3+4 > 5, 3+5 > 4, 4+5 > 3
		///     i = 3, j = 4, k = 6, (3, 4, 6) 2+4 > 6, 3+6 > 4, 
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public static List<List<int>> NumTriangle(int[] array)
		{
			//sort the array
			System.Array.Sort(array);

			List<List<int>> result = new List<List<int>>();

			//0..n-2
			for (int i = 0; i < (array.Length - 2); i++)
			{
				int k = i + 2;
				for (int j = i + 1; j < (array.Length - 1); j++)
				{
					while ((k < array.Length) && (array[i] + array[j] > array[k]))
					{
						//we already check i + j > k, so check the other two
						if (((array[i] + array[k] > array[j]) && (array[j] + array[k] > array[i])) &&
							//also check that k is not being reused
							(i != k && j != k))
						{
							result.Add(new List<int> { array[i], array[j], array[k] });
						}
						k++;
					}

				}
			}

			return result;
		}

		#endregion

		#region Number of columns

		/// <summary>
		/// Given an array display the numbers in the number of columns. Each column should contain similar
		/// number of numbers
		/// 
		/// 1, 2, 3, 4, 5, 6, 7
		/// 
		/// 1,4,6
		/// 2,5,7
		/// 3
		/// 
		/// we want the size different of each column to be at most 1
		/// so number elements floor(length / num column)
		/// first (length % num column) columns should have extra
		/// </summary>
		/// <param name="array"></param>
		/// <param name="numColumn"></param>
		/// <returns></returns>
		public static List<List<int>> DisplayInNumberOfColumns(int[] array, int numColumn)
		{
			List<List<int>> result = new List<List<int>>();

			int numElements = (int)System.Math.Floor(array.Length / numColumn * 1d);
			int numColumnsWithExtra = array.Length % numColumn;

			for (int row = 0; row < (numElements + (numColumnsWithExtra > 0 ? 1 : 0)); row++)
			{
				List<int> line = new List<int>();

				int columnMax = (row < numElements) ? numColumn : numColumnsWithExtra;
				for (int column = 0; column < columnMax; column++)
				{
					int columnIndex = (column * numElements) + System.Math.Min(numColumnsWithExtra, column);
					int index = columnIndex + row;
					line.Add(array[index]);
				}
				result.Add(line);
			}

			return result;
		}

		#endregion

		#region Window Sum

		/// <summary>
		/// Given a list of integers and a window size, return a new list of integers where each integer is the sum 
		/// of all integers in the kth window of the input list. The kth window of the input list is the integers from index
		/// k to index k + window size -1 (inclusive).
		/// 
		/// For example,[4,2,73,11,-5] and the window size 2 should return [6,75,84,6]. For another example.[4,2,73,11,-5] and
		/// window size 3 should return [79, 86, 79].
		/// 
		/// Seems like we can run a cumulative sum and subtract the sum of the current - windwsize (at 4, subtract 3, and get sum at 1)
		/// </summary>
		/// <param name="numbers"></param>
		/// <param name="windowSize"></param>
		/// <returns></returns>
		public static int[] WindowSum(int[] numbers, int windowSize)
		{
			List<int> result = new List<int>();

			int cumulativeSum = 0;

			for (int index = 0; index < numbers.Length; index++)
			{
				cumulativeSum += numbers[index];
				result.Add(cumulativeSum);
			}

			//need to subtract later since we need to previous cumulative sum to calculate diff correctly
			for (int index = numbers.Length - 1; index >= windowSize; index--)
			{
				result[index] -= result[index - windowSize];
			}

			//need to skip first window - 1 since those are partial sums
			return result.Skip(windowSize - 1).ToArray();
		}

		#endregion

		#region Minimum sub array to make sorted array

		/// <summary>
		/// Given an unsorted array arr[0..n-1] of size n, find the minimum length subarray arr[s..e]
		/// such that sorting this subarray makes the whole array sorted.
		/// 
		/// If the input array is [10, 12, 20, 30, 25, 40, 32, 31, 35, 50, 60], 
		/// your program should be able to find that the subarray lies between the indexes 3 and 8.
		/// 
		/// If the input array is [0, 1, 15, 25, 6, 7, 30, 40, 50],
		/// your program should be able to find that the subarray lies between the indexes 2 and 5.
		/// 
		/// Identify candidate
		/// sub array where left side is decreasing and right side is increasing
		/// [30, 25, 40, 32, 31]
		/// 
		/// Find the min and max from the sub array
		/// 
		/// See if there is anything larger than the min in left side
		/// See if there is anything smaller than the max in the right side
		/// 
		/// Sub array is the from the new min and new max
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public static int[] MinimumSubArray(int[] array)
		{
			//Find candidate sub array
			int index = 1;
			while ((index < array.Length) && (array[index - 1] < array[index]))
			{
				index++;
			}

			int leftIndex = index - 1;

			index = array.Length - 2;
			while ((index >= 0) && (array[index] < array[index + 1]))
			{
				index--;
			}

			int rightIndex = index + 1;

			if (leftIndex < rightIndex)
			{
				//we have found a candidate, find min and max
				int min = int.MaxValue;
				int max = int.MinValue;
				for (int count = leftIndex; count <= rightIndex; count++)
				{
					if (array[count] < min)
					{
						min = array[count];
					}
					if (array[count] > max)
					{
						max = array[count];
					}
				}

				//shift index to left if there is one larger than the min
				while ((leftIndex - 1 > 0) && (array[leftIndex - 1] > min))
				{
					leftIndex--;
				}

				//shift index to right
				while ((rightIndex + 1 < array.Length) && (array[rightIndex + 1] < max))
				{
					rightIndex++;
				}

				return new int[] { leftIndex, rightIndex };
			}

			return null;
		}

		#endregion

		#region Count Inversion

		/// <summary>
		/// Count elements out of order
		/// 
		/// 1, 3, 5, 2, 4, 6
		/// 
		/// Inversions are
		/// (3, 2), (5, 2), (5, 4)
		/// 
		/// What if we do merge sort
		/// 1, 3, 5
		/// 2, 4, 6
		/// 
		/// start with left side, for every number, any traverse on the right side is an inversion
		/// we have an inversion
		/// 
		/// 1 3 (2) 5 (2, 4)
		///   2     4        6
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public static int CountInversion(int[] numbers)
		{
			int[] sortedNumbers;

			return CountInversionR(numbers, out sortedNumbers);
		}

		private static int CountInversionR(int[] numbers, out int[] sortedNumbers)
		{
			sortedNumbers = new int[numbers.Length];

			if (numbers.Length == 1)
			{
				sortedNumbers[0] = numbers[0];
				return 0;
			}

			int[] sortedLeft;
			int[] sortedRight;

			int mid = (int)System.Math.Floor(numbers.Length / 2d);
			int leftCount = CountInversionR(numbers.Take(mid).ToArray(), out sortedLeft);
			int rightCount = CountInversionR(numbers.Skip(mid).ToArray(), out sortedRight);

			int index = 0;
            int leftIndex = 0;
			int rightIndex = 0;
			int inversionCount = 0;
			foreach (int number in sortedLeft)
			{
                int mergeCount = 0;
				while ((rightIndex < sortedRight.Length) && (sortedRight[rightIndex] < number))
				{
					sortedNumbers[index] = sortedRight[rightIndex];

					index++;
					rightIndex++;
					mergeCount += sortedLeft.Length - leftIndex;
				}

				sortedNumbers[index] = number;
                leftIndex++;
				index++;
				inversionCount += mergeCount;
			}

			for (int rest = rightIndex; rest < sortedRight.Length; rest++)
			{
				sortedNumbers[index] = sortedRight[rest];
				index++;
			}

			return leftCount + rightCount + inversionCount;
		}

		#endregion     

		#region Largest Number Formed from Array

		/// <summary>
		/// For example, given [3, 30, 34, 5, 9], the largest formed number is 9534330.
		/// 
		/// Seems like we just line up the number from the highest digit 9 -> 0. The tricky part is
		/// multiple digit numbers; 9 should come before 34
		/// 
		/// What if we cast everything to string and just do string sort
		/// </summary>
		/// <param name="numbers"></param>
		/// <returns></returns>
		public static int LargestNumber(int[] numbers)
		{
			string[] stringNumbers = (from n in numbers select n.ToString()).ToArray();

			System.Array.Sort(stringNumbers);

			StringBuilder result = new StringBuilder();
			for (int index = stringNumbers.Length - 1; index >= 0; index--) 
			{
				result.Append(stringNumbers[index]);
			}

			return int.Parse(result.ToString());
		}

		#endregion

		#region Number of ways color rgb

		/// <summary>
		/// Given n boards, find the number of ways of coloring each board with rgb
		/// No three adjacent board can have the same color (rrr, ggg, bbb)
		/// 
		/// r   r   b   r
		///             g
		///             b
		///         g   r
		///             g
		///             b
		///     g   r   r
		///             g
		///             b
		///         g   r
		///             b
		///         b   r
		///             g
		///             b
		///     b   r   r
		///             g
		///             b
		///         g   r
		///             g
		///             b
		///         b   r
		///             g
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public static int NumberOfWaysColor(int number)
		{
			return NumberOfWaysColor(number, 'a', new List<char> { 'r', 'g', 'b' });
		}

		private static int NumberOfWaysColor(int number, char previousOne, List<char> characters)
		{
			if (number == 1)
			{
				return characters.Count;
			}

			int count = 0;

			foreach (char color in characters)
			{
				List<char> availableCharacters = new List<char> { 'r', 'g', 'b' };
				if (color == previousOne)
				{
					availableCharacters.Remove(color);
				}
				count += NumberOfWaysColor(number - 1, color, availableCharacters);
			}

			return count;
		}

		#endregion

		#region Number To String

		private static string[] thousands = new string[] { "", "Thousand", "Million", "Billion" };
		private static string[] digits = new string[] { "", "One", "Two", "Three", "Four", "Five",
				"Six", "Seven", "Eight", "Nine" };
		private static string[] teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
				"Fifteen", "Sixteen", "Eighteen", "Nineteen" };
		private static string[] tens = new string[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty",
				"Seventy", "Eighty", "Ninety" };

		public static string NumberToString(int number)
		{
			StringBuilder result = new StringBuilder();

			int count = 0;
			while (number > 0)
			{
				//process 1000 at a time going from the back
				string segment = string.Empty;

				int numberUnderThousand = number % 1000;
				if (numberUnderThousand < 10)
				{
					//if it's just 1 digit after thousand. e.g. 4000
					segment = digits[numberUnderThousand];
				}
				else if (numberUnderThousand < 20)
				{
					//if it's 2 digits under 20...e.g. 11000 - eleven...11%10 = 1
					segment = teens[numberUnderThousand % 10];
				}
				else if (numberUnderThousand < 100)
				{
					//if it's 2 digit between 20 - 100. e.g. 67000 sixty seven
					segment = tens[numberUnderThousand / 10] + " " + digits[numberUnderThousand % 10];
				}
				else if (numberUnderThousand < 1000)
				{
					//handle 3 digit...then it's number + hundred and same thing as all of above for rest
					segment = digits[numberUnderThousand / 100] + " Hundred " + NumberToString(numberUnderThousand % 100);
				}

				result.Insert(0, segment + " " + thousands[count] + " ");

				number /= 1000;
				count++;
			}

			return result.ToString().Trim();
		}

		#endregion

        #region Roman Numerals to a Number

        private static int BasicUnits(char chr)
        {
            switch (chr) {
                case 'I' :
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return  1000;
            }

            throw new ArgumentException();
        }

        /// <summary>
        /// Rule
        ///     each 1 unit can repeat up to 3 times
        ///     each 1 unit can be placed before 5 and 10 to make 4 & 9
        /// </summary>
        /// <param name="roman"></param>
        /// <returns></returns>
        public static int RomanToNumber(string roman)
        {
            int result = 0;

            for (int index = 0; index < roman.Length; index++)
            {
                result += BasicUnits(roman[index]);

                if ((index > 0) && (BasicUnits(roman[index]) > BasicUnits(roman[index - 1])))
                {
                    //this means we hit the second rule which is a subtraction...
                    //since we would have added as a normal case, we need to subtract twice!
                    //IV...we would have added 1 + 5...really we want 4
                    result -= (2 * BasicUnits(roman[index - 1]));
                }
            }

            return result;
        }

        #endregion

        #region Stocks

        public static int MaxProfitOneBuyOneSell(int[] prices)
		{
			int min = int.MaxValue;
			int maxProfit = 0;
			foreach (int price in prices)
			{
				if (price < min)
				{
					min = price;
				}
				// min = Math.min(min, price)
				if ((price - min) > maxProfit)
				{
					maxProfit = price - min;
				}
				// maxProfit = Math.max(maxProfit, (price - min))
			}
			return maxProfit;
		}

		// 1,2,4,2,5,7,2,4,9 (price)
		// 0,1,3,3,4,6,6,6,8 (max profit till i)
		// 8,7,7,7,7,7,7,5,0 (max profit from i)
		// so two transaction should be (1, 7) + (2, 9) = 13
		// use DP to store max profit on day i and then max profit from day i
		public static int MaxProfitTwoTransactions(int[] prices)
		{
			int min = prices[0];
			int max = prices[prices.Length - 1];

			int maxProfit = 0;

			int[] profitUntil = new int[prices.Length];
			int[] profitFrom = new int[prices.Length];

			for (int day = 1; day < prices.Length; day++)
			{
				min = System.Math.Min(min, prices[day]);
				profitUntil[day] = System.Math.Max(profitUntil[day - 1], prices[day] - min);
			}
			//should produce 0, 1, 3, 3, 4, 6, 6, 6, 8

			for (int day = prices.Length - 2; day >= 0; day--)
			{
				max = System.Math.Max(max, prices[day]);
				profitFrom[day] = System.Math.Max(profitFrom[day + 1], max - prices[day]);
			}
			//should produce 8, 7, 7, 7, 7, 7, 7, 5, 0

			//now it's just a matter of finding the max combo
			for (int day = 1; day < prices.Length; day++)
			{
				maxProfit = System.Math.Max(maxProfit, profitUntil[day] + profitFrom[day]);
			}

			return maxProfit;
		}

		#endregion

		#region Interval Merging

		/// <summary>
		/// (3, 6), (8, 9), (1, 5) should return 6. 1-6 + 8-9
		/// 
		/// This should be fairly simple, first sort by the starting number such that we 
		/// have a good view of overlapping intervals. Then if the current one is within
		/// the range of the last one, just merge/extend until we run into a new interval
		/// When we do, calculate the length and move on
		/// </summary>
		/// <param name="intervals"></param>
		/// <returns></returns>
		public static int GetTotalCoveredLength(List<int[]> intervals)
		{
			intervals.Sort((i, j) => i[0].CompareTo(j[0]));

			int range = 0;
			int[] lastInterval = intervals[0];

			for (int count = 1; count < intervals.Count; count++)
			{
				if (intervals[count][0] < lastInterval[1])
				{
					//this can be merged
					lastInterval[1] = System.Math.Max(lastInterval[1], intervals[count][1]);
				}
				else
				{
					//add the last interval
					range += lastInterval[1] - lastInterval[0];

					//this is a new one
					lastInterval = intervals[count];
				}
			}

			//for very last one;
			range += lastInterval[1] - lastInterval[0];

			return range;
		}

		#endregion

		#region Longest Continuous Subsequence For Sum K

		/// <summary>
		/// [3, 5, 6, 7, 9]
		/// Longest continuous subsequence for sum of 18 - [5, 6, 7]
		/// 
		/// Calculate the cumulative sum and then make this into a two sum question
		/// [3, 8, 14, 21, 30] in a dictionary
		/// from the back, see if total - k exists in the dictionary
		/// 30 -> look for 12?
		/// 21 -> look for 3?
		/// 
		/// When we find one, start from the next cell to the current cell
		/// </summary>
		/// <param name="numbers"></param>
		/// <param name="k"></param>
		/// <returns></returns>
		public static List<int> LongestSubsequenceForK(int[] numbers, int k)
		{
			Dictionary<int, int> sums = new Dictionary<int, int>();

			int sum = 0;
			int index = 0;
			foreach (int number in numbers)
			{
				sum += number;
				sums.Add(sum, index);
				index++;
			}

			foreach (int number in sums.Keys)
			{
				int remainder = number - k;
				if ((sums.ContainsKey(remainder)) && (sums[number] > sums[remainder]))
				{
					List<int> result = new List<int>();
					for (int resultIndex = sums[remainder] + 1; resultIndex <= sums[number]; resultIndex++)
					{
						result.Add(numbers[resultIndex]);
					}
					return result;
				}
			}

			throw new Exception("Cannot find a valid subsequence");
		}

		#endregion

		#region Count Lines Cross Over

		public struct Point {
			public int X { get; set; }
			public int Y { get; set; }
		}

		public struct Line {
			public Point Start { get; set; }
			public Point End { get; set; }
		}

		/// <summary>
		/// When there are vertical and horizontal lines which do not overlap on respective axis,
		/// find number of intersections
		/// 
		/// 
		///                |   |
		///         _______|___|__       |
		///                |   |         |_______
		///                | __|_________|__
		///                    |
		///                    
		/// 5 in the example
		/// </summary>
		/// <param name="lines"></param>
		/// <returns></returns>
		public static int CountCrossOver(Line[] lines)
		{
            //because I use a sorted dictionary, it won't handle lines where keys are same, should use priority queue or heap to allow duplicate keys
            //but this should be enough to get the idea

            //first parse the lines into vertical and horizontal sets ordered by their respective x position
			SortedDictionary<int, Line> verticalLines = new SortedDictionary<int, Line>();
			SortedDictionary<int, Line> horizontalLines = new SortedDictionary<int, Line>();
			
			foreach(Line line in lines) {
				if (line.Start.X == line.End.X)
				{
					//vertical line
					verticalLines.Add(line.Start.X, line);
				}
				else
				{
					//horizontal line
					horizontalLines.Add(line.Start.X, line);
				}
			}

			//used to store the end points and y's so we can use this to remove from the current stack
			SortedDictionary<int, int> lineEnds = new SortedDictionary<int, int>();
			//used to store the current overlapping horizontal lines
			List<Line> currentStack = new List<Line>();
			//total count
			int count = 0;

			int horizontalIndex = 0;
			int verticalIndex = 0;
			int endIndex = 0;

			//since we only care about cross overs, we only care about processing all vertical lines
			while (verticalIndex < verticalLines.Count)
			{
				int horizontalX = horizontalLines.Keys.ElementAt(horizontalIndex);
				int verticalX = verticalLines.Keys.ElementAt(verticalIndex);
				int endX = (lineEnds.Count > endIndex) ? lineEnds.Keys.ElementAt(endIndex) : int.MaxValue;

				//now find the next point
				int nextSignificantX = System.Math.Min(horizontalX, System.Math.Min(verticalX, endX));

				//perform various operations in order (should add horizontal line first -> check for cross -> remove ending lines)
                
                //first add any new lines
                if (nextSignificantX == horizontalX)
                {
                    Line horizontalLine = horizontalLines[horizontalX];

                    //add to current stack
                    currentStack.Add(horizontalLine);

                    //add to line ends
                    lineEnds.Add(horizontalLine.End.X, horizontalLine.End.Y);

                    horizontalIndex++;
                }

				//then check if we have a cross over
				if (nextSignificantX == verticalX)
				{
					Line verticalLine = verticalLines[verticalX];
					foreach (Line line in currentStack) { 
						//if horizontal line is within bounds of the vertical line
						if ((verticalLine.Start.Y <= line.Start.Y) && (verticalLine.End.Y >= line.Start.Y)) {
							count++;
						}
					}
					verticalIndex++;
				}

				//now remove any lines ending
				if (nextSignificantX == endX)
				{
					//get the y position of horizontal line that's ending
					int endY = lineEnds[endX];
					
					//now remove from current stack
					currentStack = currentStack.Where(l => l.Start.Y != endY).ToList();

					endIndex++;
				}
			}
			
			return count;
		}

		#endregion

        #region Histogram Largest Rectangle
        
        private class LargestStorage
        {

            public int Index { get; set; }
            public int Height { get; set; }

        }

        /// <summary>
        /// Given a histogram, find the area of largest rectangle that can be formed
        /// 
        ///             -----
        ///         ----|   |
        ///         |   |   |
        ///         |   |   |----
        ///         |   |   |   |
        ///         |   |   |   |
        ///         
        /// Using a stack, push any histogram of greater height. Once we encounter a short
        /// histogram, we will pop off any greater height ones and calculate the area
        /// If this area is greater than the max area, then replace max
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public static long GetLargestRectangle(int[] heights)
        {
            long maxArea = 0;
            Stack<LargestStorage> storage = new Stack<LargestStorage>();

            int index = 0;
            foreach (int height in heights)
            {
                while ((storage.Count > 0) && (storage.Peek().Height > height))
                {
                    LargestStorage last = storage.Pop();
                    long area = (index - last.Index) * last.Height;
                    if (area > maxArea)
                    {
                        maxArea = area;
                    }
                }

                //need to put the current one for the future
                storage.Push(new LargestStorage { Index = index, Height = height });

                index++;
            }

            //need to pop stuff off the stack
            while (storage.Count > 0)
            {
                LargestStorage last = storage.Pop();
                long area = (index - last.Index) * last.Height;
                if (area > maxArea)
                {
                    maxArea = area;
                }
            }

            return maxArea;
        }

        #endregion

        #region Reservoir Sampling

        /// Allow you do achieve k/n probability for any element when n is unknown or really large
        /// 
        /// Define a reservoir of size k
        /// For every item under k, put it into reservoir
        /// For every ith item after k, it will go in with a probability of k/i 
        /// If the ith item is supposed to go into the reservoir then one item from the reservoir should come out with probability of 1/k
        /// The two steps can be combined
        /// 
        public static int[] ReservoirSampling(int[] array, int sampleSize)
        {
            int[] sample = new int[sampleSize];

            for (int index = 0; index < sampleSize; index++)
            {
                sample[index] = array[index];
            }

            for (int index = sampleSize; index < array.Length; index++)
            {
                int probability = new Random().Next(index + 1);
                if (probability < sampleSize)
                {
                    //this means we want to include this item
                    //combine the rejection step and just use the probability as index
                    sample[probability] = array[index];
                }
            }

            return sample;
        }

        #endregion

        #region Dot Product Sparse Vector

        //the question might be how to store the sparse vector...the typical answer is position & value
        //using dictionary or an array...each will have a different solution
        public static BigInteger DotProductDictionary(Dictionary<int, int> vector1, Dictionary<int, int> vector2)
        {
            Dictionary<int, int> smaller = (vector1.Count > vector2.Count) ? vector2 : vector1;
            Dictionary<int, int> larger = (vector1.Count > vector2.Count) ? vector1 : vector2;

            //overflow...2^32 * 2^32 in each array...and then 2^32 entries...so we need 2^96 unsigned int
            BigInteger dotProduct = 0;
            foreach (int position in smaller.Keys)
            {
                if (larger.ContainsKey(position))
                {
                    dotProduct += smaller[position] * larger[position];
                }
            }

            return dotProduct;
        }

        public static BigInteger DotProductList(List<Tuple<int, int>> vector1, List<Tuple<int, int>> vector2)
        {
            //overflow...2^32 * 2^32 in each array...and then 2^32 entries...so we need 2^96 unsigned int
            BigInteger dotProduct = 0;

            int vector1Index = 0;
            int vector2Index = 0;

            while ((vector1Index < vector1.Count) && (vector2Index < vector2.Count))
            {
                //if position of vector 1 is lower, advance vector 1 position
                if (vector1[vector1Index].Item1 < vector2[vector2Index].Item1)
                {
                    vector1Index++;
                }
                else if (vector1[vector1Index].Item1 > vector2[vector2Index].Item1)
                {
                    vector2Index++;
                }
                else {
                    dotProduct += vector1[vector1Index].Item2 * vector2[vector2Index].Item2;
                    vector1Index++;
                    vector2Index++;
                }
            }

            return dotProduct;
        }

        #endregion

        #region Look To Say

        /// <summary>
        /// generate the following sequence up to given number of times
        /// 1, 11, 21, 1211, 111221, 312211, 13112221, 1113213211, 31131211131221
        /// 1, one 1, two 1, one 2 one 1, one 1 one 2 two 1, three 1 two 2 one 1
        /// 
        /// seems like i just need to count number of time each number occurrs consequtively and convert
        /// that to a number
        /// </summary>
        /// <returns></returns>
        public static List<int> LookToSay(int number)
        {
            List<int> result = new List<int>();

            int currentNumber = 1;
            for (int count = 0; count < number; count++)
            {
                StringBuilder nextNumber = new StringBuilder();

                char lastCharacter = 'a';
                int characterCount = 1;
                foreach(char character in currentNumber.ToString()) {
                    if (character == lastCharacter)
                    {
                        characterCount++;
                    }
                    else 
                    {
                        //add the occurrence and number
                        if (lastCharacter != 'a')
                        {
                            nextNumber.Append(characterCount.ToString());
                            nextNumber.Append(lastCharacter);
                        }

                        //initialize to new number
                        lastCharacter = character;
                        characterCount = 1;
                    }
                }

                //final number
                nextNumber.Append(characterCount.ToString());
                nextNumber.Append(lastCharacter);

                //add the number
                result.Add(currentNumber);
                
                //change the current numbers
                currentNumber = int.Parse(nextNumber.ToString());
            }

            return result;
        }

        public static List<int> LookToSayNoString(int number)
        {
            List<int> result = new List<int>();

            int currentNumber = 1;

            for (int count = 0; count < number; count++)
            {
                int numberCount = 0;
                int lastNumber = 0;
                int lookToSayCount = 0;
                int nextNumber = 0;

                result.Add(currentNumber);

                while (currentNumber > 0)
                {
                    int lastDigit = currentNumber % 10;
                    
                    if (lastDigit == lastNumber)
                    {
                        numberCount++;
                    }
                    else
                    {
                        if (lastNumber != 0)
                        {                            
                            nextNumber += ((numberCount * 10) + lastNumber) * ((int)System.Math.Pow(100, lookToSayCount));
                            lookToSayCount++;
                        }

                        numberCount = 1;
                        lastNumber = lastDigit;
                    }

                    currentNumber /= 10;
                }

                //last bit
                nextNumber += ((numberCount * 10) + lastNumber) * ((int)System.Math.Pow(100, lookToSayCount));
                currentNumber = nextNumber;
            }

            return result;
        }

        #endregion

        #region Max Sum Non Adjacent Sub Sequence

        /// <summary>
        /// Find the max sum from the array where no two consecutive numbers are considered
        /// 3 2 7 10 should return 13 (sum of 3 and 10) 
        /// 3 2 5 10 7 should return 15 (sum of 3, 5 and 7)
        /// 
        /// Continuously perform this logic
        /// max including current number = previous max excluded + current number
        /// max excluding current number = max of previous (included, excluded)
        /// 
        /// i=3, x=0 -> i=2, x=3 -> i=10, x=3 -> i=13, x=10
        /// i=3, x=0 -> i=2, x=3 -> i=8, x=3 -> i=13, x=8 -> i=15, x=13
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int MaxSumNonAdjacentSubSequence(int[] numbers)
        {
            if ((numbers == null) || (numbers.Length == 0)) {
                throw new ArgumentException();
            }

            int previousMaxIncluded;
            int maxIncluded = numbers[0];
            int maxExcluded = 0;

            for (int index = 1; index < numbers.Length; index++)
            {
                previousMaxIncluded = maxIncluded;
                maxIncluded = maxExcluded + numbers[index];
                maxExcluded = System.Math.Max(previousMaxIncluded, maxExcluded);
            }

            return System.Math.Max(maxIncluded, maxExcluded);
        }

        #endregion

        #region Activity Selection

        public struct Times
        {
            public int Start { get; set; }
            public int End { get; set; }
        }

        /// <summary>
        /// This is a classic greedy algorithm
        /// 
        /// If you sort all activities by end time, you can sequentially take any
        /// activity where start time is after current activity. Since we always optimized
        /// on end time, we should have the most number of activities
        /// 
        /// O(n)
        /// </summary>
        /// <param name="activities"></param>
        /// <returns></returns>
        public static int ActivitySelectionGreedy(List<Times> activities)
        {
            List<Times> sortedActivities = activities.OrderBy(a => a.End).ToList();

            int count = 1;
            Times lastActivity = sortedActivities[0];
            for (int index = 1; index < sortedActivities.Count; index++)
            {
                if (sortedActivities[index].Start > lastActivity.End)
                {
                    lastActivity = sortedActivities[index];
                    count++;
                }
            }

            return count;
        }

        #endregion

        #region Overlapping Activities

        private enum TimeTrackOperation
        {
            Start,
            End
        }

        private struct TimeTrack
        {
            public int Time { get; set; }
            public int Index { get; set; }
            public TimeTrackOperation Operation { get; set; }
        }

        /// <summary>
        /// Given set of overlapping activities in terms of start/end time,
        /// find the minimum number of meeting rooms
        /// 
        /// Seems like it's just simple book keeping
        /// 
        ///     xxxxxxx   wwwww
        ///       yyyyyyyyyyy  tttt
        ///          zzzzzz
        /// 
        /// Sort by start time, and then careful track parallel activities
        /// </summary>
        /// <param name="activities"></param>
        /// <returns></returns>
        public static int OverlappingActivities(List<Times> activities)
        {
            Dictionary<int, int> tracker = new Dictionary<int, int>();

            int count = 0;
            List<TimeTrack> activitySequences = new List<TimeTrack>();
            foreach (Times times in activities)
            {
                activitySequences.Add(new TimeTrack { Time = times.Start, Index = count, Operation = TimeTrackOperation.Start });
                activitySequences.Add(new TimeTrack { Time = times.End, Index = count, Operation = TimeTrackOperation.End });
                count++;
            }

            count = 0;
            List<TimeTrack> sortedActivitySequences = activitySequences.OrderBy(a => a.Time).ToList();
            foreach (TimeTrack timeTrack in sortedActivitySequences)
            {
                if (timeTrack.Operation == TimeTrackOperation.Start)
                {
                    tracker.Add(timeTrack.Index, timeTrack.Index);
                    if (tracker.Count > count)
                    {
                        count = tracker.Count;
                    }
                }
                else
                {
                    tracker.Remove(timeTrack.Index);
                }
            }
            return count;
        }

        #endregion

        #region Permutation Sequence

        /// <summary>
        /// [1,2,3] have the following permutations:
        /// 
        /// [1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], and [3,2,1].
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static IList<IList<int>> Permute(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentException();
            }

            if (numbers.Length == 0)
            {
                return new List<IList<int>>();
            }

            bool[] used = new bool[numbers.Length];

            return Permute(numbers, used, 1);
        }

        public static IList<IList<int>> Permute(int[] numbers, bool[] used, int usedNum)
        {
            IList<IList<int>> result = new List<IList<int>>();
            for (int index = 0; index < numbers.Length; index++)
            {
                if (!used[index])
                {
                    if ((numbers.Length - usedNum) > 0)
                    {
                        used[index] = true;

                        IList<IList<int>> subResult = Permute(numbers, used, usedNum + 1);
                        foreach (IList<int> pattern in subResult)
                        {
                            for (int injection = 0; injection <= pattern.Count; injection++)
                            {
                                IList<int> newPattern = new List<int>(pattern);
                                newPattern.Insert(injection, numbers[index]);
                                result.Add(newPattern);
                            }
                        }
                    }
                    else
                    {
                        result.Add(new List<int>() { numbers[index] });
                    }
                }
            }
            return result;
        }

        // we can calculate the digit
        // 123
        // 132
        // 213
        // 231
        // 312
        // 321
        // if we are looking at k = 5...each number can have up to (n-1)! permutations..this case 2 each
        // so 5th one is the 1st of 3rd number which is 3...then it's matter of recursively find the right number
        // e.g. 6th one is 2nd of the 3rd number, so find 3, and then pass n = 1, k = 2 with used marking 3
        // since the k = 2 has to first (1!) of the second number, it's 2
        public static string GetPermutation(int n, int k)
        {
            if ((n < 1) || (n > 9))
            {
                throw new ArgumentException();
            }

            if (k == 0)
            {
                return null;
            }

            int product = 1;
            Dictionary<int, int> factorial = new Dictionary<int, int>();
            for (int number = 1; number < n; number++)
            {
                product *= number;
                factorial.Add(number, product);
            }

            bool[] used = new bool[n + 1];
            return GetPermutation(n, k, used, factorial);
        }

        private static string GetPermutation(int n, int k, bool[] used, Dictionary<int, int> factorial)
        {
            StringBuilder result = new StringBuilder();

            int unUsedCount = 0;
            int orderOfNumber = (n == 1) ? 1 : (int)System.Math.Ceiling(k * 1d / factorial[n - 1]);
            for (int number = 1; number < used.Length; number++)
            {
                if (!used[number])
                {
                    unUsedCount++;
                    if (unUsedCount == orderOfNumber)
                    {
                        used[number] = true;
                        result.Append(number);

                        if (n > 1)
                        {
                            //5 - (2 * 2) = 1...6 - (2 * 2) = 2
                            int secondOrder = k - (factorial[n - 1] * (orderOfNumber - 1));
                            result.Append(GetPermutation(n - 1, secondOrder, used, factorial));
                        }
                        break;
                    }
                }
            }

            return result.ToString();
        }

        #endregion

    }

}
