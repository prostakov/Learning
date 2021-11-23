using System;
using System.Collections.Generic;
using AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks;
using Microsoft.OpenApi.Models;

namespace AnimalHouse.CodeFirst.Server.OpenApiWebhookCallbackDefinitions.Subscription.CallbackGetters
{
    public class InvoicePostApiCallbackGetter : SubscriptionCallbackGetterBase, IOpenApiCallbackGetter
    {
        public const string Name = "invoicePost";
        public OpenApiCallback Callback => new OpenApiCallback();
        public HashSet<Type> Types => new HashSet<Type>();
        
        
        // {"4xx", OpenApiExtensions.GetResponseBody<SuccessfulUpsertApiResponse>(
        //     "If your server returns an HTTP status code indicating it does not understand the format of the payload the delivery will be treated as a failure. No retries are attempted.")},
        // {"5xx", OpenApiExtensions.GetResponseBody<SuccessfulUpsertApiResponse>(
        //     "If your server returns an HTTP status code indicating a server-side error the delivery will be treated as a failure. No retries are attempted.")},
    }
}