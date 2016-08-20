using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{
    public class Anagram
    {
        private static readonly IDictionary<char, int> _hashMap = new Dictionary<char, int>
        {
            { 'a', 2 },
            { 'b', 3 },
            { 'c', 5 },
            { 'd', 7 },
            { 'e', 11 },
            { 'f', 13 },
            { 'g', 17 },
            { 'h', 19 },
            { 'i', 23},
            { 'j', 29 },
            { 'k', 31 },
            { 'l', 37 },
            { 'm', 41 },
            { 'n', 43 },
            { 'o', 47 },
            { 'p', 53 },
            { 'q', 59 },
            { 'r', 61 },
            { 's', 67 },
            { 't', 71 },
            { 'u', 73 },
            { 'v', 79 },
            { 'w', 83 },
            { 'x', 89 },
            { 'y', 97 },
            { 'z', 101 }
        };
        private readonly IEnumerable<string> _words;

        public Anagram(IEnumerable<string> words)
        {
            _words = words;
        }

        public IEnumerable<IEnumerable<string>> FindUsingSorting()
        {
            if (_words == null)
            {
                return new List<IEnumerable<string>>();
            }
            return _words.ToLookup(SortWord);
        }

        public IEnumerable<IEnumerable<string>> FindUsingPrimeNumberHashing()
        {
            if (_words == null)
            {
                return new List<IEnumerable<string>>();
            }
            return _words.ToLookup(HashWord);
        }

        private long HashWord(string word)
        {
            var result = 1L;
            foreach(var ch in word.ToLower())
            {
                result *= (_hashMap[ch]);
            }
            return result;
        }

        private static string SortWord(string word)
        {
            var chars = word.ToLower().ToCharArray();
            System.Array.Sort(chars);
            return new string(chars);
        }
    }
}
