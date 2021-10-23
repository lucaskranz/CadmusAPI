using Cadmus.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadmus.Infra.Mapeamentos
{
    public class PedidoProdutoMapeamento : IEntityTypeConfiguration<PedidoProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoProduto> builder)
        {
            builder.ToTable("PedidoProduto");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnType("bigint");

            builder.Property(d => d.IdPedido).HasColumnType("bigint");
            builder.Property(d => d.IdProduto).HasColumnType("bigint");

            builder.HasOne(d => d.Pedido).WithMany().HasForeignKey(f => f.IdPedido);
            builder.HasOne(d => d.Produto).WithMany().HasForeignKey(f => f.IdProduto);
        }
    }
}
