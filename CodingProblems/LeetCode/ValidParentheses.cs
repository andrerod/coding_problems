using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class ValidParentheses
    {
        public int LongestValidParentheses(string s)
        {
            int longest = 0;
            var current = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else if (s[i] == ')')
                {
                    stack.Pop();
                    if (stack.Count > 0)
                    {
                        current = i - stack.Peek();
                        if (current > longest)
                            longest = current;
                    }
                    else stack.Push(i);
                }
            }

            return longest;
        }
    }
}
