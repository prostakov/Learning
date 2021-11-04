using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalHouse.Common.Models;

namespace AnimalHouse.Common.Repositories
{
    public interface IAnimalRepository
    {
        Task<Animal[]> GetAll();

        Task<Animal[]> GetByTags(List<string> tags);
        
        Task<Animal?> Get(Guid id);
        
        Task<Animal> Create(Animal animal);
        
        Task<Animal> Update(Animal animal);

        Task Delete(Guid id);
    }
}