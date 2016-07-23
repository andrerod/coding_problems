namespace ClassLibrary2
{
    public class InterleavingString
    {
        // Recursive solution
        public static bool IsInterleaveOld(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;
            return IsInterleaveRecursive(s1, 0, s2, 0, s3, 0);
        }

        public static bool IsInterleaveRecursive(string s1, int positionS1, string s2, int positionS2, string s3, int positionS3)
        {
            if (positionS3 == s3.Length) return true;
            if (positionS1 == s1.Length) return s2.Substring(positionS2) == s3.Substring(positionS3);
            if (positionS2 == s2.Length) return s1.Substring(positionS1) == s3.Substring(positionS3);

            if (s1[positionS1] == s3[positionS3] && s2[positionS2] == s3[positionS3])
            {
                return IsInterleaveRecursive(s1, positionS1 + 1, s2, positionS2, s3, positionS3 + 1) || IsInterleaveRecursive(s1, positionS1, s2, positionS2 + 1, s3, positionS3 + 1);
            }
            else if (s1[positionS1] == s3[positionS3])
            {
                return IsInterleaveRecursive(s1, positionS1 + 1, s2, positionS2, s3, positionS3 + 1);
            }
            else if (s2[positionS2] == s3[positionS3])
            {
                return IsInterleaveRecursive(s1, positionS1, s2, positionS2 + 1, s3, positionS3 + 1);
            }
            else return false;
        }

        public static bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;

            bool[,] dp = new bool[s1.Length + 1, s2.Length + 1];
            dp[0, 0] = true;

            for (int i = 1; i <= s1.Length && i <= s3.Length; i++)
            {
                if (s1[i - 1] == s3[i - 1] && dp[i - 1, 0])
                {
                    dp[i, 0] = true;
                }
            }

            for (int j = 1; j <= s2.Length && j <= s3.Length; j++)
            {
                if (s2[j - 1] == s3[j - 1] && dp[0, j - 1])
                {
                    dp[0, j] = true;
                }
            }

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    int k = i + j;

                    if (s1[i - 1] == s3[k - 1] && s1[i - 1] != s1[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else if (s2[j - 1] == s3[k - 1] && s1[i - 1] != s2[j - 1])
                    {
                        dp[i, j] = dp[i, j - 1];
                    }
                    else if (s1[i - 1] == s2[j - 1] && s1[i - 1] == s3[k - 1])
                    {
                        dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
                    }
                }
            }

            return dp[s1.Length, s2.Length];
        }
    }
}
