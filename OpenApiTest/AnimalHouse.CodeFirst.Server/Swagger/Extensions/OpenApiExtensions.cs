using System.Collections.Generic;
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
        
        public static OpenApiResponse GetResponseBody<T>(string description, string contentType = "application/json") => new()
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
                        }
                    }
                }
            }
        };
    }
}