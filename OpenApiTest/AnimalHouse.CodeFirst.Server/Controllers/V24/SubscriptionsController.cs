using System;
using System.Threading.Tasks;
using AnimalHouse.CodeFirst.Server.Responses;
using AnimalHouse.CodeFirst.Server.Swagger.Attributes;
using AnimalHouse.CodeFirst.Server.SwaggerWebhookCallbacks.Subscription;
using AnimalHouse.Common.Models;
using AnimalHouse.Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AnimalHouse.CodeFirst.Server.Controllers.V24
{
    [ApiVersion("24.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionRepository _repository;

        public SubscriptionsController(ISubscriptionRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// Create or update subscription
        /// </summary>
        /// <remarks>Subscriptions can be created and updated</remarks>
        /// <param name="subscription">Subscription to create or update</param>
        /// <response code="204">Successful operation</response>
        /// <response code="400">Request error</response>
        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation("UpdateSubscription")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Subscription))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorApiResponse))]
        [OpenApiWebhookCallbackSchema(typeof(SubscriptionWebhookCallbackDefinition))]
        public async Task<IActionResult> CreateOrUpdate([FromBody] Subscription subscription)
        {
            await _repository.CreateOrUpdate(subscription);
            return new NoContentResult();
        }
        
        /// <summary>
        /// Delete subscription
        /// </summary>
        /// <remarks>Subscriptions can be deleted</remarks>
        /// <param name="id">Id of subscription to delete</param>
        /// <response code="204">Successful operation</response>
        /// <response code="400">Request error</response>
        /// <response code="404">Not found error</response>
        [HttpDelete, Route("{id}")]
        [SwaggerOperation("DeleteSubscription")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorApiResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _repository.Delete(id);
            return new NoContentResult();
        }
    }
}