using Serilog;

namespace ShopAPI.Extensions
{
    public static class SerilogExtensions
    {
        public static WebApplicationBuilder AddSerilogLogging(
            this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, services, configuration) =>
            {
                configuration
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(services)
                    .Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .Enrich.WithThreadId()
                    //.WriteTo.Console()
                    .WriteTo.File(
                        "Logs/log-.txt",
                        rollingInterval: RollingInterval.Day,
                        retainedFileCountLimit: 30);
            });

            return builder;
        }
    }
}
