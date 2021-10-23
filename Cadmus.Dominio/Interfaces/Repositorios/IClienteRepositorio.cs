using Cadmus.Dominio.Entidades;

namespace Cadmus.Dominio.Interfaces.Repositorios
{
    public interface IClienteRepositorio: IRepositorioGenerico<Cliente, long>
    {
        bool ExisteEmailCadastrado(string email);
    }
}
