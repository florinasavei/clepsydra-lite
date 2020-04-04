using System;
using System.Collections.Generic;
using System.Text;

namespace ClepsydraLite.DAL.Models.Supplier.Category
{
    public class SupplierProductCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int SupplierId { get; set; }
    }
}
