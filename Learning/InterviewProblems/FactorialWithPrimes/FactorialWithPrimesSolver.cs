using System;
using System.Collections.Generic;
using System.Numerics;

namespace InterviewProblems.FactorialWithPrimes;

public static class FactorialWithPrimesSolver
{
    public static int Solve(int a, int b)
    {
        var result = new List<int>();
        
        var factorialValue = 1;
        for (var i = 1; i <= a; i++)
        {
            factorialValue = i * factorialValue;
            var outputValue = factorialValue + b;

            if (IsPrime(outputValue))
            {
                result.Add(outputValue);
            }
        }

        return result.Count;
    }

    private static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    private static Random _random = new();

    private static bool IsProbablyPrime(BigInteger n, int iterations)
    {
        if (n == 2 || n == 3)
            return true;
        if (n < 2 || n % 2 == 0)
            return false;

        BigInteger d = n - 1;
        int s = 0;

        while (d % 2 == 0)
        {
            d /= 2;
            s++;
        }

        for (var i = 0; i < iterations; i++)
        {
            BigInteger a = _random.Next(2, BigInteger.Compare(n - 1, int.MaxValue) < 0 ? (int)n - 1 : int.MaxValue);
            BigInteger x = BigInteger.ModPow(a, d, n);
            if (x == 1 || x == n - 1)
                continue;
            for (int r = 1; r < s; r++)
            {
                x = BigInteger.ModPow(x, 2, n);
                if (x == 1)
                    return false;
                if (x == n - 1)
                    break;
            }
            if (x != n - 1)
                return false;
        }

        return true;
    }
}