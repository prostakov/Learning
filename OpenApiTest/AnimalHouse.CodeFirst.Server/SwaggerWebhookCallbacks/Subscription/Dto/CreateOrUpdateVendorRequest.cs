using System.Collections.Generic;

namespace AnimalHouse.CodeFirst.Server.SwaggerWebhookCallbacks.Subscription.Dto
{
    public class CreateOrUpdateVendorRequest
    {
        public string Name { get; set; }
    
        public string Email { get; set; }
    
        public string Phone { get; set; }
    
        public string StreetAddress { get; set; }
    
        public string AddressCity { get; set; }
    
        public string AddressState { get; set; }
    
        public string AddressPostalCode { get; set; }
    
        public string CountryCode { get; set; }
    
        public string Currency { get; set; }
    
        public System.DateTimeOffset? ConfirmedAt { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}