using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Shop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.HealthChecks
{
    public sealed class DatabaseHealthCheck
     : IHealthCheck
    {
        private readonly ShopDbContext _dbContext;

        public DatabaseHealthCheck(
            ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var canConnect =
                    await _dbContext.Database
                        .CanConnectAsync(cancellationToken);

                if (!canConnect)
                {
                    return HealthCheckResult.Unhealthy(
                        "Cannot connect to SQL Server.");
                }

                return HealthCheckResult.Healthy(
                      description: "SQL Server is available.",
                      data: new Dictionary<string, object>
                      {
                          ["Provider"] = _dbContext.Database.ProviderName!,
                          ["Database"] = _dbContext.Database.GetDbConnection().Database,
                          ["DataSource"] = _dbContext.Database.GetDbConnection().DataSource
                      });
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy(
                    "Database connection failed.",
                    ex);
            }
        }
    }
}
