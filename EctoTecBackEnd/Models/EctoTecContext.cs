using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EctoTecBackEnd.Models
{
    public partial class EctoTecContext : DbContext
    {
        public EctoTecContext()
        {
        }

        public EctoTecContext(DbContextOptions<EctoTecContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudades { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Pais> Paises { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LUISLG-PC; Database=EctoTec; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.Idciudad);

                entity.ToTable("ciudad");

                entity.Property(e => e.Idciudad).HasColumnName("idciudad");

                entity.Property(e => e.CiudadNombre)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.Idestado).HasColumnName("idestado");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("estado");

                entity.Property(e => e.EstadoNombre)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Idestado)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idestado");

                entity.Property(e => e.Idpais).HasColumnName("idpais");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.Idpais);

                entity.ToTable("pais");

                entity.Property(e => e.Idpais).HasColumnName("idpais");

                entity.Property(e => e.PaisNombre)
                    .IsUnicode(false)
                    .HasColumnName("pais");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");

                entity.Property(e => e.Nombre)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
