using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            WriteLine("Initializing database...");
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

        // Case 1
        //private static SingletonDatabase instance => new SingletonDatabase();
        //public static SingletonDatabase Instance => instance;

        // Case 2
        //private static Lazy<SingletonDatabase> instance =>
        //    new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        //public static SingletonDatabase Instance => instance.Value;

        // Case 3
        private static SingletonDatabase _instanceObject;
        
        private static Lazy<SingletonDatabase> instance =>
            new Lazy<SingletonDatabase>(() => _instanceObject ?? (_instanceObject = new SingletonDatabase()));

        public static SingletonDatabase Instance => instance.Value;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var database = SingletonDatabase.Instance;
            var database1 = SingletonDatabase.Instance;
            var database2 = SingletonDatabase.Instance;

            var city = "Tokyo";
            WriteLine($"City of {city} has population of {database.GetPopulation(city)}");
        }
    }
}
