using System.Collections.Generic;

namespace PrefixTree
{
    public class TrieNode
    {
        public bool IsWord { get; private set; }
        public Dictionary<char, TrieNode> Children { get; }

        public TrieNode()
        {
            IsWord = false;
            Children = new Dictionary<char, TrieNode>();
        }

        public void SetWord() => IsWord = true;
    }
}