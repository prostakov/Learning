using System;
using System.Collections.Generic;
using System.Text;
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

        //[Test]
        //public void SingletonTotalPopulationTest()
        //{
        //    // testing on a live database
        //    var rf = new SingletonRecordFinder();
        //    var names = new[] { "Seoul", "Mexico City" };
        //    int tp = rf.TotalPopulation(names);
        //    Assert.That(tp, Is.EqualTo(17500000 + 17400000));
        //    Assert.That(SingletonDatabase.InstanceCount, Is.EqualTo(1));
        //}
    }
}
