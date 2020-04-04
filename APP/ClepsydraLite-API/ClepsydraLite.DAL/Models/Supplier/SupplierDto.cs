using System.Collections.Generic;
using ClepsydraLite.DAL.Models.Supplier.Category;

namespace ClepsydraLite.DAL.Models.Supplier
{
    public class SupplierDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public  IEnumerable<SupplierProductCategoryDto> SupplierProductCategories { get; set; } = new List<SupplierProductCategoryDto>();
    }
}
