using ComandaDigitalBaresERestaurantes.Aplicacao.Context;
using ComandaDigitalBaresERestaurantes.Aplicacao.UniOfWork;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.IoC
{
    public static class Dependency
    {
        public static void Register(IServiceCollection services)
        {
            services.TryAddScoped<IUnitOfWork, UnitOfWork<DatabaseContext>>();
        }
    }
}
