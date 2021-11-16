using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalHouse.Common.Repositories;
using AnimalHouse.DesignFirst.Server.Controllers.V23_4.Converters;

namespace AnimalHouse.DesignFirst.Server.Controllers.V23_4
{
    public partial class ApiController
    {
        private readonly IAnimalRepository _animalRepository;
        
        public override async Task<ICollection<Bird>> AnimalsAll()
        {
            var animals = await _animalRepository.GetAll();

            var dtos = animals.Select(AnimalsConverter.ToDto).ToList();

            return (ICollection<Bird>) dtos.Where(x => x is Bird).ToArray();
        }

        public override Task<Bird> AnimalsPOST(Bird body)
        {
            throw new NotImplementedException();
        }

        public override Task<Bird> AnimalsPUT(Bird body)
        {
            throw new NotImplementedException();
        }
    }
}