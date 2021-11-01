using System.Collections.Generic;

namespace PrefixTree.Extensions
{
    public static class StringExtensions
    {
        public static IList<char> ToCharList(this string value)
        {
            var result = new List<char>();

            foreach (var @char in value) 
                result.Add(@char);

            return result;
        }
    }
}