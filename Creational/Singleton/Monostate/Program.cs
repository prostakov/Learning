﻿using System;

namespace Monostate
{
    public class CEO
    {
        private static string _name;
        private static int _age;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ceo1 = new CEO();
            ceo1.Name = "Adam Smith";
            ceo1.Age = 55;

            var ceo2 = new CEO();
            Console.WriteLine(ceo2);
        }
    }
}
