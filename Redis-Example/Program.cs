using Microsoft.OpenApi;
using Redis_Example.Middleware;
using Serilog;
using Shop.Infrastructure.Context;
using Shop.Persistence.Context;
using Shop.Persistence.Database;

//1. Add Serilog 
Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();


var builder = WebApplication.CreateBuilder(args);

//2. Add Serilog 
builder.Host.UseSerilog((context, services, configuration) => { configuration.ReadFrom.Configuration(context.Configuration).ReadFrom.Services(services).Enrich.FromLogContext(); });
//Serilog - HardCode
//builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();

// Add Redis
builder.Services
    .AddStackExchangeRedisCache(options =>
    {
        options.Configuration =
            builder.Configuration
                .GetConnectionString("Redis");

        options.InstanceName =
            "RedisDemo:";
    });
//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration =
//        "localhost:6379";
//});

// 1. Add Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // The UI title/version label; not the OpenAPI version
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddInfrastructure();

//builder.Services
//.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
// 2. Add Swagger 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
     {
         c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
     });
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 1 Way : Whenever Don't Use Extension Method for RequestLoggingMiddleware
//app.UseMiddleware<RequestLoggingMiddleware>();
// 2 Way : Use Extension Method for RequestLoggingMiddleware
app.UseRequestLogging();

app.MapControllers();

// Initialization 
using (var scope = app.Services.CreateScope())
{
    var initializer =
        scope.ServiceProvider
             .GetRequiredService<IDatabaseInitializer>();

    await initializer.InitializeAsync();
}

app.Run();
