using Cadmus.Dominio.Entidades;
using System.Linq;

namespace Cadmus.Dominio.Interfaces.Repositorios
{
    public interface IPedidoProdutoRepositorio : IRepositorioGenerico<PedidoProduto, long>
    {
        IQueryable<PedidoProduto> ListarProdutosPorPedido(long idPedido);
    }
}
