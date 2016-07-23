using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class CandyDistribute
    {
        public static int Candy(int[] ratings)
        {
            int n = ratings.Length;

            int[] useq = new int[n];
            int[] dseq = new int[n];

            for (int i = 1; i < n; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    useq[i] = useq[i - 1] + 1;
                }
            }

            for (int i = n - 2; i > -1; i--)
            {
                if (ratings[i] > ratings[i + 1])
                {
                    dseq[i] = dseq[i + 1] + 1;
                }
            }

            int candies = 0;
            for (int i = 0; i < n; i++)
            {
                candies += (dseq[i] > useq[i] ? dseq[i] : useq[i]) + 1;
            }

            return candies;
        }
    }
}
