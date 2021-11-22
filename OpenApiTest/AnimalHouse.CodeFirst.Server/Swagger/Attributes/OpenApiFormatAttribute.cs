using System;

namespace AnimalHouse.CodeFirst.Server.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OpenApiFormatAttribute : Attribute
    {
        public string Value { get; }
        
        public OpenApiFormatAttribute(string value)
        {
            Value = value;
        }
    }
}