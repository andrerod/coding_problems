using Algorithms.Implementation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{

    /// <summary>
    /// Prefix tree
    /// 
    ///                         ""
    ///                       /  |  \
    ///                      t   A   i
    ///                     / \       \
    ///                    to te      in
    ///                      / | \
    ///                    tea ted ten
    /// </summary>
    public class Trie
    {

        public TrieNode Root = new TrieNode { Letter = '\0' };

        /// <summary>
        /// See if we can traverse the tree for each letter and end up in the terminal node
        /// 
        /// This means we have this word in the trie
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Contains(string word) {
            TrieNode node = this.Root;

            foreach(char letter in word) {
                if (!node.Children.ContainsKey(letter)) {
                    return false;
                }

                node = node.Children[letter];
            }

            return node.IsTerminal;
        }

        /// <summary>
        /// Find and return the positions if the node found is the terminal node
        /// 
        /// if any letter is not found, automatically create one
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public List<int> this[string word] {
            get {
                TrieNode node = this.Root;

                foreach (char letter in word)
                {
                    if (!node.Children.ContainsKey(letter))
                    {
                        node.Children.Add(letter, new TrieNode { Letter = letter });
                    }

                    node = node.Children[letter];
                }

                node.IsTerminal = true;

                return node.Positions;
            }
        }

        /// <summary>
        /// Return all indexes of the search word occurring in the text
        /// 
        /// We can parse the text and store all indexes in a dictionary...requires n space and o(1) search time
        /// 
        /// Instead of we use more space efficient trie
        /// 
        ///     author, authority, and authorize - Hashtable index uses 6+9+9=24 characters but trie uses only 6+3+2=11
        ///     
        /// </summary>
        /// <param name="text"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static int[] SearchWordPosition(string[] text, string search)
        {
            Trie trie = new Trie();

            for (int index = 0; index < text.Length; index++)
            {
                string word = text[index];
                trie[word].Add(index);
            }

            return trie[search].ToArray();
        }

        /// <summary>
        /// Find the longest word made up of other words
        /// 
        /// 'cat', 'cats', 'catsdogcats', 'catxdogcatsrat', 'dog', 'dogcatsdog', 'hippopotamuses', 'rat', 'ratcat', 'ratcatdog', 'ratcatdogcat'
        /// Then the longest compound word is ‘ratcatdogcat’ with 12 letters
        /// Note that the longest individual words are ‘catxdogcatsrat’ and ‘hippopotamuses’ with 14 letters, but they’re not fully constructed by other words
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string LongestCompoundWord(string[] text)
        {
            Trie trie = new Trie();

            //Add all words in the trie
            for (int index = 0; index < text.Length; index++)
            {
                string word = text[index];
                trie[word].Add(index);
            }

            //for each word, iterate through the trie and find prefixes made up of full word (termininal is true).
            //If prefix exists, then it's a possible candidate just search the trie for the remainder of the word
            string longestWord = string.Empty;

            foreach (string word in text)
            {
                List<string> segments = new List<string>();

                StringBuilder currentWord = new StringBuilder();
                TrieNode current = trie.Root;
                foreach (char letter in word)
                {
                    current = current.Children[letter];
                    currentWord.Append(letter);

                    //we have found an existing word
                    if (current.IsTerminal)
                    {
                        segments.Add(currentWord.ToString());
                        currentWord.Clear();
                    }
                }

                //more than 1 segment
                if (segments.Count > 1)
                {
                    //check if remainder is an existing word
                    if (trie.Contains(segments[segments.Count - 1]))
                    {
                        //valid word, check length
                        if (word.Length > longestWord.Length)
                        {
                            longestWord = word;
                        }
                    }
                }
            }

            return longestWord;
        }
    }
}
