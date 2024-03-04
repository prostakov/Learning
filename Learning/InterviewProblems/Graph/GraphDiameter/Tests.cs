using Common;
using FluentAssertions;
using NUnit.Framework;

namespace InterviewProblems.Graph.GraphDiameter;

/*
 * https://www.geeksforgeeks.org/longest-path-undirected-tree/amp/
 */
public class Tests : BaseTest
{
    [Test]
    public void Test()
    {
        var graph = new Graph();

        var node0 = graph.AddNode(0);
        var node1 = graph.AddNode(1);
        var node2 = graph.AddNode(2);
        var node3 = graph.AddNode(3);
        var node4 = graph.AddNode(4);
        var node5 = graph.AddNode(5);
        var node6 = graph.AddNode(6);
        var node7 = graph.AddNode(7);
        var node8 = graph.AddNode(8);
        var node9 = graph.AddNode(9);
        
        graph.AddEdge(node0, node1);
        graph.AddEdge(node1, node2); 
        graph.AddEdge(node2, node3); 
        graph.AddEdge(node2, node9); 
        graph.AddEdge(node2, node4); 
        graph.AddEdge(node4, node5); 
        graph.AddEdge(node1, node6); 
        graph.AddEdge(node6, node7); 
        graph.AddEdge(node6, node8); 
        
        var (furthestNode, _) = graph.BFS(node5);
        var (_, longestPath) = graph.BFS(furthestNode);

        longestPath.Should().Be(5);
    }
}