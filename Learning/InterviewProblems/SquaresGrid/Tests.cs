using Common;
using FluentAssertions;
using NUnit.Framework;

namespace InterviewProblems.SquaresGrid;

public class Tests : BaseTest
{
    private readonly SquaresGridSolver _squaresGridSolver = new(new IterativeSquaresGridTraversalStrategy());
    
    [Test]
    public void Test()
    {
        int[,] source =
        {
            { 1, 0, 1 },
            { 1, 0, 1 },
            { 0, 0, 1 }
        };

        var result = _squaresGridSolver.Run(source);

        result[0].Should().Be(3);
    }
    
    [Test]
    public void TestLargeGrid()
    {
        var source = new int[40, 40];

        // Figure 1 (5x3 rectangle)
        for (int i = 0; i < 5; i++)
        for (int j = 0; j < 3; j++)
            source[i, j] = 1;

        // Figure 2 (4x4 rectangle)
        for (int i = 10; i < 14; i++)
        for (int j = 10; j < 14; j++)
            source[i, j] = 1;

        // Figure 3 (3x5 rectangle)
        for (int i = 20; i < 23; i++)
        for (int j = 20; j < 25; j++)
            source[i, j] = 1;

        // Figure 4 (2x6 rectangle)
        for (int i = 30; i < 32; i++)
        for (int j = 30; j < 36; j++)
            source[i, j] = 1;

        // Figure 5 (1x5 rectangle)
        for (int j = 35; j < 40; j++)
            source[39, j] = 1;

        var result = _squaresGridSolver.Run(source);

        result[0].Should().Be(16);
        result[1].Should().Be(15);
        result[2].Should().Be(15);
        result[3].Should().Be(12);
        result[4].Should().Be(5);
    }
}