using Cadmus.Dominio.DTO;
using Cadmus.Dominio.Entidades;
using System.Collections.Generic;

namespace Cadmus.Dominio.Interfaces.Servicos
{
    public interface IClienteServico
    {
        List<Cliente> ObterListaClientes();
        Cliente ObterClientePorId(long id);
        ResponseApi Cadastrar(ClienteDTO cliente);
        ResponseApi Editar(long id, ClienteDTO model);
        ResponseApi Excluir(long id);
    }
}
