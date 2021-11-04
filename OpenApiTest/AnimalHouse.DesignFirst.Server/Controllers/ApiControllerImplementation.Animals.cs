using System.Threading.Tasks;
using AnimalHouse.Common.Repositories;

namespace AnimalHouse.DesignFirst.Server.Controllers
{
    public partial class ApiControllerImplementation
    {
        private readonly IAnimalRepository _animalRepository;
        
        public async Task<SubscriptionUpsert> ListAccountsAsync(int? limit, string cursor, System.DateTimeOffset? since, UseSystem? useSystem, SortOrder? sortOrder)
        {
            await Task.Delay(1);

            return new SubscriptionUpsert();
        }
    }
}