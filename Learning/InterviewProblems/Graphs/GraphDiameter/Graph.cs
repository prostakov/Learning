using System.Collections.Generic;

namespace InterviewProblems.Graphs.GraphDiameter;

public class Node(int value)
{
    public int Value { get; set; } = value;
    public List<Node> Edges { get; set; } = new();
}

public class Graph
{
    public List<Node> Nodes { get; } = new();
    
    public Node AddNode(int value)
    {
        var node = new Node(value);
        Nodes.Add(node);
        return node;
    }

    public void AddEdge(Node node1, Node node2)
    {
        node1.Edges.Add(node2);
        node2.Edges.Add(node1);
    }

    public (Node, int) BFS(Node startNode)
    {
        var visited = new Dictionary<Node, bool>();
        var distances = new Dictionary<Node, int>();
        var queue = new Queue<Node>();

        foreach (var node in Nodes)
        {
            visited[node] = false;
            distances[node] = int.MaxValue;
        }

        visited[startNode] = true;
        distances[startNode] = 0;
        queue.Enqueue(startNode);

        Node furthestNode = startNode;
        int maxDistance = 0;

        while (queue.Count != 0)
        {
            var node = queue.Dequeue();

            foreach (var neighbor in node.Edges)
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    distances[neighbor] = distances[node] + 1;
                    queue.Enqueue(neighbor);

                    if (distances[neighbor] > maxDistance)
                    {
                        maxDistance = distances[neighbor];
                        furthestNode = neighbor;
                    }
                }
            }
        }

        return (furthestNode, maxDistance);
    }
}
