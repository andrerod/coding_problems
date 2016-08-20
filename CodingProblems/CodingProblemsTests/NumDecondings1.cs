using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodingProblemsTests
{
    [TestClass]
    public class NumDecondings1
    {
        [TestMethod]
        public void NumDecodings()
        {
            var input = "12";

            var dp = new int[input.Length + 1];
            dp[0] = 1;

            if (input[0] == '0')
            {
                dp[1] = 0;
            }
            else
            {
                dp[1] = 1;
            }

            for (int i = 2; i < input.Length + 1; i++)
            {
                int one = Int32.Parse(input.Substring(i - 1, 1));
                int two = Int32.Parse(input.Substring(i - 2, 2));

                if (two >= 10 && two <= 26)
                {
                    dp[i] += dp[i - 2];
                }

                if (one != 0)
                {
                    dp[i] += dp[i - 1];
                }
            }

            var res = dp[input.Length];
            Console.WriteLine(res);
        }
    }
}
