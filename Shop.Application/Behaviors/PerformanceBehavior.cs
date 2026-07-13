using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shop.Application.Common.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Behaviors
{
    public sealed class PerformanceBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;

        private readonly PerformanceSettings _settings;

        public PerformanceBehavior(
            ILogger<PerformanceBehavior<TRequest, TResponse>> logger,
            IOptions<PerformanceSettings> options)
        {
            _logger = logger;
            _settings = options.Value;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();

            var response = await next();

            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds > _settings.WarningThresholdMilliseconds)
            {
                _logger.LogWarning(
                    "**** Slow Request: {RequestName} executed in {ElapsedMilliseconds} ms. ****",
                    typeof(TRequest).Name,
                    stopwatch.ElapsedMilliseconds);
            }

            return response;
        }
    }
}
