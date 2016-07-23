using System;
using System.Collections.Generic;

namespace CodingProblems
{
    public class Chapter16
    {
        public List<Tuple<int, int>> SumPairs(int[] array, int sum)
        {
            List<Tuple<int, int>> results = new List<Tuple<int, int>>();
            IDictionary<int, int> knownValues = new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                var complement = sum - array[i];
                if (knownValues.ContainsKey(complement))
                {
                    results.Add(new Tuple<int, int>(knownValues[complement], i));
                }
                else
                {
                    knownValues[array[i]] = i;
                }
            }

            return results;
        }
    }
}
