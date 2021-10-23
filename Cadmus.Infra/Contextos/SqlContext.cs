using Cadmus.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmus.Infra.Contextos
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Cliente*/
            modelBuilder.Entity<Cliente>().Property(d => d.Id).HasColumnType("bigint");
            modelBuilder.Entity<Cliente>().Property(d => d.Nome).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Cliente>().Property(d => d.Email).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Cliente>().Property(d => d.Aldeia).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Cliente>().ToTable("Cliente").HasKey(d => d.Id);

            /*PedidoProduto*/
            modelBuilder.Entity<PedidoProduto>().ToTable("PedidoProduto");
            modelBuilder.Entity<PedidoProduto>().HasKey(d => d.Id);

            modelBuilder.Entity<PedidoProduto>().Property(d => d.Id).HasColumnType("bigint");
            modelBuilder.Entity<PedidoProduto>().Property(d => d.IdPedido).HasColumnType("bigint");
            modelBuilder.Entity<PedidoProduto>().Property(d => d.IdProduto).HasColumnType("bigint");

            modelBuilder.Entity<PedidoProduto>().HasOne(d => d.Pedido).WithMany().HasForeignKey(f => f.IdPedido);
            modelBuilder.Entity<PedidoProduto>().HasOne(d => d.Produto).WithMany().HasForeignKey(f => f.IdProduto);

            /*Produto*/
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Produto>().HasKey(d => d.Id);
            modelBuilder.Entity<Produto>().Property(d => d.Id).HasColumnType("bigint");

            modelBuilder.Entity<Produto>().Property(d => d.Descricao).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Produto>().Property(d => d.Foto).HasColumnType("varchar").HasMaxLength(300);
            modelBuilder.Entity<Produto>().Property(d => d.Valor).HasColumnType("decimal");

            /*Pedido*/
            modelBuilder.Entity<Pedido>().ToTable("Pedido");
            modelBuilder.Entity<Pedido>().HasKey(d => d.Id);
            modelBuilder.Entity<Pedido>().Property(d => d.Id).HasColumnType("bigint");

            modelBuilder.Entity<Pedido>().Property(d => d.IdCliente).HasColumnType("bigint");
            modelBuilder.Entity<Pedido>().Property(d => d.Valor).HasColumnType("decimal");
            modelBuilder.Entity<Pedido>().Property(d => d.Desconto).HasColumnType("decimal");
            modelBuilder.Entity<Pedido>().Property(d => d.ValorTotal).HasColumnType("decimal");

            modelBuilder.Entity<Pedido>().HasOne(d => d.Cliente).WithMany().HasForeignKey(f => f.IdCliente);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public bool Commit()
        {
            return SaveChanges() > 0;
        }
    }
}
