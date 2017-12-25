using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using MoreLinq;
using static System.Console;

namespace LazySingleton
{
    public class SingletonDatabase
    {
        private readonly Dictionary<string, int> _population = new Dictionary<string, int>();

        private SingletonDatabase()
        {
            _population = File.ReadAllLines("capitals.txt")
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(), 
                    list => int.Parse(list.ElementAt(1)));
        }

        public int GetPopulation(string capitalName)
        {
            return _population[capitalName];
        }

        private static Lazy<SingletonDatabase> instance => 
            new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static SingletonDatabase Instance => instance.Value;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var database = SingletonDatabase.Instance;
            
            var city = "Tokyo";
            WriteLine($"City of {city} has population of {database.GetPopulation(city)}");
        }
    }
}
