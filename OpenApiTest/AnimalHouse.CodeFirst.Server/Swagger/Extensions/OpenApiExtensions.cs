using System.Collections.Generic;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace AnimalHouse.CodeFirst.Server.Swagger.Extensions
{
    public static class OpenApiExtensions
    {
        public static OpenApiRequestBody GetRequestBody<T>()
        {
            return new OpenApiRequestBody
            {
                Required = true,
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    {"application/json", new OpenApiMediaType
                    {
                        Schema = new OpenApiSchema
                        {
                            Reference = new OpenApiReference
                            {
                                Id = typeof(T).Name,
                                Type = ReferenceType.Schema
                            }
                        }
                    }}      
                }
            };
        }
        
        public static OpenApiResponse GetResponseBody<T>(string description, 
                                                         string contentType = "application/json",
                                                         object example = null) => new()
        {
            Description = description,
            Content = new Dictionary<string, OpenApiMediaType>
            {
                {
                    contentType, 
                    new OpenApiMediaType 
                    {
                        Schema = new OpenApiSchema
                        {
                            Reference = new OpenApiReference
                            {
                                Id = typeof(T).Name,
                                Type = ReferenceType.Schema
                            }
                        },
                        Example = example switch
                        {
                            string s => new OpenApiString(s),
                            _ => null
                        }
                    }
                }
            }
        };
    }
}