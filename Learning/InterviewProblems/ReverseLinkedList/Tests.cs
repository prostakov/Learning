using Common;
using FluentAssertions;
using NUnit.Framework;

namespace InterviewProblems.ReverseLinkedList;

public class Tests : BaseTest
{
    [Test]
    public void Test()
    {
        var list = new SinglyLinkedList("element1", "element2", "element3");

        list.ToString().Should().Be("element1,element2,element3");
            
        list.Reverse();
            
        list.ToString().Should().Be("element3,element2,element1");
    }
}