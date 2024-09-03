using Microsoft.EntityFrameworkCore;
using Notification.Application;
using Notification.Infrastructure;
using Notification.API.Extensions;
using Notification.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string notificationConnectionString = builder.Configuration.GetConnectionString("ApplicationDbContext") ?? string.Empty;
string identityConnectionString = builder.Configuration.GetConnectionString("IdentityDbContext") ?? string.Empty;
if (string.IsNullOrEmpty(notificationConnectionString))
    Console.WriteLine("Connection string is null or empty!");

builder.Services
    .AddSwagger()
    .AddInfrastructure(notificationConnectionString)
    .AddIdentityInfrastructure(identityConnectionString)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
