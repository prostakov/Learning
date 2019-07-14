using System;
using System.Net.Sockets;

namespace DeepCopy
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }

    public class Person : IPrototype<Person>
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public Person(string name, Address address)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public Person DeepCopy()
        {
            return new Person(Name, Address.DeepCopy());
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }

    public class Address : IPrototype<Address>
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));
            HouseNumber = houseNumber;
        }

        public Address DeepCopy()
        {
            return new Address(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var john = new Person("John Smith", new Address("Petrykiv", 5));
            Console.WriteLine(john);

            var jane = john.DeepCopy();
            jane.Name = "Jane Smith";
            Console.WriteLine(jane);
        }
    }
}
