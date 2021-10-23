using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.Interfaces.Repositorios;
using Cadmus.Infra.Contextos;
using Cadmus.Infra.Repositorios.Generico;
using System.Linq;

namespace Cadmus.Infra.Repositorios
{
    public class ProdutoRepositorio : RepositorioGenerico<Produto, long>, IProdutoRepositorio
    {
        public ProdutoRepositorio(SqlContext context) : base(context) { }

        public IQueryable<Produto> ObterListaProdutos()
        {
            return DbSet;
        }
    }
}
