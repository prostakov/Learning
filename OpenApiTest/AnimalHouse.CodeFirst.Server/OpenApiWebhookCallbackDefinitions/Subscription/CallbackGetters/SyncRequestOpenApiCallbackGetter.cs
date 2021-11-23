using System;
using System.Collections.Generic;
using AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks;
using Microsoft.OpenApi.Models;

namespace AnimalHouse.CodeFirst.Server.OpenApiWebhookCallbackDefinitions.Subscription.CallbackGetters
{
    public class SyncRequestOpenApiCallbackGetter : SubscriptionCallbackGetterBase, IOpenApiCallbackGetter
    {
        public const string Name = "syncRequest";
        public OpenApiCallback Callback => new OpenApiCallback();
        public HashSet<Type> Types => new HashSet<Type>();
    }
}