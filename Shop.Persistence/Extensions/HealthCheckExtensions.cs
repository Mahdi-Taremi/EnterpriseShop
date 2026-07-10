using Microsoft.Extensions.DependencyInjection;
using Shop.Persistence.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Extensions
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddDatabaseHealthChecks(
            this IServiceCollection services)
        {
            services
                .AddHealthChecks()
                .AddCheck<DatabaseHealthCheck>(
                    name: "sql-server");

            return services;
        }
    }
}
