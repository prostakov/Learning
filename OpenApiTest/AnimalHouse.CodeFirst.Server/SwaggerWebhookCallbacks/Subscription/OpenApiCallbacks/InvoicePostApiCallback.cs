using AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks;
using Microsoft.OpenApi.Models;

namespace AnimalHouse.CodeFirst.Server.SwaggerWebhookCallbacks.Subscription.OpenApiCallbacks
{
    public class InvoicePostApiCallback
    {
        public const string Name = "invoicePost";
        public static OpenApiCallback Callback => WebhookCallback.CreateCallback(Name, "", "");
    }
}