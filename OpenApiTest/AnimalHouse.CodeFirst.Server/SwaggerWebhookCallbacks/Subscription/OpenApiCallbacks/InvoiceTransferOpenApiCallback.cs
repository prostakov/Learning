using AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks;
using Microsoft.OpenApi.Models;

namespace AnimalHouse.CodeFirst.Server.SwaggerWebhookCallbacks.Subscription.OpenApiCallbacks
{
    public class InvoiceTransferOpenApiCallback
    {
        public const string Name = "invoiceTransfer";
        public static OpenApiCallback Callback => WebhookCallback.CreateCallback(Name, "", "");
    }
}