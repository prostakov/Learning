using System.Threading.Tasks;

namespace AnimalHouse.Common
{
    public interface IAnimalRepository
    {
        Task<Animal[]> GetAll();
        
        Task<Animal?> Get(int id);
        
        Task<Animal> Create(Animal animal);
        
        Task<Animal> Update(Animal animal);

        Task Delete(int id);
    }
}