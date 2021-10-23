using Cadmus.Dominio;
using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.Interfaces.Servicos;
using Cadmus.Dominio.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Cadmus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoController(IProdutoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        [HttpGet, Route("listaProdutos")]
        public ActionResult ObterListaClientes()
        {
            try
            {
                List<Produto> produtos = _produtoServico.ObterListaProduto();
                return Ok(produtos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message, sucesso = false });
            }
        }

        [HttpPost, Route("cadastrar")]
        public IActionResult CadastrarProduto(ProdutoDTO model)
        {
            try
            {
                ResponseApi retorno = _produtoServico.Cadastrar(model);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message, sucesso = false });
            }
        }

        [HttpPut, Route("editar/{id}")]
        public IActionResult EditarProduto(long id, ProdutoDTO model)
        {
            try
            {
                ResponseApi retorno = _produtoServico.Editar(id, model);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message, sucesso = false });
            }
        }

        [HttpDelete, Route("excluir/{id}")]
        public IActionResult ExcluirProduto(long id)
        {
            try
            {
                ResponseApi retorno = _produtoServico.Excluir(id);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message, sucesso = false });
            }
        }
    }
}
