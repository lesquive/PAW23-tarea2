using Microsoft.EntityFrameworkCore;

namespace PAW23_tarea2.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProductoCategoria> ProductosCategorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("LaFruticaDbContext");
            }
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ProductoCategoria>()
                .HasKey(pc => new { pc.ProductoId, pc.CategoriaId });

            modelBuilder.Entity<ProductoCategoria>()
                .HasOne(pc => pc.Producto)
                .WithMany(p => p.ProductosCategorias)
                .HasForeignKey(pc => pc.ProductoId);

            modelBuilder.Entity<ProductoCategoria>()
                .HasOne(pc => pc.Categoria)
                .WithMany(c => c.ProductosCategorias)
                .HasForeignKey(pc => pc.CategoriaId);
        }
    }


}
