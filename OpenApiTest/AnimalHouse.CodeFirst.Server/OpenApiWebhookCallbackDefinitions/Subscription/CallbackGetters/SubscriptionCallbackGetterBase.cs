using System;
using Microsoft.OpenApi.Models;

namespace AnimalHouse.CodeFirst.Server.OpenApiWebhookCallbackDefinitions.Subscription.CallbackGetters
{
    public class SubscriptionCallbackGetterBase
    {
        protected const string BaseUrl = "{$request.body#/callbackUrl}/";
        protected string LineBreak => Environment.NewLine + Environment.NewLine;
        
        protected OpenApiParameter RequestIdParameter => new()
        {
            Name = "X-Request-Id",
            In = ParameterLocation.Header,
            Description = "Token to be able to correctly correlate associated requests",
            Required = false,
            Schema = new OpenApiSchema
            {
                Type = "string",
                Format = "uuid"
            }
        };
    }
}