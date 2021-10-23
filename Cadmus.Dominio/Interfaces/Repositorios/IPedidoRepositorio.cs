using Cadmus.Dominio.Entidades;
using System.Linq;

namespace Cadmus.Dominio.Interfaces.Repositorios
{
    public interface IPedidoRepositorio: IRepositorioGenerico<Pedido, long>
    {
        IQueryable<Pedido> ObterListaPedidos();
    }
}
