using Cadmus.Dominio.DTO;
using Cadmus.Dominio.Entidades;
using System.Collections.Generic;

namespace Cadmus.Dominio.Interfaces.Servicos
{
    public interface IPedidoServico
    {
        List<Pedido> ObterListaPedidos();
        Pedido ObterPedidoPorId(long id);
        ResponseApi Cadastrar(PedidoDTO model);
        ResponseApi Excluir(long id);
    }
}
