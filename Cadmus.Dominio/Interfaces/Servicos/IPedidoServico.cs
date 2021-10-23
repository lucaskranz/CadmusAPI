using Cadmus.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmus.Dominio.Interfaces.Servicos
{
    public interface IPedidoServico
    {
        List<Pedido> ObterListaPedidos();
        Pedido ObterPedidoPorId(long id);
        ResponseApi Cadastrar(PedidoViewModel pedido);
        ResponseApi Editar(PedidoViewModel pedido);
        ResponseApi Excluir(long id);
    }
}
