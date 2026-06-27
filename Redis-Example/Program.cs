using Redis_Example.Middleware;
using Serilog;

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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 1 Way : Whenever Don't Use Extension Method for RequestLoggingMiddleware
//app.UseMiddleware<RequestLoggingMiddleware>();
// 2 Way : Use Extension Method for RequestLoggingMiddleware
app.UseRequestLogging();

app.MapControllers();

app.Run();
