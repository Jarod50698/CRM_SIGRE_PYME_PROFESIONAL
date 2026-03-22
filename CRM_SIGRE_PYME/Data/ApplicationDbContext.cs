using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CRM_SIGRE_PYME.Models;

namespace CRM_SIGRE_PYME.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalles { get; set; }
        public DbSet<MovimientoInventario> MovimientosInventario { get; set; }
        public DbSet<LogSeguridad> LogsSeguridad { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region PRODUCTO

            builder.Entity<Producto>()
                .HasIndex(p => p.SKU)
                .IsUnique();

            builder.Entity<Producto>()
                .Property(p => p.PrecioCompra)
                .HasPrecision(18, 2);

            builder.Entity<Producto>()
                .Property(p => p.PrecioVenta)
                .HasPrecision(18, 2);

            #endregion

            #region CLIENTE → PEDIDOS

            builder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region USUARIO → PEDIDOS

            builder.Entity<Pedido>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Pedidos)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region PEDIDO → DETALLES

            builder.Entity<PedidoDetalle>()
                .HasOne(pd => pd.Pedido)
                .WithMany(p => p.Detalles)
                .HasForeignKey(pd => pd.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region PRODUCTO → DETALLES

            builder.Entity<PedidoDetalle>()
                .HasOne(pd => pd.Producto)
                .WithMany(p => p.PedidoDetalles)
                .HasForeignKey(pd => pd.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region PRODUCTO → MOVIMIENTOS

            builder.Entity<MovimientoInventario>()
                .HasOne(m => m.Producto)
                .WithMany(p => p.Movimientos)
                .HasForeignKey(m => m.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region LOG SEGURIDAD

            builder.Entity<LogSeguridad>()
                .HasOne(l => l.Usuario)
                .WithMany()
                .HasForeignKey(l => l.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<LogSeguridad>()
                .Property(l => l.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<LogSeguridad>()
                .Property(l => l.Tipo)
                .HasDefaultValue("INFO");

            #endregion
        }
    }
}