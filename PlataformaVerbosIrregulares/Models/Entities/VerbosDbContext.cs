using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace PlataformaVerbosIrregulares.Models.Entities;

public partial class VerbosdbContext : DbContext
{
    public VerbosdbContext()
    {
    }

    public VerbosdbContext(DbContextOptions<VerbosdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estructuras> Estructuras { get; set; }

    public virtual DbSet<Oraciones> Oraciones { get; set; }

    public virtual DbSet<Reglas> Reglas { get; set; }

    public virtual DbSet<Verbosirregulares> Verbosirregulares { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=verbosdb;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Estructuras>(entity =>
        {
            entity.HasKey(e => e.IdEstructura).HasName("PRIMARY");

            entity.ToTable("estructuras");

            entity.Property(e => e.IdEstructura).HasColumnName("idEstructura");
            entity.Property(e => e.Auxiliar)
                .HasMaxLength(100)
                .HasColumnName("auxiliar");
            entity.Property(e => e.Complemento)
                .HasMaxLength(255)
                .HasColumnName("complemento");
            entity.Property(e => e.Modo)
                .HasMaxLength(20)
                .HasColumnName("modo");
            entity.Property(e => e.Sujeto)
                .HasMaxLength(100)
                .HasColumnName("sujeto");
            entity.Property(e => e.Tiempo)
                .HasMaxLength(20)
                .HasColumnName("tiempo");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");
            entity.Property(e => e.Verbo)
                .HasMaxLength(100)
                .HasColumnName("verbo");
        });

        modelBuilder.Entity<Oraciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("oraciones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.VerboBase)
                .HasMaxLength(50)
                .HasColumnName("verbo_base");
            entity.Property(e => e.VerboCorrecto)
                .HasMaxLength(50)
                .HasColumnName("verbo_correcto");
        });

        modelBuilder.Entity<Reglas>(entity =>
        {
            entity.HasKey(e => e.IdRegla).HasName("PRIMARY");

            entity.ToTable("reglas");

            entity.HasIndex(e => e.IdEstructura, "idEstructura");

            entity.Property(e => e.IdRegla).HasColumnName("idRegla");
            entity.Property(e => e.CambioEn)
                .HasMaxLength(50)
                .HasColumnName("cambioEn");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.IdEstructura).HasColumnName("idEstructura");

            entity.HasOne(d => d.IdEstructuraNavigation).WithMany(p => p.Reglas)
                .HasForeignKey(d => d.IdEstructura)
                .HasConstraintName("reglas_ibfk_1");
        });

        modelBuilder.Entity<Verbosirregulares>(entity =>
        {
            entity.HasKey(e => e.IdVerbo).HasName("PRIMARY");

            entity.ToTable("verbosirregulares");

            entity.Property(e => e.BaseForm).HasMaxLength(50);
            entity.Property(e => e.Espanol).HasMaxLength(80);
            entity.Property(e => e.Participle).HasMaxLength(50);
            entity.Property(e => e.Past).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
