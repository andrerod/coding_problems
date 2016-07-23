using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class MinimumWindowSubstring
    {
        public static string MinWindow(string s, string t)
        {
            var charCount = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                if (charCount.ContainsKey(t[i]))
                {
                    charCount[t[i]]++;
                }
                else charCount[t[i]] = 1;
            }

            int charRemaining = t.Length;
            int start = 0;
            int minWindowSize = int.MaxValue;
            string minWindow = "";
            for (int end = 0; end < s.Length; end++)
            {
                if (charCount.ContainsKey(s[end]))
                {
                    if (charCount[s[end]] > 0)
                    {
                        charRemaining--;
                    }

                    charCount[s[end]]--;

                    while (charRemaining == 0)
                    {
                        if (end - start + 1 < minWindowSize)
                        {
                            minWindowSize = end - start + 1;
                            minWindow = s.Substring(start, end - start + 1);
                        }

                        if (charCount.ContainsKey(s[start]))
                        {
                            charCount[s[start]]++;
                            if (charCount[s[start]] > 0)
                            {
                                charRemaining++;
                            }
                        }

                        start++;
                    }
                }
            }

            return minWindow;
        }
    }
}
