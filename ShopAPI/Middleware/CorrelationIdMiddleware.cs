using Serilog.Context;

namespace ShopAPI.Middleware
{
    public sealed class CorrelationIdMiddleware
    {
        private const string HeaderName = "X-Correlation-Id";

        private readonly RequestDelegate _next;

        public CorrelationIdMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(
                    HeaderName,
                    out var correlationId))
            {
                correlationId = Guid.NewGuid().ToString();
            }

            context.TraceIdentifier = correlationId!;

            context.Response.Headers[HeaderName] =
                correlationId!;

            using (LogContext.PushProperty(
           "CorrelationId",
           correlationId.ToString()))
            {
                await _next(context);
            }

            //await _next(context);
        }
    }
}
