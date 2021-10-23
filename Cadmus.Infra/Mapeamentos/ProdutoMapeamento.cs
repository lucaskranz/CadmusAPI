using Cadmus.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadmus.Infra.Mapeamentos
{
    public class ProdutoMapeamento: IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnType("bigint");

            builder.Property(d => d.Descricao).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(d => d.Foto).HasColumnType("varchar").HasMaxLength(300);
            builder.Property(d => d.Valor).HasColumnType("float");
        }
    }
}
