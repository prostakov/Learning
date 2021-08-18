using System.Collections.Generic;

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
            var current = _root;
            
            foreach (var @char in prefix)
            {
                if (!current.Children.ContainsKey(@char))
                    return new List<string>();
                
                current = current.Children[@char];
            }
            
            return GetWordsFromNode(current, prefix.ToCharArray());
        }

        private static List<string> GetWordsFromNode(TrieNode current, char[] word)
        {
            var result = new List<string>();
            
            if (current.IsWord)
                result.Add(new string(word));

            foreach (var nodeKeyValue in current.Children)
            {
                var nodeResult = GetWordsFromNode(nodeKeyValue.Value, word.Append(nodeKeyValue.Key));
                result.AddRange(nodeResult);
            }
            
            return result;
        }
    }
}