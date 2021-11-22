using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalHouse.CodeFirst.Server.SwaggerWebhookCallbacks.Subscription.Dto
{
    public class VendorCallback
    {
        public string Name { get; set; }
    
        public string Email { get; set; }
    
        public string Phone { get; set; }
    
        public string StreetAddress { get; set; }
    
        public string AddressCity { get; set; }
    
        public string AddressState { get; set; }
    
        public string AddressPostalCode { get; set; }
        
        /// <summary>
        /// Country code in alpha-2 format
        /// </summary>
        /// <example>US</example>
        public string CountryCode { get; set; }
    
        [Required]
        public string Currency { get; set; }
    
        public System.DateTimeOffset? ConfirmedAt { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}