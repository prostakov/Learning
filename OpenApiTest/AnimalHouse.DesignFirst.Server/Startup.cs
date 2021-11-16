using System.Collections.Generic;
using AnimalHouse.Common;
using AnimalHouse.DesignFirst.Server.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AnimalHouse.DesignFirst.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterAuthentication();
            services.RegisterAuthorization();

            services.AddControllers();
                    // TODO
                    // .AddNewtonsoftJson(options =>
                    // {
                    //     options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    // });
            
            services.AddSwaggerGen();

            services.RegisterRepositories();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v23/swagger.json", "v23");
                    c.SwaggerEndpoint("/swagger/v23.4/swagger.json", "v23.4");
                });
            }
            
            app.UseStaticFiles();

            app.UseCors(x =>
            {
                x.AllowAnyMethod();
                x.AllowAnyHeader();
                x.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //.RequireAuthorization("ApiScope");
            });
        }
    }
}