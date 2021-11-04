using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalHouse.Common.Models;

namespace AnimalHouse.Common.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly IDictionary<Guid, Subscription> _subscriptions;

        public SubscriptionRepository()
        {
            _subscriptions = new Dictionary<Guid, Subscription>();
        }
        
        public async Task<Subscription[]> GetAll()
        {
            return _subscriptions.Values.ToArray();
        }

        public async Task<Subscription> CreateOrUpdate(Subscription subscription)
        {
            _subscriptions[subscription.Id] = subscription;

            return subscription;
        }

        public async Task Delete(Guid id)
        {
            if (_subscriptions.ContainsKey(id))
                _subscriptions.Remove(id);
            else
                throw new ArgumentException($"Subscription with id {id} not found");
        }
    }
}