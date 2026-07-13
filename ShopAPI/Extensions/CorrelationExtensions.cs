using ShopAPI.Middleware;

namespace ShopAPI.Extensions
{
    public static class CorrelationExtensions
    {
        public static IApplicationBuilder UseCorrelationId(
            this IApplicationBuilder app)
        {
            return app.UseMiddleware<CorrelationIdMiddleware>();
        }
    }
}
