using System;
using System.Collections.Generic;
using Designing_API_To_Ready_To_Go_Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Designing_API_To_Ready_To_Go_Database.Data;

public partial class MarketContext : DbContext
{
    public MarketContext()
    {
    }

    public MarketContext(DbContextOptions<MarketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Musteriler> Musterilers { get; set; }

    public virtual DbSet<SiparisDetay> SiparisDetays { get; set; }

    public virtual DbSet<Siparisler> Siparislers { get; set; }

    public virtual DbSet<Urunler> Urunlers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Musteriler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Musteril__3214EC079FFD8624");

            entity.ToTable("Musteriler");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Isim)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.KullaniciAdi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Kullanici Adi");
            entity.Property(e => e.ParolaH)
                .HasMaxLength(267)
                .IsUnicode(false);
            entity.Property(e => e.Soyisim)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SiparisDetay>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SiparisDetay");

            entity.HasOne(d => d.Siparis).WithMany()
                .HasForeignKey(d => d.SiparisId)
                .HasConstraintName("FK__SiparisDe__Sipar__3F466844");

            entity.HasOne(d => d.Urun).WithMany()
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK__SiparisDe__UrunI__403A8C7D");
        });

        modelBuilder.Entity<Siparisler>(entity =>
        {
            entity.HasKey(e => e.SiparisId).HasName("PK__Siparisl__C3F03BFD47E9E7AA");

            entity.ToTable("Siparisler");

            entity.Property(e => e.SiparisId).ValueGeneratedNever();
            entity.Property(e => e.MusteriId)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Musteri).WithMany(p => p.Siparislers)
                .HasForeignKey(d => d.MusteriId)
                .HasConstraintName("FK__Siparisle__Muste__3D5E1FD2");
        });

        modelBuilder.Entity<Urunler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Urunler__3214EC07F4201B4A");

            entity.ToTable("Urunler");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DepoMiktari).HasColumnName("Depo Miktari");
            entity.Property(e => e.Isim)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Kategori)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
