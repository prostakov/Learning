using System;
using System.Linq;
using System.Reflection;  
using AnimalHouse.CodeFirst.Server.Swagger.Attributes;
using AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AnimalHouse.CodeFirst.Server.Swagger.OperationFilters
{
    public class WebhookCallbacksOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var webhookAttribute = context.MethodInfo.GetCustomAttributes<OpenApiWebhookCallbackSchemaAttribute>().FirstOrDefault();
            if (webhookAttribute != null)
            {
                var webhookCallback = (WebhookCallbackDefinition) Activator.CreateInstance(webhookAttribute.SchemaType);
                
                foreach (var (name, callbackGetter) in webhookCallback!.Callbacks) 
                    operation.Callbacks.Add(name, callbackGetter.Callback);
            }
        }
    }
}