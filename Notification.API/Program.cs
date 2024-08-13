using Microsoft.EntityFrameworkCore;
using Notification.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");
if (string.IsNullOrEmpty(connectionString))
    Console.WriteLine("Connection string is null or empty!");

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddInfrastructure(connectionString)
    .AddApplicationServices();

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
