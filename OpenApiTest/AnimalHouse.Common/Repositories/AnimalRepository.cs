using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalHouse.Common.Fixtures;
using AnimalHouse.Common.Models;

namespace AnimalHouse.Common.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly IDictionary<Guid, Animal> _animals;

        public AnimalRepository()
        {
            _animals = AnimalsFixture.List.ToDictionary(x => x.Id, x => x);
        }
        
        public async Task<Animal[]> GetAll()
        {
            return _animals.Values.ToArray();
        }

        public async Task<Animal[]> GetByTags(List<string> tags)
        {
            return _animals.Values.Where(x => x.Tags?.Any(tags.Contains) ?? false).ToArray();
        }

        public async Task<Animal?> Get(Guid id)
        {
            return _animals.TryGetValue(id, out var result) ? result : null;
        }

        public async Task<Animal> Create(Animal animal)
        {
            if (_animals.ContainsKey(animal.Id))
                throw new ArgumentException($"Animal with id {animal.Id} already exists");
            
            _animals.Add(animal.Id, animal);

            return animal;
        }

        public async Task<Animal> Update(Animal animal)
        {
            if (!_animals.ContainsKey(animal.Id))
                throw new ArgumentException($"Animal with id {animal.Id} does not exists");

            _animals[animal.Id] = animal;

            return animal;
        }

        public async Task Delete(Guid id)
        {
            if (!_animals.ContainsKey(id))
                throw new ArgumentException($"Animal with id {id} does not exists");

            _animals.Remove(id);
        }
    }
}