using System;

namespace AnimalHouse.CodeFirst.Server.Extensions
{
    public static class HostingExtensions
    {
        public static bool IsDevelopmentEnvironment =>
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
    }
}