using Microsoft.EntityFrameworkCore;
using Notification.Application;
using Notification.Infrastructure;
using Notification.API.Extensions;
using Notification.Infrastructure.Identity;
using Serilog;
using Prometheus;
using Notification.API.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add serilog services to the container and read config from appsettings
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

string notificationConnectionString = builder.Configuration.GetConnectionString("ApplicationDbContext") ?? string.Empty;

builder.Services.AddControllers();
builder.Services.AddHealthChecks()
    .AddSqlServer(notificationConnectionString)
    .AddCheck<SampleHealthCheck>("Sample");

builder.Services.UseHttpClientMetrics();

string identityConnectionString = builder.Configuration.GetConnectionString("IdentityDbContext") ?? string.Empty;
if (string.IsNullOrEmpty(notificationConnectionString))
    Console.WriteLine("Connection string is null or empty!");

builder.Services
    .AddSwagger()
    .AddInfrastructure(notificationConnectionString)
    .AddIdentityInfrastructure(identityConnectionString)
    .AddApplication();

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapHealthChecks("/healthz");
app.UseMetricServer();
app.UseHttpMetrics();

app.Run();
