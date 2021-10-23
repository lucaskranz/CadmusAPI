using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.Interfaces.Repositorios;
using Cadmus.Infra.Contextos;
using Cadmus.Infra.Repositorios.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmus.Infra.Repositorios
{
    public class ClienteRepositorio: RepositorioGenerico<Cliente, long>, IClienteRepositorio
    {
        public ClienteRepositorio(SqlContext context): base(context) { }

        public bool ExisteEmailCadastrado(string email)
        {
            return DbSet.Where(w => w.Email.Equals(email)).Any();
        }

        public IQueryable<Cliente> ObterListaClientes()
        {
            return DbSet;
        }
    }
}
