using Autofac;
using static System.Console;

namespace LazySingleton
{
    public interface IDatabase
    {
        int GetPopulation(string capitalName);
    }

    class Program
    {
        static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<OrdinaryDatabase>()
                .As<IDatabase>()
                .SingleInstance();
            containerBuilder.RegisterType<RecordFinder>();

            return containerBuilder.Build();
        }

        static void Main(string[] args)
        {
            var database = SingletonDatabase.Instance;
            var city = "Kyiv";
            WriteLine($"City of {city} has population of {database.GetPopulation(city)}");

            using (var c = BuildContainer())
            {
                var recordFinder = c.Resolve<RecordFinder>();
                var cities = new[] {"Mexico City", "Kyiv"};
                WriteLine($"The cities of {string.Join(", ", cities)} have total population of {recordFinder.GetTotalPopulation(cities)}");
            }
        }
    }
}
