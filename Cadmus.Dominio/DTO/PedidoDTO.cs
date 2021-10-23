using Cadmus.Dominio.Entidades;
using Cadmus.Dominio.ViewModel;
using System;
using System.Collections.Generic;

namespace Cadmus.Dominio.DTO
{
    public class PedidoDTO
    {
        public DateTime Data { get; set; }
        public decimal? Desconto { get; set; }
        public long IdCliente { get; set; }
        public ICollection<ProdutosNoPedidoViewModel> Produtos { get; set; }
    }
}