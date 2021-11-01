using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryOCP.Drinks
{
    internal class Coffee : IBeverage
    {
        public void Consume()
        {
            Console.WriteLine("This coffee is sensational!");
        }
    }

    internal class CoffeeFactory : IBeverageFactory
    {
        public IBeverage Prepare(int amount)
        {
            Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar.");
            return new Coffee();
        }
    }
}
