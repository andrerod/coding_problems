using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class FirstPositive
    {
        public int FirstMissingPositive(int[] nums)
        {
            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                while (nums[i] > 0 && nums[i] <= n && nums[i] != i + 1 && nums[nums[i] - 1] != nums[i])
                {
                    var tmp = nums[nums[i] - 1];
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = tmp;
                }
            }

            for (int j = 0; j < n; j++)
            {
                if (nums[j] != j + 1)
                    return j + 1;
            }

            return n + 1;
        }
    }
}
