using Cadmus.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmus.Infra.Mapeamentos
{
    public class ClienteMapeamento : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnType("bigint");

            builder.Property(d => d.Nome).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(d => d.Email).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(d => d.Aldeia).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
