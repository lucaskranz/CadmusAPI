using Cadmus.Dominio;
using Cadmus.Dominio.DTO;
using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.Interfaces.Repositorios;
using Cadmus.Dominio.Interfaces.Servicos;
using Cadmus.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadmus.Servicos.Servicos
{
    public class PedidoServico : IPedidoServico
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IPedidoProdutoRepositorio _pedidoProdutoRepositorio;

        public PedidoServico(IPedidoRepositorio pedidoRepositorio, 
                            IProdutoRepositorio produtoRepositorio, 
                            IPedidoProdutoRepositorio pedidoProdutoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _produtoRepositorio = produtoRepositorio;
            _pedidoProdutoRepositorio = pedidoProdutoRepositorio;
        }

        public ResponseApi Cadastrar(PedidoDTO model)
        {
            try
            {
                if(model.Produtos.Count == 0)
                    return new ResponseApi(false, "Nenhum produto vinculado ao pedido.");

                decimal valorTotal = 0;

                foreach (var item in model.Produtos)
                    valorTotal += _produtoRepositorio.GetById(item.IdProduto).Valor;

                Pedido pedido = new() { 
                  IdCliente = model.IdCliente,
                  Data = model.Data,
                  Desconto = model.Desconto,
                  Valor = valorTotal,
                  ValorTotal = valorTotal - (decimal)model.Desconto
                };

                _pedidoRepositorio.Add(pedido);
                _pedidoRepositorio.Commit();

                foreach (var item in model.Produtos)
                {
                    PedidoProduto pedidoProduto = new()
                    {
                        IdPedido = pedido.Id,
                        IdProduto = item.IdProduto
                    };

                    _pedidoProdutoRepositorio.Add(pedidoProduto);
                    _pedidoProdutoRepositorio.Commit();
                }                

                return new ResponseApi(true, $"Pedido cadastrado com sucesso. O total do seu pedido é de R$ {pedido.ValorTotal}");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro ao cadastrar - {e.Message}");
            }
        }
    
        public ResponseApi Excluir(long id)
        {
            try
            {
                Pedido pedido = _pedidoRepositorio.GetById(id);

                if (pedido == null)
                    return new ResponseApi(false, "Pedido não encontrado.");

                _pedidoRepositorio.Delete(pedido);
                _pedidoRepositorio.Commit();

                return new ResponseApi(true, "Pedido excluído com sucesso.");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro ao excluir - {e.Message}");
            }
        }

        public ListarProdutosPedidoViewModel ObterPedidoPorId(long id)
        {
            try
            {
                Pedido pedido = _pedidoRepositorio.GetById(id);
                var produtos = _pedidoProdutoRepositorio.ListarProdutosPorPedido(id).Select(a => a.Produto).ToList();

                ListarProdutosPedidoViewModel model = new()
                {
                    IdPedido = pedido.Id,
                    IdCliente = pedido.IdCliente,
                    Data = pedido.Data,
                    Desconto = pedido.Desconto,
                    Valor = pedido.Valor,
                    ValorTotal = pedido.ValorTotal,
                    Produtos = produtos
                };

                return model;
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro ao buscar por Id - {e.Message}");
            }
        }

        public List<ListarProdutosPedidoViewModel> ObterListaPedidos()
        {
            try
            {
                List<ListarProdutosPedidoViewModel> listarProdutos = new();

                List<Pedido> pedidos = _pedidoRepositorio.ObterListaPedidos().ToList();

                foreach(var item in pedidos)
                {
                    var produtos = _pedidoProdutoRepositorio.ListarProdutosPorPedido(item.Id).Select(a => a.Produto).ToList();
                    ListarProdutosPedidoViewModel model = new()
                    {
                        IdPedido = item.Id,
                        IdCliente = item.IdCliente,
                        Data = item.Data,
                        Valor = item.Valor,
                        Desconto = item.Desconto,
                        ValorTotal = item.ValorTotal,
                        Produtos = produtos
                    };

                    listarProdutos.Add(model);
                }

                return listarProdutos;
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro ao buscar lista de pedidos - {e.Message}");
            }
        }
    }
}
