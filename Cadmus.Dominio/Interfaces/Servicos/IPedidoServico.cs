using Cadmus.Dominio.DTO;
using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.ViewModel;
using System.Collections.Generic;

namespace Cadmus.Dominio.Interfaces.Servicos
{
    public interface IPedidoServico
    {
        List<ListarProdutosPedidoViewModel> ObterListaPedidos();
        ListarProdutosPedidoViewModel ObterPedidoPorId(long id);
        ResponseApi Cadastrar(PedidoDTO model);
        ResponseApi Excluir(long id);
    }
}
