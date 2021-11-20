using System;

namespace AnimalHouse.CodeFirst.Server.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SwaggerWebhookCallbackSchemaAttribute : Attribute 
    {
        public Type SchemaType { get; }

        public SwaggerWebhookCallbackSchemaAttribute(Type schemaType)
        {
            SchemaType = schemaType;
        }
    }
}