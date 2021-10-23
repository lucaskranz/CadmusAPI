using Cadmus.Dominio.Entidades;
using System.Linq;

namespace Cadmus.Dominio.Interfaces.Repositorios
{
    public interface IClienteRepositorio: IRepositorioGenerico<Cliente, long>
    {
        bool ExisteEmailCadastrado(string email);
        IQueryable<Cliente> ObterListaClientes();
    }
}
