using Cadmus.Dominio.Interfaces.Repositorios;
using Cadmus.Infra.Contextos;
using Cadmus.Infra.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Cadmus.Infra.Extensions
{
    public static class DependenciesInjectorsInfra
    {
        public static IServiceCollection AddDependenciesInjectorsInfra(this IServiceCollection services)
        {
            services.AddDbContext<SqlContext>();

            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();

            return services;
        } 
    }
}
