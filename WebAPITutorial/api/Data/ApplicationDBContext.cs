using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace api.Data
{
    //IdentityDbContext, DbContext'in aynısı olup sadece <T> sınıfına verilen değeri
    //">dotnet ef migrations add Identity" ile database'e eklemeye yarar
    //Daha sonrasında kullanıcı rolleri için de işimize yarayacaktır
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        //Database üzerinden Rolleri ayarlamak yerine rol ayarlamasını AspNetCore'a bırakabilriiz
        //OnModelCreating() methodu ApplicationDbContext sınıfına aittir
        //Database'e rol eklemek için kullanırız
        /*RegisterDto, AccountController yazıldıktan sonra roller oluşturulur 
        ve sırası ile "dotnet ef migrations <MigrationName>" ve "dotnet ef database update"
        komutları çağırılarak Database'de tablolar oluşturulur ve veriler eklenir
        (Not önemlidir) 
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Portfolio>(x => x.HasKey(p => new{p.AppUserId, p.StockId}));

            modelBuilder.Entity<Portfolio>()
            .HasOne(u => u.AppUser)
            .WithMany(u => u.Portfolios)
            .HasForeignKey(p => p.AppUserId);

            modelBuilder.Entity<Portfolio>()
            .HasOne(u => u.Stock)
            .WithMany(u => u.Portfolios)
            .HasForeignKey(p => p.StockId);

            List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                /*
                Not: ASP.NET 9.0 versiyonunda Id ve ConcurrencyStamp değerleri atanmalıdır
                */
                Id = "Admin",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = null

            },
            new IdentityRole
            {
                /*
                Not: ASP.NET 9.0 versiyonunda Id ve ConcurrencyStamp değerleri atanmalıdır
                */
                Id = "User",
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = null

            }
        };
            //Rollerin Data'ya erişimi verilir
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}