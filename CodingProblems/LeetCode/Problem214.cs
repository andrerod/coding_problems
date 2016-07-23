using System.Linq;

namespace ClassLibrary2
{
    public class Problem214
    {
        public static string ShortestPalindrome(string s)
        {
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (IsPalindrome(s, i))
                {
                    if (i < s.Length - 1)
                    {
                        return new string(s.Substring(i + 1).Reverse().ToArray()) + s;
                    }

                    return s;
                }
            }

            return s;
        }

        public static bool IsPalindrome(string s, int endPos)
        {
            for (int i = 0; i <= endPos / 2; i++)
            {
                if (s[i] != s[endPos - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
