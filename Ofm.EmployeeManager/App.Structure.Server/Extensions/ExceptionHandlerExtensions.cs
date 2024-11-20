// <copyright file="ExceptionHandlerExtensions.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

namespace Ofm.EmployeeManager.Server.Extensions
{
    using System.Net;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using Ofm.EmployeeManager.Entities.Business.Entities.Common;

    /// <summary>
    /// Provides extension methods for configuring exception handling middleware.
    /// </summary>
    public static class ExceptionHandlerExtensions
    {
        /// <summary>
        /// Configures the exception handler middleware to handle exceptions globally.
        /// </summary>
        /// <param name="app">The application builder to which the exception handler is added.</param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        var errorResponse = new GenericError
                        {
                            Message = "Service not available",
                        };

                        //await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(contextFeature.Error));
                    }
                });
            });
        }
    }
}
