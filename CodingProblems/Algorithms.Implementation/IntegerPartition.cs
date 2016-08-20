using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Algorithms.Implementation
{
    public class IntegerPartition
    {

        private class DPKey {

            public int Key1 { get; set; }
            public int Key2 { get; set; }

            public override bool Equals(Object obj)
            {
                // Check for null values and compare run-time types.
                if (obj == null || GetType() != obj.GetType())
                    return false;

                DPKey key = (DPKey)obj;
                return (Key1 == key.Key1) && (Key2 == key.Key2);
            }

            public override int GetHashCode()
            {
                return Key1 ^ Key2;
            }
        }

        #region Partition

        public static List<List<int>> Partition(int number)
        {
            List<List<int>> partitions = new List<List<int>>();

            Partition(number, number, partitions, new List<int>());

            return partitions;
        }

        /// <summary>
        /// we want to get partitions like this for sum = 4
        /// 4
        /// 3 + 1
        /// 2 + 2
        /// 2 + 1 + 1
        /// 1 + 1 + 1 + 1
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="largestNumber"></param>
        /// <param name="partitions"></param>
        private static void Partition(int sum, int largestNumber, List<List<int>> partitions, List<int> currentParitition)
        {
            if (sum == 0)
            {
                //we crossed the end, we should finish this partition
                //3. add to partition 1 + 1 + 1 + 1
                //8. add to partition 2 + 1 + 1
                //11. add to partition 2 + 2
                //16. add to partition 3 + 1
                //19. add to partition 4
                partitions.Add(currentParitition);
                return;
            }

            if (largestNumber > 1)
            {
                //this will go
                //1. have 4, 4 -> 4, 3 -> 4, 2 -> 4, 1
                //4. process 4, 2
                //6. have 2, 2 -> 2, 1
                //9. process 2, 2
                //12. process 4, 3
                //14. have 1, 3 -> 1, 2 -> 1, 1
                //17. process 1, 2 -> process 1, 3
                //18. process 4, 4
                Partition(sum, largestNumber - 1, partitions, new List<int>(currentParitition));
            }
            
            if (sum >= largestNumber)
            {
                //first we will have 4, 1, so we will have
                //2. add 1 -> 3, 1 -> add 1 -> 2, 1 -> add 1 -> 1, 1 -> add 1 -> 0, 1
                //5. add 2 -> 2, 2
                //7. add 1 -> 1, 1 -> add 1 -> 0, 1
                //10. add 2 -> 0, 2
                //13. add 3 -> 1, 3 
                //15. add 1 -> 0, 1
                //19. add 4 -> 0, 4
                currentParitition.Add(largestNumber);
                Partition(sum - largestNumber, largestNumber, partitions, currentParitition);
            }
        }

        /// <summary>
        /// Sum             0           1           2           3           4           5
        /// Largest 0       0           0           0           0           0           0
        ///         1       0           1          1,1        1,1,1      1,1,1,1    1,1,1,1,1
        ///         2       0           0           2          2,1     2,1,1   2,2  2,1,1,1 2,2,1
        ///         3       0           0           0           3          3,1      3,1,1   3,2
        ///         4       0           0           0           0           4       4,1
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="largestNumber"></param>
        /// <param name="partitions"></param>
        public static List<List<int>> PartitionDynamicProgramming(int sum)
        {
            List<List<int>> partitions = new List<List<int>>();
            Dictionary<DPKey, List<List<int>>> cache = new Dictionary<DPKey, List<List<int>>>();

            var largestNumber = sum;
            for (int i = 0; i <= largestNumber; i++)
            {
                for(int j = 0; j <= sum; j++) {
                    if ((i == 0) || (j == 0))
                    {
                        cache.Add(new DPKey { Key1 = i, Key2 = j }, new List<List<int>>());
                        continue;
                    }

                    //look back sum - largest, and scan up vertically
                    //for 4 (sum) - 2 (largest), look at 4-2 = 2 and scan all sums up (2 & 1,1) and append 2 to it
                    //this will give 2, 2 and 2, 1, 1
                    //for 5 - 2, look at 5-2 = 3 and scan all variations up (2, 1 & 1, 1, 1) and append 2 to it
                    //this will give 2, 2, 1 & 2, 1, 1, 1
                    List<List<int>> tempPartitions = new List<List<int>>();
                    var remainder = j - i; // sum - largest

                    if (remainder >= 0)
                    {
                        //make sure we don't go into negative, otherwise non-existing key
                        for (int ii = i; ii > 0; ii--)
                        {
                            var previousKey = new DPKey { Key1 = ii, Key2 = remainder };

                            //since there could be multiple partitions, we need to iterate through all variations
                            foreach (List<int> partition in cache[previousKey])
                            {
                                //combine the current largest with previous partitions
                                List<int> newPartition = new List<int>();
                                //do this to keep the largest first order
                                newPartition.Add(i);
                                newPartition.AddRange(partition);
                                tempPartitions.Add(newPartition);
                            }
                        }

                        //add the current if remainder is 0 since this is the sum
                        if (remainder == 0)
                        {
                            tempPartitions.Add(new List<int>(new int[] { i }));
                        }
                    }

                    cache.Add(new DPKey { Key1 = i, Key2 = j }, tempPartitions);
                }
            }

            //now just need to iterate through all partitions for the given sum and each largest number
            for (int i = 0; i <= largestNumber; i++)
            {
                foreach (List<int> partition in cache[new DPKey { Key1 = i, Key2 = sum }])
                {
                    partitions.Add(partition);
                }
            }

            return partitions;
        }

        #endregion

        #region Combination Subset

        public static List<List<int>> CombinationSubSet(int[] array, int number)
        {
            List<List<int>> partitions = new List<List<int>>();

            CombinationSubSet(array, number, array.Length - 1, partitions, new List<int>());

            return partitions;
        }

        private static void CombinationSubSet(int[] array, int sum, int index, List<List<int>> partitions, List<int> currentParitition)
        {
            if (sum == 0)
            {
                //we found the exact match
                partitions.Add(currentParitition);
                return;
            }

            int number = array[index];

            if (index > 0)
            {
                CombinationSubSet(array, sum, index - 1, partitions, new List<int>(currentParitition));
            }

            if (sum >= number)
            {
                currentParitition.Add(number);
                CombinationSubSet(array, sum - number, index, partitions, currentParitition);
            }
        }
        
        /// <summary>
        /// sum             0       1       2       3       4       5       6       7       8       9       10
        /// largestItem 0
        ///             2                   2              2,2            2,2,2          2,2,2,2         2,2,2,2,2                
        ///             3                           3              3,2     3,3    3,2,2           3,3,3  3,3,2,2                  
        ///             7                                                           7                      7,3
        /// </summary>
        /// <param name="array"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static List<List<int>> CombinationSubSetDynamicProgramming(int[] array, int sum)
        {
            List<List<int>> partitions = new List<List<int>>();
            Dictionary<DPKey, List<List<int>>> cache = new Dictionary<DPKey, List<List<int>>>();

            var largestNumber = sum;
            for (int i = 0; i <= array.Length; i++)
            {
                for (int j = 0; j <= sum; j++)
                {
                    if ((i == 0) || (j == 0))
                    {
                        cache.Add(new DPKey { Key1 = i, Key2 = j }, new List<List<int>>());
                        continue;
                    }

                    int number = array[i - 1];
                    List<List<int>> tempPartitions = new List<List<int>>();
                    var remainder = j - number; // sum - largest

                    if (remainder >= 0)
                    {
                        //make sure we don't go into negative, otherwise non-existing key
                        for (int ii = i; ii > 0; ii--)
                        {
                            var previousKey = new DPKey { Key1 = ii, Key2 = remainder };

                            //since there could be multiple partitions, we need to iterate through all variations
                            foreach (List<int> partition in cache[previousKey])
                            {
                                //combine the current largest with previous partitions
                                List<int> newPartition = new List<int>();
                                //do this to keep the largest first order
                                newPartition.Add(number);
                                newPartition.AddRange(partition);
                                tempPartitions.Add(newPartition);
                            }
                        }

                        //base condition
                        //add the current if remainder is 0 since this is the sum
                        if (remainder == 0)
                        {
                            tempPartitions.Add(new List<int>(new int[] { number }));
                        }
                    }

                    cache.Add(new DPKey { Key1 = i, Key2 = j }, tempPartitions);
                }
            }

            //now just need to iterate through all partitions for the given sum and each largest number
            for (int i = 0; i <= array.Length; i++)
            {
                foreach (List<int> partition in cache[new DPKey { Key1 = i, Key2 = sum }])
                {
                    partitions.Add(partition);
                }
            }

            return partitions;
        }

        #endregion

        #region Factors

        /// <summary>
        /// input 12
        /// 2*2*3
        /// 3*4
        /// 2*6
        /// 1*12
        /// 
        /// get sqrt of number, for each int, iterate down and divide, if still divisible, recurse
        /// same as integer partitioning
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<List<int>> GetFactorsRecursive(int number)
        {
            List<List<int>> result = new List<List<int>>();

            GetFactorsRecursive(number, (int)System.Math.Floor(System.Math.Sqrt(number)), result, new List<int>());

            return result;
        }

        private static void GetFactorsRecursive(int number, int divisor, List<List<int>> result, List<int> currentSet) {
            if (divisor > 1)
            {
                //handle cases like 3, 2, 1
                GetFactorsRecursive(number, divisor - 1, result, new List<int>(currentSet));
            }

            //since this is division, and we already have terminal condition we just have to do it if it's a clean division (no fraction)
            if ((number >= divisor) && ((number % divisor) == 0))
            {
                //handle cases like 3, 4 -> 3, 2, 2
                if (divisor == 1)
                {
                    currentSet.Add(number);
                    if (currentSet.Count == 1)
                    {
                        currentSet.Add(1);
                    }
                    result.Add(currentSet);
                }
                else
                {
                    currentSet.Add(divisor);
                    GetFactorsRecursive(number / divisor, (int)System.Math.Floor(System.Math.Sqrt(number / divisor)), result, currentSet);
                }
            }
        }

        #endregion

    }
}
