using System;
using System.Collections.Generic;
using AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks;
using AnimalHouse.CodeFirst.Server.SwaggerWebhookCallbacks.Subscription.OpenApiCallbacks;
using Microsoft.OpenApi.Models;

namespace AnimalHouse.CodeFirst.Server.SwaggerWebhookCallbacks.Subscription
{
    public class SubscriptionWebhookCallback : WebhookCallback
    {
        public override KeyValuePair<string, OpenApiCallback>[] Callbacks => new KeyValuePair<string, OpenApiCallback>[]
        {
            new (VendorNewOpenApiCallback.Name, VendorNewOpenApiCallback.Callback),
            new (InvoicePostApiCallback.Name, InvoicePostApiCallback.Callback),
            new (InvoiceTransferOpenApiCallback.Name, InvoiceTransferOpenApiCallback.Callback),
            new (SyncRequestOpenApiCallback.Name, SyncRequestOpenApiCallback.Callback),
        };
        public override IEnumerable<Type> Types { get; }
    }
}