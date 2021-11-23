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
    public class VendorNewOpenApiCallbackGetter : SubscriptionCallbackGetterBase, IOpenApiCallbackGetter
    {
        public OpenApiCallback Callback => new()
        {
            PathItems = new Dictionary<RuntimeExpression, OpenApiPathItem>()
            {
                {
                    RuntimeExpression.Build(BaseUrl + "vendorNew"),
                    new OpenApiPathItem
                    {
                        Operations = new Dictionary<OperationType, OpenApiOperation>
                        {
                            {
                                OperationType.Post, new OpenApiOperation
                                {
                                    Summary = "Callback initiated when new vendor is created from VIC.AI admin panel.",
                                    RequestBody = OpenApiExtensions.GetRequestBody<VendorCallback>(),
                                    Description = Description,
                                    Deprecated = false,
                                    Responses = new OpenApiResponses
                                    {
                                        {"201", OpenApiExtensions.GetResponseBody<SuccessfulUpsertApiResponse>(
                                            "Your server implementation should return this HTTP status code if the data was received successfully")},
                                        {"202", OpenApiExtensions.GetResponseBody<string>("Acknowledge receipt", contentType: "text/plain", example: "ok")},
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
            typeof(VendorCallback), 
            typeof(SuccessfulUpsertApiResponse),
            typeof(ErrorApiResponse)
        };

        private string Description => 
            "This request is sent when a user in Vic.ai adds a new vendor to the system." + LineBreak +
            "Request body contains the vendor object." + LineBreak + 
            "A 201 response indicates that the vendor object has been successfully persisted to the external system, " +
            "and it must contain the external system's vendor object id as the externalId parameter." + LineBreak + 
            "Any other response will be considered a failure, the vendor object externalId will not be specified, " +
            "and the error message you specify will be surfaced to the user." + LineBreak + 
            "A 400 response indicates a data validation error." + LineBreak + 
            "This callback will timeout after 5 seconds.";
    }
}