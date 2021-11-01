using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryOCP.Drinks
{
    internal class Tea : IBeverage
    {
        public void Consume()
        {
            Console.WriteLine("This tea is nice, but I'd prefer it with milk.");
        }
    }

    internal class TeaFactory : IBeverageFactory
    {
        public IBeverage Prepare(int amount)
        {
            Console.WriteLine($"Put in a tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }
}
