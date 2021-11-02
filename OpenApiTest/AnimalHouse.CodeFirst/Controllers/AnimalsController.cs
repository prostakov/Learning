using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AnimalHouse.Common;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AnimalHouse.CodeFirst.Controllers
{
    [Route("/animals")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository _repository;

        public AnimalsController(IAnimalRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Finds Pets by tags
        /// </summary>
        /// <remarks>Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.</remarks>
        /// <param name="tags">Tags to filter by</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid tag value</response>
        /// <callbacks>
        /// <callback>vendorNew</callback>
        /// </callbacks>
        [Produces("application/json")]
        [HttpGet, Route("{id}")]
        [SwaggerOperation("FindAnimalsByTags")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Animal>), description: "successful operation")]
        public virtual async Task<IActionResult> GetAnimalsByTags([FromQuery] [Required] List<string> tags)
        {
            var animals = await _repository.GetAll();
            return new ObjectResult(animals);
        }
    }
}