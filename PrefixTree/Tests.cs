using FluentAssertions;
using NUnit.Framework;

namespace PrefixTree
{
    public class Tests
    {
        [Test]
        public void Test()
        {
            var trie = new Trie("dog", "dark", "cat", "door", "dodge", "doge");

            var result = trie.Search("do");

            result.Should().BeEquivalentTo("dog", "door", "dodge", "doge");
        }
    }
}