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
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public ResponseApi Cadastrar(ClienteDTO model)
        {
            try
            {
                if (_clienteRepositorio.ExisteEmailCadastrado(model.Email))
                    return new ResponseApi(false, "E-mail já cadastrado.");

                Cliente cliente = new() { Nome = model.Nome, Email = model.Email, Aldeia = model.Aldeia };                
                _clienteRepositorio.Add(cliente);
                _clienteRepositorio.Commit();

                return new ResponseApi(true, "Cliente cadastrado com sucesso.");
            }
            catch(Exception e)
            {
                throw new ArgumentException($"Erro ao cadastrar - {e.Message}");
            }
        }

        public ResponseApi Editar(long id, ClienteDTO model)
        {
            try
            {
                Cliente cliente = _clienteRepositorio.GetById(id);

                if (cliente == null)
                    return new ResponseApi(false, "Cliente não encontrado.");

                cliente.Nome = model.Nome;
                cliente.Email = model.Email;
                cliente.Aldeia = model.Aldeia;

                _clienteRepositorio.Update(cliente);
                _clienteRepositorio.Commit();

                return new ResponseApi(true, "Cliente atualizado com sucesso.");
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
                Cliente cliente = _clienteRepositorio.GetById(id);

                if (cliente == null)
                    return new ResponseApi(false, "Cliente não encontrado.");

                _clienteRepositorio.Delete(cliente);
                _clienteRepositorio.Commit();

                return new ResponseApi(true, "Cliente excluído com sucesso.");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro ao excluir - {e.Message}");
            }
        }

        public Cliente ObterClientePorId(long id)
        {
            try
            {
                return _clienteRepositorio.GetById(id);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro ao buscar por Id {e.Message}");
            }
        }

        public List<Cliente> ObterListaClientes()
        {
            try
            {
                return _clienteRepositorio.ObterListaClientes().ToList();
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Erro ao buscar por Id {e.Message}");
            }
        }
    }
}
