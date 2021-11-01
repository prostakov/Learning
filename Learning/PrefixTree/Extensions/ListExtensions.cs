using System.Collections.Generic;
using System.Text;

namespace PrefixTree.Extensions
{
    public static class ListExtensions
    {
        public static string ConvertToString(this IList<char> value)
        {
            var sb = new StringBuilder(value.Count);
            foreach (var @char in value) 
                sb.Append(@char);
            return sb.ToString();
        }

        public static void RemoveLast(this IList<char> value) => value.RemoveAt(value.Count - 1);
    }
}