// <copyright file="Program.cs" company="Ofima S.A.S.">
// All rights reserved Ofima S.A.S.
// </copyright>

using Ofm.EmployeeManager.Server.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("MicrosoftSQL") ?? "InvalidConnection";

builder.Services.AddApplicationServices(connectionString);

WebApplication app = builder.Build();

app.UseApplicationConfiguration();
app.MapControllers();
app.Run();
