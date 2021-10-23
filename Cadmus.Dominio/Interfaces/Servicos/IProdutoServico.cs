using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.DTO;
using System.Collections.Generic;

namespace Cadmus.Dominio.Interfaces.Servicos
{
    public interface IProdutoServico
    {
        List<Produto> ObterListaProduto();
        Produto ObterProdutoPorId(long id);
        ResponseApi Cadastrar(ProdutoDTO model);
        ResponseApi Editar(long id, ProdutoDTO model);
        ResponseApi Excluir(long id);
    }
}
