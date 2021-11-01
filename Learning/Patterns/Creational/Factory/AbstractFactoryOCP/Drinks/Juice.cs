using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryOCP.Drinks
{
    internal class Juice : IBeverage
    {
        public void Consume()
        {
            Console.WriteLine("The juice is flowing...!");
        }
    }

    internal class JuiceFactory : IBeverageFactory
    {
        public IBeverage Prepare(int amount)
        {
            Console.WriteLine($"Pouring {amount} ml of juice...");
            return new Juice();
        }
    }
}
