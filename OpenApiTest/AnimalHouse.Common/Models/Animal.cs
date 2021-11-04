using System;
using AnimalHouse.Common.Models.Animals;
using NJsonSchema.Converters;

namespace AnimalHouse.Common.Models
{
    [Newtonsoft.Json.JsonConverter(typeof(JsonInheritanceConverter), "discriminator")]
    [JsonInheritance(nameof(Bird), typeof(Bird))]
    [JsonInheritance(nameof(Fish), typeof(Fish))]
    [JsonInheritance(nameof(Mammal), typeof(Mammal))]
    [JsonInheritance(nameof(Reptile), typeof(Reptile))]
    public abstract class Animal
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public string[]? Tags { get; set; }
    }
}