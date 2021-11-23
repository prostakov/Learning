using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AnimalHouse.CodeFirst.Server.Swagger.Configuration;
using AnimalHouse.CodeFirst.Server.Swagger.Extensions;
using AnimalHouse.CodeFirst.Server.Swagger.OperationFilters;
using AnimalHouse.CodeFirst.Server.Swagger.SchemaFilters;
using AnimalHouse.CodeFirst.Server.SwaggerWebhookCallbacks.Subscription;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AnimalHouse.CodeFirst.Server.Swagger
{
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _apiProvider;
        private readonly SwaggerConfig _swaggerConfig;
        
        public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider apiProvider, IOptions<SwaggerConfig> swaggerConfig)
        {
            _apiProvider = apiProvider ?? throw new ArgumentNullException(nameof(apiProvider));
            _swaggerConfig = swaggerConfig.Value;
        }
        
        public void Configure(SwaggerGenOptions options)
        {
            options.UseOneOfForPolymorphism();
            
            options.SchemaFilter<OpenApiFormatFilter>();

            options.OperationFilter<SwaggerDefaultValues>();
            options.OperationFilter<WebhookCallbacksOperationFilter>();
            
            options.RegisterCallbackDefinition<SubscriptionWebhookCallbackDefinition>();

            // Add a swagger document for each discovered API version
            // Note: you might choose to skip or document deprecated API versions differently
            foreach (var description in _apiProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }

            // Auth scheme
            options.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
                    Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer", //The name of the previously defined security scheme.
                            Type = ReferenceType.SecurityScheme
                        }
                    }, new List<string>()
                }
            });

            options.IncludeXmlComments(GetXmlCommentsPath(), true);

            // Use this settings to generate schemas with full namespace name.
            // For example: #/components/schemas/Animal >>> #/components/schemas/AnimalHouse.Common.Models.Animal.
            // Note: if this is set - all the OpenApiReferences should also be set to full namespace name.
            // options.CustomSchemaIds(x => x.FullName);
        }

        private static string GetXmlCommentsPath()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            return xmlPath;
        }
        
        private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = _swaggerConfig.Title,
                Version = description.ApiVersion.ToString(),
                Description = _swaggerConfig.Description,
                Contact = new OpenApiContact
                {
                    Name = _swaggerConfig.ContactName,
                    Email = _swaggerConfig.ContactEmail,
                    Url = new Uri(_swaggerConfig.ContactUrl)
                },
                License = new OpenApiLicense
                {
                    Name = _swaggerConfig.LicenseName,
                    Url = new Uri(_swaggerConfig.LicenseUrl)
                }
            };
  
            if (description.IsDeprecated) 
                info.Description += " ** THIS API VERSION HAS BEEN DEPRECATED!";

            return info;
        }
    }
}