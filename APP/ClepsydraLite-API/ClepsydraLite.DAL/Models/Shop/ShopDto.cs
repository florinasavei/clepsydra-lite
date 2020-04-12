using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClepsydraLite.DAL.Models.Supplier.Category;

namespace ClepsydraLite.DAL.Models.Shop
{
    public class ShopDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

    }
}
