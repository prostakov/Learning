using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalHouse.Common.Repositories;

namespace AnimalHouse.DesignFirst.Server.Controllers
{
    public partial class ApiController
    {
        private readonly IAnimalRepository _animalRepository;
        
        public override async Task<ICollection<Bird>> AnimalsAll()
        {
            throw new NotImplementedException();
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