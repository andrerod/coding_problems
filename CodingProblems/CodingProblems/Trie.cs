using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingProblems
{
    public class TrieNode
    {
        public char Value { get; set; }

        public bool IsWord { get; set; }

        public Dictionary<char, TrieNode> Children { get; set; }

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
        }
    }

    public class Trie
    {
        public Trie()
        {
            Root = new TrieNode();
        }

        public TrieNode Root { get; set; }

        public void InsertString(string str)
        {
            TrieNode currentNode = Root;
            for (int i = 0; i < str.Length; i++)
            {
                if (currentNode.Children.ContainsKey(str[i]))
                {
                    currentNode = currentNode.Children[str[i]];
                }
                else
                {
                    var newNode = new TrieNode { Value = str[i] };
                    currentNode.Children.Add(str[i], newNode);
                    currentNode = newNode;
                }

                if (i == str.Length -1)
                {
                    currentNode.IsWord = true;
                }
            }
        }
    }
}
