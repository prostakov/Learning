using AnimalHouse.CodeFirst.Server.Swagger.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace AnimalHouse.CodeFirst.Server.Swagger.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseSwaggerMiddleware(this IApplicationBuilder app, IConfiguration config)
        {
            var swaggerConfig = config.GetSection("SwaggerOptions").Get<SwaggerConfig>();
            app.UseSwagger(options =>
            {
                options.RouteTemplate = $"{swaggerConfig.RoutePrefix}/{{documentName}}/{swaggerConfig.DocsFile}";
            });
            app.UseSwaggerUI(options =>
            {
                options.InjectStylesheet($"/{swaggerConfig.RoutePrefix}/swagger-custom-ui-styles.css");
                options.InjectJavascript($"/{swaggerConfig.RoutePrefix}/swagger-custom-script.js");
            });
        }
    }
}