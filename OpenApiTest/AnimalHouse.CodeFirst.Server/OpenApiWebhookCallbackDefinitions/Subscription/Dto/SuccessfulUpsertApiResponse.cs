using System;

namespace AnimalHouse.CodeFirst.Server.OpenApiWebhookCallbackDefinitions.Subscription.Dto
{
    public class SuccessfulUpsertApiResponse
    {
        public Guid ExternalId { get; set; }
        public DateTimeOffset ExternalUpdatedAt { get; set; }
    }
}