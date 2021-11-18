using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace AnimalHouse.CodeFirst.Server.Swagger.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSwaggerMiddleware(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerUIOptions>, ConfigureSwaggerUiOptions>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();
            
            services.AddSwaggerGen(options => options.EnableAnnotations(enableAnnotationsForInheritance: true, 
                                                                        enableAnnotationsForPolymorphism: true));
        }
        
        public static void ConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                // Controllers and endpoints without ApiVersion attribute will be automatically assigned this version
                options.DefaultApiVersion = new ApiVersion(23, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                options.ReportApiVersions = true;
                // Adds a convention to let Swagger understand the different API versions
                options.Conventions.Add(new VersionByNamespaceConvention());
            });

            services.AddVersionedApiExplorer(options =>
            {
                // Add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // Note: the specified format code will format the version as "'V'major[.minor][-status]"
                options.GroupNameFormat = "'V'VVV";
                // Note: this option is only necessary when versioning by url segment.
                // The SubstitutionFormat can also be used to control the format of the API version in route templates.
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}