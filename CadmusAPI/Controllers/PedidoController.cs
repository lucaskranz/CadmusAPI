using Cadmus.Dominio;
using Cadmus.Dominio.DTO;
using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.Interfaces.Servicos;
using Cadmus.Dominio.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Cadmus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoServico _pedidoServico;

        public PedidoController(IPedidoServico pedidoServico)
        {
            _pedidoServico = pedidoServico;
        }

        [HttpGet, Route("listaPedidos")]
        public ActionResult ObterListaPedidos()
        {
            try
            {
                List<ListarProdutosPedidoViewModel> pedidos = _pedidoServico.ObterListaPedidos();

                return Ok(pedidos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message, sucesso = false });
            }
        }

        [HttpGet, Route("pedidoPorId/{id}")]
        public IActionResult ObterPedidoPorId(long id)
        {
            try
            {
                ListarProdutosPedidoViewModel pedido = _pedidoServico.ObterPedidoPorId(id);

                return Ok(pedido);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message, sucesso = false });
            }
        }

        [HttpPost, Route("cadastrar")]
        public IActionResult CadastrarProduto(PedidoDTO model)
        {
            try
            {
                ResponseApi retorno = _pedidoServico.Cadastrar(model);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message, sucesso = false });
            }
        }

        [HttpDelete, Route("excluir/{id}")]
        public IActionResult ExcluirPedido(long id)
        {
            try
            {
                ResponseApi retorno = _pedidoServico.Excluir(id);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message, sucesso = false });
            }
        }

    }
}
