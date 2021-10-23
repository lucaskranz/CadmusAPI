using Cadmus.Dominio.Interfaces.Servicos;
using Cadmus.Servicos.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Cadmus.Servicos.Extensions
{
    public static class DependenciesInjectorsServicos
    {
        public static IServiceCollection AddDependenciesInjectorsServicos(this IServiceCollection services)
        {
            services.AddScoped<IClienteServico, ClienteServico>();
            services.AddScoped<IProdutoServico, ProdutoServico>();
            services.AddScoped<IPedidoServico, PedidoServico>();

            return services;
        }
    }
}
