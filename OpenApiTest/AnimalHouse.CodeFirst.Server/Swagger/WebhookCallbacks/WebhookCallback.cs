using System;
using System.Collections.Generic;
using AnimalHouse.CodeFirst.Server.SwaggerWebhookCallbacks.Subscription.Dto;
using Microsoft.OpenApi.Expressions;
using Microsoft.OpenApi.Models;

namespace AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks
{
    public abstract class WebhookCallback
    {
        public abstract KeyValuePair<string, OpenApiCallback>[] Callbacks { get; }

        public abstract IEnumerable<Type> Types { get; }
        
        protected static readonly OpenApiResponses defaultCallbackResponses = new()
        {
            {"200", new OpenApiResponse {Description = "Your server implementation should return this HTTP status code if the data was received successfully"}},
            {"4xx", new OpenApiResponse {Description = "If your server returns an HTTP status code indicating it does not understand the format of the payload the delivery will be treated as a failure. No retries are attempted."}},
            {"5xx", new OpenApiResponse {Description = "If your server returns an HTTP status code indicating a server-side error the delivery will be treated as a failure. No retries are attempted."}},
        };
        
        public static OpenApiCallback CreateCallback(string name, string summary, string description)
        {
            var requestBody = new OpenApiRequestBody();
            requestBody.Content.Add(
                "application/json", new OpenApiMediaType()
                {
                    Schema = new OpenApiSchema()
                    {
                        Reference = new OpenApiReference()
                        {
                            Id = nameof(CreateOrUpdateVendorRequest),
                            Type = ReferenceType.Schema
                        }
                    }
                }
            );
            
            return new OpenApiCallback()
            {
                PathItems = new Dictionary<RuntimeExpression, OpenApiPathItem>()
                {
                    {
                        RuntimeExpression.Build("{$request.body#/callbackUrl}/" + name), 
                        new OpenApiPathItem
                        {
                            Operations = new Dictionary<OperationType, OpenApiOperation>
                            {
                                {OperationType.Post, new OpenApiOperation
                                {
                                    Summary = summary, 
                                    RequestBody = requestBody,
                                    Description = description,
                                    Deprecated = false,
                                    Responses = defaultCallbackResponses,
                                    Parameters = new List<OpenApiParameter>
                                    {
                                        new OpenApiParameter
                                        {
                                            Name = "X-Request-Id",
                                            In = ParameterLocation.Header,
                                            Description = "Token to be able to correctly correlate associated requests",
                                            Required = false,
                                            Schema = new OpenApiSchema
                                            {
                                                Type = "string",
                                                Format = "uuid"
                                            }
                                        }
                                    }
                                }}
                            }
                        }
                    }
                }
            };
        }
    }
}