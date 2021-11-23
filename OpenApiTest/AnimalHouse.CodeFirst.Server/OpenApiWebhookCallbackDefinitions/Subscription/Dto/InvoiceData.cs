using System;

namespace AnimalHouse.CodeFirst.Server.OpenApiWebhookCallbackDefinitions.Subscription.Dto
{
    public class InvoiceData
    {
        public string TransactionType { get; set; }
        public string RefNumber { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string PoNumber { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset GlDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public string PaymentInfo { get; set; }
    }
}