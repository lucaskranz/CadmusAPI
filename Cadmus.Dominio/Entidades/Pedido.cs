using Cadmus.Dominio.Entidades.Base;
using System;
using System.Collections.Generic;

namespace Cadmus.Dominio.Entidades
{
    public class Pedido : Entity<Pedido, long>
    {
        public DateTime Data{ get; set; }
        public decimal Valor { get; set; }
        public decimal? Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public long IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}

