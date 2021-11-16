using System;
using AnimalHouse.CodeFirst.Server.Swagger.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace AnimalHouse.CodeFirst.Server.Swagger
{
    public class ConfigureSwaggerUiOptions : IConfigureOptions<SwaggerUIOptions>
    {
        private readonly SwaggerConfig _options;
        private readonly IApiVersionDescriptionProvider _apiProvider;

        public ConfigureSwaggerUiOptions(IApiVersionDescriptionProvider apiProvider, IOptions<SwaggerConfig> options)
        {
            _apiProvider = apiProvider ?? throw new ArgumentNullException(nameof(apiProvider));
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        /// <inheritdoc />
        public void Configure(SwaggerUIOptions options)
        {
            options = options ?? throw new ArgumentNullException(nameof(options));
            options.RoutePrefix = _options.RoutePrefix;
            options.DocumentTitle = _options.Description;
            options.DocExpansion(DocExpansion.List);
            options.DefaultModelExpandDepth(0);
            
            foreach (var description in _apiProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/{_options.RoutePrefix}/{description.GroupName}/{_options.DocsFile}", description.GroupName);
            }
        }
    }
}
