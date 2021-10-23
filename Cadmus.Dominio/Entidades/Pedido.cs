using Cadmus.Dominio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

