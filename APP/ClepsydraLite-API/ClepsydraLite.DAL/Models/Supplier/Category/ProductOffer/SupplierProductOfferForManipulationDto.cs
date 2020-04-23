using System.ComponentModel.DataAnnotations;

namespace ClepsydraLite.DAL.Models.Supplier.Category.ProductOffer
{
    public abstract class SupplierProductOfferForManipulationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1500)]
        public virtual string Description { get; set; }
    }
}