using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.Interfaces.Repositorios;
using Cadmus.Infra.Contextos;
using Cadmus.Infra.Repositorios.Generico;

namespace Cadmus.Infra.Repositorios
{
    public class PedidoRepositorio : RepositorioGenerico<Pedido, long>, IPedidoRepositorio
    {
        public PedidoRepositorio(SqlContext context) : base(context) { } 

    }
}
