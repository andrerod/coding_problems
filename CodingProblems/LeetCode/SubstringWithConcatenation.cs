using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class SubstringWithConcatenation
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            List<int> result = new List<int>();
            var wordCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!wordCount.ContainsKey(word))
                {
                    wordCount[word] = 1;
                }
                else wordCount[word]++;
            }

            var total = words.Length;
            var wordLength = words[0].Length;

            for (int i = 0; i <= s.Length - total * wordLength; i++)
            {
                var target = new Dictionary<string, int>(wordCount);

                for (int j = i; j <= s.Length - wordLength && target.Count > 0; j+=wordLength)
                {
                    var sub = s.Substring(j, wordLength);
                    if (!target.ContainsKey(sub)) break;
                    if (target[sub] > 1)
                    {
                        target[sub]--;
                    }
                    else
                    {
                        target.Remove(sub);
                    }
                }

                if (target.Count == 0)
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
