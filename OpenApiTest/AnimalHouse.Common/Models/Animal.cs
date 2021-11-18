using System;
using AnimalHouse.Common.Models.Animals;
using NJsonSchema.Converters;
using Swashbuckle.AspNetCore.Annotations;

namespace AnimalHouse.Common.Models
{
    [Newtonsoft.Json.JsonConverter(typeof(JsonInheritanceConverter), "discriminator")]
    [SwaggerDiscriminator("discriminator")]
    
    [JsonInheritance(nameof(Bird), typeof(Bird))]
    [SwaggerSubType(typeof(Bird), DiscriminatorValue = nameof(Bird))]
    
    [JsonInheritance(nameof(Fish), typeof(Fish))]
    [SwaggerSubType(typeof(Fish), DiscriminatorValue = nameof(Fish))]
    
    [JsonInheritance(nameof(Mammal), typeof(Mammal))]
    [SwaggerSubType(typeof(Mammal), DiscriminatorValue = nameof(Mammal))]
    
    [JsonInheritance(nameof(Reptile), typeof(Reptile))]
    [SwaggerSubType(typeof(Reptile), DiscriminatorValue = nameof(Reptile))]
    
    public abstract class Animal
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public string[]? Tags { get; set; }
    }
}