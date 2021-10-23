using Cadmus.Dominio;
using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.Interfaces.Repositorios;
using Cadmus.Dominio.Interfaces.Servicos;
using Cadmus.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmus.Servicos.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        public ResponseApi Cadastrar(ProdutoDTO model)
        {
            try
            {
                if (model.Valor <= 0)
                    return new ResponseApi(false, "Valor precisa ser maior do que 0.");

                Produto produto = new() { Descricao = model.Descricao, Foto = model.Foto, Valor = model.Valor };

                _produtoRepositorio.Add(produto);
                _produtoRepositorio.Commit();

                return new ResponseApi(true, "Produto cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro ao cadastrar - {e.Message}");
            }
        }

        public ResponseApi Editar(long id, ProdutoDTO model)
        {
            try
            {
                Produto produto = _produtoRepositorio.GetById(id);

                if (produto == null)
                    return new ResponseApi(false, "Produto não encontrado.");

                if (model.Valor <= 0)
                    return new ResponseApi(false, "Valor precisa ser maior do que 0.");

                produto.Descricao = model.Descricao;
                produto.Foto = model.Foto;
                produto.Valor = model.Valor;

                _produtoRepositorio.Update(produto);
                _produtoRepositorio.Commit();

                return new ResponseApi(true, "Produto atualizado com sucesso.");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro ao editar - {e.Message}");
            }
        }

        public ResponseApi Excluir(long id)
        {
            try
            {
                Produto produto = _produtoRepositorio.GetById(id);

                if (produto == null)
                    return new ResponseApi(false, "Produto não encontrado.");

                _produtoRepositorio.Delete(produto);
                _produtoRepositorio.Commit();

                return new ResponseApi(true, "Produto excluído com sucesso.");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro ao excluir - {e.Message}");
            }
        }

        public List<Produto> ObterListaProduto()
        {
            try
            {
                return _produtoRepositorio.ObterListaProdutos().ToList();
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro ao buscar por Id {e.Message}");
            }
        }

        public Produto ObterProdutoPorId(long id)
        {
            try
            {
                return _produtoRepositorio.GetById(id);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro ao buscar por Id {e.Message}");
            }
        }


    }
}
