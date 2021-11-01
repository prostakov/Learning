using System;

namespace AnimalHouse.Common
{
    public class Animal
    {
        public int Id { get; set; }

        public AnimalType Type { get; set; }

        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public string[]? Tags { get; set; }
    }

    public enum AnimalType
    {
        None = 0,
        Cat,
        Dog,
        Elephant
    }
}