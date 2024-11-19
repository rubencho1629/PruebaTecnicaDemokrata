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
                entity.Property(u => u.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar")
                    .HasComment("Primer nombre del usuario");

                entity.Property(u => u.SegundoNombre)
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar")
                    .HasComment("Segundo nombre del usuario");

                entity.Property(u => u.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar")
                    .HasComment("Primer apellido del usuario");

                entity.Property(u => u.SegundoApellido)
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar")
                    .HasComment("Segundo apellido del usuario");

                entity.Property(u => u.FechaNacimiento)
                    .IsRequired()
                    .HasColumnType("datetime2");

                entity.Property(u => u.Sueldo)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(u => u.FechaCreacion)
                    .IsRequired()
                    .HasDefaultValueSql("GETDATE()")
                    .HasColumnType("datetime2");

                entity.Property(u => u.FechaModificacion)
                    .IsRequired()
                    .HasDefaultValueSql("GETDATE()")
                    .HasColumnType("datetime2");
            });
        }
    }
}
