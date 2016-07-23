using System;
using System.Collections.Generic;

namespace ClassLibrary2
{
    public class PalindromePairs
    {
        public class Trie
        {
            public int Pos { get; set; }

            public Dictionary<char, Trie> Children { get; set; }

            public List<int> Palindromes { get; set; }

            public Trie()
            {
                Pos = -1;
                Children = new Dictionary<char, Trie>();
                Palindromes = new List<int>();
            }
        }

        public static void Add(Trie root, string word, int position)
        {
            for (int i = word.Length - 1; i >= 0; i--)
            {
                char ch = word[i];
                if (IsPalindrome(word, 0, i))
                {
                    root.Palindromes.Add(position);
                }

                if (!root.Children.ContainsKey(ch))
                {
                    root.Children[ch] = new Trie();
                }

                root = root.Children[ch];
            }

            root.Pos = position;
            root.Palindromes.Add(position);
        }

        public static bool IsPalindrome(String str, int i, int j)
        {
            while (i < j)
            {
                if (str[i++] != str[j--])
                {
                    return false;
                }
            }

            return true;
        }

        public static void Search(Trie root, string[] words, int i, List<Tuple<int, int>> result)
        {
            int length = words[i].Length;
            for (int j = 0; j < length && root != null; j++)
            {
                if (root.Pos >= 0 && i != root.Pos && IsPalindrome(words[i], j, length - 1))
                {
                    result.Add(new Tuple<int, int>(i, root.Pos));
                }

                char ch = words[i][j];
                root = root.Children[ch];
            }

            if (root != null && root.Palindromes.Count > 0)
            {
                foreach (var j in root.Palindromes)
                {
                    if (j != i)
                    {
                        result.Add(new Tuple<int, int>(i, j));
                    }
                }
            }
        }

        public static List<Tuple<int, int>> Pairs(string[] words)
        {
            var answers = new List<Tuple<int, int>>();
            Trie root = new Trie();
            for (int i = 0; i < words.Length; i++)
            {
                Add(root, words[i], i);
            }

            for (int i = 0; i < words.Length; i++)
            {
                Search(root, words, i, answers);
            }

            return answers;
        }
    }
}
