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
    public class SyncRequestOpenApiCallbackGetter : SubscriptionCallbackGetterBase, IOpenApiCallbackGetter
    {
        public OpenApiCallback Callback => new()
        {
            PathItems = new Dictionary<RuntimeExpression, OpenApiPathItem>()
            {
                {
                    RuntimeExpression.Build(BaseUrl + "syncRequest"),
                    new OpenApiPathItem
                    {
                        Operations = new Dictionary<OperationType, OpenApiOperation>
                        {
                            {
                                OperationType.Post, new OpenApiOperation
                                {
                                    Summary = "Callback initiated sync master data is triggered from VIC.AI admin panel.",
                                    RequestBody = OpenApiExtensions.GetRequestBody<RequestIdCallback>(),
                                    Description = Description,
                                    Deprecated = false,
                                    Responses = new OpenApiResponses
                                    {
                                        {"200", new OpenApiResponse {Description = "Request acknowleged"}},
                                        {"default", OpenApiExtensions.GetResponseBody<ErrorApiResponse>("Request unservicable")},
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
            typeof(RequestIdCallback),
            typeof(ErrorApiResponse)
        };

        private string Description =>
            "This request is sent when a user in Vic.ai triggers a sync of all masterdata." + LineBreak +

            "In response to this message, you’re expected to post masterdata (vendors, GL accounts, dimensions) " +
            "into Vic.ai using the respective routes. You may perform a partial update, determining which data " +
            "to update using queries." + LineBreak +

            "Once this process is completed, perform a syncUpdate patch, passing the syncId, which will allow Vic.ai " +
            "to mark the user's sync action as completed with the 'complete' operation. If you cannot complete this " +
            "process before the specified timeout, then perform a syncUpdate patch with the 'extend' operation, which " +
            "will extend the timeout for the update. If the timeout expires before a 'complete' action has been sent, " +
            "then the request will be marked as 'failed'." + LineBreak +

            "The body of the syncRequest contains the requestId; this is a token that should be returned with all " +
            "upsert actions associated with this syncRequest." + LineBreak +

            "A 200 response indicates that the request has been acknowledged and informs the user that the sync has " +
            "been successfully triggered.";
    }
}