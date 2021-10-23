using Cadmus.Dominio.Entidades.Base;

namespace Cadmus.Dominio.Entidades
{
    public class Produto: Entity<Produto, long>
    {
        public string  Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Foto { get; set; }
    }
}
