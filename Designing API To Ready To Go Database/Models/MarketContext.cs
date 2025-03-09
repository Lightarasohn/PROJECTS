using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Designing_API_To_Ready_To_Go_Database.Models;

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
        });

        modelBuilder.Entity<SiparisDetay>(entity =>
        {
            entity.HasOne(d => d.Siparis).WithMany().HasConstraintName("FK__SiparisDe__Sipar__3F466844");

            entity.HasOne(d => d.Urun).WithMany().HasConstraintName("FK__SiparisDe__UrunI__403A8C7D");
        });

        modelBuilder.Entity<Siparisler>(entity =>
        {
            entity.HasKey(e => e.SiparisId).HasName("PK__Siparisl__C3F03BFD47E9E7AA");

            entity.Property(e => e.SiparisId).ValueGeneratedNever();

            entity.HasOne(d => d.Musteri).WithMany(p => p.Siparislers).HasConstraintName("FK__Siparisle__Muste__3D5E1FD2");
        });

        modelBuilder.Entity<Urunler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Urunler__3214EC07F4201B4A");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
