using System;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks
{
    public interface IOpenApiCallbackGetter
    {
        OpenApiCallback Callback { get; }
        
        HashSet<Type> Types { get; } 
    }
}