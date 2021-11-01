using System.Collections.Generic;
using System.Linq;
using PrefixTree.Extensions;

namespace PrefixTree
{
    public class Trie
    {
        private readonly TrieNode _root = new();

        public Trie(params string[] words)
        {
            Insert(words);
        }
        
        public void Insert(params string[] words)
        {
            foreach (var word in words) 
                Insert(word);
        }

        private void Insert(string word)
        {
            var current = _root;
            
            foreach (var @char in word)
            {
                if (!current.Children.ContainsKey(@char))
                    current.Children[@char] = new TrieNode();
                
                current = current.Children[@char];
            }
            
            current.SetWord();
        }

        public IEnumerable<string> Search(string prefix)
        {
            var result = new HashSet<string>();
            var current = _root;
            
            foreach (var @char in prefix)
            {
                if (!current.Children.ContainsKey(@char))
                    return new List<string>();
                
                current = current.Children[@char];
            }
            
            GetWordsFromNode(result, current, prefix.ToCharList());

            return result;
        }

        private static void GetWordsFromNode(HashSet<string> result, TrieNode current, IList<char> word)
        {
            if (current.IsWord)
                result.Add(word.ConvertToString());

            if (current.Children.Any())
            {
                word.Add(new char());
                foreach (var nodeKeyValue in current.Children)
                {
                    word.RemoveLast();
                    word.Add(nodeKeyValue.Key);
                    GetWordsFromNode(result, nodeKeyValue.Value, word);
                }
                word.RemoveLast();
            }
        }
    }
}