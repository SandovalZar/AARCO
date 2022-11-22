using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Automoviles.Models.Entities;

#nullable disable

namespace Automoviles.Models.Context
{
    public partial class AutoContext : DbContext
    {
        public AutoContext()
        {
        }

        public AutoContext(DbContextOptions<AutoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Descripcion> Descripcion { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<SubModDes> SubModDes { get; set; }
        public virtual DbSet<Submarca> Submarca { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Descripcion>(entity =>
            {
                entity.Property(e => e.DescripcionId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubModDes>(entity =>
            {
                entity.HasOne(d => d.IdDesNavigation)
                    .WithMany(p => p.SubModDes)
                    .HasForeignKey(d => d.IdDes)
                    .HasConstraintName("FK_SubModDes_Descripcion");

                entity.HasOne(d => d.IdModNavigation)
                    .WithMany(p => p.SubModDes)
                    .HasForeignKey(d => d.IdMod)
                    .HasConstraintName("FK_SubModDes_Modelo");

                entity.HasOne(d => d.IdSubmNavigation)
                    .WithMany(p => p.SubModDes)
                    .HasForeignKey(d => d.IdSubm)
                    .HasConstraintName("FK_SubModDes_Submarca");
            });

            modelBuilder.Entity<Submarca>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Submarca)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_Submarca_Marca");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
