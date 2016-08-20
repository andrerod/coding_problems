using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation.Models
{
    
    public class TrieNode
    {

        public char Letter { get; set; }

        public Dictionary<char, TrieNode> Children { get; set; }

        public List<int> Positions { get; set; }

        public bool IsTerminal { get; set; }

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            Positions = new List<int>();
        }

    }
}
