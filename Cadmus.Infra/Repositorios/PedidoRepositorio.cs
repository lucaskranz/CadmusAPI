using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.Interfaces.Repositorios;
using Cadmus.Infra.Contextos;
using Cadmus.Infra.Repositorios.Generico;
using System.Linq;

namespace Cadmus.Infra.Repositorios
{
    public class PedidoRepositorio : RepositorioGenerico<Pedido, long>, IPedidoRepositorio
    {
        public PedidoRepositorio(SqlContext context) : base(context) { }

        public IQueryable<Pedido> ObterListaPedidos()
        {
            return DbSet;
        }
    }
}
