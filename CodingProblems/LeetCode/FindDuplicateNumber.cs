using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class FindDuplicateNumber
    {
        public int FindDuplicate(int [] nums)
        {
            int fast = 0;
            int slow = 0;
            fast = nums[nums[fast]];
            slow = nums[slow];
            while (fast != slow)
            {
                fast = nums[nums[fast]];
                slow = nums[slow];
            }

            fast = 0;
            while (nums[fast] != nums[slow])
            {
                fast = nums[fast];
                slow = nums[slow];
            }

            return nums[slow];
        }
    }
}
