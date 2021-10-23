using Cadmus.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmus.Dominio.ViewModel
{
    public class ListarProdutosPedidoViewModel
    {
        public long IdPedido { get; set; }
        public long IdCliente { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public decimal? Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
