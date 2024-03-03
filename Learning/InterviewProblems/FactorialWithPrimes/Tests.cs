using Common;
using FluentAssertions;
using NUnit.Framework;

namespace InterviewProblems.FactorialWithPrimes;

/*
 * You are given A boxes kept in a row (1-based indexing) and a number B.
 * The i-th box contains value which is i!+B.
 * How many boxes are there which contains prime number?
 */
public class Tests : BaseTest
{
    [TestCase(2, 3, 1)]
    [TestCase(3, 2, 1)]
    [TestCase(7, 2, 1)]
    public void Test(int a, int b, int expectedResult)
    {
        var actualResult = FactorialWithPrimesSolver.Solve(a, b);

        actualResult.Should().Be(expectedResult);
    }
}