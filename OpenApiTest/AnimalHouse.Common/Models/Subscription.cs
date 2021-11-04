using System;

namespace AnimalHouse.Common.Models
{
    public class Subscription
    {
        public Guid Id { get; set; }

        public string CallbackUrl { get; set; }

        public string CallbackToken { get; set; }
    }
}