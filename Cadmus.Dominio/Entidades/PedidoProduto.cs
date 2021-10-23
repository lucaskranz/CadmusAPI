using Cadmus.Dominio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmus.Dominio.Entidades
{
    public class PedidoProduto : Entity<PedidoProduto, long>
    {
        public long IdPedido { get; set; }
        public long IdProduto { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
