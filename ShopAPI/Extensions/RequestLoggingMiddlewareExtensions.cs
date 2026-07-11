using ShopAPI.Middleware;

namespace ShopAPI.Extensions
{
    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder
         UseRequestLogging(
             this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
