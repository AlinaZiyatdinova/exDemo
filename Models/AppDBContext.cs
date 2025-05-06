using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfDemoZiaytdinova.Models;

public partial class AppDBContext : DbContext
{
    public AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerProduct> PartnerProducts { get; set; }

    public virtual DbSet<PartnerType> PartnerTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-D0U93NL\\SQLEXPRESS;Database=Company;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.ToTable("MaterialType");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Percent)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.ToTable("Partner");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Director)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Inn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("INN");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Raiting)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.PartnerType).WithMany(p => p.Partners)
                .HasForeignKey(d => d.PartnerTypeId)
                .HasConstraintName("FK_Partner_PartnerType");
        });

        modelBuilder.Entity<PartnerProduct>(entity =>
        {
            entity.ToTable("PartnerProduct");

            entity.Property(e => e.Count)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateSale)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Partner).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK_PartnerProduct_Partner");

            entity.HasOne(d => d.Product).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_PartnerProduct_Product");
        });

        modelBuilder.Entity<PartnerType>(entity =>
        {
            entity.ToTable("PartnerType");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Art)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MinPrice)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.MaterialType).WithMany(p => p.Products)
                .HasForeignKey(d => d.MaterialTypeId)
                .HasConstraintName("FK_Product_MaterialType");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .HasConstraintName("FK_Product_ProductType");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("ProductType");

            entity.Property(e => e.Coefficient)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductTypeName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
