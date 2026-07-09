using Microsoft.OpenApi;
using System.Reflection;

namespace ShopAPI.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(
            this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Enterprise Shop API",

                        Version = "v1",

                        Description =
                            "Production-ready ASP.NET Core Web API built with Clean Architecture, CQRS and DDD.",

                        Contact = new OpenApiContact
                        {
                            Name = "Mahdi Taremi",

                            Email = "taremiam@gmail.com"
                        },

                        License = new OpenApiLicense
                        {
                            Name = "MIT"
                        }
                    });

                //var xmlFile =
                //    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                //var xmlPath =
                //    Path.Combine(AppContext.BaseDirectory, xmlFile);

                //options.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(
            this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    "Enterprise Shop API v1");
            });

            return app;
        }
    }
}
