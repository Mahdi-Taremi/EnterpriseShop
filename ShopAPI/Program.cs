using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi;
using Serilog;
using Shop.Application;
using Shop.Application.Common.Settings;
using Shop.Infrastructure.Context;
using Shop.Persistence;
using Shop.Persistence.Context;
using Shop.Persistence.Database;
using ShopAPI.Extensions;
using ShopAPI.Middleware;
using System.Reflection;

//1. Add Serilog +
//Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();


var builder = WebApplication.CreateBuilder(args);

//2. Add Serilog +
builder.AddSerilogLogging();

builder.Services.AddControllers();

// Add Redis +
//builder.Services
//    .AddStackExchangeRedisCache(options =>
//    {
//        options.Configuration =
//            builder.Configuration
//                .GetConnectionString("Redis");

//        options.InstanceName =
//            "RedisDemo:";
//    });
//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration =
//        "localhost:6379";
//});

// 1. Add Swagger 
builder.Services.AddSwaggerDocumentation();

builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddInfrastructure();

builder.Services.AddApplication();

builder.Services.Configure<PerformanceSettings>(
    builder.Configuration.GetSection("PerformanceSettings"));

var app = builder.Build();

app.UseCorrelationId();

// Use Extension Method for RequestLoggingMiddleware
//app.UseRequestLogging();

app.UseSerilogRequestLoggingEx();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
// 2. Add Swagger 
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseHttpsRedirection();

app.UseAuthorization();




app.MapControllers();

// Initialization 
using (var scope = app.Services.CreateScope())
{
    var initializer =
        scope.ServiceProvider
             .GetRequiredService<IDatabaseInitializer>();
    await initializer.MigrateAsync();
    if (app.Environment.IsDevelopment())
    {
        await initializer.SeedAsync();
    }
}

app.MapHealthChecks("/health");

app.Run();
