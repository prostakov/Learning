using System;
using System.Collections.Generic;
using System.Linq;
using AnimalHouse.CodeFirst.Server.OpenApiWebhookCallbackDefinitions.Subscription.CallbackGetters;
using AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks;

namespace AnimalHouse.CodeFirst.Server.OpenApiWebhookCallbackDefinitions.Subscription
{
    public class SubscriptionWebhookCallbackDefinition : WebhookCallbackDefinition
    {
        private readonly VendorNewOpenApiCallbackGetter _vendorNewOpenApiCallbackGetter = new();
        private readonly InvoicePostApiCallbackGetter _invoicePostApiCallbackGetter = new();
        private readonly InvoiceTransferOpenApiCallbackGetter _invoiceTransferOpenApiCallbackGetter = new();
        private readonly SyncRequestOpenApiCallbackGetter _syncRequestOpenApiCallbackGetter = new();
        
        public override KeyValuePair<string, IOpenApiCallbackGetter>[] Callbacks => new KeyValuePair<string, IOpenApiCallbackGetter>[]
        {
            new ("New Vendor", _vendorNewOpenApiCallbackGetter),
            new ("Post Invoice", _invoicePostApiCallbackGetter),
            new ("Transfer Invoice", _invoiceTransferOpenApiCallbackGetter),
            new ("Sync Request", _syncRequestOpenApiCallbackGetter),
        };
        
        public override IEnumerable<Type> Types => _vendorNewOpenApiCallbackGetter.Types
            .Union(_invoicePostApiCallbackGetter.Types)
            .Union(_invoiceTransferOpenApiCallbackGetter.Types)
            .Union(_syncRequestOpenApiCallbackGetter.Types);
    }
}