using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalHouse.Common
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly IDictionary<int, Animal> _animals = new Dictionary<int, Animal>();
        
        public async Task<Animal[]> GetAll()
        {
            await Task.Delay(1);
            return _animals.Values.ToArray();
        }

        public async Task<Animal?> Get(int id)
        {
            await Task.Delay(1);
            return _animals.TryGetValue(id, out var result) ? result : null;
        }

        public async Task<Animal> Create(Animal animal)
        {
            await Task.Delay(1);

            if (_animals.ContainsKey(animal.Id))
                throw new ArgumentException($"Animal with id {animal.Id} already exists");
            
            _animals.Add(animal.Id, animal);

            return animal;
        }

        public async Task<Animal> Update(Animal animal)
        {
            await Task.Delay(1);

            if (!_animals.ContainsKey(animal.Id))
                throw new ArgumentException($"Animal with id {animal.Id} does not exists");

            _animals[animal.Id] = animal;

            return animal;
        }

        public async Task Delete(int id)
        {
            await Task.Delay(1);

            if (!_animals.ContainsKey(id))
                throw new ArgumentException($"Animal with id {id} does not exists");

            _animals.Remove(id);
        }
    }
}