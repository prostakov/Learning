using System;
using System.Collections.Generic;
using AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks;
using Microsoft.OpenApi.Models;

namespace AnimalHouse.CodeFirst.Server.OpenApiWebhookCallbackDefinitions.Subscription.CallbackGetters
{
    public class InvoiceTransferOpenApiCallbackGetter : SubscriptionCallbackGetterBase, IOpenApiCallbackGetter
    {
        public const string Name = "invoiceTransfer";
        public OpenApiCallback Callback => new OpenApiCallback();
        public HashSet<Type> Types => new HashSet<Type>();
    }
}