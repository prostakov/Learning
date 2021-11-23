using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AnimalHouse.CodeFirst.Server.Swagger.Attributes;

namespace AnimalHouse.CodeFirst.Server.OpenApiWebhookCallbackDefinitions.Subscription.Dto
{
    public class VendorCallback
    {
        [Required]
        public string Name { get; set; }
    
        [Required]
        public string Email { get; set; }
    
        [Required]
        public string Phone { get; set; }
    
        [Required]
        public string StreetAddress { get; set; }
    
        [Required]
        public string AddressCity { get; set; }
    
        [Required]
        public string AddressState { get; set; }
    
        [Required]
        public string AddressPostalCode { get; set; }
        
        /// <summary>
        /// Country code in alpha-2 format
        /// </summary>
        /// <example>US</example>
        [Required]
        public string CountryCode { get; set; }
    
        /// <summary>
        /// Currency code
        /// </summary>
        /// <example>USD</example>
        [Required]
        [OpenApiFormat("ISO-4217")]
        public string Currency { get; set; }
    
        public System.DateTimeOffset? ConfirmedAt { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}