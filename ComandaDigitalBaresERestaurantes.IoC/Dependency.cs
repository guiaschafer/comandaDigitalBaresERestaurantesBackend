using ComandaDigitalBaresERestaurantes.Aplicacao.Context;
using ComandaDigitalBaresERestaurantes.Interface;
using ComandaDigitalBaresERestaurantes.Interface.Authentication;
using ComandaDigitalBaresERestaurantes.Interface.Mappers;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
using ComandaDigitalBaresERestaurantes.Interface.Repository;
using ComandaDigitalBaresERestaurantes.Service;
using ComandaDigitalBaresERestaurantes.Service.Authentication;
using ComandaDigitalBaresERestaurantes.Service.Mappers;
using ComandaDigitalBaresERestaurantes.Service.Providers;
using ComandaDigitalBaresERestaurantes.Service.Repository;
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
            services.TryAddScoped<IUnitOfWork, UnitOfWork>();
            services.TryAddScoped<IJwtTokenService, JwtTokenService>();
            services.TryAddScoped<IPasswordService, PasswordService>();
            services.TryAddScoped<IHashService, HashService>();


            services.TryAddScoped<IUserProvider, UserProvider>();
            services.TryAddScoped<IProductProvider, ProductProvider>();
            services.TryAddScoped<ICategoryProvider, CategoryProvider>();            
            services.TryAddScoped<IOrderProvider, OrderProvider>();
            services.TryAddScoped<IAuthenticationProvider, AuthenticationProvider>();
            services.TryAddScoped<IAuthenticationService, AuthenticationService>();

            services.TryAddScoped<IUserMapper, UserMapper>();
            services.TryAddScoped<IProductMapper, ProductMapper>();
            services.TryAddScoped<DatabaseContext>();

        }
    }
}
