using System.Collections.Generic;
using ClepsydraLite.DAL.Models.Supplier.Category;

namespace ClepsydraLite.DAL.Models.Supplier
{
    public class SupplierForCreationDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<SupplierProductCategoryForCreationDto> SupplierProductCategories { get; set; } = new LinkedList<SupplierProductCategoryForCreationDto>();

    }
}
