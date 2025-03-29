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

    public virtual DbSet<Musteriler> Musteriler { get; set; }

    public virtual DbSet<SiparisDetay> SiparisDetay { get; set; }

    public virtual DbSet<Siparisler> Siparisler { get; set; }

    public virtual DbSet<Urunler> Urunler { get; set; }

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
            entity.HasKey(sd => 
                          new {sd.SiparisId, sd.UrunId});

            entity.HasOne(d => d.Siparis).WithMany().HasForeignKey(d => d.SiparisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SiparisDe__Sipar__59FA5E80");

            entity.HasOne(d => d.Urun).WithMany().HasForeignKey(d => d.UrunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SiparisDe__UrunI__5BE2A6F2");
        });

        modelBuilder.Entity<Siparisler>(entity =>
        {
            entity.HasKey(e => e.SiparisId).HasName("PK__Siparisl__C3F03BFDE7BA8F4E");

            entity.HasOne(d => d.Musteri).WithMany(p => p.Siparisler).HasConstraintName("FK__Siparisle__Muste__5070F446");
        });

        modelBuilder.Entity<Urunler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Urunler__3214EC077A254878");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
