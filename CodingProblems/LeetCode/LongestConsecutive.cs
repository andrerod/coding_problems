using System.Collections.Generic;

namespace ClassLibrary2
{
    public class LongestConsecutive
    {
        public static int Solve(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return 1;

            Dictionary<int, int> counts = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                counts[num] = counts.ContainsKey(num)
                   ? counts[num] + 1
                   : 1;
            }

            int maxLength = 1;
            foreach (var num in nums)
            {
                if (counts.ContainsKey(num))
                {
                    int left = num - 1;
                    int right = num + 1;
                    int length = 1;

                    counts[num]--;
                    while (counts.ContainsKey(left))
                    {
                        counts.Remove(left);
                        left--;
                        length++;
                    }

                    while (counts.ContainsKey(right))
                    {
                        counts.Remove(right);
                        right++;
                        length++;
                    }

                    if (length > maxLength)
                        maxLength = length;
                }
            }

            return maxLength;
        }
    }
}
