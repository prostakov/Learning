using System.Threading.Tasks;
using AnimalHouse.Common.Repositories;

namespace AnimalHouse.DesignFirst.Server.Controllers
{
    public partial class ApiControllerImplementation : IApiController
    {
        public ApiControllerImplementation(IAnimalRepository animalRepository, ISubscriptionRepository subscriptionRepository)
        {
            _animalRepository = animalRepository;
            _subscriptionRepository = subscriptionRepository;
        }
        
        public async Task<HealthCheck> HealthCheckAsync()
        {
            await Task.Delay(1);

            return new HealthCheck
            {
                Status = HealthCheckStatus.Pass
            };
        }
    }
}