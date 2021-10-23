using Cadmus.Dominio.Entidades;
using System.Linq;

namespace Cadmus.Dominio.Interfaces.Repositorios
{
    public interface IProdutoRepositorio: IRepositorioGenerico<Produto, long>
    {
        IQueryable<Produto> ObterListaProdutos();
    }
}
