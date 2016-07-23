using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class InvalidParentheses
    {
        public static List<string> RemoveInvalidParentheses(string s)
        {
            List<string> answer = new List<string>();
            Remove(s, answer, 0, 0, new char[] { '(', ')' });
            return answer;
        }

        public static void Remove(string s, List<string> answer, int last_i, int last_j, char[] par)
        {
            int stack = 0, i;

            // Search for mismatch
            for (i = last_i; i < s.Length; i++)
            {
                if (s[i] == par[0]) stack++;
                else if (s[i] == par[1]) stack--;
                if (stack < 0) break;
            }

            // Remove a parenthesis
            if (stack < 0)
            {
                for (int j = last_j; j <= i; j++)
                {
                    if (s[j] == par[1] && (j == last_j || s[j - 1] != par[1]))
                    {
                        string candidate = s.Substring(0, j) + s.Substring(j + 1);
                        Remove(candidate, answer, i, j, par);
                    }
                }

                return;
            }

            string reversed = new string(s.Reverse().ToArray());
            if (par[0] == '(')
            {
                Remove(reversed, answer, 0, 0, new char[] { ')', '(' });
            }
            else
            {
                // double reversed
                answer.Add(reversed);
            }
        }
    }
}
