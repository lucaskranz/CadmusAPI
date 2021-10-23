using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.ViewModel;
using System.Collections.Generic;

namespace Cadmus.Dominio.Interfaces.Servicos
{
    public interface IProdutoServico
    {
        List<Produto> ObterListaProdutos();
        Produto ObterProdutoPorId(long id);
        ResponseApi Cadastrar(ProdutoViewModel produto);
        ResponseApi Editar(ProdutoViewModel produto);
        ResponseApi Excluir(long id);
    }
}
