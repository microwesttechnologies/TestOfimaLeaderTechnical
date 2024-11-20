// <copyright file="CorsExtensions.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Server.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Provides extension methods for configuring CORS (Cross-Origin Resource Sharing).
    /// </summary>
    public static class CorsExtensions
    {
        /// <summary>
        /// Adds CORS configuration to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The service collection to which the CORS configuration is added.</param>
        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }

        /// <summary>
        /// Uses the configured CORS policy in the specified <see cref="IApplicationBuilder"/>.
        /// </summary>
        /// <param name="app">The application builder to which the CORS middleware is added.</param>
        public static void UseCorsConfiguration(this IApplicationBuilder app)
        {
            app.UseCors("AllowAllOrigins");
        }
    }
}
