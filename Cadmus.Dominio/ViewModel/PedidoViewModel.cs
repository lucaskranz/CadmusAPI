using Cadmus.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Cadmus.Dominio.Interfaces.Servicos
{
    public class PedidoViewModel
    {
        public long Numero { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public decimal? Desconto { get; set; }
        public long IdCliente { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}