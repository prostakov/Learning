using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalHouse.Common
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