﻿using System;
using System.Collections.Generic;
using static System.Console;

namespace AbstractFactory
{
    class Program
    {
        public interface IHotDrink
        {
            void Consume();
        }

        internal class Tea : IHotDrink
        {
            public void Consume()
            {
                WriteLine("This tea is nice, but I'd prefer it with milk.");
            }
        }

        internal class Coffee : IHotDrink
        {
            public void Consume()
            {
                WriteLine("This coffee is sensational!");
            }
        }

        public interface IHotDrinkFactory
        {
            IHotDrink Prepare(int amount);
        }

        internal class TeaFactory : IHotDrinkFactory
        {
            public IHotDrink Prepare(int amount)
            {
                WriteLine($"Put in a tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
                return new Tea();
            }
        }

        internal class CoffeeFactory : IHotDrinkFactory
        {
            public IHotDrink Prepare(int amount)
            {
                WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar.");
                return new Coffee();
            }
        }

        public class HotDrinkMachine
        {
            public enum AvailableDrink
            {
                Coffee, Tea
            }

            private Dictionary<AvailableDrink, IHotDrinkFactory> factories =
                new Dictionary<AvailableDrink, IHotDrinkFactory>();

            public HotDrinkMachine()
            {
                //foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
                //{
                //    var factoryType =
                //        Type.GetType("ConsoleApp2." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory");
                //    var factory = (IHotDrinkFactory) Activator.CreateInstance(factoryType);
                //    factories.Add(drink, factory);
                //}
                factories.Add(AvailableDrink.Coffee, new CoffeeFactory());
                factories.Add(AvailableDrink.Tea, new TeaFactory());
            }

            public IHotDrink MakeDrink(AvailableDrink drink, int amount)
            {
                return factories[drink].Prepare(amount);
            }
        }

        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
            drink.Consume();

            ReadKey();
        }
    }
}
