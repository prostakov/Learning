using System;
using System.Threading.Tasks;
using AnimalHouse.Common.Models;

namespace AnimalHouse.Common.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<Subscription[]> GetAll();

        Task<Subscription> CreateOrUpdate(Subscription subscription);

        Task Delete(Guid id);
    }
}