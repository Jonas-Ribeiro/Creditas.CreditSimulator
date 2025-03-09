using Creditas.CreditSimulator.Domain.Contracts.Services;
using Creditas.CreditSimulator.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creditas.CreditSimulator.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ICalculatorCreditService, CalculatorCreditService>();
            services.AddScoped<IFeeService, FeeService>();
            return services;
        }
    }
}
