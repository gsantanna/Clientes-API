using FluentValidation.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Interfaces;
using Project.Application.Services;
using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Domain.Interfaces.Services;
using Project.Domain.Services;
using Project.Infra.Context;
using Project.Infra.Repositories;

namespace Project.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static void Register(IServiceCollection services)
        {
            #region Application
            services.AddScoped<IClienteApplicationService, ClienteApplicationService>();
            services.AddScoped<IEnderecoApplicationService, EnderecoApplicationService>();
            #endregion

            #region Infra
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

        }
    }
}
