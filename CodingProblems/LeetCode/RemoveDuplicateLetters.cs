using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class RemoveDuplicateLetters
    {
        public static string RemoveDupLetters(string s)
        {
            int[] count = new int[('z' - 'a')];
            int pos = 0; // position for the smallest s[i]
            for (int i = 0; i < s.Length; i++)
            {
                count[s[i] - 'a']++;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < s[pos])
                {
                    pos = i;
                }

                count[s[i] - 'a']--;

                if (count[s[i] - 'a'] == 0)
                    break;
            }

            return s.Length == 0 ? "" : s[pos] + RemoveDupLetters(s.Substring(pos + 1).Replace("" + s[pos], ""));
        }

        public static string RemoveDupLetters2(string s)
        {
            Stack<char> st = new Stack<char>();
            int[] count = new int['z' - 'a'];
            bool[] visited = new bool['z' - 'a'];

            for (int i = 0; i < s.Length; i++)
            {
                count[s[i] - 'a']++;
            }

            for (int i = 0; i < s.Length; i++)
            {
                count[s[i] - 'a']--;
                if (visited[s[i] - 'a']) continue;

                while (st.Count > 0 && st.Peek() - 'a' > s[i] - 'a' && count[st.Peek() - 'a'] > 0)
                {
                    visited[st.Peek() - 'a'] = false;
                    st.Pop();
                }

                visited[s[i] - 'a'] = true;
                st.Push(s[i]);
            }

            string res = "";
            while (st.Count > 0)
                res += st.Pop();

            return res;
        }
    }
}
