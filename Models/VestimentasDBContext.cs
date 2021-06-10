using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PracticaConBDD.Models
{
    public partial class VestimentasDBContext : DbContext
    {
        public VestimentasDBContext()
        {
        }

        public VestimentasDBContext(DbContextOptions<VestimentasDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Local> Locals { get; set; }
        public virtual DbSet<LocalPrendum> LocalPrenda { get; set; }
        public virtual DbSet<Prendum> Prenda { get; set; }
        public virtual DbSet<TipoPrendum> TipoPrenda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-II8LQJV\\SQLSERVER;Database=VestimentasDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Local>(entity =>
            {
                entity.HasKey(e => e.IdLocal);

                entity.ToTable("Local");

                entity.Property(e => e.Direccion).HasMaxLength(200);

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<LocalPrendum>(entity =>
            {
                entity.HasKey(e => new { e.IdPrenda, e.IdLocal })
                    .HasName("PK__LocalPre__863FCF8595700CFD");

                entity.HasOne(d => d.IdLocalNavigation)
                    .WithMany(p => p.LocalPrenda)
                    .HasForeignKey(d => d.IdLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LocalPren__IdLoc__4316F928");

                entity.HasOne(d => d.IdPrendaNavigation)
                    .WithMany(p => p.LocalPrenda)
                    .HasForeignKey(d => d.IdPrenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LocalPren__IdPre__4222D4EF");
            });

            modelBuilder.Entity<Prendum>(entity =>
            {
                entity.HasKey(e => e.IdPrenda)
                    .HasName("PK__prenda__2A17B41E30F1B3EC");

                entity.ToTable("prenda");

                entity.Property(e => e.IdPrenda).ValueGeneratedNever();

                entity.Property(e => e.Color).HasMaxLength(100);

                entity.Property(e => e.Marca).HasMaxLength(100);

                entity.Property(e => e.Modelo).HasMaxLength(100);

                entity.Property(e => e.Talle)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdTipoPrendaNavigation)
                    .WithMany(p => p.Prenda)
                    .HasForeignKey(d => d.IdTipoPrenda)
                    .HasConstraintName("FK__prenda__IdTipoPr__3C69FB99");
            });

            modelBuilder.Entity<TipoPrendum>(entity =>
            {
                entity.HasKey(e => e.IdTipoPrenda);

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
