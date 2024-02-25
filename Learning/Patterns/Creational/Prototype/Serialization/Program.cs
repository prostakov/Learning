using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Xml.Serialization;

namespace Serialization
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var json = JsonSerializer.Serialize(self);
            return JsonSerializer.Deserialize<T>(json);
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, self);
                stream.Position = 0;
                return (T) serializer.Deserialize(stream);
            }
        }

        public static T DeepCopyJson<T>(this T self)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(Person));
                serializer.WriteObject(stream, self);
                stream.Position = 0;
                return (T)serializer.ReadObject(stream);
            }
        }

        // TODO: NewtonsoftJsonSerializaion implementation
    }
    
    //[Serializable]
    public class Person
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public Person() { }

        public Person(string name, Address address)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }

    //[Serializable]
    public class Address
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public Address() {}

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));
            HouseNumber = houseNumber;
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

            var jane = john.DeepCopyJson();
            jane.Name = "Jane Smith";
            jane.Address.StreetName = "Berdychiv";
            Console.WriteLine(jane);
        }
    }
}
