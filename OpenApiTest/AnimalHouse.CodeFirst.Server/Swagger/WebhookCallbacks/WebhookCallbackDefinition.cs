using System;
using System.Collections.Generic;

namespace AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks
{
    public abstract class WebhookCallbackDefinition
    {
        public abstract KeyValuePair<string, IOpenApiCallbackGetter>[] Callbacks { get; }

        public abstract IEnumerable<Type> Types { get; }
    }
}