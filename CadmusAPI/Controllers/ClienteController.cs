using Cadmus.Dominio;
using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.Interfaces.Servicos;
using Cadmus.Dominio.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadmus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServico _clienteServico;

        public ClienteController(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        [HttpGet, Route("listaClientes")]
        public ActionResult ObterListaClientes()
        {
            try
            {
                List<Cliente> clientes = _clienteServico.ObterListaClientes();
                return Ok(clientes);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message, sucesso = false });
            }
        }

        [HttpPost, Route("cadastrar")]
        public IActionResult CadastrarCliente(ClienteDTO model)
        {
            try
            {
                ResponseApi retorno = _clienteServico.Cadastrar(model);                
                return Ok(retorno);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message, sucesso = false});
            }
        }

        [HttpPut, Route("editar/{id}")]
        public IActionResult EditarCliente(long id, ClienteDTO model)
        {
            try
            {
                ResponseApi retorno = _clienteServico.Editar(id, model);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message, sucesso = false });
            }
        }

        [HttpDelete, Route("excluir/{id}")]
        public IActionResult ExcluirCliente(long id)
        {
            try
            {
                ResponseApi retorno = _clienteServico.Excluir(id);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message, sucesso = false });
            }
        }

    }
}
