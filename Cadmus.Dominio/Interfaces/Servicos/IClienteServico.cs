using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmus.Dominio.Interfaces.Servicos
{
    public interface IClienteServico
    {
        Cliente ObterClientePorId(long id);
        ResponseApi Cadastrar(Cliente cliente);
        ResponseApi Editar(long id, ClienteViewModel model);
        ResponseApi Excluir(long id);
    }
}
