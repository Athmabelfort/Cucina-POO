
using Cucina_POO.Model;
using Microsoft.EntityFrameworkCore;

namespace Cucina_POO.Data
{
    internal class CucinaDbContext : DbContext
    {
        public CucinaDbContext(DbContextOptions<CucinaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemDePedido> ItensDePedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cliente 1:N Endereco
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Endereco)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Restaurante 1:N Endereco (opcional)
            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Restaurante)
                .WithMany()
                .HasForeignKey(e => e.IdRestaurante)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Cliente 1:N Pedido
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Pedidos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.IdCliente)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Restaurante 1:N Produto
            modelBuilder.Entity<Restaurante>()
                .HasMany(r => r.Produtos)
                .WithOne(p => p.Restaurante)
                .HasForeignKey(p => p.IdRestaurante)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Pedido 1:N ItemDePedido
            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.ItemDePedido)
                .WithOne(i => i.Pedido)
                .HasForeignKey(i => i.IdPedido)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Produto 1:N ItemDePedido
            modelBuilder.Entity<Produto>()
                .HasMany(p => p.ItensDePedido)
                .WithOne(i => i.Produto)
                .HasForeignKey(i => i.IdProduto)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
