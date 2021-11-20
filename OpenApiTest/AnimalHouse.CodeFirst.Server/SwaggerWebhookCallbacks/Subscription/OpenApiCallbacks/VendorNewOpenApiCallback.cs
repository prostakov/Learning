using AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks;
using Microsoft.OpenApi.Models;

namespace AnimalHouse.CodeFirst.Server.SwaggerWebhookCallbacks.Subscription.OpenApiCallbacks
{
    public static class VendorNewOpenApiCallback
    {
        public const string Name = "vendorNew";
        public static OpenApiCallback Callback => WebhookCallback.CreateCallback(Name, Summary, Description);

        private const string Summary = "Callback initiated when new vendor is created from VIC.AI admin panel.";
        
        private const string Description = @"This request is sent when a user in Vic.ai adds a new vendor to the system.

Request body contains the vendor object.

A 201 response indicates that the vendor object has been successfully persisted to the external system, and it must contain the external system's vendor object id as the externalId parameter.

Any other response will be considered a failure, the vendor object externalId will not be specified, and the error message you specify will be surfaced to the user.

A 400 response indicates a data validation error.

This callback will timeout after 5 seconds.";
    }
}