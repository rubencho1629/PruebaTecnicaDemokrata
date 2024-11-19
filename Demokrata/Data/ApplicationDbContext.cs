using Demokrata.Models;
using Microsoft.EntityFrameworkCore;

namespace Demokrata.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(u => u.PrimerNombre).IsRequired().HasMaxLength(50);
                entity.Property(u => u.PrimerApellido).IsRequired().HasMaxLength(50);

                // Configuración para la columna Sueldo
                entity.Property(u => u.Sueldo)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)"); // Máximo 18 dígitos, 2 decimales

                entity.Property(u => u.FechaCreacion).HasDefaultValueSql("GETDATE()");
                entity.Property(u => u.FechaModificacion).HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
