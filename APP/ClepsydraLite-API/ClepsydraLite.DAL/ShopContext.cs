using System;
using System.IO;
using ClepsydraLite.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ClepsydraLite.DAL
{
    //TODO: use SQL server
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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
        {
            public ShopDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "../../ClepsydraLite.API/appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<ShopDbContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);
                return new ShopDbContext(builder.Options);
            }
        }
    }
}
