using System;
using Microsoft.EntityFrameworkCore;
using örnekproje.Models;

namespace tekkatmanproje.Data
{
    public class AppDbContext : DbContext
    {

        public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //public DbSet<Eleman>? Elemans { get; set; }
        //public DbSet<Departman>? Departmens { get; set; }

        public DbSet<Product> ?Products { get; set; }
        public DbSet<Category>?Categories { get; set; }
        public DbSet<User> ?Users { get; set; }

    }
}

