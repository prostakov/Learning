using Common;
using NUnit.Framework;

namespace InterviewProblems.Trees.FindSimplePaths;

/*
 * Description:
 * Given a tree of N nodes. The N-1 edges are given in 2D integer array A.
 * Find the number of simple paths that do not share an edge or a vertex with the longest simple path in the tree.
 * Since the answer can be large, output it modulo 10^9+7.
 *
 * Note:
 *  - if there are multiple longest paths, choose the one with the further endpoint from 1 and the largest node in the tree.
 *  - secondly, in case of still multiple longest paths, again choose the second endpoint as the largest node value possible.
 *  - 2 <= N <= 10^5
 *
 * Input format:
 *  - the first and only argument is the 2D integer array A. It's of size (N-1)*2.
 *  - the two integers in each row indicate an edge between those two nodes.
 * Output format:
 *  - return single integer as per given problem.
 */
public class Tests : BaseTest
{
    [Test]
    public void Test1()
    {
        var a = new[,]
        {
            { 1, 2 }, 
            { 2, 3 }, 
            { 3, 4 }, 
            { 4, 5 },
        };
        var expectedOutput = 0;
        
        // TODO
    }
    
    [Test]
    public void Test2()
    {
        var a = new[,]
        {
            { 1, 2 }, 
            { 2, 3 }, 
            { 3, 4 }, 
            { 4, 5 },
            { 5, 6 },
            { 6, 7 },
            { 7, 8 },
            { 8, 9 },
            { 9, 10 },
            { 5, 11 },
            { 11, 12 },
            { 11, 13 },
            { 11, 14 },
        };
        var expectedOutput = 6;
        
        // TODO
    }
}