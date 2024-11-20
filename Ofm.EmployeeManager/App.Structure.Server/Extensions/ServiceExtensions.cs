// <copyright file="ServiceExtensions.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Server.Extensions
{
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Ofm.EmployeeManager.Dal.Context;
    using Ofm.EmployeeManager.Dal.Dal.UnitWorks.Abstraction;
    using Ofm.EmployeeManager.Dal.Dal.UnitWorks.Implementation;
    using Ofm.EmployeeManager.Entities.Business.Map;
    using Ofm.EmployeeManager.Module.Services.Facades.Implementation;
    using Ofm.EmployeeManager.Module.Services.Services;

    /// <summary>
    /// Provides extension methods for configuring application services and middlewares.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Adds application services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The service collection to which the application services are added.</param>
        /// <param name="connectionString">The connection string for the database.</param>
        public static void AddApplicationServices(this IServiceCollection services, string connectionString)
        {
            MapperConfiguration mapperConfig = new(mc => { mc.AddProfile(new MappingProfile()); });
            IMapper mapper = mapperConfig.CreateMapper();

            services.AddCorsConfiguration();
            services.AddSwaggerConfiguration();

            services.AddDbContext<MicrosoftSqlDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddSingleton(mapper);
            services.AddScoped<IUnitWork, EmployeeUnitWork>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<LogginService>();
            services.AddScoped<EmployeeFacade>();
            services.AddScoped<LogginEmployeeFacade>();

            services.AddControllers();
        }

        /// <summary>
        /// Configures application middleware in the specified <see cref="IApplicationBuilder"/>.
        /// </summary>
        /// <param name="app">The application builder to which the middleware is added.</param>
        public static void UseApplicationConfiguration(this IApplicationBuilder app)
        {
            app.ConfigureExceptionHandler();
            app.UseCorsConfiguration();
            app.UseSwaggerConfiguration();
            app.UseHttpsRedirection();
            app.UseAuthorization();
        }
    }
}
