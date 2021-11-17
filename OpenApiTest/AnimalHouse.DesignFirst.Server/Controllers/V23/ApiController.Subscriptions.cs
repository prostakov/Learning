using System;
using System.Threading.Tasks;
using AnimalHouse.Common.Models;
using AnimalHouse.Common.Repositories;

namespace AnimalHouse.DesignFirst.Server.Controllers.V23
{
    public partial class ApiController
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public override async Task Subscribe(SubscriptionUpsert body)
        {
            var subscription = new Subscription
            {
                Id = Guid.NewGuid(), // TODO: UserId in here
                CallbackUrl = body.CallbackUrl.ToString(),
                CallbackToken = body.AccessToken
            };
            await _subscriptionRepository.CreateOrUpdate(subscription);
        }

        public override async Task<Response> Unsubscribe()
        {
            var id = Guid.NewGuid(); // TODO: UserId in here
            await _subscriptionRepository.Delete(id);
            return Controllers.V23.Response.Ok;
        }
    }
}