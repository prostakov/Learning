using System;
using System.Linq;
using System.Reflection;
using AnimalHouse.CodeFirst.Server.Swagger.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AnimalHouse.CodeFirst.Server.Swagger.SchemaFilters
{
    public class OpenApiFormatFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null || context.Type == null)
                return;

            var properties = context.Type.GetProperties().Where(t => t.GetCustomAttribute<OpenApiFormatAttribute>() != null);
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttributes<OpenApiFormatAttribute>().FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(attribute?.Value))
                {
                    var schemaProperty = schema.Properties.First(x =>
                        string.Compare(x.Key, property.Name, StringComparison.OrdinalIgnoreCase) == 0);
                    schemaProperty.Value.Format = attribute.Value;
                }
            }
        }
    }
}