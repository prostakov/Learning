using System;
using System.Threading.Tasks;
using AnimalHouse.Common.Repositories;

namespace AnimalHouse.DesignFirst.Server.Controllers
{
    public partial class ApiController : ApiControllerBase
    {
        public ApiController(IAnimalRepository animalRepository, ISubscriptionRepository subscriptionRepository)
        {
            _animalRepository = animalRepository;
            _subscriptionRepository = subscriptionRepository;
        }

        public override async Task<HealthCheck> HealthCheck()
        {
            await Task.Delay(1);

            return new HealthCheck {Status = HealthCheckStatus.Pass};
        }
    }
}