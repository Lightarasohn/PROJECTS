using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
    }
}