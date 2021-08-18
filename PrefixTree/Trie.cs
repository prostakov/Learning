using System;
using System.Collections.Generic;

namespace PrefixTree
{
    public class TrieNode
    {
        public char Symbol { get; set; }
        public List<TrieNode> Children { get; set; }
        public bool IsWord { get; set; }
    }

    public class Trie
    {
        public Trie(params string[] input)
        {
            Build(input);
        }
        
        public void Build(string[] input)
        {
        }

        public string[] Search(string prefix)
        {
            return Array.Empty<string>();
        }
    }
}