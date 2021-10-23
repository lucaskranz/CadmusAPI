using Cadmus.Dominio.Entidades.Base;

namespace Cadmus.Dominio.Entidades
{
    public class Cliente : Entity<Cliente, long>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Aldeia { get; set; }
    }
}
