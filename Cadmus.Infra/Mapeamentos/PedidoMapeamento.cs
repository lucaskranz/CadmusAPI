using Cadmus.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadmus.Infra.Mapeamentos
{
    public class PedidoMapeamento : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnType("bigint");

            builder.Property(d => d.IdCliente).HasColumnType("bigint");
            builder.Property(d => d.Valor).HasColumnType("float");
            builder.Property(d => d.Desconto).HasColumnType("float");
            builder.Property(d => d.ValorTotal).HasColumnType("float");

            builder.HasOne(d => d.Cliente).WithMany().HasForeignKey(f => f.IdCliente);
        }
    }
}
