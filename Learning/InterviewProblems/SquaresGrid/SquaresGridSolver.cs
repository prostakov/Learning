using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewProblems.SquaresGrid;

public class SquaresGridSolver(ISquaresGridTraversalStrategy strategy)
{
    public int[] Run(int[,] source)
    {
        for (var i = 0; i < source.GetLength(0); i++)
        for (var j = 0; j < source.GetLength(1); j++)
            if (source[i, j] != 0 && source[i, j] != 1)
                throw new ArgumentException("Grid is not valid");

        return strategy.RunTraverse(source);
    }
}

public interface ISquaresGridTraversalStrategy
{
    int[] RunTraverse(int[,] source);
}

public class RecursiveSquaresGridTraversalStrategy : ISquaresGridTraversalStrategy
{
    public int[] RunTraverse(int[,] source)
    {
        var result = new List<int>();
        var visitedCache = new HashSet<(int, int)>();
        
        for (var i = 0; i < source.GetLength(0); i++)
        for (var j = 0; j < source.GetLength(1); j++)
        {
            var size = 0;
            Traverse(source, i, j, ref size, visitedCache);

            if (size > 0)
            {
                result.Add(size);  
            } 
        }
        
        return result.OrderDescending().ToArray();
    }
    
    private static void Traverse(int[,] source, int i, int j, ref int size, ISet<(int, int)> visitedCache)
    {
        if (i < 0 || j < 0 || i >= source.GetLength(0) || j >= source.GetLength(1) ||  
            source[i, j] == 0 || visitedCache.Contains((i, j)))
        {
            return;   
        }

        size++;
        visitedCache.Add((i, j));
        
        Traverse(source, i - 1, j, ref size, visitedCache);
        Traverse(source, i, j - 1, ref size, visitedCache);
        Traverse(source, i + 1, j, ref size, visitedCache);
        Traverse(source, i, j + 1, ref size, visitedCache);
    }
}

public class IterativeSquaresGridTraversalStrategy : ISquaresGridTraversalStrategy
{
    public int[] RunTraverse(int[,] source)
    {
        var result = new List<int>();
        var visitedCache = new HashSet<(int, int)>();
        
        for (var i = 0; i < source.GetLength(0); i++)
        for (var j = 0; j < source.GetLength(1); j++)
        {
            var size = GetSize(source, i, j, visitedCache);

            if (size > 0)
            {
                result.Add(size);
            } 
        }
        
        return result.OrderDescending().ToArray();
    }
    
    private static int GetSize(int[,] source, int i, int j, ISet<(int, int)> visitedCache)
    {
        var size = 0;
        
        var stack = new Stack<(int, int)>();
        stack.Push((i, j));

        while (stack.Any())
        {
            (i, j) = stack.Pop();
            
            if (i < 0 || j < 0 || i >= source.GetLength(0) || j >= source.GetLength(1) ||  
                source[i, j] == 0 || visitedCache.Contains((i, j)))
            {
                continue;
            }
            
            size++;
            visitedCache.Add((i, j));
            
            stack.Push((i - 1, j));
            stack.Push((i, j - 1));
            stack.Push((i + 1, j));
            stack.Push((i, j + 1));
        }
        
        return size;
    }
}