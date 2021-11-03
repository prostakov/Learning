using System;

namespace AnimalHouse.Common
{
    public abstract class Animal
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public string[]? Tags { get; set; }
    }
}