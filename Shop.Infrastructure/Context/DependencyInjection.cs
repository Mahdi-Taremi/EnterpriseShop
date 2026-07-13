using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Common.Interfaces.Services;
using Shop.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Context
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
       this IServiceCollection services)
        {
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
