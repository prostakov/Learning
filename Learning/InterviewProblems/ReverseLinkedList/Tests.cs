using System;
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

    [Test]
    public void METHOD()
    {
        unsafe
        {
            var s1 = "Some 1";
            var s2 = "Some 1";
            var result = object.ReferenceEquals(s1, s2);
            
            TypedReference tr = __makeref(s1);
            IntPtr ptr = **(IntPtr**) (&tr);
                
            TypedReference tr2 = __makeref(s2);
            IntPtr ptr2 = **(IntPtr**) (&tr2);
        }
    }
}