using Creditas.CreditSimulator.Application.Services;
using Creditas.CreditSimulator.Domain.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creditas.CreditSimulator.Application.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISimulatorService, SimulatorService>();            
            return services;
        }
    }
}
