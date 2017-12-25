using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Autofac;
using NUnit.Framework;
using MoreLinq;

using static System.Console;

namespace LazySingleton
{
    public interface IDatabase
    {
        int GetPopulation(string capitalName);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var database = SingletonDatabase.Instance;

            var city = "Kyiv";
            WriteLine($"City of {city} has population of {database.GetPopulation(city)}");
        }
    }
}
