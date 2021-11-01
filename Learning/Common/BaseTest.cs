using System;
using NUnit.Framework;
using Serilog;

namespace Common
{
    public class BaseTest
    {
        protected ILogger Logger;
        protected static readonly Random TheGreatestRandom = new();
        
        [SetUp]
        public void SetUp()
        {
            Logger = LoggerExtensions.CreateLogger();
        }
    }
}