using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class FestavaDataDBContext : DbContext
    {
        public FestavaDataDBContext(DbContextOptions options)
        : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}