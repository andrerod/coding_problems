using System.Collections.Generic;

namespace ClassLibrary2
{
    public class WordLadder
    {
        public static int FindLadders(string beginWord, string endWord, HashSet<string> wordList)
        {
            if (wordList == null || wordList.Count == 0)
            {
                return 0;
            }

            var queue = new Queue<string>();
            queue.Enqueue(beginWord);
            wordList.Remove(beginWord);
            var res = 1;
            char[] letters = new char['z' - 'a' + 1];
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = (char)((int)'a' + i);
            }

            while (queue.Count > 0)
            {
                int n = queue.Count;

                for (int i = 0; i < n; i++)
                {
                    var pop = queue.Dequeue();

                    foreach (var c in letters)
                    {
                        for (var j = 0; j < pop.Length; j++)
                        {
                            if (c != pop[j])
                            {
                                var tmp = pop.Substring(0, j) + c + pop.Substring(j + 1);
                                if (tmp.Equals(endWord))
                                {
                                    return res + 1;
                                }

                                if (wordList.Contains(tmp))
                                {
                                    queue.Enqueue(tmp);
                                    wordList.Remove(tmp);
                                }
                            }
                        }
                    }
                }

                res += 1;
            }

            return 0;
        }
    }
}
