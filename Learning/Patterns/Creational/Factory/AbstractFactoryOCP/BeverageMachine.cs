using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryOCP
{
    public interface IBeverage
    {
        void Consume();
    }

    public interface IBeverageFactory
    {
        IBeverage Prepare(int amount);
    }

    public class BeverageMachine
    {
        private List<Tuple<string, IBeverageFactory>> factories = new List<Tuple<string, IBeverageFactory>>();

        public void RegisterFactoriesAutomatically()
        {
            foreach (var t in typeof(BeverageMachine).Assembly.GetTypes())
            {
                if (typeof(IBeverageFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(Tuple.Create(
                        t.Name.Replace("Factory", string.Empty),
                        (IBeverageFactory)Activator.CreateInstance(t)
                    ));
                }
            }
        }

        public void RegisterFactory<T>() where T: IBeverageFactory
        {
            var tuple = Tuple.Create(
                typeof(T).Name.Replace("Factory", string.Empty),
                (IBeverageFactory) Activator.CreateInstance(typeof(T)));

            factories.Add(tuple);
        }

        public IBeverage MakeBeverage()
        {
            Console.WriteLine("Available drink:");
            for (var index = 0; index < factories.Count; index++)
            {
                var tuple = factories[index];
                Console.WriteLine($"{index}: {tuple.Item1}");
            }

            while (true)
            {
                string s = Console.ReadLine();
                if (s != null && int.TryParse(s, out int i) && i >= 0 && i < factories.Count)
                {
                    Console.Write("Specify amount: ");
                    s = Console.ReadLine();
                    if (s != null && int.TryParse(s, out int amount) && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }
                Console.WriteLine("Incorrect input, try again!");
            }
        }
    }
}
