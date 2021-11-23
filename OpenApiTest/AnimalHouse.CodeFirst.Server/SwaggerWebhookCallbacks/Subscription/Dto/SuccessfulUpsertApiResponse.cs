using System;

namespace AnimalHouse.CodeFirst.Server.SwaggerWebhookCallbacks.Subscription.Dto
{
    public class SuccessfulUpsertApiResponse
    {
        public Guid ExternalId { get; set; }
        public DateTimeOffset ExternalUpdatedAt { get; set; }
    }
}