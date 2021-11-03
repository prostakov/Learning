using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AnimalHouse.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AnimalHouse.CodeFirst.Server.Controllers
{
    [Authorize]
    [Route("/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository _repository;

        public AnimalsController(IAnimalRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// Get all animals
        /// </summary>
        /// <remarks>Gets all animals that are currently in storage</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid tag value</response>
        [Produces("application/json")]
        [HttpGet]
        [SwaggerOperation("GetAllAnimals")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Animal>), description: "successful operation")]
        public virtual async Task<IActionResult> GetAll()
        {
            var animals = await _repository.GetAll();
            return new ObjectResult(animals);
        }

        /// <summary>
        /// Finds Pets by tags
        /// </summary>
        /// <remarks>Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.</remarks>
        /// <param name="tags">Tags to filter by</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid tag value</response>
        [Produces("application/json")]
        [HttpGet, Route("{id}")]
        [SwaggerOperation("FindAnimalsByTags")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Animal>), description: "successful operation")]
        public virtual async Task<IActionResult> GetAnimalsByTags([FromQuery] [Required] List<string> tags)
        {
            var animals = await _repository.GetAll();
            return new ObjectResult(animals);
        }
        
        /// <summary>
        /// Create animal
        /// </summary>
        /// <remarks>Animals can be created.</remarks>
        /// <param name="animal">Animal to create</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid tag value</response>
        [Produces("application/json")]
        [HttpPost]
        [SwaggerOperation("CreateNewAnimal")]
        [SwaggerResponse(statusCode: 201, type: typeof(Animal), description: "successful operation")]
        public virtual async Task<IActionResult> Create([FromBody] Animal animal)
        {
            var createdAnimal = await _repository.Create(animal);
            return new CreatedResult(createdAnimal.Id.ToString(), createdAnimal);
        }
    }
}