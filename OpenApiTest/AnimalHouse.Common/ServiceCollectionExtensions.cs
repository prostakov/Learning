using System;
using System.Text;
using AnimalHouse.Common.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AnimalHouse.Common
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAnimalRepository, AnimalRepository>();
            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
        }
        
        public static void RegisterAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        RequireExpirationTime = false,
                        ValidIssuer = "Serhii Prostakov",
                        ValidAudience = "Serhii Prostakov",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("af5b8f5e-ffd3-4bc2-84df-e027a0432974")),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        public static void RegisterAuthorization(this IServiceCollection services)
        {
            // services.AddAuthorization(options =>
            // {
            //     options.AddPolicy("ApiScope", policy =>
            //     {
            //         policy.RequireAuthenticatedUser();
            //         policy.RequireClaim("scope", "pai-api");
            //     });
            // });
        }
    }
}