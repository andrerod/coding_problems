using System;

namespace ClassLibrary2
{
    public class MaximumNumber
    {
        public int[] MaxNumber(int[] nums1, int[] nums2, int k)
        {
            int[] res = new int[k];

            for (int i = Math.Max(0, k - nums2.Length); i <= k && i <= nums1.Length; i++)
            {
                var temp1 = MaxNumber(nums1, i);
                var temp2 = MaxNumber(nums2, k - i);
                var candidate = Merge(temp1, temp2, k);
                if (Compare(candidate, 0, res, 0))
                {
                    res = candidate;
                }
            }

            return res;
        }

        // Faz o merge de dois numeros escolhendo sempre o maior de cada um
        public int[] Merge(int[] nums1, int[] nums2, int k)
        {
            int[] res = new int[nums1.Length + nums2.Length];
            for (int i = 0, j = 0, r = 0; r < k; r++)
            {
                res[r] = Compare(nums1, i, nums2, j) ? nums1[i++] : nums2[j++];
            }

            return res;
        }

        // compara dois numeros digito a digito
        public bool Compare(int[] nums1, int i, int[] nums2, int j)
        {
            int size1 = nums1.Length, size2 = nums2.Length;
            while (i < size1 && j < size2 && nums1[i] == nums2[j])
            {
                i++;
                j++;
            }
            return j == size2 || (i < size1 && nums1[i] > nums2[j]);
        }

        // Finds the maximum number with length k out of available nums1 digits.
        public int[] MaxNumber(int[] nums1, int k)
        {
            int[] answer = new int[k];
            for (int potentialDigit = 0, j = 0; potentialDigit < nums1.Length; potentialDigit++)
            {
                while (nums1.Length - potentialDigit + j > k && j > 0 && answer[j - 1] < nums1[potentialDigit])
                {
                    j--;
                }
                if (j < k)
                {
                    answer[j++] = nums1[potentialDigit];
                }
            }

            return answer;
        }
    }
}
