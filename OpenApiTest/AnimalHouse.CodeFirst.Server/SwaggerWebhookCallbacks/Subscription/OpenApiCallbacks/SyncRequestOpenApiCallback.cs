using AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks;
using Microsoft.OpenApi.Models;

namespace AnimalHouse.CodeFirst.Server.SwaggerWebhookCallbacks.Subscription.OpenApiCallbacks
{
    public class SyncRequestOpenApiCallback
    {
        public const string Name = "syncRequest";
        public static OpenApiCallback Callback => WebhookCallback.CreateCallback(Name, "", "");
    }
}