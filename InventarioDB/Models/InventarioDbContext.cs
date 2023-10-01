using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventarioDB.Models;

public partial class InventarioDbContext : DbContext
{
    public InventarioDbContext()
    {
    }

    public InventarioDbContext(DbContextOptions<InventarioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Entradum> Entrada { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Salidum> Salida { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(App.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entradum>(entity =>
        {
            entity.HasKey(e => e.EntradaId);

            entity.ToTable(tb => tb.HasTrigger("ActualizarCantidadEntrada"));

            entity.Property(e => e.EntradaId).HasColumnName("EntradaID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Observacion).HasMaxLength(60);
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Producto).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_Entrada_Producto");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK_Product");

            entity.ToTable("Producto");

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Responsable).HasMaxLength(50);
            entity.Property(e => e.Sku).HasColumnName("SKU");
            entity.Property(e => e.Valor).HasColumnType("decimal(12, 2)");
        });

        modelBuilder.Entity<Salidum>(entity =>
        {
            entity.HasKey(e => e.SalidaId);

            entity.ToTable(tb => tb.HasTrigger("ActualizarCantidadSalida"));

            entity.Property(e => e.SalidaId).HasColumnName("SalidaID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Observacion).HasMaxLength(60);
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Producto).WithMany(p => p.Salida)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_Salida_Producto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
