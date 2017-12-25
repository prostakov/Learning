using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MoreLinq;

namespace LazySingleton
{
    public class SingletonDatabase : IDatabase
    {
        private readonly string _databaseFilePath = 
            Path.Combine(new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt");

        private readonly Dictionary<string, int> _population = new Dictionary<string, int>();

        private static int _instanceCount;
        public static int InstanceCount => _instanceCount;
        
        private SingletonDatabase()
        {
            _instanceCount++;
            
            _population = File.ReadAllLines(_databaseFilePath)
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1), NumberStyles.AllowThousands));
        }

        public int GetPopulation(string capitalName)
        {
            return _population[capitalName];
        }

        private static Lazy<SingletonDatabase> instance =
            new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static IDatabase Instance => instance.Value;
    }

    public class OrdinaryDatabase : IDatabase
    {
        private readonly string _databaseFilePath =
            Path.Combine(new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt");

        private readonly Dictionary<string, int> _population = new Dictionary<string, int>();

        public OrdinaryDatabase()
        {
            _population = File.ReadAllLines(_databaseFilePath)
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1), NumberStyles.AllowThousands));
        }

        public int GetPopulation(string capitalName)
        {
            return _population[capitalName];
        }
    }

    public class RecordFinder
    {
        private readonly IDatabase _database;

        public RecordFinder(IDatabase database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            return names.Sum(name => _database.GetPopulation(name));
        }
    }
}
