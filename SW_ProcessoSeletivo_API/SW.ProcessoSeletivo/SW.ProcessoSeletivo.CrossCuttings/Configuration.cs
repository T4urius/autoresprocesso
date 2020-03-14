using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SW.ProcessoSeletivo.Domain.Contracts.Repositories;
using SW.ProcessoSeletivo.Repository.Data;
using SW.ProcessoSeletivo.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.ProcessoSeletivo.CrossCutting.IoC
{
    public static class Configuration
    {
        public static void AddRegisterIoCServices(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterData(services);
        }

        private static void RegisterData(IServiceCollection services)
        {
            services.AddScoped<SWAutoresDataContext>();
        }
    }
}
