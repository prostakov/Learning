using System;

namespace AnimalHouse.CodeFirst.Server.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class OpenApiWebhookCallbackSchemaAttribute : Attribute 
    {
        public Type SchemaType { get; }

        public OpenApiWebhookCallbackSchemaAttribute(Type schemaType)
        {
            SchemaType = schemaType;
        }
    }
}