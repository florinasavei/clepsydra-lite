using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClepsydraLite.DAL.Models.Supplier.Category;

namespace ClepsydraLite.DAL.Models.Shop
{
    public class ShopForCreationDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Telephone { get; set; }

    }
}
