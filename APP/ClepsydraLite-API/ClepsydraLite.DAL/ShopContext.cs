using System;
using ClepsydraLite.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClepsydraLite.DAL
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext()
        {
            Database.EnsureCreated();
        }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=../products.db");
    }
}
