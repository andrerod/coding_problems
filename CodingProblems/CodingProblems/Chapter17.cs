using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingProblems
{
    public class Chapter17
    {
        public void Problem2(int[] cards)
        {
            var random = new Random();
            for (int i = 0; i < cards.Length; i++)
            {
                var k = random.Next(i, cards.Length - 1);
                var tmp = cards[i];
                cards[i] = cards[k];
                cards[k] = tmp;
            }
        }

        public int[] Problem3(int[] options, int number)
        {
            int[] result = new int[number];
            if (number > options.Length)
            {
                return null;
            }

            var rand = new Random();
            for (int i = 0; i < number; i++)
            {
                var k = rand.Next(i, options.Length - 1);
                result[i] = options[k];
                var tmp = options[k];
                options[k] = options[i];
                options[i] = tmp;
            }

            return result;
        }

        private static int[] CalculateDeltas(char[] array)
        {
            int[] deltas = new int[array.Length];
            int delta = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 'a' && array[i] <= 'z')
                {
                    delta++;
                }
                else
                {
                    delta--;
                }

                deltas[i] = delta;
            }

            return deltas;
        }

        public static int[] FindLongestMatch(int[] deltas)
        {
            var map = new Dictionary<int, int>();
            map[0] = -1;
            int[] max = new int[2];
            for (int i = 0; i < deltas.Length; i++)
            {
                if (!map.ContainsKey(deltas[i]))
                {
                    map[deltas[i]] = i;
                }
                else
                {
                    int match = map[deltas[i]];
                    int distance = i - match;
                    int longest = max[1] - max[0];
                    if (distance > longest)
                    {
                        max[1] = i;
                        max[0] = match;
                    }
                }
            }

            return max;
        }

        public static char[] Extract(char[] input, int start, int end)
        {
            var arr = new char[end - start + 1];
            for (int i = start; i <= end; i++)
            {
                arr[i - start] = input[i];
            }

            return arr;
        }

        public static char[] Problem4(char[] input)
        {
            int[] deltas = CalculateDeltas(input);

            int[] match = FindLongestMatch(deltas);

            return Extract(input, match[0] + 1, match[1]);
        }

        public static bool CanBuildWord(string word, bool originalWord, Dictionary<string, bool> knowWords)
        {
            if (knowWords.ContainsKey(word) && !originalWord)
            {
                return knowWords[word];
            }

            for (int i = 0; i < word.Length; i++)
            {
                var left = word.Substring(0, i);
                var right = word.Substring(i + 1);
                if (knowWords.ContainsKey(left) && knowWords[left])
                {
                    CanBuildWord(right, false, knowWords);
                    return true;
                }
            }

            knowWords.Add(word, false);
            return false;
        }

        // longest word made of other words in the list
        // cat, banana, dog, nana, walk, walker, dogwalker
        public static string Problem15(string[] words)
        {
            var wordsDictionary = new Dictionary<string, bool>();
            foreach (var word in words)
            {
                wordsDictionary.Add(word, true);
            }

            words = words.OrderByDescending(word => word.Length).ToArray();
            foreach (var word in words)
            {
                if (CanBuildWord(word, true, wordsDictionary))
                {
                    return word;
                }
            }
            // sort words by length
            // store partial results

            return null;
        }

        public class MaxHeap<T> where T : IComparable
        {
            private List<T> elements { get; set; }

            public void Add(T newValue)
            {
                elements.Add(newValue);
                Heapify();
            }

            public void Delete(T item)
            {
                int i = elements.IndexOf(item);
                int last = elements.Count - 1;

                elements[i] = elements[last];
                elements.RemoveAt(last);
                Heapify();
            }

            public T PopMax()
            {
                if (elements.Count > 0)
                {
                    T item = elements[0];
                    Delete(item);
                    return item;
                }
                //relook at this - should we just throw exception?
                return default(T);
            }

            public void Heapify()
            {
                for (int i = elements.Count - 1; i > 0; i--)
                {
                    int parentPosition = (i + 1) / 2 - 1;
                    parentPosition = parentPosition >= 0 ? parentPosition : 0;

                    if (elements[i].CompareTo(elements[parentPosition]) > 1)
                    {
                        T tmp = elements[parentPosition];
                        elements[parentPosition] = elements[i];
                        elements[i] = tmp;
                    }
                }
            }
        }

        public static Trie CreateTreeFromStrings(string[] smalls, int maxLength)
        {
            Trie tree = new Trie();
            foreach (var s in smalls)
            {
                if (s.Length < maxLength)
                {
                    tree.InsertString(s);
                }
            }

            return tree;
        }

        public static string[] FindStringsAtLoc(TrieNode root, string big, int start)
        {
            var strings = new List<string>();
            for (var index = start; index < big.Length; index++)
            {
                if (!root.Children.ContainsKey(big[index])) break;
                root = root.Children[big[index]];
                if (root.IsWord)
                {
                    strings.Add(big.Substring(start, index + 1 - start));
                }
            }

            return strings.ToArray();
        }

        public static Dictionary<string, List<int>> SearchAll(string big, string[] smalls)
        {
            Dictionary<string, List<int>> lookup = new Dictionary<string, List<int>>();
            int maxLength = big.Length;

            TrieNode root = CreateTreeFromStrings(smalls, maxLength).Root;
            for (int i = 0; i < big.Length; i++)
            {
                var strings = FindStringsAtLoc(root, big, i);
                foreach (var str in strings)
                {
                    if (lookup.ContainsKey(str))
                    {
                        lookup[str].Add(i);
                    }
                    else
                    {
                        lookup[str] = new List<int>(new int[] { i });
                    }
                }
            }

            return lookup;
        }

        public int[,] ComputeSums(int[,] matrix)
        {
            var sums = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var left = i > 0 ? sums[i - 1, j] : 0;
                    var top = j > 0 ? sums[i, j - 1] : 0;
                    var overlap = i > 0 && j > 0 ? sums[i - 1, j - 1] : 0;
                    sums[i, j] = matrix[i, j] + left + top - overlap;
                }
            }

            return sums;
        }

        public int[] GetMaxMatrix(int[,] matrix)
        {
            int[] best = null;
            var sums = ComputeSums(matrix);

            for (int startX = 0; startX < matrix.GetLength(0); startX++)
            {
                for (int startY = 0; startY < matrix.GetLength(1); startY++)
                {
                    for (int endX = startX; endX < matrix.GetLength(0); endX++)
                    {
                        for (int endY = startY; endY < matrix.GetLength(1); endY++)
                        {

                        }
                    }
                }
            }

            return best;
        }
    }
}
