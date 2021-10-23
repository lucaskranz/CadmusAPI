using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.Interfaces.Repositorios;
using Cadmus.Infra.Contextos;
using Cadmus.Infra.Repositorios.Generico;
using System.Linq;

namespace Cadmus.Infra.Repositorios
{
    public class PedidoProdutoRepositorio : RepositorioGenerico<PedidoProduto, long>, IPedidoProdutoRepositorio
    {
        public PedidoProdutoRepositorio(SqlContext context) : base(context) { }

        public IQueryable<PedidoProduto> ListarProdutosPorPedido(long idPedido)
        {
            return DbSet.Where(p => p.IdPedido == idPedido);
        }
    }
}
