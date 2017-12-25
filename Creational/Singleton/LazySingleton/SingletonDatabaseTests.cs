using System.Collections.Generic;
using System.Linq;
using Autofac;
using Moq;
using NUnit.Framework;

namespace LazySingleton
{
    /// <summary>
    /// IMPORTANT: be sure to turn off shadow copying for unit tests in R#!
    /// </summary>
    [TestFixture]
    public class SingletonDatabaseTests
    {
        [Test]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase.InstanceCount, Is.EqualTo(1));
        }

        [Test]
        public void SingletonRecordFinder_LiveDatabase_Test()
        {
            var recordFinder = new RecordFinder(SingletonDatabase.Instance);
            var names = new[] { "Seoul", "Mexico City" };
            int totalPopulation = recordFinder.GetTotalPopulation(names);
            Assert.That(totalPopulation, Is.EqualTo(9989795 + 8851080));
            Assert.That(SingletonDatabase.InstanceCount, Is.EqualTo(1));
        }

        [Test]
        public void SingletonRecordFinder_Test()
        {
            Dictionary<string, int> populations = new Dictionary<string, int>
            {
                {"Seoul", 9989795},
                {"Mexico City", 8851080},
            };
            
            var databaseMock = new Mock<IDatabase>();
            foreach (var capital in populations.Keys)
                databaseMock.Setup(db => db.GetPopulation(capital)).Returns(populations[capital]);
            
            var recordFinder = new RecordFinder(databaseMock.Object);
            var names = populations.Keys;
            int totalPopulation = recordFinder.GetTotalPopulation(names);

            Assert.That(totalPopulation, Is.EqualTo(populations.Values.Sum()));
        }

        [Test]
        public void DIPopulationTest()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<OrdinaryDatabase>()
                .As<IDatabase>()
                 .SingleInstance();
            cb.RegisterType<RecordFinder>();

            using (var c = cb.Build())
            {
                var recordFinder = c.Resolve<RecordFinder>();
                var names = new[] { "Seoul", "Mexico City" };

                int totalPopulation = recordFinder.GetTotalPopulation(names);
                Assert.That(totalPopulation, Is.EqualTo(9989795 + 8851080));
            }
        }
    }
}
