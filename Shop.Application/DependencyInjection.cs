using FluentValidation;
//using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Common.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            //services.AddAutoMapper(cfg =>
            //{
            //    cfg.AddMaps(Assembly.GetExecutingAssembly());
            //});

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(
                    Assembly.GetExecutingAssembly());
            });

            services.AddValidatorsFromAssembly(
            Assembly.GetExecutingAssembly());

            services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
