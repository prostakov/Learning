using System;
using System.Threading.Tasks;
using AnimalHouse.Common.Repositories;

namespace AnimalHouse.DesignFirst.Server.Controllers
{
    public partial class ApiController
    {
        private readonly IAnimalRepository _animalRepository;

        public override async Task<SubscriptionUpsert> ListAccounts(int? limit, string cursor, DateTimeOffset? since, UseSystem? useSystem, SortOrder? sortOrder)
        {
            await Task.Delay(1);

            return new SubscriptionUpsert();
        }
    }
}