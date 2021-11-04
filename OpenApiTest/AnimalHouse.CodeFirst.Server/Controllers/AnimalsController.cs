using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AnimalHouse.CodeFirst.Server.Responses;
using AnimalHouse.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation("GetAllAnimals")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Animal>), description: "successful operation")]
        public async Task<IActionResult> GetAll()
        {
            var animals = await _repository.GetAll();
            return new ObjectResult(animals);
        }

        /// <summary>
        /// Finds animals by tags
        /// </summary>
        /// <remarks>Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.</remarks>
        /// <param name="tags">Tags to filter by</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid tag value</response>
        [HttpGet, Route("tags")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation("FindAnimalsByTags")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Animal[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorApiResponse))]
        public async Task<IActionResult> GetAnimalsByTags([FromQuery] [Required] List<string> tags)
        {
            var animals = await _repository.GetByTags(tags);
            return new ObjectResult(animals);
        }
        
        /// <summary>
        /// Create animal
        /// </summary>
        /// <remarks>Animals can be created</remarks>
        /// <param name="animal">Animal to create</param>
        /// <response code="201">Successful operation</response>
        /// <response code="400">Request error</response>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation("CreateNewAnimal")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Animal))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorApiResponse))]
        public async Task<IActionResult> Create([FromBody] Animal animal)
        {
            var createdAnimal = await _repository.Create(animal);
            return new CreatedResult(createdAnimal.Id.ToString(), createdAnimal);
        }
        
        /// <summary>
        /// Update animal
        /// </summary>
        /// <remarks>Animals can be updated</remarks>
        /// <param name="animal">Animal to update</param>
        /// <response code="204">Successful operation</response>
        /// <response code="400">Request error</response>
        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation("CreateNewAnimal")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Animal))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorApiResponse))]
        public async Task<IActionResult> Update([FromBody] Animal animal)
        {
            var updatedAnimal = await _repository.Update(animal);
            return new CreatedResult(updatedAnimal.Id.ToString(), updatedAnimal);
        }
    }
}