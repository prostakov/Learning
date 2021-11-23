using System;
using System.Collections.Generic;
using AnimalHouse.CodeFirst.Server.OpenApiWebhookCallbackDefinitions.Subscription.Dto;
using AnimalHouse.CodeFirst.Server.Responses;
using AnimalHouse.CodeFirst.Server.Swagger.Extensions;
using AnimalHouse.CodeFirst.Server.Swagger.WebhookCallbacks;
using Microsoft.OpenApi.Expressions;
using Microsoft.OpenApi.Models;

namespace AnimalHouse.CodeFirst.Server.OpenApiWebhookCallbackDefinitions.Subscription.CallbackGetters
{
    public class InvoicePostApiCallbackGetter : SubscriptionCallbackGetterBase, IOpenApiCallbackGetter
    {
        public OpenApiCallback Callback => new()
        {
            PathItems = new Dictionary<RuntimeExpression, OpenApiPathItem>()
            {
                {
                    RuntimeExpression.Build(BaseUrl + "invoicePost"),
                    new OpenApiPathItem
                    {
                        Operations = new Dictionary<OperationType, OpenApiOperation>
                        {
                            {
                                OperationType.Post, new OpenApiOperation
                                {
                                    Summary = "Callback initiated when new invoice is being posted from VIC.AI admin panel.",
                                    RequestBody = GetRequestBody(),
                                    Description = Description,
                                    Deprecated = false,
                                    Responses = new OpenApiResponses
                                    {
                                        {"201", OpenApiExtensions.GetResponseBody<SuccessfulUpsertApiResponse>(
                                            "Your server implementation should return this HTTP status code if the data was received successfully")},
                                        {"202", new OpenApiResponse {Description = "Deferred post, confirmation asynchronous"}},
                                        {"400", OpenApiExtensions.GetResponseBody<ErrorApiResponse>("Invalid invoice data")},
                                        {"default", OpenApiExtensions.GetResponseBody<ErrorApiResponse>("Unexpected error")},
                                    },
                                    Parameters = new List<OpenApiParameter> { RequestIdParameter }
                                }
                            }
                        }
                    }
                }
            }
        };
        
        public HashSet<Type> Types => new()
        {
            typeof(InvoiceData)
        };

        private static OpenApiRequestBody GetRequestBody()
        {
            return new OpenApiRequestBody
            {
                Required = true,
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    {"multipart/form-data", new OpenApiMediaType
                    {
                        Schema = new OpenApiSchema
                        {
                            Type = "object",
                            Properties = new Dictionary<string, OpenApiSchema>
                            {
                                {"invoiceData", new OpenApiSchema
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Id = nameof(InvoiceData),
                                        Type = ReferenceType.Schema
                                    }
                                }},
                                {"invoiceDocument", new OpenApiSchema
                                {
                                    Type = "string",
                                    Format = "binary",
                                }}
                            }
                        },
                        Encoding = new Dictionary<string, OpenApiEncoding>
                        {
                            {"invoiceData", new OpenApiEncoding{ ContentType = "application/json"}},
                            {"invoiceDocument", new OpenApiEncoding{ ContentType = "application/pdf"}},
                        }
                    }}      
                }
            };
        }
        
        private string Description =>
            "This request is sent when a user in Vic.ai posts an invoice object to the system." + LineBreak +
            "Request body contains the invoice object (invoiceData part) as JSON, and corresponding invoice documents " +
            
            "as a pdf file (invoicePayload part) as multipart form data. This will always be a pdf file." + LineBreak +
            
            "A 201 response indicates that the invoice object has been successfully persisted to the external system, " +
            "and it must contain the external system's invoice object id as the externalId parameter." + LineBreak +
            
            "A 202 response indicates that the receipt of the invoice object has been acknowledged; an asynchronous " +
            "update will occur via invoiceConfirm operationId; the supplied 'X-Request-Id' in the request header will " +
            "be provided as the X-Request-Id header for any associated asynchronous updates." + LineBreak +
            
            "Any other response will be considered a failure, the invoice object externalId will not be specified, " +
            "and the error message you specify will be surfaced to the user." + LineBreak +
            
            "A 400 response indicates a data validation error." + LineBreak +
            
            "This callback will timeout after 5 seconds; to prevent inconsistencies, if the request will take longer " +
            "than 5 seconds, it is appropriate to respond with a 202 response code.";
    }
}