// <copyright file="SwaggerExtensions.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Server.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Provides extension methods for configuring Swagger in the application.
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Adds Swagger services to the specified service collection.
        /// </summary>
        /// <param name="services">The service collection to which Swagger services will be added.</param>
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        /// <summary>
        /// Configures Swagger middleware in the application pipeline.
        /// </summary>
        /// <param name="app">The application builder to configure Swagger middleware.</param>
        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            if (app.ApplicationServices.GetService<IHostEnvironment>().IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
