using System;
using AnimalHouse.CodeFirst.Server.Swagger.DocumentFilters;
using AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AnimalHouse.CodeFirst.Server.Swagger.Extensions
{
    public static class WebhookCallbackRegistrationExtensions
    {
        public static void RegisterCallbackDefinition<T>(this SwaggerGenOptions options) where T : WebhookCallbackDefinition
        {
            var webhookCallback = (WebhookCallbackDefinition) Activator.CreateInstance<T>();
            
            options.DocumentFilter<CustomModelDocumentFilter<T>>();

            foreach (var type in webhookCallback.Types)
            {
                options.DocumentFilterDescriptors.Add(new FilterDescriptor
                {
                    Type = typeof(CustomModelDocumentFilter<>).MakeGenericType(type),
                    Arguments = Array.Empty<object>()
                });   
            }
        }
    }
}