using System;
using System.Threading.Tasks;
using AnimalHouse.Common.Models;
using AnimalHouse.Common.Repositories;

namespace AnimalHouse.DesignFirst.Server.Controllers
{
    public partial class ApiControllerImplementation
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public async Task SubscribeAsync(SubscriptionUpsert body)
        {
            var subscription = new Subscription
            {
                Id = Guid.NewGuid(), // TODO: UserId in here
                CallbackUrl = body.CallbackUrl.ToString(),
                CallbackToken = body.AccessToken
            };
            await _subscriptionRepository.CreateOrUpdate(subscription);
        }

        public async Task<Response> UnsubscribeAsync()
        {
            var id = Guid.NewGuid(); // TODO: UserId in here
            await _subscriptionRepository.Delete(id);
            return Response.Ok;
        }
    }
}