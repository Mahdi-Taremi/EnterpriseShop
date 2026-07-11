using Serilog;

namespace ShopAPI.Extensions
{
    public static class SerilogExtensions
    {
        // Registration : Dependency Injection, Host, Configuration
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
                    .Enrich.WithThreadId();
                    //.WriteTo.Console()
                    //.WriteTo.File(
                    //    "Logs/log-.txt",
                    //    rollingInterval: RollingInterval.Day,
                    //    retainedFileCountLimit: 30);
            });

            return builder;
        }

        // Pipeline : After Build
        public static WebApplication UseSerilogRequestLoggingEx(
     this WebApplication app)
        {
            app.UseSerilogRequestLogging(options =>
            {
                options.MessageTemplate =
                    "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

                options.EnrichDiagnosticContext =
                    (diagnosticContext, httpContext) =>
                    {
                        diagnosticContext.Set(
                            "RequestHost",
                            httpContext.Request.Host.Value);

                        diagnosticContext.Set(
                            "RequestScheme",
                            httpContext.Request.Scheme);

                        diagnosticContext.Set(
                            "ClientIP",
                            httpContext.Connection.RemoteIpAddress?.ToString());

                        diagnosticContext.Set(
                            "UserAgent",
                            httpContext.Request.Headers.UserAgent.ToString());

                        diagnosticContext.Set(
                            "TraceIdentifier",
                            httpContext.TraceIdentifier);
                    };
            });

            return app;
        }
    }
}
