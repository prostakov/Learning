using System;
using System.Collections.Generic;
using AbstractFactoryOCP.Drinks;
using static System.Console;

namespace AbstractFactoryOCP
{
    class Program
    {
        static void Main(string[] args)
        {
            var machine = new BeverageMachine();
            machine.RegisterFactory<TeaFactory>();
            machine.RegisterFactory<CoffeeFactory>();
            machine.RegisterFactory<JuiceFactory>();
            
            var drink = machine.MakeBeverage();
            drink.Consume();
        }
    }
}
