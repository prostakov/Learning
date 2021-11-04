using System;
using AnimalHouse.Common.Animals;
using NJsonSchema.Converters;

namespace AnimalHouse.Common
{
    [Newtonsoft.Json.JsonConverter(typeof(JsonInheritanceConverter), "discriminator")]
    [JsonInheritanceAttribute(nameof(Bird), typeof(Bird))]
    [JsonInheritanceAttribute(nameof(Fish), typeof(Fish))]
    [JsonInheritanceAttribute(nameof(Mammal), typeof(Mammal))]
    [JsonInheritanceAttribute(nameof(Reptile), typeof(Reptile))]
    public abstract class Animal
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public string[]? Tags { get; set; }
    }
}