using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClepsydraLite.DAL.Models.Supplier.Category
{
    public class SupplierProductCategoryForUpdateDto: SupplierProductCategoryForManipulationDto
    {
        [Required]
        public override  string Description
        {
            get => base.Description;
            set => base.Description = value;
        }
    }
}
