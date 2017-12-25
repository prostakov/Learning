using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using MoreLinq;

namespace LazySingleton
{
    public class SingletonDatabase : IDatabase
    {
        private readonly Dictionary<string, int> _population = new Dictionary<string, int>();

        private static int _instanceCount;
        public static int InstanceCount => _instanceCount;
        
        private SingletonDatabase()
        {
            _instanceCount++;
            _population = File.ReadAllLines(Path.Combine(
                    new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName,
                    "capitals.txt"))
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

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
                result += SingletonDatabase.Instance.GetPopulation(name);
            return result;
        }
    }
}
