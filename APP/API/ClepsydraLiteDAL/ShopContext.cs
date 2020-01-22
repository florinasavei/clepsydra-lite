using System;
using System.Collections.Generic;
using ClepsydraDALCommon;
using Microsoft.EntityFrameworkCore;

namespace ClepsydraLiteDAL
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=products.db");
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public List<Price> Prices { get; } = new List<Price>();
    }

    public class Price
    {
        public int PriceId { get; set; }
        public PriceType PriceType { get; set; }
        public decimal PriceValue { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
